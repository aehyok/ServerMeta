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
using SinoSZClientBase.MetaDataService;

namespace SinoSZMetaDataManager
{
    public partial class QueryModelManager : DevExpress.XtraEditors.XtraUserControl, IControlMenu
    {
        private bool _haveChange = false;
        private bool _initFinished = false;
        MD_QueryModel _queryModel = null;
        MD_Namespace _nameSpace = null;
        public QueryModelManager()
        {
            InitializeComponent();
        }

        public QueryModelManager(MD_QueryModel _qm)
        {
            InitializeComponent();
            _queryModel = _qm;
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

        #endregion

        private void SaveData()
        {
            _queryModel.Description = this.TE_DES.EditValue.ToString();
            _queryModel.DisplayTitle = this.TE_DISPLAY.EditValue.ToString();
            _queryModel.DisplayOrder = Convert.ToInt32(this.TE_DISPLAYORDER.EditValue.ToString());
            _queryModel.QueryModelName = this.TE_MODELNAME.EditValue.ToString();
            _queryModel.IsFixQuery = (this.TE_TYPE.Items[0].CheckState == CheckState.Checked);
            _queryModel.IsRelationQuery = (this.TE_TYPE.Items[1].CheckState == CheckState.Checked);
            _queryModel.IsDataAuditing = (this.TE_TYPE.Items[2].CheckState == CheckState.Checked);
            _queryModel.QueryInterface = (this.te_Ics.SelectedItem.ToString());
            _queryModel.EXTMeta = (this.te_ExtMeta.EditValue == null) ? "" : this.te_ExtMeta.EditValue.ToString();
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                _mdc.SaveQueryModel(_queryModel);
            }
            _haveChange = false;
            RaiseDataChanged();
        }


        public void SetNamespace(MD_Namespace _ns)
        {
            _nameSpace = _ns;
            this.TE_NAMESPACE.EditValue = _ns.DisplayTitle;
            this.te_Ics.SelectedIndex = 0;
        }


        public MD_QueryModel SaveNew()
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                _queryModel = new MD_QueryModel();
                _queryModel.Description = (this.TE_DES.EditValue == null) ? "" : this.TE_DES.EditValue.ToString();
                _queryModel.DisplayTitle = (this.TE_DISPLAY.EditValue == null) ? this.TE_MODELNAME.EditValue.ToString() : this.TE_DISPLAY.EditValue.ToString();
                _queryModel.DisplayOrder = Convert.ToInt32((this.TE_DISPLAYORDER.EditValue == null) ? "0" : this.TE_DISPLAYORDER.EditValue.ToString());
                _queryModel.QueryModelName = this.TE_MODELNAME.EditValue.ToString();
                _queryModel.IsFixQuery = (this.TE_TYPE.Items[0].CheckState == CheckState.Checked);
                _queryModel.IsRelationQuery = (this.TE_TYPE.Items[1].CheckState == CheckState.Checked);
                _queryModel.IsDataAuditing = (this.TE_TYPE.Items[2].CheckState == CheckState.Checked);
                _queryModel.QueryInterface = (this.te_Ics.EditValue.ToString());
                _queryModel.NamespaceName = (_nameSpace == null) ? "" : _nameSpace.NameSpace;
                _queryModel.DWDM = _nameSpace.DWDM;
                _queryModel.EXTMeta = (this.te_ExtMeta.EditValue == null) ? "" : this.te_ExtMeta.EditValue.ToString();
                _mdc.SaveNewQueryModel(_queryModel);
            }
            _haveChange = false;
            RaiseDataChanged();
            return _queryModel;
        }
        private void RefreshData()
        {
            if (_queryModel == null) return;
            this.TE_DES.EditValue = _queryModel.Description;
            this.TE_DISPLAY.EditValue = _queryModel.DisplayTitle;
            this.TE_DISPLAYORDER.EditValue = _queryModel.DisplayOrder;
            this.TE_ID.EditValue = _queryModel.QueryModelID;
            this.TE_MODELNAME.EditValue = _queryModel.QueryModelName;
            this.TE_NAMESPACE.EditValue = _queryModel.Namespace.DisplayTitle;
            this.TE_TYPE.Items[0].CheckState = _queryModel.IsFixQuery ? CheckState.Checked : CheckState.Unchecked;
            this.TE_TYPE.Items[1].CheckState = _queryModel.IsRelationQuery ? CheckState.Checked : CheckState.Unchecked;
            this.TE_TYPE.Items[2].CheckState = _queryModel.IsDataAuditing ? CheckState.Checked : CheckState.Unchecked;
            this.te_Ics.EditValue = _queryModel.QueryInterface;
            this.te_ExtMeta.EditValue = _queryModel.EXTMeta;
            this._haveChange = false;
        }

        private void InputDataChanged()
        {
            _haveChange = true;
            RaiseDataChanged();
        }


        private void sinoSZTextEdit3_EditValueChanged(object sender, EventArgs e)
        {
            //修改数据
            InputDataChanged();
        }

        private void sinoSZTextEdit4_EditValueChanged(object sender, EventArgs e)
        {
            //修改数据
            InputDataChanged();
        }

        private void sinoSZTextEdit5_EditValueChanged(object sender, EventArgs e)
        {
            //修改数据
            InputDataChanged();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TE_ID_EditValueChanged(object sender, EventArgs e)
        {
            //修改数据
            InputDataChanged();
        }

        private void TE_NAMESPACE_EditValueChanged(object sender, EventArgs e)
        {
            //修改数据
            InputDataChanged();
        }

        private void TE_DES_EditValueChanged(object sender, EventArgs e)
        {
            //修改数据
            InputDataChanged();
        }

        private void TE_TYPE_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TE_TYPE_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            //修改数据
            InputDataChanged();
        }

        private void te_Ics_SelectedIndexChanged(object sender, EventArgs e)
        {
            InputDataChanged();
        }

        private void te_ExtMeta_EditValueChanged(object sender, EventArgs e)
        {
            InputDataChanged();
        }



    }
}
