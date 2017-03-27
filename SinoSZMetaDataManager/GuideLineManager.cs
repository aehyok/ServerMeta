using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZPluginFramework;
using SinoSZMetaDataManager.TreeObject;
using DevExpress.XtraTreeList.Nodes;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZClientBase.MetaDataService;
using SinoSZJS.Base.MetaData.Common;

namespace SinoSZMetaDataManager
{
    public partial class GuideLineManager : DevExpress.XtraEditors.XtraUserControl, IControlMenu
    {
        private static List<MD_GuideLineFieldGroup> ClipPad_Fields = new List<MD_GuideLineFieldGroup>();
        private static List<MD_GuideLineParameter> ClipPad_Params = new List<MD_GuideLineParameter>();
        private MD_GuideLine _guideLine = null;
        private bool _haveChange = false;
        private bool _initFinished = false;
        private List<MD_GuideLineFieldGroup> _fgList = null;
        private List<MD_GuideLineParameter> _pList = null;
        private List<MD_GuideLineDetailDefine> _dList = null;
        private TreeObj_GuideLineFieldList _treeData = null;
        public GuideLineManager()
        {
            InitializeComponent();
        }

        public GuideLineManager(MD_GuideLine _gline)
        {
            InitializeComponent();
            _guideLine = _gline;
            RefreshData();
            _initFinished = true;
        }

        private void RefreshData()
        {
            TE_ID.EditValue = _guideLine.ID;
            TE_Name.EditValue = _guideLine.GuideLineName;
            TE_ORDER.EditValue = _guideLine.DisplayOrder;
            TE_SF.EditValue = _guideLine.GuideLineMethod;
            _fgList = MC_GuideLine.GetFieldGroupsFromMeta(_guideLine.GuideLineMeta);
            this.te_Description.EditValue = _guideLine.Description;
            _treeData = new TreeObj_GuideLineFieldList();
            foreach (MD_GuideLineFieldGroup _glg in _fgList)
            {
                TreeObj_GuideLineFieldGroup _group = new TreeObj_GuideLineFieldGroup(_glg);
                TreeObj_GuidelLineFieldItem _item = _group as TreeObj_GuidelLineFieldItem;
                foreach (MD_GuideLineFieldName _fname in _glg.Fields)
                {
                    TreeObj_GuidelLineFieldItem _fitem = new TreeObj_GuidelLineFieldItem(_fname);
                    _item.Children.Add(_fitem);
                }
                _treeData.Add(_item);
            }
            this.treeList1.DataSource = _treeData;
            _pList = MC_GuideLine.GetParametersFromMeta(_guideLine.GuideLineMeta);
            this.gridParameter.DataSource = _pList;
            _dList = MC_GuideLine.GetDetaiDefinelFromMeta(_guideLine.GuideLineMeta);
            this.gridDetail.DataSource = _dList;
            this._haveChange = false;
        }

        #region IControlMenu Members

