using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraTreeList.Nodes;

using SinoSZPluginFramework;


using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.EnumDefine;
using SinoSZJS.Base.MetaData.Define;
using System.Linq;
using SinoSZJS.Base.Controller;

namespace SinoSZMetaDataQuery.Common
{
    public partial class SinoSZUC_MD_Model_FieldList : UserControl
    {
        private static int ExpIndex = 1;
        private string queryViewName = "";
        public string QueryViewName
        {
            get { return queryViewName; }
            set { queryViewName = value; }
        }

        private MDModel_QueryModel queryModel = null;
        public MDModel_QueryModel QueryModel
        {
            get { return queryModel; }
            set { queryModel = value; }
        }

        #region 自定义事件
        public event EventHandler<FieldSelectEventArgs> FieldSelected;
        private void RaiseFieldSelected(MDModel_Table_Column _item)
        {
            if (FieldSelected != null)
            {
                FieldSelected(this, new FieldSelectEventArgs(_item));
            }
        }

        public event EventHandler<EventArgs> MenuChanged;
        private void RaiseMenuChanged()
        {
            if (MenuChanged != null)
            {
                MenuChanged(this, new EventArgs());
            }
        }


        #endregion

        public SinoSZUC_MD_Model_FieldList()
        {
            InitializeComponent();
        }

        public void ShowFieldsList()
        {
            if (QueryModel == null) return;
            this.treeList1.BeginUpdate();
            IList<SinoSZUC_FieldTreeItem> _data = SinoSZUC_FieldTreeItem.GetListByQueryView(queryModel);
            SelectedFirstTable(_data);
            this.treeList1.DataSource = _data;
            this.treeList1.EndUpdate();
        }

        private void SelectedFirstTable(IList<SinoSZUC_FieldTreeItem> _data)
        {
            string _id = _data[0].ID;
            _data[0].State = 1;
            foreach (SinoSZUC_FieldTreeItem _citem in _data)
            {
                if (_citem.ParentID == _id && _citem.IsDefault)
                {
                    _citem.State = 2;
                }
            }
        }



        /// <summary>
        /// 显示单行默认结果列---(数据审核用)
        /// </summary>
        public void ShowSingleLineDefaultList()
        {
            if (QueryModel == null) return;
            this.treeList1.BeginUpdate();
            IList<SinoSZUC_FieldTreeItem> _data = SinoSZUC_FieldTreeItem.GetSingleLineDefaultListByQueryView(queryModel);
            this.treeList1.DataSource = _data;
            this.treeList1.EndUpdate();
            this.treeList1.ExpandAll();
        }

        private void treeList1_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {
            if ((string)e.Node.GetValue("ItemType") == "TABLE")
            {
                MDModel_Table _tb = e.Node.GetValue("Data") as MDModel_Table;
                if (_tb.TableDefine.ViewTableRelationType == MDType_ViewTableRelation.SingleChildRecord)
                {
                    e.NodeImageIndex = 0;
                }
                else
                {
                    e.NodeImageIndex = 1;
                }
            }
            else if ((string)e.Node.GetValue("ItemType") == "COLUMN")
            {
                MDModel_Table_Column _tc = e.Node.GetValue("Data") as MDModel_Table_Column;
                if (_tc.ColumnType == QueryColumnType.TableColumn)
                {
                    e.NodeImageIndex = 2;
                }
                else if (_tc.ColumnType == QueryColumnType.StatisticsColumn)
                {
                    e.NodeImageIndex = 4;
                }
                else if (_tc.ColumnType == QueryColumnType.CalculationColumn)
                {
                    e.NodeImageIndex = 3;
                }
            }
        }

        private void treeList1_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            int _st = (int)e.Node.GetValue("State");
            e.NodeImageIndex = _st;
        }

        private void treeList1_StateImageClick(object sender, DevExpress.XtraTreeList.NodeClickEventArgs e)
        {
            int _st = (int)e.Node.GetValue("State");
            string _type = (string)e.Node.GetValue("ItemType");
            bool _canResult = (bool)e.Node.GetValue("CanShowAsResult");

            _st += 1;
            if (_st > 2)
            {
                _st = 0;
            }
            else if (_type == "COLUMN" && _st == 1)
            {
                _st = 2;
            }
            if (_canResult)
            {
                e.Node.SetValue("State", _st);
            }
            else
            {
                e.Node.SetValue("State", 3);
            }

            if (_type == "COLUMN")
            {
                SetTableState(e.Node, _st);
            }
            else
            {
                SetColumnState(e.Node, _st);
            }
        }

