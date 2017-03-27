using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.Authorize;
using SinoSZClientUser.TreeObject;
using SinoSZJS.Base.User;
using SinoSZJS.Base.User.Finder;
using SinoSZJS.Base.User.Comparer;
using System.Linq;

namespace SinoSZClientUser.PostManager
{
    public partial class Dialog_ShowPostRight : DevExpress.XtraEditors.XtraForm
    {
        private SinoPost CurrentPost = null;
        public Dialog_ShowPostRight()
        {
            InitializeComponent();
        }

        public Dialog_ShowPostRight(SinoPost _post)
        {
            InitializeComponent();
            CurrentPost = _post;
            InitForm();
        }

        private void InitForm()
        {
            InitRigtTree();
            InitQueryViewRightTree();
        }

        private void InitQueryViewRightTree()
        {
            if (CurrentPost != null)
            {
                using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
                {
                    List<UserQueryModelInfo> _qvRightList = _umsc.GetModelRightListByPostID(CurrentPost.PostID).ToList<UserQueryModelInfo>();
                    TObj_ModelRightList _qvRights = new TObj_ModelRightList();
                    foreach (UserQueryModelInfo _qmRight in _qvRightList)
                    {
                        TObj_ModelRightItem _ritem = new TObj_ModelRightItem(_qmRight);
                        _qvRights.Add(_ritem);
                    }
                    this.treeList3.BeginUpdate();
                    this.treeList3.DataSource = _qvRights;
                    this.treeList3.EndUpdate();
                }
            }
        }

        private void InitRigtTree()
        {
            if (CurrentPost != null)
            {
                using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
                {
                    List<UserRightInfo> _rightList = _umsc.GetRightListByPostID(CurrentPost.PostID).ToList<UserRightInfo>();
                    UserRightFinder _finder = new UserRightFinder("-1");
                    List<UserRightInfo> _TopRightList = _rightList.FindAll(new Predicate<UserRightInfo>(_finder.FindByFatherID));
                    _TopRightList.Sort(new UserRightInfoComparer());
                    TObj_RightItemList RightList = new TObj_RightItemList();
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
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
    }
}