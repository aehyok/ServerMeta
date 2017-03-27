using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZClientBase;
using SinoSZJS.Base.SystemInterface;
using SinoSZPluginFramework;
using DevExpress.XtraTreeList.Nodes;

namespace SinoSZClientSysManager.InterfaceManager
{
        public partial class frmIM_SJJH : frmBase
        {
                private List<SystemICS_SJJH_Node> _nodeList = new List<SystemICS_SJJH_Node>();
                public frmIM_SJJH()
                {
                        InitializeComponent();
                }

                public override void Init(string _title, string _menuName, object _param)
                {
                        this.Text = _title;
                        this._menuPageName = _menuName;
                        this._initFinished = true;
                        this.panelWait.Visible = true;
                        this.backgroundWorker1.RunWorkerAsync();
                }

                private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
                {

                        //_nodeList = SinoSZSysManagerDC.SysManagerFactroy.GetSJJHNodeList();
                }

                private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
                {
                        ShowTree(_nodeList);
                        this.panelWait.Visible = false;
                        ShowSelectedItem();
                }

                private void ShowTree(List<SystemICS_SJJH_Node> _nodeList)
                {
                        this.treeList1.BeginUpdate();
                        SystemICS_SJJH_NodeFinder _finder = new SystemICS_SJJH_NodeFinder("");
                        List<SystemICS_SJJH_Node> olist = _nodeList.FindAll(new Predicate<SystemICS_SJJH_Node>(_finder.FindByFatherID));
                        olist.Sort(new SystemICS_SJJH_NodeComparer());
                        foreach (SystemICS_SJJH_Node _dw in olist)
                        {
                                TreeListNode _dwnode = treeList1.AppendNode(null, null);
                                _dwnode.SetValue(this.treeListColumn1, _dw.DisplayName);
                                _dwnode.ImageIndex = (_dw.LX == "用户") ? 2 : 1;
                                _dwnode.SelectImageIndex = (_dw.LX == "用户") ? 2 : 1;
                                _dwnode.Tag = _dw;
                                LoadChildNode(_dwnode, _dw, _nodeList);
                                _dwnode.Expanded = true;
                        }
                        this.treeList1.EndUpdate();

                }

                private void LoadChildNode(TreeListNode _fnode, SystemICS_SJJH_Node _fdw, List<SystemICS_SJJH_Node> _nodeList)
                {
                        SystemICS_SJJH_NodeFinder _finder = new SystemICS_SJJH_NodeFinder(_fdw.ID);
                        List<SystemICS_SJJH_Node> olist = _nodeList.FindAll(new Predicate<SystemICS_SJJH_Node>(_finder.FindByFatherID));
                        olist.Sort(new SystemICS_SJJH_NodeComparer());
                        foreach (SystemICS_SJJH_Node _dw in olist)
                        {
                                TreeListNode _dwnode = treeList1.AppendNode(null, _fnode);
                                _dwnode.SetValue(this.treeListColumn1, _dw.DisplayName);
                                _dwnode.ImageIndex = (_dw.LX == "用户") ? 2 : 1;
                                _dwnode.SelectImageIndex = (_dw.LX == "用户") ? 2 : 1; ;
                                _dwnode.Tag = _dw;
                                LoadChildNode(_dwnode, _dw, _nodeList);
                                _dwnode.Expanded = true;
                        }
                }

                private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
                {
                        ShowSelectedItem();
                }

                public bool HaveSelected
                {
                        get
                        {
                                if (_nodeList.Count == 0 || this.treeList1.FocusedNode == null)
                                {
                                        return false;
                                }
                                if (this.treeList1.FocusedNode.Tag == null) return false;
                                SystemICS_SJJH_Node _node = this.treeList1.FocusedNode.Tag as SystemICS_SJJH_Node;

                                return _node.LX == "用户";
                        }
                }
                private void ShowSelectedItem()
                {
                        if (!HaveSelected)
                        {
                                ClearInfo();
                                return;
                        }

                        SystemICS_SJJH_Node _selectNode = this.treeList1.FocusedNode.Tag as SystemICS_SJJH_Node;

                        this.imuC_SJJH_DataDefine1.ShowInfo(_selectNode);
                        this.imuC_SJJH_AccessLog1.ShowInfo(_selectNode);
                        this.imuC_SJJH_InterfaceInfo1.ShowInfo(_selectNode);
                        RaiseMenuChanged();
                }

                private void ClearInfo()
                {
                        this.imuC_SJJH_DataDefine1.Clear();
                        this.imuC_SJJH_AccessLog1.Clear();
                        this.imuC_SJJH_InterfaceInfo1.Clear();
                }

                #region 重载基类的方法

                protected override IList<FrmMenuGroup> GetMenuGroups(string _pagename)
                {
                        IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();

                        FrmMenuGroup _thisGroup = new FrmMenuGroup("接口管理");
                        _thisGroup.MenuItems = new List<FrmMenuItem>();
                        FrmMenuItem _item = new FrmMenuItem("修改密码", "修改密码", global::SinoSZClientSysManager.Properties.Resources.x3, HaveSelected);
                        _thisGroup.MenuItems.Add(_item);
                        _ret.Add(_thisGroup);

                        return _ret;
                }

                protected override bool ExcuteCommand(string _cmdName)
                {
                        switch (_cmdName)
                        {
                                case "修改密码":

                                        break;
                        }
                        return true;
                }

                #endregion

                private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
                {
                        ShowSelectedItem();
                }
        }
}