        //通过对字段的状态的修改,自动改正表的状态
        private void SetTableState(TreeListNode _node, int _st)
        {
            TreeListNode _fnode = _node.ParentNode;
            if (_fnode == null) return;
            int _count = 0;
            foreach (TreeListNode _cnode in _fnode.Nodes)
            {
                int _state = (int)_cnode.GetValue("State");
                if (_state == 2) _count++;
            }

            if (_count == 0)
            {
                _fnode.SetValue("State", 0);
            }
            else if (_count == _fnode.Nodes.Count)
            {
                _fnode.SetValue("State", 2);
            }
            else
            {
                _fnode.SetValue("State", 1);
            }
        }

        //通过对表的状态修改,自动设置字段的状态
        private void SetColumnState(TreeListNode _node, int _st)
        {
            if (_st != 1)
            {
                SetAllChildColumnToState(_node, _st);
            }
            else
            {
                SetAllChildColumnToDefault(_node);
            }
        }

        private void SetAllChildColumnToDefault(TreeListNode _node)
        {
            for (int i = 0; i < _node.Nodes.Count; i++)
            {
                bool _isDefault = (bool)_node.Nodes[i]["IsDefault"];
                bool _canResult = (bool)_node.Nodes[i]["CanShowAsResult"];

                if (_isDefault && _canResult)
                {
                    _node.Nodes[i]["State"] = 2;
                }

            }
        }

        //所有表的字段全设置为同一个状态
        private void SetAllChildColumnToState(TreeListNode _node, int _st)
        {
            for (int i = 0; i < _node.Nodes.Count; i++)
            {
                bool _canResult = (bool)_node.Nodes[i]["CanShowAsResult"];
                if (_canResult)
                {
                    _node.Nodes[i]["State"] = _st;
                }
            }
        }


