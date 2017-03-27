using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Reflection;
using System.Runtime.Remoting.Lifetime;
using SinoSZJS.Base.Misc;
using System.Timers;
using SinoSZJS.CS.BizMetaDataManager.DAL;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.InputModel;
using SinoSZJS.Base.MetaData.EnumDefine;
using SinoSZJS.Base.MetaData.Define;
using SinoSZJS.Base.IMetaData;

namespace SinoSZJS.CS.BizMetaDataManager
{
    public class BIZ_MetaDataManager : IMetaDataFactroy
    {
        private static IMetaDataFactroy _imetaDataFactroy;
        public static IMetaDataFactroy MetaDataFactroy
        {
            get
            {
                if (_imetaDataFactroy == null)
                {
                    _imetaDataFactroy = GetDataConfig();
                }
                return _imetaDataFactroy;
            }

            set
            {
                _imetaDataFactroy = value;
            }
        }

        #region IMetaDataFactroy Members



        public bool SaveQueryModel_UserDefine(string _queryModelID, string _display, string _descript)
        {
            return MetaDataFactroy.SaveQueryModel_UserDefine(_queryModelID, _display, _descript);
        }

        public MD_QueryModel GetQueryModelByName(string modelName)
        {
            return MetaDataFactroy.GetQueryModelByName(modelName);
        }

        public MD_QueryModel GetQueryModelByName(string modelName, string nameSpace)
        {
            return MetaDataFactroy.GetQueryModelByName(modelName, nameSpace);
        }

        public MD_QueryModelGroup GetQueryModelGroup(string queryModelGroupID)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public MD_QueryModelGroup GetQueryModelGroup(string queryModelGroupID, string nameSpace)
        {
            return MetaDataFactroy.GetQueryModelGroup(queryModelGroupID, nameSpace);
        }

        public MD_RefTable GetRefTable(string refTableName)
        {
            return MetaDataFactroy.GetRefTable(refTableName);
        }

        public MD_RefTable GetRefTable(string refTableName, string nameSpace)
        {
            return MetaDataFactroy.GetRefTable(refTableName, nameSpace);
        }

        public MD_QueryModel GetQueryModelByID(string modelID)
        {
            return MetaDataFactroy.GetQueryModelByID(modelID);
        }

        public MD_QueryModel GetQueryModelByID(string modelID, string nameSpace)
        {
            return MetaDataFactroy.GetQueryModelByID(modelID, nameSpace);
        }

        public IList<MD_Nodes> GetNodeList()
        {
            return MetaDataFactroy.GetNodeList();
        }

        public IList<MD_Namespace> GetNameSpaceAtNode(string NodeDWDM)
        {
            return MetaDataFactroy.GetNameSpaceAtNode(NodeDWDM);
        }

        public bool SaveNewNameSapce(MD_Namespace _ns)
        {
            return MetaDataFactroy.SaveNewNameSapce(_ns);
        }

        public bool SaveNodes(MD_Nodes _nodes)
        {
            return MetaDataFactroy.SaveNodes(_nodes);
        }

        public bool SaveNewNodes(MD_Nodes _nodes)
        {
            return MetaDataFactroy.SaveNewNodes(_nodes);
        }

        public bool DelNodes(string _node)
        {
            return MetaDataFactroy.DelNodes(_node);
        }

        public bool SaveNameSapce(MD_Namespace _Namespace)
        {
            return MetaDataFactroy.SaveNameSapce(_Namespace);
        }

        public bool DelNamespace(MD_Namespace _ns)
        {
            return MetaDataFactroy.DelNamespace(_ns);
        }

        public IList<DB_TableMeta> GetDBTableList()
        {
            return MetaDataFactroy.GetDBTableList();
        }

        public IList<DB_TableMeta> GetDBTableListOfDMB()
        {
            return MetaDataFactroy.GetDBTableListOfDMB();
        }

