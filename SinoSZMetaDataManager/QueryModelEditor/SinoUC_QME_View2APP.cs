using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.MetaData.Define;
using SinoSZPluginFramework;
using SinoSZClientBase.MetaDataService;

namespace SinoSZMetaDataManager.QueryModelEditor
{
    public partial class SinoUC_QME_View2APP : DevExpress.XtraEditors.XtraUserControl, IControlMenu
    {
        private MD_View2App CurrentData;
        private bool _haveChange = false;
        private bool _initFinished = false;
        public SinoUC_QME_View2APP()
        {
            InitializeComponent();
        }
        public SinoUC_QME_View2APP(MD_View2App _data)
        {
            InitializeComponent();
            InitData(_data);
        }

        public void InitData(MD_View2App _data)
        {
            CurrentData = _data;
            this.TE_DISPLAY.EditValue = _data.Title;
            this.te_AppName.EditValue = _data.AppName;
            this.te_DisplayHeight.EditValue = _data.DisplayHeight;
            this.te_DisplayOrder.EditValue = _data.DisplayOrder;
            this.te_Meta.EditValue = _data.Meta;
            this.te_URL.EditValue = _data.RegURL;
            _initFinished = true;

        }

        public MD_View2App GetData()
        {
            CurrentData.Title = (this.TE_DISPLAY.EditValue == null) ? "" : this.TE_DISPLAY.EditValue.ToString();
            CurrentData.AppName = (this.te_AppName.EditValue == null) ? "" : this.te_AppName.EditValue.ToString();
            CurrentData.RegURL = (this.te_URL.EditValue == null) ? "" : this.te_URL.EditValue.ToString();
            CurrentData.Meta = (this.te_Meta.EditValue == null) ? "" : this.te_Meta.EditValue.ToString();
            CurrentData.DisplayHeight = (this.te_DisplayHeight.EditValue == null) ? 40 : (int)this.te_DisplayHeight.EditValue;
            CurrentData.DisplayHeight = (CurrentData.DisplayHeight == 0) ? 40 : CurrentData.DisplayHeight;
            CurrentData.DisplayOrder = (this.te_DisplayOrder.EditValue == null) ? 0 : (int)this.te_DisplayOrder.EditValue;

            return CurrentData;
        }

        private void SaveData()
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                MD_View2App _newData = this.GetData();
                if (_mdc.SaveView2App(_newData.ID, _newData))
                {
                    XtraMessageBox.Show("保存成功！", "系统提示", MessageBoxButtons.OK);
                    this._haveChange = false;
                    RaiseDataChanged();
                }
                else
                {
                    XtraMessageBox.Show("保存失败！", "系统提示", MessageBoxButtons.OK);
                }
            }
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

        public List<SinoSZPluginFramework.FrmMenuGroup> GetControlMenu()
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

        private void RefreshData()
        {
            InitData(CurrentData);
        }

        private void TE_DISPLAY_EditValueChanged(object sender, EventArgs e)
        {
            _haveChange = true;
            RaiseDataChanged();
        }

        private void te_AppName_EditValueChanged(object sender, EventArgs e)
        {
            _haveChange = true;
            RaiseDataChanged();
        }

        private void te_URL_EditValueChanged(object sender, EventArgs e)
        {
            _haveChange = true;
            RaiseDataChanged();
        }

        private void te_DisplayHeight_EditValueChanged(object sender, EventArgs e)
        {
            _haveChange = true;
            RaiseDataChanged();
        }

        private void te_DisplayOrder_EditValueChanged(object sender, EventArgs e)
        {
            _haveChange = true;
            RaiseDataChanged();
        }

        private void te_Meta_EditValueChanged(object sender, EventArgs e)
        {
            _haveChange = true;
            RaiseDataChanged();
        }



    }
}