        private void treeList1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
        }

        private void treeList1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeListNode _node = this.treeList1.FocusedNode;
            if (_node != null)
            {
                string _itemType = (string)_node.GetValue("ItemType");
                if (_itemType == "COLUMN")
                {
                    MDModel_Table_Column _item = _node.GetValue("Data") as MDModel_Table_Column;
                    #region 设为选择此字段
                    bool _canResult = (bool)_node.GetValue("CanShowAsResult");
                    if (_canResult)
                    {
                        _node.SetValue("State", 2);
                    }
                    SetTableState(_node, 2);
                    #endregion

                    this.RaiseFieldSelected(_item);
                }
            }
        }

        public FrmMenuGroup GetMenuGroup()
        {
            bool _showSum = false;
            bool _showCompute = false;
            if (this.treeList1.FocusedNode != null)
            {
                if ((string)this.treeList1.FocusedNode.GetValue("ItemType") == "TABLE")
                {
                    _showCompute = true;
                    MDModel_Table _tb = this.treeList1.FocusedNode.GetValue("Data") as MDModel_Table;
                    if (_tb.TableName == this.queryModel.MainTable.TableName)
                    {
                        _showSum = true;
                    }
                }
            }

            FrmMenuGroup _thisGroup = new FrmMenuGroup("数据字段管理");

            _thisGroup.MenuItems = new List<FrmMenuItem>();
            FrmMenuItem _item = new FrmMenuItem("计算项字段", "计算项字段", global::SinoSZMetaDataQuery.Properties.Resources.b5, _showCompute);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("统计项字段", "统计项字段", global::SinoSZMetaDataQuery.Properties.Resources.b6, _showSum);
            _thisGroup.MenuItems.Add(_item);


            return _thisGroup;
        }

        public bool DoCommand(string _cmdName)
        {
            switch (_cmdName)
            {
                case "计算项字段":
                    InsertComputeField();
                    break;
                case "统计项字段":
                    InsertStatisticsField();
                    break;
            }

            return true;
        }

        private void InsertStatisticsField()
        {
            Dialog_CreateStatisticsField _f = new Dialog_CreateStatisticsField(this.QueryModel);
            if (_f.ShowDialog() == DialogResult.OK)
            {
                MDModel_Table _tb = this.queryModel.MainTable;
                AddStaticsticsField(_f.FieldName, _f.QueryString, _f.ResultDataType, _tb);
            }

        }

        private void AddStaticsticsField(string _fieldName, string _algorithm, string _resultType, MDModel_Table _tb)
        {
            MD_ViewTableColumn _vtc = new MD_ViewTableColumn("", "", "", true, true, false, false, false, "", 0, 0);
            _vtc.TableColumn = new MD_TableColumn("", "", "", true, "", 0, 0, 0, "", "", 0, "", "", 0, 0, 0, true, 0, "", "", "");
            MDModel_Table_Column _newtc = new MDModel_Table_Column(_vtc);
            _newtc.ColumnType = QueryColumnType.StatisticsColumn;
            _newtc.ColumnTitle = _fieldName;
            _newtc.ColumnName = _fieldName;
            _newtc.ColumnAlgorithm = _algorithm;
            _newtc.ColumnAlias = "EXP" + ExpIndex++;
            _newtc.QueryModelName = this.queryModel.FullQueryModelName;
            _newtc.ColumnDataType = _resultType;
            _newtc.TableName = _tb.TableName;
            _newtc.TID = _tb.TableID;
            _tb.Columns.Add(_newtc);
            _tb.AliasDict.Add(_newtc.ColumnAlias, _newtc);

            this.treeList1.BeginUpdate();
            SinoSZUC_FieldTreeItem _tcItem = new SinoSZUC_FieldTreeItem(_newtc);
            _tcItem.ParentID = _tb.TableDefine.TableID;
            _tcItem.State = 2;
            List<SinoSZUC_FieldTreeItem> _listData = this.treeList1.DataSource as List<SinoSZUC_FieldTreeItem>;
            _listData.Add(_tcItem);

            this.treeList1.EndUpdate();
            this.treeList1.RefreshDataSource();

        }

        private void InsertComputeField()
        {
            if (this.treeList1.FocusedNode == null) return;
            if ((string)this.treeList1.FocusedNode.GetValue("ItemType") == "TABLE")
            {

                MDModel_Table _tb = this.treeList1.FocusedNode.GetValue("Data") as MDModel_Table;

                Dialog_CreateComputeField _f = new Dialog_CreateComputeField(_tb);
                if (_f.ShowDialog() == DialogResult.OK)
                {

                    AddCalculationField(_f.DisplayName, _f.QueryString, this.queryModel.FullQueryModelName, _tb, _f.ResultDataType);
                }
            }
            return;
        }

        private void AddCalculationField(string _displayName, string _algorithm, string _queryModelName, MDModel_Table _tb, string _resultType)
        {
            MD_ViewTableColumn _vtc = new MD_ViewTableColumn("", "", "", true, true, false, false, false, "", 0, 0);
            _vtc.TableColumn = new MD_TableColumn("", "", "", true, _resultType, 0, 0, 0, "", "", 0, _displayName, "",
                80, 1, 0, true, 0, "", "", "");


            MDModel_Table_Column _newtc = new MDModel_Table_Column(_vtc);
            _newtc.ColumnType = QueryColumnType.CalculationColumn;
            _newtc.ColumnTitle = _displayName;
            _newtc.ColumnName = "";
            _newtc.ColumnAlgorithm = _algorithm;
            _newtc.ColumnAlias = _tb.TableName + "_EXP" + ExpIndex++;
            _newtc.QueryModelName = _queryModelName;
            _newtc.ColumnDataType = _resultType;
            _newtc.TableName = _tb.TableName;
            _newtc.TID = _tb.TableID;

            _tb.Columns.Add(_newtc);
            _tb.AliasDict.Add(_newtc.ColumnAlias, _newtc);

            this.treeList1.BeginUpdate();
            SinoSZUC_FieldTreeItem _tcItem = new SinoSZUC_FieldTreeItem(_newtc);
            _tcItem.ParentID = _tb.TableDefine.TableID;
            _tcItem.State = 2;
            List<SinoSZUC_FieldTreeItem> _listData = this.treeList1.DataSource as List<SinoSZUC_FieldTreeItem>;
            _listData.Add(_tcItem);

            this.treeList1.EndUpdate();
            this.treeList1.RefreshDataSource();

        }

        public void InsertResultFields2QueryRequest(MC_QueryRequsetFactory _queryRequestFactory)
        {
            _queryRequestFactory.AddResultTable(this.QueryModel.MainTable);
            foreach (TreeListNode _node in this.treeList1.Nodes)
            {
                string _itemType = (string)_node.GetValue("ItemType");
                if (_itemType == "TABLE")
                {
                    //如果是表则处理                              
                    int _state = (int)_node.GetValue("State");
                    if (_state > 0)
                    {
                        //如果是选中部分或全选中状态
                        MDModel_Table _ctable = _node.GetValue("Data") as MDModel_Table;
                        _queryRequestFactory.AddResultTable(_ctable);
                        AddTableColumn(_queryRequestFactory, _ctable, _node);
                    }
                }
            }
        }


        public bool CheckItems(ref string _errorMsg)
        {
            int _count = 0;
            foreach (TreeListNode _node in this.treeList1.Nodes)
            {
                string _itemType = (string)_node.GetValue("ItemType");
                if (_itemType == "TABLE")
                {
                    //如果是表则处理                              
                    int _state = (int)_node.GetValue("State");
                    if (_state > 0)
                    {
                        //如果是选中部分或全选中状态
                        _count++;
                    }
                }

            }
            if (_count > 0)
            {
                return true;
            }
            else
            {
                _errorMsg = "未选择查询结果字段!";
                return false;
            }
        }

        private void AddTableColumn(MC_QueryRequsetFactory _queryRequestFactory, MDModel_Table _mtable, TreeListNode _fnode)
        {
            foreach (TreeListNode _cnode in _fnode.Nodes)
            {
                string _itemType = (string)_cnode.GetValue("ItemType");
                if (_itemType == "COLUMN")
                {
                    //如果是表则处理                              
                    int _state = (int)_cnode.GetValue("State");
                    if (_state > 0 && _state < 3)
                    {
                        //如果是选中部分或全选中状态
                        MDModel_Table_Column _mColumn = _cnode.GetValue("Data") as MDModel_Table_Column;
                        _queryRequestFactory.AddResultTableColumn(_mtable, _mColumn);
                    }
                }
            }
        }



        /// <summary>
        /// 用保存的查询请求更新此控件
        /// </summary>
        /// <param name="_request"></param>
        public void RefreshBySaveRequest(MDQuery_Request _request)
        {
            //清除选择
            foreach (TreeListNode _node in this.treeList1.Nodes)
            {
                _node.SetValue("State", 0);
                foreach (TreeListNode _cnode in _node.Nodes)
                {
                    _cnode.SetValue("State", 0);
                }
            }

            //选择
            MDQuery_ResultTable _mtable = _request.MainResultTable;
            RefreshTableSelected(_mtable);

            foreach (MDQuery_ResultTable _ctable in _request.ChildResultTables)
            {
                RefreshTableSelected(_ctable);
            }
        }

        private void RefreshTableSelected(MDQuery_ResultTable _mtable)
        {
            TreeListNode _mtableNode = FindTableNode(_mtable.TableName);
            MDModel_Table _tb = _mtableNode.GetValue("Data") as MDModel_Table;
            if (_mtableNode != null)
            {
                foreach (TreeListNode _cnode in _mtableNode.Nodes)
                {
                    MDModel_Table_Column _mColumn = _cnode.GetValue("Data") as MDModel_Table_Column;
                    var _find = from _c in _mtable.Columns
                                where _c.ColumnName == _mColumn.ColumnName
                                select _c;
                    if (_find != null && _find.Count() > 0)
                    {
                        _cnode.SetValue("State", 2);
                        SetTableState(_cnode, 2);
                    }
                }

                foreach (MDQuery_TableColumn _rtc in _mtable.Columns)
                {

                    if (_rtc.ColumnType == QueryColumnType.CalculationColumn)
                    {
                        AddCalculationField(_rtc.ColumnTitle, _rtc.ColumnAlgorithm, this.queryModel.FullQueryModelName, _tb,
                            _rtc.ColumnDataType);
                    }

                    if (_rtc.ColumnType == QueryColumnType.StatisticsColumn)
                    {
                        AddStaticsticsField(_rtc.ColumnTitle, _rtc.ColumnAlgorithm, _rtc.ColumnDataType, _tb);
                    }
                }
            }
        }

        /// <summary>
        /// 通过表名选节点
        /// </summary>
        /// <param name="_tName"></param>
        /// <returns></returns>
        private TreeListNode FindTableNode(string _tName)
        {
            foreach (TreeListNode _node in this.treeList1.Nodes)
            {
                string _itemType = (string)_node.GetValue("ItemType");
                if (_itemType == "TABLE")
                {
                    MDModel_Table _table = _node.GetValue("Data") as MDModel_Table;
                    if (_table.TableName == _tName)
                    {
                        return _node;
                    }
                }
            }
            return null;

        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            RaiseMenuChanged();
        }
    }
}
