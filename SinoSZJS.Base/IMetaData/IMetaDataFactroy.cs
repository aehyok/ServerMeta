using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.InputModel;
using SinoSZJS.Base.MetaData.Define;
using SinoSZJS.Base.MetaData.EnumDefine;

namespace SinoSZJS.Base.IMetaData
{
    public interface IMetaDataFactroy
    {
        MD_QueryModel GetQueryModelByName(string modelName);

        MD_QueryModel GetQueryModelByName(string modelName, string nameSpace);

        MD_QueryModelGroup GetQueryModelGroup(string queryModelGroupID);

        MD_QueryModelGroup GetQueryModelGroup(string queryModelGroupID, string nameSpace);

        MD_RefTable GetRefTable(string refTableName);

        MD_RefTable GetRefTable(string refTableName, string nameSpace);

        MD_QueryModel GetQueryModelByID(string modelID);

        MD_QueryModel GetQueryModelByID(string modelID, string nameSpace);

        IList<MD_Nodes> GetNodeList();

        IList<MD_Namespace> GetNameSpaceAtNode(string _nodeDWDM);

        /// <summary>
        /// 保存新的命名空间
        /// </summary>
        /// <param name="_ns"></param>
        /// <returns></returns>
        bool SaveNewNameSapce(MD_Namespace _ns);

        /// <summary>
        /// 保存修改的节点信息
        /// </summary>
        /// <param name="_nodes"></param>
        bool SaveNodes(MD_Nodes _nodes);

        /// <summary>
        /// 保存新的节点信息
        /// </summary>
        /// <param name="_nodes"></param>
        /// <returns></returns>
        bool SaveNewNodes(MD_Nodes _nodes);

        /// <summary>
        /// 删除节点信息
        /// </summary>
        /// <param name="_node"></param>
        /// <returns></returns>
        bool DelNodes(string _nodeID);

        /// <summary>
        /// 保存命名空间信息
        /// </summary>
        /// <param name="mD_Namespace"></param>
        /// <returns></returns>
        bool SaveNameSapce(MD_Namespace _Namespace);

        /// <summary>
        /// 删除命名空间
        /// </summary>
        /// <param name="_ns"></param>
        /// <returns></returns>
        bool DelNamespace(MD_Namespace _ns);

        /// <summary>
        /// 取数据库中的表的列表
        /// </summary>
        /// <returns></returns>
        IList<DB_TableMeta> GetDBTableList();


        /// <summary>
        /// 取数据库中的代码表
        /// </summary>
        /// <returns></returns>
        IList<DB_TableMeta> GetDBTableListOfDMB();

        /// <summary>
        /// 从数据库中取表的字段定义
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        IList<DB_ColumnMeta> GetDBColumnsOfTable(string _tableName);

        /// <summary>
        /// 将新的表存入元数据
        /// </summary>
        /// <param name="_tm"></param>
        /// <returns></returns>
        bool SaveNewTable(DB_TableMeta _tm, MD_Namespace _ns);

        /// <summary>
        /// 取命名空间下的表的列表
        /// </summary>
        /// <param name="_ns"></param>
        /// <returns></returns>
        IList<MD_Table> GetTablesAtNamespace(MD_Namespace _ns);

        /// <summary>
        /// 取指定表ID的表定义
        /// </summary>
        /// <param name="_tid"></param>
        /// <returns></returns>
        MD_Table GetTableByTableID(string _tid);

        /// <summary>
        /// 取命名空间下的查询模型
        /// </summary>
        /// <param name="_ns"></param>
        /// <returns></returns>
        IList<MD_QueryModel> GetQueryModelAtNamespace(MD_Namespace _ns);

        /// <summary>
        /// 取命名空间下的代码表
        /// </summary>
        /// <param name="_ns"></param>
        /// <returns></returns>
        IList<MD_RefTable> GetRefTableAtNamespace(MD_Namespace _ns);

        /// <summary>
        /// 取表的列定义
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        IList<MD_TableColumn> GetColumnsOfTable(string _tid);