        public IList<DB_ColumnMeta> GetDBColumnsOfTable(string _tableName)
        {
            return MetaDataFactroy.GetDBColumnsOfTable(_tableName);
        }

        public bool SaveNewTable(DB_TableMeta _tm, MD_Namespace _ns)
        {
            return MetaDataFactroy.SaveNewTable(_tm, _ns);
        }

        public IList<MD_Table> GetTablesAtNamespace(MD_Namespace _ns)
        {
            return MetaDataFactroy.GetTablesAtNamespace(_ns);
        }

        public MD_Table GetTableByTableID(string _tid)
        {
            return MetaDataFactroy.GetTableByTableID(_tid);
        }

        public IList<MD_QueryModel> GetQueryModelAtNamespace(MD_Namespace _ns)
        {
            return MetaDataFactroy.GetQueryModelAtNamespace(_ns);
        }

        public IList<MD_RefTable> GetRefTableAtNamespace(MD_Namespace _ns)
        {
            return MetaDataFactroy.GetRefTableAtNamespace(_ns);
        }

        public IList<MD_TableColumn> GetColumnsOfTable(string _tid)
        {
            return MetaDataFactroy.GetColumnsOfTable(_tid);
        }

        public MD_ViewTable GetMainTableOfQueryModel(MD_QueryModel _qm)
        {
            return MetaDataFactroy.GetMainTableOfQueryModel(_qm);
        }

        public string GetNewID()
        {
            return MetaDataFactroy.GetNewID();
        }

        public bool SaveTableDefine(MD_Table _table)
        {
            return MetaDataFactroy.SaveTableDefine(_table);
        }

        public bool SaveNewQueryModel(MD_QueryModel _queryModel)
        {
            return MetaDataFactroy.SaveNewQueryModel(_queryModel);
        }

        public bool SaveQueryModel(MD_QueryModel _queryModel)
        {
            return MetaDataFactroy.SaveQueryModel(_queryModel);
        }

        public bool SaveViewMainTable(MD_ViewTable _viewtable)
        {
            return MetaDataFactroy.SaveViewMainTable(_viewtable);
        }

        public IList<MD_ViewTable> GetChildTableOfQueryModel(MD_QueryModel _queryModel)
        {
            return MetaDataFactroy.GetChildTableOfQueryModel(_queryModel);
        }

        public bool SaveViewChildTable(MD_ViewTable _viewtable)
        {
            return MetaDataFactroy.SaveViewChildTable(_viewtable);
        }

        public bool AddMainTableToQueryModel(string _queryModelID, MD_Table _selectedTable)
        {
            return MetaDataFactroy.AddMainTableToQueryModel(_queryModelID, _selectedTable);
        }

        public bool AddChildTableToQueryModel(string _queryModelID, string _mainTableID, MD_Table _selectedTable)
        {
            return MetaDataFactroy.AddChildTableToQueryModel(_queryModelID, _mainTableID, _selectedTable);
        }

        public bool IsExistChildTable(string _viewTableID)
        {
            return MetaDataFactroy.IsExistChildTable(_viewTableID);
        }

        public bool DelViewTable(string _viewTableID)
        {
            return MetaDataFactroy.DelViewTable(_viewTableID);
        }

        public bool IsExistChildOfView(string _queryModelID)
        {
            return MetaDataFactroy.IsExistChildOfView(_queryModelID);
        }

        public bool DelViewMeta(string _queryModelID)
        {
            return MetaDataFactroy.DelViewMeta(_queryModelID);
        }

        public bool DelViewAndChildren(string QueryModelID)
        {
            return MetaDataFactroy.DelViewAndChildren(QueryModelID);
        }

        public bool IsExistViewUsedTable(string _tableID)
        {
            return MetaDataFactroy.IsExistViewUsedTable(_tableID);
        }

        public bool DelTableMeta(string _tableID)
        {
            return MetaDataFactroy.DelTableMeta(_tableID);
        }

