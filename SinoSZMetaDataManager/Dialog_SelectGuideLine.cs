using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZMetaDataQuery;

using DevExpress.XtraTreeList.Nodes;

using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.Define;
using System.Linq;
using SinoSZClientBase.MetaDataService;
using SinoSZClientBase.MetaDataQueryService;

namespace SinoSZMetaDataManager
{
    public partial class Dialog_SelectGuideLine : DevExpress.XtraEditors.XtraForm
    {
        private string _glid = "";
        public Dialog_SelectGuideLine()
        {
            InitializeComponent();
            InitGuideLineTree();
        }
        private bool _initFinished = false;

        public string GuideLineID
        {
            get { return _glid; }
        }

        private void InitGuideLineTree()
        {
            treeList1.Nodes.Clear();
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                IList<MD_Nodes> _nodes = _mdc.GetNodeList();
                foreach (MD_Nodes _node in _nodes)
                {
                    TreeListNode _fnode = treeList1.AppendNode(null, null);
                    _fnode.SetValue(this.treeListColumn1, _node);
                    _fnode.HasChildren = true;
                }
            }
        }

        private void LoadChildGuideLine(MD_GuideLine _fgl, TreeListNode _fnode)
        {
            using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
            {
                List<MD_GuideLine> _rootGuideLineList = _msc.GetGuideLineListByFatherID(_fgl.ID).ToList<MD_GuideLine>();
                foreach (MD_GuideLine _gl in _rootGuideLineList)
                {
                    TreeListNode _newnode = treeList1.AppendNode(null, _fnode);
                    _newnode.SetValue(this.treeListColumn1, _gl);
                    _newnode.HasChildren = true;
                }
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

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

            TreeListNode _fnode = e.Node;
            if (_fnode == null) return;
            object _value = _fnode.GetValue(this.treeListColumn1);
            if (_value is MD_Nodes)
            {
                _glid = "";
            }

            if (_value is MD_Title)
            {
                _glid = "";
            }

            if (_value is MD_GuideLineGroup)
            {
                _glid = "";
            }

            if (_value is MD_GuideLine)
            {
                MD_GuideLine _f = _value as MD_GuideLine;
                _glid = _f.ID;
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}