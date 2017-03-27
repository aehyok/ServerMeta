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
using SinoSZClientUser.Controls;

namespace SinoSZClientUser.PostManager
{
    public partial class frmPostDefine : XtraForm, IChildForm
    {
        private IApplication _application = null;
        private bool _initFinished = false;
        private SinoOrganize _currentOrg = null;
        private static List<SinoPost> ClipPad = new List<SinoPost>();

        public frmPostDefine()
        {
            InitializeComponent();
        }

        private void frmPostDefine_Load(object sender, EventArgs e)
        {
            this.sinoUC_OrgTree1.LoadOrgList(SessionClass.CurrentSinoUser.QxszDWID);
            this._currentOrg = this.sinoUC_OrgTree1.SelectedOrganize;
            _initFinished = true;
            ShowPostOfOrg(this._currentOrg);


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
            FrmMenuPage _page = new FrmMenuPage("岗位管理");
            _page.MenuGroups = GetMenuGroups(_page.PageTitle);
            _ret.Add(_page);
            return _ret;
        }

        private IList<FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();

            bool focuedPost = (this.postList1.SelectedPost != null);

            FrmMenuGroup _thisGroup = new FrmMenuGroup("岗位管理功能");

            _thisGroup.MenuItems = new List<FrmMenuItem>();
            FrmMenuItem _item = new FrmMenuItem("添加岗位", "添加岗位", global::SinoSZClientUser.Properties.Resources.e5, true);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("删除岗位", "删除岗位", global::SinoSZClientUser.Properties.Resources.e6, focuedPost);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("修改岗位", "修改岗位", global::SinoSZClientUser.Properties.Resources.e7, focuedPost);
            _thisGroup.MenuItems.Add(_item);
            _ret.Add(_thisGroup);

            if (this.xtraTabControl1.SelectedTabPageIndex == 0)
            {
                _thisGroup = new FrmMenuGroup("岗位的角色授权");

                _thisGroup.MenuItems = new List<FrmMenuItem>();
                _item = new FrmMenuItem("保存", "保存", global::SinoSZClientUser.Properties.Resources.xx, this.postRoleList1.HaveDataChanged);
                _thisGroup.MenuItems.Add(_item);

                _item = new FrmMenuItem("取消", "取消", global::SinoSZClientUser.Properties.Resources.x1, this.postRoleList1.HaveDataChanged);
                _thisGroup.MenuItems.Add(_item);

                _item = new FrmMenuItem("查看授权", "查看授权", global::SinoSZClientUser.Properties.Resources.e16, focuedPost);
                _thisGroup.MenuItems.Add(_item);

                _ret.Add(_thisGroup);
            }

            if (this.xtraTabControl1.SelectedTabPageIndex == 1)
            {
                _thisGroup = new FrmMenuGroup("岗位的用户");

                _thisGroup.MenuItems = new List<FrmMenuItem>();
                _item = new FrmMenuItem("添加用户", "添加用户", global::SinoSZClientUser.Properties.Resources.e11, (this.postUserList1.Post != null));
                _thisGroup.MenuItems.Add(_item);

                _item = new FrmMenuItem("删除用户", "删除用户", global::SinoSZClientUser.Properties.Resources.e12, (this.postUserList1.FocusedUser != null));
                _thisGroup.MenuItems.Add(_item);

                _ret.Add(_thisGroup);
            }

            _thisGroup = new FrmMenuGroup("岗位复制");