        public bool SaveNewRefTable(DB_TableMeta _tm, MD_Namespace _namespace)
        {
            return MetaDataFactroy.SaveNewRefTable(_tm, _namespace);
        }

        public System.Data.DataTable Get_RefTableColumn(MD_RefTable _refTable)
        {
            return MetaDataFactroy.Get_RefTableColumn(_refTable);
        }

        public bool SaveRefTable(MD_RefTable _refTable, System.Data.DataTable _refData)
        {
            return MetaDataFactroy.SaveRefTable(_refTable, _refData);
        }

        public IList<MD_Menu> GetMenuDefineOfNode(string _nodeCode)
        {
            return MetaDataFactroy.GetMenuDefineOfNode(_nodeCode);
        }

        public IList<MD_Menu> GetSubMenuDefine(string _fmenuID)
        {
            return MetaDataFactroy.GetSubMenuDefine(_fmenuID);
        }

        public bool SaveMenuDefine(MD_Menu _menu)
        {
            return MetaDataFactroy.SaveMenuDefine(_menu);
        }

        public bool AddSystemMenu(string _nodeCode)
        {
            return MetaDataFactroy.AddSystemMenu(_nodeCode);
        }

        public bool AddSystemSubMenu(string _fatherMenuID, string _nodeID)
        {
            return MetaDataFactroy.AddSystemSubMenu(_fatherMenuID, _nodeID);
        }

        public bool DelSystemMenu(string _menuid)
        {
            return MetaDataFactroy.DelSystemMenu(_menuid);
        }

        public IList<MD_GuideLineGroup> GetGuideLineGroup(string _nodeCode, string _guideLineGroupType)
        {
            return MetaDataFactroy.GetGuideLineGroup(_nodeCode, _guideLineGroupType);
        }

        public IList<MD_GuideLine> GetGuideLineOfGroup(string _groupName)
        {
            return MetaDataFactroy.GetGuideLineOfGroup(_groupName);
        }

        public bool SaveGuideLineGroupDefine(MD_GuideLineGroup _GuideLineGroup)
        {
            return MetaDataFactroy.SaveGuideLineGroupDefine(_GuideLineGroup);
        }

        public IList<MD_GuideLine> GetChildGuideLines(string _fatherGuildLineID)
        {
            return MetaDataFactroy.GetChildGuideLines(_fatherGuildLineID);
        }

        public bool DelGuideLineGroup(string _guideLineGroupName)
        {
            return MetaDataFactroy.DelGuideLineGroup(_guideLineGroupName);
        }

        public bool IsExistChildOfGuideLineGroup(string _guideLineGroupName)
        {
            return MetaDataFactroy.IsExistChildOfGuideLineGroup(_guideLineGroupName);
        }

        public bool SaveNewGuideLineGroupDefine(MD_GuideLineGroup _guideLineGroup)
        {
            return MetaDataFactroy.SaveNewGuideLineGroupDefine(_guideLineGroup);
        }

        public bool IsExistGuideLineGroupName(string _guideLineGroupName)
        {
            return MetaDataFactroy.IsExistGuideLineGroupName(_guideLineGroupName);
        }

        public bool SaveNewGuideLine(string _guideLineName, decimal _fid, string _guideLineGroupName)
        {
            return MetaDataFactroy.SaveNewGuideLine(_guideLineName, _fid, _guideLineGroupName);
        }

        public bool IsExistChildOfGuideLine(string _guideLineID)
        {
            return MetaDataFactroy.IsExistChildOfGuideLine(_guideLineID);
        }

        public bool DelGuideLine(string _guideLineID)
        {
            return MetaDataFactroy.DelGuideLine(_guideLineID);
        }

        public bool SaveGuideLine(MD_GuideLine _guideLine)
        {
            return MetaDataFactroy.SaveGuideLine(_guideLine);
        }

        public IList<MD_ConceptGroup> GetConceptGroups()
        {
            return MetaDataFactroy.GetConceptGroups();
        }

