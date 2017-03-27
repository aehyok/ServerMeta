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
using System.Linq;
using SinoSZJS.Base.MetaData.Define;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZClientBase.MetaDataService;

namespace SinoSZMetaDataManager
{
    public partial class frmGuideLineManager : DevExpress.XtraEditors.XtraForm, IChildForm
    {
        private IApplication _application = null;
        private bool _initFinished = false;


        public frmGuideLineManager()
        {
            InitializeComponent();
            InitNodes();
        }

        private void InitNodes()
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                treeList1.Nodes.Clear();
                IList<MD_Nodes> _nodes = _mdc.GetNodeList();
                foreach (MD_Nodes _node in _nodes)
                {
                    TreeListNode _fnode = treeList1.AppendNode(null, null);
                    _fnode.SetValue(this.treeListColumn1, _node);
                    _fnode.HasChildren = true;
                }
                ShowNodeData(treeList1.FocusedNode);
            }
        }

        private void treeList1_BeforeExpand(object sender, DevExpress.XtraTreeList.BeforeExpandEventArgs e)
        {
            //展开项
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
                if (_value is MD_Nodes)
                {
                    _fnode.Nodes.Clear();
                    MD_Nodes _nodes = _value as MD_Nodes;

                    MD_Title _mt = new MD_Title("统计指标", "MD_TJZB", _nodes);
                    TreeListNode _newnode = treeList1.AppendNode(null, _fnode);
                    _newnode.SetValue(this.treeListColumn1, _mt);
                    _newnode.HasChildren = true;
                    _newnode.ImageIndex = 1;
                    _newnode.SelectImageIndex = 2;

                    _mt = new MD_Title("报表指标", "MD_REPORTGUIDLINE", _nodes);
                    _newnode = treeList1.AppendNode(null, _fnode);
                    _newnode.SetValue(this.treeListColumn1, _mt);
                    _newnode.HasChildren = true;
                    _newnode.ImageIndex = 1;
                    _newnode.SelectImageIndex = 2;
                }

                if (_value is MD_Title)
                {
                    IList<MD_GuideLineGroup> _guideLineGroups = null;
                    _fnode.Nodes.Clear();
                    MD_Title _mdtitle = _value as MD_Title;
                    MD_Nodes _nodes = (MD_Nodes)_mdtitle.FatherObj;
                    switch (_mdtitle.TitleType)
                    {
                        case "MD_TJZB":

                            _guideLineGroups = _mdc.GetGuideLineGroup(_nodes.DWDM, "3");  //参数3表示统计指标
                            foreach (MD_GuideLineGroup _tb in _guideLineGroups)
                            {
                                TreeListNode _newnode = treeList1.AppendNode(null, _fnode);
                                _newnode.SetValue(this.treeListColumn1, _tb);
                                _newnode.ImageIndex = 0;
                                _newnode.SelectImageIndex = 2;
                                _newnode.HasChildren = true;
                            }
                            break;

                        case "MD_REPORTGUIDLINE":
                            _guideLineGroups = _mdc.GetGuideLineGroup(_nodes.DWDM, "1");  //参数1表示报表指标

                            foreach (MD_GuideLineGroup _tb in _guideLineGroups)
                            {
                                TreeListNode _newnode = treeList1.AppendNode(null, _fnode);
                                _newnode.SetValue(this.treeListColumn1, _tb);
                                _newnode.ImageIndex = 0;
                                _newnode.SelectImageIndex = 2;
                                _newnode.HasChildren = true;
                            }
                            break;
                    }
                }

                if (_value is MD_GuideLineGroup)
                {
                    MD_GuideLineGroup _glg = _value as MD_GuideLineGroup;
                    switch (_glg.LX)
                    {
                        case 1:         //报表指标
                            break;

                        case 3:         //统计指标
                            List<MD_GuideLine> _guideLineList = _mdc.GetGuideLineOfGroup(_glg.ZBZTMC).ToList<MD_GuideLine>();
                            _glg.ChildGuideLines = _guideLineList;
                            foreach (MD_GuideLine _gl in _guideLineList)
                            {
                                TreeListNode _newnode = treeList1.AppendNode(null, _fnode);
                                _newnode.SetValue(this.treeListColumn1, _gl);
                                _newnode.ImageIndex = 0;
                                _newnode.SelectImageIndex = 2;
                                _newnode.HasChildren = true;
                                _gl.MD_GuideLineGroup = _glg;
                            }
                            break;
                    }
                }

                if (_value is MD_GuideLine)
                {
                    MD_GuideLine _gline = _value as MD_GuideLine;
                    List<MD_GuideLine> _childGuideLineList = _mdc.GetChildGuideLines(_gline.ID).ToList<MD_GuideLine>();
                    _gline.Children = _childGuideLineList;
                    foreach (MD_GuideLine _gl in _childGuideLineList)
                    {
                        TreeListNode _newnode = treeList1.AppendNode(null, _fnode);
                        _newnode.SetValue(this.treeListColumn1, _gl);
                        _newnode.ImageIndex = 0;
                        _newnode.SelectImageIndex = 2;
                        _newnode.HasChildren = true;
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

            if (_value is MD_Nodes)
            {
                this.panel1.Controls.Clear();
            }

            if (_value is MD_Title)
            {
                this.panel1.Controls.Clear();
            }

            if (_value is MD_GuideLineGroup)
            {
                this.panel1.Controls.Clear();
                GuideLineGroupManager _f = new GuideLineGroupManager(_value as MD_GuideLineGroup);
                _f.DataChanged += new EventHandler<EventArgs>(_f_DataChanged);
                _f.MenuChanged += new EventHandler<EventArgs>(_f_MenuChanged);
                _f.Dock = DockStyle.Fill;
                this.panel1.Controls.Add(_f);
            }

            if (_value is MD_GuideLine)
            {
                this.panel1.Controls.Clear();
                GuideLineManager _f = new GuideLineManager(_value as MD_GuideLine);
                _f.DataChanged += new EventHandler<EventArgs>(_f_DataChanged);
                _f.MenuChanged += new EventHandler<EventArgs>(_f_MenuChanged);
                _f.Dock = DockStyle.Fill;
                this.panel1.Controls.Add(_f);
            }

        }

        void _f_MenuChanged(object sender, EventArgs e)
        {
            RaiseMenuChanged();
        }

        private void _f_DataChanged(object sender, EventArgs e)
        {
            this.treeList1.Update();
            RaiseMenuChanged();
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

        public IList<FrmMenuPage> GetMenuPages()
        {
            IList<FrmMenuPage> _ret = new List<FrmMenuPage>();
            FrmMenuPage _page = new FrmMenuPage("指标定义");
            _page.MenuGroups = GetMenuGroups(_page.PageTitle);
            _ret.Add(_page);
            return _ret;
        }

        private IList<FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();


            TreeListNode _fnode = treeList1.FocusedNode;
            if (_fnode != null)
            {
                object _value = _fnode.GetValue(this.treeListColumn1);
                if (_value is MD_Nodes)
                {
                }
                else
                {
                    FrmMenuGroup _mg = MenuDefine.GetMenuGroupByObject(_value);
                    if (_mg != null)
                    {
                        _ret.Add(_mg);
                    }
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

        public bool DoCommand(string _cmdName)
        {
            TreeListNode _fnode = treeList1.FocusedNode;
            if (_cmdName == "查询指标")
            {
                //Find
                QueryGuideLineNode(_fnode);
            }
            else
            {
                if (_fnode != null)
                {
                    object _value = _fnode.GetValue(this.treeListColumn1);
                    if (MenuDefine.RunObjectCommand(_cmdName, _value))
                    {
                        //刷新树
                        RefrashNode(_fnode.ParentNode);
                        //InitNodes();
                    };
                }

                Control _control = this.panel1.Controls.Count == 0 ? null : this.panel1.Controls[0];
                if (_control is IControlMenu)
                {
                    (_control as IControlMenu).DoCommand(_cmdName);
                }
            }
            return true;
        }

        private void QueryGuideLineNode(TreeListNode _fnode)
        {
            throw new Exception("The method or operation is not implemented.");
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

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            TreeListNode _fnode = e.Node;
            ShowNodeData(_fnode);
            RaiseMenuChanged();
        }

        private void frmGuideLineManager_Load(object sender, EventArgs e)
        {
            this._initFinished = true;
        }
    }
}