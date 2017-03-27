using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using SinoSZPluginFramework;

using SinoSZClientBase;

using System.Threading;
using SinoSZMetaDataQuery.Common;
using SinoSZClientBase.ShowChart;
using DevExpress.XtraGrid.Views.Base;
using SinoSZClientBase.Export;
using SinoSZMetaDataQuery.PAnalize;
using System.IO;
using System.Reflection;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.Common;
using SinoSZClientBase.Cache;
using SinoSZClientBase.MetaDataQueryService;

namespace SinoSZMetaDataQuery.DataQuery
{
    public partial class frmSinoSZ_QueryResult : DevExpress.XtraEditors.XtraForm, IChildForm
    {

        private IApplication _application = null;

        private MDQuery_Request QueryRequest = null;
        private MDModel_QueryModel QueryModel = null;
        private DataSet QueryResultData = null;
        private bool _initFinished = false;
        private bool CanShowDetailButton = true;
        private bool _queryCanceled = false;
        private Dictionary<string, SinoSZ_TableRelationCompose> _relationDataDict = new Dictionary<string, SinoSZ_TableRelationCompose>();
        private string _queryType = "QueryModel";
        private MDQuery_Task _queryTask = null;
        private List<FrmMenuGroup> ExtendMenuGroups = new List<FrmMenuGroup>();
        private static string disUsePanalize = "";
        public static bool DisableUsePAnalize
        {
            get
            {
                if (disUsePanalize == "")
                {
                    //disUsePanalize = SinoSZQueryConfig.MetaDataFactroy.GetCanUsePanalizeSet();
                }
                return (disUsePanalize == "1");

            }
        }

        #region 属性
        private object _currentGrid = null;
        /// <summary>
        /// 当前显示的Grid对象
        /// </summary>
        public object CurrentGrid
        {
            get { return _currentGrid; }
        }
        #endregion

        #region 构造方法
        public frmSinoSZ_QueryResult()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造查询结果窗体
        /// </summary>
        /// <param name="_qv">查询模型</param>
        /// <param name="_request">查询请求</param>
        public frmSinoSZ_QueryResult(MDModel_QueryModel _qv, MDQuery_Request _request)
        {
            InitializeComponent();
            QueryRequest = _request;
            QueryModel = _qv;

            this.Text = string.Format("查询[{0}]结果", _qv.DisplayName);
        }

        public frmSinoSZ_QueryResult(MDModel_QueryModel _qv, MDQuery_Request _request, bool _showDetailButton)
        {
            InitializeComponent();
            QueryRequest = _request;
            QueryModel = _qv;
            CanShowDetailButton = _showDetailButton;
            this.Text = string.Format("查询[{0}]结果", _qv.DisplayName);
        }

        /// <summary>
        /// 构造查询结果窗体
        /// </summary>
        /// <param name="_qv">查询模型</param>
        /// <param name="_request">查询请求</param>
        public frmSinoSZ_QueryResult(MDModel_QueryModel _qv, MDQuery_Request _request, string _type)
        {
            InitializeComponent();
            QueryRequest = _request;
            QueryModel = _qv;
            _queryType = _type;
            this.Text = string.Format("查询[{0}]结果", _qv.DisplayName);
        }

        public frmSinoSZ_QueryResult(MDQuery_Task _task)
        {
            InitializeComponent();
            string _title = _task.TaskName.Split('\n')[0];
            this.Text = string.Format("查询任务[{0}]的结果",
                    _title.Length > 10 ? _title.Substring(0, 10) + "..." : _title);
            _queryType = "TaskResult";
            _queryTask = _task;
        }
        #endregion

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
            FrmMenuPage _page = new FrmMenuPage("查询结果");
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