        /// <summary>
        /// 取查询模型的主表
        /// </summary>
        /// <param name="_qm"></param>
        /// <returns></returns>
        MD_ViewTable GetMainTableOfQueryModel(MD_QueryModel _qm);

        /// <summary>
        /// 取最新的序列产生器的值
        /// </summary>
        /// <returns></returns>
        string GetNewID();

        /// <summary>
        /// 保存表定义
        /// </summary>
        /// <param name="mD_Table"></param>
        /// <returns></returns>
        bool SaveTableDefine(MD_Table _table);

        /// <summary>
        /// 保存新的查询模型
        /// </summary>
        /// <param name="_queryModel"></param>
        bool SaveNewQueryModel(MD_QueryModel _queryModel);

        /// <summary>
        /// 保存查询模型定义
        /// </summary>
        /// <param name="_queryModel"></param>
        /// <returns></returns>
        bool SaveQueryModel(MD_QueryModel _queryModel);

        /// <summary>
        ///　保存查询模型主表定义
        /// </summary>
        /// <param name="_viewtable"></param>
        /// <returns></returns>
        bool SaveViewMainTable(MD_ViewTable _viewtable);

        /// <summary>
        /// 取查询模型主表的子表
        /// </summary>
        /// <param name="mD_QueryModel"></param>
        /// <returns></returns>
        IList<MD_ViewTable> GetChildTableOfQueryModel(MD_QueryModel _queryModel);

        /// <summary>
        /// 保存查询模型副表定义
        /// </summary>
        /// <param name="_viewtable"></param>
        /// <returns></returns>
        bool SaveViewChildTable(MD_ViewTable _viewtable);


        /// <summary>
        /// 向查询模型里添加主表
        /// </summary>
        /// <param name="p"></param>
        /// <param name="_selectedTable"></param>
        /// <returns></returns>
        bool AddMainTableToQueryModel(string _queryModelID, MD_Table _selectedTable);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        /// <param name="_selectedTable"></param>
        /// <returns></returns>
        bool AddChildTableToQueryModel(string _queryModelID, string _mainTableID, MD_Table _selectedTable);

        /// <summary>
        /// 指定的表是否有子表
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        bool IsExistChildTable(string _viewTableID);

        /// <summary>
        /// 删除查询模型中的表
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        bool DelViewTable(string _viewTableID);

        /// <summary>
        /// 指定查询模型中是否有表
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        bool IsExistChildOfView(string _queryModelID);

        /// <summary>
        /// 删除查询模型
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        bool DelViewMeta(string _queryModelID);

        /// <summary>
        /// 删除查询模型及其主表子表等子定义
        /// </summary>
        /// <param name="QueryModelID"></param>
        /// <returns></returns>
        bool DelViewAndChildren(string QueryModelID);

        /// <summary>
        /// 是否存在使用此表的查询模型
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        bool IsExistViewUsedTable(string _tableID);

        /// <summary>
        /// 删除指定的数据表
        /// </summary>
        /// <param name="_tableID"></param>
        /// <returns></returns>
        bool DelTableMeta(string _tableID);

        /// <summary>
        /// 保存新的代码表
        /// </summary>
        /// <param name="_tm"></param>
        /// <param name="_namespace"></param>
        /// <returns></returns>
        bool SaveNewRefTable(DB_TableMeta _tm, MD_Namespace _namespace);

        /// <summary>
        /// 取代码表中的记录
        /// </summary>
        /// <param name="_refTable"></param>
        /// <returns></returns>
        DataTable Get_RefTableColumn(MD_RefTable _refTable);

        /// <summary>
        /// 保存代码表内容
        /// </summary>
        /// <param name="_refTable"></param>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        bool SaveRefTable(MD_RefTable _refTable, DataTable _refData);

        /// <summary>
        /// 取指定节点下的一级菜单
        /// </summary>
        /// <param name="_node"></param>
        /// <returns></returns>
        IList<MD_Menu> GetMenuDefineOfNode(string _nodeCode);

