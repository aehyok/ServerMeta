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

namespace SinoSZClientUser.UserManager
{
    public partial class Dialog_AddUserPost : DevExpress.XtraEditors.XtraForm
    {
        private UserBaseInfo CurrentUser = null;
        private bool _initFinished = false;
        private SinoOrganize _currentOrg = null;
        private bool PostAdded = false;
        public Dialog_AddUserPost()
        {
            InitializeComponent();
        }

        public Dialog_AddUserPost(UserBaseInfo _user)
        {
            InitializeComponent();
            CurrentUser = _user;
            InitForm();
        }

        private void InitForm()
        {
            this.sinoUC_OrgTree1.LoadOrgList(SessionClass.CurrentSinoUser.QxszDWID);
            this._currentOrg = this.sinoUC_OrgTree1.SelectedOrganize;
            _initFinished = true;
            ShowPostOfOrg(this._currentOrg);
        }

        private void sinoUC_OrgTree1_FocusChanged(object sender, SinoSZClientBase.Organize.OrgEventArgs e)
        {
            SinoOrganize _org = e.Organize;
            ShowPostOfOrg(_org);
        }

        private void ShowPostOfOrg(SinoOrganize _org)
        {
            this.postList1.Organize = _org;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (PostAdded)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //添加岗位
             using(SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
             {
                 if (this.postList1.SelectedPost != null)
                 {
                     if (_umsc.IsExistUserPost(this.CurrentUser.UserID, this.postList1.SelectedPost.PostID))
                     {
                         XtraMessageBox.Show(string.Format("用户{0}已经具有{0}的岗位授权!", this.CurrentUser.UserName, this.postList1.SelectedPost.PostName),
                                 "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                         return;
                     }
                     else
                     {
                         if (_umsc.AddUserPost(this.CurrentUser.UserID, this.postList1.SelectedPost.PostID))
                         {
                             this.PostAdded = true;
                             XtraMessageBox.Show(string.Format("添加岗位{0}成功!", this.postList1.SelectedPost.PostName),
                                     "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                         }
                         else
                         {
                             XtraMessageBox.Show(string.Format("添加岗位{0}失败!", this.postList1.SelectedPost.PostName),
                                   "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         }
                     }
                 }
            }
        }
    }
}