        public List<FrmMenuGroup> GetControlMenu()
        {
            FrmMenuGroup _thisGroup;
            FrmMenuItem _item;
            List<FrmMenuGroup> _ret = new List<FrmMenuGroup>();

            if (this.xtraTabControl1.SelectedTabPageIndex == 0)
            {
                _thisGroup = new FrmMenuGroup("查询参数定义");
                _thisGroup.MenuItems = new List<FrmMenuItem>();

                _item = new FrmMenuItem("添加参数", "添加参数", global::SinoSZMetaDataManager.Properties.Resources.g30, true);
                _thisGroup.MenuItems.Add(_item);


                _item = new FrmMenuItem("删除参数", "删除参数", global::SinoSZMetaDataManager.Properties.Resources.g31, IsParameterFocused());
                _thisGroup.MenuItems.Add(_item);

                _item = new FrmMenuItem("复制参数", "复制参数定义", global::SinoSZMetaDataManager.Properties.Resources.e8, true);
                _thisGroup.MenuItems.Add(_item);

                _item = new FrmMenuItem("粘贴参数", "粘贴参数定义", global::SinoSZMetaDataManager.Properties.Resources.e9, (ClipPad_Params.Count > 0));
                _thisGroup.MenuItems.Add(_item);
                _ret.Add(_thisGroup);
            }

            if (this.xtraTabControl1.SelectedTabPageIndex == 1)
            {

                _thisGroup = new FrmMenuGroup("显示字段定义");
                _thisGroup.MenuItems = new List<FrmMenuItem>();

                _item = new FrmMenuItem("添加组", "添加字段组", global::SinoSZMetaDataManager.Properties.Resources.g34, true);
                _thisGroup.MenuItems.Add(_item);

                _item = new FrmMenuItem("删除组", "删除字段组", global::SinoSZMetaDataManager.Properties.Resources.g35, IsFieldGroupFocused());
                _thisGroup.MenuItems.Add(_item);

                _item = new FrmMenuItem("添加字段", "添加字段定义", global::SinoSZMetaDataManager.Properties.Resources.g37, IsFieldGroupFocused());
                _thisGroup.MenuItems.Add(_item);

                _item = new FrmMenuItem("删除字段", "删除字段定义", global::SinoSZMetaDataManager.Properties.Resources.g38, IsFieldFocused());
                _thisGroup.MenuItems.Add(_item);

                _item = new FrmMenuItem("移往其它组", "移往其它组", global::SinoSZMetaDataManager.Properties.Resources.g36, IsFieldFocused());
                _thisGroup.MenuItems.Add(_item);

                _item = new FrmMenuItem("复制定义", "复制字段定义", global::SinoSZMetaDataManager.Properties.Resources.e8, true);
                _thisGroup.MenuItems.Add(_item);

                _item = new FrmMenuItem("粘贴定义", "粘贴字段定义", global::SinoSZMetaDataManager.Properties.Resources.e9, (ClipPad_Fields.Count > 0));
                _thisGroup.MenuItems.Add(_item);
                _ret.Add(_thisGroup);
            }

            if (this.xtraTabControl1.SelectedTabPageIndex == 2)
            {
                _thisGroup = new FrmMenuGroup("链接明细内容定义");
                _thisGroup.MenuItems = new List<FrmMenuItem>();

                _item = new FrmMenuItem("添加定义", "添加明细定义", global::SinoSZMetaDataManager.Properties.Resources.g40, true);
                _thisGroup.MenuItems.Add(_item);

                _item = new FrmMenuItem("删除定义", "删除明细定义", global::SinoSZMetaDataManager.Properties.Resources.g41, IsDetailFocused());
                _thisGroup.MenuItems.Add(_item);
                _ret.Add(_thisGroup);
            }

            _thisGroup = new FrmMenuGroup("保存修改");
            _thisGroup.MenuItems = new List<FrmMenuItem>();

            _item = new FrmMenuItem("保存", "保存", global::SinoSZMetaDataManager.Properties.Resources.xx, _haveChange);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("取消", "取消", global::SinoSZMetaDataManager.Properties.Resources.x1, _haveChange);
            _thisGroup.MenuItems.Add(_item);


            _ret.Add(_thisGroup);
            return _ret;
        }

        private bool IsFieldGroupFocused()
        {
            if (this.treeList1.FocusedNode == null) return false;
            string _type = (string)this.treeList1.FocusedNode.GetValue("Type");
            if (_type == "GROUP") return true;
            return false;
        }

        private bool IsFieldFocused()
        {
            if (this.treeList1.FocusedNode == null) return false;
            string _type = (string)this.treeList1.FocusedNode.GetValue("Type");
            if (_type == "GROUP") return false;
            return true;
        }

        private bool IsDetailFocused()
        {
            if (this.gridDetail.Focused)
            {
                if (this.gridView3.FocusedRowHandle >= 0)
                {
                    return true;
                }
            }
            return false;
        }



        private bool IsParameterFocused()
        {
            if (this.gridParameter.Focused)
            {
                if (this.gridView2.FocusedRowHandle >= 0)
                {
                    return true;
                }
            }
            return false;
        }


        public bool HaveDataChanged()
        {
            return _haveChange && _initFinished;
        }

        public event EventHandler<EventArgs> DataChanged;

        public event EventHandler<EventArgs> MenuChanged;

        public void RaiseDataChanged()
        {
            if (HaveDataChanged() && DataChanged != null)
            {
                DataChanged(this, new EventArgs());
            }
        }

        private void RaiseMenuChanged()
        {
            if (MenuChanged != null)
            {
                MenuChanged(this, new EventArgs());
            }
        }