            if (this.backgroundWorker1.IsBusy && !this.backgroundWorker1.CancellationPending)
            {
                FrmMenuGroup _thisGroup = new FrmMenuGroup("查询处理");

                _thisGroup.MenuItems = new List<FrmMenuItem>();
                FrmMenuItem _item = new FrmMenuItem("取消", "取消", global::SinoSZMetaDataQuery.Properties.Resources.x1, true);
                _thisGroup.MenuItems.Add(_item);
                _ret.Add(_thisGroup);
            }
            else
            {

                FrmMenuGroup _thisGroup = new FrmMenuGroup("数据分析");
                _thisGroup.MenuItems = new List<FrmMenuItem>();
                FrmMenuItem _item;

                if (QueryResultData != null)
                {

                    _item = new FrmMenuItem("展示方式", "展示方式", global::SinoSZMetaDataQuery.Properties.Resources.b11, true);
                    _thisGroup.MenuItems.Add(_item);

                    FrmMenuItem _citem = new FrmMenuItem("常规展示", "常规展示", global::SinoSZMetaDataQuery.Properties.Resources.b12, true);
                    _item.ChildMenus.Add(_citem);
                    foreach (DataTable _dt in QueryResultData.Tables)
                    {
                        if (_dt.TableName != this.QueryModel.MainTable.TableName)
                        {
                            MDModel_Table _mt = MC_QueryModel.GetTableDefine(this.QueryModel, _dt.TableName);
                            _citem = new FrmMenuItem(string.Format("关联展示[{0}]", _mt.TableDefine.DisplayTitle),
                                    string.Format("关联展示,{0}", _dt.TableName),
                                    global::SinoSZMetaDataQuery.Properties.Resources.b13, true);
                            _item.ChildMenus.Add(_citem);

                        }
                    }

                    _citem = new FrmMenuItem("关联展示[全部]", "全部平铺展示", global::SinoSZMetaDataQuery.Properties.Resources.b14, true);
                    _item.ChildMenus.Add(_citem);
                }
                bool _canGroupSort = false;
                bool _canShowAsChart = true;
                bool _canShowDetail = true;
                string _GSbuttonCaption = "分组排序";
                if (CurrentGrid is SinoSZUC_GridControlEx)
                {
                    SinoSZUC_GridControlEx _grid = (SinoSZUC_GridControlEx)CurrentGrid;
                    if (_grid.ShowAsGroupSorting)
                    {
                        _GSbuttonCaption = "取消分组";
                        _canShowDetail = false;
                        _canGroupSort = true;
                    }
                    else
                    {
                        if (_grid.Grouped)
                        {
                            _canGroupSort = true;
                        }
                    }

                }
                else
                {
                    _canShowAsChart = false;
                }

                if (_GSbuttonCaption == "分组排序")
                {
                    _item = new FrmMenuItem(_GSbuttonCaption, "分组排序", global::SinoSZMetaDataQuery.Properties.Resources.b15, _canGroupSort);
                    _thisGroup.MenuItems.Add(_item);
                }
                else
                {
                    _item = new FrmMenuItem(_GSbuttonCaption, "分组排序", global::SinoSZMetaDataQuery.Properties.Resources.b16, _canGroupSort);
                    _thisGroup.MenuItems.Add(_item);
                }


                //_item = new FrmMenuItem("数据透视", "数据透视", global::SinoSZMetaDataQuery.Properties.Resources.b17, _canShowAsChart);
                //_thisGroup.MenuItems.Add(_item);


                _item = new FrmMenuItem("图表展示", "图表展示", global::SinoSZMetaDataQuery.Properties.Resources.b18, _canShowAsChart);
                _thisGroup.MenuItems.Add(_item);

                //_item = new FrmMenuItem("数据筛选", "数据筛选", global::SinoSZMetaDataQuery.Properties.Resources.DataFilter2, true);
                //_thisGroup.MenuItems.Add(_item);

                _ret.Add(_thisGroup);


                _thisGroup = new FrmMenuGroup("数据处理");
                _thisGroup.MenuItems = new List<FrmMenuItem>();
                if (!frmSinoSZ_QueryResult.DisableUsePAnalize)
                {
                    _item = new FrmMenuItem("数据转存", "数据转存", global::SinoSZMetaDataQuery.Properties.Resources.b26, true);
                    _thisGroup.MenuItems.Add(_item);
                }

                _item = new FrmMenuItem("导出", "导出", global::SinoSZMetaDataQuery.Properties.Resources.x3, true);
                _thisGroup.MenuItems.Add(_item);

                //_item = new FrmMenuItem("添加字段", "添加字段", global::SinoSZMetaDataQuery.Properties.Resources.b27, _canShowAsChart);
                //_thisGroup.MenuItems.Add(_item);


                _item = new FrmMenuItem("详细信息", "详细信息", global::SinoSZMetaDataQuery.Properties.Resources.x2, _canShowDetail && CanShowDetailButton);
                _thisGroup.MenuItems.Add(_item);


                _ret.Add(_thisGroup);

                foreach (FrmMenuGroup _extg in this.ExtendMenuGroups)
                {
                    _ret.Add(_extg);
                }

            }
            return _ret;
        }


