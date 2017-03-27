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
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZClientBase.MetaDataService;

namespace SinoSZMetaDataManager
{
    public partial class GuideLineGroupManager : DevExpress.XtraEditors.XtraUserControl, IControlMenu
    {
        private MD_GuideLineGroup _guideLineGroup = null;
        private bool _haveChange = false;
        private bool _initFinished = false;

        public GuideLineGroupManager()
        {
            InitializeComponent();
        }

        public GuideLineGroupManager(MD_GuideLineGroup _gr)
        {
            InitializeComponent();
            _guideLineGroup = _gr;
            RefreshData();
            _initFinished = true;
        }

        private void RefreshData()
        {
            this.TE_Descript.EditValue = this._guideLineGroup.ZBZTSM;
            this.TE_GroupName.EditValue = this._guideLineGroup.ZBZTMC;
            this.TE_Namespace.EditValue = this._guideLineGroup.NamespaceName;
            this.TE_RightType.EditValue = this._guideLineGroup.QXLX;
            this.TE_Type.SelectedIndex = (this._guideLineGroup.LX == 3) ? 0 : 1;
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

        private void SaveData()
        {

            this._guideLineGroup.ZBZTSM = this.TE_Descript.EditValue.ToString();
            this._guideLineGroup.QXLX = this.TE_RightType.SelectedIndex;
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                if (_mdc.SaveGuideLineGroupDefine(this._guideLineGroup))
                {
                    this._haveChange = false;
                    RaiseMenuChanged();
                }
                else
                {
                    XtraMessageBox.Show("保存失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    RaiseMenuChanged();
                    break;
            }
            return true;
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

        #endregion

        private void TE_GroupName_EditValueChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void TE_Namespace_EditValueChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void TE_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();

        }

        private void TE_RightType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void TE_Descript_EditValueChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }

        internal void InserNew(MD_Nodes _nodes, string _groupType)
        {
            _guideLineGroup = new MD_GuideLineGroup();
            _guideLineGroup.SSDW = _nodes.DWDM;
            _guideLineGroup.LX = (_groupType == "TJZB") ? 3 : 1;
            RefreshData();
            this.TE_GroupName.Properties.ReadOnly = false;
        }

        /// <summary>
        /// 验证输入信息正确性
        /// </summary>
        /// <param name="_msg"></param>
        /// <returns></returns>
        internal bool InputCheck(out string _msg)
        {
            _msg = "";
            return true;
        }

        /// <summary>
        /// 保存新的指标组定义
        /// </summary>
        internal bool SaveNew()
        {
            this._guideLineGroup.ZBZTSM = (this.TE_Descript.EditValue == null) ? "" : this.TE_Descript.EditValue.ToString();
            this._guideLineGroup.QXLX = this.TE_RightType.SelectedIndex;
            this._guideLineGroup.ZBZTMC = this.TE_GroupName.EditValue.ToString();
            this._guideLineGroup.NamespaceName = (this.TE_Namespace.EditValue == null) ? "" : this.TE_Namespace.EditValue.ToString();
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                if (_mdc.IsExistGuideLineGroupName(this._guideLineGroup.ZBZTMC))
                {
                    XtraMessageBox.Show(string.Format("已经存在名称为{0}的指标组!", _guideLineGroup.ZBZTMC),
                                    "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (_mdc.SaveNewGuideLineGroupDefine(this._guideLineGroup))
                {
                    this._haveChange = false;
                    return true;
                }
                else
                {
                    XtraMessageBox.Show("保存失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
        }
    }
}
