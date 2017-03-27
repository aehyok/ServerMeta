using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SinoSZJS.Base.Authorize;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors;
using System.Linq;

namespace SinoSZClientUser.Controls
{
    public partial class PostRoleList : UserControl
    {
        private SinoPost CurrentPost = null;
        private List<SinoRole> SysRoleList = null;
        private List<SinoRole> RoleList = null;
        private Dictionary<string, SinoRole> PostRoleDict = null;
        private bool haveDataChanged = false;
        private bool _initFinished = false;
        public PostRoleList()
        {
            InitializeComponent();
        }

        public bool HaveDataChanged
        {
            get { return haveDataChanged; }
        }

        public SinoPost Post
        {
            set
            {
                CurrentPost = value;
                InitRoleList();
            }
        }

        #region 自定义事件
        public event EventHandler<EventArgs> DataChanged;
        public void RaiseDataChanged()
        {
            if (!_initFinished) return;
            haveDataChanged = true;
            if (DataChanged != null)
            {
                DataChanged(this, new EventArgs());
            }

        }
        #endregion

        private void InitRoleList()
        {
            this.treeList1.Nodes.Clear();
            if (this.CurrentPost == null)
            {
                haveDataChanged = false;
                _initFinished = true;
                return;
            }
            using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient()) 
            {

                SysRoleList = _umsc.GetRoleList().ToList<SinoRole>();
                RoleList = _umsc.GetRoleOfPost(CurrentPost.PostID).ToList<SinoRole>();
            }
            PostRoleDict = new Dictionary<string, SinoRole>();
            foreach (SinoRole _sr in RoleList)
            {
                PostRoleDict.Add(_sr.RoleID, _sr);
            }

            foreach (SinoRole _sysRole in SysRoleList)
            {
                if (_sysRole.RoleID != "0")
                {
                    TreeListNode _tn = this.treeList1.AppendNode(null, null);
                    _tn.ImageIndex = 0;
                    _tn.SelectImageIndex = 0;
                    _tn.SetValue(this.treeListColumn1, _sysRole.RoleName);
                    if (PostRoleDict.ContainsKey(_sysRole.RoleID))
                    {
                        _tn.SetValue(this.treeListColumn2, true);
                    }
                    else
                    {
                        _tn.SetValue(this.treeListColumn2, false);
                    }
                    _tn.Tag = _sysRole;
                }
            }
            haveDataChanged = false;
            _initFinished = true;
        }

        public bool SaveRoleDefine()
        {
            using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
            {
                _umsc.SaveRolesOfPost(GetSelectedRoles().ToArray(), this.CurrentPost.PostID);
            }
            haveDataChanged = false;
            return true;
        }

        private List<SinoRole> GetSelectedRoles()
        {
            List<SinoRole> _ret = new List<SinoRole>();
            foreach (TreeListNode _tn in this.treeList1.Nodes)
            {
                if (_tn.GetValue(this.treeListColumn2) != null)
                {
                    bool _isChecked = (bool)_tn.GetValue(this.treeListColumn2);
                    if (_isChecked)
                    {
                        SinoRole _sr = _tn.Tag as SinoRole;
                        _ret.Add(_sr);
                    }
                }
            }
            return _ret;
        }

        public bool ResetRoleDefine()
        {
            InitRoleList();
            return true;
        }


        internal void Close()
        {
            if (HaveDataChanged)
            {
                DialogResult _res = XtraMessageBox.Show("当前角色授权情况有修改，是否保存？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_res == DialogResult.Yes)
                {
                    SaveRoleDefine();
                }
            }
        }

        private void treeList1_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            if (e.Node.GetValue(this.treeListColumn2) == null) return;
            bool _isChecked = (bool)e.Node.GetValue(this.treeListColumn2);
            if (_isChecked)
            {
                e.NodeImageIndex = 1;
            }
            else
            {
                e.NodeImageIndex = 0;
            }
        }

        private void treeList1_StateImageClick(object sender, DevExpress.XtraTreeList.NodeClickEventArgs e)
        {
            bool _isChecked = (bool)e.Node.GetValue(this.treeListColumn2);
            _isChecked = !_isChecked;
            e.Node.SetValue(this.treeListColumn2, _isChecked);
            RaiseDataChanged();
        }
    }
}