        /// <summary>
        /// 取指定菜单项下的子菜单
        /// </summary>
        /// <param name="_fmenuID"></param>
        /// <returns></returns>
        IList<MD_Menu> GetSubMenuDefine(string _fmenuID);

        /// <summary>
        /// 保存菜单定义
        /// </summary>
        /// <param name="_menu"></param>
        /// <returns></returns>
        bool SaveMenuDefine(MD_Menu _menu);

        /// <summary>
        /// 添加系统菜单
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        bool AddSystemMenu(string _nodeCode);


        /// <summary>
        /// 添加子菜单
        /// </summary>
        /// <param name="_fatherMenuID"></param>
        /// <param name="_nodeID"></param>
        /// <returns></returns>
        bool AddSystemSubMenu(string _fatherMenuID, string _nodeID);


        /// <summary>
        /// 删除系统菜单
        /// </summary>
        /// <param name="_menuid"></param>
        /// <returns></returns>
        bool DelSystemMenu(string _menuid);

        /// <summary>
        /// 取指定节点下的指标定义组
        /// </summary>
        /// <param name="_nodeCode">节点名称</param>
        /// <param name="_guideLineGroupType">组类型</param>
        /// <returns></returns>
        IList<MD_GuideLineGroup> GetGuideLineGroup(string _nodeCode, string _guideLineGroupType);

        /// <summary>
        /// 取指定指标组下的指标列表
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        IList<MD_GuideLine> GetGuideLineOfGroup(string _groupName);

        /// <summary>
        /// 保存指标组的定义
        /// </summary>
        /// <param name="mD_GuideLineGroup"></param>
        /// <returns></returns>
        bool SaveGuideLineGroupDefine(MD_GuideLineGroup _GuideLineGroup);

        /// <summary>
        /// 取指定指标下的子指标列表
        /// </summary>
        /// <param name="_fatherGuildLineID"></param>
        /// <returns></returns>
        IList<MD_GuideLine> GetChildGuideLines(string _fatherGuildLineID);

        /// <summary>
        /// 删除指标组
        /// </summary>
        /// <param name="_guideLineGroupName"></param>
        /// <returns></returns>
        bool DelGuideLineGroup(string _guideLineGroupName);

        /// <summary>
        /// 取指标组下的指标个数
        /// </summary>
        /// <param name="_guideLineGroupName"></param>
        /// <returns></returns>
        bool IsExistChildOfGuideLineGroup(string _guideLineGroupName);

        /// <summary>
        /// 保存新的指标组定义
        /// </summary>
        /// <param name="_guideLineGroup"></param>
        /// <returns></returns>
        bool SaveNewGuideLineGroupDefine(MD_GuideLineGroup _guideLineGroup);

        /// <summary>
        /// 系统中是否存在指定名称的指标组
        /// </summary>
        /// <param name="_guideLineGroupName"></param>
        /// <returns></returns>
        bool IsExistGuideLineGroupName(string _guideLineGroupName);

        /// <summary>
        /// 保存新的指标
        /// </summary>
        /// <param name="_guideLineName"></param>
        /// <param name="_fid"></param>
        /// <param name="_guideLineGroupName"></param>
        /// <returns></returns>
        bool SaveNewGuideLine(string _guideLineName, decimal _fid, string _guideLineGroupName);

        /// <summary>
        /// 指定指标下是否包含子指标
        /// </summary>
        /// <param name="_guideLineID"></param>
        /// <returns></returns>
        bool IsExistChildOfGuideLine(string _guideLineID);


        /// <summary>
        /// 删除指定指标
        /// </summary>
        /// <param name="_guideLineID"></param>
        /// <returns></returns>
        bool DelGuideLine(string _guideLineID);

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="_guideLine"></param>
        /// <returns></returns>
        bool SaveGuideLine(MD_GuideLine _guideLine);

