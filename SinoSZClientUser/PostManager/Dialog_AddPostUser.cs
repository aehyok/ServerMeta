using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.Authorize;
using SinoSZJS.Base.User;
using System.Linq;

namespace SinoSZClientUser.PostManager
{
    public partial class Dialog_AddPostUser : DevExpress.XtraEditors.XtraForm
    {
        private SinoOrganize _currentOrg = null;
        private List<UserBaseInfo> CurrentUserList = null;
        public Dialog_AddPostUser()
        {
            InitializeComponent();
        }

        #region 自定义事件
        public event EventHandler<PostUserAddArgs> UserAdded;
        public void RaiseUserAdded(PostUserAddArgs _args)
        {

            if (UserAdded != null)
            {
                UserAdded(this, _args);
            }

        }
        #endregion

        private void userList1_Load(object sender, EventArgs e)
        {
            this.sinoUC_OrgTree1.LoadOrgList(SessionClass.CurrentSinoUser.QxszDWID);
            this._currentOrg = this.sinoUC_OrgTree1.SelectedOrganize;
            RefreshUserList();
        }

        private void sinoUC_OrgTree1_FocusChanged(object sender, SinoSZClientBase.Organize.OrgEventArgs e)
        {
            SinoOrganize _org = e.Organize;
            _currentOrg = _org;
            RefreshUserList();
        }
        private bool ShowChildOrgUsers
        {
            get
            {
                return this.checkEdit1.Checked;
            }
        }
        private void RefreshUserList()
        {
            this.panelControl1.Visible = true;
            this.labelStatus.Text = "正在读取用户列表....";
            this.sinoUC_OrgTree1.Enabled = false;
            if (!this.backgroundWorker1.IsBusy) this.backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
            {
                CurrentUserList = _umsc.GetUserListInOrg(this._currentOrg.Code, ShowChildOrgUsers ? (decimal)1000 : (decimal)1).ToList<UserBaseInfo>();
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.userList1.DataSource = CurrentUserList;
            this.panelControl1.Visible = false;
            this.sinoUC_OrgTree1.Enabled = true;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (this.userList1.FocusedUser != null)
            {
                PostUserAddArgs _args = new PostUserAddArgs(this.userList1.FocusedUser);
                RaiseUserAdded(_args);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            RefreshUserList();
        }
    }
}