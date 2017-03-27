using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using SinoSZPluginFramework;
using SinoSZJS.Base.MetaData.Define;
using SinoSZJS.Base.MetaData.EnumDefine;
using SinoSZClientBase.MetaDataService;

namespace SinoSZMetaDataManager
{
    public partial class RefTableManager : DevExpress.XtraEditors.XtraUserControl, IControlMenu
    {
        private bool _haveChange = false;
        private bool _initFinished = false;
        private MD_RefTable _refTable = null;
        private DataTable _refTableData = null;
        public RefTableManager()
        {
            InitializeComponent();
        }

        public RefTableManager(MD_RefTable _rtable)
        {
            InitializeComponent();
            _refTable = _rtable;
            RefreshData();
            _initFinished = true;
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


        private void RefreshData()
        {
            this.TE_DisplayName.EditValue = _refTable.Description;
            this.TE_DMBMode.SelectedIndex = (int)_refTable.RefParamMode - 1;
            this.TE_DownLoadMode.SelectedIndex = (int)_refTable.RefDownloadMode - 1;
            this.TE_ID.EditValue = _refTable.RefTableID;
            this.TE_LevelFormat.EditValue = _refTable.LevelFormat;
            this.TE_TableName.EditValue = _refTable.RefTableName;
            this.te_HideCode.EditValue = _refTable.HideCode;
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                _refTableData = _mdc.Get_RefTableColumn(_refTable.RefTableName);
            }
            this.gridControl1.DataSource = _refTableData;
            this._haveChange = false;
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
            }
            return true;
        }

        private void SaveData()
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                CurrencyManager cm_Meta1 = (CurrencyManager)this.BindingContext[_refTableData, ""];
                cm_Meta1.EndCurrentEdit();

                _refTable.Description = this.TE_DisplayName.EditValue.ToString();
                _refTable.RefParamMode = (this.TE_DMBMode.SelectedIndex == 0) ? MDType_RefParamMode.Normal : MDType_RefParamMode.UserParam;
                _refTable.RefDownloadMode = (this.TE_DownLoadMode.SelectedIndex == 0) ? MDType_RefDownloadMode.FullDownload : MDType_RefDownloadMode.LevelDownload;
                _refTable.LevelFormat = this.TE_LevelFormat.EditValue.ToString();
                _refTable.HideCode = (this.te_HideCode.EditValue == null) ? false : ((bool)this.te_HideCode.EditValue);
                _mdc.SaveRefTable(_refTable, _refTableData.GetChanges());
            }
            _refTableData.AcceptChanges();
            this._haveChange = false;
        }

        #endregion

        private void TE_DisplayName_EditValueChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void TE_LevelFormat_EditValueChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void TE_DMBMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void TE_DownLoadMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }


        private void gridView1_CellValueChanged_1(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void te_HideCode_EditValueChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }
    }
}
