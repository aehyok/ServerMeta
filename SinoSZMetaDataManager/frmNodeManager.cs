using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;


using DevExpress.XtraTreeList.Nodes;
using SinoSZPluginFramework;
using SinoSZMetaDataManager.QueryModelEditor;
using System.Linq;
using SinoSZJS.Base.MetaData.Define;
using SinoSZJS.Base.MetaData.EnumDefine;
using SinoSZClientBase.MetaDataService;

namespace SinoSZMetaDataManager
{
    public partial class frmNodeManager : DevExpress.XtraEditors.XtraForm, IChildForm
    {
        private IApplication _application = null;
        private bool _initFinished = false;


        public frmNodeManager()
        {
            InitializeComponent();
            InitNodes();
            InitConcept();
        }

        private void InitConcept()
        {
            try
            {
                TreeListNode _fnode = treeList1.AppendNode(null, null);
                _fnode.ImageIndex = 1;
                _fnode.SelectImageIndex = 0;
                MD_Title _conceptTitle = new MD_Title("概念标签定义", "MD_CONCEPTGROUP");
                _fnode.SetValue(this.treeListColumn1, _conceptTitle);
                _fnode.HasChildren = true;
                InitConceptGroup(_fnode);
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(string.Format("发生错误:{0}", e.Message), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw e;
            }
        }

        private void InitView2GuideLine(TreeListNode _fnode, MD_QueryModel _qm)
        {
            IList<MD_View_GuideLine> _vgList;
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                _vgList = _mdc.GetView2GuideLineList(_qm.QueryModelID);
            }
            foreach (MD_View_GuideLine _gl in _vgList)
            {
                TreeListNode _node = treeList1.AppendNode(null, _fnode);
                _node.ImageIndex = 1;
                _node.SelectImageIndex = 0;
                _node.SetValue(this.treeListColumn1, _gl);
                _node.HasChildren = true;
            }
        }