            _thisGroup.MenuItems = new List<FrmMenuItem>();
            _item = new FrmMenuItem("复制岗位", "复制岗位", global::SinoSZClientUser.Properties.Resources.e8, focuedPost);
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
                case "添加岗位":
                    Add_NewPost();
                    break;
                case "删除岗位":
                    Del_Post();
                    break;
                case "修改岗位":
                    Modify_PostInfo();
                    break;
                case "保存":
                    Save_RoleChange();
                    break;
                case "取消":
                    Cancel_RoleChange();
                    break;
                case "复制岗位":
                    Copy_Post();
                    break;
                case "粘贴岗位":
                    Paste_Post();
                    break;
                case "查看授权":
                    Show_Rights();
                    break;
                case "添加用户":
                    Add_PostUser();
                    break;
                case "删除用户":
                    Del_PostUser();
                    break;
            }
            return true;
        }






        #endregion

        private void Add_PostUser()
        {
            if (this.postUserList1.Post != null) this.postUserList1.AddUser();
        }

        private void Del_PostUser()
        {
            if (this.postUserList1.FocusedUser == null) return;
            this.postUserList1.DeleteCurretUser();
        }

        private void sinoUC_OrgTree1_FocusChanged(object sender, SinoSZClientBase.Organize.OrgEventArgs e)
        {
            SinoOrganize _org = e.Organize;
            ShowPostOfOrg(_org);
        }

        private void postList1_FocusPostChanged(object sender, EventArgs e)
        {
            ShowPostRoles();
            RaiseMenuChanged();
        }

        private void postRoleList1_DataChanged(object sender, EventArgs e)
        {
            this.RaiseMenuChanged();
        }

        #region 私有方法
        private void ShowPostOfOrg(SinoOrganize _org)
        {
            this.postList1.Organize = _org;
            ShowPostRoles();
            RaiseMenuChanged();
        }

        /// <summary>
        /// 显示岗位下的所有角色列表
        /// </summary>                
        private void ShowPostRoles()
        {
            if (this.postRoleList1.HaveDataChanged)
            {
                this.postRoleList1.Close();
            }
            SinoPost _post = this.postList1.SelectedPost;
            this.postRoleList1.Post = _post;
            this.postUserList1.Post = _post;

        }

        /// <summary>
        /// 添加岗位
        /// </summary>
        private void Add_NewPost()
        {
            if (this.sinoUC_OrgTree1.SelectedOrganize == null) return;
            Dialog_AddPost _f = new Dialog_AddPost();
            using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
            {
                if (_f.ShowDialog() == DialogResult.OK)
                {
                    string _postName = _f.PostName;
                    string _postDescript = _f.PostDescript;
                    int _PostLevel = _f.PostLevel;
                    _umsc.AddPostOfOrg(_postName, _postDescript, _PostLevel, this.sinoUC_OrgTree1.SelectedOrganize.Code);
                    ShowPostOfOrg(this.sinoUC_OrgTree1.SelectedOrganize);
                }
            }

        }
        /// <summary>
        /// 删除岗位
        /// </summary>
        private void Del_Post()
        {
            if (this.postList1.SelectedPost == null) return;
            using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
            {
                if (_umsc.DelPostOfOrg(this.postList1.SelectedPost.PostID))
                {
                    ShowPostOfOrg(this.sinoUC_OrgTree1.SelectedOrganize);
                }
            }
        }

        /// <summary>
        /// 显示岗位授权
        /// </summary>
        private void Show_Rights()
        {
            if (this.postList1.SelectedPost == null) return;
            Dialog_ShowPostRight _f = new Dialog_ShowPostRight(this.postList1.SelectedPost);
            _f.ShowDialog();
        }
        /// <summary>
        /// 修改岗位信息
        /// </summary>
        private void Modify_PostInfo()
        {

            if (this.postList1.SelectedPost == null) return;
            Dialog_AddPost _f = new Dialog_AddPost(this.postList1.SelectedPost);

            if (_f.ShowDialog() == DialogResult.OK)
            {
                string _postName = _f.PostName;
                string _postDescript = _f.PostDescript;
                int _PostLevel = _f.PostLevel;
                using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
                {
                    _umsc.ModifyPostOfOrg(_postName, _postDescript, _PostLevel, this.postList1.SelectedPost.PostID);
                    ShowPostOfOrg(this.sinoUC_OrgTree1.SelectedOrganize);
                }
            }
        }


        /// <summary>
        /// 取消岗位角色修改
        /// </summary>
        private void Cancel_RoleChange()
        {
            this.postRoleList1.ResetRoleDefine();
            RaiseMenuChanged();
        }
        /// <summary>
        /// 保存岗位角色修改
        /// </summary>
        private void Save_RoleChange()
        {
            this.postRoleList1.SaveRoleDefine();
            RaiseMenuChanged();
        }
        /// <summary>
        /// 复制岗位
        /// </summary>
        private void Copy_Post()
        {
            ClipPad = this.postList1.GetSelectedPosts();
            RaiseMenuChanged();
        }
        /// <summary>
        /// 粘贴岗位
        /// </summary>
        private void Paste_Post()
        {
            if (ClipPad.Count > 0)
            {
                string _msg = "";
                if (this.postList1.ExistName(ClipPad, ref _msg))
                {
                    XtraMessageBox.Show(string.Format("已经存在名称为{0}的岗位!", _msg), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
                    {
                        _umsc.PastePostToOrg(ClipPad.ToArray(), this.sinoUC_OrgTree1.SelectedOrganize);
                        ShowPostOfOrg(this.sinoUC_OrgTree1.SelectedOrganize);
                    }
                }
            }
        }


        #endregion

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            RaiseMenuChanged();
        }





    }
}