using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using DevExpress.XtraTreeList.Nodes;
using SinoSZPluginFramework;
using System.Linq;
using SinoSZMetaDataQuery.DataQuery;
using SinoSZJS.Base.MetaData.Define;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZClientBase.MetaDataQueryService;

namespace SinoSZMetaDataQuery.DataSearch
{
    public partial class frmDataSearch : DevExpress.XtraEditors.XtraForm, IChildForm
    {
        private IApplication _application = null;
        private bool _initFinished = false;
        private string QueryModels = "";
        private string _searchText = "";
        private string _searchConceptGroup = "";
        private int _searchType = 0;
        private List<MD_QueryModel> _selectModels = null;
        private List<MDSearch_ResultDataIndex> _searchResult = null;
        private List<MD_QueryModel> QueryModelList = new List<MD_QueryModel>();
        private bool _queryCanceled = false;
        public frmDataSearch()
        {
            InitializeComponent();
        }

        public frmDataSearch(string _queryModelNames)
        {
            InitializeComponent();
            QueryModels = _queryModelNames;
            this.sinoSZUC_SearchInput1.InitInput();
            InitModels();
        }

        private void InitModels()
        {
            using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
            {
                QueryModelList = _msc.GetQueryModels(QueryModels).ToList<MD_QueryModel>();
            }
            foreach (MD_QueryModel _qm in QueryModelList)
            {
                TreeListNode _node = this.treeList1.AppendNode(null, null);
                _node.Tag = _qm;
                _node.SetValue("COLUMN1", _qm);
                _node.SetValue("State", 1);
            }
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
            FrmMenuPage _page = new FrmMenuPage("信息检索");
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
            FrmMenuGroup _thisGroup = new FrmMenuGroup("信息检索功能");

            _thisGroup.MenuItems = new List<FrmMenuItem>();

            bool _searching = false;
            if (this.backgroundWorker1.IsBusy && !this.backgroundWorker1.CancellationPending)
            {
                _searching = true;
            }

            FrmMenuItem _item = new FrmMenuItem("信息检索", "信息检索", global::SinoSZMetaDataQuery.Properties.Resources.b1, !_searching && !_queryCanceled);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("取消", "取消", global::SinoSZMetaDataQuery.Properties.Resources.x1, _searching);
            _thisGroup.MenuItems.Add(_item);


            _ret.Add(_thisGroup);

            _thisGroup = new FrmMenuGroup("检索结果处理");
            _thisGroup.MenuItems = new List<FrmMenuItem>();

            bool _haveCurrentResultRow = (this.gridView1.FocusedRowHandle >= 0);
            _item = new FrmMenuItem("详细信息", "详细信息", global::SinoSZMetaDataQuery.Properties.Resources.x2, _haveCurrentResultRow);
            _thisGroup.MenuItems.Add(_item);

            bool _haveResultData = (this.gridView1.RowCount > 0) && !_searching;
            _item = new FrmMenuItem("导出", "导出", global::SinoSZMetaDataQuery.Properties.Resources.x3, _haveResultData);

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
                case "信息检索":
                    CMD_DataSearch();
                    break;
                case "取消":
                    CMD_CancelSearch();
                    break;
                case "详细信息":
                    CMD_ShowDetail();
                    break;
                case "导出":
                    break;
            }

            return true;
        }

        private void CMD_ShowDetail()
        {
            int _index = this.gridView1.FocusedRowHandle;
            if (_index >= 0)
            {
                MDSearch_ResultDataIndex _rd = this.gridView1.GetRow(_index) as MDSearch_ResultDataIndex;
                frmSinoSZ_DataDetail _f = new frmSinoSZ_DataDetail(_rd);
                this._application.AddForm(Guid.NewGuid().ToString(), _f);

            }
        }

        private void CMD_CancelSearch()
        {
            if (this.backgroundWorker1.IsBusy)
            {
                this.backgroundWorker1.CancelAsync();
                this.labelState.Text = "正在取消搜索,请稍候 ....";
                _queryCanceled = true;
                RaiseMenuChanged();
            }

        }

