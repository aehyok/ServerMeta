using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SinoSZMetaDataQuery.Common;
using SinoSZPluginFramework;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using SinoSZJS.Base;
using SinoSZPluginFramework.ClientPlugin;

using DevExpress.XtraEditors;
using SinoSZJS.Base.Misc;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZClientBase.Cache;
using SinoSZJS.Base.Controller;
using SinoSZClientBase.MetaDataQueryService;

namespace SinoSZMetaDataQuery.DataQuery
{
    public partial class frmSinoSZ_RelationQuery : DevExpress.XtraEditors.XtraForm, IChildForm
    {
        protected IApplication _application = null;
        protected string QueryModelName = "";
        protected MDModel_QueryModel _queryModel = null;
        protected bool _initFinished = false;
        public frmSinoSZ_RelationQuery()
        {
            InitializeComponent();
        }

        public frmSinoSZ_RelationQuery(string _qv, string _param)
        {
            InitializeComponent();
            QueryModelName = _qv;
            string _title = StrUtils.GetMetaByName("标题", _param);

            if (_qv != "")
            {
                _queryModel = MetaDataCache.GetQueryModelDefine(_qv);
                if (_queryModel != null)
                {
                    if (_title != "")
                        this.Text = string.Format("{0}关联查询", _title);
                    else
                        this.Text = string.Format("查询[{0}]", _queryModel.DisplayName);

                    this.sinoSZUC_MD_Model_FieldList1.QueryModel = _queryModel;
                    this.sinoSZUC_MD_Model_FieldList1.ShowFieldsList();
                    this.sinoSZUC_MD_Model_FieldList1.FieldSelected += new EventHandler<FieldSelectEventArgs>(sinoSZUC_MD_Model_FieldList1_FieldSelected);
                    this.sinoSZUC_ConditionPanel1.MenuChanged += new EventHandler<EventArgs>(sinoSZUC_ConditionPanel1_MenuChanged);
                }
                else
                {
                    XtraMessageBox.Show("查询模型未找到!");
                }
                this._initFinished = true;
            }
        }

        protected void sinoSZUC_ConditionPanel1_MenuChanged(object sender, EventArgs e)
        {
            RaiseMenuChanged();
        }

        protected void sinoSZUC_MD_Model_FieldList1_FieldSelected(object sender, FieldSelectEventArgs e)
        {
            this.sinoSZUC_ConditionPanel1.AddCondition(e.FieldItem);
        }

        protected void sinoSZUC_MD_Model_FieldList1_MenuChanged(object sender, EventArgs e)
        {
            RaiseMenuChanged();
        }

        #region IChildForm Members

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


        public IList<FrmMenuPage> GetMenuPages()
        {
            IList<FrmMenuPage> _ret = new List<FrmMenuPage>();
            FrmMenuPage _page = new FrmMenuPage("关联查询");
            _page.MenuGroups = GetMenuGroups(_page.PageTitle);
            _ret.Add(_page);

            return _ret;
        }

        private IList<FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();

            _ret.Add(this.sinoSZUC_MD_Model_FieldList1.GetMenuGroup());

            FrmMenuGroup _conditionMenus = this.sinoSZUC_ConditionPanel1.GetMenuGroup();
            if (_conditionMenus != null) _ret.Add(_conditionMenus);

            FrmMenuGroup _thisGroup = new FrmMenuGroup("查询条件模板");

            _thisGroup.MenuItems = new List<FrmMenuItem>();
            FrmMenuItem _item = new FrmMenuItem("保存条件", "保存条件", global::SinoSZMetaDataQuery.Properties.Resources.b3, true);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("调用条件", "调用条件", global::SinoSZMetaDataQuery.Properties.Resources.b4, true);
            _thisGroup.MenuItems.Add(_item);
            _ret.Add(_thisGroup);

            _thisGroup = new FrmMenuGroup("关联查询");
            _thisGroup.MenuItems = new List<FrmMenuItem>();


            _item = new FrmMenuItem("说明", "说明", global::SinoSZMetaDataQuery.Properties.Resources.u4, true);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("查询", "查询", global::SinoSZMetaDataQuery.Properties.Resources.b10, true);
            _thisGroup.MenuItems.Add(_item);


            _ret.Add(_thisGroup);

            //添加扩展GROUP
            CreateExtMenuGroup(_ret);
            return _ret;
        }