        public bool SaveConceptGroup(MD_ConceptGroup _ConceptGroup)
        {
            return MetaDataFactroy.SaveConceptGroup(_ConceptGroup);
        }


        public bool IsExistConceptGroup(string _groupName)
        {
            return MetaDataFactroy.IsExistConceptGroup(_groupName);
        }

        public bool AddNewConceptGroup(string _groupName)
        {
            return MetaDataFactroy.AddNewConceptGroup(_groupName);
        }

        public bool DelConcpetGroup(string _groupName)
        {
            return MetaDataFactroy.DelConcpetGroup(_groupName);
        }

        public bool IsExistChildOfConceptGroup(string _groupName)
        {
            return MetaDataFactroy.IsExistChildOfConceptGroup(_groupName);
        }

        public bool IsExistConceptTag(string _TagName)
        {
            return MetaDataFactroy.IsExistConceptTag(_TagName);
        }

        public bool AddNewConceptTag(string _TagName, string _description, string _groupName)
        {
            return MetaDataFactroy.AddNewConceptTag(_TagName, _description, _groupName);
        }

        public bool SaveConceptTag(MD_ConceptItem _ConceptItem)
        {
            return MetaDataFactroy.SaveConceptTag(_ConceptItem);
        }

        public List<MD_ConceptItem> GetSubConceptTagDefine(string _groupName)
        {
            return MetaDataFactroy.GetSubConceptTagDefine(_groupName);
        }

        public bool DelConceptTag(string _CTag)
        {
            return MetaDataFactroy.DelConceptTag(_CTag);
        }

        public MD_GuideLine GetGuideLineDefine(string _guideLineID)
        {
            return MetaDataFactroy.GetGuideLineDefine(_guideLineID);
        }

        public bool SaveNewGuideLine(MD_GuideLine _guideLine)
        {
            return MetaDataFactroy.SaveNewGuideLine(_guideLine);
        }

        public bool IsExistGuideLineID(string _guideLineID)
        {
            return MetaDataFactroy.IsExistGuideLineID(_guideLineID);
        }

        public List<MD_RightDefine> GetRightData()
        {
            return MetaDataFactroy.GetRightData();
        }

        public List<MD_RightDefine> GetRightData(string SystemID)
        {
            return MetaDataFactroy.GetRightData(SystemID);
        }

        public bool SaveRightDefine(List<MD_RightDefine> _rightList)
        {
            return MetaDataFactroy.SaveRightDefine(_rightList);
        }

        public bool ImportTableDefine(MD_Table _tableDefine)
        {
            return MetaDataFactroy.ImportTableDefine(_tableDefine);
        }



        public bool ImportRefTableDefine(MD_RefTable _rt)
        {
            return MetaDataFactroy.ImportRefTableDefine(_rt);
        }

        public bool ImportQueryModelDefine(MD_QueryModel _qv)
        {
            return MetaDataFactroy.ImportQueryModelDefine(_qv);
        }

        public string AddTableRelationView(string _tableID, string _modelName)
        {
            return MetaDataFactroy.AddTableRelationView(_tableID, _modelName);
        }


        public List<string> GetAllQueryModelNames()
        {
            return MetaDataFactroy.GetAllQueryModelNames();
        }


        public List<MD_Table2View> GetTable2ViewList(string _tid)
        {
            try
            {
                return MetaDataFactroy.GetTable2ViewList(_tid);
            }
            catch (Exception e)
            {
                return new List<MD_Table2View>();
            }
        }

        #endregion

        #region 私有方法

        private static IMetaDataFactroy GetDataConfig()
        {

            OraMetaDataFactroy _of = new OraMetaDataFactroy();
            return _of as IMetaDataFactroy;
        }