        /// <summary>
        /// 执行菜单命令
        /// </summary>
        /// <param name="_cmdName"></param>
        /// <returns></returns>
        public bool DoCommand(string _cmdName)
        {
            string[] _cmdstrs = _cmdName.Split(',');
            string _cmdType = _cmdstrs[0];
            switch (_cmdType)
            {
                case "取消":
                    if (this.backgroundWorker1.IsBusy)
                    {
                        this.backgroundWorker1.CancelAsync();
                        RaiseMenuChanged();
                        this.panelProgress.Visible = false;
                        this.panelData.Visible = true;
                        this.timer1.Enabled = true;
                        _queryCanceled = true;
                    }
                    break;
                case "常规展示":
                    ShowAsNormal();
                    break;
                case "关联展示":
                    if (_cmdstrs.Length > 1) ShowAsRelation(_cmdstrs[1]);
                    break;
                case "全部平铺展示":
                    ShowFull();
                    break;
                case "分组排序":
                    ShowAsGroupSort();
                    break;
                case "图表展示":
                    ShowAsChart();
                    break;
                case "详细信息":
                    ShowDetail();
                    break;
                case "导出":
                    ExportData();
                    break;
                case "数据转存":
                    SaveToPanalize();
                    break;
                default:
                    foreach (FrmMenuGroup _extg in this.ExtendMenuGroups)
                    {
                        foreach (FrmMenuItem _item in _extg.MenuItems)
                        {
                            if (_item.MenuCommand != null)
                            {
                                if (_item.MenuCommand.CommandName == _cmdType)
                                {
                                    IMenuCommand _ic = _item.MenuCommand.Commander;
                                    _ic.DoCommand("", _cmdType, "", _item.MenuCommand.CommandParam);
                                }
                            }
                        }
                    }
                    break;
            }
            return true;
        }






        #endregion

        /// <summary>
        /// 以图表方式展示
        /// </summary>
        private void ShowAsChart()
        {
            if (_currentGrid is SinoSZUC_GridControlEx)
            {
                SinoSZUC_GridControlEx _gridEx = _currentGrid as SinoSZUC_GridControlEx;
                DataTable _dt = _gridEx.CurrentData();
                Dictionary<string, string> _fieldsDict = _gridEx.CurrentFieldsDict();
                frmChartShow _f = new frmChartShow(_dt, _fieldsDict);
                _application.AddForm(Guid.NewGuid().ToString(), _f);
            }
        }

        /// <summary>
        /// 关联展示
        /// </summary>
        /// <param name="p"></param>
        private void ShowAsRelation(string _relationTableName)
        {
            this.sinoSZUC_GridControlEx1.Visible = false;
            this.sinoSZUC_GridControlEx2.Visible = true;
            this.sinoSZUC_GridControlEx3.Visible = false;
            if (!_relationDataDict.ContainsKey(_relationTableName))
            {
                SinoSZ_TableRelationCompose _ret = SinoSZ_TableRelationCompose.Compse(this.QueryRequest, this.QueryModel,
                        QueryResultData.Tables[_relationTableName]);
                _relationDataDict.Add(_relationTableName, _ret);
            }

            SinoSZ_TableRelationCompose _trc = _relationDataDict[_relationTableName];
            this.sinoSZUC_GridControlEx2.ClearColumns();
            this.sinoSZUC_GridControlEx2.ShowQueryResult(_trc.QueryRequest, _trc.QueryModel);
            this.sinoSZUC_GridControlEx2.DataSource = _trc.ResultData;
            _currentGrid = this.sinoSZUC_GridControlEx2;
            RaiseMenuChanged();
        }

