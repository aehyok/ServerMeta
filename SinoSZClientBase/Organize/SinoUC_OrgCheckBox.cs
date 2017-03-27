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
using System.Linq;

namespace SinoSZClientBase.Organize
{
    public partial class SinoUC_OrgCheckBox : DevExpress.XtraEditors.XtraUserControl
    {
        protected bool _initFinished = false;
        protected IAuthorize ics_Auth = null;

        protected List<SinoOrganize> RootList = null;

        public SinoUC_OrgCheckBox()
        {
            InitializeComponent();
        }

        #region¡¡ÊôÐÔ
        virtual public List<SinoOrganize> SelectedOrgList
        {
            get
            {
                List<SinoOrganize> _ret = new List<SinoOrganize>();
                foreach (TreeListNode _tn in this.treeList1.Nodes)
                {
                    int _st = (int)_tn.GetValue(this.treeListColumn2);
                    if (_st == 1)
                    {
                        SinoOrganize _orgSelected = _tn.Tag as SinoOrganize;
                        _ret.Add(_orgSelected);
                    }
                    AddChildSelectedNodes(_tn, _ret);
                }
                return _ret;
            }
        }


        #endregion

        #region ÊÂ¼þ

        public event EventHandler<OrgEventArgs> FocusChanged;
        virtual protected void RaiseFocusChanged(OrgEventArgs _arg)
        {
            if (FocusChanged != null && _initFinished)
            {
                FocusChanged(this, _arg);
            }
        }

        public event EventHandler<EventArgs> SelectedChanged;
        virtual protected void RaiseSelectedChanged()
        {
            if (SelectedChanged != null && _initFinished)
            {
                SelectedChanged(this, new EventArgs());
            }
        }
        #endregion

        virtual public void LoadOrgList(string _rootDwid)
        {
            this.treeList1.Nodes.Clear();
            this.treeList1.BeginUpdate();
            using (CommonService.CommonServiceClient _csc = new CommonService.CommonServiceClient())
            {
                RootList = _csc.GetRootDwList(_rootDwid, 1).ToList<SinoOrganize>();
                FindOrgByStr _finder = new FindOrgByStr(_rootDwid);
                List<SinoOrganize> olist = RootList.FindAll(new Predicate<SinoOrganize>(_finder.FindByID));
                olist.Sort(new SinoOrganizeComparer());
                foreach (SinoOrganize _dw in olist)
                {
                    TreeListNode _dwnode = treeList1.AppendNode(null, null);
                    _dwnode.SetValue(this.treeListColumn1, ShowTitle(_dw));
                    _dwnode.SetValue(this.treeListColumn2, (int)0);
                    _dwnode.ImageIndex = 1;
                    _dwnode.SelectImageIndex = 0;
                    _dwnode.Tag = _dw;
                    LoadChildNode(_dwnode, _dw);
                    _dwnode.Expanded = true;
                }
            }
            this.treeList1.EndUpdate();
            _initFinished = true;
        }

        virtual protected void LoadChildNode(TreeListNode _fathernode, SinoOrganize _fatherdw)
        {
            using (CommonService.CommonServiceClient _csc = new CommonService.CommonServiceClient())
            {
                List<SinoOrganize> childList = _csc.GetRootDwList(_fatherdw.Code.ToString(), 2).ToList<SinoOrganize>();
                FindOrgByStr _finder = new FindOrgByStr(_fatherdw.Code.ToString());
                List<SinoOrganize> olist = childList.FindAll(new Predicate<SinoOrganize>(_finder.FindByFatherID));
                olist.Sort(new SinoOrganizeComparer());
                foreach (SinoOrganize _dw in olist)
                {
                    TreeListNode _dwnode = treeList1.AppendNode(null, _fathernode);
                    _dwnode.SetValue(this.treeListColumn1, ShowTitle(_dw));
                    _dwnode.SetValue(this.treeListColumn2, (int)0);
                    _dwnode.ImageIndex = 1;
                    _dwnode.SelectImageIndex = 0;
                    _dwnode.Tag = _dw;
                    _dwnode.Expanded = false;
                    _dwnode.HasChildren = true;
                }
            }
        }

        virtual protected string ShowTitle(SinoOrganize _dw)
        {
            return _dw.Name;
        }

        private void treeList1_BeforeExpand(object sender, DevExpress.XtraTreeList.BeforeExpandEventArgs e)
        {
            TreeListNode _fnode = e.Node;
            SinoOrganize _org = _fnode.Tag as SinoOrganize;
            if (_fnode.Nodes.Count == 0 && _fnode.HasChildren)
            {
                LoadChildNode(_fnode, _org);
            }
        }

        private void treeList1_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            if (e.Node.GetValue(this.treeListColumn2) != null)
            {
                int _st = (int)e.Node.GetValue(this.treeListColumn2);
                e.NodeImageIndex = _st;
            }
        }

        private void treeList1_StateImageClick(object sender, DevExpress.XtraTreeList.NodeClickEventArgs e)
        {
            int _st = (int)e.Node.GetValue(this.treeListColumn2);

            _st += 1;
            if (_st > 1)
            {
                _st = 0;
            }
            this.treeList1.BeginUpdate();
            e.Node.SetValue(this.treeListColumn2, _st);
            this.treeList1.EndUpdate();
            RaiseSelectedChanged();
        }


        private void AddChildSelectedNodes(TreeListNode _fnodes, List<SinoOrganize> _ret)
        {
            foreach (TreeListNode _tn in _fnodes.Nodes)
            {
                int _st = (int)_tn.GetValue(this.treeListColumn2);
                if (_st == 1)
                {
                    SinoOrganize _orgSelected = _tn.Tag as SinoOrganize;
                    _ret.Add(_orgSelected);
                }
                AddChildSelectedNodes(_tn, _ret);
            }
        }
    }
}
