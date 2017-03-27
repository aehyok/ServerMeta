using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SinoSZJS.Base.Authorize;
using SinoSZClientUser.TreeObject;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors;
using SinoSZJS.Base.User;
using SinoSZJS.Base.User.Finder;
using SinoSZJS.Base.User.Comparer;
using System.Linq;

namespace SinoSZClientUser.RoleManager
{
    public partial class SinoSZUC_RoleInfo : UserControl
    {
        private SinoRole RoleDefine = null;
        private bool haveChange = false;
        private TObj_RightItemList RightList = null;
        private TreeListNode RoleNode = null;
        private List<string> CanUseQueryModelNames = new List<string>();
        /// <summary>
        /// 角色
        /// </summary>
        public SinoRole Role
        {
            get { return RoleDefine; }
            set { RoleDefine = value; }
        }
        /// <summary>
        /// 是否有数据修改
        /// </summary>
        public bool HaveChanged
        {
            get { return haveChange; }
            set { haveChange = value; }
        }

        public SinoSZUC_RoleInfo()
        {
            InitializeComponent();
        }

        public SinoSZUC_RoleInfo(SinoRole _role, TreeListNode _treeNode, List<string> canUseQueryModelNames)
        {
            InitializeComponent();
            RoleDefine = _role;
            RoleNode = _treeNode;
            CanUseQueryModelNames = canUseQueryModelNames;
            InitForm();
        }

        private void InitForm()
        {
            this.textEdit1.EditValue = RoleDefine.RoleName;
            this.textEdit2.EditValue = RoleDefine.Descript;
            InitRigtTree(RoleDefine);
            InitQueryViewRightTree(RoleDefine);
            haveChange = false;
        }

        private void InitQueryViewRightTree(SinoRole _sr)
        {
            using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
            {
                List<UserQueryModelInfo> _qvRightList = _umsc.GetModelRightListByRoleID(_sr.RoleID).ToList<UserQueryModelInfo>();
                TObj_ModelRightList _qvRights = new TObj_ModelRightList();
                foreach (UserQueryModelInfo _qmRight in _qvRightList)
                {

                    string _qvname = string.Format("{0}.{1}", _qmRight.QueryModelNamespace, _qmRight.QueryModelName);
                    if (this.CanUseQueryModelNames.Contains(_qvname))
                    {
                        TObj_ModelRightItem _ritem = new TObj_ModelRightItem(_qmRight);
                        _qvRights.Add(_ritem);
                    }
                }
                this.treeList3.BeginUpdate();
                this.treeList3.DataSource = _qvRights;
                this.treeList3.EndUpdate();
            }
        }

        private void InitRigtTree(SinoRole _sr)
        {
            if (_sr != null)
            {
                using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
                {
                    List<UserRightInfo> _rightList = _umsc.GetRightListByRoleID(_sr.RoleID).ToList<UserRightInfo>();
                    UserRightFinder _finder = new UserRightFinder("-1");
                    List<UserRightInfo> _TopRightList = _rightList.FindAll(new Predicate<UserRightInfo>(_finder.FindByFatherID));
                    _TopRightList.Sort(new UserRightInfoComparer());
                    RightList = new TObj_RightItemList();
                    foreach (UserRightInfo _ri in _TopRightList)
                    {
                        TObj_RightItem _ritem = new TObj_RightItem(_ri);
                        RightList.Add(_ritem);
                        AddChildrenRightItem(_ritem, _rightList);
                    }
                    this.treeList2.BeginUpdate();
                    this.treeList2.DataSource = RightList;
                    this.treeList2.ExpandAll();
                    this.treeList2.EndUpdate();
                }
            }
        }

        private void AddChildrenRightItem(TObj_RightItem _fitem, List<UserRightInfo> _rightList)
        {
            UserRightFinder _finder = new UserRightFinder(_fitem.ID);
            List<UserRightInfo> _ChildRightList = _rightList.FindAll(new Predicate<UserRightInfo>(_finder.FindByFatherID));
            _ChildRightList.Sort(new UserRightInfoComparer());
            foreach (UserRightInfo _ri in _ChildRightList)
            {
                TObj_RightItem _ritem = new TObj_RightItem(_ri);
                _fitem.Children.Add(_ritem);
                AddChildrenRightItem(_ritem, _rightList);
            }
        }



