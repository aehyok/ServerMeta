using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.CS.BizMetaDataManager.DAL;
using SinoSZJS.Base.MetaData.Define;
using System.Data;
using SinoSZJS.Base.Report.DataCheck;

namespace SinoSZJS.WCF.Lib
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“MetaDataQueryService”。
    public class MetaDataQueryService : IMetaDataQueryService
    {
        private static Dictionary<string, MD_QueryModel> QueryModelCache = new Dictionary<string, MD_QueryModel>();

        public MD_QueryModel GetMDQueryModelDefine(string QueryModelName)
        {
            if (!QueryModelCache.ContainsKey(QueryModelName))
            {
                OraMetaDataFactroy _OMDFactroy = new OraMetaDataFactroy();
                MD_QueryModel _qv = _OMDFactroy.GetQueryModelByName(QueryModelName);
                _qv.MainTable = _OMDFactroy.GetMainTableOfQueryModel(_qv);
                _qv.ChildTables = _OMDFactroy.GetChildTableOfQueryModel(_qv);
                QueryModelCache.Add(QueryModelName, _qv);
            }
            return QueryModelCache[QueryModelName];
        }

        public System.Data.DataSet QueryData(MDQuery_Request Query_Request)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.QueryData(Query_Request);
        }

        public System.Data.DataTable GetMainTableDataByKey(string _queryModelName, string _mainTableName, string _keyid)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetMainTableDataByKey(_queryModelName, _mainTableName, _keyid);
        }

        public System.Data.DataTable GetChildTableDataByKey(string _queryModelName, string _childTableName, string _keyid)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetChildTableDataByKey(_queryModelName, _childTableName, _keyid);
        }

        public int GetChildTableCountByKey(string _queryModelName, string _childTableName, string _keyid)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetChildTableCountByKey(_queryModelName, _childTableName, _keyid);
        }

        public List<Base.MetaData.QueryModel.MDQuery_ChildTableRowCount> GetChildRowCountList(string _queryModelName, string _keyid)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetChildRowCountList(_queryModelName, _keyid);
        }

        public List<Base.MetaData.Define.MD_ConceptGroup> GetConceptList()
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetConceptList();
        }

        public List<Base.MetaData.Define.MD_QueryModel> GetQueryModels(string _queryModelNames)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetQueryModels(_queryModelNames);
        }

        public List<Base.MetaData.QueryModel.MDSearch_Column> GetSearchResultColumn(string _searchText, int _searchType, string _searchConceptGroup, string _queryModelName)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetSearchResultColumn(_searchText, _searchType, _searchConceptGroup, _queryModelName);
        }

        public List<Base.MetaData.QueryModel.MDSearch_ResultDataIndex> GetSearchResult(string _searchText, int _searchType, Base.MetaData.QueryModel.MDSearch_Column _sc)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetSearchResult(_searchText, _searchType, _sc);
        }

        public string GetMainTableKeyByChildKey(Base.MetaData.QueryModel.MDSearch_Column _childColumn, string _childKey)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetMainTableKeyByChildKey(_childColumn, _childKey);
        }

        public string GetMainTableKeyByColumnCondition(string _modelName, string _columnName, string _data)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetMainTableKeyByColumnCondition(_modelName, _columnName, _data);
        }

        public List<Base.MetaData.QueryModel.MD_GuideLine> GetRootGuideLineList(string rootGuideLines)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetRootGuideLineList(rootGuideLines);
        }

        public List<Base.MetaData.QueryModel.MD_GuideLine> GetGuideLineListByFatherID(string _fatherID)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetGuideLineListByFatherID(_fatherID);
        }

        public System.Data.DataTable QueryGuideLine(string _guideLineID, List<Base.MetaData.QueryModel.MDQuery_GuideLineParameter> _param)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.QueryGuideLine(_guideLineID, _param);
        }

        public System.Data.DataTable QueryGuideLineByDefault(string _guideLineID, List<Base.MetaData.QueryModel.MDQuery_GuideLineParameter> _param)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.QueryGuideLineByDefault(_guideLineID, _param);
        }

        public int QueryGuideLineResultCount(string _guideLineID, List<Base.MetaData.QueryModel.MDQuery_GuideLineParameter> _params)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.QueryGuideLineResultCount(_guideLineID, _params);
        }

        public Base.MetaData.QueryModel.MD_GuideLine GetGuideLineByID(string _guideLineID)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetGuideLineByID(_guideLineID);
        }

        public string AddNewQueryTask(string _taskName, Base.MetaData.QueryModel.MDQuery_Request _queryRequest)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.AddNewQueryTask(_taskName, _queryRequest);
        }

        public Base.MetaData.QueryModel.MDQuery_Request GetQueryTaskRequestContext(string _taskID)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetQueryTaskRequestContext(_taskID);
        }

        public List<Base.MetaData.QueryModel.MDQuery_Task> GetQueryTaskList()
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetQueryTaskList();
        }

        public Base.MetaData.QueryModel.MDQuery_Task GetQueryTaskStateByID(string _taskID)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetQueryTaskStateByID(_taskID);
        }

        public bool ClearQueryTask(string _taskID)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.ClearQueryTask(_taskID);
        }

        public bool LockQueryTaskResult(string _taskID)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.LockQueryTaskResult(_taskID);
        }

        public bool CancleQueryTask(string _taskID)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.CancleQueryTask(_taskID);
        }

        public System.Data.DataSet GetTaskQueryResult_DataSet(string _taskID)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetTaskQueryResult_DataSet(_taskID);
        }

        public System.Data.DataSet GetTaskQueryResult_ORA(string _taskID)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetTaskQueryResult_ORA(_taskID);
        }

        public List<Base.MetaData.DataCheck.MD_CheckRule> GetDataCheckRuleDefine(string QueryModelName)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetDataCheckRuleDefine(QueryModelName);
        }

        public void SaveCheckRuleState(string QueryModelName, List<Base.MetaData.DataCheck.MD_CheckRule> _ruleList)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            _of.SaveCheckRuleState(QueryModelName, _ruleList);
        }

        public void SaveQuery(string SaveName, bool IsPublic, Base.MetaData.QueryModel.MDQuery_Request QueryRequest)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            _of.SaveQuery(SaveName, IsPublic, QueryRequest);
        }

        public System.Data.DataTable GetSaveQueryList(string QueryModelName)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetSaveQueryList(QueryModelName);
        }

        public Base.MetaData.QueryModel.MDQuery_Request LoadQuery(string SaveQueryID)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.LoadQuery(SaveQueryID);
        }

        public System.Data.DataTable QueryDataWithWHXH(Base.MetaData.QueryModel.MDQuery_Request _queryRequest, string _dwdm)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.QueryDataWithWHXH(_queryRequest, _dwdm);
        }

        public Base.InputModel.MD_InputModel GetInputModelByName(string _modelName)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetInputModelByName(_modelName);
        }

        public bool DelSavedQuery(string _savedID)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.DelSavedQuery(_savedID);
        }

        public string GetUserLevel()
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetUserLevel();
        }

        public System.Data.DataTable GetDataCheckInfo(string _modelName, string _mainKey, ref string SHID)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetDataCheckInfo(_modelName, _mainKey, ref SHID);
        }

        public string GetDataCheckInfoJLID(string QueryModelName, string _mainkeyId, string _level, ref string SHID)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetDataCheckInfoJLID(QueryModelName, _mainkeyId, _level, ref SHID);
        }

        public string SaveDataCheckResult(string CurrentJLID, string CurrentLevel, string CurrentID, string _shjg, string _shr, string _xgyj, string WHXH)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.SaveDataCheckResult(CurrentJLID, CurrentLevel, CurrentID, _shjg, _shr, _xgyj, WHXH);
        }

        public string GetDataCheckWHXH(string _tableName, string _mainColumn, string _mainKey)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetDataCheckWHXH(_tableName, _mainColumn, _mainKey);
        }

        public bool SaveNewDataCheckRule(string _ruleName, string _queryModelName, string _gzsf)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.SaveNewDataCheckRule(_ruleName, _queryModelName, _gzsf);
        }

        public bool DelDataCheckRule(string _ruleID)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.DelDataCheckRule(_ruleID);
        }

        public bool ChangeDataCheckRule(string _ruleID, string _gzsf)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.ChangeDataCheckRule(_ruleID, _gzsf);
        }

        public System.Data.DataTable GetInputModelBlankData(string _initGuideLineID, string _getBlankGuideLineID, List<Base.MetaData.QueryModel.MDQuery_GuideLineParameter> _params)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetInputModelBlankData(_initGuideLineID, _getBlankGuideLineID, _params);
        }

        public bool SaveDataByInputModel(string _inputModelName, System.Data.DataTable _changedData)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.SaveDataByInputModel(_inputModelName, _changedData);
        }

        public void TestComputeExpress(string ExpressionString, Base.MetaData.QueryModel.MDModel_Table TableDefine, ref string QueryString, ref string resultDataType)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            _of.TestComputeExpress(ExpressionString, TableDefine, ref  QueryString, ref resultDataType);
        }

        public void SaveComputeFieldDefine(string DisplayName, string Description, string Expression, string QueryString, string ResultDataType, string TableName, string ModelName)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            _of.SaveComputeFieldDefine(DisplayName, Description, Expression, QueryString, ResultDataType, TableName, ModelName);
        }

        public List<Base.MetaData.QueryModel.MDQuery_ComputeColumnDefine> GetPersonSavedComputField(string ModelName, string TableName)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetPersonSavedComputField(ModelName, TableName);
        }

        public List<Base.MetaData.Define.MD_FUNCTION> GetFunctionList(int _type)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetFunctionList(_type);
        }

        public void TestStatisticsExpress(string TableName, Base.MetaData.QueryModel.MDModel_Table_Column _column, Base.MetaData.Define.MD_FUNCTION FunctionDefine, ref string queryString, ref string resultDataType)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            _of.TestStatisticsExpress(TableName, _column, FunctionDefine, ref queryString, ref resultDataType);
        }

        public string GetQueryModelDescription(string _modelName)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetQueryModelDescription(_modelName);
        }

        public System.Data.DataSet GetRuleList(string QueryModelName)
        {
            DataSet _ds = new DataSet();
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            DataTable _dt = _of.GetRuleList(QueryModelName);
            _ds.Tables.Add(_dt);
            return _ds;
        }

        public void ImportRule(string SrcRuleID)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            _of.ImportRule(SrcRuleID);
        }

        public void RecoverRuleDefine(string TargetRuleID, string SrcRuleID)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            _of.RecoverRuleDefine(TargetRuleID, SrcRuleID);
        }

        public string GetSjshInfo_HGJS(Base.MetaData.QueryModel.MDQuery_Request _queryRequest, string MainKeyID)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetSjshInfo_HGJS(_queryRequest, MainKeyID);
        }

        public System.Data.DataSet GetDataCheckBoardList()
        {
            DataSet _ds = new DataSet();
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            DataTable _dt = _of.GetDataCheckBoardList();
            _dt.TableName = "BOARDLIST";
            _ds.Tables.Add(_dt);
            return _ds;
        }

        public bool InsertNewDataCheckMsg(string _shjlid, string _title, string _context, string _cddw, string _tel, string _email, decimal _sfkj)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.InsertNewDataCheckMsg(_shjlid, _title, _context, _cddw, _tel, _email, _sfkj);
        }

        public string GetSjshInfo_DWID(string _shjlid)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetSjshInfo_DWID(_shjlid);
        }

        public Base.MetaData.DataCheck.MD_DataCheckMsg GetDataCheckMsg(string _ggjlid)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetDataCheckMsg(_ggjlid);
        }

        public bool SendDataCheckMsgFK(string _ggjlid, string _fkjg)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.SendDataCheckMsgFK(_ggjlid, _fkjg);
        }

        public bool UpdateDataCheckMsg(string _ggjlid, string _title, string _context, string _cddw, string _tel, string _email, decimal _sfkj)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.UpdateDataCheckMsg(_ggjlid, _title, _context, _cddw, _tel, _email, _sfkj);

        }

        public bool DeleteDataCheckMsg(string _ggjlid)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.DeleteDataCheckMsg(_ggjlid);
        }

        public MD_GuideLine_ParamSetting GetGuideLineParamSetting(string _guideLineID)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetGuideLineParamSetting(_guideLineID);
        }

        public bool SaveGuideLineParamSetting(MD_GuideLine_ParamSetting _paramSetting, List<Base.MetaData.QueryModel.MDQuery_GuideLineParameter> _paramters)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.SaveGuideLineParamSetting(_paramSetting, _paramters);
        }

        public Base.InputModel.MD_InputModel_ColumnGroup GetInputGroupByID(string InputGroupID)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetInputGroupByID(InputGroupID);
        }

        public Base.InputModel.MD_InputModel GetInputModelByID(string InputModelID)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetInputModelByID(InputModelID);
        }

        public bool DelComputeFieldDefine(string ColumnName)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.DelComputeFieldDefine(ColumnName);
        }

        public System.Data.DataSet CompareData(Base.MetaData.DataCompare.MDCompare_Request compareRequest, System.Data.DataTable srcData)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.CompareData(compareRequest, srcData);
        }

        public string GetAttachFileName(string IndexString, string FieldName)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetAttachFileName(IndexString, FieldName);
        }

        public byte[] GetAttachFileBytes(string IndexString, string FieldName)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetAttachFileBytes(IndexString, FieldName);
        }

        public string GetFLWSFileName(string _indexString, string FieldName)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetFLWSFileName(_indexString, FieldName);
        }

        public byte[] GetFLWSFileBytes(string _indexString, string FieldName)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetFLWSFileBytes(_indexString, FieldName);
        }

        public System.Data.DataTable GetTaskQueryLog(string TaskID)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetTaskQueryLog(TaskID);
        }

        public bool ChangeQueryTaskRequestTime(string TaskID, DateTime RequestTime)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.ChangeQueryTaskRequestTime(TaskID, RequestTime);
        }

        public bool RebuildGuideLineParamSetting(string GuideLineID)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.RebuildGuideLineParamSetting(GuideLineID);
        }


        public List<ReportHisDataRow> GetSjsh_HisData(string QueryModelName, string MainKeyID, string WHXH)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetSjsh_HisData(QueryModelName, MainKeyID, WHXH);
        }

        public bool HeartBeat()
        {
            return true;
        }
    }
}
