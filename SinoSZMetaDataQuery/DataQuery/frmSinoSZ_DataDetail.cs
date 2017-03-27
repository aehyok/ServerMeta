using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using SinoSZMetaDataQuery.Common;
using SinoSZPluginFramework;
using DevExpress.XtraTreeList.Nodes;

using SinoSZJS.Base;
using SinoSZMetaDataQuery.DataSearch;
using System.Threading;

using SinoSZJS.Base.MetaData.QueryModel;
using System.Linq;
using SinoSZJS.Base.MetaData.Common;
using SinoSZClientBase.Cache;
using SinoSZJS.Base.Controller;
using SinoSZClientBase.MetaDataQueryService;

namespace SinoSZMetaDataQuery.DataQuery
{
    public partial class frmSinoSZ_DataDetail : DevExpress.XtraEditors.XtraForm, IChildForm
    {
        private IApplication _application = null;
        private bool _initFinished = false;
        private string CurrentTaskID = "";
        private string CurrentVEHICode = "";
        private MDQuery_Task QueryTaskID_BGD = null;
        private MDModel_QueryModel QueryModel = null;
        private string MainKeyID = "";
        private Dictionary<string, Panel> ChildTablePanel = new Dictionary<string, Panel>();
        private List<MDQuery_ChildTableRowCount> _childRowCountList = new List<MDQuery_ChildTableRowCount>();
        private DataTable ResultData = null;
        private MDSearch_ResultDataIndex SearchResutIndex = null;
        public frmSinoSZ_DataDetail()
        {
            InitializeComponent();
        }

        public frmSinoSZ_DataDetail(MDModel_QueryModel _model, string _keyid)
        {
            InitializeComponent();
            QueryModel = _model;
            MainKeyID = _keyid;
            this.Text = string.Format("{0}的详细信息", _model.DisplayName);
            ShowKKPanel();
        }

        public frmSinoSZ_DataDetail(MDSearch_ResultDataIndex _searchResutIndex)
        {
            InitializeComponent();
            QueryModel = MetaDataCache.GetQueryModelDefine(_searchResutIndex.SourceColumn.QueryModel.FullName);
            using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
            {
                MainKeyID = _msc.GetMainTableKeyByChildKey(_searchResutIndex.SourceColumn, _searchResutIndex.MainKey);
            }
            this.Text = string.Format("{0}的详细信息", QueryModel.DisplayName);
            SearchResutIndex = _searchResutIndex;
            ShowKKPanel();
        }

        private void ShowKKPanel()
        {
            if (QueryModel.MainTable.TableName == "VEHI_SZ_FORMBIND")
            {
                this.panelKKCX.Visible = true;
            }
            else
            {
                this.panelKKCX.Visible = false;
            }
        }


        private void ShowHotData(MDSearch_ResultDataIndex _searchResutIndex)
        {
            //显示信息热点，暂不实现

        }



        private void ShowRelationData()
        {
            this.treeList1.BeginUpdate();
            this.treeList1.Nodes.Clear();
            TreeListNode _RootNode = this.treeList1.AppendNode(0, null);
            _RootNode.SetValue("COLUMN1", this.QueryModel.DisplayName);
            _RootNode.SetValue("State", 2);
            _RootNode.ImageIndex = 1;
            _RootNode.Expanded = true;
            //XtraMessageBox.Show(_watch.GetHistory());                    

            _RootNode.ExpandAll();
            this.treeList1.EndUpdate();
        }


        #region 实现IChildFrom接口

        public IApplication Application
        {
            get { return _application; }
            set { _application = value; }
        }

