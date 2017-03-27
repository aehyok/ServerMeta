using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.Authorize;
using SinoSZClientUser.PostManager;
using SinoSZJS.Base.User;
using System.Linq;

namespace SinoSZClientUser.Controls
{
    public partial class PostUserList : DevExpress.XtraEditors.XtraUserControl
    {
        private List<UserBaseInfo> CurrentPostUserList = null;
        public PostUserList()
        {
            InitializeComponent();
        }

        public UserBaseInfo FocusedUser
        {
            get
            {
                if (this.gridView1.RowCount > 0 && this.gridView1.FocusedRowHandle >= 0)
                {
                    return this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as UserBaseInfo;
                }
                else
                {
                    return null;
                }
            }
        }

        private SinoPost CurrentPost = null;
        public SinoPost Post
        {
            set
            {
                CurrentPost = value;
                InitUserList();
            }

            get { return CurrentPost; }
        }

        private void InitUserList()
        {

            if (CurrentPost == null)
            {
                this.gridView1.BeginUpdate();
                CurrentPostUserList = new List<UserBaseInfo>();
                this.sinoCommonGrid1.DataSource = CurrentPostUserList;
                this.gridView1.EndUpdate();
            }
            else
            {
                this.gridView1.BeginUpdate();
                using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
                {
                    CurrentPostUserList = _umsc.GetUsersOfPost(CurrentPost.PostID).ToList<UserBaseInfo>();
                }
                this.sinoCommonGrid1.DataSource = CurrentPostUserList;
                this.gridView1.EndUpdate();
            }
        }


        public void AddUser()
        {
            Dialog_AddPostUser _f = new Dialog_AddPostUser();
            _f.UserAdded += new EventHandler<PostUserAddArgs>(_f_UserAdded);
            _f.ShowDialog();
        }

        private void _f_UserAdded(object sender, PostUserAddArgs e)
        {
            UserBaseInfo _cUser = e.User;
            bool _find = false;
            SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient();
            foreach (UserBaseInfo _user in this.CurrentPostUserList)
            {
                if (_user.UserID == _cUser.UserID) _find = true;
            }
            if (!_find)
            {
                if (_umsc.AddUserPost(_cUser.UserID, CurrentPost.PostID))
                {
                    this.gridView1.BeginUpdate();
                    this.CurrentPostUserList.Add(_cUser);
                    this.sinoCommonGrid1.DataSource = this.CurrentPostUserList;
                    this.gridView1.EndUpdate();
                    XtraMessageBox.Show(string.Format("用户{0}添加成功！", _cUser.UserName), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void DeleteCurretUser()
        {
            UserBaseInfo _cUser = this.FocusedUser;
            if (_cUser == null) return;
            SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient();
            if (_umsc.DeleteUserOfPost(CurrentPost.PostID, _cUser.UserID))
            {
                this.gridView1.BeginUpdate();
                this.CurrentPostUserList.Remove(_cUser);
                this.sinoCommonGrid1.DataSource = this.CurrentPostUserList;
                this.gridView1.EndUpdate();
            }
            else
            {
            }
        }
    }
}
