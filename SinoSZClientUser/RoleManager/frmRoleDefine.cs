using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZPluginFramework;
using SinoSZJS.Base.Authorize;
using DevExpress.XtraTreeList.Nodes;
using SinoSZJS.Base.Misc;
using System.Linq;

namespace SinoSZClientUser.RoleManager
{
    public partial class frmRoleDefine : DevExpress.XtraEditors.XtraForm, IChildForm
    {
        private IApplication _application = null;
        private bool _initFinished = false;
        private List<SinoRole> RoleList = new List<SinoRole>();
        private SinoSZUC_RoleInfo CurrentRoleInfo = null;
        private List<string> CanUseQueryModelNames = new List<string>();

        private string Param = "";
        public frmRoleDefine()
        {
            InitializeComponent();
        }

        public frmRoleDefine(string _param)
        {
            InitializeComponent();
            Param = _param;
            string qvs = StrUtils.GetMetaByName2("查询模型", _param).Trim();
            if (qvs != "")
            {
                CanUseQueryModelNames.Clear();
                foreach (string _s in qvs.Split(','))
                {
                    CanUseQueryModelNames.Add(_s);
                }
            }
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
            FrmMenuPage _page = new FrmMenuPage("角色管理");
            _page.MenuGroups = GetMenuGroups(_page.PageTitle);
            _ret.Add(_page);
            return _ret;
        }

        private IList<FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();

            FrmMenuGroup _thisGroup = new FrmMenuGroup("角色管理功能");

            _thisGroup.MenuItems = new List<FrmMenuItem>();
            FrmMenuItem _item = new FrmMenuItem("添加角色", "添加角色", global::SinoSZClientUser.Properties.Resources.e2, true);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("删除角色", "删除角色", global::SinoSZClientUser.Properties.Resources.e3, (this.CurrentRoleInfo != null));
            _thisGroup.MenuItems.Add(_item);

            _ret.Add(_thisGroup);

            _thisGroup = new FrmMenuGroup("保存修改");

            bool _haveChange = (this.CurrentRoleInfo == null) ? false : this.CurrentRoleInfo.HaveChanged;
            _thisGroup.MenuItems = new List<FrmMenuItem>();
            _item = new FrmMenuItem("保存授权", "保存授权", global::SinoSZClientUser.Properties.Resources.xx, _haveChange);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("取消修改", "取消修改", global::SinoSZClientUser.Properties.Resources.x1, _haveChange);
            _thisGroup.MenuItems.Add(_item);

            _ret.Add(_thisGroup);
            return _ret;
        }


        public bool DoCommand(string _cmdName)
        {
            switch (_cmdName)
            {
                case "添加角色":
                    if (!AddNewRole())
                    {
                        return false;
                    }
                    break;
                case "删除角色":
                    if (!DelRole())
                    {
                        return false;
                    }
                    break;
                case "保存授权":
                    if (CurrentRoleInfo != null)
                    {
                        CurrentRoleInfo.SaveData();
                    }
                    break;
                case "取消修改":
                    if (CurrentRoleInfo != null) CurrentRoleInfo.ResetData();
                    break;

            }
            this.RaiseMenuChanged();
            return true;
        }




        #endregion

        #region 事件处理
        private void frmRoleDefine_Load(object sender, EventArgs e)
        {
            this._initFinished = true;
            InitRoleList();
        }


        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            TreeListNode _node = e.Node;
            if (_node != null)
            {
                SinoRole _sr = _node.Tag as SinoRole;
                ShowRoleData(_sr, _node);
            }
        }



        #endregion

        #region 私有方法
        /// <summary>
        /// 取角色列表
        /// </summary>
        private void InitRoleList()
        {
            this.treeList1.BeginUpdate();
            this.treeList1.Nodes.Clear();
            using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
            {
                RoleList = _umsc.GetRoleList().ToList<SinoRole>();
            }
            foreach (SinoRole _sr in RoleList)
            {
                TreeListNode _tn = this.treeList1.AppendNode(null, null);
                _tn.ImageIndex = 0;
                _tn.SelectImageIndex = 0;
                _tn.SetValue(this.treeListColumn1, _sr.RoleName);
                _tn.Tag = _sr;
            }
            this.treeList1.EndUpdate();
            TreeListNode _node = this.treeList1.FocusedNode;
            if (_node != null)
            {
                SinoRole _role = _node.Tag as SinoRole;
                ShowRoleData(_role, _node);
            }

        }
        /// <summary>
        /// 添加新角色
        /// </summary>
        /// <returns></returns>
        private bool AddNewRole()
        {
            Dialog_AddRole _ar = new Dialog_AddRole();
            if (_ar.ShowDialog() == DialogResult.OK)
            {
                SinoRole _newRole = new SinoRole();
                _newRole.RoleID = "";
                _newRole.RoleName = _ar.RoleName;
                _newRole.Descript = _ar.RoleDes;
                using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
                {
                    if (_umsc.AddNewRole(_newRole))
                    {
                        InitRoleList();
                        return true;
                    }
                }

            }
            return false;
        }


        private bool DelRole()
        {
            if (this.CurrentRoleInfo != null)
            {
                if (this.CurrentRoleInfo.DelRole())
                {
                    InitRoleList();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// 数据变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _uc_DataChanged(object sender, EventArgs e)
        {
            this.RaiseMenuChanged();
        }

        private void ShowRoleData(SinoRole _sr, TreeListNode _node)
        {
            if (CurrentRoleInfo != null)
            {
                if (CurrentRoleInfo.HaveChanged)
                {
                    string _msg = String.Format("角色{0}的信息有修改,是否保存?", CurrentRoleInfo.Role.RoleName);
                    DialogResult _rs = XtraMessageBox.Show(_msg, "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (_rs == DialogResult.Yes)
                    {
                        CurrentRoleInfo.SaveData();
                    }
                }
            }
            CurrentRoleInfo = null;
            if (_sr != null)
            {
                SinoSZUC_RoleInfo _uc = new SinoSZUC_RoleInfo(_sr, _node, CanUseQueryModelNames);
                _uc.Dock = DockStyle.Fill;
                _uc.DataChanged += new EventHandler<EventArgs>(_uc_DataChanged);
                this.splitContainerControl1.Panel2.Controls.Clear();
                this.splitContainerControl1.Panel2.Controls.Add(_uc);
                _uc.BringToFront();
                CurrentRoleInfo = _uc;

            }
            this.RaiseMenuChanged();
        }
        #endregion

    }
}