        public event EventHandler<EventArgs> MenuChanged;
        virtual public void RaiseMenuChanged()
        {
            if (this._initFinished && MenuChanged != null)
            {
                MenuChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// 取辅助菜单页
        /// </summary>
        /// <returns></returns>
        public IList<FrmMenuPage> GetMenuPages()
        {
            IList<FrmMenuPage> _ret = new List<FrmMenuPage>();
            FrmMenuPage _page = new FrmMenuPage("详细信息");
            _page.MenuGroups = GetMenuGroups(_page.PageTitle);
            _ret.Add(_page);
            return _ret;
        }

        /// <summary>
        /// 取菜单组
        /// </summary>
        /// <param name="_pagename"></param>
        /// <returns></returns>
        private IList<FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();
            FrmMenuGroup _thisGroup = new FrmMenuGroup("详细信息");

            _thisGroup.MenuItems = new List<FrmMenuItem>();
            FrmMenuItem _item = new FrmMenuItem("导出", "导出", global::SinoSZMetaDataQuery.Properties.Resources.x3, true);
            _thisGroup.MenuItems.Add(_item);
            _item = new FrmMenuItem("打印", "打印", global::SinoSZMetaDataQuery.Properties.Resources.x4, true);
            _thisGroup.MenuItems.Add(_item);
            _ret.Add(_thisGroup);
            return _ret;
        }


        /// <summary>
        /// 执行菜单命令
        /// </summary>
        /// <param name="_cmdName"></param>
        /// <returns></returns>
        public bool DoCommand(string _cmdName)
        {
            switch (_cmdName)
            {
                case "打印":
                    PrintDetailInfoPanel _pc = new PrintDetailInfoPanel(this.PanelDetail, PrintDetailInfoPanel.FontType.Small);
                    _pc.Print();
                    break;
                case "导出":
                    return ExportDetialData();

            }
            return true;
        }




        #endregion

        private bool ExportDetialData()
        {
            SaveFileDialog _sf = new SaveFileDialog();
            _sf.Filter = "Excle文件|*.xls";
            _sf.FilterIndex = 1;
            string _fname = "";
            while (_fname == "")
            {
                if (_sf.ShowDialog() == DialogResult.OK)
                {
                    _fname = _sf.FileName;
                    if (_fname != "")
                    {
                        ExportDetailInfoPanel _ep = new ExportDetailInfoPanel(this.PanelDetail);
                        _ep.Export(_fname);
                        if (XtraMessageBox.Show("已生成，是否打开？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(_fname);
                        }
                        return true;
                    }
                    else
                    {
                        XtraMessageBox.Show("请输入导出文件名！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private void treeList1_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            object _stobj = e.Node.GetValue("State");
            if (_stobj == null) return;
            int _st = (int)_stobj;
            e.NodeImageIndex = _st;
        }

        private void treeList1_StateImageClick(object sender, DevExpress.XtraTreeList.NodeClickEventArgs e)
        {
            Panel _panel = null;
            object _stobj = e.Node.GetValue("State");
            if (_stobj == null) return;

            int _st = (int)_stobj;
            if (_st == 2) return;

            _st += 1;
            if (_st > 1)
            {
                _st = 0;
            }

            e.Node.SetValue("State", _st);
            MDModel_Table _table = e.Node.Tag as MDModel_Table;

            if (!ChildTablePanel.ContainsKey(_table.TableName))
            {
                _panel = CreatePanel(_table);
            }
            else
            {
                _panel = ChildTablePanel[_table.TableName];
            }

            switch (_st)
            {
                case 0:      //未选中
                    _panel.Visible = false;
                    break;
                case 1:　　//选中
                    _panel.Visible = true;
                    _panel.BringToFront();
                    break;
            }

        }

        private Panel CreatePanel(MDModel_Table _ctable)
        {
            Panel _panel = new Panel();
            _panel.Height = 0;
            DataTable _cdt;
            using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
            {
                _cdt = _msc.GetChildTableDataByKey(this.QueryModel.FullQueryModelName,
                                               _ctable.TableName, this.MainKeyID);
            }
            if (_cdt != null)
            {
                int i = 1;
                foreach (DataRow _dr in _cdt.Rows)
                {
                    SinoSZUC_RecordData _crd = new SinoSZUC_RecordData(_ctable, _dr, i++);
                    _crd.Dock = DockStyle.Top;
                    _panel.Controls.Add(_crd);
                    _crd.BringToFront();
                    _panel.Height += _crd.Height;
                }
            }
            _panel.Visible = false;
            _panel.Dock = DockStyle.Top;
            this.PanelDetail.Controls.Add(_panel);
            ChildTablePanel.Add(_ctable.TableName, _panel);
            return _panel;
        }

        private void treeList1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeListNode _node = this.treeList1.FocusedNode;
            if (_node != null)
            {
                if (_node.Tag != null)
                {
                    MDModel_Table _table = _node.Tag as MDModel_Table;
                    frmSinoSZ_ChildDetail _form = new frmSinoSZ_ChildDetail(this.QueryModel, _table, this.MainKeyID);
                    _application.AddForm(_table.TableName + this.MainKeyID, _form);
                }
            }
        }

        private void frmSinoSZ_DataDetail_Load(object sender, EventArgs e)
        {
            this.labelState.Text = string.Format("正在搜索关联表 ....");
            this.progressBarControl1.Visible = false;
            this.marqueeProgressBarControl1.Properties.Stopped = false;
            this.backgroundWorker2.RunWorkerAsync();

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
            {
                ResultData = _msc.GetMainTableDataByKey(this.QueryModel.FullQueryModelName,
                                                       this.QueryModel.MainTable.TableName, this.MainKeyID);
            }

        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowData(ResultData);
            ShowHotData(SearchResutIndex);
            ShowRelationData();
            this.panelControl2.Visible = false;
            this.marqueeProgressBarControl1.Properties.Stopped = true;
            this.progressBarControl1.Visible = true;
            this.backgroundWorker1.RunWorkerAsync();
            this.timer2.Enabled = true;
        }



        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //decimal i = 0;
            //decimal _count = Convert.ToDecimal(this.QueryModel.ChildTableDict.Count);

            //foreach (MDModel_Table _ctable in this.QueryModel.ChildTableDict.Values)
            //{

            //        decimal _progress = i / _count * 100;
            //        int _ret = SinoSZQueryConfig.MetaDataFactroy.GetChildTableCountByKey(this.QueryModel.QueryModelName, _ctable.TableName, this.MainKeyID);
            //        if (_ret > 0)
            //        {
            //                MDQuery_ChildTableRowCount _item = new MDQuery_ChildTableRowCount(_ctable.TableName, _ret);
            //                this.backgroundWorker1.ReportProgress(Convert.ToInt32(_progress), _item);
            //        }
            //        i++;
            //}
            using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
            {
                this._childRowCountList = _msc.GetChildRowCountList(this.QueryModel.FullQueryModelName, this.MainKeyID).ToList<MDQuery_ChildTableRowCount>();
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //MDQuery_ChildTableRowCount _obj = e.UserState as MDQuery_ChildTableRowCount;

            //MDModel_Table _ctable = this.QueryModel.ChildTableDict[_obj.TableName];
            //TreeListNode _node = this.treeList1.AppendNode(0, 0);
            //_node.SetValue("COLUMN1", _ctable.TableDefine.DisplayTitle);
            //_node.SetValue("COLUMN2", _obj.RowCount);
            //_node.SetValue("State", 0);
            //_node.Tag = _ctable;
            //_node.ImageIndex = 0;
            //_node.ParentNode.ExpandAll();
            //this.progressBarControl1.Position = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            this.progressBarControl1.Position = 100;
            int _relationCount = 0;
            foreach (MDQuery_ChildTableRowCount _obj in this._childRowCountList)
            {
                if (_obj.RowCount > 0)
                {
                    _relationCount += _obj.RowCount;
                    MDModel_Table _ctable = this.QueryModel.ChildTableDict[_obj.TableName];
                    TreeListNode _node = this.treeList1.AppendNode(0, 0);
                    _node.SetValue("COLUMN1", _ctable.TableDefine.DisplayTitle);
                    _node.SetValue("COLUMN2", _obj.RowCount);
                    _node.SetValue("State", 0);
                    _node.Tag = _ctable;
                    _node.ImageIndex = 0;
                }
            }
            this.labelState.Text = string.Format("共检索到{0}条关联记录!", _relationCount);
            this.progressBarControl1.Visible = false;
            this.treeList1.ExpandAll();
            this.timer2.Enabled = false;
        }



        private void timer2_Tick(object sender, EventArgs e)
        {
            this.progressBarControl1.Increment(5);
            if (this.progressBarControl1.Position > 90) this.progressBarControl1.Position = 0;
        }



        private void ShowData(DataTable _dt)
        {
            ChildTablePanel.Clear();
            this.PanelDetail.Controls.Clear();

            DataRow _dr = null;

            if (_dt != null)
            {
                if (_dt.Rows.Count > 0) _dr = _dt.Rows[0];
            }
            SinoSZUC_RecordData _rd = new SinoSZUC_RecordData(QueryModel.MainTable, _dr);
            _rd.Dock = DockStyle.Top;
            this.PanelDetail.Controls.Add(_rd);
            _rd.BringToFront();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            switch (this.simpleButton1.Text)
            {
                case "开始查询":
                    //旧的异步查询方法已经废弃，现用同步查询
                    /*
                    this.simpleButton1.Visible = false;
                    string _rfname = "";
                    //this.queryWaitingPanel1.Visible = true;
                    // this.queryWaitingPanel1.SetWait("查询任务已发！");
                    this.CurrentTaskID = GetQueryTaskID(ref _rfname);
                    if (CurrentTaskID != "")
                    {
                            this.panel_BGDMSG.Visible = true;
                            Msg_HGBGD.Text = string.Format("请到查询任务列表中查看结果！\r\n{0}", _rfname);
                            this.bgWorker_BGD.RunWorkerAsync();
                    }
                     * 
                     * * */
                    StartQueryOtherLib();
                    break;


                case "查看详细":
                    frmSinoSZ_QueryResult _qr = new frmSinoSZ_QueryResult(this.QueryTaskID_BGD);
                    _application.AddForm(Guid.NewGuid().ToString(), _qr);
                    break;

            }
        }

        private string StartQueryOtherLib()
        {
            string _ret = "";
            string Task_Name = "";
            string _taskid = "";
            MDQuery_Request _request;
            if (ResultData == null) return "";
            if (ResultData.Rows.Count < 1) return "";
            var _find = from _c in this.QueryModel.MainTable.Columns
                        where _c.ColumnName == "FORM_ID"
                        select _c;
            if (_find == null || _find.Count() < 1) return "";
            MDModel_Table_Column tc_FORM_ID = this.QueryModel.MainTable.GetColumnByName("FORM_ID");
            MDModel_Table_Column tc_FORM_TYPE = this.QueryModel.MainTable.GetColumnByName("FORM_TYPE");
            MDModel_Table_Column tc_I_E_PORT = this.QueryModel.MainTable.GetColumnByName("I_E_PORT");
            MDModel_Table_Column tc_I_E_FLAG = this.QueryModel.MainTable.GetColumnByName("I_E_FLAG");
            MDModel_Table_Column tc_I_E_DATETIME = this.QueryModel.MainTable.GetColumnByName("I_E_DATETIME");
            MDModel_Table_Column tc_VE_CUSTOMS_NO = this.QueryModel.MainTable.GetColumnByName("VE_CUSTOMS_NO");
            DataRow _dr = ResultData.Rows[0];
            string _formType = _dr[tc_FORM_TYPE.ColumnAlias].ToString().Trim();
            string _formID = _dr[tc_FORM_ID.ColumnAlias].ToString().Trim();
            string _portCode = _dr[tc_I_E_PORT.ColumnAlias].ToString().Trim();
            string _customs_no = _dr[tc_VE_CUSTOMS_NO.ColumnAlias].ToString().Trim();
            _portCode = _portCode.Substring(0, 2);

            string _IEFlag = _dr[tc_I_E_FLAG.ColumnAlias].ToString().Trim();
            string _IEFlagNum = (_IEFlag == "I") ? "1" : "0";
            DateTime I_E_Date = (DateTime)_dr[tc_I_E_DATETIME.ColumnAlias];
            DateTime Min_SB_Date = I_E_Date.AddMonths(-1);
            switch (_formType)
            {
                case "1":			//清单
                    XtraMessageBox.Show("本记录为清单，无法查询详细内容", "系统提示");
                    return "";

                case "2":			//报关单

                    string _FormIDPre = _formID.Substring(0, 2);
                    //生成一个单号
                    _ret = string.Format("{0}{1}{2}", I_E_Date.Year, _IEFlagNum, _formID);
                    _request = CreateBGDQueryRequest2(I_E_Date, _IEFlagNum, _formID);
                    string _qvName = "HG_GDFS.海关报关单";
                    MDModel_QueryModel _qv = MetaDataCache.GetQueryModelDefine(_qvName);
                    frmSinoSZ_QueryResult _qr = new frmSinoSZ_QueryResult(_qv, _request, false);
                    _application.AddForm(Guid.NewGuid().ToString(), _qr);
                    return _taskid;


                case "4":			//转关单
                    string _prestr = _formID.Substring(0, 4);
                    if (_prestr == "1000" || _prestr == "5000")
                    {
                        _request = CreateZGDQueryRequest("@" + _formID, Min_SB_Date, I_E_Date);
                        Task_Name = string.Format("查询编号为{0}的转关单[{1}]", _ret, DateTime.Now.ToString("yyyyMMdd"));
                        using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                        {
                            _taskid = _msc.AddNewQueryTask(Task_Name, _request);
                        }
                        return _taskid;
                    }
                    break;
            }

            return "";
        }



        private string GetQueryTaskID(ref string rfname)
        {
            string _ret = "";
            rfname = "";
            string Task_Name = "";
            string _taskid = "";
            MDQuery_Request _request;
            if (ResultData == null) return "";
            if (ResultData.Rows.Count < 1) return "";
            if (this.QueryModel.MainTable.GetColumnByName("FORM_ID") == null) return "";
            MDModel_Table_Column tc_FORM_ID = this.QueryModel.MainTable.GetColumnByName("FORM_ID");
            MDModel_Table_Column tc_FORM_TYPE = this.QueryModel.MainTable.GetColumnByName("FORM_TYPE");
            MDModel_Table_Column tc_I_E_PORT = this.QueryModel.MainTable.GetColumnByName("I_E_PORT");
            MDModel_Table_Column tc_I_E_FLAG = this.QueryModel.MainTable.GetColumnByName("I_E_FLAG");
            MDModel_Table_Column tc_I_E_DATETIME = this.QueryModel.MainTable.GetColumnByName("I_E_DATETIME");
            MDModel_Table_Column tc_VE_CUSTOMS_NO = this.QueryModel.MainTable.GetColumnByName("VE_CUSTOMS_NO");
            DataRow _dr = ResultData.Rows[0];
            string _formType = _dr[tc_FORM_TYPE.ColumnAlias].ToString().Trim();
            string _formID = _dr[tc_FORM_ID.ColumnAlias].ToString().Trim();
            string _portCode = _dr[tc_I_E_PORT.ColumnAlias].ToString().Trim();
            string _customs_no = _dr[tc_VE_CUSTOMS_NO.ColumnAlias].ToString().Trim();
            _portCode = _portCode.Substring(0, 2);

            string _IEFlag = _dr[tc_I_E_FLAG.ColumnAlias].ToString().Trim();
            string _IEFlagNum = (_IEFlag == "I") ? "1" : "0";
            DateTime I_E_Date = (DateTime)_dr[tc_I_E_DATETIME.ColumnAlias];
            DateTime Min_SB_Date = I_E_Date.AddMonths(-1);
            switch (_formType)
            {
                case "1":			//清单
                    return "";
                case "2":			//报关单

                    string _FormIDPre = _formID.Substring(0, 2);
                    //采用改正过的算法
                    //if (I_E_Date.Year == Min_SB_Date.Year)
                    //{
                    //        //生成一个单号
                    //        _ret = string.Format("{0}{1}{2}{3}{4}", _portCode, _FormIDPre, I_E_Date.Year, _IEFlagNum, _formID);
                    //}
                    //else
                    //{
                    //        //生成两个单号
                    //        string _d1 = string.Format("{0}{1}{2}{3}{4}", _portCode, _FormIDPre, I_E_Date.Year, _IEFlagNum, _formID);
                    //        string _d2 = string.Format("{0}{1}{2}{3}{4}", _portCode, _FormIDPre, Min_SB_Date.Year, _IEFlagNum, _formID);
                    //        _ret = string.Format("{0},{1}", _d1, _d2);
                    //}

                    //生成一个单号
                    _ret = string.Format("{0}{1}{2}", I_E_Date.Year, _IEFlagNum, _formID);
                    _request = CreateBGDQueryRequest(_ret);
                    Task_Name = string.Format("查询车辆[{2}]于{1}进出口岸时所载货物的报关单[{0}]", _ret, I_E_Date.ToString("yyyy年MM月dd日"), _customs_no);
                    rfname = string.Format("报关单编号为[{0}]的查询任务", _ret);
                    using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                    {
                        _taskid = _msc.AddNewQueryTask(Task_Name, _request);
                    }
                    return _taskid;


                case "4":			//转关单
                    string _prestr = _formID.Substring(0, 4);
                    if (_prestr == "1000" || _prestr == "5000")
                    {
                        _request = CreateZGDQueryRequest("@" + _formID, Min_SB_Date, I_E_Date);
                        Task_Name = string.Format("查询编号为{0}的转关单[{1}]", _ret, DateTime.Now.ToString("yyyyMMdd"));
                        using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                        {
                            _taskid = _msc.AddNewQueryTask(Task_Name, _request);
                        }
                        return _taskid;
                    }
                    break;
            }

            return "";
        }



        private void simpleButton2_Click(object sender, EventArgs e)
        {
            switch (this.simpleButton2.Text)
            {
                case "开始查询":
                    this.simpleButton2.Visible = false;
                    this.queryWaitingPanel2.Visible = true;
                    this.queryWaitingPanel2.SetWait();
                    CurrentVEHICode = GetCurrentVEHIData();
                    if (CurrentVEHICode != "")
                    {
                        //this.bgWorker_AJ.RunWorkerAsync();
                    }
                    break;

                case "查看详细":

                    break;

            }
        }

        private string GetCurrentVEHIData()
        {
            if (ResultData == null) return "";
            if (ResultData.Rows.Count < 1) return "";
            if (this.QueryModel.MainTable.GetColumnByName("VE_CUSTOMS_NO") == null) return "";
            MDModel_Table_Column _tc = this.QueryModel.MainTable.GetColumnByName("VE_CUSTOMS_NO");
            return ResultData.Rows[0][_tc.ColumnAlias].ToString();
        }

        private void bgWorker_BGD_DoWork(object sender, DoWorkEventArgs e)
        {
            //建查询			
            bool IsQuerying = true;
            while (IsQuerying)
            {
                Thread.Sleep(3000);
                using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                {
                    QueryTaskID_BGD = _msc.GetQueryTaskStateByID(CurrentTaskID);
                }
                if (QueryTaskID_BGD.TaskState > 2) IsQuerying = false;
            }

        }

        private MDQuery_Request CreateZGDQueryRequest(string _dh, DateTime _sdate, DateTime _edate)
        {
            string _qvName = "HG_GDFS.海关报关单";
            MDModel_QueryModel _qv = MetaDataCache.GetQueryModelDefine(_qvName);
            MC_QueryRequsetFactory _rf = new MC_QueryRequsetFactory();
            _rf.QueryModelName = _qvName;
            //加条件
            MDQuery_ConditionItem _cItem = new MDQuery_ConditionItem();
            _cItem.ColumnIndex = "1";
            _cItem.Column = new MDQuery_TableColumn(_qv.MainTable.GetColumnByName("VOYAGE_NO"));
            _cItem.Operator = "等于";
            _cItem.Values = new List<string>();
            _cItem.Values.Add(_dh);
            _rf.AddConditonItem(_cItem);

            _cItem = new MDQuery_ConditionItem();
            _cItem.ColumnIndex = "2";
            _cItem.Column = new MDQuery_TableColumn(_qv.MainTable.GetColumnByName("D_DATE"));
            _cItem.Operator = "时间段";
            _cItem.Values = new List<string>();
            _cItem.Values.Add(_sdate.ToString("yyyyMMdd"));
            _cItem.Values.Add(_edate.ToString("yyyyMMdd"));
            _rf.AddConditonItem(_cItem);
            _rf.AddExpression("1*2");

            //加结果
            _rf.AddResultTable(_qv.MainTable);
            foreach (MDModel_Table_Column _tc in _qv.MainTable.Columns)
            {
                _rf.AddResultTableColumn(_qv.MainTable, _tc);
            }
            foreach (string _cTName in _qv.ChildTableDict.Keys)
            {
                MDModel_Table _ctable = _qv.ChildTableDict[_cTName];
                _rf.AddResultTable(_ctable);
                foreach (MDModel_Table_Column _ccol in _ctable.Columns)
                {
                    _rf.AddResultTableColumn(_ctable, _ccol);
                }
            }
            return _rf.GetQueryRequest();
        }
        private MDQuery_Request CreateBGDQueryRequest2(DateTime I_E_Date, string _IEFlagNum, string _formID)
        {
            string _qvName = "HG_GDFS.海关报关单";
            MDModel_QueryModel _qv = MetaDataCache.GetQueryModelDefine(_qvName);
            MC_QueryRequsetFactory _rf = new MC_QueryRequsetFactory();
            _rf.QueryModelName = _qvName;
            //加条件  D_Date> I_E_DATE-半年
            MDQuery_ConditionItem _cItem_startDate = new MDQuery_ConditionItem();
            _cItem_startDate.ColumnIndex = "1";
            _cItem_startDate.Column = new MDQuery_TableColumn(_qv.MainTable.GetColumnByName("D_DATE"));
            _cItem_startDate.Operator = "大于";
            _cItem_startDate.Values = new List<string>();
            DateTime _startDate = I_E_Date.AddMonths(-6);
            _cItem_startDate.Values.Add(_startDate.ToString("yyyyMMdd"));
            _rf.AddConditonItem(_cItem_startDate);

            //加条件 ENTRY_ID_SHORT = 进出口标志+单证号
            MDQuery_ConditionItem _cItem = new MDQuery_ConditionItem();
            _cItem.ColumnIndex = "2";
            _cItem.Column = new MDQuery_TableColumn(_qv.MainTable.GetColumnByName("ENTRY_ID_SHORT"));
            _cItem.Operator = "等于";
            _cItem.Values = new List<string>();
            _cItem.Values.Add(string.Format("{0}{1}", _IEFlagNum, _formID));
            _rf.AddConditonItem(_cItem);

            //加条件 D_DATE<I_E_DATE
            MDQuery_ConditionItem _cItem_endDate = new MDQuery_ConditionItem();
            _cItem_endDate.ColumnIndex = "3";
            _cItem_endDate.Column = new MDQuery_TableColumn(_qv.MainTable.GetColumnByName("D_DATE"));
            _cItem_endDate.Operator = "小于";
            _cItem_endDate.Values = new List<string>();
            DateTime _endDate = I_E_Date.AddDays(1);
            _cItem_endDate.Values.Add(_endDate.ToString("yyyyMMdd"));
            _rf.AddConditonItem(_cItem_endDate);


            _rf.AddExpression("1*2*3");

            //加结果
            _rf.AddResultTable(_qv.MainTable);
            foreach (MDModel_Table_Column _tc in _qv.MainTable.Columns)
            {
                _rf.AddResultTableColumn(_qv.MainTable, _tc);
            }
            foreach (string _cTName in _qv.ChildTableDict.Keys)
            {
                MDModel_Table _ctable = _qv.ChildTableDict[_cTName];
                _rf.AddResultTable(_ctable);
                foreach (MDModel_Table_Column _ccol in _ctable.Columns)
                {
                    _rf.AddResultTableColumn(_ctable, _ccol);
                }
            }
            return _rf.GetQueryRequest();
        }

        private MDQuery_Request CreateBGDQueryRequest(string _dh)
        {
            string _qvName = "HG_GDFS.海关报关单";
            MDModel_QueryModel _qv = MetaDataCache.GetQueryModelDefine(_qvName);
            MC_QueryRequsetFactory _rf = new MC_QueryRequsetFactory();
            _rf.QueryModelName = _qvName;
            //加条件
            MDQuery_ConditionItem _cItem = new MDQuery_ConditionItem();
            _cItem.ColumnIndex = "1";
            _cItem.Column = new MDQuery_TableColumn(_qv.MainTable.GetColumnByName("ENTRY_ID_14"));
            _cItem.Operator = "等于";
            _cItem.Values = new List<string>();
            foreach (string _s in _dh.Split(','))
            {
                _cItem.Values.Add(_s);
            }
            _rf.AddConditonItem(_cItem);
            _rf.AddExpression("1");

            //加结果
            _rf.AddResultTable(_qv.MainTable);
            foreach (MDModel_Table_Column _tc in _qv.MainTable.Columns)
            {
                _rf.AddResultTableColumn(_qv.MainTable, _tc);
            }
            foreach (string _cTName in _qv.ChildTableDict.Keys)
            {
                MDModel_Table _ctable = _qv.ChildTableDict[_cTName];
                _rf.AddResultTable(_ctable);
                foreach (MDModel_Table_Column _ccol in _ctable.Columns)
                {
                    _rf.AddResultTableColumn(_ctable, _ccol);
                }
            }
            return _rf.GetQueryRequest();
        }

        private void bgWorker_BGD_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.queryWaitingPanel1.ShowFinished("查询完成!");
            this.simpleButton1.Text = "查看详细";
            this.simpleButton1.Visible = true;
        }
    }
}