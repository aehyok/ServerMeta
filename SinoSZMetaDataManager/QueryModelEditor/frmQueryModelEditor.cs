using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZClientBase;
using SinoSZJS.Base.Misc;
using DevExpress.XtraTreeList.Nodes;
using SinoSZPluginFramework;
using SinoSZJS.Base.MetaData.Define;
using SinoSZJS.Base.MetaData.EnumDefine;
using SinoSZClientBase.MetaDataService;

namespace SinoSZMetaDataManager.QueryModelEditor
{
    public partial class frmQueryModelEditor : frmBase
    {
        private string Param = "";
        private List<string> ModelNameList = new List<string>();
        private Dictionary<string, MD_QueryModel> ModelDict = new Dictionary<string, MD_QueryModel>();
        private IControlMenu CurrentItem = null;
        private TreeListNode CurrentNode = null;
        public frmQueryModelEditor()
        {
            InitializeComponent();
        }

        #region 重载基类的方法

        public override void Init(string _title, string _menuName, object _param)
        {
            this.Text = _title;
            Param = _param.ToString();
            string _queryViewNames = StrUtils.GetMetaByName("查询模型", Param).Trim();
            if (_queryViewNames != "")
            {
                foreach (string _qvName in _queryViewNames.Split(','))
                {
                    if (!ModelNameList.Contains(_qvName))
                    {
                        ModelNameList.Add(_qvName);
                        using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
                        {
                            ModelDict.Add(_qvName, _mdc.GetQueryModelByName(_qvName));
                        }
                    }
                }
            }
            InitTree();
            this._initFinished = true;
            RaiseMenuChanged();
        }


        protected override IList<FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();

            if (CurrentItem != null)
            {
                foreach (FrmMenuGroup _group in CurrentItem.GetControlMenu())
                {
                    _ret.Add(_group);
                }

            }


            return _ret;
        }

        protected override bool ExcuteCommand(string _cmdName)
        {
            if (CurrentItem != null)
            {
                return CurrentItem.DoCommand(_cmdName);
            }
            return false;
        }



        #endregion

        private void InitTree()
        {
            foreach (MD_QueryModel _qv in ModelDict.Values)
            {
                TreeListNode _fnode = treeList1.AppendNode(null, null);
                _fnode.ImageIndex = 1;
                _fnode.SelectImageIndex = 0;
                _fnode.SetValue(this.treeListColumn1, _qv);
                _fnode.HasChildren = true;
                _fnode.Expanded = false;
            }
            CurrentNode = null;
            if (treeList1.Nodes.Count > 0) ShowNodeItem(this.treeList1.Nodes[0]);

        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            CurrentNode = e.Node;
            if (CurrentItem != null)
            {
                CurrentItem.CloseControl();
            }
            if (e.Node != null)
            {
                ShowNodeItem(e.Node);
            }
            else
            {
                this.panel1.Controls.Clear();
                CurrentItem = null;
            }
            RaiseMenuChanged();
        }

        private void ShowNodeItem(TreeListNode treeListNode)
        {
            object _selectedItem = treeListNode.GetValue(this.treeListColumn1);
            if (_selectedItem is MD_QueryModel)
            {
                ShowQueryModelInfo(_selectedItem as MD_QueryModel);

            }
            else if (_selectedItem is MD_ViewTable)
            {
                MD_ViewTable _vt = _selectedItem as MD_ViewTable;
                if (_vt.ViewTableType == MDType_ViewTable.MainTable)
                {
                    ShowTableInfo(_vt);
                }
                else
                {
                    ShowTableInfo(_vt);
                }
            }
            else
            {
                this.panel1.Controls.Clear();
                CurrentItem = null;
            }

        }

        private void ShowTableInfo(MD_ViewTable _vt)
        {
            SinoUC_QME_TableInfo _uc = new SinoUC_QME_TableInfo(CurrentNode);
            _uc.DataChanged += new EventHandler<EventArgs>(_uc_DataChanged);
            _uc.MenuChanged += new EventHandler<EventArgs>(_uc_MenuChanged);
            _uc.DataSaved += new EventHandler<EventArgs>(_uc_DataSaved);
            _uc.InitData(_vt);
            _uc.Dock = DockStyle.Fill;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(_uc);
            CurrentItem = _uc as IControlMenu;
        }

        void _uc_DataSaved(object sender, EventArgs e)
        {
            this.treeList1.BeginUpdate();
            this.treeList1.EndUpdate();
        }


        private void ShowQueryModelInfo(MD_QueryModel _qv)
        {
            SinoUC_QME_QueryModelInfo _uc = new SinoUC_QME_QueryModelInfo();
            _uc.DataChanged += new EventHandler<EventArgs>(_uc_DataChanged);
            _uc.MenuChanged += new EventHandler<EventArgs>(_uc_MenuChanged);
            _uc.InitData(_qv);
            _uc.Dock = DockStyle.Fill;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(_uc);
            CurrentItem = _uc as IControlMenu;

        }

        void _uc_MenuChanged(object sender, EventArgs e)
        {
            this.treeList1.BeginUpdate();
            this.treeList1.EndUpdate();
            this.treeList1.Refresh();
            RaiseMenuChanged();
        }

        void _uc_DataChanged(object sender, EventArgs e)
        {
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

        private void LoadChildData(TreeListNode _fnode, object _value)
        {
            if (_value is MD_QueryModel)
            {
                LoadMainTable(_fnode, _value as MD_QueryModel);
            }
            if (_value is MD_ViewTable)
            {
                MD_ViewTable _vt = _value as MD_ViewTable;
                if (_vt.ViewTableType == MDType_ViewTable.MainTable)
                {
                    LoadChildTable(_fnode, _vt);
                }
            }


        }

        private void LoadChildTable(TreeListNode _fnode, MD_ViewTable _vt)
        {
            using (MetaDataServiceClient _msc = new MetaDataServiceClient())
            {
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

        private void LoadMainTable(TreeListNode _fnode, MD_QueryModel _qv)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                MD_ViewTable _mainTable = _mdc.GetMainTableOfQueryModel(_qv.QueryModelID);
                if (_mainTable != null)
                {
                    TreeListNode _newnode = treeList1.AppendNode(null, _fnode);
                    _newnode.SetValue(this.treeListColumn1, _mainTable);
                    _newnode.ImageIndex = 2;
                    _newnode.SelectImageIndex = 0;
                    _newnode.HasChildren = true;
                    _mainTable.QueryModelID = _qv.QueryModelID;
                    _qv.MainTable = _mainTable;
                }
            }
        }


    }
}