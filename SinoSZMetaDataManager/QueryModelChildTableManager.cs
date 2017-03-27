using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZPluginFramework;

using System.Collections;
using SinoSZJS.Base.MetaData.Define;
using SinoSZJS.Base.MetaData.EnumDefine;
using SinoSZClientBase.MetaDataService;

namespace SinoSZMetaDataManager
{
    public partial class QueryModelChildTableManager : DevExpress.XtraEditors.XtraUserControl, IControlMenu
    {
        private bool _haveChange = false;
        private bool _initFinished = false;
        private MD_ViewTable _viewtable = null;

        public QueryModelChildTableManager()
        {
            InitializeComponent();
        }

        public QueryModelChildTableManager(MD_ViewTable _vt)
        {
            InitializeComponent();
            _viewtable = _vt;
            RefreshData();
            _initFinished = true;
        }


        #region IControlMenu Members

        public List<FrmMenuGroup> GetControlMenu()
        {
            FrmMenuGroup _thisGroup = new FrmMenuGroup("修改保存");
            _thisGroup.MenuItems = new List<FrmMenuItem>();
            FrmMenuItem _item = new FrmMenuItem("保存", "保存", global::SinoSZMetaDataManager.Properties.Resources.xx, _haveChange);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("取消", "取消", global::SinoSZMetaDataManager.Properties.Resources.x1, _haveChange);
            _thisGroup.MenuItems.Add(_item);
            List<FrmMenuGroup> _ret = new List<FrmMenuGroup>();
            _ret.Add(_thisGroup);
            return _ret;
        }

        public bool HaveDataChanged()
        {
            return _haveChange && _initFinished;
        }

        public void RaiseDataChanged()
        {

            if (HaveDataChanged() && DataChanged != null)
            {
                DataChanged(this, new EventArgs());
            }

        }

        private void RaiseMenuChanged()
        {
            if (MenuChanged != null)
            {
                MenuChanged(this, new EventArgs());
            }
        }


        public event EventHandler<EventArgs> DataChanged;

        public event EventHandler<EventArgs> MenuChanged;

        public bool CloseControl()
        {
            if (HaveDataChanged())
            {
                DialogResult _res = XtraMessageBox.Show("是否保存数据修改?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_res == DialogResult.Yes)
                {
                    SaveData();
                }
                else
                {
                    RefreshData();
                }
            }
            return true;
        }

        public bool DoCommand(string _cmdName)
        {
            switch (_cmdName)
            {
                case "保存":
                    SaveData();
                    break;
                case "取消":
                    RefreshData();
                    break;
                case "字段同步":
                    return CMD_ViewTableColumnSync(_viewtable);
            }
            return true;
        }
        /// <summary>
        /// 同步模型中的表字段
        /// </summary>
        /// <param name="_vt"></param>
        /// <returns></returns>
        private bool CMD_ViewTableColumnSync(MD_ViewTable _vt)
        {
            IList<MD_ViewTableColumn> _vtc = _vt.Columns;
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                IList<MD_TableColumn> _tcolumns = _mdc.GetColumnsOfTable(_vt.TableID);

                IList<MD_ViewTableColumn> _newvtColumns = new List<MD_ViewTableColumn>();
                IDictionary<string, MD_ViewTableColumn> _vtcDict = new Dictionary<string, MD_ViewTableColumn>();
                foreach (MD_ViewTableColumn _vtColumn in _vtc)
                {
                    _vtcDict.Add(_vtColumn.TableColumn.ColumnName, _vtColumn);
                }


                IDictionary<string, MD_TableColumn> _tcDict = new Dictionary<string, MD_TableColumn>();
                foreach (MD_TableColumn _tbcol in _tcolumns)
                {
                    _tcDict.Add(_tbcol.ColumnName, _tbcol);
                }

                ArrayList _delkeys = new ArrayList();
                foreach (string _key in _vtcDict.Keys)
                {
                    if (_tcDict.ContainsKey(_key))
                    {
                        _newvtColumns.Add(_vtcDict[_key]);
                    }
                }

                foreach (string _key in _tcDict.Keys)
                {
                    if (!_vtcDict.ContainsKey(_key))
                    {
                        MD_TableColumn _thistc = _tcDict[_key];
                        MD_ViewTableColumn _newvtc = new MD_ViewTableColumn(
                            _mdc.GetNewID(),
                             _vt.ViewTableID,
                                _thistc.ColumnID,
                                true,
                                true,
                                true,
                                false,
                                false,
                                _thistc.DWDM,
                                0,
                                0);

                        _newvtColumns.Add(_newvtc);
                    }
                }
                _vt.Columns = _newvtColumns;
                this.gridControl1.DataSource = _vt.Columns;
                this._haveChange = true;
                RaiseDataChanged();
                return true;
            }
        }



        private void RefreshData()
        {
            if (_viewtable == null) return;
            this.TE_ID.EditValue = _viewtable.ViewTableID;
            this.TE_DISPLAY.EditValue = _viewtable.DisplayTitle;
            this.TE_NAMESPACE.EditValue = _viewtable.NamespaceName;
            this.TE_ORDER.EditValue = _viewtable.DisplayOrder;
            this.TE_RELATION.EditValue = _viewtable.RelationString;
            this.TE_TABLENAME.EditValue = _viewtable.TableName;
            this.TE_TYPE.SelectedIndex = (_viewtable.ViewTableRelationType == MDType_ViewTableRelation.SingleChildRecord) ? 0 : 1;
            this.gridControl1.DataSource = _viewtable.Columns;
            this.TE_DISPLAYTYPE.SelectedIndex = (_viewtable.DisplayType == MDType_DisplayType.GridType) ? 0 : 1;
            this.te_IntegradApp.EditValue = _viewtable.IntegratedApp;
            this._haveChange = false;
        }

        private void SaveData()
        {
            this.gridView1.PostEditor();
            _viewtable.DisplayTitle = this.TE_DISPLAY.EditValue.ToString();
            _viewtable.DisplayOrder = int.Parse(this.TE_ORDER.EditValue.ToString());
            _viewtable.RelationString = this.TE_RELATION.EditValue.ToString();
            _viewtable.ViewTableRelationType = (this.TE_TYPE.SelectedIndex == 0) ? MDType_ViewTableRelation.SingleChildRecord : MDType_ViewTableRelation.MultiChildRecord;
            _viewtable.DisplayType = (this.TE_DISPLAYTYPE.SelectedIndex == 0) ? MDType_DisplayType.GridType : MDType_DisplayType.FormType;
            _viewtable.IntegratedApp = this.te_IntegradApp.EditValue.ToString();
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                _mdc.SaveViewChildTable(_viewtable);
                this._haveChange = false;
                RaiseDataChanged();
            }
        }
        #endregion

        private void sinoSZTextEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void sinoSZTextEdit6_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void sinoSZTextEdit5_EditValueChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void TE_DISPLAY_EditValueChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void TE_TYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void TE_RELATION_EditValueChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void TE_DISPLAYTYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void te_IntegradApp_EditValueChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }
    }
}
