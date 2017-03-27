using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZClientBase;
using SinoSZJS.Base.Authorize;
using SinoSZJS.Base.User;
using System.Linq;
using SinoSZPluginFramework;

namespace SinoSZClientUser.UserMapping
{
    public partial class frmUserMapping_CUPAA : frmBase
    {
        private SinoOrganize _currentOrg = null;
        private bool ShowChildOrgUsers = false;
        private List<UserMappingInfo> CurrentUserList = null;
        public frmUserMapping_CUPAA()
        {
            InitializeComponent();
        }

        public override void Init(string _title, string _menuName, object _param)
        {
            this._menuPageName = _menuName;
            this.sinoUC_OrgTree1.LoadOrgList(SessionClass.CurrentSinoUser.QxszDWID);
            this._currentOrg = this.sinoUC_OrgTree1.SelectedOrganize;
            _initFinished = true;
        }

        private void sinoUC_OrgTree1_FocusChanged(object sender, SinoSZClientBase.Organize.OrgEventArgs e)
        {
            SinoOrganize _org = e.Organize;
            _currentOrg = _org;
            RefreshUserList();
        }

        /// <summary>
        /// 刷新用户列表
        /// </summary>
        private void RefreshUserList()
        {
            this.pWaitUserList.Visible = true;
            this.timer1.Enabled = true;
            this.sinoUC_OrgTree1.Enabled = false;
            this.pBarUserList.Position = 0;
            if (!this.backgroundWorker1.IsBusy) this.backgroundWorker1.RunWorkerAsync();

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
            {
                CurrentUserList = _umsc.GetUserListMapping(this._currentOrg.Code, ShowChildOrgUsers ? (decimal)10000 : (decimal)1).ToList<UserMappingInfo>();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.timer1.Enabled = false;
            this.userMappingList1.DataSource = CurrentUserList;
            this.pWaitUserList.Visible = false;
            this.sinoUC_OrgTree1.Enabled = true;
            this.RaiseMenuChanged();
        }



        #region 重载基类的方法

        protected override IList<FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            FrmMenuItem _item;
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();

            FrmMenuGroup _thisGroup = new FrmMenuGroup("三统一用户信息映射");
            _thisGroup.MenuItems = new List<FrmMenuItem>();

            if (this.ShowChildOrgUsers)
            {
                _item = new FrmMenuItem("不含下级", "不含下级", global::SinoSZClientUser.Properties.Resources.e14, true);
            }
            else
            {
                _item = new FrmMenuItem("包含下级", "包含下级", global::SinoSZClientUser.Properties.Resources.e13, true);
            }
            _thisGroup.MenuItems.Add(_item);



            _item = new FrmMenuItem("保存映射", "保存映射", global::SinoSZClientUser.Properties.Resources.xx, true);
            _thisGroup.MenuItems.Add(_item);

            _ret.Add(_thisGroup);

            return _ret;
        }

        protected override bool ExcuteCommand(string _cmdName)
        {
            switch (_cmdName)
            {
                case "不含下级":
                    this.ShowChildOrgUsers = false;
                    RefreshUserList();
                    break;
                case "包含下级":
                    this.ShowChildOrgUsers = true;
                    RefreshUserList();
                    break;
                case "保存映射":
                    SaveMapping();
                    break;

            }
            return true;
        }




        #endregion

        private void SaveMapping()
        {
            bool _ret = false;
            UserMappingInfo _umi = this.userMappingList1.FocusedUser;
            string _name = this.TE_TRD_NAME.Text.Trim();
            string _yhid = this.TE_TRD_USERID.Text.Trim();
            string _xm = this.TE_TRD_XM.Text.Trim();
            using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
            {
                _ret = _umsc.SaveUserMapping(_yhid, _umi.UserID, _name, _xm, _umi.UserName);
            }
            if (_ret)
            {
                this.userMappingList1.BeginUpdate();
                _umi.TRD_LoginName = _name;
                _umi.TRD_YHID = _yhid;
                _umi.TRD_XM = _xm;
                this.userMappingList1.EndUpdate();
                XtraMessageBox.Show("保存映射成功！", "系统提示");
            }
        }

        private void userMappingList1_UserFocusChanged(object sender, EventArgs e)
        {
            UserMappingInfo _umi = this.userMappingList1.FocusedUser;
            if (_umi != null)
            {
                this.te_CUPAA_USERID.Text = _umi.UserID;
                this.TE_CUPAA_USERNAME.Text = _umi.UserName;
                this.TE_TRD_NAME.Text = _umi.TRD_LoginName;
                this.TE_TRD_USERID.Text = _umi.TRD_YHID;
                this.TE_TRD_XM.Text = _umi.TRD_XM;
            }
            else
            {
                this.te_CUPAA_USERID.Text = "";
                this.TE_CUPAA_USERNAME.Text = "";
                this.TE_TRD_NAME.Text = "";
                this.TE_TRD_USERID.Text = "";
                this.TE_TRD_XM.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _trdinfo = "";
            string _loginName = this.te_search.Text.Trim();
            if (_loginName == null || _loginName == "")
            {
                Clear_TRD_Info();
            }
            else
            {
                using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
                {
                    _trdinfo = _umsc.GetTRDUserInfo(_loginName, _currentOrg.Code.ToString());
                }
                if (_trdinfo == null || _trdinfo == "" || _trdinfo == ",,")
                {
                    XtraMessageBox.Show("未在线索系统中找到对应的用户！", "系统提示");
                    Clear_TRD_Info();
                }
                else
                {
                    string[] _ns = _trdinfo.Split(',');
                    if (_ns.Length != 3)
                    {
                        XtraMessageBox.Show("未在线索系统中找到对应的用户！", "系统提示");
                        Clear_TRD_Info();
                    }
                    else
                    {
                        this.TE_TRD_NAME.Text = _ns[0];
                        this.TE_TRD_USERID.Text = _ns[1];
                        this.TE_TRD_XM.Text = _ns[2];
                    }
                }
            }

        }

        private void Clear_TRD_Info()
        {
            this.TE_TRD_NAME.Text = "";
            this.TE_TRD_USERID.Text = "";
            this.TE_TRD_XM.Text = "";
        }



    }
}