        private void InitView2Application(TreeListNode _fnode, MD_QueryModel _qm)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                List<MD_View2App> _vgList = _mdc.GetView2ApplicationList(_qm.QueryModelID).ToList<MD_View2App>();
                foreach (MD_View2App _gl in _vgList)
                {
                    TreeListNode _node = treeList1.AppendNode(null, _fnode);
                    _node.ImageIndex = 2;
                    _node.SelectImageIndex = 0;
                    _node.SetValue(this.treeListColumn1, _gl);
                    _node.HasChildren = false;
                }
            }
        }

        private void InitViewExRight(TreeListNode _fnode, MD_QueryModel _qm)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                IList<MD_QueryModel_ExRight> _erList = _mdc.GetQueryModelExRights(_qm.QueryModelID, "0");
                foreach (MD_QueryModel_ExRight _right in _erList)
                {
                    TreeListNode _node = treeList1.AppendNode(null, _fnode);
                    _node.ImageIndex = 1;
                    _node.SelectImageIndex = 0;
                    _node.SetValue(this.treeListColumn1, _right);
                    _node.HasChildren = true;
                }
            }
        }

        private void InitConceptGroup(TreeListNode _fnode)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                IList<MD_ConceptGroup> _groups = _mdc.GetConceptGroups();
                foreach (MD_ConceptGroup _group in _groups)
                {
                    TreeListNode _node = treeList1.AppendNode(null, _fnode);
                    _node.ImageIndex = 1;
                    _node.SelectImageIndex = 0;

                    _node.SetValue(this.treeListColumn1, _group);
                    _node.HasChildren = true;
                    foreach (MD_ConceptItem _item in _group.Items)
                    {
                        TreeListNode _cnode = treeList1.AppendNode(null, _node);
                        _cnode.ImageIndex = 1;
                        _cnode.SelectImageIndex = 0;
                        _cnode.SetValue(this.treeListColumn1, _item);
                        _cnode.HasChildren = false;
                    }
                }
            }
        }
        private void InitNodes()
        {
            try
            {
                treeList1.Nodes.Clear();
                using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
                {
                    IList<MD_Nodes> _nodes = _mdc.GetNodeList();
                    foreach (MD_Nodes _node in _nodes)
                    {
                        TreeListNode _fnode = treeList1.AppendNode(null, null);
                        _fnode.ImageIndex = 1;
                        _fnode.SelectImageIndex = 0;
                        _fnode.SetValue(this.treeListColumn1, _node);
                        _fnode.HasChildren = true;
                    }
                    ShowNodeData(treeList1.FocusedNode);
                }
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(string.Format("发生错误:{0}", e.Message), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw e;
            }

        }


        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            TreeListNode _fnode = e.Node;
            ShowNodeData(_fnode);
            RaiseMenuChanged();
        }

        private void treeList1_BeforeExpand(object sender, DevExpress.XtraTreeList.BeforeExpandEventArgs e)
        {
            TreeListNode _fnode = e.Node;
            object _value = _fnode.GetValue(this.treeListColumn1);
            if (_fnode.Nodes.Count == 0 && _fnode.HasChildren)
            {
                LoadChildData(_fnode, _value);
            }
        }

        #region 加载子内容
        private void LoadChildData(TreeListNode _fnode, object _value)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                MD_Title _mt;
                MD_Namespace _ns;
                if (_value is MD_Nodes)
                {
                    _fnode.Nodes.Clear();
                    MD_Nodes _node = _value as MD_Nodes;

                    IList<MD_Namespace> _namespaces = _mdc.GetNameSpaceAtNode(_node.DWDM);
                    if (_node.NameSpaces == null) _node.NameSpaces = new List<MD_Namespace>();
                    foreach (MD_Namespace _space in _namespaces)
                    {
                        TreeListNode _newnode = treeList1.AppendNode(null, _fnode);
                        _newnode.SetValue(this.treeListColumn1, _space);
                        _newnode.ImageIndex = 1;
                        _newnode.SelectImageIndex = 0;
                        _newnode.HasChildren = true;
                        _node.NameSpaces.Add(_space);
                    }

                    _mt = new MD_Title("菜单定义", "MD_MENU", _node);
                    TreeListNode _newnode2 = treeList1.AppendNode(null, _fnode);
                    _newnode2.SetValue(this.treeListColumn1, _mt);
                    _newnode2.ImageIndex = 1;
                    _newnode2.SelectImageIndex = 0;
                    _newnode2.HasChildren = true;
                }

                if (_value is MD_Namespace)
                {
                    _fnode.Nodes.Clear();
                    _ns = _value as MD_Namespace;
                    _mt = new MD_Title("数据表", "MD_TABLE", _ns);
                    TreeListNode _newnode = treeList1.AppendNode(null, _fnode);
                    _newnode.SetValue(this.treeListColumn1, _mt);
                    _newnode.ImageIndex = 1;
                    _newnode.SelectImageIndex = 0;
                    _newnode.HasChildren = true;

                    _mt = new MD_Title("查询模型", "MD_QUERYMODEL", _ns);
                    _newnode = treeList1.AppendNode(null, _fnode);
                    _newnode.ImageIndex = 1;
                    _newnode.SelectImageIndex = 0;
                    _newnode.SetValue(this.treeListColumn1, _mt);
                    _newnode.HasChildren = true;

                    _mt = new MD_Title("代码表", "MD_REFTABLE", _ns);
                    _newnode = treeList1.AppendNode(null, _fnode);
                    _newnode.ImageIndex = 1;
                    _newnode.SelectImageIndex = 0;
                    _newnode.SetValue(this.treeListColumn1, _mt);
                    _newnode.HasChildren = true;

                }

                if (_value is MD_Title)
                {
                    _fnode.Nodes.Clear();
                    MD_Title _mdtitle = _value as MD_Title;

                    switch (_mdtitle.TitleType)
                    {
                        case "MD_TABLE":
                            _ns = (MD_Namespace)_mdtitle.FatherObj;
                            IList<MD_Table> _tables = _mdc.GetTablesAtNamespace(_ns.NameSpace);
                            if (_ns.TableList == null) _ns.TableList = new List<MD_Table>();

                            foreach (MD_Table _tb in _tables)
                            {
                                TreeListNode _newnode = treeList1.AppendNode(null, _fnode);
                                _newnode.SetValue(this.treeListColumn1, _tb);
                                _newnode.HasChildren = true;
                                _newnode.ImageIndex = 2;
                                _newnode.SelectImageIndex = 0;
                                _ns.TableList.Add(_tb);
                                _tb.NamespaceName = _ns.NameSpace;
                            }
                            break;
                        case "MD_QUERYMODEL":
                            _ns = (MD_Namespace)_mdtitle.FatherObj;
                            IList<MD_QueryModel> _models = _mdc.GetQueryModelAtNamespace(_ns.NameSpace);
                            if (_ns.QueryModelList == null) _ns.QueryModelList = new List<MD_QueryModel>();
                            foreach (MD_QueryModel _model in _models)
                            {
                                TreeListNode _newnode = treeList1.AppendNode(null, _fnode);
                                _newnode.SetValue(this.treeListColumn1, _model);
                                _newnode.ImageIndex = 1;
                                _newnode.SelectImageIndex = 0;
                                _newnode.HasChildren = true;
                                _ns.QueryModelList.Add(_model);
                                _model.Namespace = _ns;
                            }
                            break;

                        case "MD_REFTABLE":
                            _ns = (MD_Namespace)_mdtitle.FatherObj;
                            IList<MD_RefTable> _refTables = _mdc.GetRefTableAtNamespace(_ns.NameSpace);
                            if (_ns.RefTableList == null) _ns.RefTableList = new List<MD_RefTable>();
                            foreach (MD_RefTable _rt in _refTables)
                            {
                                TreeListNode _newnode = treeList1.AppendNode(null, _fnode);
                                _newnode.SetValue(this.treeListColumn1, _rt);
                                _newnode.ImageIndex = 2;
                                _newnode.SelectImageIndex = 0;
                                _newnode.HasChildren = false;
                                _ns.RefTableList.Add(_rt);
                                _rt.Namespace = _ns;
                            }
                            break;

                        case "MD_MENU":
                            MD_Nodes _node = (MD_Nodes)_mdtitle.FatherObj;
                            IList<MD_Menu> _menuTable = _mdc.GetMenuDefineOfNode(_node.DWDM);
                            foreach (MD_Menu _menu in _menuTable)
                            {
                                TreeListNode _newnode = treeList1.AppendNode(null, _fnode);
                                _newnode.SetValue(this.treeListColumn1, _menu);

                                if (_menu.MenuType.Length > 3 && _menu.MenuType.Substring(0, 3) == "WEB")
                                {
                                    _newnode.ImageIndex = 4;
                                    _newnode.SelectImageIndex = 0;
                                }
                                else if (_menu.MenuType.Length > 3 && _menu.MenuType.Substring(0, 3) == "SL_")
                                {
                                    _newnode.ImageIndex = 5;
                                    _newnode.SelectImageIndex = 0;
                                }
                                else
                                {
                                    _newnode.ImageIndex = 2;
                                    _newnode.SelectImageIndex = 0;
                                }
                                _newnode.HasChildren = true;
                                _menu.NodeID = _node.ID;
                                _menu.MD_Nodes = _node;
                            }
                            break;

                        case "MD_CONCEPTGROUP":
                            InitConceptGroup(_fnode);
                            break;

                        case "MD_VIEW_GUIDELINE":
                            InitView2GuideLine(_fnode, (MD_QueryModel)_mdtitle.FatherObj);
                            break;
                        case "MD_VIEW_APPLICATION":
                            InitView2Application(_fnode, (MD_QueryModel)_mdtitle.FatherObj);
                            break;
                        case "MD_VIEW_EXRIGHT":
                            InitViewExRight(_fnode, (MD_QueryModel)_mdtitle.FatherObj);
                            break;
                    }
                }

                if (_value is MD_QueryModel_ExRight)
                {
                    _fnode.Nodes.Clear();
                    MD_QueryModel_ExRight _fright = _value as MD_QueryModel_ExRight;
                    IList<MD_QueryModel_ExRight> _erList = _mdc.GetQueryModelExRights(_fright.ModelID, _fright.ID);
                    foreach (MD_QueryModel_ExRight _right in _erList)
                    {
                        TreeListNode _node = treeList1.AppendNode(null, _fnode);
                        _node.ImageIndex = 1;
                        _node.SelectImageIndex = 0;
                        _node.SetValue(this.treeListColumn1, _right);
                        _node.HasChildren = true;
                    }
                }

                if (_value is MD_QueryModel)
                {
                    _fnode.Nodes.Clear();
                    MD_QueryModel _qm = _value as MD_QueryModel;
                    MD_ViewTable _mainTable = _mdc.GetMainTableOfQueryModel(_qm.QueryModelID);
                    if (_mainTable != null)
                    {
                        TreeListNode _newnode = treeList1.AppendNode(null, _fnode);
                        _newnode.SetValue(this.treeListColumn1, _mainTable);
                        _newnode.ImageIndex = 2;
                        _newnode.SelectImageIndex = 0;
                        _newnode.HasChildren = true;
                        _mainTable.QueryModelID = _qm.QueryModelID;
                        _qm.MainTable = _mainTable;
                    }
                    List<MD_View2ViewGroup> _v2vGroup = _mdc.GetView2ViewGroupOfQueryModel(_qm.QueryModelID).ToList<MD_View2ViewGroup>();
                    if (_v2vGroup != null && _v2vGroup.Count > 0)
                    {
                        foreach (MD_View2ViewGroup _g in _v2vGroup)
                        {

                            TreeListNode _newnode = treeList1.AppendNode(null, _fnode);
                            _newnode.SetValue(this.treeListColumn1, _g);
                            _newnode.ImageIndex = 3;
                            _newnode.SelectImageIndex = 0;
                            _newnode.HasChildren = true;
                            _g.QueryModelID = _qm.QueryModelID;

                        }
                    }
                    _mt = new MD_Title("关联数据指标", "MD_VIEW_GUIDELINE", _qm);
                    TreeListNode _newqxnode2 = treeList1.AppendNode(null, _fnode);
                    _newqxnode2.ImageIndex = 8;
                    _newqxnode2.SelectImageIndex = 0;
                    _newqxnode2.SetValue(this.treeListColumn1, _mt);
                    _newqxnode2.HasChildren = true;

                    _mt = new MD_Title("集成应用展示", "MD_VIEW_APPLICATION", _qm);
                    TreeListNode _newAppnode = treeList1.AppendNode(null, _fnode);
                    _newAppnode.ImageIndex = 8;
                    _newAppnode.SelectImageIndex = 0;
                    _newAppnode.SetValue(this.treeListColumn1, _mt);
                    _newAppnode.HasChildren = true;

                    _mt = new MD_Title("扩展权限定义", "MD_VIEW_EXRIGHT", _qm);
                    TreeListNode _newqxnode = treeList1.AppendNode(null, _fnode);
                    _newqxnode.ImageIndex = 6;
                    _newqxnode.SelectImageIndex = 0;
                    _newqxnode.SetValue(this.treeListColumn1, _mt);
                    _newqxnode.HasChildren = true;
                }




                if (_value is MD_View2ViewGroup)
                {
                    _fnode.Nodes.Clear();
                    MD_View2ViewGroup _v2vg = _value as MD_View2ViewGroup;
                    List<MD_View2View> _v2vs = _mdc.GetView2ViewList(_v2vg.ID, _v2vg.QueryModelID).ToList<MD_View2View>();
                    if (_v2vs != null)
                    {
                        foreach (MD_View2View _v in _v2vs)
                        {
                            TreeListNode _newnode = treeList1.AppendNode(null, _fnode);
                            _v.QueryModelID = _v2vg.QueryModelID;
                            _v.ViewGroupID = _v2vg.ID;
                            _newnode.SetValue(this.treeListColumn1, _v);
                            _newnode.ImageIndex = 2;
                            _newnode.SelectImageIndex = 0;
                            _newnode.HasChildren = true;
                        }
                    }
                }




                if (_value is MD_Table)
                {
                    _fnode.Nodes.Clear();
                    MD_Table _tb = _value as MD_Table;
                    List<MD_Table2View> _t2vs = _mdc.GetTable2ViewList(_tb.TID).ToList<MD_Table2View>();
                    if (_t2vs != null)
                    {
                        foreach (MD_Table2View _t2v in _t2vs)
                        {
                            TreeListNode _newnode = treeList1.AppendNode(null, _fnode);
                            _newnode.SetValue(this.treeListColumn1, _t2v);
                            _newnode.ImageIndex = 2;
                            _newnode.SelectImageIndex = 0;
                            _newnode.HasChildren = true;
                        }
                    }

                }

                if (_value is MD_ViewTable)
                {
                    _fnode.Nodes.Clear();
                    MD_ViewTable _vt = _value as MD_ViewTable;
                    if (_vt.ViewTableType == MDType_ViewTable.MainTable)
                    {
                        MetaDataServiceClient _msc = new MetaDataServiceClient();
                        IList<MD_ViewTable> _childTables = _msc.GetChildTableOfQueryModel(_vt.QueryModelID);


                        foreach (MD_ViewTable _cvt in _childTables)
                        {
                            TreeListNode _newnode = treeList1.AppendNode(null, _fnode);
                            _newnode.SetValue(this.treeListColumn1, _cvt);
                            _newnode.ImageIndex = 2;
                            _newnode.SelectImageIndex = 0;
                            _newnode.HasChildren = true;
                            _cvt.QueryModelID = _vt.QueryModelID;
                        }

                    }
                }

                if (_value is MD_Menu)
                {
                    MD_Menu _fmenu = _value as MD_Menu;
                    IList<MD_Menu> _menuTable = _mdc.GetSubMenuDefine(_fmenu.MenuID);
                    foreach (MD_Menu _menu in _menuTable)
                    {
                        TreeListNode _newnode = treeList1.AppendNode(null, _fnode);
                        _newnode.SetValue(this.treeListColumn1, _menu);
                        if (_menu.MenuType.Length > 3 && _menu.MenuType.Substring(0, 3) == "WEB")
                        {
                            _newnode.ImageIndex = 4;
                            _newnode.SelectImageIndex = 0;
                        }
                        else if (_menu.MenuType.Length > 3 && _menu.MenuType.Substring(0, 3) == "SL_")
                        {
                            _newnode.ImageIndex = 5;
                            _newnode.SelectImageIndex = 0;
                        }
                        else
                        {
                            _newnode.ImageIndex = 2;
                            _newnode.SelectImageIndex = 0;
                        }
                        _newnode.HasChildren = true;
                        _menu.NodeID = _fmenu.MD_Nodes.ID;
                        _menu.MD_Nodes = _fmenu.MD_Nodes;
                    }
                }

                if (_value is MD_ConceptGroup)
                {
                    MD_ConceptGroup _cGroup = _value as MD_ConceptGroup;
                    List<MD_ConceptItem> _itemDefines = _mdc.GetSubConceptTagDefine(_cGroup.Name).ToList<MD_ConceptItem>();
                    _cGroup.Items = _itemDefines;
                    _fnode.Nodes.Clear();
                    foreach (MD_ConceptItem _item in _itemDefines)
                    {
                        TreeListNode _newnode = treeList1.AppendNode(null, _fnode);
                        _newnode.SetValue(this.treeListColumn1, _item);
                        _newnode.HasChildren = false;
                    }
                }
            }
        }




        #endregion

        #region 显示数据
        private void ShowNodeData(TreeListNode _fnode)
        {
            if (_fnode == null) return;
            object _value = _fnode.GetValue(this.treeListColumn1);
            ChangePanelContext();
            this.panel1.Visible = false;
            if (_value is MD_Nodes)
            {
                this.panel1.Controls.Clear();
                NodeManager _f = new NodeManager(_value as MD_Nodes);
                _f.DataChanged += new EventHandler<EventArgs>(_f_DataChanged);
                _f.Dock = DockStyle.Fill;
                this.panel1.Controls.Add(_f);
            }

            if (_value is MD_Namespace)
            {
                this.panel1.Controls.Clear();
                NameSpaceManager _f = new NameSpaceManager(_value as MD_Namespace);
                _f.DataChanged += new EventHandler<EventArgs>(_f_DataChanged);
                _f.Dock = DockStyle.Fill;
                this.panel1.Controls.Add(_f);
            }

            if (_value is MD_QueryModel_ExRight)
            {
                this.panel1.Controls.Clear();
                QueryModelExRightManger _f = new QueryModelExRightManger(_value as MD_QueryModel_ExRight);
                _f.DataChanged += new EventHandler<EventArgs>(_f_DataChanged);
                _f.Dock = DockStyle.Fill;
                this.panel1.Controls.Add(_f);
            }

            if (_value is MD_Title)
            {
                this.panel1.Controls.Clear();
                MD_Title _mdtitle = _value as MD_Title;
                switch (_mdtitle.TitleType)
                {
                    case "MD_MENU":
                        NodeRightDefine _f = new NodeRightDefine(this._application);
                        _f.SuspendLayout();
                        _f.DataChanged += new EventHandler<EventArgs>(_f_DataChanged);
                        _f.Dock = DockStyle.Fill;
                        this.panel1.Controls.Add(_f);
                        _f.ResumeLayout();
                        TreeListNode _fatherNode = _fnode.ParentNode;
                        _f.NodesData = _fatherNode.GetValue(this.treeListColumn1) as MD_Nodes;
                        break;

                }
            }

            if (_value is MD_Table && !(_value is MD_ViewTable))
            {
                this.panel1.Controls.Clear();
                TableManager _f = new TableManager(_value as MD_Table);
                _f.SuspendLayout();
                _f.DataChanged += new EventHandler<EventArgs>(_f_DataChanged);
                _f.Dock = DockStyle.Fill;
                this.panel1.Controls.Add(_f);
                _f.ResumeLayout();
            }

            if (_value is MD_Table2View)
            {
                this.panel1.Controls.Clear();
                Table2ViewManager _f = new Table2ViewManager(_value as MD_Table2View);
                _f.SuspendLayout();
                _f.DataChanged += new EventHandler<EventArgs>(_f_DataChanged);
                _f.Dock = DockStyle.Fill;
                this.panel1.Controls.Add(_f);
                _f.ResumeLayout();
            }

            if (_value is MD_ViewTable)
            {
                this.panel1.Controls.Clear();
                MD_ViewTable _mvt = _value as MD_ViewTable;
                if (_mvt.ViewTableType == MDType_ViewTable.MainTable)
                {
                    QueryModelMainTableManager _f = new QueryModelMainTableManager(_mvt);
                    _f.DataChanged += new EventHandler<EventArgs>(_f_DataChanged);
                    _f.Dock = DockStyle.Fill;
                    this.panel1.Controls.Add(_f);
                }

                if (_mvt.ViewTableType == MDType_ViewTable.ChildTable)
                {
                    QueryModelChildTableManager _f = new QueryModelChildTableManager(_mvt);
                    _f.DataChanged += new EventHandler<EventArgs>(_f_DataChanged);
                    _f.Dock = DockStyle.Fill;
                    this.panel1.Controls.Add(_f);
                }
            }

            if (_value is MD_View_GuideLine)
            {
                this.panel1.Controls.Clear();
                ViewGuideLineManager _f = new ViewGuideLineManager(_value as MD_View_GuideLine);
                _f.DataChanged += new EventHandler<EventArgs>(_f_DataChanged);
                _f.Dock = DockStyle.Fill;
                this.panel1.Controls.Add(_f);
            }

            if(_value is MD_View2App)
            {
                this.panel1.Controls.Clear();
                SinoUC_QME_View2APP _f = new SinoUC_QME_View2APP(_value as MD_View2App);
                _f.DataChanged += new EventHandler<EventArgs>(_f_DataChanged);
                _f.Dock = DockStyle.Fill;
                this.panel1.Controls.Add(_f);
            }

            if (_value is MD_QueryModel)
            {
                this.panel1.Controls.Clear();
                QueryModelManager _f = new QueryModelManager(_value as MD_QueryModel);
                _f.DataChanged += new EventHandler<EventArgs>(_f_DataChanged);
                _f.Dock = DockStyle.Fill;
                this.panel1.Controls.Add(_f);

            }

            if (_value is MD_RefTable)
            {
                this.panel1.Controls.Clear();
                RefTableManager _f = new RefTableManager(_value as MD_RefTable);
                _f.DataChanged += new EventHandler<EventArgs>(_f_DataChanged);
                _f.Dock = DockStyle.Fill;
                this.panel1.Controls.Add(_f);
            }

            if (_value is MD_Menu)
            {
                this.panel1.Controls.Clear();
                MenuManager _f = new MenuManager(_value as MD_Menu, this._application);
                _f.DataChanged += new EventHandler<EventArgs>(_f_DataChanged);
                _f.Dock = DockStyle.Fill;
                this.panel1.Controls.Add(_f);
            }

            if (_value is MD_ConceptGroup)
            {
                this.panel1.Controls.Clear();
                ConceptGroup _f = new ConceptGroup(_value as MD_ConceptGroup);
                _f.DataChanged += new EventHandler<EventArgs>(_f_DataChanged);
                _f.Dock = DockStyle.Fill;
                this.panel1.Controls.Add(_f);
            }

            if (_value is MD_ConceptItem)
            {
                this.panel1.Controls.Clear();
                ConceptTag _f = new ConceptTag(_value as MD_ConceptItem);
                _f.DataChanged += new EventHandler<EventArgs>(_f_DataChanged);
                _f.Dock = DockStyle.Fill;
                this.panel1.Controls.Add(_f);

            }

            if (_value is MD_View2ViewGroup)
            {
                this.panel1.Controls.Clear();
                View2ViewGroupInfo _f = new View2ViewGroupInfo(_value as MD_View2ViewGroup);
                _f.DataChanged += new EventHandler<EventArgs>(_f_DataChanged);
                _f.Dock = DockStyle.Fill;
                this.panel1.Controls.Add(_f);
            }

            if (_value is MD_View2View)
            {
                this.panel1.Controls.Clear();
                View2ViewInfo _f = new View2ViewInfo(_value as MD_View2View);
                _f.DataChanged += new EventHandler<EventArgs>(_f_DataChanged);
                _f.Dock = DockStyle.Fill;
                this.panel1.Controls.Add(_f);
            }

            this.panel1.Visible = true;
        }

        private void ChangePanelContext()
        {
            if (this.panel1.Controls.Count > 0)
            {
                object _obj = this.panel1.Controls[0];
                if (_obj is IControlMenu)
                {
                    IControlMenu _ic = _obj as IControlMenu;
                    _ic.CloseControl();
                }
            }
        }

        private void _f_DataChanged(object sender, EventArgs e)
        {
            this.treeList1.Update();
            RaiseMenuChanged();
        }

        #endregion

        #region IChildForm Members
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

        #endregion

        private void frmNodeManager_Load(object sender, EventArgs e)
        {
            this._initFinished = true;
            RaiseMenuChanged();
        }



        #region IChildForm Members
        public IList<FrmMenuPage> GetMenuPages()
        {
            IList<FrmMenuPage> _ret = new List<FrmMenuPage>();
            FrmMenuPage _page = new FrmMenuPage("节点配置");
            _page.MenuGroups = GetMenuGroups(_page.PageTitle);
            _ret.Add(_page);
            return _ret;
        }

        #endregion

        private IList<FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();
            TreeListNode _fnode = treeList1.FocusedNode;
            if (_fnode != null)
            {
                object _value = _fnode.GetValue(this.treeListColumn1);
                FrmMenuGroup _mg = MenuDefine.GetMenuGroupByObject(_value);
                if (_mg != null)
                {
                    _ret.Add(_mg);
                }
            }

            Control _control = this.panel1.Controls.Count == 0 ? null : this.panel1.Controls[0];
            if (_control != null)
            {
                foreach (FrmMenuGroup _mg in MenuDefine.GetMenuGroupByControls(_control))
                {
                    if (_mg != null)
                    {
                        _ret.Add(_mg);
                    }
                }
            }

            return _ret;
        }

        #region IChildForm Members

        public bool DoCommand(string _cmdName)
        {
            TreeListNode _fnode = treeList1.FocusedNode;
            if (_fnode != null)
            {
                object _value = _fnode.GetValue(this.treeListColumn1);
                if (MenuDefine.RunObjectCommand(_cmdName, _value))
                {
                    //刷新树
                    if (_fnode.ParentNode != null) RefrashNode(_fnode.ParentNode);
                    else
                    {
                        this.treeList1.Nodes.Clear();
                        InitNodes();
                        InitConcept();
                    }

                };
            }

            Control _control = this.panel1.Controls.Count == 0 ? null : this.panel1.Controls[0];
            if (_control is IControlMenu)
            {
                (_control as IControlMenu).DoCommand(_cmdName);
            }

            return true;
        }

        private void RefrashNode(TreeListNode treeListNode)
        {
            if (treeListNode == null)
            {
                InitNodes();
                return;
            }
            object _value = treeListNode.GetValue(this.treeListColumn1);
            treeListNode.Nodes.Clear();
            LoadChildData(treeListNode, _value);

        }

        #endregion
    }
}