        public bool SaveViewTable_UserDefine(string _viewTableID, string _displayString, MDType_DisplayType _displayType, List<MD_ViewTableColumn> TableColumnDefine)
        {
            try
            {
                return MetaDataFactroy.SaveViewTable_UserDefine(_viewTableID, _displayString, _displayType, TableColumnDefine);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void SaveViewTableOrder_UserDefine(Dictionary<string, int> ChildTableOrder)
        {

            MetaDataFactroy.SaveViewTableOrder_UserDefine(ChildTableOrder);

        }



        public IList<MD_InputModel> GetInputModelOfNamespace(string _namespace)
        {
            return MetaDataFactroy.GetInputModelOfNamespace(_namespace);
        }

        public IList<MD_View_GuideLine> GetView2GuideLineList(string QueryModelID)
        {
            return MetaDataFactroy.GetView2GuideLineList(QueryModelID);
        }

        #endregion

        #region IMetaDataFactroy Members


        public MD_InputModel GetInputModel(string _namespace, string ModelName)
        {
            return MetaDataFactroy.GetInputModel(_namespace, ModelName);
        }

        public bool SaveNewInputModel(string _namespace, MD_InputModel SaveModel)
        {
            return MetaDataFactroy.SaveNewInputModel(_namespace, SaveModel);
        }

        public bool DelInputModel(string InputModelID)
        {
            return MetaDataFactroy.DelInputModel(InputModelID);
        }

        public bool SaveInputModel(MD_InputModel SaveModel)
        {
            return MetaDataFactroy.SaveInputModel(SaveModel);
        }

        public bool AddNewInputModelGroup(MD_InputModel_ColumnGroup Group)
        {
            return MetaDataFactroy.AddNewInputModelGroup(Group);
        }

        public bool DelInputModelColumnGroup(string InputModelID, string GroupID)
        {
            return MetaDataFactroy.DelInputModelColumnGroup(InputModelID, GroupID);
        }

        public bool InputModel_MoveColumnToGroup(MD_InputModel_Column _col, MD_InputModel_ColumnGroup mD_InputModel_ColumnGroup)
        {
            return MetaDataFactroy.InputModel_MoveColumnToGroup(_col, mD_InputModel_ColumnGroup);
        }

        public bool SaveInputModelColumnGroup(MD_InputModel_ColumnGroup _group)
        {
            return MetaDataFactroy.SaveInputModelColumnGroup(_group);
        }

        public bool FindInputModelColumnByName(string InputModelID, string ColumnName)
        {
            return MetaDataFactroy.FindInputModelColumnByName(InputModelID, ColumnName);
        }

        public bool AddNewInputModelColumn(string InputModelID, string GroupID, string ColumnName)
        {
            return MetaDataFactroy.AddNewInputModelColumn(InputModelID, GroupID, ColumnName);
        }

        public bool DelInputModelColumn(string ColumnID)
        {
            return MetaDataFactroy.DelInputModelColumn(ColumnID);
        }

        public bool OracleTableExist(string TableName)
        {
            return MetaDataFactroy.OracleTableExist(TableName);
        }

        public bool AddNewInputModelSavedTable(string InputModelID, string TableName)
        {
            return MetaDataFactroy.AddNewInputModelSavedTable(InputModelID, TableName);
        }

        public bool DelInputModelSavedTable(string TableID)
        {
            return MetaDataFactroy.DelInputModelSavedTable(TableID);
        }

        public bool SaveInputModelSaveTable(MD_InputModel_SaveTable _newTable)
        {
            return MetaDataFactroy.SaveInputModelSaveTable(_newTable);
        }




        public bool AddInputModelTableColumn(string TableName, string AddFieldName, string DataType)
        {
            return MetaDataFactroy.AddInputModelTableColumn(TableName, AddFieldName, DataType);
        }

        #endregion

        #region IMetaDataFactroy Members


        public List<string> GetDBPrimayKeyList(string TableName)
        {
            return MetaDataFactroy.GetDBPrimayKeyList(TableName);
        }

        public bool DelInputModelTableColumn(string TableName, string DelFieldName)
        {
            return MetaDataFactroy.DelInputModelTableColumn(TableName, DelFieldName);
        }




        public bool AddChildInputModel(string MainModelID, string ChildModelID)
        {
            return MetaDataFactroy.AddChildInputModel(MainModelID, ChildModelID);
        }

        public bool SaveInputModelChildDefine(MD_InputModel_Child InputModelChild)
        {
            return MetaDataFactroy.SaveInputModelChildDefine(InputModelChild);
        }

        #endregion

        #region IMetaDataFactroy Members


        public bool DelRefTable(string RefTableID)
        {
            return MetaDataFactroy.DelRefTable(RefTableID);
        }




        public bool DelInputModelChild(string ChildModelID)
        {
            return MetaDataFactroy.DelInputModelChild(ChildModelID);
        }

        #endregion



        #region IMetaDataFactroy Members


        public bool IsExistID(string _oldid, string _tname, string _colname)
        {
            try
            {
                return MetaDataFactroy.IsExistID(_oldid, _tname, _colname);
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public List<MD_View2ViewGroup> GetView2ViewGroupOfQueryModel(string ViewID)
        {
            try
            {
                return MetaDataFactroy.GetView2ViewGroupOfQueryModel(ViewID);
            }
            catch (Exception e)
            {
                return null;
            }
        }



        public string AddView2ViewGroup(string ViewID)
        {
            try
            {
                return MetaDataFactroy.AddView2ViewGroup(ViewID);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }



        public bool SaveView2ViewGroup(MD_View2ViewGroup View2ViewGroup)
        {
            try
            {
                return MetaDataFactroy.SaveView2ViewGroup(View2ViewGroup);
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public List<MD_View2View> GetView2ViewList(string GroupID, string ViewID)
        {
            try
            {
                return MetaDataFactroy.GetView2ViewList(GroupID, ViewID);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public string DelView2ViewGroup(string GroupID)
        {
            try
            {
                return MetaDataFactroy.DelView2ViewGroup(GroupID);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        public string AddView2View(string ViewID, string GroupID)
        {
            try
            {
                return MetaDataFactroy.AddView2View(ViewID, GroupID);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        public bool SaveView2View(MD_View2View View2View)
        {
            try
            {
                return MetaDataFactroy.SaveView2View(View2View);
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public string CMD_DelView2View(string v2vid)
        {
            try
            {
                return MetaDataFactroy.CMD_DelView2View(v2vid);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        public List<MD_QueryModel_ExRight> GetQueryModelExRights(string QueryModelID, string FatherID)
        {
            try
            {
                return MetaDataFactroy.GetQueryModelExRights(QueryModelID, FatherID);
            }
            catch (Exception e)
            {
                return new List<MD_QueryModel_ExRight>();
            }
        }



        public bool AddNewViewExRight(string RightValue, string RightTitle, string ViewID, MD_QueryModel_ExRight FatherRight)
        {
            try
            {
                return MetaDataFactroy.AddNewViewExRight(RightValue, RightTitle, ViewID, FatherRight);
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public bool SaveQueryModelExRight(MD_QueryModel_ExRight ExRight)
        {
            try
            {
                return MetaDataFactroy.SaveQueryModelExRight(ExRight);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string CMD_DelViewExRight(MD_QueryModel_ExRight ExRight)
        {
            return MetaDataFactroy.CMD_DelViewExRight(ExRight);
        }

        public bool SaveView2GL(string V2GID, string VIEWID, string GuideLineID, string Params, int DisplayOrder, string DisplayTitle)
        {
            return MetaDataFactroy.SaveView2GL(V2GID, VIEWID, GuideLineID, Params, DisplayOrder, DisplayTitle);
        }

        public string CMD_DelView2GL(MD_View_GuideLine View2GL)
        {
            return MetaDataFactroy.CMD_DelView2GL(View2GL);
        }

        #endregion
    }
}
