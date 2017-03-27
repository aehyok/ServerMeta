using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SinoSZJS.Base.MetaData.Define;
using SinoSZJS.CS.BizMetaDataManager.DAL;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.InputModel;
using SinoSZJS.Base.MetaData.EnumDefine;


namespace SinoSZJS.WCF.Lib
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“MetaDataService”。
    public class MetaDataService : IMetaDataService
    {

        public MD_QueryModel GetQueryModelByName(string ModelName)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetQueryModelByName(ModelName);
            }
            catch (Exception ex)
            {
                throw new FaultException(string.Format("取查询模型定义[{0}]错误！", ModelName), new FaultCode("服务"));
            }
        }


        public MD_QueryModel GetQueryModelByID(string ModelID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetQueryModelByID(ModelID);
            }
            catch (Exception ex)
            {
                throw new FaultException(string.Format("取查询模型定义[MODELID={0}]错误！", ModelID), new FaultCode("服务"));
            }
        }

        public MD_QueryModelGroup GetQueryModelGroup(string QueryModelGroupID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetQueryModelGroup(QueryModelGroupID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }



        public MD_RefTable GetRefTable(string RefTableName)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetRefTable(RefTableName);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }


        public IList<MD_Nodes> GetNodeList()
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetNodeList();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public IList<MD_Namespace> GetNameSpaceAtNode(string NodeDWDM)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetNameSpaceAtNode(NodeDWDM);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveNewNameSapce(MD_Namespace Namespace)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveNewNameSapce(Namespace);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveNodes(MD_Nodes Nodes)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveNodes(Nodes);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveNewNodes(MD_Nodes Nodes)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveNewNodes(Nodes);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool DelNodes(string NodeID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.DelNodes(NodeID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveNameSapce(MD_Namespace Namespace)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveNameSapce(Namespace);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool DelNamespace(MD_Namespace Namespace)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.DelNamespace(Namespace);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public IList<DB_TableMeta> GetDBTableList()
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetDBTableList();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public IList<DB_TableMeta> GetDBTableListOfDMB()
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetDBTableListOfDMB();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public IList<DB_ColumnMeta> GetDBColumnsOfTable(string TableName)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetDBColumnsOfTable(TableName);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveNewTable(DB_TableMeta TableMeta, MD_Namespace Namespace)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveNewTable(TableMeta, Namespace);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public IList<MD_Table> GetTablesAtNamespace(string NsName)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetTablesAtNamespace(NsName);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public MD_Table GetTableByTableID(string TableID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetTableByTableID(TableID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public IList<MD_QueryModel> GetQueryModelAtNamespace(string NsName)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetQueryModelAtNamespace(NsName);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public IList<MD_RefTable> GetRefTableAtNamespace(string Namespace)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetRefTableAtNamespace(Namespace);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public IList<MD_TableColumn> GetColumnsOfTable(string TableID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetColumnsOfTable(TableID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public MD_ViewTable GetMainTableOfQueryModel(string QueryModelID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetMainTableOfQueryModel(QueryModelID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public string GetNewID()
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetNewID();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveTableDefine(MD_Table Table)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveTableDefine(Table);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveNewQueryModel(MD_QueryModel QueryModel)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveNewQueryModel(QueryModel);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveQueryModel(MD_QueryModel QueryModel)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveQueryModel(QueryModel);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveViewMainTable(MD_ViewTable ViewTable)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveViewMainTable(ViewTable);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public IList<MD_ViewTable> GetChildTableOfQueryModel(string QueryModelID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetChildTableOfQueryModel(QueryModelID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveViewChildTable(MD_ViewTable ViewTable)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveViewChildTable(ViewTable);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool AddMainTableToQueryModel(string QueryModelID, MD_Table SelectedTable)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.AddMainTableToQueryModel(QueryModelID, SelectedTable);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool AddChildTableToQueryModel(string QueryModelID, string MainTableID, MD_Table SelectedTable)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.AddChildTableToQueryModel(QueryModelID, MainTableID, SelectedTable);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool IsExistChildTable(string ViewTableID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.IsExistChildTable(ViewTableID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool DelViewTable(string ViewTableID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.DelViewTable(ViewTableID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool IsExistChildOfView(string QueryModelID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.IsExistChildOfView(QueryModelID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool DelViewMeta(string QueryModelID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.DelViewMeta(QueryModelID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool DelViewAndChildren(string QueryModelID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.DelViewAndChildren(QueryModelID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool IsExistViewUsedTable(string TableID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.IsExistViewUsedTable(TableID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool DelTableMeta(string TableID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.DelTableMeta(TableID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveNewRefTable(DB_TableMeta TableMeta, MD_Namespace Namespace)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveNewRefTable(TableMeta, Namespace);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public System.Data.DataTable Get_RefTableColumn(string RefTableName)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.Get_RefTableColumn(RefTableName);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveRefTable(MD_RefTable RefTable, System.Data.DataTable RefData)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveRefTable(RefTable, RefData);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public IList<MD_Menu> GetMenuDefineOfNode(string NodeCode)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetMenuDefineOfNode(NodeCode);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public IList<MD_Menu> GetSubMenuDefine(string FatherMenuID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetSubMenuDefine(FatherMenuID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveMenuDefine(MD_Menu Menu)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveMenuDefine(Menu);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool AddSystemMenu(string NodeCode)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.AddSystemMenu(NodeCode);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool AddSystemSubMenu(string FatherMenuID, string NodeID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.AddSystemSubMenu(FatherMenuID, NodeID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool DelSystemMenu(string MenuID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.DelSystemMenu(MenuID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public IList<MD_GuideLineGroup> GetGuideLineGroup(string NodeCode, string GuideLineGroupType)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetGuideLineGroup(NodeCode, GuideLineGroupType);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public IList<MD_GuideLine> GetGuideLineOfGroup(string GroupName)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetGuideLineOfGroup(GroupName);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveGuideLineGroupDefine(MD_GuideLineGroup GuideLineGroup)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveGuideLineGroupDefine(GuideLineGroup);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public IList<MD_GuideLine> GetChildGuideLines(string FatherGuildLineID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetChildGuideLines(FatherGuildLineID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool DelGuideLineGroup(string GuideLineGroupName)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.DelGuideLineGroup(GuideLineGroupName);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool IsExistChildOfGuideLineGroup(string GuideLineGroupName)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.IsExistChildOfGuideLineGroup(GuideLineGroupName);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveNewGuideLineGroupDefine(MD_GuideLineGroup GuideLineGroup)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveNewGuideLineGroupDefine(GuideLineGroup);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool IsExistGuideLineGroupName(string GuideLineGroupName)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.IsExistGuideLineGroupName(GuideLineGroupName);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool InsertNewGuideLineItem(string GuideLineName, decimal FatherID, string GuideLineGroupName)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveNewGuideLine(GuideLineName, FatherID, GuideLineGroupName);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool IsExistChildOfGuideLine(string GuideLineID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.IsExistChildOfGuideLine(GuideLineID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool DelGuideLine(string GuideLineID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.DelGuideLine(GuideLineID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveGuideLine(MD_GuideLine GuideLine)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveGuideLine(GuideLine);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public IList<MD_ConceptGroup> GetConceptGroups()
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetConceptGroups();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public List<MD_ConceptItem> GetSubConceptTagDefine(string GroupName)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetSubConceptTagDefine(GroupName);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool IsExistConceptGroup(string GroupName)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.IsExistConceptGroup(GroupName);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveConceptGroup(MD_ConceptGroup ConceptGroup)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveConceptGroup(ConceptGroup);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool AddNewConceptGroup(string GroupName)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.AddNewConceptGroup(GroupName);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool DelConcpetGroup(string ConceptGroup)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.DelConcpetGroup(ConceptGroup);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool IsExistChildOfConceptGroup(string GroupName)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.IsExistChildOfConceptGroup(GroupName);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool IsExistConceptTag(string TagName)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.IsExistConceptTag(TagName);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool AddNewConceptTag(string TagName, string Description, string GroupName)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.AddNewConceptTag(TagName, Description, GroupName);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveConceptTag(MD_ConceptItem ConceptItem)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveConceptTag(ConceptItem);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool DelConceptTag(string CTag)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.DelConceptTag(CTag);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public MD_GuideLine GetGuideLineDefine(string GuideLineID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetGuideLineDefine(GuideLineID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveNewGuideLine(MD_GuideLine GuideLine)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveNewGuideLine(GuideLine);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool IsExistGuideLineID(string GuideLineID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.IsExistGuideLineID(GuideLineID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public List<MD_RightDefine> GetRightData(string SystemID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetRightData(SystemID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveRightDefine(List<MD_RightDefine> RightList)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveRightDefine(RightList);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool ImportTableDefine(MD_Table TableDefine)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.ImportTableDefine(TableDefine);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool ImportRefTableDefine(MD_RefTable RefTable)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.ImportRefTableDefine(RefTable);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool ImportQueryModelDefine(MD_QueryModel QueryModel)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.ImportQueryModelDefine(QueryModel);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public string AddTableRelationView(string TbleID, string ModelName)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.AddTableRelationView(TbleID, ModelName);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public List<string> GetAllQueryModelNames()
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetAllQueryModelNames();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public List<MD_Table2View> GetTable2ViewList(string TableID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetTable2ViewList(TableID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveQueryModel_UserDefine(string QueryModelID, string Display, string Descript)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveQueryModel_UserDefine(QueryModelID, Display, Descript);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveViewTable_UserDefine(string ViewTableID, string DisplayString, MDType_DisplayType DisplayType, List<MD_ViewTableColumn> TableColumnDefine)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveViewTable_UserDefine(ViewTableID, DisplayString, DisplayType, TableColumnDefine);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public void SaveViewTableOrder_UserDefine(Dictionary<string, int> ChildTableOrder)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                _of.SaveViewTableOrder_UserDefine(ChildTableOrder);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public IList<MD_InputModel> GetInputModelOfNamespace(string Namespace)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetInputModelOfNamespace(Namespace);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public MD_InputModel GetInputModel(string Namespace, string ModelName)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetInputModel(Namespace, ModelName);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveNewInputModel(string Namespace, MD_InputModel SaveModel)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveNewInputModel(Namespace, SaveModel);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool DelInputModel(string InputModelID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.DelInputModel(InputModelID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveInputModel(MD_InputModel SaveModel)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveInputModel(SaveModel);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool AddNewInputModelGroup(MD_InputModel_ColumnGroup Group)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.AddNewInputModelGroup(Group);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool DelInputModelColumnGroup(string InputModelID, string GroupID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.DelInputModelColumnGroup(InputModelID, GroupID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool InputModel_MoveColumnToGroup(MD_InputModel_Column Col, MD_InputModel_ColumnGroup InputModel_ColumnGroup)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.InputModel_MoveColumnToGroup(Col, InputModel_ColumnGroup);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveInputModelColumnGroup(MD_InputModel_ColumnGroup Group)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveInputModelColumnGroup(Group);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool FindInputModelColumnByName(string InputModelID, string ColumnName)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.FindInputModelColumnByName(InputModelID, ColumnName);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool AddNewInputModelColumn(string InputModelID, string GroupID, string ColumnName)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.AddNewInputModelColumn(InputModelID, GroupID, ColumnName);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool DelInputModelColumn(string ColumnID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.DelInputModelColumn(ColumnID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool OracleTableExist(string TableName)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.OracleTableExist(TableName);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool AddNewInputModelSavedTable(string InputModelID, string TableName)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.AddNewInputModelSavedTable(InputModelID, TableName);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool DelInputModelSavedTable(string TableID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.DelInputModelSavedTable(TableID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveInputModelSaveTable(MD_InputModel_SaveTable NewTable)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveInputModelSaveTable(NewTable);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool AddInputModelTableColumn(string TableName, string AddFieldName, string DataType)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.AddInputModelTableColumn(TableName, AddFieldName, DataType);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public List<string> GetDBPrimayKeyList(string TableName)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetDBPrimayKeyList(TableName);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool DelInputModelTableColumn(string TableName, string DelFieldName)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.DelInputModelTableColumn(TableName, DelFieldName);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool AddChildInputModel(string MainModelID, string ChildModelID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.AddChildInputModel(MainModelID, ChildModelID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveInputModelChildDefine(MD_InputModel_Child InputModelChild)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveInputModelChildDefine(InputModelChild);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool DelRefTable(string RefTableID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.DelRefTable(RefTableID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool DelInputModelChild(string ChildModelID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.DelInputModelChild(ChildModelID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool IsExistID(string Oldid, string TableName, string Colname)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.IsExistID(Oldid, TableName, Colname);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public List<MD_View2ViewGroup> GetView2ViewGroupOfQueryModel(string ViewID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetView2ViewGroupOfQueryModel(ViewID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public string AddView2ViewGroup(string ViewID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.AddView2ViewGroup(ViewID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveView2ViewGroup(MD_View2ViewGroup View2ViewGroup)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveView2ViewGroup(View2ViewGroup);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public List<MD_View2View> GetView2ViewList(string GroupID, string ViewID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetView2ViewList(GroupID, ViewID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public string DelView2ViewGroup(string GroupID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.DelView2ViewGroup(GroupID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public string AddView2View(string ViewID, string GroupID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.AddView2View(ViewID, GroupID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveView2View(MD_View2View View2View)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveView2View(View2View);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public string CMD_DelView2View(string View2ViewID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.CMD_DelView2View(View2ViewID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public List<MD_QueryModel_ExRight> GetQueryModelExRights(string QueryModelID, string FatherID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetQueryModelExRights(QueryModelID, FatherID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool AddNewViewExRight(string RightValue, string RightTitle, string ViewID, MD_QueryModel_ExRight FatherRight)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.AddNewViewExRight(RightValue, RightTitle, ViewID, FatherRight);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveQueryModelExRight(MD_QueryModel_ExRight QueryModel_ExRight)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveQueryModelExRight(QueryModel_ExRight);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public string CMD_DelViewExRight(MD_QueryModel_ExRight ExRight)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.CMD_DelViewExRight(ExRight);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public IList<MD_View_GuideLine> GetView2GuideLineList(string QueryModelID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetView2GuideLineList(QueryModelID);
            }
            catch (Exception ex)
            {
                throw new FaultException("取View2GuideLine时出错！", new FaultCode("服务"));
            }
        }

        public bool SaveView2GL(string V2GID, string VIEWID, string GuideLineID, string Params, int DisplayOrder, string DisplayTitle)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveView2GL(V2GID, VIEWID, GuideLineID, Params, DisplayOrder, DisplayTitle);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public string CMD_DelView2GL(MD_View_GuideLine View2GL)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.CMD_DelView2GL(View2GL);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public MDModel_QueryModel GetModelDefine(string Name)
        {
            return null;
        }


        public List<MD_View2App> GetView2ApplicationList(string QueryModelID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.GetView2ApplicationList(QueryModelID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SaveView2App(string V2AID, MD_View2App View2AppData)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.SaveView2App(V2AID, View2AppData);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public string CMD_DelView2App(string V2AID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.CMD_DelView2App(V2AID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }


        public string CMD_ClearView2App(string QueryModelID)
        {
            try
            {
                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                return _of.CMD_ClearView2App(QueryModelID);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool HeartBeat()
        {
            return true;
        }
    }
}
