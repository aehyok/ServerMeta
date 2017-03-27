using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.Authorize;
using SinoSZPluginFramework;
using SinoSZClientUser.UserManager;
using SinoSZClientUser.PostManager;
using SinoSZJS.Base.User;
using System.Linq;

namespace SinoSZClientUser
{
    public partial class frmUserDefine : XtraForm, IChildForm
    {
        private IApplication _application = null;
        private bool ShowChildOrgUsers = false;
        private bool _initFinished = false;
        private SinoOrganize _currentOrg = null;
        private List<UserBaseInfo> CurrentUserList = null;
        private static List<UserPostInfo> ClipPad = new List<UserPostInfo>();
        private bool CanAddUser = false;
        public frmUserDefine()
        {
            InitializeComponent();
        }
        public frmUserDefine(string _title, string _canAdd)
        {
            string _can = _canAdd.Trim().ToUpper();
            if (_can == "YES" || _can == "TRUE")
            {
                CanAddUser = true;
            }
            InitializeComponent();
            this.Text = _title;
        }

        private void frmUserDefine_Load(object sender, EventArgs e)
        {
            this.sinoUC_OrgTree1.LoadOrgList(SessionClass.CurrentSinoUser.QxszDWID);
            this._currentOrg = this.sinoUC_OrgTree1.SelectedOrganize;
            _initFinished = true;
        }

        /// <summary>
        /// 当前选择的单位变更时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sinoUC_OrgTree1_FocusChanged(object sender, SinoSZClientBase.Organize.OrgEventArgs e)
        {
            SinoOrganize _org = e.Organize;
            _currentOrg = _org;
            RefreshUserList();

        }


        #region 实现IChildForm接口

        public IApplication Application
        {
            get { return _application; }
            set { _application = value; }
        }

        public event EventHandler<EventArgs> MenuChanged;
        virtual public void RaiseMenuChanged()
        {
            if (this._initFinished && MenuChanged != null)
            {
                MenuChanged(this, new EventArgs());
            }
        }


        public IList<FrmMenuPage> GetMenuPages()
        {
            IList<FrmMenuPage> _ret = new List<FrmMenuPage>();
            FrmMenuPage _page = new FrmMenuPage("用户管理");
            _page.MenuGroups = GetMenuGroups(_page.PageTitle);
            _ret.Add(_page);
            return _ret;
        }

        private IList<FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            FrmMenuItem _item;
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();

            FrmMenuGroup _thisGroup = new FrmMenuGroup("用户管理功能");

            _thisGroup.MenuItems = new List<FrmMenuItem>();
            if (this.CanAddUser)
            {
                _item = new FrmMenuItem("添加机构", "添加机构", global::SinoSZClientUser.Properties.Resources.g5, true);
                _thisGroup.MenuItems.Add(_item);
                _item = new FrmMenuItem("删除机构", "删除机构", global::SinoSZClientUser.Properties.Resources.g6, true);
                _thisGroup.MenuItems.Add(_item);
            }

            _item = new FrmMenuItem("注册用户", "注册用户", global::SinoSZClientUser.Properties.Resources.e11, true);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("删除用户", "删除用户", global::SinoSZClientUser.Properties.Resources.e12, this.userList1.IsUserSelected);
            _thisGroup.MenuItems.Add(_item);

            if (this.ShowChildOrgUsers)
            {
                _item = new FrmMenuItem("不含下级", "不含下级", global::SinoSZClientUser.Properties.Resources.e14, true);
            }
            else
            {
                _item = new FrmMenuItem("包含下级", "包含下级", global::SinoSZClientUser.Properties.Resources.e13, true);
            }
            _thisGroup.MenuItems.Add(_item);

            _ret.Add(_thisGroup);

            _thisGroup = new FrmMenuGroup("岗位授权");

            _thisGroup.MenuItems = new List<FrmMenuItem>();
            _item = new FrmMenuItem("添加岗位", "添加岗位", global::SinoSZClientUser.Properties.Resources.e5, this.userList1.IsUserSelected);
            _thisGroup.MenuItems.Add(_item);