        /// <summary>
        /// 信息检索
        /// </summary>
        private void CMD_DataSearch()
        {
            _searchText = this.sinoSZUC_SearchInput1.SearchText;
            _searchType = this.sinoSZUC_SearchInput1.SearchType;
            _searchConceptGroup = this.sinoSZUC_SearchInput1.SearchConceptGroup;
            if (_searchText == null || _searchText == "")
            {
                XtraMessageBox.Show("请输入需要检索的内容!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_searchType < 0)
            {
                XtraMessageBox.Show("检索的类型不正确!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _selectModels = GetSelectQueryModel();
            if (_selectModels.Count < 1)
            {
                XtraMessageBox.Show("请选择检索的数据源范围!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _searchResult = new List<MDSearch_ResultDataIndex>();
            this.sinoCommonGrid1.DataSource = _searchResult;
            _queryCanceled = false;
            this.backgroundWorker1.RunWorkerAsync();
            RaiseMenuChanged();
        }

        /// <summary>
        /// 取选择的查询模型
        /// </summary>
        /// <returns></returns>
        private List<MD_QueryModel> GetSelectQueryModel()
        {
            List<MD_QueryModel> _ret = new List<MD_QueryModel>();
            foreach (TreeListNode _node in this.treeList1.Nodes)
            {
                object _stobj = _node.GetValue("State");
                if (_stobj != null)
                {
                    int _st = (int)_stobj;
                    if (_st == 1)
                    {
                        MD_QueryModel _qm = _node.GetValue("COLUMN1") as MD_QueryModel;
                        _ret.Add(_qm);
                    }
                }
            }
            return _ret;
        }


        #endregion

        private void frmDataSearch_Load(object sender, EventArgs e)
        {

            this._initFinished = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            SearhProgressState _stateobj;
            _searchResult = new List<MDSearch_ResultDataIndex>();
            List<MDSearch_Column> _searchColumns = new List<MDSearch_Column>();
            using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
            {
                foreach (MD_QueryModel _qm in _selectModels)
                {

                    List<MDSearch_Column> _columns = _msc.GetSearchResultColumn(_searchText, _searchType, _searchConceptGroup,
                        _qm.FullName).ToList<MDSearch_Column>();
                    foreach (MDSearch_Column _sc in _columns)
                    {
                        _sc.QueryModel = _qm;
                        _searchColumns.Add(_sc);
                    }
                }
            }
            decimal i = 0;
            decimal _count = Convert.ToDecimal(_searchColumns.Count);
            List<MDSearch_ResultDataIndex> _resultData = null;
            using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
            {
                foreach (MDSearch_Column _sc in _searchColumns)
                {
                    string _str = string.Format("正在搜索:[{0}]数据源中的{1} ....", _sc.QueryModel.DisplayTitle, string.Format("[{0}].[{1}]", _sc.TableTitle, _sc.ColumnTitle));
                    decimal _progress = i / _count * 100;
                    _stateobj = new SearhProgressState(_str, null);
                    this.backgroundWorker1.ReportProgress(Convert.ToInt32(_progress), _stateobj);
                    _resultData = _msc.GetSearchResult(_searchText, _searchType, _sc).ToList<MDSearch_ResultDataIndex>();
                    _stateobj = new SearhProgressState(_str, _resultData);
                    this.backgroundWorker1.ReportProgress(Convert.ToInt32(_progress), _stateobj);
                    i++;
                }
            }



        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!_queryCanceled)
            {
                this.labelState.Text = string.Format(" 共检索到{0}条匹配的记录!", _searchResult.Count);
                this.progressBarControl1.Position = 100;
                this.sinoCommonGrid1.BeginUpdate();
                this.sinoCommonGrid1.DataSource = _searchResult;
                this.sinoCommonGrid1.EndUpdate();
            }
            else
            {
                this.labelState.Text = string.Format(" 搜索被用户取消!　共检索到{0}条匹配的记录!", _searchResult.Count);
                this.sinoCommonGrid1.BeginUpdate();
                this.sinoCommonGrid1.DataSource = _searchResult;
                this.sinoCommonGrid1.EndUpdate();
            }
            _queryCanceled = false;
            RaiseMenuChanged();

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            SearhProgressState _obj = e.UserState as SearhProgressState;
            if (!_queryCanceled)
            {
                this.labelState.Text = _obj.Message;
            }
            else
            {
                this.labelState.Text = "正在取消搜索,请稍候 ....";
            }
            if (_obj.ResultData != null)
            {
                this.sinoCommonGrid1.BeginUpdate();
                foreach (MDSearch_ResultDataIndex _rd in _obj.ResultData)
                {
                    _searchResult.Add(_rd);
                }
                this.sinoCommonGrid1.DataSource = _searchResult;
                this.sinoCommonGrid1.EndUpdate();
            }

            this.progressBarControl1.Position = e.ProgressPercentage;

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            RaiseMenuChanged();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            CMD_ShowDetail();
        }

    }
}