        /// <summary>
        /// 取概念组
        /// </summary>
        /// <returns></returns>
        IList<MD_ConceptGroup> GetConceptGroups();

        /// <summary>
        /// 取概念组下的所有概念标签
        /// </summary>
        /// <param name="_groupName"></param>
        /// <returns></returns>
        List<MD_ConceptItem> GetSubConceptTagDefine(string _groupName);
        /// <summary>
        /// 是否存在指定名称概念组
        /// </summary>
        /// <param name="_groupName"></param>
        /// <returns></returns>
        bool IsExistConceptGroup(string _groupName);


        /// <summary>
        /// 保存概念组
        /// </summary>
        /// <param name="_ConceptGroup"></param>
        /// <returns></returns>
        bool SaveConceptGroup(MD_ConceptGroup _ConceptGroup);

        /// <summary>
        /// 添加新的概念组
        /// </summary>
        /// <param name="_groupName"></param>
        /// <returns></returns>
        bool AddNewConceptGroup(string _groupName);

        /// <summary>
        /// 删除概念组
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        bool DelConcpetGroup(string p);

        /// <summary>
        /// 概念组是否有子内容
        /// </summary>
        /// <param name="_groupName"></param>
        /// <returns></returns>
        bool IsExistChildOfConceptGroup(string _groupName);

        /// <summary>
        /// 是否存在概念标签
        /// </summary>
        /// <param name="_TagName"></param>
        /// <returns></returns>
        bool IsExistConceptTag(string _TagName);

        /// <summary>
        /// 添加新的概念标签
        /// </summary>
        /// <param name="_TagName"></param>
        /// <param name="_description"></param>
        /// <param name="_groupName"></param>
        /// <returns></returns>
        bool AddNewConceptTag(string _TagName, string _description, string _groupName);

        /// <summary>
        /// 保存标签定义
        /// </summary>
        /// <param name="mD_ConceptItem"></param>
        /// <returns></returns>
        bool SaveConceptTag(MD_ConceptItem mD_ConceptItem);
        /// <summary>
        /// 删除概念标签
        /// </summary>
        /// <param name="_CTag"></param>
        /// <returns></returns>
        bool DelConceptTag(string _CTag);

        /// <summary>
        /// 取指定指标ID的指标定义
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        MD_GuideLine GetGuideLineDefine(string _guideLineID);

        /// <summary>
        /// 保存新的指标定义
        /// </summary>
        /// <param name="_guideLine"></param>
        bool SaveNewGuideLine(MD_GuideLine _guideLine);

        /// <summary>
        /// 判断指定指标ID的指标是否存在
        /// </summary>
        /// <param name="_guideLineID"></param>
        /// <returns></returns>
        bool IsExistGuideLineID(string _guideLineID);

        /// <summary>
        /// 取所有的权限定义
        /// </summary>
        /// <returns></returns>
        List<MD_RightDefine> GetRightData();
        List<MD_RightDefine> GetRightData(string SystemID);
        /// <summary>
        /// 保存权限定义
        /// </summary>
        /// <param name="_ret"></param>
        /// <returns></returns>
        bool SaveRightDefine(List<MD_RightDefine> _rightList);

        /// <summary>
        /// 导入表定义
        /// </summary>
        /// <param name="_tableDefine"></param>
        bool ImportTableDefine(MD_Table _tableDefine);


        /// <summary>
        /// 导入代码表定义
        /// </summary>
        /// <param name="_rt"></param>
        /// <returns></returns>
        bool ImportRefTableDefine(MD_RefTable _rt);

        /// <summary>
        /// 导入查询模型
        /// </summary>
        /// <param name="_qv"></param>
        /// <returns></returns>
        bool ImportQueryModelDefine(MD_QueryModel _qv);

        /// <summary>
        /// 添加表到查询模型的关联定义
        /// </summary>
        /// <param name="_tableID"></param>
        /// <param name="_modelName"></param>
        /// <returns></returns>
        string AddTableRelationView(string _tableID, string _modelName);

