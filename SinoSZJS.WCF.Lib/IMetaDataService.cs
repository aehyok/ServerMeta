using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.Define;
using SinoSZJS.Base.InputModel;
using SinoSZJS.Base.MetaData.EnumDefine;



namespace SinoSZJS.WCF.Lib
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IMetaDataService”。
    [ServiceContract]
    public interface IMetaDataService
    {
        [OperationContract]
        bool HeartBeat();

        /// <summary>
        /// 通过名称取查询模型
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        [OperationContract]
        MD_QueryModel GetQueryModelByName(string ModelName);

        /// <summary>
        /// 通过ModelID取查询模型
        /// </summary>
        /// <param name="modelID"></param>
        /// <returns></returns>
        [OperationContract]
        MD_QueryModel GetQueryModelByID(string ModelID);


        [OperationContract]
        MD_QueryModelGroup GetQueryModelGroup(string QueryModelGroupID);


        [OperationContract]
        MD_RefTable GetRefTable(string RefTableName);


        [OperationContract]
        IList<MD_Nodes> GetNodeList();

        [OperationContract]
        IList<MD_Namespace> GetNameSpaceAtNode(string NodeDWDM);


        /// <summary>
        /// 保存新的命名空间
        /// </summary>
        /// <param name="_ns"></param>
        /// <returns></returns>
        [OperationContract]
        bool SaveNewNameSapce(MD_Namespace Namespace);

        /// <summary>
        /// 保存修改的节点信息
        /// </summary>
        /// <param name="_nodes"></param>
        [OperationContract]
        bool SaveNodes(MD_Nodes Nodes);

        /// <summary>
        /// 保存新的节点信息
        /// </summary>
        /// <param name="_nodes"></param>
        /// <returns></returns>
        [OperationContract]
        bool SaveNewNodes(MD_Nodes Nodes);

        /// <summary>
        /// 删除节点信息
        /// </summary>
        /// <param name="_node"></param>
        /// <returns></returns>
        [OperationContract]
        bool DelNodes(string NodeID);

        /// <summary>
        /// 保存命名空间信息
        /// </summary>
        /// <param name="mD_Namespace"></param>
        /// <returns></returns>
        [OperationContract]
        bool SaveNameSapce(MD_Namespace Namespace);

        /// <summary>
        /// 删除命名空间
        /// </summary>
        /// <param name="_ns"></param>
        /// <returns></returns>
        [OperationContract]
        bool DelNamespace(MD_Namespace Namespace);

        /// <summary>
        /// 取数据库中的表的列表
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<DB_TableMeta> GetDBTableList();


        /// <summary>
        /// 取数据库中的代码表
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<DB_TableMeta> GetDBTableListOfDMB();

        /// <summary>
        /// 从数据库中取表的字段定义
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [OperationContract]
        IList<DB_ColumnMeta> GetDBColumnsOfTable(string TableName);

        /// <summary>
        /// 将新的表存入元数据
        /// </summary>
        /// <param name="_tm"></param>
        /// <returns></returns>
        [OperationContract]
        bool SaveNewTable(DB_TableMeta TableMeta, MD_Namespace Namespace);

        /// <summary>
        /// 取命名空间下的表的列表
        /// </summary>
        /// <param name="_ns"></param>
        /// <returns></returns>
        [OperationContract]
        IList<MD_Table> GetTablesAtNamespace(string NsName);

        /// <summary>
        /// 取指定表ID的表定义
        /// </summary>
        /// <param name="_tid"></param>
        /// <returns></returns>
        [OperationContract]
        MD_Table GetTableByTableID(string TableID);

        /// <summary>
        /// 取命名空间下的查询模型
        /// </summary>
        /// <param name="_ns"></param>
        /// <returns></returns>
        [OperationContract]
        IList<MD_QueryModel> GetQueryModelAtNamespace(string NsName);

        /// <summary>
        /// 取命名空间下的代码表
        /// </summary>
        /// <param name="_ns"></param>
        /// <returns></returns>
        [OperationContract]
        IList<MD_RefTable> GetRefTableAtNamespace(string Namespace);

        /// <summary>
        /// 取表的列定义
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [OperationContract]
        IList<MD_TableColumn> GetColumnsOfTable(string TableID);

        /// <summary>
        /// 取查询模型的主表
        /// </summary>
        /// <param name="_qm"></param>
        /// <returns></returns>
        [OperationContract]
        MD_ViewTable GetMainTableOfQueryModel(string QueryModelID);

        /// <summary>
        /// 取最新的序列产生器的值
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        string GetNewID();

        /// <summary>
        /// 保存表定义
        /// </summary>
        /// <param name="mD_Table"></param>
        /// <returns></returns>
        [OperationContract]
        bool SaveTableDefine(MD_Table Table);

        /// <summary>
        /// 保存新的查询模型
        /// </summary>
        /// <param name="_queryModel"></param>
        [OperationContract]
        bool SaveNewQueryModel(MD_QueryModel QueryModel);

        /// <summary>
        /// 保存查询模型定义
        /// </summary>
        /// <param name="_queryModel"></param>
        /// <returns></returns>
        [OperationContract]
        bool SaveQueryModel(MD_QueryModel QueryModel);

        /// <summary>
        ///　保存查询模型主表定义
        /// </summary>
        /// <param name="_viewtable"></param>
        /// <returns></returns>
        [OperationContract]
        bool SaveViewMainTable(MD_ViewTable ViewTable);

        /// <summary>
        /// 取查询模型主表的子表
        /// </summary>
        /// <param name="mD_QueryModel"></param>
        /// <returns></returns>
        [OperationContract]
        IList<MD_ViewTable> GetChildTableOfQueryModel(string QueryModelID);

        /// <summary>
        /// 保存查询模型副表定义
        /// </summary>
        /// <param name="_viewtable"></param>
        /// <returns></returns>
        [OperationContract]
        bool SaveViewChildTable(MD_ViewTable ViewTable);


        /// <summary>
        /// 向查询模型里添加主表
        /// </summary>
        /// <param name="p"></param>
        /// <param name="_selectedTable"></param>
        /// <returns></returns>
        [OperationContract]
        bool AddMainTableToQueryModel(string QueryModelID, MD_Table SelectedTable);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        /// <param name="_selectedTable"></param>
        /// <returns></returns>
        [OperationContract]
        bool AddChildTableToQueryModel(string QueryModelID, string MainTableID, MD_Table SelectedTable);

        /// <summary>
        /// 指定的表是否有子表
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [OperationContract]
        bool IsExistChildTable(string ViewTableID);

        /// <summary>
        /// 删除查询模型中的表
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [OperationContract]
        bool DelViewTable(string ViewTableID);

        /// <summary>
        /// 指定查询模型中是否有表
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [OperationContract]
        bool IsExistChildOfView(string QueryModelID);

        /// <summary>
        /// 删除查询模型
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [OperationContract]
        bool DelViewMeta(string QueryModelID);

        /// <summary>
        /// 删除查询模型及其主表子表等子定义
        /// </summary>
        /// <param name="QueryModelID"></param>
        /// <returns></returns>
        [OperationContract]
        bool DelViewAndChildren(string QueryModelID);

        /// <summary>
        /// 是否存在使用此表的查询模型
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [OperationContract]
        bool IsExistViewUsedTable(string TableID);

        /// <summary>
        /// 删除指定的数据表
        /// </summary>
        /// <param name="_tableID"></param>
        /// <returns></returns>
        [OperationContract]
        bool DelTableMeta(string TableID);

        /// <summary>
        /// 保存新的代码表
        /// </summary>
        /// <param name="_tm"></param>
        /// <param name="_namespace"></param>
        /// <returns></returns>
        [OperationContract]
        bool SaveNewRefTable(DB_TableMeta TableMeta, MD_Namespace Namespace);

        /// <summary>
        /// 取代码表中的记录
        /// </summary>
        /// <param name="_refTable"></param>
        /// <returns></returns>
        [OperationContract]
        DataTable Get_RefTableColumn(string RefTableName);

        /// <summary>
        /// 保存代码表内容
        /// </summary>
        /// <param name="_refTable"></param>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        [OperationContract]
        bool SaveRefTable(MD_RefTable RefTable, DataTable RefData);

        /// <summary>
        /// 取指定节点下的一级菜单
        /// </summary>
        /// <param name="_node"></param>
        /// <returns></returns>
        [OperationContract]
        IList<MD_Menu> GetMenuDefineOfNode(string NodeCode);

        /// <summary>
        /// 取指定菜单项下的子菜单
        /// </summary>
        /// <param name="_fmenuID"></param>
        /// <returns></returns>
        [OperationContract]
        IList<MD_Menu> GetSubMenuDefine(string FatherMenuID);

        /// <summary>
        /// 保存菜单定义
        /// </summary>
        /// <param name="_menu"></param>
        /// <returns></returns>
        [OperationContract]
        bool SaveMenuDefine(MD_Menu Menu);

        /// <summary>
        /// 添加系统菜单
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [OperationContract]
        bool AddSystemMenu(string NodeCode);


        /// <summary>
        /// 添加子菜单
        /// </summary>
        /// <param name="_fatherMenuID"></param>
        /// <param name="_nodeID"></param>
        /// <returns></returns>
        [OperationContract]
        bool AddSystemSubMenu(string FatherMenuID, string NodeID);


        /// <summary>
        /// 删除系统菜单
        /// </summary>
        /// <param name="_menuid"></param>
        /// <returns></returns>
        [OperationContract]
        bool DelSystemMenu(string MenuID);

        /// <summary>
        /// 取指定节点下的指标定义组
        /// </summary>
        /// <param name="_nodeCode">节点名称</param>
        /// <param name="_guideLineGroupType">组类型</param>
        /// <returns></returns>
        [OperationContract]
        IList<MD_GuideLineGroup> GetGuideLineGroup(string NodeCode, string GuideLineGroupType);

        /// <summary>
        /// 取指定指标组下的指标列表
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [OperationContract]
        IList<MD_GuideLine> GetGuideLineOfGroup(string GroupName);

        /// <summary>
        /// 保存指标组的定义
        /// </summary>
        /// <param name="mD_GuideLineGroup"></param>
        /// <returns></returns>
        [OperationContract]
        bool SaveGuideLineGroupDefine(MD_GuideLineGroup GuideLineGroup);

        /// <summary>
        /// 取指定指标下的子指标列表
        /// </summary>
        /// <param name="_fatherGuildLineID"></param>
        /// <returns></returns>
        [OperationContract]
        IList<MD_GuideLine> GetChildGuideLines(string FatherGuildLineID);

        /// <summary>
        /// 删除指标组
        /// </summary>
        /// <param name="_guideLineGroupName"></param>
        /// <returns></returns>
        [OperationContract]
        bool DelGuideLineGroup(string GuideLineGroupName);

        /// <summary>
        /// 取指标组下的指标个数
        /// </summary>
        /// <param name="_guideLineGroupName"></param>
        /// <returns></returns>
        [OperationContract]
        bool IsExistChildOfGuideLineGroup(string GuideLineGroupName);

        /// <summary>
        /// 保存新的指标组定义
        /// </summary>
        /// <param name="_guideLineGroup"></param>
        /// <returns></returns>
        [OperationContract]
        bool SaveNewGuideLineGroupDefine(MD_GuideLineGroup GuideLineGroup);

        /// <summary>
        /// 系统中是否存在指定名称的指标组
        /// </summary>
        /// <param name="_guideLineGroupName"></param>
        /// <returns></returns>
        [OperationContract]
        bool IsExistGuideLineGroupName(string GuideLineGroupName);

        /// <summary>
        /// 保存新的指标
        /// </summary>
        /// <param name="_guideLineName"></param>
        /// <param name="_fid"></param>
        /// <param name="_guideLineGroupName"></param>
        /// <returns></returns>
        [OperationContract]
        bool InsertNewGuideLineItem(string GuideLineName, decimal FatherID, string GuideLineGroupName);

        /// <summary>
        /// 指定指标下是否包含子指标
        /// </summary>
        /// <param name="_guideLineID"></param>
        /// <returns></returns>
        [OperationContract]
        bool IsExistChildOfGuideLine(string GuideLineID);


        /// <summary>
        /// 删除指定指标
        /// </summary>
        /// <param name="_guideLineID"></param>
        /// <returns></returns>
        [OperationContract]
        bool DelGuideLine(string GuideLineID);

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="_guideLine"></param>
        /// <returns></returns>
        [OperationContract]
        bool SaveGuideLine(MD_GuideLine GuideLine);

        /// <summary>
        /// 取概念组
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<MD_ConceptGroup> GetConceptGroups();

        /// <summary>
        /// 取概念组下的所有概念标签
        /// </summary>
        /// <param name="_groupName"></param>
        /// <returns></returns>
        [OperationContract]
        List<MD_ConceptItem> GetSubConceptTagDefine(string GroupName);
        /// <summary>
        /// 是否存在指定名称概念组
        /// </summary>
        /// <param name="_groupName"></param>
        /// <returns></returns>
        [OperationContract]
        bool IsExistConceptGroup(string GroupName);


        /// <summary>
        /// 保存概念组
        /// </summary>
        /// <param name="_ConceptGroup"></param>
        /// <returns></returns>
        [OperationContract]
        bool SaveConceptGroup(MD_ConceptGroup ConceptGroup);

        /// <summary>
        /// 添加新的概念组
        /// </summary>
        /// <param name="_groupName"></param>
        /// <returns></returns>
        [OperationContract]
        bool AddNewConceptGroup(string GroupName);

        /// <summary>
        /// 删除概念组
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [OperationContract]
        bool DelConcpetGroup(string ConceptGroup);

        /// <summary>
        /// 概念组是否有子内容
        /// </summary>
        /// <param name="_groupName"></param>
        /// <returns></returns>
        [OperationContract]
        bool IsExistChildOfConceptGroup(string GroupName);

        /// <summary>
        /// 是否存在概念标签
        /// </summary>
        /// <param name="_TagName"></param>
        /// <returns></returns>
        [OperationContract]
        bool IsExistConceptTag(string TagName);

        /// <summary>
        /// 添加新的概念标签
        /// </summary>
        /// <param name="_TagName"></param>
        /// <param name="_description"></param>
        /// <param name="_groupName"></param>
        /// <returns></returns>
        [OperationContract]
        bool AddNewConceptTag(string TagName, string Description, string GroupName);

        /// <summary>
        /// 保存标签定义
        /// </summary>
        /// <param name="mD_ConceptItem"></param>
        /// <returns></returns>
        [OperationContract]
        bool SaveConceptTag(MD_ConceptItem ConceptItem);
        /// <summary>
        /// 删除概念标签
        /// </summary>
        /// <param name="_CTag"></param>
        /// <returns></returns>
        [OperationContract]
        bool DelConceptTag(string CTag);

        /// <summary>
        /// 取指定指标ID的指标定义
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [OperationContract]
        MD_GuideLine GetGuideLineDefine(string GuideLineID);

        /// <summary>
        /// 保存新的指标定义
        /// </summary>
        /// <param name="_guideLine"></param>
        [OperationContract]
        bool SaveNewGuideLine(MD_GuideLine GuideLine);

        /// <summary>
        /// 判断指定指标ID的指标是否存在
        /// </summary>
        /// <param name="_guideLineID"></param>
        /// <returns></returns>
        [OperationContract]
        bool IsExistGuideLineID(string GuideLineID);

        /// <summary>
        /// 取所有的权限定义
        /// </summary>
        /// <returns></returns>    
        [OperationContract]
        List<MD_RightDefine> GetRightData(string SystemID);
        /// <summary>
        /// 保存权限定义
        /// </summary>
        /// <param name="_ret"></param>
        /// <returns></returns>
        [OperationContract]
        bool SaveRightDefine(List<MD_RightDefine> RightList);

        /// <summary>
        /// 导入表定义
        /// </summary>
        /// <param name="_tableDefine"></param>
        [OperationContract]
        bool ImportTableDefine(MD_Table TableDefine);


        /// <summary>
        /// 导入代码表定义
        /// </summary>
        /// <param name="_rt"></param>
        /// <returns></returns>
        [OperationContract]
        bool ImportRefTableDefine(MD_RefTable RefTable);

        /// <summary>
        /// 导入查询模型
        /// </summary>
        /// <param name="_qv"></param>
        /// <returns></returns>
        [OperationContract]
        bool ImportQueryModelDefine(MD_QueryModel QueryModel);

        /// <summary>
        /// 添加表到查询模型的关联定义
        /// </summary>
        /// <param name="_tableID"></param>
        /// <param name="_modelName"></param>
        /// <returns></returns>
        [OperationContract]
        string AddTableRelationView(string TbleID, string ModelName);

        /// <summary>
        /// 取所有查询模型名称
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<string> GetAllQueryModelNames();

        /// <summary>
        /// 取表关联的查询模型的列表
        /// </summary>
        /// <param name="_tid"></param>
        /// <returns></returns>
        [OperationContract]
        List<MD_Table2View> GetTable2ViewList(string TableID);

        /// <summary>
        /// 保存查询模型用户定义信息
        /// </summary>
        /// <param name="_queryModelID"></param>
        /// <param name="_display"></param>
        /// <param name="_descript"></param>
        /// <returns></returns>
        [OperationContract]
        bool SaveQueryModel_UserDefine(string QueryModelID, string Display, string Descript);
        [OperationContract]
        bool SaveViewTable_UserDefine(string ViewTableID, string DisplayString, MDType_DisplayType DisplayType, List<MD_ViewTableColumn> TableColumnDefine);
        [OperationContract]
        void SaveViewTableOrder_UserDefine(Dictionary<string, int> ChildTableOrder);
        [OperationContract]
        IList<MD_InputModel> GetInputModelOfNamespace(string Namespace);
        [OperationContract]
        MD_InputModel GetInputModel(string Namespace, string ModelName);
        [OperationContract]
        bool SaveNewInputModel(string Namespace, MD_InputModel SaveModel);
        [OperationContract]
        bool DelInputModel(string InputModelID);
        [OperationContract]
        bool SaveInputModel(MD_InputModel SaveModel);
        [OperationContract]
        bool AddNewInputModelGroup(MD_InputModel_ColumnGroup Group);
        [OperationContract]
        bool DelInputModelColumnGroup(string InputModelID, string GroupID);
        [OperationContract]
        bool InputModel_MoveColumnToGroup(MD_InputModel_Column Col, MD_InputModel_ColumnGroup InputModel_ColumnGroup);
        [OperationContract]
        bool SaveInputModelColumnGroup(MD_InputModel_ColumnGroup Group);
        [OperationContract]
        bool FindInputModelColumnByName(string InputModelID, string ColumnName);
        [OperationContract]
        bool AddNewInputModelColumn(string InputModelID, string GroupID, string ColumnName);
        [OperationContract]
        bool DelInputModelColumn(string ColumnID);
        [OperationContract]
        bool OracleTableExist(string TableName);
        [OperationContract]
        bool AddNewInputModelSavedTable(string InputModelID, string TableName);
        [OperationContract]
        bool DelInputModelSavedTable(string TableID);
        [OperationContract]
        bool SaveInputModelSaveTable(MD_InputModel_SaveTable NewTable);

        [OperationContract]
        bool AddInputModelTableColumn(string TableName, string AddFieldName, string DataType);
        [OperationContract]
        List<string> GetDBPrimayKeyList(string TableName);
        [OperationContract]
        bool DelInputModelTableColumn(string TableName, string DelFieldName);
        [OperationContract]
        bool AddChildInputModel(string MainModelID, string ChildModelID);
        [OperationContract]
        bool SaveInputModelChildDefine(MD_InputModel_Child InputModelChild);
        [OperationContract]
        bool DelRefTable(string RefTableID);
        [OperationContract]
        bool DelInputModelChild(string ChildModelID);
        [OperationContract]
        bool IsExistID(string Oldid, string TableName, string Colname);
        [OperationContract]
        List<MD_View2ViewGroup> GetView2ViewGroupOfQueryModel(string ViewID);
        [OperationContract]
        string AddView2ViewGroup(string ViewID);
        [OperationContract]
        bool SaveView2ViewGroup(MD_View2ViewGroup View2ViewGroup);
        [OperationContract]
        List<MD_View2View> GetView2ViewList(string GroupID, string ViewID);
        [OperationContract]
        string DelView2ViewGroup(string GroupID);
        [OperationContract]
        string AddView2View(string ViewID, string GroupID);
        [OperationContract]
        bool SaveView2View(MD_View2View View2View);
        [OperationContract]
        string CMD_DelView2View(string View2ViewID);
        [OperationContract]
        List<MD_QueryModel_ExRight> GetQueryModelExRights(string QueryModelID, string FatherID);
        [OperationContract]
        bool AddNewViewExRight(string RightValue, string RightTitle, string ViewID, MD_QueryModel_ExRight FatherRight);

        [OperationContract]
        bool SaveQueryModelExRight(MD_QueryModel_ExRight QueryModel_ExRight);
        [OperationContract]
        string CMD_DelViewExRight(MD_QueryModel_ExRight ExRight);
        [OperationContract]
        IList<MD_View_GuideLine> GetView2GuideLineList(string QueryModelID);
        [OperationContract]
        bool SaveView2GL(string V2GID, string VIEWID, string GuideLineID, string Params, int DisplayOrder, string DisplayTitle);
        [OperationContract]
        string CMD_DelView2GL(MD_View_GuideLine View2GL);
        [OperationContract]
        List<MD_View2App> GetView2ApplicationList(string QueryModelID);
        [OperationContract]
        bool SaveView2App(string V2AID, MD_View2App View2AppData);
        [OperationContract]
        string CMD_DelView2App(string V2AID);
        [OperationContract]
        string CMD_ClearView2App(string QueryModelID);

    }
}