        public void SaveData()
        {
            this.RoleDefine.RoleName = this.textEdit1.EditValue.ToString();
            this.RoleDefine.Descript = this.textEdit2.EditValue.ToString();
            List<UserRightInfo> _functionRights = GetSelectedFunctionRights();
            List<UserQueryModelInfo> _modelRights = GetSelectedModelRights();
            using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
            {
                if (_umsc.SaveRightsOfRole(this.RoleDefine, _functionRights.ToArray(), _modelRights.ToArray()))
                {
                    this.RoleNode.SetValue(this.RoleNode.TreeList.Columns[0], this.RoleDefine.RoleName);
                    haveChange = false;
                }
            }

        }

        public bool DelRole()
        {
            string _msg = string.Format("请确认是否要删除角色:{0}?", this.RoleDefine.RoleName);

            DialogResult _res = XtraMessageBox.Show(_msg, "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (_res == DialogResult.Yes)
            {
                using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
                {
                    return _umsc.DeleteRole(this.RoleDefine);
                }
            }
            return false;
        }

        private List<UserQueryModelInfo> GetSelectedModelRights()
        {
            List<UserQueryModelInfo> _ret = new List<UserQueryModelInfo>();
            foreach (TreeListNode _node in this.treeList3.Nodes)
            {
                TObj_ModelRightItem _ritem = treeList3.GetDataRecordByNode(_node) as TObj_ModelRightItem;
                if (_ritem.HaveRight)
                {
                    _ret.Add(_ritem.Data);
                }
            }
            return _ret;
        }

        /// <summary>
        /// 取用户选择的所有功能权限
        /// </summary>
        /// <returns></returns>
        private List<UserRightInfo> GetSelectedFunctionRights()
        {
            List<UserRightInfo> _ret = new List<UserRightInfo>();

            foreach (TreeListNode _node in this.treeList2.Nodes)
            {
                TObj_RightItem _ritem = treeList2.GetDataRecordByNode(_node) as TObj_RightItem;
                if (_ritem.HaveRight)
                {
                    _ret.Add(_ritem.Data);
                }
                GetSelectedChildren(_node, _ret);
            }
            return _ret;
        }

        private void GetSelectedChildren(TreeListNode _fnode, List<UserRightInfo> _ret)
        {
            foreach (TreeListNode _node in _fnode.Nodes)
            {
                TObj_RightItem _ritem = treeList2.GetDataRecordByNode(_node) as TObj_RightItem;
                if (_ritem.HaveRight)
                {
                    _ret.Add(_ritem.Data);
                }
                GetSelectedChildren(_node, _ret);
            }
        }

        public void ResetData()
        {
            InitForm();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            RaiseDataChanged();
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            RaiseDataChanged();
        }

        public event EventHandler<EventArgs> DataChanged;
        public void RaiseDataChanged()
        {
            haveChange = true;
            if (DataChanged != null)
            {
                DataChanged(this, new EventArgs());
            }

        }

        private void treeList2_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            bool _st = (bool)e.Node.GetValue("HaveRight");
            if (_st)
            {
                e.NodeImageIndex = 2;
            }
            else
            {
                e.NodeImageIndex = 0;
            }
        }

        private void treeList2_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {
            if (e.Node.Level < 1)
            {
                e.NodeImageIndex = 0;
            }
            else
            {
                e.NodeImageIndex = 1;
            }
        }

        private void treeList2_StateImageClick(object sender, DevExpress.XtraTreeList.NodeClickEventArgs e)
        {
            bool _st = (bool)e.Node.GetValue("HaveRight");
            _st = !_st;
            e.Node.SetValue("HaveRight", _st);
            RaiseDataChanged();
        }

        private void treeList3_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {
            e.NodeImageIndex = 1;
        }

        private void treeList3_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            bool _st = (bool)e.Node.GetValue("HaveRight");
            if (_st)
            {
                e.NodeImageIndex = 2;
            }
            else
            {
                e.NodeImageIndex = 0;
            }
        }

        private void treeList3_StateImageClick(object sender, DevExpress.XtraTreeList.NodeClickEventArgs e)
        {
            bool _st = (bool)e.Node.GetValue("HaveRight");
            _st = !_st;
            e.Node.SetValue("HaveRight", _st);
            RaiseDataChanged();
        }




    }
}