        public bool CloseControl()
        {
            if (HaveDataChanged())
            {
                DialogResult _res = XtraMessageBox.Show("是否保存数据修改?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_res == DialogResult.Yes)
                {
                    SaveData();
                }
                else
                {
                    RefreshData();
                }
            }
            return true;
        }

        private void SaveData()
        {
            this._guideLine.GuideLineName = this.TE_Name.EditValue.ToString();
            this._guideLine.GuideLineMethod = this.TE_SF.EditValue.ToString();
            this._guideLine.DisplayOrder = int.Parse(this.TE_ORDER.EditValue.ToString());
            this._guideLine.Description = (this.te_Description.EditValue == null) ? "" : this.te_Description.EditValue.ToString();
            this.treeList1.PostEditor();
            this.gridView2.PostEditor();
            this.gridView3.PostEditor();


            _fgList = new List<MD_GuideLineFieldGroup>();
            foreach (TreeObj_GuidelLineFieldItem _item in _treeData)
            {
                TreeObj_GuideLineFieldGroup _group = _item as TreeObj_GuideLineFieldGroup;
                MD_GuideLineFieldGroup _fg = _group.GroupData;
                GetChildData(_fg, _group);
                _fgList.Add(_fg);
            }

            //注：对于老系统的strYN参数的特殊处理

            foreach (MD_GuideLineParameter _p in this.gridParameter.DataSource as IList<MD_GuideLineParameter>)
            {
                if (_p.ParameterName == "strYN")
                {
                    XtraMessageBox.Show("为了与旧系统的兼容需要，参数名称不可以是strYN!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            // ------------------------------------------

            this._guideLine.GuideLineMeta = MC_GuideLine.CreateMeta(_fgList,
                    this.gridParameter.DataSource as IList<MD_GuideLineParameter>, this.gridDetail.DataSource as IList<MD_GuideLineDetailDefine>);
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                if (_mdc.SaveGuideLine(MC_GuideLine.GetGuideLineDefineData(this._guideLine)))
                {
                    XtraMessageBox.Show("保存成功！");
                    _haveChange = false;
                    this.RaiseMenuChanged();
                }
            }

        }

        private void GetChildData(MD_GuideLineFieldGroup _fg, TreeObj_GuideLineFieldGroup _group)
        {
            _fg.Fields = new List<MD_GuideLineFieldName>();
            foreach (TreeObj_GuidelLineFieldItem _fitem in _group.Children)
            {
                MD_GuideLineFieldName _fn = _fitem.FieldData;
                _fg.Fields.Add(_fn);
            }
        }



        public bool DoCommand(string _cmdName)
        {
            switch (_cmdName)
            {
                case "添加参数":
                    AddParameter();
                    break;

                case "删除参数":
                    DelParameter();
                    break;

                case "复制参数定义":
                    Copy_ParamDefine();
                    break;
                case "粘贴参数定义":
                    Paste_ParamDefine();
                    break;
                case "添加字段组":
                    AddFieldGroup();
                    break;

                case "删除字段组":
                    DelFieldGroup();
                    break;

                case "移往其它组":
                    MoveItem();
                    break;

                case "复制字段定义":
                    Copy_FieldDefine();
                    break;

                case "粘贴字段定义":
                    Paste_FieldDefine();
                    break;

                case "添加字段定义":
                    AddFieldDefine();
                    break;

                case "删除字段定义":
                    DelFieldDefine();
                    break;


                case "添加明细定义":
                    AddDetailDefine();
                    break;

                case "删除明细定义":
                    DelDetailDefine();
                    break;

                case "保存":
                    SaveData();
                    break;
                case "取消":
                    RefreshData();
                    RaiseMenuChanged();
                    break;
            }
            return true;
        }







        /// <summary>
        /// 删除字段组
        /// </summary>
        private void DelFieldGroup()
        {
            TreeListNode _tn = this.treeList1.FocusedNode;
            if (_tn == null) return;
            string _type = (string)_tn.GetValue("Type");
            if (_type != "GROUP") return;
            if (_tn.Nodes.Count > 0)
            {
                XtraMessageBox.Show("本组下有字段定义,不可被删除!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.treeList1.Nodes.Remove(_tn);
            this._haveChange = true;
            RaiseDataChanged();
        }

        /// <summary>
        /// 添加字段组
        /// </summary>
        private void AddFieldGroup()
        {
            string _gname = string.Format("GROUP{0}", _treeData.Count + 1);
            MD_GuideLineFieldGroup _fg = new MD_GuideLineFieldGroup(_gname, "新建组", "CENTER", 0, false, "SHOW");
            TreeObj_GuideLineFieldGroup _treeFG = new TreeObj_GuideLineFieldGroup(_fg);
            TreeObj_GuidelLineFieldItem _item = _treeFG as TreeObj_GuidelLineFieldItem;
            this._treeData.Add(_item);
            this.treeList1.DataSource = null;
            this.treeList1.DataSource = _treeData;

            this._haveChange = true;
            RaiseDataChanged();
        }

        /// <summary>
        /// 添加字段定义
        /// </summary>
        private void AddFieldDefine()
        {
            if (!this.IsFieldGroupFocused()) return;
            TreeListNode _tn = this.treeList1.FocusedNode;
            if (_tn == null) return;
            MD_GuideLineFieldName _gf = new MD_GuideLineFieldName();
            _gf.FieldName = "字段";
            TreeObj_GuidelLineFieldItem _fi = new TreeObj_GuidelLineFieldItem(_gf);
            TreeObj_GuideLineFieldGroup _fg = this.treeList1.GetDataRecordByNode(_tn) as TreeObj_GuideLineFieldGroup;
            _fg.Children.Add(_fi);
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void DelFieldDefine()
        {
            if (!this.IsFieldFocused()) return;
            TreeListNode _tn = this.treeList1.FocusedNode;
            _tn.ParentNode.Nodes.Remove(_tn);
            this._haveChange = true;
            RaiseDataChanged();
        }


        /// <summary>
        /// 字段移往其它组
        /// </summary>
        private void MoveItem()
        {
            if (!this.IsFieldFocused()) return;
            Dialog_MoveFieldToGroup _f = new Dialog_MoveFieldToGroup();
            List<string> _groupNames = new List<string>();
            foreach (TreeListNode _node in this.treeList1.Nodes)
            {
                string _gname = (string)_node.GetValue("Name");
                _groupNames.Add(_gname);
            }
            _f.InitItems(_groupNames);
            if (_f.ShowDialog() == DialogResult.OK)
            {
                TreeListNode _tn = this.treeList1.FocusedNode;
                TreeListNode _fnode = _tn.ParentNode;
                string _oldGroup = (string)_fnode.GetValue("Name");
                if (_oldGroup == _f.SelectdGroupName)
                {
                    XtraMessageBox.Show("移往的组与当前所在组名称相同!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    TreeObj_GuidelLineFieldItem _fItem = this.treeList1.GetDataRecordByNode(_tn) as TreeObj_GuidelLineFieldItem;
                    _fnode.Nodes.Remove(_tn);
                    TreeListNode _newFather = null;
                    foreach (TreeListNode _node in this.treeList1.Nodes)
                    {
                        string _gname = (string)_node.GetValue("Name");
                        if (_gname == _f.SelectdGroupName)
                        {
                            _newFather = _node;
                            break;
                        }
                    }
                    if (_newFather != null)
                    {
                        TreeObj_GuideLineFieldGroup _gItem = this.treeList1.GetDataRecordByNode(_newFather) as TreeObj_GuideLineFieldGroup;
                        _gItem.Children.Add(_fItem);
                        this._haveChange = true;
                        RaiseDataChanged();
                    }
                }

            }

        }

        private void DelDetailDefine()
        {
            if (this.gridView3.FocusedRowHandle < 0)
            {
                return;
            }
            this.gridView3.BeginUpdate();
            this.gridView3.DeleteRow(this.gridView3.FocusedRowHandle);
            this.gridView3.EndUpdate();
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void AddDetailDefine()
        {
            this.gridDetail.BeginUpdate();
            MD_GuideLineDetailDefine _gdd = new MD_GuideLineDetailDefine();
            _gdd.TargetFieldName = "字段";
            _gdd.QueryDetailType = "查询模型";
            IList<MD_GuideLineDetailDefine> _detailList = this.gridDetail.DataSource as IList<MD_GuideLineDetailDefine>;
            _detailList.Add(_gdd);
            this.gridDetail.EndUpdate();
            this._haveChange = true;
            RaiseDataChanged();
        }



        //删除参数
        private void DelParameter()
        {

            if (this.gridView2.FocusedRowHandle < 0)
            {
                return;
            }
            this.gridView2.BeginUpdate();
            int _delIndex = this.gridView2.FocusedRowHandle;
            this.gridView2.DeleteRow(this.gridView2.FocusedRowHandle);
            this.gridView2.EndUpdate();
            this._haveChange = true;
            RaiseDataChanged();

        }


        private void AddParameter()
        {
            this.gridParameter.BeginUpdate();
            MD_GuideLineParameter _gp = new MD_GuideLineParameter();
            _gp.ParameterName = "param";
            IList<MD_GuideLineParameter> _pList = this.gridParameter.DataSource as IList<MD_GuideLineParameter>;
            _pList.Add(_gp);
            this.gridParameter.EndUpdate();
            this._haveChange = true;
            RaiseDataChanged();
        }


        private void Paste_FieldDefine()
        {
            this.treeList1.BeginUpdate();
            foreach (MD_GuideLineFieldGroup _fg in ClipPad_Fields)
            {
                TreeObj_GuideLineFieldGroup _treeFG = new TreeObj_GuideLineFieldGroup(_fg);
                TreeObj_GuidelLineFieldItem _item = _treeFG as TreeObj_GuidelLineFieldItem;
                this._treeData.Add(_item);
                foreach (MD_GuideLineFieldName _fn in _fg.Fields)
                {
                    TreeObj_GuidelLineFieldItem _fi = new TreeObj_GuidelLineFieldItem(_fn);
                    _treeFG.Children.Add(_fi);
                }
            }
            this.treeList1.DataSource = null;
            this.treeList1.DataSource = _treeData;
            this.treeList1.EndUpdate();
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void Copy_FieldDefine()
        {
            List<MD_GuideLineFieldGroup> _fieldLists = new List<MD_GuideLineFieldGroup>();
            foreach (TreeObj_GuidelLineFieldItem _item in _treeData)
            {
                TreeObj_GuideLineFieldGroup _group = _item as TreeObj_GuideLineFieldGroup;
                MD_GuideLineFieldGroup _fg = _group.GroupData;
                GetChildData(_fg, _group);
                _fieldLists.Add(_fg);
            }
            ClipPad_Fields = _fieldLists;
            RaiseMenuChanged();
        }

        private void Paste_ParamDefine()
        {
            if (ClipPad_Params.Count < 0) return;
            this.gridParameter.DataSource = null;
            this.gridParameter.DataSource = ClipPad_Params;
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void Copy_ParamDefine()
        {
            ClipPad_Params = new List<MD_GuideLineParameter>();
            IList<MD_GuideLineParameter> _plist = this.gridParameter.DataSource as IList<MD_GuideLineParameter>;
            foreach (MD_GuideLineParameter _p in _plist)
            {
                ClipPad_Params.Add(_p);
            }
            RaiseMenuChanged();
        }

        #endregion

        private void TE_Name_EditValueChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void te_Description_EditValueChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }
        private void TE_ORDER_EditValueChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void TE_SF_EditValueChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }



        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }

        private void gridParameter_Enter(object sender, EventArgs e)
        {
            RaiseMenuChanged();
        }

        private void gridFieldName_Enter(object sender, EventArgs e)
        {
            RaiseMenuChanged();
        }



        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            RaiseMenuChanged();
        }

        private void gridView3_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }
        private void treeList1_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            this._haveChange = true;
            RaiseDataChanged();
        }
        private void gridDetail_Enter(object sender, EventArgs e)
        {
            RaiseMenuChanged();
        }

        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            RaiseMenuChanged();
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            this.gridView3.PostEditor();
            int _index = this.gridView3.FocusedRowHandle;
            if (_index >= 0)
            {
                MD_GuideLineDetailDefine _gd = this.gridView3.GetRow(_index) as MD_GuideLineDetailDefine;
                Dialog_EditGuideLineDetailParam _f = new Dialog_EditGuideLineDetailParam(_gd);
                if (_f.ShowDialog() == DialogResult.OK)
                {
                    this.gridView3.BeginUpdate();
                    string _ret = _f.GetDetailParam();
                    _gd.DetailParameterMeta = _ret;
                    this.gridView3.EndUpdate();
                    this._haveChange = true;
                    RaiseDataChanged();
                }
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            RaiseMenuChanged();
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            RaiseMenuChanged();
        }

        private void treeList1_CustomNodeCellEdit(object sender, DevExpress.XtraTreeList.GetCustomNodeCellEditEventArgs e)
        {
            string _type = (string)e.Node.GetValue("Type");
            if (e.Column.FieldName == "DisplayFormat")
            {
                switch (_type)
                {
                    case "GROUP":
                        e.RepositoryItem = repositoryItemComboBox3;
                        break;
                    default:
                        break;
                }
            }
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            this.gridView2.PostEditor();
            int _index = this.gridView2.FocusedRowHandle;
            if (_index >= 0)
            {
                MD_GuideLineParameter _gd = this.gridView2.GetRow(_index) as MD_GuideLineParameter;
                Dialog_EditGuideLineRefTable _f = new Dialog_EditGuideLineRefTable(_gd);
                if (_f.ShowDialog() == DialogResult.OK)
                {
                    this.gridView2.BeginUpdate();
                    _gd.RefTableName = _f.RefTableName;
                    _gd.IncludeChildren = _f.IncludeChildren;
                    _gd.SelectAllCode = _f.SelectAllCode;
                    this.gridView2.EndUpdate();
                    this._haveChange = true;
                    RaiseDataChanged();
                }
            }
        }







    }
}