        /// <summary>
        /// 全部平铺展示
        /// </summary>
        private void ShowFull()
        {
            if (this.sinoSZUC_GridControlEx3.DataSource == null)
            {
                this.sinoSZUC_GridControlEx3.ShowQueryResult(this.QueryRequest, this.QueryModel, QueryResultData);
                DataTable _fullComboData = MC_QueryModel.CreateFullComboData(this.QueryRequest, this.QueryModel, QueryResultData);
                this.sinoSZUC_GridControlEx3.DataSource = _fullComboData;
            }
            this.sinoSZUC_GridControlEx1.Visible = false;
            this.sinoSZUC_GridControlEx2.Visible = false;
            this.sinoSZUC_GridControlEx3.Visible = true;
            _currentGrid = this.sinoSZUC_GridControlEx3;
            RaiseMenuChanged();
        }


        /// <summary>
        /// 常规展示
        /// </summary>
        private void ShowAsNormal()
        {
            this.sinoSZUC_GridControlEx1.Visible = true;
            this.sinoSZUC_GridControlEx2.Visible = false;
            this.sinoSZUC_GridControlEx3.Visible = false;
            _currentGrid = this.sinoSZUC_GridControlEx1;
            RaiseMenuChanged();
        }

        /// <summary>
        /// 导出
        /// </summary>
        private void ExportData()
        {
            BaseView _bv = null;
            if (_currentGrid is SinoSZUC_GridControlEx)
            {
                SinoSZUC_GridControlEx _gridEx = _currentGrid as SinoSZUC_GridControlEx;
                _bv = _gridEx.CurrentView;
            }
            if (_currentGrid is SinoSZUC_GridControlEx_FullRelation)
            {
                SinoSZUC_GridControlEx_FullRelation _gridFullEX = _currentGrid as SinoSZUC_GridControlEx_FullRelation;
                _bv = _gridFullEX.CurrentView;
            }

            if (_bv != null)
            {
                SinoSZExport_GridViewData.Export(_bv);
            }
        }

        /// <summary>
        /// 界面启动加载处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSinoSZ_QueryResult_Load(object sender, EventArgs e)
        {
            _initFinished = true;
            switch (this._queryType)
            {
                case "PAQueryModel":
                case "QueryModel":
                    this.backgroundWorker1.RunWorkerAsync();
                    break;

                case "TaskResult":
                    if (this._queryTask.TaskState == 3)
                    {
                        this.backgroundWorker1.RunWorkerAsync();
                    }
                    break;
            }
        }

        /// <summary>
        /// 处理用户对数据分组操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sinoSZUC_GridControlEx1_ColumnGrouped(object sender, EventArgs e)
        {
            RaiseMenuChanged();
        }

        /// <summary>
        /// 处理用户对数据的分组结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sinoSZUC_GridControlEx1_GroupColumnCleared(object sender, EventArgs e)
        {
            RaiseMenuChanged();
        }

        /// <summary>
        /// 启动查询线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            BackgroundWorker bgwValue = (BackgroundWorker)sender;
            switch (_queryType)
            {
                case "QueryModel":
                    QueryByModel();
                    break;
                case "PAQueryModel":
                    PAQueryByModel();
                    break;
                case "TaskResult":
                    try
                    {
                        QueryTaskID();
                    }
                    catch (Exception exp)
                    {
                        string _msg = string.Format("{1} 在取任务查询结果数据时出现错误:{0}", exp.Message, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        string _fullPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\ClientErrorLog.log";
                        StreamWriter _fs;
                        if (File.Exists(_fullPath))
                        {
                            _fs = File.AppendText(_fullPath);
                        }
                        else
                        {
                            _fs = File.CreateText(_fullPath);
                        }
                        _fs.WriteLine(_msg);
                        _fs.Close();
                        throw exp;
                    }
                    break;
            }

        }



        private void QueryTaskID()
        {
            if (this._queryTask != null)
            {
                using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                {
                    QueryRequest = _msc.GetQueryTaskRequestContext(this._queryTask.TaskID);
                    QueryModel = MetaDataCache.GetQueryModelDefine(QueryRequest.QueryModelName);
                    switch (this._queryTask.TaskType)
                    {
                        case "HGSQL":
                            QueryResultData = _msc.GetTaskQueryResult_DataSet(this._queryTask.TaskID);
                            MC_QueryModel.CreateDataRelation(this.QueryModel, QueryResultData);
                            break;
                        case "LOCALORA":
                            QueryResultData = _msc.GetTaskQueryResult_ORA(this._queryTask.TaskID);
                            MC_QueryModel.CreateDataRelation(this.QueryModel, QueryResultData);
                            break;
                    }
                }
            }

        }

