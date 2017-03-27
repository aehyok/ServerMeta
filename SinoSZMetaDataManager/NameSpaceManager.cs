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
    public partial class NameSpaceManager : DevExpress.XtraEditors.XtraUserControl, IControlMenu
    {
        private bool _haveChange = false;
        private bool _initFinished = false;

        private MD_Namespace _nodesData;
        public MD_Namespace NodesData
        {
            get
            {
                this.TE_NAMESPACE.BindingManager.EndCurrentEdit();
                this.TE_OWNER.BindingManager.EndCurrentEdit();
                this.TE_ORDER.BindingManager.EndCurrentEdit();
                this.TE_MENU.BindingManager.EndCurrentEdit();
                this.TE_DISPLAY.BindingManager.EndCurrentEdit();
                this.TE_DESCRIPT.BindingManager.EndCurrentEdit();
                this.TE_CONCEPTS.BindingManager.EndCurrentEdit();
                this.TE_DWDM.BindingManager.EndCurrentEdit();
                return _nodesData;
            }

            set
            {
                _nodesData = value;
                if (_nodesData != null)
                {
                    RefreshData();
                }
            }

        }

        public NameSpaceManager()
        {
            InitializeComponent();
        }

        public NameSpaceManager(MD_Namespace _ns)
        {
            InitializeComponent();
            NodesData = _ns;

        }

        private void sinoSZComboEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RefreshData()
        {
            this.TE_NAMESPACE.EditValue = _nodesData.NameSpace;
            this.TE_CONCEPTS.EditValue = _nodesData.Concepts;
            this.TE_DESCRIPT.EditValue = _nodesData.Description;
            this.TE_DISPLAY.EditValue = _nodesData.DisplayTitle;
            this.TE_DWDM.EditValue = _nodesData.DWDM;
            this.TE_MENU.EditValue = _nodesData.MenuPosition;
            this.TE_ORDER.EditValue = _nodesData.DisplayOrder;
            this.TE_OWNER.EditValue = _nodesData.Owner;

            this._haveChange = false;
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

        //保存新
        public void SaveNew(MD_Nodes _nodes)
        {
            MD_Namespace _ns = new MD_Namespace();
            _ns.NameSpace = this.TE_NAMESPACE.EditValue.ToString();
            _ns.Description = this.TE_DESCRIPT.EditValue.ToString();
            _ns.MenuPosition = (this.TE_MENU.EditValue == null) ? "" : this.TE_MENU.EditValue.ToString();
            _ns.DisplayTitle = this.TE_DISPLAY.EditValue.ToString();
            _ns.Owner = this.TE_OWNER.EditValue.ToString();
            _ns.DisplayOrder = this.TE_ORDER.EditValue.ToString() == "" ? 0 : int.Parse(this.TE_ORDER.EditValue.ToString());
            _ns.DWDM = this.TE_DWDM.EditValue.ToString();
            _ns.Concepts = this.TE_CONCEPTS.EditValue.ToString();
            _ns.Nodes = _nodes;
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                _mdc.SaveNewNameSapce(_ns);
            }
        }

        public bool InputCheck(out string _errorMsg)
        {
            bool _ret = true;
            _errorMsg = "";
            if (this.TE_NAMESPACE.EditValue == null)
            {
                _ret = false;
                _errorMsg += "未输入命名空间的名称！\n";
            }

            if (this.TE_DESCRIPT.EditValue == null)
            {
                _ret = false;
                _errorMsg += "未输入描述信息！\n";
            }

            if (this.TE_CONCEPTS.EditValue == null)
            {
                _ret = false;
                _errorMsg += "未输入概念标签组信息！\n";
            }

            if (this.TE_DISPLAY.EditValue == null)
            {
                _ret = false;
                _errorMsg += "未输入显示名称！\n";
            }

            if (this.TE_DWDM.EditValue == null)
            {
                _ret = false;
                _errorMsg += "未输入单位信息！\n";
            }


            if (this.TE_OWNER.EditValue == null)
            {
                _ret = false;
                _errorMsg += "未输入所有者名称！\n";
            }

            if (this.TE_ORDER.EditValue == null)
            {
                _ret = false;
                _errorMsg += "未输入显示顺序！\n";
            }

            return _ret;

        }

        private void TE_DESCRIPT_EditValueChanged(object sender, EventArgs e)
        {
            InputDataChanged();
        }

        internal void InsertNewNs(MD_Nodes _node)
        {
            this.TE_NAMESPACE.Properties.ReadOnly = false;
            this.TE_OWNER.EditValue = _node.NodeName;
            this.TE_DWDM.EditValue = _node.DWDM;

        }

        #region IControlMenu Members



        /// <summary>
        /// 是否有数据变更
        /// </summary>
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

        private void SaveData()
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                this._nodesData.NameSpace = this.TE_NAMESPACE.EditValue.ToString();
                this._nodesData.Description = this.TE_DESCRIPT.EditValue.ToString();
                this._nodesData.MenuPosition = (this.TE_MENU.EditValue == null) ? "" : this.TE_MENU.EditValue.ToString();
                this._nodesData.DisplayTitle = this.TE_DISPLAY.EditValue.ToString();
                this._nodesData.Owner = this.TE_OWNER.EditValue.ToString();
                this._nodesData.DisplayOrder = this.TE_ORDER.EditValue.ToString() == "" ? 0 : int.Parse(this.TE_ORDER.EditValue.ToString());
                this._nodesData.DWDM = this.TE_DWDM.EditValue.ToString();
                this._nodesData.Concepts = this.TE_CONCEPTS.EditValue.ToString();

                if (_mdc.SaveNameSapce(this._nodesData))
                {
                    XtraMessageBox.Show("保存成功！");
                    _haveChange = false;
                    this.RaiseMenuChanged();
                }
            }
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

        #endregion


        private void InputDataChanged()
        {
            _haveChange = true;
            RaiseDataChanged();
        }


        private void TE_NAMESPACE_EditValueChanged(object sender, EventArgs e)
        {
            InputDataChanged();
        }

        private void TE_DISPLAY_EditValueChanged(object sender, EventArgs e)
        {
            InputDataChanged();
        }

        private void TE_ORDER_EditValueChanged(object sender, EventArgs e)
        {
            InputDataChanged();
        }

        private void TE_DWDM_EditValueChanged(object sender, EventArgs e)
        {
            InputDataChanged();
        }

        private void TE_CONCEPTS_EditValueChanged(object sender, EventArgs e)
        {
            InputDataChanged();
        }

        private void TE_MENU_EditValueChanged(object sender, EventArgs e)
        {
            InputDataChanged();
        }

        private void NameSpaceManager_Load(object sender, EventArgs e)
        {
            _initFinished = true;
        }


    }
}
