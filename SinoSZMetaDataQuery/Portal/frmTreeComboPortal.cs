using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZPluginFramework;
using SinoSZClientBase;
using SinoSZJS.Base.Misc;
using SinoSZClientBase.PortalItem;
using DevExpress.XtraTreeList.Nodes;

namespace SinoSZMetaDataQuery.Portal
{
        public partial class frmTreeComboPortal : frmBase
        {
                protected string Param = "";
                protected FrmMenuItem CurrentMenuItem = null;
                protected UC_PortalShow CurrentPortalItem = null;
                protected List<PortalItemDefine> Items = new List<PortalItemDefine>();

                public frmTreeComboPortal()
                {
                        InitializeComponent();
                }

                #region 重载基类的方法

                protected override IList<FrmMenuGroup> GetMenuGroups(string _pagename)
                {
                        if (this.CurrentPortalItem != null)
                        {
                                return this.CurrentPortalItem.GetMenuGroups();
                        }
                        return new List<FrmMenuGroup>();
                }

                protected override bool ExcuteCommand(string _cmdName)
                {

                        if (this.CurrentPortalItem != null)
                        {
                                if (this.CurrentPortalItem.ExcuteCommand(_cmdName))
                                {
                                        RaiseMenuChanged();
                                }
                        }
                        return false;
                }




                #endregion

                public override void Init(string _title, string _menuName, object _param)
                {
                        Param = (string)_param;
                       
                        this.Text = StrUtils.GetMetaByName2("标题", Param);
                        InitTree();
                        AutoShowFirst();
                        _initFinished = true;
                        RaiseMenuChanged();
                }

                private void AutoShowFirst()
                {
                        if (treeList1.Nodes.Count > 0)
                        {
                                TreeListNode _firstNode = treeList1.Nodes[0];
                                if (_firstNode.Nodes.Count > 0)
                                {
                                        ShowNodeData(_firstNode.Nodes[0]);
                                }
                        }
                }

                private void InitTree()
                {
                        treeList1.BeginUpdate();
                        treeList1.Nodes.Clear();
                        FrmMenuItem _md = MenuService.LastClickMenu;

                        foreach (FrmMenuItem _fi in _md.ChildMenus)
                        {
                                TreeListNode _node = treeList1.AppendNode(null, null);
                                _node.SetValue(this.treeListColumn1, _fi.MenuTitle);
                                _node.Tag = _fi;
                                _node.ImageIndex = 2;
                                AddSubMenu(_node, _fi);
                                _node.ExpandAll();
                        }
                        treeList1.EndUpdate();
                }

                private void AddSubMenu(TreeListNode _fnode, FrmMenuItem _fMenu)
                {
                        foreach (FrmMenuItem _fi in _fMenu.ChildMenus)
                        {
                                TreeListNode _node = treeList1.AppendNode(null, _fnode);
                                _node.SetValue(this.treeListColumn1, _fi.MenuTitle);
                                _node.Tag = _fi;
                                _node.ImageIndex = 1;
                                AddSubMenu(_node, _fi);
                        }
                }

                private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
                {
                        if (!_initFinished) return;
                        //改变项目后
                        TreeListNode _tn = e.Node;
                        ShowNodeData(_tn);
                }

                private void ShowNodeData(TreeListNode _tn)
                {
                        if (_tn.Tag is FrmMenuItem)
                        {
                                FrmMenuItem _fmi = _tn.Tag as FrmMenuItem;
                                if (!_fmi.Equals(CurrentMenuItem))
                                {
                                        if (_fmi.MenuCommand != null)
                                        {
                                                MenuCommandDefine _mcd = _fmi.MenuCommand;
                                                CurrentMenuItem = _fmi;
                                                UC_PortalShow _up = new UC_PortalShow(_mcd.CommandParam as string, this.Application, false);
                                                CurrentPortalItem = _up;
                                                _up.Dock = DockStyle.Fill;
                                                this.splitContainerControl1.Panel2.Controls.Clear();
                                                this.splitContainerControl1.Panel2.Controls.Add(_up);
                                        }
                                        RaiseMenuChanged();
                                }
                        }
                }

                private void frmTreeComboPortal_Load(object sender, EventArgs e)
                {

                }
        }
}