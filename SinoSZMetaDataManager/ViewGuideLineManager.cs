using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZPluginFramework;

using SinoSZClientBase.MetaDataService;
using SinoSZJS.Base.MetaData.Define;

namespace SinoSZMetaDataManager
{
    public partial class ViewGuideLineManager : DevExpress.XtraEditors.XtraUserControl, IControlMenu
    {
        private bool _haveChange = false;
        private bool _initFinished = false;
        private MD_View_GuideLine View2GLDefine = null;
        public ViewGuideLineManager()
        {
            InitializeComponent();
        }


        public ViewGuideLineManager(MD_View_GuideLine gldefine)
        {
            InitializeComponent();
            View2GLDefine = gldefine;
            InitData();
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
            FrmMenuGroup _thisGroup = new FrmMenuGroup("�޸ı���");
            _thisGroup.MenuItems = new List<FrmMenuItem>();
            FrmMenuItem _item = new FrmMenuItem("����", "����", global::SinoSZMetaDataManager.Properties.Resources.xx, _haveChange);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("ȡ��", "ȡ��", global::SinoSZMetaDataManager.Properties.Resources.x1, _haveChange);
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
                DialogResult _res = XtraMessageBox.Show("�Ƿ񱣴������޸�?", "ϵͳ��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                case "����":
                    SaveData();
                    break;
                case "ȡ��":
                    RefreshData();
                    break;
            }
            return true;
        }

        #endregion


        private void InitData()
        {
            if (this.View2GLDefine != null)
            {
                this.uC_View2GLInfo1.initData(this.View2GLDefine);
            }
            _initFinished = true;
        }

        private void RefreshData()
        {
            InitData();
        }

        private void SaveData()
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {

                if (_mdc.SaveView2GL(this.uC_View2GLInfo1.V2GID, this.View2GLDefine.ViewID, this.uC_View2GLInfo1.GuideLineID, this.uC_View2GLInfo1.Parameters, this.uC_View2GLInfo1.DisplayOrder, this.uC_View2GLInfo1.DisplayTitle))
                {
                    View2GLDefine.TargetGuideLineID = this.uC_View2GLInfo1.GuideLineID;
                    View2GLDefine.RelationParam = this.uC_View2GLInfo1.Parameters;
                    View2GLDefine.DisplayOrder = this.uC_View2GLInfo1.DisplayOrder;
                    View2GLDefine.DisplayTitle = this.View2GLDefine.DisplayTitle;
                    XtraMessageBox.Show("����ɹ���", "ϵͳ��ʾ", MessageBoxButtons.OK);
                    this._haveChange = false;
                    RaiseDataChanged();
                }
                else
                {
                    XtraMessageBox.Show("����ʧ�ܣ�", "ϵͳ��ʾ", MessageBoxButtons.OK);
                }
            }
        }

        private void uC_View2GLInfo1_DataChanged(object sender, EventArgs e)
        {
            _haveChange = true;
            RaiseDataChanged();
        }

    }
}