        private void QueryByModel()
        {
            if (this.QueryRequest != null)
            {
                using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                {
                    QueryResultData = _msc.QueryData(this.QueryRequest);
                }
                //多表关联处理    
                MC_QueryModel.CreateDataRelation(this.QueryModel, QueryResultData);
            }
        }

        private void PAQueryByModel()
        {
            //if (this.QueryRequest != null)
            //{
            //        QueryResultData = SinoSZQueryConfig.MetaDataFactroy.PAQueryData(this.QueryRequest, this.QueryModel);
            //        //多表关联处理    
            //        MC_QueryModel.CreateDataRelation(this.QueryModel, QueryResultData);
            //}
        }

        /// <summary>
        /// 异步查询完毕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //显示
            if (!_queryCanceled)
            {
                if (QueryRequest != null)
                {
                    this.sinoSZUC_GridControlEx1.ShowQueryResult(QueryRequest, QueryModel);
                }

                if (QueryResultData != null)
                {
                    this.sinoSZUC_GridControlEx1.DataSource = QueryResultData.Tables[this.QueryRequest.MainResultTable.TableName];
                    _currentGrid = this.sinoSZUC_GridControlEx1;
                }

                this.panelProgress.Visible = false;
                this.panelData.Visible = true;
                this.timer1.Enabled = true;
                _queryCanceled = false;
            }
        }

        /// <summary>
        /// 转存到个人分析空间
        /// </summary>
        private void SaveToPanalize()
        {


            BaseView _bv = null;
            if (_currentGrid is SinoSZUC_GridControlEx)
            {
                SinoSZUC_GridControlEx _gridEx = _currentGrid as SinoSZUC_GridControlEx;
                _bv = _gridEx.CurrentView;
            }
            if (_currentGrid is SinoSZUC_GridControlEx_FullRelation)
            {
                SinoSZUC_GridControlEx_FullRelation _gridFullEX = _currentGrid as SinoSZUC_GridControlEx_FullRelation;
                _bv = _gridFullEX.CurrentView;
            }

            if (_bv != null)
            {
                PAnalize_GridViewData.SaveToPAnalize(_bv);
            }


        }


        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        /// <summary>
        /// 延时刷新菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!this.backgroundWorker1.IsBusy || this.backgroundWorker1.CancellationPending)
            {
                this.timer1.Enabled = false;
                RaiseMenuChanged();
            }
        }

        /// <summary>
        /// 以分组排序方式显示
        /// </summary>
        private void ShowAsGroupSort()
        {
            if (CurrentGrid is SinoSZUC_GridControlEx)
            {
                SinoSZUC_GridControlEx _grid = (SinoSZUC_GridControlEx)CurrentGrid;
                _grid.ShowAsGroupSorting = !_grid.ShowAsGroupSorting;
                RaiseMenuChanged();
            }
        }

        /// <summary>
        /// 显示详细信息
        /// </summary>
        private void ShowDetail()
        {
            switch (this._queryType)
            {
                case "QueryModel":
                    if (_currentGrid is SinoSZUC_GridControlEx)
                    {
                        SinoSZUC_GridControlEx _gridEx = _currentGrid as SinoSZUC_GridControlEx;
                        DataRow _dr = _gridEx.FocusedDataRow;
                        if (_dr != null)
                        {
                            string _mainKeyID = _dr["MAINID"].ToString();
                            frmSinoSZ_DataDetail _form = new frmSinoSZ_DataDetail(this.QueryModel, _mainKeyID);
                            _application.AddForm(Guid.NewGuid().ToString(), _form);
                        }
                    }
                    break;
                case "TaskResult":
                    XtraMessageBox.Show("任务式查询的数据结果无法查看详细数据!");
                    break;
            }

        }

        public string GetFocusedMainKey()
        {
            try
            {
                if (_currentGrid is SinoSZUC_GridControlEx)
                {
                    SinoSZUC_GridControlEx _gridEx = _currentGrid as SinoSZUC_GridControlEx;
                    DataRow _dr = _gridEx.FocusedDataRow;
                    if (_dr != null)
                    {
                        string _mainKeyID = _dr["MAINID"].ToString();
                        return _mainKeyID;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "";
        }

        public void AddExtMenuGroup(FrmMenuGroup _extGroup)
        {
            ExtendMenuGroups.Add(_extGroup);
        }
    }
}