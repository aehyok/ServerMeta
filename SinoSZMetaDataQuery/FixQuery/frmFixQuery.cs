using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZClientBase;
using SinoSZJS.Base.Misc;
using SinoSZPluginFramework;

using DevExpress.XtraEditors.Controls;


using SinoSZMetaDataQuery.DataQuery;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZClientBase.Cache;
using SinoSZJS.Base.Controller;

namespace SinoSZMetaDataQuery.FixQuery
{
    public partial class frmFixQuery : frmBase
    {
        protected string Param = "";
        protected FrmMenuItem CurrentMenuItem = null;
        protected string QueryModelName = "";
        protected MDModel_QueryModel _queryModel = null;

        public frmFixQuery()
        {
            InitializeComponent();
        }


        #region 重载基类的方法

        public override void Init(string _title, string _menuName, object _param)
        {
            Param = (string)_param;

            this.Text = StrUtils.GetMetaByName2("标题", Param);
            QueryModelName = StrUtils.GetMetaByName2("查询模型", Param);
            InitForm();
            _initFinished = true;
            RaiseMenuChanged();
        }

        protected override IList<FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            FrmMenuItem _item;
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();
            FrmMenuGroup _thisGroup = new FrmMenuGroup("固定查询");

            _thisGroup.MenuItems = new List<FrmMenuItem>();
            _item = new FrmMenuItem("说明", "说明", global::SinoSZMetaDataQuery.Properties.Resources.u4, true);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("查询", "查询", global::SinoSZMetaDataQuery.Properties.Resources.b10, true);
            _thisGroup.MenuItems.Add(_item);

            _ret.Add(_thisGroup);

            return _ret;
        }

        protected override bool ExcuteCommand(string _cmdName)
        {
            switch (_cmdName)
            {
                case "查询":
                    QueryData();
                    break;
                case "说明":
                    ShowDescript();
                    break;

            }

            return true;
        }




        #endregion

        private void ShowDescript()
        {
            Dialog_QueryModelDescript _f = new Dialog_QueryModelDescript(this._queryModel.FullQueryModelName);
            _f.ShowDialog();

        }

        private void QueryData()
        {
            string _errorMsg = "";
            if (!this.sinoSZUC_FixConditionPanel1.IsValid(ref _errorMsg))
            {
                XtraMessageBox.Show(string.Format("查询条件不正确:{0}", _errorMsg), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MC_QueryRequsetFactory _rf = new MC_QueryRequsetFactory();
            _rf.QueryModelName = this.QueryModelName;
            this.sinoSZUC_FixConditionPanel1.InsertConditions2QueryRequest(_rf);
            InsertQueryResult(_rf);
            MDQuery_Request _queryRequest = _rf.GetQueryRequest();
            frmSinoSZ_QueryResult _qr = new frmSinoSZ_QueryResult(_queryModel, _queryRequest);
            _application.AddForm(Guid.NewGuid().ToString(), _qr);
        }

        private void InsertQueryResult(MC_QueryRequsetFactory _queryRequestFactory)
        {
            _queryRequestFactory.AddResultTable(this._queryModel.MainTable);
            foreach (MDModel_Table_Column _tc in this._queryModel.MainTable.Columns)
            {
                if (_tc.ColumnDefine.DefaultResult)
                {
                    _queryRequestFactory.AddResultTableColumn(this._queryModel.MainTable, _tc);
                }
            }

            foreach (CheckedListBoxItem _item in this.checkedListBoxControl1.CheckedItems)
            {
                FixChildItem _itemData = _item.Value as FixChildItem;
                MDModel_Table _table = _itemData.TableDefine;
                _queryRequestFactory.AddResultTable(_table);
                foreach (MDModel_Table_Column _tc2 in _table.Columns)
                {
                    if (_tc2.ColumnDefine.DefaultResult)
                    {
                        _queryRequestFactory.AddResultTableColumn(_table, _tc2);
                    }
                }
            }

        }

        private void InitForm()
        {
            _queryModel = MetaDataCache.GetQueryModelDefine(this.QueryModelName);
            this.sinoSZUC_FixConditionPanel1.ShowConditionItems(_queryModel);
            this.checkedListBoxControl1.Items.Clear();
            foreach (MDModel_Table _cTable in _queryModel.ChildTableDict.Values)
            {
                bool _canShow = false;
                foreach (MDModel_Table_Column _tc in _cTable.Columns)
                {
                    if (_tc.ColumnDefine.DefaultResult) _canShow = true;
                }
                if (_canShow)
                {
                    FixChildItem _item = new FixChildItem(_cTable.TableDefine.DisplayTitle, _cTable);
                    CheckedListBoxItem _cb = new CheckedListBoxItem();
                    _cb.Value = _item;
                    this.checkedListBoxControl1.Items.Add(_cb);
                }
            }
        }



    }
}