            bool _isSelectedPost = (this.userPostList1.SelectedPost != null);
            _item = new FrmMenuItem("删除岗位", "删除岗位", global::SinoSZClientUser.Properties.Resources.e6, _isSelectedPost);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("设默认岗位", "设默认岗位", global::SinoSZClientUser.Properties.Resources.e15, _isSelectedPost);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("查看授权", "查看授权", global::SinoSZClientUser.Properties.Resources.e16, _isSelectedPost);
            _thisGroup.MenuItems.Add(_item);

            _ret.Add(_thisGroup);

            _thisGroup = new FrmMenuGroup("岗位复制");

            _thisGroup.MenuItems = new List<FrmMenuItem>();
            _item = new FrmMenuItem("复制岗位", "复制岗位", global::SinoSZClientUser.Properties.Resources.e8, _isSelectedPost);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("粘贴岗位", "粘贴岗位", global::SinoSZClientUser.Properties.Resources.e9, ClipPad.Count > 0);
            _thisGroup.MenuItems.Add(_item);

            _ret.Add(_thisGroup);
            return _ret;
        }


        public bool DoCommand(string _cmdName)
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
                case "添加机构":
                    AddOrgInfo();
                    break;
                case "删除机构":
                    DelOrgInfo();
                    break;
                case "注册用户":
                    RegisterUser();
                    break;
                case "删除用户":
                    UnRegisterUser();
                    break;
                case "添加岗位":
                    Add_Post();
                    break;
                case "删除岗位":
                    Del_Post();
                    break;
                case "设默认岗位":
                    Set_DefaultPost();
                    break;
                case "查看授权":
                    Show_Rights();
                    break;
                case "复制岗位":
                    Copy_Post();
                    break;
                case "粘贴岗位":
                    Paste_Post();
                    break;

            }

            return true;
        }

        #endregion

        #region 处理命令

        private void DelOrgInfo()
        {
            using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
            {
                if (this._currentOrg != null && CanAddUser)
                {
                    if (_umsc.IsExistChildOrg(this._currentOrg.Code))
                    {
                        XtraMessageBox.Show("请先删除下级组织机构后才可以删除本机构!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string _msg = string.Format("注意: 当您删除机构时,此机构下的用户也将被删除!\n\r\n\r 您确定要删除机构\"{0}\"吗? ", this._currentOrg.FullName);
                        DialogResult _res = XtraMessageBox.Show(_msg, "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (_res == DialogResult.Yes)
                        {
                            if (_umsc.DelOrg(this._currentOrg))
                            {
                                this.sinoUC_OrgTree1.RefreshCurrentFatherNode();
                            }
                            else
                            {
                                XtraMessageBox.Show("删除组织机构失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
        }

        private void AddOrgInfo()
        {
            if (this._currentOrg != null && CanAddUser)
            {
                Dialog_AddOrgInfo _f = new Dialog_AddOrgInfo(this._currentOrg);
                if (_f.ShowDialog() == DialogResult.OK)
                {
                    using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
                    {
                        if (_umsc.AddNewOrg(_f.OrgShotName, _f.OrgFullName, this._currentOrg))
                        {
                            this.sinoUC_OrgTree1.RefreshCurrentNode();
                        }
                        else
                        {
                            XtraMessageBox.Show("添加组织机构失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            }
        }


        /// <summary>
        /// 注册用户
        /// </summary>
        private void RegisterUser()
        {
            if (this._currentOrg != null)
            {
                if (CanAddUser)
                {
                    Dialog_AddUserInfo _uinfo = new Dialog_AddUserInfo(this._currentOrg);
                    if (_uinfo.ShowDialog() == DialogResult.OK)
                    {
                        using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
                        {
                            if (_umsc.AddUserInfo(_uinfo.YHM, _uinfo.XM, _uinfo.XB, _uinfo.SFZH,
                                this._currentOrg.Code, GetDWGUID(this._currentOrg.Code), _uinfo.HGGH, _uinfo.JH, _uinfo.ZWMC, _uinfo.ZWJB, _uinfo.EMAIL))
                            {
                                RefreshUserList();
                            }
                            else
                            {
                                XtraMessageBox.Show("添加用户失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                    }
                }
                else
                {
                    Dialog_RegisterUser _f = new Dialog_RegisterUser(this._currentOrg.Code, ShowChildOrgUsers);
                    if (_f.ShowDialog() == DialogResult.OK)
                    {
                        RefreshUserList();
                    }
                }
            }
        }

        private string GetDWGUID(decimal _code)
        {
            using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
            {
                return _umsc.GetDWGUID(_code);
            }
        }

        private void UnRegisterUser()
        {
            if (this.userList1.IsUserSelected)
            {
                DialogResult _ret = XtraMessageBox.Show(string.Format("确认要删除用户{0}吗?", this.userList1.FocusedUser.UserName), "系统提示",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (_ret == DialogResult.Yes)
                {
                    using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
                    {
                        if (_umsc.UnRegisterUser(this.userList1.FocusedUser.UserID))
                        {
                            RefreshUserList();
                        }
                        else
                        {
                            XtraMessageBox.Show(string.Format("删除用户{0}失败!", this.userList1.FocusedUser.UserName), "系统提示",
                                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
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


        private void Copy_Post()
        {
            ClipPad = this.userPostList1.GetSelectedPosts();
            RaiseMenuChanged();
        }


        private void Paste_Post()
        {
            using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
            {
                if (ClipPad.Count > 0)
                {
                    string _msg = "";
                    if (this.userPostList1.ExistName(ClipPad, ref _msg))
                    {
                        XtraMessageBox.Show(string.Format("已经存在名称为{0}的岗位!", _msg), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        foreach (UserPostInfo _p in ClipPad)
                        {
                            if (_umsc.AddUserPost(this.userList1.FocusedUser.UserID, _p.PostID))
                            {

                            }
                            else
                            {
                                XtraMessageBox.Show(string.Format("添加岗位{0}失败!", _p.PostName),
                                      "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        ShowUserPostList();
                        this.RaiseMenuChanged();
                    }
                }
            }
        }

        #endregion


        private void timer1_Tick(object sender, EventArgs e)
        {
            this.pBarUserList.Increment(5);
            if (this.pBarUserList.Position > 90) this.pBarUserList.Position = 0;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
            {
                CurrentUserList = _umsc.GetUserListInOrg(this._currentOrg.Code, ShowChildOrgUsers ? (decimal)10000 : (decimal)1).ToList<UserBaseInfo>();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.timer1.Enabled = false;
            this.userList1.DataSource = CurrentUserList;
            ShowUserPostList();
            this.pWaitUserList.Visible = false;
            this.sinoUC_OrgTree1.Enabled = true;
            this.RaiseMenuChanged();
        }

        private void userList1_UserFocusChanged(object sender, EventArgs e)
        {
            ShowUserPostList();
            this.RaiseMenuChanged();
        }

        private void ShowUserPostList()
        {
            if (this.userList1.IsUserSelected)
            {
                UserBaseInfo _user = this.userList1.FocusedUser;
                this.userPostList1.UserInfo = _user;
            }
        }

        private void Add_Post()
        {
            if (this.userList1.IsUserSelected)
            {
                Dialog_AddUserPost _f = new Dialog_AddUserPost(this.userList1.FocusedUser);
                if (_f.ShowDialog() == DialogResult.OK)
                {
                    ShowUserPostList();
                    this.RaiseMenuChanged();
                }
            }
        }

        private void Del_Post()
        {
            if (this.userList1.FocusedUser != null && this.userPostList1.SelectedPost != null)
            {
                using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
                {
                    if (_umsc.DeleteUserPost(this.userList1.FocusedUser.UserID, this.userPostList1.SelectedPost.PostID))
                    {
                        ShowUserPostList();
                        this.RaiseMenuChanged();
                    }
                    else
                    {
                        XtraMessageBox.Show(string.Format("删除岗位{0}失败!", this.userPostList1.SelectedPost.PostName), "系统提示",
                                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void Show_Rights()
        {
            if (this.userList1.FocusedUser != null && this.userPostList1.SelectedPost != null)
            {
                Dialog_ShowPostRight _f = new Dialog_ShowPostRight(this.userPostList1.SelectedPost.Post);
                _f.ShowDialog();
            }
        }

        private void Set_DefaultPost()
        {
            if (this.userList1.FocusedUser != null && this.userPostList1.SelectedPost != null)
            {
                using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
                {
                    if (_umsc.SetDefaultUserPost(this.userList1.FocusedUser.UserID, this.userPostList1.SelectedPost.PostID))
                    {
                        ShowUserPostList();
                        this.RaiseMenuChanged();
                    }
                }
            }
        }


    }
}