        virtual protected void CreateExtMenuGroup(IList<FrmMenuGroup> _ret)
        {

        }

        virtual protected void DoExtCommand(string _cmdName)
        {

        }

        public bool DoCommand(string _cmdName)
        {
            switch (_cmdName)
            {
                case "查询":
                    QueryData(this._application);
                    break;
                case "保存条件":
                    SaveQueryCondition();
                    break;
                case "调用条件":
                    LoadSaveCondition();
                    break;
                case "说明":
                    Dialog_QueryModelDescript _f = new Dialog_QueryModelDescript(this._queryModel.FullQueryModelName);
                    _f.ShowDialog();
                    break;
                default:
                    DoExtCommand(_cmdName);
                    break;

            }

            this.sinoSZUC_ConditionPanel1.DoCommand(_cmdName);
            this.sinoSZUC_MD_Model_FieldList1.DoCommand(_cmdName);

            return true;
        }



        #endregion


        /// <summary>
        /// 查询数据
        /// </summary>
        virtual protected void QueryData(IApplication _application)
        {
            if (_application == null) return;

            string _errorMsg = "";
            if (!this.sinoSZUC_MD_Model_FieldList1.CheckItems(ref _errorMsg))
            {
                XtraMessageBox.Show(string.Format("选择查询结果不正确:{0}", _errorMsg), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!this.sinoSZUC_ConditionPanel1.CheckInput(ref _errorMsg))
            {
                XtraMessageBox.Show(string.Format("查询条件不正确:{0}", _errorMsg), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MC_QueryRequsetFactory _rf = new MC_QueryRequsetFactory();
            _rf.QueryModelName = this.QueryModelName;
            this.sinoSZUC_ConditionPanel1.InsertConditions2QueryRequest(_rf);
            this.sinoSZUC_MD_Model_FieldList1.InsertResultFields2QueryRequest(_rf);
            MDQuery_Request _queryRequest = _rf.GetQueryRequest();
            if (_queryRequest.MainResultTable.Columns == null || _queryRequest.MainResultTable.Columns.Count < 1)
            {
                XtraMessageBox.Show("主表必须至少选择一个结果字段！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmSinoSZ_QueryResult _qr = new frmSinoSZ_QueryResult(_queryModel, _queryRequest);
            AddExtMenu(_qr);
            _application.AddForm(Guid.NewGuid().ToString(), _qr);
            //XtraMessageBox.Show(string.Format("查询请求包占用存{0}Byte", CalcMemory.CalcInstanceMemory(_rf.GetQueryRequest())));
        }

        virtual protected void AddExtMenu(frmSinoSZ_QueryResult _qr)
        {

        }



        private void SaveQueryCondition()
        {

            string _errorMsg = "";
            if (!this.sinoSZUC_MD_Model_FieldList1.CheckItems(ref _errorMsg))
            {
                XtraMessageBox.Show(string.Format("选择查询结果不正确:{0}", _errorMsg), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!this.sinoSZUC_ConditionPanel1.CheckInput(ref _errorMsg))
            {
                XtraMessageBox.Show(string.Format("查询条件不正确:{0}", _errorMsg), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Dialog_SaveQuery _f = new Dialog_SaveQuery();
            if (_f.ShowDialog() == DialogResult.OK)
            {
                MC_QueryRequsetFactory _rf = new MC_QueryRequsetFactory();
                _rf.QueryModelName = this.QueryModelName;
                this.sinoSZUC_ConditionPanel1.InsertConditions2QueryRequest(_rf);
                this.sinoSZUC_MD_Model_FieldList1.InsertResultFields2QueryRequest(_rf);
                using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                {
                    _msc.SaveQuery(_f.SaveName, _f.IsPublic, _rf.GetQueryRequest());
                }
            }
        }

        private void LoadSaveCondition()
        {
            Dialog_LoadQuery _f = new Dialog_LoadQuery(this.QueryModelName);
            if (_f.ShowDialog() == DialogResult.OK)
            {
                using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                {
                    MDQuery_Request _request = _msc.LoadQuery(_f.SelectedID);

                    this.sinoSZUC_MD_Model_FieldList1.RefreshBySaveRequest(_request);
                    this.sinoSZUC_ConditionPanel1.RefreshBySaveRequest(this._queryModel, _request);
                }

            }
        }



    }
}