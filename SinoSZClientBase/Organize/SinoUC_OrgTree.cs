using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.Authorize;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using System.Linq;
namespace SinoSZClientBase.Organize
{
    public partial class SinoUC_OrgTree : DevExpress.XtraEditors.XtraUserControl
    {
        protected bool _initFinished = false;
        protected IAuthorize ics_Auth = null;

        protected List<SinoOrganize> RootList = null;

        #region　属性
        virtual public SinoOrganize SelectedOrganize
        {
            get
            {
                if (this.treeList1.FocusedNode == null) return null;
                TreeListNode _node = this.treeList1.FocusedNode;
                SinoOrganize _org = _node.Tag as SinoOrganize;
                return _org;
            }
        }
        #endregion

        #region 事件

        public event EventHandler<OrgEventArgs> FocusChanged;
        virtual protected void RaiseFocusChanged(OrgEventArgs _arg)
        {
            if (FocusChanged != null && _initFinished)
            {
                FocusChanged(this, _arg);
            }
        }

        public event EventHandler<OrgEventArgs> DoubleClicked;
        virtual protected void RaiseDoubleClicked(OrgEventArgs _arg)
        {
            if (DoubleClicked != null && _initFinished)
            {
                DoubleClicked(this, _arg);
            }
        }
        #endregion

        public SinoUC_OrgTree()
        {
            InitializeComponent();
        }

        virtual public void LoadOrgList(string _rootDwid)
        {
            this.treeList1.Nodes.Clear();
            this.treeList1.BeginUpdate();
            using (CommonService.CommonServiceClient _csc = new CommonService.CommonServiceClient())
            {
                RootList = _csc.GetRootDwList(_rootDwid, 1).ToList<SinoOrganize>();
            }
            FindOrgByStr _finder = new FindOrgByStr(_rootDwid);
            List<SinoOrganize> olist = RootList.FindAll(new Predicate<SinoOrganize>(_finder.FindByID));
            olist.Sort(new SinoOrganizeComparer());
            foreach (SinoOrganize _dw in olist)
            {
                TreeListNode _dwnode = treeList1.AppendNode(null, null);
                _dwnode.SetValue(this.treeListColumn1, ShowTitle(_dw));
                _dwnode.ImageIndex = 1;
                _dwnode.SelectImageIndex = 0;
                _dwnode.Tag = _dw;
                LoadChildNode(_dwnode, _dw);
                _dwnode.Expanded = true;
            }
            this.treeList1.EndUpdate();
            _initFinished = true;
        }

        virtual protected void LoadChildNode(TreeListNode _fathernode, SinoOrganize _fatherdw)
        {
            List<SinoOrganize> childList;
            using (CommonService.CommonServiceClient _csc = new CommonService.CommonServiceClient())
            {
                childList = _csc.GetRootDwList(_fatherdw.Code.ToString(), 2).ToList<SinoOrganize>();
            }
            FindOrgByStr _finder = new FindOrgByStr(_fatherdw.Code.ToString());
            List<SinoOrganize> olist = childList.FindAll(new Predicate<SinoOrganize>(_finder.FindByFatherID));
            olist.Sort(new SinoOrganizeComparer());
            foreach (SinoOrganize _dw in olist)
            {
                TreeListNode _dwnode = treeList1.AppendNode(null, _fathernode);
                _dwnode.SetValue(this.treeListColumn1, ShowTitle(_dw));
                _dwnode.ImageIndex = 1;
                _dwnode.SelectImageIndex = 0;
                _dwnode.Tag = _dw;
                _dwnode.Expanded = false;
                _dwnode.HasChildren = true;
            }
        }

        virtual protected string ShowTitle(SinoOrganize _dw)
        {
            return _dw.Name;
        }

        virtual protected void treeList1_BeforeExpand(object sender, DevExpress.XtraTreeList.BeforeExpandEventArgs e)
        {
            TreeListNode _fnode = e.Node;
            SinoOrganize _org = _fnode.Tag as SinoOrganize;
            if (_fnode.Nodes.Count == 0 && _fnode.HasChildren)
            {
                LoadChildNode(_fnode, _org);
            }
        }

        virtual protected void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            TreeListNode _node = e.Node;
            SinoOrganize _org = _node.Tag as SinoOrganize;
            OrgEventArgs _ev = new OrgEventArgs(_node, _org);
            RaiseFocusChanged(_ev);
        }



        private void treeList1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeListHitInfo _cInfo = this.treeList1.CalcHitInfo(new Point(e.X, e.Y));
            if (_cInfo.Node != null)
            {
                TreeListNode _node = _cInfo.Node;
                if (_node != null && (_node.Tag is SinoOrganize))
                {
                    SinoOrganize _org = _node.Tag as SinoOrganize;
                    OrgEventArgs _ev = new OrgEventArgs(_node, _org);
                    RaiseDoubleClicked(_ev);
                }
            }

        }



        public void RefreshCurrentNode()
        {
            if (this.treeList1.FocusedNode != null)
            {
                this.treeList1.BeginUpdate();
                TreeListNode _cnode = this.treeList1.FocusedNode;
                _cnode.Nodes.Clear();
                SinoOrganize _org = _cnode.Tag as SinoOrganize;

                LoadChildNode(_cnode, _org);

                this.treeList1.EndUpdate();
            }
        }

        public void RefreshCurrentFatherNode()
        {
            if (this.treeList1.FocusedNode != null && this.treeList1.FocusedNode.ParentNode != null)
            {
                this.treeList1.BeginUpdate();
                TreeListNode _cnode = this.treeList1.FocusedNode;
                TreeListNode _fnode = _cnode.ParentNode;
                _fnode.Nodes.Clear();
                SinoOrganize _org = _fnode.Tag as SinoOrganize;

                LoadChildNode(_fnode, _org);

                this.treeList1.EndUpdate();
            }
        }
    }
}