        /// <summary>
        /// 取所有查询模型名称
        /// </summary>
        /// <returns></returns>
        List<string> GetAllQueryModelNames();

        /// <summary>
        /// 取表关联的查询模型的列表
        /// </summary>
        /// <param name="_tid"></param>
        /// <returns></returns>
        List<MD_Table2View> GetTable2ViewList(string _tid);

        /// <summary>
        /// 保存查询模型用户定义信息
        /// </summary>
        /// <param name="_queryModelID"></param>
        /// <param name="_display"></param>
        /// <param name="_descript"></param>
        /// <returns></returns>
        bool SaveQueryModel_UserDefine(string _queryModelID, string _display, string _descript);

        bool SaveViewTable_UserDefine(string _viewTableID, string _displayString, MDType_DisplayType _displayType, List<MD_ViewTableColumn> TableColumnDefine);

        void SaveViewTableOrder_UserDefine(Dictionary<string, int> ChildTableOrder);

        IList<MD_InputModel> GetInputModelOfNamespace(string _namespace);
        MD_InputModel GetInputModel(string _namespace, string ModelName);

        bool SaveNewInputModel(string _namespace, MD_InputModel SaveModel);

        bool DelInputModel(string InputModelID);

        bool SaveInputModel(MD_InputModel SaveModel);

        bool AddNewInputModelGroup(MD_InputModel_ColumnGroup Group);

        bool DelInputModelColumnGroup(string InputModelID, string GroupID);

        bool InputModel_MoveColumnToGroup(MD_InputModel_Column _col, MD_InputModel_ColumnGroup mD_InputModel_ColumnGroup);

        bool SaveInputModelColumnGroup(MD_InputModel_ColumnGroup _group);

        bool FindInputModelColumnByName(string InputModelID, string ColumnName);

        bool AddNewInputModelColumn(string InputModelID, string GroupID, string ColumnName);

        bool DelInputModelColumn(string ColumnID);

        bool OracleTableExist(string TableName);

        bool AddNewInputModelSavedTable(string InputModelID, string TableName);

        bool DelInputModelSavedTable(string TableID);

        bool SaveInputModelSaveTable(MD_InputModel_SaveTable _newTable);


        bool AddInputModelTableColumn(string TableName, string AddFieldName, string DataType);

        List<string> GetDBPrimayKeyList(string TableName);

        bool DelInputModelTableColumn(string TableName, string DelFieldName);

        bool AddChildInputModel(string MainModelID, string ChildModelID);

        bool SaveInputModelChildDefine(MD_InputModel_Child InputModelChild);

        bool DelRefTable(string RefTableID);

        bool DelInputModelChild(string ChildModelID);

        bool IsExistID(string _oldid, string _tname, string _colname);

        List<MD_View2ViewGroup> GetView2ViewGroupOfQueryModel(string ViewID);

        string AddView2ViewGroup(string ViewID);

        bool SaveView2ViewGroup(MD_View2ViewGroup View2ViewGroup);

        List<MD_View2View> GetView2ViewList(string GroupID, string ViewID);

        string DelView2ViewGroup(string GroupID);

        string AddView2View(string ViewID, string GroupID);

        bool SaveView2View(MD_View2View View2View);

        string CMD_DelView2View(string v2vid);

        List<MD_QueryModel_ExRight> GetQueryModelExRights(string QueryModelID, string FatherID);

        bool AddNewViewExRight(string RightValue, string RightTitle, string ViewID, MD_QueryModel_ExRight FatherRight);


        bool SaveQueryModelExRight(MD_QueryModel_ExRight mD_QueryModel_ExRight);

        string CMD_DelViewExRight(MD_QueryModel_ExRight ExRight);

        IList<MD_View_GuideLine> GetView2GuideLineList(string QueryModelID);

        bool SaveView2GL(string V2GID, string VIEWID, string GuideLineID, string Params, int DisplayOrder, string DisplayTitle);

        string CMD_DelView2GL(MD_View_GuideLine View2GL);
    }
}
