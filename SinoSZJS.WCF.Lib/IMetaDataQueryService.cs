using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SinoSZJS.Base.MetaData.QueryModel;
using System.Data;
using SinoSZJS.Base.MetaData.Define;
using SinoSZJS.Base.InputModel;
using SinoSZJS.Base.MetaData.DataCheck;
using SinoSZJS.Base.MetaData.DataCompare;
using SinoSZJS.Base.Report.DataCheck;

namespace SinoSZJS.WCF.Lib
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IMetaDataQueryService”。
    [ServiceContract]
    public interface IMetaDataQueryService
    {
        [OperationContract]
        bool HeartBeat();

        /// <summary>
        /// 取查询模型定义
        /// </summary>
        /// <param name="_queryModel"></param>
        /// <returns></returns>
        [OperationContract]
        MD_QueryModel GetMDQueryModelDefine(string _queryModel);
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="mDQuery_Request"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet QueryData(MDQuery_Request mDQuery_Request);

        /// <summary>
        /// 通过MAINID取查询模型中的主表记录
        /// </summary>
        /// <param name="_queryModelName"></param>
        /// <param name="_mainTableName"></param>
        /// <param name="_keyid"></param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetMainTableDataByKey(string _queryModelName, string _mainTableName, string _keyid);
        /// <summary>
        /// 通过MAINID取查询模型中的子表记录
        /// </summary>
        /// <param name="_queryModelName"></param>
        /// <param name="_childTableName"></param>
        /// <param name="_keyid"></param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetChildTableDataByKey(string _queryModelName, string _childTableName, string _keyid);
        /// <summary>
        /// 通过MAINID取查询模型中的子表记录总数
        /// </summary>
        /// <param name="_queryModelName"></param>
        /// <param name="_childTableName"></param>
        /// <param name="_keyid"></param>
        /// <returns></returns>
        [OperationContract]
        int GetChildTableCountByKey(string _queryModelName, string _childTableName, string _keyid);

        /// <summary>
        /// 取所有子表的记录数列表
        /// </summary>
        /// <param name="_queryModelName"></param>
        /// <param name="_keyid"></param>
        /// <returns></returns>
        [OperationContract]
        List<MDQuery_ChildTableRowCount> GetChildRowCountList(string _queryModelName, string _keyid);

        /// <summary>
        /// 取所有的概念定义
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<MD_ConceptGroup> GetConceptList();

        /// <summary>
        /// 取指定名称列表的所有查询模型定义
        /// </summary>
        /// <param name="_queryModelNames"></param>
        /// <returns></returns>
        [OperationContract]
        List<MD_QueryModel> GetQueryModels(string _queryModelNames);

        /// <summary>
        /// 取搜索字段列表
        /// </summary>
        /// <param name="_searchText"></param>
        /// <param name="_searchType"></param>
        /// <param name="_searchConceptGroup"></param>
        /// <param name="_queryModelName"></param>
        /// <returns></returns>
        [OperationContract]
        List<MDSearch_Column> GetSearchResultColumn(string _searchText, int _searchType, string _searchConceptGroup, string _queryModelName);

        /// <summary>
        /// 取搜索到的数据记录索引
        /// </summary>
        /// <param name="_searchText"></param>
        /// <param name="_searchType"></param>
        /// <param name="_sc"></param>
        /// <returns></returns>
        [OperationContract]
        List<MDSearch_ResultDataIndex> GetSearchResult(string _searchText, int _searchType, MDSearch_Column _sc);

        /// <summary>
        /// 通过子表的主键取主表的主键
        /// </summary>
        /// <param name="_childColumn"></param>
        /// <param name="_childKey"></param>
        /// <returns></returns>
        [OperationContract]
        string GetMainTableKeyByChildKey(MDSearch_Column _childColumn, string _childKey);

        /// <summary>
        /// 通过查询模型的主表的一个字段的值取主键值
        /// </summary>
        /// <param name="_modelName"></param>
        /// <param name="_columnName"></param>
        /// <param name="_data"></param>
        /// <returns></returns>
        [OperationContract]
        string GetMainTableKeyByColumnCondition(string _modelName, string _columnName, string _data);

        /// <summary>
        /// 取指定的根指标定义列表
        /// </summary>
        /// <param name="rootGuideLines"></param>
        /// <returns></returns>
        [OperationContract]
        List<MD_GuideLine> GetRootGuideLineList(string rootGuideLines);
        /// <summary>
        /// 取指定的指标下的子指标列表
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [OperationContract]
        List<MD_GuideLine> GetGuideLineListByFatherID(string _fatherID);

        /// <summary>
        /// 指标查询
        /// </summary>
        /// <param name="_guideLineID"></param>
        /// <param name="_param"></param>
        /// <returns></returns>
        [OperationContract]
        DataTable QueryGuideLine(string _guideLineID, List<MDQuery_GuideLineParameter> _param);
        /// <summary>
        /// 用默认值查询指标
        /// </summary>
        /// <param name="_guideLineID"></param>
        /// <param name="_param"></param>
        /// <returns></returns>
        [OperationContract]
        DataTable QueryGuideLineByDefault(string _guideLineID, List<MDQuery_GuideLineParameter> _param);

        /// <summary>
        /// 取指标查询的结果记录数
        /// </summary>
        /// <param name="_guideLineID"></param>
        /// <param name="_params"></param>
        /// <returns></returns>
        [OperationContract]
        int QueryGuideLineResultCount(string _guideLineID, List<MDQuery_GuideLineParameter> _params);


        /// <summary>
        /// 通过GuideLineID取指标定义
        /// </summary>
        /// <param name="_guideLineID"></param>
        /// <returns></returns>
        [OperationContract]
        MD_GuideLine GetGuideLineByID(string _guideLineID);

        /// <summary>
        /// 添加新的查询任务
        /// </summary>
        /// <param name="_taskName"></param>
        /// <param name="_queryRequest"></param>
        /// <returns>返回查询的ID号</returns>
        [OperationContract]
        string AddNewQueryTask(string _taskName, MDQuery_Request _queryRequest);

        /// <summary>
        /// 取指标ID的查询任务请求内容
        /// </summary>
        /// <param name="_taskID"></param>
        /// <returns></returns>
        [OperationContract]
        MDQuery_Request GetQueryTaskRequestContext(string _taskID);

        /// <summary>
        /// 取当前用户的任务列表
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<MDQuery_Task> GetQueryTaskList();


        /// <summary>
        /// 取指定查询任务ID的当前状态
        /// </summary>
        /// <param name="_taskID"></param>
        /// <returns></returns>
        [OperationContract]
        MDQuery_Task GetQueryTaskStateByID(string _taskID);

        /// <summary>
        /// 清除任务ID
        /// </summary>
        /// <param name="_taskID"></param>
        /// <returns></returns>
        [OperationContract]
        bool ClearQueryTask(string _taskID);

        /// <summary>
        /// 锁定任务结果
        /// </summary>
        /// <param name="_taskID"></param>
        /// <returns></returns>
        [OperationContract]
        bool LockQueryTaskResult(string _taskID);

        /// <summary>
        /// 取消查询任务
        /// </summary>
        /// <param name="_taskID"></param>
        /// <returns></returns>
        [OperationContract]
        bool CancleQueryTask(string _taskID);

        /// <summary>
        /// 取任务查询结果(以DataTable序列化成XML)
        /// </summary>
        /// <param name="_taskID"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetTaskQueryResult_DataSet(string _taskID);

        /// <summary>
        /// 取任务查询结果(以ORACLE序列化成XML)
        /// </summary>
        /// <param name="_taskID"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetTaskQueryResult_ORA(string _taskID);

        /// <summary>
        /// 取指定查询模型的数据审核规则
        /// </summary>
        /// <param name="QueryModelName"></param>
        /// <returns></returns>
        [OperationContract]
        List<MD_CheckRule> GetDataCheckRuleDefine(string QueryModelName);

        /// <summary>
        /// 保存规则选定状态
        /// </summary>
        /// <param name="QueryModelName"></param>
        /// <param name="_ruleList"></param>
        void SaveCheckRuleState(string QueryModelName, List<MD_CheckRule> _ruleList);

        /// <summary>
        /// 保存查询
        /// </summary>
        /// <param name="SaveName">保存名称</param>
        /// <param name="IsPublic">是否公开</param>
        /// <param name="QueryRequest">查询请求</param>
        [OperationContract]
        void SaveQuery(string SaveName, bool IsPublic, MDQuery_Request QueryRequest);

        /// <summary>
        /// 取保存的查询列表
        /// </summary>
        /// <param name="QueryModelName"></param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetSaveQueryList(string QueryModelName);

        /// <summary>
        /// 取保存的查询请求定义
        /// </summary>
        /// <param name="SaveQueryID"></param>
        /// <returns></returns>
        [OperationContract]
        MDQuery_Request LoadQuery(string SaveQueryID);

        /// <summary>
        /// 通过查询模型取带维护序号的数据(数据审核用)
        /// </summary>
        /// <param name="_queryRequest"></param>
        /// <param name="_dwdm"></param>
        /// <returns></returns>
        [OperationContract]
        DataTable QueryDataWithWHXH(MDQuery_Request _queryRequest, string _dwdm);

        /// <summary>
        /// 取录入模型定义
        /// </summary>
        /// <param name="_modelName"></param>
        /// <returns></returns>
        [OperationContract]
        MD_InputModel GetInputModelByName(string _modelName);

        /// <summary>
        /// 删除保存的查询模型
        /// </summary>
        /// <param name="_savedID"></param>
        /// <returns></returns>
        [OperationContract]
        bool DelSavedQuery(string _savedID);

        /// <summary>
        /// 取用户的单位级别 :   总署缉私局、直属缉私局、广东分署缉私局、缉私分局
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        string GetUserLevel();

        /// <summary>
        /// 取审核信息
        /// </summary>
        /// <param name="_modelName"></param>
        /// <param name="_mainKey"></param>
        /// <param name="SHID"></param>
        /// <param name="WHXH"></param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetDataCheckInfo(string _modelName, string _mainKey, ref string SHID);

        /// <summary>
        /// 取数据审核的记录ID
        /// </summary>
        /// <param name="QueryModelName"></param>
        /// <param name="_mainkeyId"></param>
        /// <param name="_level"></param>
        /// <param name="SHID"></param>
        /// <returns></returns>
        [OperationContract]
        string GetDataCheckInfoJLID(string QueryModelName, string _mainkeyId, string _level, ref string SHID);

        /// <summary>
        /// 保存审核信息
        /// </summary>
        /// <param name="CurrentJLID"></param>
        /// <param name="CurrentLevel"></param>
        /// <param name="CurrentID"></param>
        /// <param name="_shjg"></param>
        /// <param name="_shr"></param>
        /// <param name="_xgyj"></param>
        /// <param name="WHXH"></param>
        /// <returns></returns>
        [OperationContract]
        string SaveDataCheckResult(string CurrentJLID, string CurrentLevel, string CurrentID, string _shjg, string _shr, string _xgyj, string WHXH);


        /// <summary>
        /// 取维护序号
        /// </summary>
        /// <param name="_tableName"></param>
        /// <param name="_mainColumn"></param>
        /// <param name="_mainKey"></param>
        /// <returns></returns>
        [OperationContract]
        string GetDataCheckWHXH(string _tableName, string _mainColumn, string _mainKey);


        /// <summary>
        /// 保存数据审核规则
        /// </summary>
        /// <param name="_ruleName"></param>
        /// <param name="_queryModelName"></param>
        /// <param name="_gzsf"></param>
        /// <returns></returns>
        [OperationContract]
        bool SaveNewDataCheckRule(string _ruleName, string _queryModelName, string _gzsf);

        /// <summary>
        /// 删除规则
        /// </summary>
        /// <param name="_ruleID"></param>
        /// <returns></returns>
        [OperationContract]
        bool DelDataCheckRule(string _ruleID);

        /// <summary>
        /// 修改规则算法
        /// </summary>
        /// <param name="_ruleID"></param>
        /// <param name="_gzsf"></param>
        /// <returns></returns>
        [OperationContract]
        bool ChangeDataCheckRule(string _ruleID, string _gzsf);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_"></param>
        /// <param name="_params"></param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetInputModelBlankData(string _initGuideLineID, string _getBlankGuideLineID, List<MDQuery_GuideLineParameter> _params);

        /// <summary>
        /// 保存录入模型的数据
        /// </summary>
        /// <param name="_queryModelName"></param>
        /// <param name="_changedData"></param>
        /// <returns></returns>
        [OperationContract]
        bool SaveDataByInputModel(string _inputModelName, DataTable _changedData);

        /// <summary>
        /// 测试表达式是否正确
        /// </summary>
        /// <param name="ExpressionString"></param>
        /// <param name="TableDefine"></param>
        [OperationContract]
        void TestComputeExpress(string ExpressionString, MDModel_Table TableDefine, ref string QueryString, ref string resultDataType);
        /// <summary>
        /// 保存计算字段定义
        /// </summary>
        /// <param name="DisplayName"></param>
        /// <param name="Description"></param>
        /// <param name="Expression"></param>
        /// <param name="QueryString"></param>
        /// <param name="TableName"></param>
        /// <param name="ModelName"></param>
        [OperationContract]
        void SaveComputeFieldDefine(string DisplayName, string Description, string Expression, string QueryString, string ResultDataType, string TableName, string ModelName);

        /// <summary>
        /// 取用户个人收藏的计算字段
        /// </summary>
        /// <param name="ModelName"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        [OperationContract]
        List<MDQuery_ComputeColumnDefine> GetPersonSavedComputField(string ModelName, string TableName);

        /// <summary>
        /// 取函数定义列表
        /// </summary>
        /// <param name="_type">类型  0：计算函数  1.统计函数</param>
        /// <returns></returns>
        [OperationContract]
        List<MD_FUNCTION> GetFunctionList(int _type);


        [OperationContract]
        void TestStatisticsExpress(string TableName, MDModel_Table_Column _column, MD_FUNCTION FunctionDefine, ref string queryString, ref string resultDataType);



        /// <summary>
        /// 取查询模型的说明
        /// </summary>
        /// <param name="_modelName"></param>
        /// <returns></returns>
        [OperationContract]
        string GetQueryModelDescription(string _modelName);

        /// <summary>
        /// 取规则列表
        /// </summary>
        /// <param name="QueryModelName"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetRuleList(string QueryModelName);


        /// <summary>
        /// 导入总局的规则
        /// </summary>
        /// <param name="SrcRuleID"></param>
        [OperationContract]
        void ImportRule(string SrcRuleID);

        /// <summary>
        /// 用总局的规则覆盖当前规则
        /// </summary>
        /// <param name="TargetRuleID"></param>
        /// <param name="SrcRuleID"></param>
        [OperationContract]
        void RecoverRuleDefine(string TargetRuleID, string SrcRuleID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="MainKeyID"></param>
        /// <returns></returns>
        [OperationContract]
        string GetSjshInfo_HGJS(MDQuery_Request _queryRequest, string MainKeyID);

        [OperationContract]
        List<ReportHisDataRow> GetSjsh_HisData(string QueryModelName, string MainKeyID, string WHXH);

        /// <summary>
        /// 取审核 公告信息
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        DataSet GetDataCheckBoardList();

        /// <summary>
        /// 添加审核公告
        /// </summary>
        /// <param name="_shjlid"></param>
        /// <param name="_title"></param>
        /// <param name="_context"></param>
        /// <param name="_cddw"></param>
        /// <param name="_tel"></param>
        /// <param name="_email"></param>
        /// <param name="_sfkj"></param>
        /// <returns></returns>
        [OperationContract]
        bool InsertNewDataCheckMsg(string _shjlid, string _title, string _context, string _cddw, string _tel, string _email, decimal _sfkj);

        /// <summary>
        /// 通过审核记录取审核单位的ID
        /// </summary>
        /// <param name="_shjlid"></param>
        /// <returns></returns>
        [OperationContract]
        string GetSjshInfo_DWID(string _shjlid);


        /// <summary>
        /// 通过记录ID取审核公告信息
        /// </summary>
        /// <param name="_ggjlid"></param>
        /// <returns></returns>
        /// 
        [OperationContract]
        MD_DataCheckMsg GetDataCheckMsg(string _ggjlid);

        /// <summary>
        /// 反馈审核公告
        /// </summary>
        /// <param name="_ggjlid"></param>
        /// <param name="_fkjg"></param>
        /// <returns></returns>
        [OperationContract]
        bool SendDataCheckMsgFK(string _ggjlid, string _fkjg);

        /// <summary>
        /// 保存公告修改信息
        /// </summary>
        /// <param name="_ggjlid"></param>
        /// <param name="_title"></param>
        /// <param name="_context"></param>
        /// <param name="_cddw"></param>
        /// <param name="_tel"></param>
        /// <param name="_email"></param>
        /// <param name="_sfkj"></param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateDataCheckMsg(string _ggjlid, string _title, string _context, string _cddw, string _tel, string _email, decimal _sfkj);

        /// <summary>
        /// 删除审核公告记录
        /// </summary>
        /// <param name="_ggjlid"></param>
        /// <returns></returns>
        [OperationContract]
        bool DeleteDataCheckMsg(string _ggjlid);

        /// <summary>
        /// 取指定指标在本单位的参数设置
        /// </summary>
        /// <param name="_guideLineID"></param>
        /// <returns></returns>
        [OperationContract]
        MD_GuideLine_ParamSetting GetGuideLineParamSetting(string _guideLineID);

        /// <summary>
        /// 保存指标参数定义
        /// </summary>
        /// <param name="_paramSetting"></param>
        /// <param name="_paramters"></param>
        /// <returns></returns>
        [OperationContract]
        bool SaveGuideLineParamSetting(MD_GuideLine_ParamSetting _paramSetting, List<MDQuery_GuideLineParameter> _paramters);
        [OperationContract]
        MD_InputModel_ColumnGroup GetInputGroupByID(string InputGroupID);
        [OperationContract]
        MD_InputModel GetInputModelByID(string InputModelID);
        [OperationContract]
        bool DelComputeFieldDefine(string ColumnName);
        [OperationContract]
        DataSet CompareData(MDCompare_Request compareRequest, DataTable srcData);
        [OperationContract]
        string GetAttachFileName(string IndexString, string FieldName);
        [OperationContract]
        byte[] GetAttachFileBytes(string IndexString, string FieldName);
        [OperationContract]
        string GetFLWSFileName(string _indexString, string FieldName);
        [OperationContract]
        byte[] GetFLWSFileBytes(string _indexString, string FieldName);
        [OperationContract]
        DataTable GetTaskQueryLog(string TaskID);
        [OperationContract]
        bool ChangeQueryTaskRequestTime(string TaskID, DateTime RequestTime);
        [OperationContract]
        bool RebuildGuideLineParamSetting(string GuideLineID);
    }
}
