using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using SinoSZJS.Base.Authorize;
using SinoSZJS.Base;
using System.Runtime.Serialization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Oracle.DataAccess.Types;
using SinoSZJS.Base.Misc;
using SinoSZJS.Base.SystemLog;
using System.Runtime.Remoting;
using SinoSZJS.DataAccess;
using SinoSZJS.CS.BizMetaDataManager.DAL.GuideLineParamSetting;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.InputModel;
using SinoSZJS.Base.MetaData.Define;
using SinoSZJS.Base.MetaData.DataCheck;
using SinoSZJS.Base.MetaData.DataCompare;
using SinoSZJS.Base.MetaData.Common;
using SinoSZJS.Base.PAnalize;
using SinoSZJS.Base.IMetaData;
using SinoSZJS.Base.Report.DataCheck;


namespace SinoSZJS.CS.BizMetaDataManager.DAL
{
    public class OraMetaDataQueryFactroy : IMetaDataQueryFactroy
    {
        private OraMetaDataFactroy _OMDFactroy = new OraMetaDataFactroy();
        public static Dictionary<string, MDModel_QueryModel> ModelLib = new Dictionary<string, MDModel_QueryModel>();
        #region IMetaDataQueryFactroy Members

        public MDModel_QueryModel GetMDQueryModelDefine(string _queryModel)
        {
            if (!ModelLib.ContainsKey(_queryModel))
            {
                try
                {
                    MD_QueryModel _qv = _OMDFactroy.GetQueryModelByName(_queryModel);
                    _qv.MainTable = _OMDFactroy.GetMainTableOfQueryModel(_qv);
                    _qv.ChildTables = _OMDFactroy.GetChildTableOfQueryModel(_qv);
                    ModelLib.Add(_queryModel, MC_QueryModel.CreateQuery_ModelDefine(_qv));
                }
                catch (Exception ex)
                {
                    OralceLogWriter.WriteSystemLog(string.Format("取查询模型定义[{0}]失败!{1}", _queryModel, ex.Message), "ERROR");
                    return null;
                }
            }
            WriteUserActionLog("取查询模型定义", string.Format("取查询模型[{0}]成功！", _queryModel));
            return ModelLib[_queryModel];
        }

        public DataSet PAQueryData(MDQuery_Request _queryRequest, MDModel_QueryModel _queryModel)
        {
            DataSet _ds = null;
            int _startTime = Environment.TickCount;
            MDModel_QueryModel _qv = _queryModel;
            int _GetQueryFinishedTime = Environment.TickCount;

            string _mainQueryStr = OraQueryBuilder.GetPAQueryStr(_qv, _queryRequest);
            int _BuildQueryStringFinishedTime = Environment.TickCount;


            //单查询语句
            _ds = OracleHelper.FillDataSet(_mainQueryStr, _qv.MainTable.TableName);
            WriteQueryLog(_mainQueryStr, Environment.TickCount - _GetQueryFinishedTime);

            int _GetDataByQueryFinishedTime = Environment.TickCount;

            return _ds;
        }

        public DataSet QueryData(MDQuery_Request _queryRequest)
        {
            MDModel_QueryModel _qv;
            int _GetQueryFinishedTime;
            Dictionary<string, string> _resultQueryStrings;
            DataSet _ds = null;
            int _startTime = Environment.TickCount;
            try
            {
                _qv = GetMDQueryModelDefine(_queryRequest.QueryModelName);
                _GetQueryFinishedTime = Environment.TickCount;
            }
            catch (Exception ex)
            {
                string _error = string.Format("取查询模型定义时出错！{0}", ex.Message);
                throw new Exception(_error);
            }
            if (_qv.QueryInterface == "SQL_GDFS")
            {
                return QueryDataBy_SQL_GDFS(_qv, _queryRequest, _GetQueryFinishedTime);
            }

            string _mainQueryStr = "";
            //构建查询字符串
            try
            {
                _resultQueryStrings = OraQueryBuilder.GetQueryStr(_qv, _queryRequest, ref _mainQueryStr);
            }
            catch (Exception ex)
            {
                string _error = string.Format("构建查询字符串时出错！{0}", ex.Message);
                throw new Exception(_error);
            }

            int _BuildQueryStringFinishedTime = Environment.TickCount;

            //用查询字符串取数据
            if (_resultQueryStrings.Count > 0)
            {
                //多查询语句
                try
                {
                    _ds = MultiQuery(_mainQueryStr, _resultQueryStrings);
                }
                catch (Exception ex)
                {
                    string _error = string.Format("多查询语句取数据时出错！{0}", ex.Message);
                    throw new Exception(_error);
                }
            }
            else
            {
                //单查询语句
                try
                {
                    _ds = OracleHelper.FillDataSet(_mainQueryStr, _qv.MainTable.TableName);
                    WriteQueryLog(_mainQueryStr, Environment.TickCount - _GetQueryFinishedTime);
                }
                catch (Exception ex)
                {
                    string _error = string.Format("单查询语句取数据时出错！{0}", ex.Message);
                    WriteQueryLog(_mainQueryStr, Environment.TickCount - _GetQueryFinishedTime);
                    OralceLogWriter.WriteSystemLog(_error, "ERROR");
                    throw new Exception(_error);
                }

            }
            int _GetDataByQueryFinishedTime = Environment.TickCount;

            return _ds;


        }

        private DataSet QueryDataBy_SQL_GDFS(MDModel_QueryModel _qv, MDQuery_Request _queryRequest, int _GetQueryFinishedTime)
        {

            return null;
        }




        public DataTable QueryDataWithWHXH(MDQuery_Request _queryRequest, string _dwdm)
        {

            int _startTime = Environment.TickCount;
            MDModel_QueryModel _qv = GetMDQueryModelDefine(_queryRequest.QueryModelName);
            int _GetQueryFinishedTime = Environment.TickCount;

            //构建查询字符串
            string _QueryStrings = OraQueryBuilder.GetQueryStrWithWHXH(_qv, _queryRequest, _dwdm);
            int _BuildQueryStringFinishedTime = Environment.TickCount;

            //单查询语句
            DataTable _dt = OracleHelper.Get_Data(_QueryStrings, _qv.MainTable.TableName);
            WriteQueryLog(_QueryStrings, Environment.TickCount - _GetQueryFinishedTime);

            int _GetDataByQueryFinishedTime = Environment.TickCount;

            return _dt;
        }

        public string AddNewQueryTask(string _taskName, MDQuery_Request _queryRequest)
        {
            MDModel_QueryModel _qv = GetMDQueryModelDefine(_queryRequest.QueryModelName);
            switch (_qv.QueryInterface)
            {
                case "ORA_JSIS":
                    return AddNewQueryTask_ORA(_taskName, _qv, _queryRequest);

                case "SQL_GDFS":
                    return AddNewQueryTask_SQL(_taskName, _qv, _queryRequest);

            }

            return "";
        }




        /// <summary>
        /// 添加sqlserver查询任务
        /// </summary>
        /// <param name="_queryRequest"></param>
        /// <returns></returns>
        private string AddNewQueryTask_SQL(string _taskName, MDModel_QueryModel _qv, MDQuery_Request _queryRequest)
        {
            string _mainQueryStr = "";
            string _taskid = "";
            //构建查询字符串
            Dictionary<string, string> _resultQueryStrings = SQLQueryBuilder.GetQueryStr(_qv, _queryRequest, ref _mainQueryStr);

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction txn = cn.BeginTransaction();
                _taskid = Guid.NewGuid().ToString();

                AddTaskRecord(_taskid, _taskName, "HGSQL", _queryRequest, cn);


                //用查询字符串取数据
                if (_resultQueryStrings.Count > 0)
                {
                    //多查询语句                                        
                    int i = 0;
                    foreach (string _key in _resultQueryStrings.Keys)
                    {
                        AddTaskSQL(_taskid, i++, (string)_resultQueryStrings[_key], "SELECT", cn);
                    }

                }
                else
                {
                    //单查询语句
                    AddTaskSQL(_taskid, 0, _mainQueryStr, "SELECT", cn);
                }
                txn.Commit();
            }

            return _taskid;
        }
        /// <summary>
        /// 添加本地ORACLE查询任务
        /// </summary>
        /// <param name="_queryRequest"></param>
        /// <returns></returns>
        private string AddNewQueryTask_ORA(string _taskName, MDModel_QueryModel _qv, MDQuery_Request _queryRequest)
        {
            string _mainQueryStr = "";
            string _taskid = "";
            //构建查询字符串
            Dictionary<string, string> _resultQueryStrings = OraQueryBuilder.GetQueryStr(_qv, _queryRequest, ref _mainQueryStr);

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction txn = cn.BeginTransaction();
                _taskid = Guid.NewGuid().ToString();

                AddTaskRecord(_taskid, _taskName, "LOCALORA", _queryRequest, cn);


                //用查询字符串取数据
                if (_resultQueryStrings.Count > 0)
                {
                    //多查询语句                                        
                    string _sqlStr = string.Format("insert into QUERY_TEMP (PK_C) {0}", _mainQueryStr);
                    AddTaskSQL(_taskid, 0, _sqlStr, "DML", cn);
                    int i = 1;
                    foreach (string _key in _resultQueryStrings.Keys)
                    {
                        AddTaskSQL(_taskid, i++, (string)_resultQueryStrings[_key], "SELECT", cn);
                    }

                }
                else
                {
                    //单查询语句
                    AddTaskSQL(_taskid, 0, _mainQueryStr, "SELECT", cn);
                }
                txn.Commit();
            }
            return _taskid;
        }

        private const string SQL_AddTaskSQL = @"insert into TASK_QUERY_SQL (
                                                ID,TASK_ID,XH,SQLCONTEXT,SQLSTATE,SQLTYPE )
                                                values
                                                ( :ID,:TASK_ID,:XH,:SQLCONTEXT,0,:SQLTYPE )";
        /// <summary>
        /// 添加SQL语句
        /// </summary>
        /// <param name="_taskid"></param>
        /// <param name="p"></param>
        /// <param name="_mainQueryStr"></param>
        /// <param name="p_4"></param>
        /// <param name="cn"></param>
        private void AddTaskSQL(string _taskid, int _xh, string _mainQueryStr, string _type, OracleConnection cn)
        {
            string _sqlid = Guid.NewGuid().ToString();

            OracleCommand _cmd = new OracleCommand(SQL_AddTaskSQL, cn);
            _cmd.Parameters.Add(new OracleParameter(":ID", _sqlid));
            _cmd.Parameters.Add(new OracleParameter(":TASK_ID", _taskid));
            _cmd.Parameters.Add(new OracleParameter(":XH", Convert.ToDecimal(_xh)));
            _cmd.Parameters.Add(new OracleParameter(":SQLCONTEXT", _mainQueryStr));
            _cmd.Parameters.Add(new OracleParameter(":SQLTYPE", _type));
            _cmd.ExecuteNonQuery();
        }

        private const string SQL_AddTaskRecord = @"insert into TASK_QUERY
                                                    (ID,TASKNAME,REQUESTTIME,OUTTIME,
                                                    PRIORITY,TASKSTATE,REQUESTUSER,REQUESTPOST,
                                                    QUERYPROGRESS,LOCKRESULT,RESULTCLEARTIME,TASKTYPE,REQUESTSOURCE,SOURCEVIEW)
                                                    values 
                                                    (:ID,:TASKNAME,:REQUESTTIME,sysdate +30,
                                                    0,0,:USERID,:POSTID, 
                                                    0,0,sysdate +200,:TASKTYPE,:REQUESTSOURCE,:SOURCEVIEW)";
        /// <summary>
        /// 添加任务记录
        /// </summary>
        /// <param name="_qv"></param>
        /// <param name="_queryRequest"></param>
        /// <param name="cn"></param>
        private void AddTaskRecord(string _taskid, string _taskName, string _taskType, MDQuery_Request _queryRequest, OracleConnection cn)
        {
            DateTime _requestTime = DateTime.Now;
            int _priority = GetPriority(_queryRequest);
            if (_priority > 0)
            {
                _requestTime = new DateTime(_requestTime.Year, _requestTime.Month, _requestTime.Day, 20, 0, 0);
            }

            //写入查询任务记录
            string _sqlid = Guid.NewGuid().ToString();

            OracleCommand _cmd = new OracleCommand(SQL_AddTaskRecord, cn);
            _cmd.Parameters.Add(new OracleParameter(":ID", _taskid));
            _cmd.Parameters.Add(new OracleParameter(":TASKNAME", _taskName));
            _cmd.Parameters.Add(new OracleParameter(":REQUESTTIME", _requestTime));
            _cmd.Parameters.Add(new OracleParameter(":USERID", decimal.Parse(SinoUserCtx.CurUser.UserID)));
            _cmd.Parameters.Add(new OracleParameter(":POSTID", decimal.Parse(SinoUserCtx.CurUser.CurrentPost.PostID)));
            _cmd.Parameters.Add(new OracleParameter(":TASKTYPE", _taskType));
            _cmd.Parameters.Add(new OracleParameter(":REQUESTSOURCE", "QUERY"));
            _cmd.Parameters.Add(new OracleParameter(":SOURCEVIEW", _queryRequest.QueryModelName));
            _cmd.ExecuteNonQuery();

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            formatter.Serialize(stream, _queryRequest);
            stream.Seek(0, SeekOrigin.Begin);
            byte[] blob = new byte[stream.Length];
            stream.Read(blob, 0, blob.Length);

            stream.Close();

            //写入查询请求内容
            _cmd = new OracleCommand();
            _cmd.CommandText = "update TASK_QUERY set QUERYCONTEXT = :QUERYCONTEXT　 where ID=:ID";
            _cmd.CommandType = CommandType.Text;

            _cmd.Parameters.Add(new OracleParameter(":QUERYCONTEXT", OracleDbType.Blob, blob.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, blob));
            _cmd.Parameters.Add(":ID", _taskid);
            _cmd.Connection = cn;
            _cmd.ExecuteNonQuery();
        }

        private int GetPriority(MDQuery_Request _queryRequest)
        {
            int _ret = 9;
            foreach (MDQuery_ConditionItem _item in _queryRequest.ConditionItems)
            {
                switch (_item.Column.ColumnName)
                {
                    case "ENTRY_ID":
                    case "CONTR_NO":
                    case "MANUAL_NO":
                    case "RELATIVE_ID":
                    case "VOYAGE_NO":
                    case "ENTRY_ID_14":
                    case "TRADE_CO":
                        switch (_item.Operator.Trim())
                        {
                            case "等于":
                            case "集合":
                                return 0;
                        }
                        break;
                    case "I_E_PORT":
                    case "DECL_PORT":
                        switch (_item.Operator.Trim())
                        {
                            case "等于":
                                _ret--;
                                break;
                        }
                        break;

                }


            }
            return _ret;
        }

        /// <summary>
        /// 取查询任务的请求内容
        /// </summary>
        /// <param name="_taskID"></param>
        /// <returns></returns>
        public MDQuery_Request GetQueryTaskRequestContext(string _taskID)
        {
            MDQuery_Request _ret = null;
            string _sql = " select QUERYCONTEXT from TASK_QUERY where ID=:ID";
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand(_sql, cn);
                _cmd.Parameters.Add(":ID", _taskID);

                using (OracleDataReader myOracleDataReader = _cmd.ExecuteReader())
                {
                    myOracleDataReader.Read();
                    OracleBlob myOracleClob = myOracleDataReader.GetOracleBlob(0);
                    myOracleClob.Position = 0;

                    //long lobLength = myOracleClob.Length;
                    //byte[] cbuffer = new byte[lobLength];
                    //actual = myOracleClob.Read(cbuffer, 0, cbuffer.Length);
                    //myOracleDataReader.Close();

                    //MemoryStream _memory = new System.IO.MemoryStream(cbuffer);
                    //_memory.Position = 0;

                    BinaryFormatter formatter = new BinaryFormatter();
                    _ret = formatter.Deserialize(myOracleClob) as MDQuery_Request;
                    //_memory.Close();
                }
                cn.Close();
            }
            return _ret;
        }

        private DataSet MultiQuery(string _mainQueryStr, Dictionary<string, string> _resultQueryStrings)
        {
            string _childSQL = "";
            DataSet _ds = new DataSet();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction txn = cn.BeginTransaction();
                try
                {
                    int _startTime = Environment.TickCount;
                    string _sqlStr = string.Format("insert into QUERY_TEMP (PK_C) {0}", _mainQueryStr);
                    try
                    {
                        OracleHelper.ExecuteNonQuery(cn, CommandType.Text, _sqlStr);
                    }
                    catch (Exception ex)
                    {
                        string _error = string.Format("插入QUERY_TEMP出错:{0}", ex.Message);
                        throw new Exception(_error);
                    }

                    WriteQueryLog(_sqlStr, Environment.TickCount - _startTime);

                    foreach (string _key in _resultQueryStrings.Keys)
                    {
                        _startTime = Environment.TickCount;
                        try
                        {
                            OracleDataAdapter _adapter = new OracleDataAdapter();
                            //Set the select command to fetch product details
                            _childSQL = (string)_resultQueryStrings[_key];
                            DataTable _dt = OracleHelper.FillDataTable(cn, CommandType.Text, _childSQL);
                            _dt.TableName = _key;
                            _ds.Tables.Add(_dt);
                            WriteQueryLog(_childSQL, Environment.TickCount - _startTime);
                        }
                        catch (Exception ex)
                        {
                            WriteQueryLog(_childSQL, Environment.TickCount - _startTime);
                            string _error = string.Format("取{0}表的结果数据出错!{1}", _key, ex.Message);
                            throw new Exception(_error);
                        }
                    }
                    //Fill the DataSet with data from 'Products' database table
                    txn.Commit();
                }
                catch (Exception ex)
                {
                    txn.Rollback();
                    throw ex;
                }
            }
            return _ds;
        }


        public DataTable GetMainTableDataByKey(string _queryModelName, string _mainTableName, string _keyid)
        {
            string _sqlStr = "";
            MDModel_QueryModel _model = GetMDQueryModelDefine(_queryModelName);
            if (_model != null)
            {
                MDModel_Table _maintable = _model.MainTable;
                if (_maintable.TableName != _mainTableName) return null;

                DataTable _ret = new DataTable();
                _ret.TableName = _mainTableName;
                using (OracleConnection cn = OracleHelper.OpenConnection())
                {
                    try
                    {
                        _sqlStr = OraQueryBuilder.GetMainTableData(_maintable, _keyid);
                        _ret = OracleHelper.FillDataTable(cn, CommandType.Text, _sqlStr);

                        cn.Close();
                    }
                    catch (Exception e)
                    {
                        string _errStr = string.Format("通过主键取主表记录时发生错误! QueryModelName={0} MainTableName={1} Key={2} \n\r ErrorMsg:{4} \n\r SQL: {3} ",
                                _queryModelName, _mainTableName, _keyid, _sqlStr, e.Message);
                        OralceLogWriter.WriteSystemLog(_errStr, "ERROR");
                        throw e;
                    }
                }
                return _ret;

            }
            else
            {
                return null;
            }
        }


        public DataTable GetChildTableDataByKey(string _queryModelName, string _childTableName, string _keyid)
        {
            MDModel_QueryModel _model = GetMDQueryModelDefine(_queryModelName);
            string _sqlStr = "";

            if (_model != null)
            {
                if (!_model.ChildTableDict.ContainsKey(_childTableName)) return null;
                MDModel_Table _childTable = _model.ChildTableDict[_childTableName];

                DataTable _ret = new DataTable();
                _ret.TableName = _childTableName;
                using (OracleConnection cn = OracleHelper.OpenConnection())
                {
                    try
                    {
                        _sqlStr = OraQueryBuilder.GetChildTableData(_model.MainTable, _childTable, _keyid);

                        _ret = OracleHelper.FillDataTable(cn, CommandType.Text, _sqlStr);
                        //Fill the DataSet with data from 'Products' database table
                        cn.Close();
                    }
                    catch (Exception e)
                    {
                        string _errStr = string.Format("通过主表主键键取子表记录时发生错误! QueryModelName={0} ChildTableName={1} Key={2} \n\r ErrorMsg:{4} \n\r SQL: {3} ",
                                _queryModelName, _childTableName, _keyid, _sqlStr, e.Message);
                        OralceLogWriter.WriteSystemLog(_errStr, "ERROR");
                        throw e;
                    }
                }
                return _ret;

            }
            else
            {
                return null;
            }
        }

        public string GetMainTableKeyByChildKey(MDSearch_Column _childColumn, string _childKey)
        {
            MDModel_QueryModel _model = GetMDQueryModelDefine(_childColumn.QueryModel.FullName);
            if (_model != null)
            {
                if (_model.MainTable.TableName == _childColumn.TableName)
                {
                    return _childKey;
                }
                else
                {
                    if (!_model.ChildTableDict.ContainsKey(_childColumn.TableName)) return null;
                    MDModel_Table _childTable = _model.ChildTableDict[_childColumn.TableName];
                    string _sqlStr = OraQueryBuilder.GetMainTableKeyByChildKey(_model.MainTable, _childTable, _childKey);
                    OracleParameter[] _param = { new OracleParameter(":CHILDKEY", OracleDbType.Varchar2) };
                    _param[0].Value = _childKey;
                    return OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, _sqlStr, _param).ToString();
                }
            }
            else
            {
                return null;
            }
        }

        public string GetMainTableKeyByColumnCondition(string _modelName, string _columnName, string _data)
        {
            MDModel_QueryModel _model = GetMDQueryModelDefine(_modelName);
            if (_model != null)
            {
                if (_model.MainTable.TableDefine.Table.MainKey == _columnName)
                {
                    return _data;
                }
                else
                {
                    string _sqlStr = OraQueryBuilder.GetMainTableKeyByColumnCondition(_model.MainTable, _columnName, _data);

                    return OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, _sqlStr).ToString();
                }
            }
            else
            {
                return "";
            }
        }

        public int GetChildTableCountByKey(string _queryModelName, string _childTableName, string _keyid)
        {
            MDModel_QueryModel _model = GetMDQueryModelDefine(_queryModelName);
            if (_model != null)
            {
                if (!_model.ChildTableDict.ContainsKey(_childTableName)) return 0;
                MDModel_Table _childTable = _model.ChildTableDict[_childTableName];
                string _sqlStr = OraQueryBuilder.GetChildTableCount(_model.MainTable, _childTable, _keyid);
                decimal _count = (decimal)OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, _sqlStr, null);

                return Convert.ToInt32(_count);

            }
            else
            {
                return 0;
            }
        }

        public List<MDQuery_ChildTableRowCount> GetChildRowCountList(string _queryModelName, string _keyid)
        {
            List<MDQuery_ChildTableRowCount> _ret = new List<MDQuery_ChildTableRowCount>();
            SinoSZStopWatch _watch = new SinoSZStopWatch();
            MDModel_QueryModel _model = GetMDQueryModelDefine(_queryModelName);
            _watch.Tick("取查询模型用时");

            if (_model != null)
            {
                foreach (MDModel_Table _ctable in _model.ChildTableDict.Values)
                {
                    int _startTime = Environment.TickCount;
                    string _sqlStr = OraQueryBuilder.GetChildTableCount(_model.MainTable, _ctable, _keyid);
                    int _count = Convert.ToInt32(OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, _sqlStr, null));
                    int _endTime = Environment.TickCount;
                    WriteQueryLog(_sqlStr, _endTime - _startTime);
                    MDQuery_ChildTableRowCount _item = new MDQuery_ChildTableRowCount(_ctable.TableName, _count);
                    _ret.Add(_item);
                }
            }
            _watch.Tick("取子表记录用时");
            return _ret;
        }

        private const string SQL_WriteQueryLog = @"insert into query_log (ID,SJ,USETIME,QUERY_STR,LX,YHID)
                                                 values (SEQ_ZHTJ.NEXTVAL,sysdate,:USETIME,:QUERY_STR,'1',:YHID)  ";
        private void WriteQueryLog(string _sqlStr, int _userTime)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                OracleCommand _cmd = new OracleCommand(SQL_WriteQueryLog, cn);
                _cmd.CommandType = CommandType.Text;
                _cmd.Parameters.Add(":USETIME", Convert.ToDecimal(_userTime));
                _cmd.Parameters.Add(":QUERY_STR", (_sqlStr.Length > 2000) ? _sqlStr.Substring(0, 2000) : _sqlStr);
                _cmd.Parameters.Add(":YHID", decimal.Parse(SinoUserCtx.CurUser.UserID));
                _cmd.ExecuteNonQuery();
                _txn.Commit();
            }
        }

        private void WriteQueryLogBySystem(string _sqlStr, int _userTime)
        {
            string _sql = "insert into query_log (ID,SJ,USETIME,QUERY_STR,LX,YHID) ";
            _sql += " values (SEQ_ZHTJ.NEXTVAL,sysdate,:USETIME,:QUERY_STR,'1',:YHID) ";
            OracleParameter[] _param = { 
                                new OracleParameter(":USETIME", OracleDbType.Decimal), 
                                new OracleParameter(":QUERY_STR", OracleDbType.Varchar2,4000), 
                                new OracleParameter(":YHID", OracleDbType.Decimal) 
                                };
            _param[0].Value = Convert.ToDecimal(_userTime);
            _param[1].Value = (_sqlStr.Length > 2000) ? _sqlStr.Substring(0, 2000) : _sqlStr;
            _param[2].Value = (decimal)0;
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);
        }

        public List<MD_ConceptGroup> GetConceptList()
        {
            List<MD_ConceptGroup> _ret = new List<MD_ConceptGroup>();

            string _sql = "select groupname,groupdes,dwdm,displayorder from md_conceptgroup ";

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text,
                                           _sql);

            while (dr.Read())
            {
                MD_ConceptGroup _group = new MD_ConceptGroup(dr.IsDBNull(0) ? "" : dr.GetString(0),
                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                        dr.IsDBNull(2) ? "" : dr.GetString(2),
                        dr.IsDBNull(3) ? 0 : Convert.ToInt32(dr.GetDecimal(3)));
                _group.Items = GetSubConceptTag(_group.Name);
                _ret.Add(_group);
            }
            dr.Close();
            return _ret;
        }

        public List<MD_ConceptItem> GetSubConceptTag(string _groupName)
        {
            List<MD_ConceptItem> _ret = new List<MD_ConceptItem>();
            string _sql = "select CTAG,DESCRIPT,CRULE,GROUPNAME,DWDM,DISPLAYORDER from md_concept ";
            _sql += " where GROUPNAME = :GROUPNAME ";
            OracleParameter[] _param = { new OracleParameter(":GROUPNAME", OracleDbType.Varchar2) };
            _param[0].Value = _groupName;
            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text,
                                          _sql, _param);

            while (dr.Read())
            {
                MD_ConceptItem _item = new MD_ConceptItem(dr.IsDBNull(0) ? "" : dr.GetString(0),
                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                        dr.IsDBNull(3) ? "" : dr.GetString(3),
                        dr.IsDBNull(2) ? "" : dr.GetString(2),
                        dr.IsDBNull(4) ? "" : dr.GetString(4),
                        dr.IsDBNull(5) ? 0 : Convert.ToInt32(dr.GetDecimal(5)));
                _ret.Add(_item);
            }
            dr.Close();
            return _ret;
        }


        public List<MD_QueryModel> GetQueryModels(string _queryModelNames)
        {
            OraMetaDataFactroy _of = new OraMetaDataFactroy();
            List<MD_QueryModel> _ret = new List<MD_QueryModel>();
            foreach (string _qmName in _queryModelNames.Split(','))
            {
                MD_QueryModel _qv = _of.GetQueryModelByName(_qmName);
                _ret.Add(_qv);
            }
            return _ret;
        }

        public List<MDSearch_Column> GetSearchResultColumn(string _searchText, int _searchType, string _searchConceptGroup, string _queryModelName)
        {
            string[] _modelNames = _queryModelName.Split('.');
            List<MDSearch_Column> _ret = new List<MDSearch_Column>();
            StringBuilder _sb = new StringBuilder();
            _sb.Append(" select a.namespace,a.tid,a.tablename,a.displayname tdname,a.mainkey,");
            _sb.Append(" b.tcid,b.columnname,b.displaytitle cdname,b.type columntype,");
            _sb.Append(" b.refdmb refdmb,b.ctag,a.secretfun,v.displayname vdname");
            _sb.Append(" from md_table a");
            _sb.Append(" join md_tablecolumn b on a.tid = b.tid");
            _sb.Append(" join md_viewtable vt on vt.tid = a.tid");
            _sb.Append(" join md_view v on v.viewid = vt.viewid");
            _sb.Append(" where v.namespace = :NAMESPACE ");
            _sb.Append(" AND V.VIEWNAME=:VIEWNAME ");

            List<MD_ConceptItem> _tags = GetSubConceptTag(_searchConceptGroup);
            if (_tags.Count < 1)
            {
                return new List<MDSearch_Column>();
            }

            string _fgf = "AND (";
            foreach (MD_ConceptItem _tag in _tags)
            {
                _sb.Append(string.Format(" {0} b.CTAG LIKE '%{1}%' ", _fgf, _tag));
                _fgf = "OR";
            }
            if (_fgf == "OR")
            {
                _sb.Append(" )");
            }

            OracleParameter[] _param = { new OracleParameter(":NAMESPACE", OracleDbType.Varchar2),
                                                                        new OracleParameter(":VIEWNAME",OracleDbType.Varchar2)};
            _param[0].Value = _modelNames[0];
            _param[1].Value = _modelNames[1];
            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text,
                                          _sb.ToString(), _param);

            while (dr.Read())
            {
                MDSearch_Column _item = new MDSearch_Column(_queryModelName,
                        dr.IsDBNull(2) ? "" : dr.GetString(2),
                        dr.IsDBNull(3) ? "" : dr.GetString(3),
                        dr.IsDBNull(6) ? "" : dr.GetString(6),
                        dr.IsDBNull(7) ? "" : dr.GetString(7),
                        dr.IsDBNull(4) ? "" : dr.GetString(4));
                _ret.Add(_item);
            }
            dr.Close();
            return _ret;
        }

        public List<MDSearch_ResultDataIndex> GetSearchResult(string _searchText, int _searchType, MDSearch_Column _sc)
        {
            string _sqlConcept = "";
            string _stext = _searchText;
            string _conditionStr = "";

            MDModel_QueryModel _qv = GetMDQueryModelDefine(_sc.QueryModel.FullName);
            List<MDSearch_ResultDataIndex> _ret = new List<MDSearch_ResultDataIndex>();
            string _filterStr = OraQueryBuilder.CreateDataFilterStr(_qv);


            if (_searchType == 1)
            {
                _conditionStr = string.Format(" {2}.{0} = '{1}' ", _sc.ColumnName, _stext, _sc.TableName);
            }
            else
            {
                //如果是模糊
                _stext = _stext.Replace(' ', '%');
                _stext = string.Format("%{0}%", _stext);
                _conditionStr = string.Format(" {2}.{0} like '{1}' ", _sc.ColumnName, _stext, _sc.TableName);
            }

            if (_qv.MainTable.TableName == _sc.TableName)
            {
                _sqlConcept = string.Format("select {0} RESDATA,{1} MAINKEY from {2} where {3} {4}  ", _sc.ColumnName, _sc.TableKeyColumn, _sc.TableName,
                        _filterStr, _conditionStr);
            }
            else
            {
                List<string> _tableList = new List<string>();
                _tableList.Add(_qv.MainTable.TableName);
                _tableList.Add(_sc.TableName);
                string _tableRelationStr = OraQueryBuilder.CreateTableRelationString(_qv, _tableList);
                _sqlConcept = string.Format("select {2}.{0} RESDATA,{2}.{1} MAINKEY from {2},{3} where {4}  ( {5} ({6})) ", _sc.ColumnName, _sc.TableKeyColumn, _sc.TableName,
                        _qv.MainTable.TableName, _filterStr, _tableRelationStr, _conditionStr);
            }


            //筛选权限范围记录
            //if (_sfun != "")
            //{
            //        _sqlConcept += string.Format(" and {2}({0}.ZHCX_DW,'{1}') = '1' ", _sc.TableName, SinoUserCtx.CurUser.CurrentPost.PostDWDM, _sfun);
            //}

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sqlConcept);
            string _sourceStr = _sc.QueryModel.DisplayTitle;
            while (dr.Read())
            {
                MDSearch_ResultDataIndex _item = new MDSearch_ResultDataIndex(dr.IsDBNull(0) ? "" : dr.GetString(0),
                        0, _sc, _sourceStr, dr.IsDBNull(1) ? "" : dr.GetValue(1).ToString());
                _ret.Add(_item);
            }
            dr.Close();
            return _ret;
        }

        public List<MD_GuideLine> GetRootGuideLineList(string rootGuideLines)
        {
            List<MD_GuideLine> _ret = new List<MD_GuideLine>();

            StringBuilder _sql = new StringBuilder();
            _sql.Append(" select ID,ZBMC,ZBZT,ZBSF, ZBMETA,FID,ZBCXSF,JSMX_ZBMETA,XSXH, ZBSM ");
            _sql.Append(" from TJ_ZDYZBDYB where ID in ( ");
            _sql.Append(rootGuideLines);
            _sql.Append(" ) ");


            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql.ToString());

            while (dr.Read())
            {
                MD_GuideLine _vt = new MD_GuideLine(
                        dr.GetOracleDecimal(0).Value.ToString(),
                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                        dr.IsDBNull(2) ? "" : dr.GetString(2),
                        dr.IsDBNull(3) ? "" : dr.GetString(3),
                        dr.IsDBNull(4) ? "" : dr.GetString(4),
                        dr.IsDBNull(5) ? "0" : dr.GetOracleDecimal(5).Value.ToString(),
                        dr.IsDBNull(6) ? "" : dr.GetString(6),
                        dr.IsDBNull(7) ? "" : dr.GetString(7),
                        dr.IsDBNull(8) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(8).Value),
                        dr.IsDBNull(9) ? "" : dr.GetString(9)
                        );
                _ret.Add(_vt);
            }
            dr.Close();

            return _ret;
        }

        public List<MD_GuideLine> GetGuideLineListByFatherID(string _fatherGuildLineID)
        {
            List<MD_GuideLine> _ret = new List<MD_GuideLine>();

            StringBuilder _sql = new StringBuilder();
            _sql.Append(" select ID,ZBMC,ZBZT,ZBSF, ZBMETA,FID,ZBCXSF,JSMX_ZBMETA,XSXH,ZBSM ");
            _sql.Append(" from TJ_ZDYZBDYB where FID=:FID order by XSXH asc");
            OracleParameter[] _param = {
                                new OracleParameter(":FID",OracleDbType.Decimal)
                               
                        };
            _param[0].Value = decimal.Parse(_fatherGuildLineID);

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql.ToString(), _param);

            while (dr.Read())
            {
                MD_GuideLine _vt = new MD_GuideLine(
                        dr.GetOracleDecimal(0).Value.ToString(),
                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                        dr.IsDBNull(2) ? "" : dr.GetString(2),
                        dr.IsDBNull(3) ? "" : dr.GetString(3),
                        dr.IsDBNull(4) ? "" : dr.GetString(4),
                        dr.IsDBNull(5) ? "0" : dr.GetOracleDecimal(5).Value.ToString(),
                        dr.IsDBNull(6) ? "" : dr.GetString(6),
                        dr.IsDBNull(7) ? "" : dr.GetString(7),
                        dr.IsDBNull(8) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(8).Value),
                        dr.IsDBNull(9) ? "" : dr.GetString(9)
                        );
                _ret.Add(_vt);
            }
            dr.Close();
            return _ret;
        }

        public DataTable QueryGuideLine(string _guideLineID, List<MDQuery_GuideLineParameter> _param)
        {
            List<MD_GuideLine> _gls = GetRootGuideLineList(_guideLineID);
            if (_gls.Count < 1) return null;
            int _GetQueryFinishedTime = Environment.TickCount;
            MD_GuideLine _glDefine = _gls[0];
            string _queryStr = _glDefine.GuideLineMethod;
            if (_param != null)
            {
                foreach (MDQuery_GuideLineParameter _gp in _param)
                {
                    _queryStr = OraQueryBuilder.RebuildGuideLineQueryString(_queryStr, _gp);
                }
            }
            _queryStr = OraQueryBuilder.ReplaceExtSecret(_queryStr, "");
            DataTable _ret = OracleHelper.FillDataTable(OracleHelper.ConnectionStringProfile, CommandType.Text, _queryStr);
            WriteQueryLog(_queryStr, Environment.TickCount - _GetQueryFinishedTime);
            return _ret;
        }

        public DataTable QueryGuideLineNoUserInfo(string _guideLineID, List<MDQuery_GuideLineParameter> _param)
        {
            List<MD_GuideLine> _gls = GetRootGuideLineList(_guideLineID);
            if (_gls.Count < 1) return null;
            int _GetQueryFinishedTime = Environment.TickCount;
            MD_GuideLine _glDefine = _gls[0];
            string _queryStr = _glDefine.GuideLineMethod;
            if (_param != null)
            {
                foreach (MDQuery_GuideLineParameter _gp in _param)
                {
                    _queryStr = OraQueryBuilder.RebuildGuideLineQueryString(_queryStr, _gp);
                }
            }
            _queryStr = OraQueryBuilder.ReplaceExtSecretNoUserInfo(_queryStr);
            DataTable _ret = OracleHelper.FillDataTable(OracleHelper.ConnectionStringProfile, CommandType.Text, _queryStr);
            WriteQueryLogBySystem(_queryStr, Environment.TickCount - _GetQueryFinishedTime);
            return _ret;
        }

        public void ExcuteQueryGuideLine(string _guideLineID, List<MDQuery_GuideLineParameter> _param)
        {
            List<MD_GuideLine> _gls = GetRootGuideLineList(_guideLineID);
            if (_gls.Count < 1) return;
            int _GetQueryFinishedTime = Environment.TickCount;
            MD_GuideLine _glDefine = _gls[0];
            string _queryStr = _glDefine.GuideLineMethod;
            foreach (MDQuery_GuideLineParameter _gp in _param)
            {
                _queryStr = OraQueryBuilder.RebuildGuideLineQueryString(_queryStr, _gp);
            }
            _queryStr = OraQueryBuilder.ReplaceExtSecret(_queryStr, "");
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _queryStr);
        }

        public int QueryGuideLineResultCount(string _guideLineID, List<MDQuery_GuideLineParameter> _params)
        {
            List<MD_GuideLine> _gls = GetRootGuideLineList(_guideLineID);
            if (_gls.Count < 1) return -1;
            int _GetQueryFinishedTime = Environment.TickCount;
            MD_GuideLine _glDefine = _gls[0];
            string _queryStr = _glDefine.GuideLineMethod;
            foreach (MDQuery_GuideLineParameter _gp in _params)
            {
                _queryStr = OraQueryBuilder.RebuildGuideLineQueryString(_queryStr, _gp);
            }
            _queryStr = OraQueryBuilder.ReplaceExtSecret(_queryStr, "");
            string _sqlCount = string.Format("select count(*) from ({0}) ", _queryStr);
            decimal _ret = (decimal)OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, _sqlCount);

            WriteQueryLog(_sqlCount, Environment.TickCount - _GetQueryFinishedTime);
            return Convert.ToInt32(_ret);

        }


        public DataTable QueryGuideLineNoUserRight(string _guideLineID, List<MDQuery_GuideLineParameter> _param)
        {
            List<MD_GuideLine> _gls = GetRootGuideLineList(_guideLineID);
            if (_gls.Count < 1) return null;
            int _GetQueryFinishedTime = Environment.TickCount;
            MD_GuideLine _glDefine = _gls[0];
            string _queryStr = _glDefine.GuideLineMethod;
            foreach (MDQuery_GuideLineParameter _gp in _param)
            {
                _queryStr = OraQueryBuilder.RebuildGuideLineQueryString(_queryStr, _gp);
            }
            _queryStr = OraQueryBuilder.ReplaceFunction(_queryStr);
            DataTable _ret = OracleHelper.FillDataTable(OracleHelper.ConnectionStringProfile, CommandType.Text, _queryStr);
            return _ret;
        }

        public DataTable QueryGuideLineByDefault(string _guideLineID, List<MDQuery_GuideLineParameter> _param)
        {
            List<MD_GuideLine> _gls = GetRootGuideLineList(_guideLineID);
            if (_gls.Count < 1) return null;
            int _GetQueryFinishedTime = Environment.TickCount;
            MD_GuideLine _glDefine = _gls[0];
            string _queryStr = _glDefine.GuideLineMethod;
            foreach (MDQuery_GuideLineParameter _gp in _param)
            {
                _queryStr = OraQueryBuilder.RebuildGuideLineQueryStringByDefault(_queryStr, _gp);
            }
            _queryStr = OraQueryBuilder.ReplaceExtSecret(_queryStr, "");
            DataTable _ret = OracleHelper.FillDataTable(OracleHelper.ConnectionStringProfile, CommandType.Text, _queryStr);
            WriteQueryLog(_queryStr, Environment.TickCount - _GetQueryFinishedTime);
            return _ret;
        }


        public MD_GuideLine GetGuideLineByID(string _guideLineID)
        {
            MD_GuideLine _ret = null;

            StringBuilder _sql = new StringBuilder();
            _sql.Append(" select ID,ZBMC,ZBZT,ZBSF, ZBMETA,FID,ZBCXSF,JSMX_ZBMETA,XSXH,ZBSM ");
            _sql.Append(" from TJ_ZDYZBDYB where ID=:ID ");
            OracleParameter[] _param = {
                                new OracleParameter(":ID",OracleDbType.Decimal)
                               
                        };
            _param[0].Value = decimal.Parse(_guideLineID);

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql.ToString(), _param);

            while (dr.Read())
            {
                _ret = new MD_GuideLine(
                        dr.GetOracleDecimal(0).Value.ToString(),
                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                        dr.IsDBNull(2) ? "" : dr.GetString(2),
                        dr.IsDBNull(3) ? "" : dr.GetString(3),
                        dr.IsDBNull(4) ? "" : dr.GetString(4),
                        dr.IsDBNull(5) ? "0" : dr.GetOracleDecimal(5).Value.ToString(),
                        dr.IsDBNull(6) ? "" : dr.GetString(6),
                        dr.IsDBNull(7) ? "" : dr.GetString(7),
                        dr.IsDBNull(8) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(8).Value),
                         dr.IsDBNull(9) ? "" : dr.GetString(9)
                        );

            }
            dr.Close();
            return _ret;
        }


        public List<MDQuery_Task> GetQueryTaskList()
        {
            List<MDQuery_Task> _ret = new List<MDQuery_Task>();
            StringBuilder _sql = new StringBuilder();
            _sql.Append(" select ID,TASKNAME,REQUESTTIME,OUTTIME,PRIORITY,TASKSTATE,FINISHEDTIME, ");
            _sql.Append(" REQUESTUSER,REQUESTPOST,LOCKRESULT,RESULTCLEARTIME,TASKTYPE,");
            _sql.Append(" (select GWMC from QX2_GWDYB where GWID=REQUESTPOST) GWMC, ");
            _sql.Append(" (select ZHTJ_ZZJG2.GETDWMC(GWDWID) from QX2_GWDYB where GWID=REQUESTPOST) GWDWMC ");
            _sql.Append(" from TASK_QUERY where REQUESTUSER=:REQUESTUSER and TASKSTATE<11 and REQUESTSOURCE='QUERY' ");
            _sql.Append(" order by REQUESTTIME desc ");
            OracleParameter[] _param = {
                                new OracleParameter(":REQUESTUSER",OracleDbType.Decimal)
                               
                        };
            _param[0].Value = decimal.Parse(SinoUserCtx.CurUser.UserID);

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql.ToString(), _param);

            while (dr.Read())
            {
                MDQuery_Task _task = new MDQuery_Task(
                        dr.GetString(0),
                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                        dr.IsDBNull(2) ? DateTime.MinValue : dr.GetDateTime(2),
                        dr.IsDBNull(3) ? DateTime.MinValue : dr.GetDateTime(3),
                        dr.IsDBNull(4) ? 0 : Convert.ToInt32(dr.GetDecimal(4)),
                        dr.IsDBNull(5) ? 0 : Convert.ToInt32(dr.GetDecimal(5)),
                        dr.IsDBNull(6) ? (DateTime?)null : (DateTime?)dr.GetDateTime(6),
                        SinoUserCtx.CurUser.UserID,
                        SinoUserCtx.CurUser.UserName,
                        dr.IsDBNull(8) ? "" : dr.GetDecimal(8).ToString(),
                        dr.IsDBNull(12) ? "" : dr.GetString(12),
                        dr.IsDBNull(13) ? "" : dr.GetString(13),
                        dr.IsDBNull(9) ? false : (dr.GetDecimal(9) > 0),
                        dr.IsDBNull(10) ? DateTime.MinValue : dr.GetDateTime(10),
                        dr.IsDBNull(11) ? "LOCALORA" : dr.GetString(11)
                        );
                _ret.Add(_task);
            }
            dr.Close();
            return _ret;
        }

        public MDQuery_Task GetQueryTaskStateByID(string _taskID)
        {
            MDQuery_Task _ret = null;
            StringBuilder _sql = new StringBuilder();
            _sql.Append(" select ID,TASKNAME,REQUESTTIME,OUTTIME,PRIORITY,TASKSTATE,FINISHEDTIME, ");
            _sql.Append(" REQUESTUSER,REQUESTPOST,LOCKRESULT,RESULTCLEARTIME,TASKTYPE,");
            _sql.Append(" (select GWMC from QX2_GWDYB where GWID=REQUESTPOST) GWMC, ");
            _sql.Append(" (select ZHTJ_ZZJG2.GETDWMC(GWDWID) from QX2_GWDYB where GWID=REQUESTPOST) GWDWMC ");
            _sql.Append(" from TASK_QUERY where ID=:ID");
            OracleParameter[] _param = {
                                new OracleParameter(":ID",OracleDbType.Varchar2)
                               
                        };
            _param[0].Value = _taskID;

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql.ToString(), _param);

            while (dr.Read())
            {
                _ret = new MDQuery_Task(
                       dr.GetString(0),
                       dr.IsDBNull(1) ? "" : dr.GetString(1),
                       dr.IsDBNull(2) ? DateTime.MinValue : dr.GetDateTime(2),
                       dr.IsDBNull(3) ? DateTime.MinValue : dr.GetDateTime(3),
                       dr.IsDBNull(4) ? 0 : Convert.ToInt32(dr.GetDecimal(4)),
                       dr.IsDBNull(5) ? 0 : Convert.ToInt32(dr.GetDecimal(5)),
                       dr.IsDBNull(6) ? DateTime.MinValue : dr.GetDateTime(6),
                       SinoUserCtx.CurUser.UserID,
                       SinoUserCtx.CurUser.UserName,
                       dr.IsDBNull(8) ? "" : dr.GetDecimal(8).ToString(),
                       dr.IsDBNull(12) ? "" : dr.GetString(12),
                       dr.IsDBNull(13) ? "" : dr.GetString(13),
                       dr.IsDBNull(9) ? false : (dr.GetDecimal(9) > 0),
                       dr.IsDBNull(10) ? DateTime.MinValue : dr.GetDateTime(10),
                       dr.IsDBNull(11) ? "LOCALORA" : dr.GetString(11)
                       );

            }
            dr.Close();
            return _ret;
        }

        public bool ClearQueryTask(string _taskID)
        {
            StringBuilder _sql = new StringBuilder();
            _sql.Append(" update TASK_QUERY set ");
            _sql.Append(" TASKSTATE=11 ");
            _sql.Append(" where ID=:ID and REQUESTUSER=:REQUESTUSER");

            string _delChild = "delete from TASK_QUERY_SQL where TASK_ID=:TASK_ID";

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction txn = cn.BeginTransaction();
                List<OracleParameter> _plist = new List<OracleParameter>(); //OracleCommand _cmd = new OracleCommand(_sql.ToString(), cn);
                _plist.Add(new OracleParameter(":ID", _taskID));
                _plist.Add(new OracleParameter(":REQUESTUSER", decimal.Parse(SinoUserCtx.CurUser.UserID)));
                OracleHelper.ExecuteNonQuery(cn, CommandType.Text, _sql.ToString(), _plist.ToArray());

                OracleCommand _cmd2 = new OracleCommand(_delChild, cn);
                _cmd2.Parameters.Add(":TASK_ID", _taskID);
                _cmd2.ExecuteNonQuery();
                txn.Commit();
                cn.Close();
            }
            return true;
        }

        private const string SQL_LockQueryTaskResult = @"update TASK_QUERY set LOCKRESULT=1  where ID=:ID and REQUESTUSER=:REQUESTUSER";
        public bool LockQueryTaskResult(string _taskID)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction txn = cn.BeginTransaction();
                OracleCommand _cmd = new OracleCommand(SQL_LockQueryTaskResult, cn);
                _cmd.Parameters.Add(":ID", _taskID);
                _cmd.Parameters.Add(":REQUESTUSER", decimal.Parse(SinoUserCtx.CurUser.UserID));
                _cmd.ExecuteNonQuery();
                txn.Commit();
                cn.Close();
            }
            return true;
        }

        private const string SQL_CancleQueryTask = @"update TASK_QUERY set TASKSTATE=4 where ID=:ID and REQUESTUSER=:REQUESTUSER ";
        public bool CancleQueryTask(string _taskID)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction txn = cn.BeginTransaction();
                OracleCommand _cmd = new OracleCommand(SQL_CancleQueryTask, cn);
                _cmd.Parameters.Add(":ID", _taskID);
                _cmd.Parameters.Add(":REQUESTUSER", decimal.Parse(SinoUserCtx.CurUser.UserID));
                _cmd.ExecuteNonQuery();
                txn.Commit();
                cn.Close();
            }
            return true;
        }

        public List<MD_CheckRule> GetDataCheckRuleDefine(string QueryModelName)
        {
            SinoUser _su = SinoUserCtx.CurUser;
            List<MD_CheckRule> _ret = new List<MD_CheckRule>();
            string[] _qvs = QueryModelName.Split('.');
            string _sql = "select ID,GZMC,GZSF,DWDM,STATE from SJSH_SHGZB where NAMESPACE= :NS and VIEWNAME=:MODEL and DWDM=:DWDM";
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand(_sql, cn);
                _cmd.Parameters.Add(":NS", _qvs[0]);
                _cmd.Parameters.Add(":MODEL", _qvs[1]);
                _cmd.Parameters.Add(":DWDM", _su.CurrentPost.PostDWDM);

                OracleDataReader dr = _cmd.ExecuteReader();
                while (dr.Read())
                {
                    MD_CheckRule _rule = new MD_CheckRule(
                            dr.IsDBNull(0) ? "" : dr.GetDecimal(0).ToString(),
                            QueryModelName,
                            dr.IsDBNull(1) ? "" : dr.GetString(1),
                            dr.IsDBNull(2) ? "" : dr.GetString(2),
                            dr.IsDBNull(3) ? "" : dr.GetString(3),
                            dr.IsDBNull(4) ? false : (dr.GetDecimal(4) > 0)
                    );
                    _ret.Add(_rule);
                }
                dr.Close();
                cn.Close();
            }
            //写用户操作日志
            WriteUserActionLog("取数据审核规则", string.Format("用户={0} 岗位所在单位={1} QuerModel={2} 返回规则数={3}", _su.UserName, _su.CurrentPost.PostDWDM, QueryModelName, _ret.Count()));
            return _ret;
        }

        public bool WriteUserActionLog(string _type, string _msg)
        {
            try
            {
                SinoUser _su = SinoUserCtx.CurUser;
                OralceLogWriter.WriteUserLog(decimal.Parse(_su.UserID), _type, _msg, 1, _su.IPAddress, _su.HostName, _su.SystemID);
                return true;
            }
            catch (Exception ex)
            {
                OralceLogWriter.WriteSystemLog(string.Format("在写用户日志时出错:{2},type={0},msg={1}", _type, _msg, ex.Message), "ERROR");
                return false;
            }
        }

        public void SaveCheckRuleState(string QueryModelName, List<MD_CheckRule> _ruleList)
        {
            string _clearSql = "update SJSH_SHGZB set STATE=0 where NAMESPACE= :NS and VIEWNAME=:MODEL and DWDM=:DWDM";
            string _updateSql = "update SJSH_SHGZB set STATE=1 where  ID=:ID";
            string[] _qvs = QueryModelName.Split('.');

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction txn = cn.BeginTransaction();
                OracleCommand _cmd = new OracleCommand(_clearSql, cn);
                _cmd.Parameters.Add(":NS", _qvs[0]);
                _cmd.Parameters.Add(":MODEL", _qvs[1]);
                _cmd.Parameters.Add(":DWDM", SinoUserCtx.CurUser.CurrentPost.PostDWDM);
                _cmd.ExecuteNonQuery();
                foreach (MD_CheckRule _rule in _ruleList)
                {
                    OracleCommand _cmd2 = new OracleCommand(_updateSql, cn);
                    _cmd2.Parameters.Add(":ID", decimal.Parse(_rule.ID));
                    _cmd.ExecuteNonQuery();
                }
                txn.Commit();
                cn.Close();
            }
            return;
        }


        public DataSet GetTaskQueryResult_DataSet(string _taskID)
        {
            DataSet _ret = new DataSet();
            //取查询请求
            string _taskType = "";
            MDQuery_Request _request = GetQueryTaskRequestContext(_taskID, ref _taskType);
            int _xh = 0;

            DataSet MainResult = GetTaskQueryResultData(_taskID, _xh++);
            DataTable _dt = MainResult.Tables[0];
            if (_taskType == "HGSQL") ChangeRefCodeData(_dt, _request, _request.MainResultTable);
            MainResult.Tables.Remove(_dt);
            _ret.Tables.Add(_dt);
            _dt.TableName = _request.MainResultTable.TableName;
            MainResult.Dispose();

            foreach (MDQuery_ResultTable _table in _request.ChildResultTables)
            {
                DataSet _childResult = GetTaskQueryResultData(_taskID, _xh++);
                DataTable _cdt = _childResult.Tables[0];
                if (_taskType == "HGSQL") ChangeRefCodeData(_cdt, _request, _table);
                _childResult.Tables.Remove(_cdt);
                _ret.Tables.Add(_cdt);
                _cdt.TableName = _table.TableName;

            }

            _ret.RemotingFormat = SerializationFormat.Binary;
            return _ret;
        }

        private void ChangeRefCodeData(DataTable _dt, MDQuery_Request _request, MDQuery_ResultTable _ResultTable)
        {
            foreach (MDQuery_TableColumn _rc in _ResultTable.Columns)
            {
                string _aliasName = _rc.ColumnAlias;
                if (_rc.RefDMB != "")
                {
                    Dictionary<string, string> _refTB = GetRefTableDictionary(_rc.RefDMB);
                    foreach (DataRow _dr in _dt.Rows)
                    {
                        string _data = _dr.IsNull(_aliasName) ? "" : _dr[_aliasName].ToString();
                        if (_refTB.ContainsKey(_data))
                        {
                            _dr[_aliasName] = _refTB[_data];
                        }
                    }
                }
            }
            _dt.AcceptChanges();
        }


        private Dictionary<string, string> GetRefTableDictionary(string _refTableName)
        {
            Dictionary<string, string> _ret = new Dictionary<string, string>();
            string _sql = string.Format("select dm,mc from jsods.{0}", OraCommandSecretCheck.CheckTableName(_refTableName));
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                //OracleCommand _cmd = new OracleCommand(_sql, cn);
                OracleDataReader _dr = OracleHelper.ExecuteReader(cn, CommandType.Text, _sql);
                while (_dr.Read())
                {
                    string _dm = _dr.IsDBNull(0) ? "" : _dr.GetString(0);
                    string _mc = _dr.IsDBNull(1) ? "" : _dr.GetString(1);
                    _ret.Add(_dm, _mc);
                }
                _dr.Close();
                cn.Close();
            }
            return _ret;
        }

        private const string SQL_GetQueryTaskRequestContext = @"select QUERYCONTEXT,TASKTYPE from TASK_QUERY where ID=:ID";
        private MDQuery_Request GetQueryTaskRequestContext(string _taskID, ref string TaskType)
        {
            MDQuery_Request _ret = null;
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand(SQL_GetQueryTaskRequestContext, cn);
                _cmd.Parameters.Add(":ID", _taskID);

                using (OracleDataReader myOracleDataReader = _cmd.ExecuteReader())
                {
                    myOracleDataReader.Read();
                    TaskType = myOracleDataReader.GetString(1);
                    OracleBlob myOracleClob = myOracleDataReader.GetOracleBlob(0);
                    myOracleClob.Position = 0;

                    //long lobLength = myOracleClob.Length;
                    //byte[] cbuffer = new byte[lobLength];
                    //actual = myOracleClob.Read(cbuffer, 0, cbuffer.Length);
                    //myOracleDataReader.Close();

                    //MemoryStream _memory = new System.IO.MemoryStream(cbuffer);
                    //_memory.Position = 0;

                    BinaryFormatter formatter = new BinaryFormatter();
                    _ret = formatter.Deserialize(myOracleClob) as MDQuery_Request;
                    //_memory.Close();
                }
                cn.Close();
            }
            return _ret;
        }

        private const string SQL_GetTaskQueryResult_DataSet = " select QUERYRESULT_B  from TASK_QUERY_SQL where TASK_ID=:TID and XH=:XH";
        private DataSet GetTaskQueryResultData(string _taskID, int _xh)
        {
            DataSet _ret = new DataSet();

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_GetTaskQueryResult_DataSet, cn);
                    _cmd.Parameters.Add(":TID", _taskID);
                    _cmd.Parameters.Add(":XH", Convert.ToDecimal(_xh));

                    using (OracleDataReader myOracleDataReader = _cmd.ExecuteReader())
                    {
                        myOracleDataReader.Read();
                        OracleBlob myOracleClob = myOracleDataReader.GetOracleBlob(0);
                        myOracleClob.Position = 0;
                        _ret.ReadXml(myOracleClob);
                    }

                }
                catch (Exception ex)
                {
                    string _errmsg = string.Format("取任务查询的结果数据时发生错误TASKID={0} XH={1} Error:{2}", _taskID, _xh, ex.Message);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                }
                cn.Close();
            }
            _ret.RemotingFormat = SerializationFormat.Binary;
            return _ret;
        }



        public DataSet GetTaskQueryResult_ORA(string _taskID)
        {
            return null;
        }


        private const string SQL_SaveQuery = @"insert into QUERY_SAVE (ID,TITLE,TJSF,YHID,LX,SJ,VIEWNAME,SYDWID,ISPUBLIC)
                                                 values (:ID,:TITLE,:TJSF,:YHID,'查询模型',sysdate,:VIEWNAME,:SYDWID,:ISPUBLIC) ";
        public void SaveQuery(string SaveName, bool IsPublic, MDQuery_Request QueryRequest)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            formatter.Serialize(stream, QueryRequest);
            stream.Seek(0, SeekOrigin.Begin);
            byte[] blob = new byte[stream.Length];
            stream.Read(blob, 0, blob.Length);
            stream.Close();
            string _id = Guid.NewGuid().ToString();

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand(SQL_SaveQuery, cn);
                _cmd.Parameters.Add(":ID", _id);
                _cmd.Parameters.Add(":TITLE", SaveName);
                _cmd.Parameters.Add(new OracleParameter(":TJSF", OracleDbType.Blob, blob.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, blob));
                _cmd.Parameters.Add(":YHID", decimal.Parse(SinoUserCtx.CurUser.UserID));
                _cmd.Parameters.Add(":VIEWNAME", QueryRequest.QueryModelName);
                _cmd.Parameters.Add(":SYDWID", decimal.Parse(SinoUserCtx.CurUser.CurrentPost.PostDwID));
                _cmd.Parameters.Add(":ISPUBLIC", IsPublic ? (decimal)1 : (decimal)0);
                _cmd.ExecuteNonQuery();
                cn.Close();
            }
            return;
        }


        public DataTable GetSaveQueryList(string QueryModelName)
        {
            string _sql = " select  ID,TITLE SAVENAME,ZHTJ_ZZJG2.Get_YHXM(YHID) USERNAME,YHID,SJ SAVEDATE,ISPUBLIC from QUERY_SAVE ";
            _sql += " where (YHID=:YHID or (ISPUBLIC=1 and SYDWID=:DWID)) and  VIEWNAME=:VIEWNAME";
            OracleParameter[] _param = {
                                new OracleParameter(":YHID",OracleDbType.Decimal),
                                new OracleParameter(":DWID",OracleDbType.Decimal),
                                new OracleParameter(":VIEWNAME",OracleDbType.Varchar2)
                        };
            _param[0].Value = decimal.Parse(SinoUserCtx.CurUser.UserID);
            _param[1].Value = decimal.Parse(SinoUserCtx.CurUser.CurrentPost.PostDwID);
            _param[2].Value = QueryModelName;
            return OracleHelper.FillDataTable(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);
        }


        public MDQuery_Request LoadQuery(string SaveQueryID)
        {
            MDQuery_Request _ret = null;
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand(" select  TJSF from QUERY_SAVE where ID=:ID", cn);
                _cmd.Parameters.Add(":ID", SaveQueryID);

                using (OracleDataReader myOracleDataReader = _cmd.ExecuteReader())
                {
                    myOracleDataReader.Read();
                    OracleBlob myOracleClob = myOracleDataReader.GetOracleBlob(0);
                    IFormatter formatter = new BinaryFormatter();
                    _ret = (MDQuery_Request)formatter.Deserialize(myOracleClob);
                }
                cn.Close();
            }
            return _ret;

        }

        private const string SQL_GetInputModelByID = @"select IV_ID,NAMESPACE,IV_NAME,DESCRIPTION,DISPLAYNAME,DISPLAYORDER,IV_CS,TID,DELRULE,DWDM,INTEGRATEDAPP,RESTYPE,
                                                       beforewrite,afterwrite from MD_INPUTVIEW where IV_ID=:IVID ";
        public MD_InputModel GetInputModelByID(string InputModelID)
        {
            MD_InputModel _ret = null;

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand(SQL_GetInputModelByID, cn);
                _cmd.Parameters.Add(":IVID", decimal.Parse(InputModelID));

                using (OracleDataReader _dr = _cmd.ExecuteReader())
                {
                    while (_dr.Read())
                    {
                        _ret = new MD_InputModel(
                                _dr.IsDBNull(0) ? "" : _dr.GetDecimal(0).ToString(),
                                _dr.IsDBNull(1) ? "" : _dr.GetString(1),
                                _dr.IsDBNull(2) ? "" : _dr.GetString(2),
                                _dr.IsDBNull(3) ? "" : _dr.GetString(3),
                                _dr.IsDBNull(4) ? "" : _dr.GetString(4),
                                _dr.IsDBNull(5) ? (int)0 : Convert.ToInt32(_dr.GetDecimal(5)),
                                _dr.IsDBNull(6) ? "" : _dr.GetString(6),
                                _dr.IsDBNull(8) ? "" : _dr.GetString(8),
                                _dr.IsDBNull(9) ? "" : _dr.GetString(9),
                                _dr.IsDBNull(10) ? "" : _dr.GetString(10),
                                _dr.IsDBNull(11) ? "" : _dr.GetString(11)
                        );
                        string _tname = StrUtils.GetMetaByName2("TABLE", _ret.Param);
                        string _orderField = StrUtils.GetMetaByName2("ORDER", _ret.Param);
                        string _modelType = StrUtils.GetMetaByName2("TYPE", _ret.Param);
                        string _paramType = StrUtils.GetMetaByName2("PARAMTYPE", _ret.Param);
                        _ret.BeforeWrite = _dr.IsDBNull(12) ? "" : _dr.GetString(12);
                        _ret.AfterWrite = _dr.IsDBNull(13) ? "" : _dr.GetString(13);
                        _ret.ModelType = (_modelType == "") ? "GRID" : _modelType.ToUpper();
                        _ret.ParamterType = (_paramType == "") ? "OTHER" : _paramType.ToUpper();
                        _ret.InitGuideLine = StrUtils.GetMetaByName2("INITZB", _ret.Param);
                        _ret.GetDataGuideLine = StrUtils.GetMetaByName2("GETZB", _ret.Param);
                        _ret.GetNewRecordGuideLine = StrUtils.GetMetaByName2("NEWZB", _ret.Param);
                        _ret.OrderField = _orderField;
                        _ret.TableName = _tname;
                        _ret.WriteTableNames = GetWriteDesTableOfInputModel(_ret, cn);
                        _ret.ChildInputModel = GetChildInputModel(_ret, cn);
                    }
                    _dr.Close();
                }
                cn.Close();
            }
            if (_ret != null)
            {
                GetInputModelColumnGroups(_ret);
            }
            if (_ret != null)
            {
                _ret.Columns = GetInputModelColumnDefine(_ret.ID);
            }

            return _ret;
        }

        private const string SQL_GetInputModelByName = @"select IV_ID,NAMESPACE,IV_NAME,DESCRIPTION,DISPLAYNAME,DISPLAYORDER,IV_CS,TID,DELRULE,DWDM,INTEGRATEDAPP,RESTYPE,
                                                         beforewrite,afterwrite from MD_INPUTVIEW where NAMESPACE=:NS and IV_NAME=:IVNAME ";
        public MD_InputModel GetInputModelByName(string _modelName)
        {
            MD_InputModel _ret = null;
            string[] _mns = _modelName.Split('.');
            if (_mns.Length < 2) return null;
            string _ns = _mns[0];
            string _mame = _mns[1];

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand(SQL_GetInputModelByName, cn);
                _cmd.Parameters.Add(":NS", _ns);
                _cmd.Parameters.Add(":IVNAME", _mame);
                OracleDataReader _dr = _cmd.ExecuteReader();
                while (_dr.Read())
                {
                    _ret = new MD_InputModel(
                            _dr.IsDBNull(0) ? "" : _dr.GetDecimal(0).ToString(),
                            _ns,
                            _mame,
                            _dr.IsDBNull(3) ? "" : _dr.GetString(3),
                            _dr.IsDBNull(4) ? "" : _dr.GetString(4),
                            _dr.IsDBNull(5) ? (int)0 : Convert.ToInt32(_dr.GetDecimal(5)),
                            _dr.IsDBNull(6) ? "" : _dr.GetString(6),
                            _dr.IsDBNull(8) ? "" : _dr.GetString(8),
                            _dr.IsDBNull(9) ? "" : _dr.GetString(9),
                            _dr.IsDBNull(10) ? "" : _dr.GetString(10),
                            _dr.IsDBNull(11) ? "" : _dr.GetString(11)
                    );

                    string _tname = StrUtils.GetMetaByName2("TABLE", _ret.Param);
                    string _orderField = StrUtils.GetMetaByName2("ORDER", _ret.Param);
                    string _modelType = StrUtils.GetMetaByName2("TYPE", _ret.Param);
                    string _paramType = StrUtils.GetMetaByName2("PARAMTYPE", _ret.Param);
                    _ret.BeforeWrite = _dr.IsDBNull(12) ? "" : _dr.GetString(12);
                    _ret.AfterWrite = _dr.IsDBNull(13) ? "" : _dr.GetString(13);
                    _ret.ModelType = (_modelType == "") ? "GRID" : _modelType.ToUpper();
                    _ret.ParamterType = (_paramType == "") ? "OTHER" : _paramType.ToUpper();
                    _ret.InitGuideLine = StrUtils.GetMetaByName2("INITZB", _ret.Param);
                    _ret.GetDataGuideLine = StrUtils.GetMetaByName2("GETZB", _ret.Param);
                    _ret.GetNewRecordGuideLine = StrUtils.GetMetaByName2("NEWZB", _ret.Param);
                    _ret.OrderField = _orderField;
                    _ret.TableName = _tname;
                    _ret.WriteTableNames = GetWriteDesTableOfInputModel(_ret, cn);
                    _ret.ChildInputModel = GetChildInputModel(_ret, cn);

                }
                _dr.Close();
                cn.Close();
            }
            if (_ret != null)
            {
                GetInputModelColumnGroups(_ret);
            }
            if (_ret != null)
            {
                _ret.Columns = GetInputModelColumnDefine(_ret.ID);
            }

            return _ret;
        }

        private List<MD_InputModel_Child> GetChildInputModel(MD_InputModel _ret, OracleConnection cn)
        {
            OraMetaDataFactroy _of = new OraMetaDataFactroy();
            List<MD_InputModel_Child> _cret = _of.GetChildInputModel(_ret, cn);
            foreach (MD_InputModel_Child _child in _cret)
            {
                if (_child.ChildModel != null)
                {
                    GetInputModelColumnGroups(_child.ChildModel);
                }
                if (_child.ChildModel != null)
                {
                    _child.ChildModel.Columns = GetInputModelColumnDefine(_child.ChildModel.ID);
                }
            }
            return _cret;
        }

        private const string SQL_GetWriteDesTableOfInputModel = @"select  ID,TABLENAME,TABLETITLE,ISLOCK,DISPLAYORDER
                                                                  from MD_INPUTTABLE where IV_ID = :IVID order by DISPLAYORDER  ";
        private List<MD_InputModel_SaveTable> GetWriteDesTableOfInputModel(MD_InputModel _model, OracleConnection cn)
        {
            List<MD_InputModel_SaveTable> _ret = new List<MD_InputModel_SaveTable>();

            OracleCommand _cmd = new OracleCommand(SQL_GetWriteDesTableOfInputModel, cn);
            _cmd.Parameters.Add(":IVID", _model.ID);
            using (OracleDataReader _dr = _cmd.ExecuteReader())
            {
                while (_dr.Read())
                {
                    MD_InputModel_SaveTable _tb = new MD_InputModel_SaveTable(
                            _dr.IsDBNull(0) ? "" : _dr.GetDecimal(0).ToString(),
                            _dr.IsDBNull(1) ? "" : _dr.GetString(1),
                            _dr.IsDBNull(2) ? "" : _dr.GetString(2),
                            _dr.IsDBNull(3) ? true : (_dr.GetDecimal(3) > 0),
                            _model.ID,
                            _dr.IsDBNull(4) ? 0 : Convert.ToInt32(_dr.GetDecimal(4))
                    );
                    GetInputModelSaveTableColumn(_tb, cn);
                    _ret.Add(_tb);
                }
            }
            return _ret;
        }

        private const string SQL_GetInputModelSaveTableColumn = @"select ID,SRCCOL,DESCOL,METHOD,DESDES from MD_INPUTTABLECOLUMN where IVT_ID=:TID ";
        private void GetInputModelSaveTableColumn(MD_InputModel_SaveTable _tb, OracleConnection cn)
        {

            OracleCommand _cmd = new OracleCommand(SQL_GetInputModelSaveTableColumn, cn);
            _cmd.Parameters.Add(":TID", decimal.Parse(_tb.ID));
            using (OracleDataReader _dr = _cmd.ExecuteReader())
            {
                if (_tb.Columns == null) _tb.Columns = new List<MD_InputModel_SaveTableColumn>();

                while (_dr.Read())
                {
                    MD_InputModel_SaveTableColumn _col = new MD_InputModel_SaveTableColumn(
                            _dr.IsDBNull(0) ? "" : _dr.GetDecimal(0).ToString(),
                            _dr.IsDBNull(1) ? "" : _dr.GetString(1),
                            _dr.IsDBNull(2) ? "" : _dr.GetString(2),
                            _dr.IsDBNull(3) ? "" : _dr.GetString(3),
                            _dr.IsDBNull(4) ? "" : _dr.GetString(4)
                    );
                    _tb.Columns.Add(_col);
                }
            }
        }

        /// <summary>
        /// 取查询模型的录入字段分组
        /// </summary>
        /// <param name="_ret"></param>
        /// 
        private const string SQL_GetInputModelColumnGroups = @"select IVG_ID,DISPLAYTITLE,DISPLAYORDER,GROUPTYPE,APPREGURL,GROUPCS
                                                                   from md_inputgroup  where IV_ID=:IVID order by DISPLAYORDER asc ";
        private void GetInputModelColumnGroups(MD_InputModel _ret)
        {
            if (_ret.Groups == null) _ret.Groups = new List<MD_InputModel_ColumnGroup>();
            _ret.Groups.Clear();
            string _sql = "";
            _sql += " ";
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleParameter[] _param = {
                                        new OracleParameter(":IVID", OracleDbType.Decimal)};
                _param[0].Value = decimal.Parse(_ret.ID);
                using (OracleDataReader _dr = OracleHelper.ExecuteReader(cn, CommandType.Text, SQL_GetInputModelColumnGroups, _param))
                {

                    while (_dr.Read())
                    {
                        string _groupid = _dr.IsDBNull(0) ? "0" : _dr.GetDecimal(0).ToString();
                        string _title = _dr.IsDBNull(1) ? "" : _dr.GetString(1);
                        int _order = _dr.IsDBNull(2) ? 0 : Convert.ToInt32(_dr.GetDecimal(2));
                        MD_InputModel_ColumnGroup _group = new MD_InputModel_ColumnGroup(_groupid, _ret.ID, _title, _order);
                        _group.GroupType = _dr.IsDBNull(3) ? "DEFAULT" : _dr.GetString(3).ToUpper();
                        _group.AppRegUrl = _dr.IsDBNull(4) ? "" : _dr.GetString(4);
                        _group.GroupParam = _dr.IsDBNull(5) ? "" : _dr.GetString(5);
                        GetColumnsOfInputGroup(_group, cn);
                        _ret.Groups.Add(_group);
                    }
                    _dr.Close();
                }
                cn.Clone();
            }

        }

        private const string SQL_GetColumnsOfInputGroup = @"select IVC_ID,IV_ID,TCID,DWDM,
                                                            INPUTDEFAULT,INPUTRULE,CANEDITRULE,CANDISPLAY,
                                                            COLUMNNAME,COLUMNORDER,COLUMNTYPE,READONLY,
                                                            DISPLAYNAME,ISCOMPUTE,COLUMNWIDTH,COLUMNHEIGHT,
                                                            TEXTALIGNMENT,EDITFORMAT,DISPLAYFORMAT,REQUIRED,TOOLTIP,DATACHANGEDEVENT,MAXLENGTH,
                                                            DEFAULTSHOW
                                                            from MD_INPUTVIEWCOLUMN 
                                                            where IV_ID=:IVID and IVG_ID=:IVGID
                                                            order by COLUMNORDER";
        private void GetColumnsOfInputGroup(MD_InputModel_ColumnGroup _group, OracleConnection cn)
        {
            List<MD_InputModel_Column> _ret = new List<MD_InputModel_Column>();

            OracleCommand _cmd = new OracleCommand(SQL_GetColumnsOfInputGroup, cn);
            _cmd.Parameters.Add(":IVID", decimal.Parse(_group.ModelID));
            _cmd.Parameters.Add(":IVGID", decimal.Parse(_group.GroupID));

            OracleDataReader _dr = _cmd.ExecuteReader();
            if (_group.Columns == null) _group.Columns = new List<MD_InputModel_Column>();
            while (_dr.Read())
            {
                MD_InputModel_Column _col = new MD_InputModel_Column(
                        _dr.IsDBNull(0) ? "" : _dr.GetDecimal(0).ToString(),
                        _dr.IsDBNull(8) ? "" : _dr.GetString(8),
                        _dr.IsDBNull(12) ? "" : _dr.GetString(12),
                        _dr.IsDBNull(10) ? "" : _dr.GetString(10),
                        _dr.IsDBNull(9) ? 0 : Convert.ToInt32(_dr.GetDecimal(9)),
                        _dr.IsDBNull(1) ? "" : _dr.GetDecimal(1).ToString(),
                        _dr.IsDBNull(11) ? true : (_dr.GetDecimal(11) < 1),
                        _dr.IsDBNull(7) ? true : (_dr.GetString(7).ToUpper() == "Y"),
                        _dr.IsDBNull(13) ? false : (_dr.GetDecimal(13) > 0),
                        _dr.IsDBNull(11) ? false : (_dr.GetDecimal(11) > 0),
                        _dr.IsDBNull(3) ? "" : _dr.GetString(3),
                        _dr.IsDBNull(4) ? "" : _dr.GetString(4),
                        _dr.IsDBNull(5) ? "" : _dr.GetString(5),
                        _dr.IsDBNull(6) ? "" : _dr.GetString(6),
                        _dr.IsDBNull(14) ? 1 : Convert.ToInt32(_dr.GetDecimal(14)),
                        _dr.IsDBNull(15) ? 1 : Convert.ToInt32(_dr.GetDecimal(15)),
                        _dr.IsDBNull(16) ? 0 : Convert.ToInt32(_dr.GetDecimal(16)),
                        _dr.IsDBNull(17) ? "" : _dr.GetString(17),
                        _dr.IsDBNull(18) ? "" : _dr.GetString(18),
                        _dr.IsDBNull(19) ? false : (_dr.GetDecimal(19) > 0),
                        _dr.IsDBNull(20) ? "" : _dr.GetString(20),
                         _dr.IsDBNull(22) ? 0 : Convert.ToInt32(_dr.GetDecimal(22)),
                        _dr.IsDBNull(21) ? "" : _dr.GetString(21)

                );
                _col.DefaultShow = _dr.IsDBNull(23) ? false : (_dr.GetDecimal(23) > 0);
                _group.Columns.Add(_col);
            }
            _dr.Close();
        }

        private const string SQL_GetInputModelColumnDefine = @"select IVC_ID,IV_ID,TCID,DWDM,
                                        INPUTDEFAULT,INPUTRULE,CANEDITRULE,CANDISPLAY,
                                        COLUMNNAME,COLUMNORDER,COLUMNTYPE,READONLY,
                                        DISPLAYNAME,ISCOMPUTE,COLUMNWIDTH,COLUMNHEIGHT,
                                        TEXTALIGNMENT,EDITFORMAT,DISPLAYFORMAT,REQUIRED,TOOLTIP,DATACHANGEDEVENT,MAXLENGTH,
                                        defaultshow from MD_INPUTVIEWCOLUMN 
                                         where IV_ID=:IVID and IVG_ID=0
                                        order by COLUMNORDER";
        private List<MD_InputModel_Column> GetInputModelColumnDefine(string _inputModelID)
        {
            List<MD_InputModel_Column> _ret = new List<MD_InputModel_Column>();

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand(SQL_GetInputModelColumnDefine, cn);
                _cmd.Parameters.Add(":IVID", decimal.Parse(_inputModelID));

                OracleDataReader _dr = _cmd.ExecuteReader();
                while (_dr.Read())
                {
                    MD_InputModel_Column _col = new MD_InputModel_Column(
                            _dr.IsDBNull(0) ? "" : _dr.GetDecimal(0).ToString(),
                            _dr.IsDBNull(8) ? "" : _dr.GetString(8),
                            _dr.IsDBNull(12) ? "" : _dr.GetString(12),
                            _dr.IsDBNull(10) ? "" : _dr.GetString(10),
                            _dr.IsDBNull(9) ? 0 : Convert.ToInt32(_dr.GetDecimal(9)),
                            _dr.IsDBNull(1) ? "" : _dr.GetDecimal(1).ToString(),
                            _dr.IsDBNull(11) ? true : (_dr.GetDecimal(11) < 1),
                            _dr.IsDBNull(7) ? true : (_dr.GetString(7).ToUpper() == "Y"),
                            _dr.IsDBNull(13) ? false : (_dr.GetDecimal(13) > 0),
                            _dr.IsDBNull(11) ? false : (_dr.GetDecimal(11) > 0),
                            _dr.IsDBNull(3) ? "" : _dr.GetString(3),
                            _dr.IsDBNull(4) ? "" : _dr.GetString(4),
                            _dr.IsDBNull(5) ? "" : _dr.GetString(5),
                            _dr.IsDBNull(6) ? "" : _dr.GetString(6),
                            _dr.IsDBNull(14) ? 1 : Convert.ToInt32(_dr.GetDecimal(14)),
                            _dr.IsDBNull(15) ? 1 : Convert.ToInt32(_dr.GetDecimal(15)),
                            _dr.IsDBNull(16) ? 0 : Convert.ToInt32(_dr.GetDecimal(16)),
                            _dr.IsDBNull(17) ? "" : _dr.GetString(17),
                            _dr.IsDBNull(18) ? "" : _dr.GetString(18),
                            _dr.IsDBNull(19) ? false : (_dr.GetDecimal(19) > 0),
                            _dr.IsDBNull(20) ? "" : _dr.GetString(20),
                             _dr.IsDBNull(22) ? 0 : Convert.ToInt32(_dr.GetDecimal(22)),
                            _dr.IsDBNull(21) ? "" : _dr.GetString(21)

                    );
                    _col.DefaultShow = _dr.IsDBNull(23) ? false : (_dr.GetDecimal(23) > 0);
                    _ret.Add(_col);
                }
                _dr.Close();
                cn.Close();
            }

            return _ret;
        }



        public bool DelSavedQuery(string _savedID)
        {
            string _sql = "delete from QUERY_SAVE where id=:ID and yhid=:YHID ";
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(_sql, cn);
                    _cmd.Parameters.Add(":ID", _savedID);
                    _cmd.Parameters.Add(":YHID", decimal.Parse(SinoUserCtx.CurUser.UserID));
                    _cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("删除保存的查询时出错,错误信息为:{0}!\nID:{1}",
                           e.Message, _savedID);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    return false;
                }
            }
        }


        public string GetUserLevel()
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand("select zhcx_hgjs.get_dwjb(:DWID) from dual ", cn);
                    _cmd.Parameters.Add(":nDWID", decimal.Parse(SinoUserCtx.CurUser.CurrentPost.PostDwID));
                    object _retObj = _cmd.ExecuteScalar();
                    if (_retObj == null) return "缉私分局";
                    string _ret = _retObj.ToString();
                    if (_ret == "") return "缉私分局";
                    return _ret;
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("取用户级别信息时出错,错误信息为:{0}!\nUserName:{1}",
                           e.Message, SinoUserCtx.CurUser.LoginName);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    return "缉私分局";
                }
                cn.Close();
            }
        }

        public DataTable GetDataCheckInfo(string _modelName, string _mainKey, ref string _shid)
        {
            _shid = "";
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    string[] _names = _modelName.Split('.');
                    //取审核ID
                    OracleCommand _cmd = new OracleCommand("SELECT SH.ID FROM SJSH_B SH WHERE SH.NAMESPACE=:NAMESPACE AND SH.VIEWNAME=:VIEWNAME AND SH.SHDXGJZ=:SHDXGJZ", cn);
                    _cmd.Parameters.Add(":NAMESPACE", _names[0]);
                    _cmd.Parameters.Add(":VIEWNAME", _names[1]);
                    _cmd.Parameters.Add(":SHDXGJZ", _mainKey);
                    object _retObj = _cmd.ExecuteScalar();
                    if (_retObj == null)
                    {
                        //没有审核ID的插入一个审核ID
                        //取新序号
                        OraMetaDataFactroy _factroy = new OraMetaDataFactroy();
                        _shid = _factroy.GetNewID();
                        //插入
                        _cmd = new OracleCommand("insert into SJSH_B (ID,NAMESPACE,VIEWNAME,SHDXGJZ) values (:ID,:NS,:VN,:MAINKEY)", cn);
                        _cmd.Parameters.Add(":ID", decimal.Parse(_shid));
                        _cmd.Parameters.Add(":NS", _names[0]);
                        _cmd.Parameters.Add(":VN", _names[1]);
                        _cmd.Parameters.Add(":MAINKEY", _mainKey);
                        _cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        _shid = _retObj.ToString();
                    }
                    //取审核信息
                    string _sqlStr = "SELECT * FROM SJSH_JGJLB WHERE ID =:ID";
                    DataTable _ret = new DataTable();
                    OracleDataAdapter _adapter = new OracleDataAdapter();
                    //Set the select command to fetch product details
                    _adapter.SelectCommand = new OracleCommand(_sqlStr, cn);
                    _adapter.SelectCommand.Parameters.Add(":ID", decimal.Parse(_shid));
                    //AddWithKey sets the Primary Key information to complete the 
                    //schema information
                    _adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                    _adapter.Fill(_ret);



                    return _ret;
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("取用户审核信息时出错,错误信息为:{0}!\nModelName:{1}\nMainKey={2}",
                           e.Message, _modelName, _mainKey);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    return null;
                }
                cn.Close();
            }
        }



        public string GetDataCheckInfoJLID(string QueryModelName, string _mainKey, string _level, ref string SHID)
        {
            SHID = "";
            string _ret = "";
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    string[] _names = QueryModelName.Split('.');
                    //取审核ID
                    OracleCommand _cmd = new OracleCommand("SELECT SH.ID FROM SJSH_B SH WHERE SH.NAMESPACE=:NAMESPACE AND SH.VIEWNAME=:VIEWNAME AND SH.SHDXGJZ=:SHDXGJZ", cn);
                    _cmd.Parameters.Add(":NAMESPACE", _names[0]);
                    _cmd.Parameters.Add(":VIEWNAME", _names[1]);
                    _cmd.Parameters.Add(":SHDXGJZ", _mainKey);
                    object _retObj = _cmd.ExecuteScalar();
                    if (_retObj == null)
                    {
                        //没有审核ID的插入一个审核ID
                        //取新序号
                        OraMetaDataFactroy _factroy = new OraMetaDataFactroy();
                        SHID = _factroy.GetNewID();
                        //插入
                        _cmd = new OracleCommand("insert into SJSH_B (ID,NAMESPACE,VIEWNAME,SHDXGJZ) values (:ID,:NS,:VN,:MAINKEY)", cn);
                        _cmd.Parameters.Add(":ID", decimal.Parse(SHID));
                        _cmd.Parameters.Add(":NS", _names[0]);
                        _cmd.Parameters.Add(":VN", _names[1]);
                        _cmd.Parameters.Add(":MAINKEY", _mainKey);
                        _cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        SHID = _retObj.ToString();
                    }
                    //取审核信息
                    string _sqlStr = "SELECT SHJLID FROM SJSH_JGJLB WHERE ID =:ID AND DWJBFL=:JBFL";
                    OracleCommand _cmd2 = new OracleCommand(_sqlStr, cn);
                    _cmd2.Parameters.Add(":ID", decimal.Parse(SHID));
                    _cmd2.Parameters.Add(":JBFL", _level);

                    object _jlidObj = _cmd2.ExecuteScalar();
                    if (_jlidObj == null)
                    {
                        _ret = "";
                    }
                    else
                    {
                        _ret = _jlidObj.ToString();
                    }

                    return _ret;
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("取用户审核信息记录ID时出错,错误信息为:{0}!\nModelName:{1}\nMainKey={2}\n Level={3}",
                           e.Message, QueryModelName, _mainKey, _level);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    return null;
                }
                cn.Close();
            }
        }
        private const string SQL_SaveDataCheckResult_Upd_SJSHB_ZONGSJ = "Update SJSH_B Set SH_ZONGSJ =:VALUE Where ID = :ID";
        private const string SQL_SaveDataCheckResult_Upd_SJSHB_ZHISJ = "Update SJSH_B Set SH_ZHISJ =:VALUE Where ID = :ID";
        private const string SQL_SaveDataCheckResult_Upd_SJSHB_FJ = "Update SJSH_B Set SH_FJ =:VALUE Where ID = :ID";
        private const string SQL_SaveDataCheckResult_Ins_JGJLB = "insert into SJSH_JGJLB (SHJLID,ID,DWDM,DWJBFL,RYXM,SHRQ,SHYJ,SHJG,WHXH) values (:SHJLID,:ID,:DWDM,:DWJBFL,:RYXM,sysdate,:SHYJ,:SHJG,:WHXH)";
        private const string SQL_SaveDataCheckResult_Upd_JGJLB = "Update SJSH_JGJLB SET DWDM = :DWDM,RYXM = :RYXM,SHRQ = sysdate,SHYJ = :SHYJ,SHJG =:SHJG,WHXH = :WHXH WHERE SHJLID=:SHJLID";
        private const string SQL_SaveDataCheckResult_Upd_RZJLB = @"insert into sjsh_rzjlb (rzid, id, shjlid, shrq, viewname, namespace,
                    shdxgjz, sh_fj, sh_zhisj, sh_fsj, sh_zongsj, shyj, dwjbfl, ryxm, whxh) 
                    select SEQUENCES_META.NEXTVAL,B.ID,A.SHJLID,A.SHRQ,
                    B.VIEWNAME,B.NAMESPACE,B.SHDXGJZ,
                    B.SH_FJ,B.SH_ZHISJ,B.SH_FSJ,B.SH_ZONGSJ,
                    A.SHYJ,:USERLEVEL,A.RYXM,A.WHXH FROM sjsh_jgjlb A,sjsh_b B 
                    where a.shjlid =:SHJLID and b.id = a.id";
        public string SaveDataCheckResult(string CurrentJLID, string CurrentLevel, string CurrentID, string _shjg, string _shr, string _xgyj, string _WHXH)
        {
            string _updateB = "";
            string _fieldName = "";
            string _ret = CurrentJLID;
            switch (CurrentLevel)
            {
                case "总署缉私局":
                case "广东分署缉私局":
                    _fieldName = "SH_ZONGSJ";
                    _updateB = SQL_SaveDataCheckResult_Upd_SJSHB_ZONGSJ;
                    break;
                case "直属缉私局":
                    _fieldName = "SH_ZHISJ";
                    _updateB = SQL_SaveDataCheckResult_Upd_SJSHB_ZHISJ;
                    break;
                case "缉私分局":
                    _fieldName = "SH_FJ";
                    _updateB = SQL_SaveDataCheckResult_Upd_SJSHB_FJ;
                    break;
            }



            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                try
                {

                    //更新审核表
                    OracleCommand _cmd = new OracleCommand(_updateB, cn);
                    _cmd.Parameters.Add(":VALUE", (_shjg == "通过") ? "1" : "2");
                    _cmd.Parameters.Add(":ID", decimal.Parse(CurrentID));
                    _cmd.ExecuteNonQuery();

                    if (CurrentJLID == "")
                    {
                        OraMetaDataFactroy _factroy = new OraMetaDataFactroy();
                        CurrentJLID = _factroy.GetNewID();
                        _ret = CurrentJLID;
                        _cmd = new OracleCommand(SQL_SaveDataCheckResult_Ins_JGJLB, cn);
                        _cmd.Parameters.Add(":SHJLID", decimal.Parse(CurrentJLID));
                        _cmd.Parameters.Add(":ID", decimal.Parse(CurrentID));
                        _cmd.Parameters.Add(":DWDM", SinoUserCtx.CurUser.CurrentPost.PostDWDM);
                        _cmd.Parameters.Add(":DWJBFL", CurrentLevel);
                        _cmd.Parameters.Add(":RYXM", _shr);
                        _cmd.Parameters.Add(":SHYJ", _xgyj);
                        _cmd.Parameters.Add(":SHJG", _shjg);
                        _cmd.Parameters.Add(":WHXH", decimal.Parse(_WHXH));
                        _cmd.ExecuteNonQuery();

                    }
                    else
                    {
                        _cmd = new OracleCommand(SQL_SaveDataCheckResult_Upd_JGJLB, cn);
                        _cmd.Parameters.Add(":DWDM", SinoUserCtx.CurUser.CurrentPost.PostDWDM);
                        _cmd.Parameters.Add(":RYXM", _shr);
                        _cmd.Parameters.Add(":SHYJ", _xgyj);
                        _cmd.Parameters.Add(":SHJG", _shjg);
                        _cmd.Parameters.Add(":WHXH", decimal.Parse(_WHXH));
                        _cmd.Parameters.Add(":SHJLID", decimal.Parse(CurrentJLID));
                        _cmd.ExecuteNonQuery();
                    }


                    //写审核日志表
                    _cmd = new OracleCommand(SQL_SaveDataCheckResult_Upd_RZJLB, cn);
                    _cmd.Parameters.Add(":USERLEVEL", CurrentLevel);
                    _cmd.Parameters.Add(":SHJLID", CurrentJLID);
                    _cmd.ExecuteNonQuery();


                    _txn.Commit();
                    cn.Close();
                    return _ret;
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("保存用户审核信息时出错,错误信息为:{0}!\n CurrentLevel:{1}\n CurrentID={2}",
                           e.Message, CurrentLevel, CurrentID);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    _txn.Rollback();
                    cn.Close();
                    return "-1";
                }

            }
        }




        public string GetDataCheckWHXH(string _tableName, string _mainColumn, string _mainKey)
        {
            string _selectwhxh = string.Format("SELECT WHXHB.WHXH FROM {0}_WHXH WHXHB WHERE WHXHB.{1} = :MAINID  ", _tableName, _mainColumn);
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleParameter[] _param = { new OracleParameter(":MAINID", _mainKey) };
                    object _retObj = OracleHelper.ExecuteScalar(cn, CommandType.Text, _selectwhxh, _param);
                    return _retObj.ToString();
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("取表数据的维护序号时出错,错误信息为:{0}!\n _tableName:{1}\n _mainColumn={2} _mainKey={3}",
                           e.Message, _tableName, _mainColumn, _mainKey);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    return "-1";
                }
                cn.Close();
            }


        }

        private const string SQL_SaveNewDataCheckRule = @"insert into SJSH_SHGZB (id,viewname,namespace,gzmc,gzsf,dwdm,state)
                                                            values (:ID,:VIEWNAME,:NAMESPACE,:GZMC,:GZSF,:DWDM,1)";
        public bool SaveNewDataCheckRule(string _ruleName, string _queryModelName, string _gzsf)
        {
            OraMetaDataFactroy _factroy = new OraMetaDataFactroy();
            string _newid = _factroy.GetNewID();
            string _checkStr = "";

            string[] qvs = _queryModelName.Split('.');
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_SaveNewDataCheckRule, cn);
                    _cmd.Parameters.Add(":ID", decimal.Parse(_newid));
                    _cmd.Parameters.Add(":VIEWNAME", qvs[1]);
                    _cmd.Parameters.Add(":NAMESPACE", qvs[0]);
                    _cmd.Parameters.Add(":GZMC", _ruleName);
                    _cmd.Parameters.Add(":GZSF", _gzsf);
                    _cmd.Parameters.Add(":DWDM", SinoUserCtx.CurUser.CurrentPost.PostDWDM);
                    _cmd.ExecuteNonQuery();
                    _txn.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("保存新的审核规则时出错,错误信息为:{0}!\n _ruleName:{1}\n _queryModelName={2}",
                           e.Message, _ruleName, _queryModelName);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    _txn.Rollback();
                    return false;
                }
                cn.Close();
            }
        }


        private const string SQL_DelDataCheckRule = "delete from SJSH_SHGZB where ID=:ID and DWDM=:DWDM";
        public bool DelDataCheckRule(string _ruleID)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_DelDataCheckRule, cn);
                    _cmd.Parameters.Add(":ID", decimal.Parse(_ruleID));
                    _cmd.Parameters.Add(":DWMD", SinoUserCtx.CurUser.CurrentPost.PostDWDM);
                    _cmd.ExecuteNonQuery();
                    _txn.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("删除审核规则时出错,错误信息为:{0}!\n _ruleID:{1}\n DWDM={2}",
                          e.Message, _ruleID, SinoUserCtx.CurUser.CurrentPost.PostDWDM);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    _txn.Rollback();
                    return false;
                }
                cn.Close();
            }
        }


        public bool ChangeDataCheckRule(string _ruleID, string _gzsf)
        {
            string _del = "update SJSH_SHGZB set GZSF=:GZSF where ID=:ID and DWDM=:DWDM";
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                try
                {
                    OracleCommand _cmd = new OracleCommand(_del, cn);
                    _cmd.Parameters.Add(":GZSF", _gzsf);
                    _cmd.Parameters.Add(":ID", decimal.Parse(_ruleID));
                    _cmd.Parameters.Add(":DWMD", SinoUserCtx.CurUser.CurrentPost.PostDWDM);
                    _cmd.ExecuteNonQuery();
                    _txn.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("修改审核规则算法时出错,错误信息为:{0}!\n _ruleID:{1}\n DWDM={2}",
                          e.Message, _ruleID, SinoUserCtx.CurUser.CurrentPost.PostDWDM);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    _txn.Rollback();
                    return false;
                }
                cn.Close();
            }
        }



        public bool IsPASpaceExist(string PersonAnalizeSapceName)
        {
            string _sql = "select count(AS_ID) from MD_ANALIZESPACE where DISPLAYTITLE=:DISPLAYTITLE and YHID=:YHID";
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(_sql, cn);
                    _cmd.Parameters.Add(":DISPLAYTITLE", PersonAnalizeSapceName);
                    _cmd.Parameters.Add(":YHID", decimal.Parse(SinoUserCtx.CurUser.UserID));
                    decimal _ret = (decimal)_cmd.ExecuteScalar();
                    return _ret > 0;
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("判断是否存在名称为{1}的分析空间时出错,错误信息为:{0}!",
                          e.Message, PersonAnalizeSapceName);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    return false;
                }
                cn.Close();
            }
        }

        private const string SQL_CreateNewPASpace = @"insert into  MD_ANALIZESPACE (AS_ID,DISPLAYTITLE,YHID,CREATE_YH,CREATE_DATE,AS_LX,CREATE_DWID) values
                                                       (:AS_ID,:DISPLAYTITLE,:YHID,:CREATE_YH,sysdate,0,:CREATE_DWID) ";
        public MD_PAnalizeProject CreateNewPASpace(string PersonAnalizeSapceName)
        {
            OraMetaDataFactroy _of = new OraMetaDataFactroy();
            string _newid = _of.GetNewID();


            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_CreateNewPASpace, cn);
                    _cmd.Parameters.Add(":AS_ID", decimal.Parse(_newid));
                    _cmd.Parameters.Add(":DISPLAYTITLE", PersonAnalizeSapceName);
                    _cmd.Parameters.Add(":YHID", decimal.Parse(SinoUserCtx.CurUser.UserID));
                    _cmd.Parameters.Add(":CREATE_YH", SinoUserCtx.CurUser.UserName);
                    _cmd.Parameters.Add(":CREATE_DWID", decimal.Parse(SinoUserCtx.CurUser.CurrentPost.PostDwID));
                    _cmd.ExecuteNonQuery();
                    return new MD_PAnalizeProject(_newid, PersonAnalizeSapceName, "", "0", SinoUserCtx.CurUser.UserID, SinoUserCtx.CurUser.UserName, DateTime.Now, 0);
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("创建名称为{1}的分析空间时出错,错误信息为:{0}!",
                          e.Message, PersonAnalizeSapceName);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    return null;
                }
                cn.Close();
            }
        }



        private const string SQL_GetPAProjectOfUser = @"select AS_ID,DISPLAYTITLE,DESCRIPTION,AS_LX,YHID,CREATE_YH,CREATE_DATE,DISPLAYORDER
                                                           from MD_ANALIZESPACE where YHID=:YHID ";
        public List<MD_PAnalizeProject> GetPAProjectOfUser()
        {
            List<MD_PAnalizeProject> _ret = new List<MD_PAnalizeProject>();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_GetPAProjectOfUser, cn);
                    _cmd.Parameters.Add(":YHID", decimal.Parse(SinoUserCtx.CurUser.UserID));
                    using (OracleDataReader _dr = _cmd.ExecuteReader())
                    {
                        while (_dr.Read())
                        {
                            MD_PAnalizeProject _p = new MD_PAnalizeProject(
                                    _dr.IsDBNull(0) ? "" : _dr.GetDecimal(0).ToString(),
                                    _dr.IsDBNull(1) ? "" : _dr.GetString(1),
                                    _dr.IsDBNull(2) ? "" : _dr.GetString(2),
                                    _dr.IsDBNull(3) ? "0" : _dr.GetDecimal(3).ToString(),
                                    _dr.IsDBNull(4) ? "" : _dr.GetDecimal(4).ToString(),
                                    _dr.IsDBNull(5) ? "" : _dr.GetString(5),
                                    _dr.IsDBNull(6) ? DateTime.Now : _dr.GetDateTime(6),
                                    _dr.IsDBNull(7) ? 0 : Convert.ToInt32(_dr.GetDecimal(7))
                            );
                            _ret.Add(_p);
                        }
                    }
                    return _ret;
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("取用户{1}的个人分析空间时出错,错误信息为:{0}!",
                          e.Message, SinoUserCtx.CurUser.UserName);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    return null;
                }
                cn.Close();
            }
        }

        private const string SQL_insCol = @"insert into MD_ANALIZETABLECOLUMN
                                                    (TCID,TID,COLUMNNAME,ISNULLABLE,TYPE,LENGTH,REFDMB,
                                                    DISPLAYTITLE,DISPLAYFORMAT,
                                                    DISPLAYORDER,CANDISPLAY) VALUES 
                                                    (:TCID,:TID,:COLUMNNAME,:ISNULLABLE,:TYPE,:LENGTH,:REFDMB,
                                                    :DISPLAYTITLE,:DISPLAYFORMAT,
                                                    :DISPLAYORDER,1) ";
        private const string SQL_Insert = @"insert into MD_ANALIZETABLE
                                                        (TID,AS_ID,TABLENAME,DISPLAYNAME,DESCRIPTION,
                                                        MAINKEY,TYPE,CREATEUSER,CREATEDATE)
                                                        values
                                                         (:TID,:AS_ID,:TABLENAME,:DISPLAYNAME,:DESCRIPTION,
                                                        'MAINID','基础数据',:CREATEUSER,sysdate)";
        public bool SaveDataToPAnalize(MD_PAnalizeProject _PAProject, string _tableName, List<MD_PATable_Column> columnDefine, DataTable _dt)
        {
            /*
            OraMetaDataFactroy _of = new OraMetaDataFactroy();
            string tid = _of.GetNewID();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                #region 建立表元数据
                try
                {

                    OracleCommand _cmd = new OracleCommand(SQL_Insert, cn);
                    _cmd.Parameters.Add(":TID", decimal.Parse(tid));
                    _cmd.Parameters.Add(":AS_ID", decimal.Parse(_PAProject.ID));
                    _cmd.Parameters.Add(":TABLENAME", string.Format("T{0}", tid));
                    _cmd.Parameters.Add(":DISPLAYNAME", _tableName);
                    _cmd.Parameters.Add(":DESCRIPTION", _tableName);
                    _cmd.Parameters.Add(":CREATEUSER", SinoUserCtx.CurUser.UserName);
                    _cmd.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("结果存入个人分析空间出错：写入个分析空间表元数据定义时出错！,错误信息为:{0}!", e.Message);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    _txn.Rollback();
                    return false;
                }
                #endregion


                #region 建立各个字段元数据定义

                foreach (MD_PATable_Column _col in columnDefine)
                {
                    try
                    {
                        string _tcid = _of.GetNewID();
                        OracleCommand _cmd = new OracleCommand(SQL_insCol, cn);
                        _cmd.Parameters.Add(":TCID", decimal.Parse(_tcid));
                        _cmd.Parameters.Add(":TID", decimal.Parse(tid));
                        _cmd.Parameters.Add(":COLUMNNAME", _col.ColumnName);
                        _cmd.Parameters.Add(":ISNULLABLE", (_col.ColumnName == "PAMAINID") ? (decimal)0 : (decimal)1);
                        _cmd.Parameters.Add(":TYPE", _col.ColumnType);
                        _cmd.Parameters.Add(":LENGTH", Convert.ToDecimal(_col.ColumnLength));
                        _cmd.Parameters.Add(":REFDMB", _col.RefDMB);
                        _cmd.Parameters.Add(":DISPLAYTITLE", _col.DisplayTitle);
                        _cmd.Parameters.Add(":DISPLAYFORMAT", _col.DisplayFormat);
                        _cmd.Parameters.Add(":DISPLAYORDER", Convert.ToDecimal(_col.DisplayOrder) + 1);
                        _cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        string _errmsg = string.Format("结果存入个人分析空间出错：写入个分析空间表字段{1}元数据定义时出错！,错误信息为:{0}!",
                                e.Message, _col.ColumnName);
                        OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                        _txn.Rollback();
                        return false;
                    }
                }
                #endregion

                #region 生成表
                try
                {
                    OracleCommand Cmd = new OracleCommand("PANALIZE.panl.createtb", cn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.Add("nTid", decimal.Parse(tid));
                    Cmd.Parameters.Add("nRet", OracleDbType.Decimal, DBNull.Value, ParameterDirection.Output);
                    Cmd.ExecuteScalar();
                    OracleDecimal _ret = (OracleDecimal)Cmd.Parameters[1].Value;
                    if (_ret.ToInt32() > 0)
                    {
                        string _errmsg = string.Format("结果存入个人分析空间出错：通过元数据建立分析空间表{0}时出错！,错误信息为:存贮过程返回为 1--失败 !",
                            tid);
                        OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                        _txn.Rollback();
                        return false;
                    }
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("结果存入个人分析空间出错：通过元数据建立分析空间表{1}时出错！,错误信息为:{0}!",
                                  e.Message, tid);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    _txn.Rollback();
                    return false;
                }
                #endregion

                #region 插入数据
                try
                {
                    string _fieldStr = "";
                    string _valueStr = "";
                    string _fg = "";
                    foreach (MD_PATable_Column _col in columnDefine)
                    {
                        _fieldStr += string.Format("{0}{1}", _fg, _col.ColumnName);
                        _valueStr += string.Format("{0}:{1}", _fg, _col.ColumnName);
                        _fg = ",";
                    }
                    string _insertData = string.Format("insert into PANALIZE.T{0} ({1}) values ({2})", tid, _fieldStr, _valueStr);

                    foreach (DataRow _dr in _dt.Rows)
                    {
                        OracleCommand _cmd = new OracleCommand(_insertData, cn);
                        foreach (MD_PATable_Column _col in columnDefine)
                        {
                            string _pname = string.Format(":{0}", _col.ColumnName);
                            _cmd.Parameters.Add(_pname, _dr[_col.ColumnName]);
                        }
                        _cmd.ExecuteNonQuery();
                    }

                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("结果存入个人分析空间出错：将记录数据插入个人分析空间的表时出错！,错误信息为:{0}! ",
                                  e.Message);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    _txn.Rollback();
                    return false;
                }
                #endregion

                #region 改代码表数据
                try
                {
                    OracleCommand Cmd = new OracleCommand("PANALIZE.panl.TranMC_to_DM", cn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.Add("nTid", decimal.Parse(tid));
                    Cmd.Parameters.Add("nRet", OracleDbType.Decimal, DBNull.Value, ParameterDirection.Output);
                    Cmd.ExecuteScalar();
                    OracleDecimal _ret = (OracleDecimal)Cmd.Parameters[1].Value;
                    if (_ret.ToInt32() > 0)
                    {
                        string _errmsg = string.Format("结果存入个人分析空间出错：通过TranMC_to_DM修改表{0}中的代码项时出错！,错误信息为:存贮过程返回为 1--失败 !",
                            tid);
                        OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                        _txn.Rollback();
                        return false;
                    }
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("结果存入个人分析空间出错：通过TranMC_to_DM修改表{0}中的代码项时出错！,错误信息为:存贮过程返回为 1--失败 !",
                                  tid);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    _txn.Rollback();
                    return false;
                }
                #endregion

                _txn.Commit();
                cn.Close();
            }
            */

            return true;
        }



        public DataTable GetInputModelBlankData(string _initGuideLineID, string _getBlankGuideLineID, List<MDQuery_GuideLineParameter> _params)
        {

            try
            {
                //取要补录的记录数据
                DataTable _ret = QueryGuideLine(_getBlankGuideLineID, _params);
                //如果不为空,则返回,为空则初始化
                if (_ret != null && _ret.Rows.Count > 0)
                {
                    return _ret;
                }

                ExcuteQueryGuideLine(_initGuideLineID, _params);
                //再次取空记录数据
                _ret = QueryGuideLine(_getBlankGuideLineID, _params);
                return _ret;
            }
            catch (Exception e)
            {
                string _errmsg = string.Format("取数据补录的表格数据时出错,错误信息为:{0}!",
                      e.Message, SinoUserCtx.CurUser.UserName);
                OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                return null;
            }

        }



        public bool SaveDataByInputModel(string _inputModelName, DataTable _changedData)
        {
            MD_InputModel _inputModel = GetInputModelByName(_inputModelName);
            if (_inputModel == null || _inputModel.TableName == "") return false;

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                string cmdStr = string.Format("select * from {0} ", _inputModel.TableName);
                OracleTransaction txn = cn.BeginTransaction();
                OracleDataAdapter adapter = new OracleDataAdapter(cmdStr, cn);
                OracleCommandBuilder builder = new OracleCommandBuilder(adapter);
                adapter.Update(_changedData);
                txn.Commit();
                cn.Close();
            }
            return true;
        }


        public void TestComputeExpress(string ExpressionString, MDModel_Table TableDefine, ref string QueryString, ref string resultDataType)
        {
            string _sql;
            resultDataType = "VARCHAR";
            QueryString = OraQueryBuilder.BuildComupteField(ExpressionString, TableDefine);
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    _sql = string.Format("select {0} from {1} where rownum<2", QueryString, TableDefine.TableName);
                    OracleTransaction txn = cn.BeginTransaction();
                    using (OracleDataReader _dr = OracleHelper.ExecuteReader(cn, CommandType.Text, _sql))
                    {
                        DataTable _dt = _dr.GetSchemaTable();
                        DataRow _row = _dt.Rows[0];
                        Type _rtype = _row["DATATYPE"] as Type;
                        if (_rtype == typeof(DateTime))
                        {
                            resultDataType = "DATE";
                        }
                        else if (_rtype == typeof(decimal))
                        {
                            resultDataType = "NUMBER";
                        }
                        else
                        {
                            resultDataType = "VARCHAR2";
                        }
                    }

                    txn.Rollback();
                    cn.Close();
                }
                catch (Exception e)
                {
                    cn.Close();
                    throw e;
                }
            }

        }


        public void TestStatisticsExpress(string TableName, MDModel_Table_Column _column, MD_FUNCTION FunctionDefine, ref string queryString, ref string resultDataType)
        {
            string _sql;
            queryString = OraQueryBuilder.BuildStatisticsField(TableName, _column, FunctionDefine);
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    _sql = string.Format("{0} where rownum<2", queryString);
                    OracleTransaction txn = cn.BeginTransaction();
                    using (OracleDataReader _dr = OracleHelper.ExecuteReader(cn, CommandType.Text, _sql))
                    {
                        DataTable _dt = _dr.GetSchemaTable();
                        DataRow _row = _dt.Rows[0];
                        Type _rtype = _row["DATATYPE"] as Type;
                        if (_rtype == typeof(DateTime))
                        {
                            resultDataType = "DATE";
                        }
                        else if (_rtype == typeof(decimal))
                        {
                            resultDataType = "NUMBER";
                        }
                        else
                        {
                            resultDataType = "VARCHAR2";
                        }

                    }
                    txn.Rollback();
                    cn.Close();
                }
                catch (Exception e)
                {
                    cn.Close();
                    throw e;
                }
            }
        }


        private const string SQL_SaveComputeFieldDefine = @"insert into MD_COMPUTECOLUMN (ID,COLUMNAME,COLUMNEXP,TABLENAME,VIEWNAME,COLUMNMETA,COLUMNDES,ISPUBLIC,USERID,CREATEDATE) 
                                                values (:ID,:COLUMNAME,:COLUMNEXP,:TABLENAME,:VIEWNAME,:COLUMNMETA,:COLUMNDES,0,:USERID,sysdate) ";
        public void SaveComputeFieldDefine(string DisplayName, string Description, string Expression, string QueryString, string ResultDataType, string TableName, string ModelName)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_SaveComputeFieldDefine, cn);
                    _cmd.Parameters.Add(":ID", Guid.NewGuid().ToString());
                    _cmd.Parameters.Add(":COLUMNAME", DisplayName);
                    _cmd.Parameters.Add(":COLUMNEXP", QueryString);
                    _cmd.Parameters.Add(":TABLENAME", TableName);
                    _cmd.Parameters.Add(":VIEWNAME", ModelName);
                    _cmd.Parameters.Add(":COLUMNMETA", string.Format("<Expression>{0}</Expression><ResultDataType>{1}</ResultDataType>",
                                                                    QueryString, ResultDataType));
                    _cmd.Parameters.Add(":COLUMNDES", Description);
                    _cmd.Parameters.Add(":USERID", SinoUserCtx.CurUser.UserID);
                    _cmd.ExecuteNonQuery();
                    cn.Close();
                }
                catch (Exception e)
                {
                    cn.Close();
                    throw e;
                }
            }
        }

        private const string SQL_GetPersonSavedComputField = @"select ID,COLUMNAME,COLUMNEXP,COLUMNDES,ISPUBLIC,VIEWNAME,TABLENAME,COLUMNMETA,USERID,CREATEDATE
                                                                 from  MD_COMPUTECOLUMN where VIEWNAME= :VIEWNAME and TABLENAME=:TABLENAME and
                                                                USERID=:USERID and ISPUBLIC =0";
        public List<MDQuery_ComputeColumnDefine> GetPersonSavedComputField(string ModelName, string TableName)
        {
            List<MDQuery_ComputeColumnDefine> _ret = new List<MDQuery_ComputeColumnDefine>();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_GetPersonSavedComputField, cn);
                    _cmd.Parameters.Add(":VIEWNAME", ModelName);
                    _cmd.Parameters.Add(":TABLENAME", TableName);
                    _cmd.Parameters.Add(":USERID", decimal.Parse(SinoUserCtx.CurUser.UserID));
                    using (OracleDataReader _dr = _cmd.ExecuteReader())
                    {
                        while (_dr.Read())
                        {
                            string _meta = _dr.IsDBNull(7) ? "" : _dr.GetString(7);
                            MDQuery_ComputeColumnDefine _item = new MDQuery_ComputeColumnDefine(
                                    _dr.IsDBNull(0) ? "" : _dr.GetString(0),
                                    _dr.IsDBNull(1) ? "" : _dr.GetString(1),
                                    _dr.IsDBNull(2) ? "" : _dr.GetString(2),
                                    _dr.IsDBNull(3) ? "" : _dr.GetString(3),
                                    _dr.IsDBNull(4) ? false : (_dr.GetDecimal(4) > 0),
                                    _dr.IsDBNull(5) ? "" : _dr.GetString(5),
                                    _dr.IsDBNull(6) ? "" : _dr.GetString(6),
                                    StrUtils.GetMetaByName2("ResultDataType", _meta),
                                    StrUtils.GetMetaByName2("Expression", _meta),
                                    _dr.IsDBNull(9) ? DateTime.MinValue : _dr.GetDateTime(9)
                            );
                            _ret.Add(_item);
                        }
                    }
                    cn.Close();
                }
                catch (Exception e)
                {
                    cn.Close();
                    throw e;
                }
            }
            return _ret;
        }

        private const string SQL_GetFunctionList = @"select FUNID,FUNCTIONNAME,DISPLAYNAME,DESCRIPTION,RESULTTYPE,TYPE,PARAMETA
                                                    from  md_function where TYPE=:TYPE";
        public List<MD_FUNCTION> GetFunctionList(int _type)
        {
            List<MD_FUNCTION> _ret = new List<MD_FUNCTION>();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {

                    OracleCommand _cmd = new OracleCommand(SQL_GetFunctionList, cn);
                    _cmd.Parameters.Add(":TYPE", Convert.ToDecimal(_type));
                    using (OracleDataReader _dr = _cmd.ExecuteReader())
                    {
                        while (_dr.Read())
                        {
                            string _meta = _dr.IsDBNull(6) ? "" : _dr.GetString(6);
                            MD_FUNCTION _item = new MD_FUNCTION(
                                    _dr.IsDBNull(0) ? "" : _dr.GetDecimal(0).ToString(),
                                    _dr.IsDBNull(1) ? "" : _dr.GetString(1),
                                    _dr.IsDBNull(2) ? "" : _dr.GetString(2),
                                    _dr.IsDBNull(3) ? "" : _dr.GetString(3),
                                     _dr.IsDBNull(4) ? "" : _dr.GetString(4),
                                    _dr.IsDBNull(5) ? "" : _dr.GetDecimal(5).ToString()
                            );
                            _item.ParamList = new List<string>();
                            _item.ParamTypeDict = new Dictionary<string, string>();
                            string[] _strs = _meta.Split(',');
                            foreach (string _s in _strs)
                            {
                                string _pname = StrUtils.GetMetaByName2("name", _s);
                                string _ptype = StrUtils.GetMetaByName2("type", _s);
                                _item.ParamList.Add(_pname);
                                _item.ParamTypeDict.Add(_pname, _ptype);
                            }
                            _ret.Add(_item);
                        }
                    }
                    cn.Close();
                }
                catch (Exception e)
                {
                    cn.Close();
                    throw e;
                }
            }
            return _ret;
        }



        public string GetCanUsePanalizeSet()
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    string _sql = "select count(*)  from zhtj_csb t where csname='不需要分析空间' and csdata='1' ";

                    OracleCommand _cmd = new OracleCommand(_sql, cn);
                    object _retObj = _cmd.ExecuteScalar();
                    if (_retObj == null) return "0";
                    return _retObj.ToString();

                }
                catch (Exception e)
                {
                    cn.Close();
                    return "1";
                }
            }
            return "1";
        }




        public string GetQueryModelDescription(string _modelName)
        {
            string _ret = "";
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    string[] _strs = _modelName.Split('.');
                    string _sql = "select description from md_view where namespace=:ns and viewname = :nv";
                    OracleCommand _cmd = new OracleCommand(_sql, cn);
                    _cmd.Parameters.Add(":ns", _strs[0]);
                    _cmd.Parameters.Add(":nv", _strs[1]);
                    using (OracleDataReader _dr = _cmd.ExecuteReader())
                    {
                        while (_dr.Read())
                        {
                            _ret = _dr.IsDBNull(0) ? "" : _dr.GetString(0);
                        }
                    }

                }
                catch (Exception e)
                {
                    throw e;
                }
                cn.Close();
            }
            return _ret;
        }


        public DataTable GetRuleList(string QueryModelName)
        {
            string _sql;
            DataTable _ret = new DataTable();
            _ret.TableName = "RULELIST";
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    string _getSJDW = "select ZHTJ_ZZJG2.GetParent_DWDM(:dwdm,1) from dual";
                    OracleCommand getCmd = new OracleCommand(_getSJDW, cn);
                    getCmd.Parameters.Add(":dwdm", SinoUserCtx.CurUser.CurrentPost.PostDWDM);
                    object _sjdwdm = getCmd.ExecuteScalar();

                    string[] _strs = QueryModelName.Split('.');
                    _sql = "select ID,GZMC from SJSH_SHGZB where NAMESPACE= :ns and VIEWNAME=:nv and DWDM=:dwdm";
                    OracleCommand _cmd = new OracleCommand(_sql, cn);
                    _cmd.Parameters.Add(":ns", _strs[0]);
                    _cmd.Parameters.Add(":nv", _strs[1]);
                    _cmd.Parameters.Add(":dwdm", _sjdwdm.ToString());
                    OracleDataAdapter _da = new OracleDataAdapter(_cmd);
                    _da.Fill(_ret);
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("取审核规则列表时出错,错误信息为:{0}!\n _queryModelName={1}",
                        e.Message, QueryModelName);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");

                }
                cn.Close();
            }

            return _ret;
        }


        private const string SQL_ImportRule_sql = "select ID,GZMC,GZSF,DWDM,STATE,VIEWNAME,NAMESPACE from SJSH_SHGZB where ID=:ID";
        private const string SQL_ImportRule_ins = @"insert into SJSH_SHGZB (ID,VIEWNAME,NAMESPACE,GZMC,GZSF,DWDM,STATE)
                                                    values ( SEQUENCES_META.NEXTVAL,:VIEWNAME,:NAMESPACE,:GZMC,:GZSF,:DWDM,0)";
        public void ImportRule(string SrcRuleID)
        {
            OracleCommand _cmd;
            MD_CheckRule srcRule = null;

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                try
                {
                    #region 取源规则
                    _cmd = new OracleCommand(SQL_ImportRule_sql, cn);
                    _cmd.Parameters.Add(":ID", decimal.Parse(SrcRuleID));
                    OracleDataReader dr = _cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        string _ns = dr.IsDBNull(6) ? "" : dr.GetString(6);
                        string _qv = dr.IsDBNull(5) ? "" : dr.GetString(5);

                        srcRule = new MD_CheckRule(
                                dr.IsDBNull(0) ? "" : dr.GetDecimal(0).ToString(),
                                string.Format("{0}.{1}", _ns, _qv),
                                dr.IsDBNull(1) ? "" : dr.GetString(1),
                                dr.IsDBNull(2) ? "" : dr.GetString(2),
                                dr.IsDBNull(3) ? "" : dr.GetString(3),
                                dr.IsDBNull(4) ? false : (dr.GetDecimal(4) > 0)
                        );
                    }
                    dr.Close();
                    #endregion

                    #region 保存新记录
                    if (srcRule != null)
                    {
                        string[] _qvStrs = srcRule.QueryModelName.Split('.');
                        _cmd = new OracleCommand(SQL_ImportRule_ins, cn);
                        _cmd.Parameters.Add(":VIEWNAME", _qvStrs[1]);
                        _cmd.Parameters.Add(":NAMESPACE", _qvStrs[0]);
                        _cmd.Parameters.Add(":GZMC", srcRule.RuleName);
                        _cmd.Parameters.Add(":GZSF", srcRule.MethodDefine);
                        _cmd.Parameters.Add(":DWDM", SinoUserCtx.CurUser.CurrentPost.PostDWDM);
                        _cmd.ExecuteNonQuery();
                    }
                    #endregion

                    _txn.Commit();
                    cn.Close();
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("导入审核规则时出错,错误信息为:{0}!\n SrcRuleID={1}",
                       e.Message, SrcRuleID);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    _txn.Rollback();
                    cn.Close();
                }
            }

        }

        private const string SQL_RecoverRuleDefine_sql = "select ID,GZMC,GZSF,DWDM,STATE,VIEWNAME,NAMESPACE from SJSH_SHGZB where ID=:ID";
        private const string SQL_RecoverRuleDefine_ups = "update SJSH_SHGZB set  GZSF=:GZSF where ID=:ID";
        public void RecoverRuleDefine(string TargetRuleID, string SrcRuleID)
        {
            OracleCommand _cmd;
            MD_CheckRule srcRule = null;

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                try
                {

                    #region 取源规则
                    _cmd = new OracleCommand(SQL_RecoverRuleDefine_sql, cn);
                    _cmd.Parameters.Add(":ID", decimal.Parse(SrcRuleID));
                    OracleDataReader dr = _cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        string _ns = dr.IsDBNull(6) ? "" : dr.GetString(6);
                        string _qv = dr.IsDBNull(5) ? "" : dr.GetString(5);

                        srcRule = new MD_CheckRule(
                                dr.IsDBNull(0) ? "" : dr.GetDecimal(0).ToString(),
                                string.Format("{0}.{1}", _ns, _qv),
                                dr.IsDBNull(1) ? "" : dr.GetString(1),
                                dr.IsDBNull(2) ? "" : dr.GetString(2),
                                dr.IsDBNull(3) ? "" : dr.GetString(3),
                                dr.IsDBNull(4) ? false : (dr.GetDecimal(4) > 0)
                        );

                    }
                    dr.Close();
                    #endregion

                    #region 保存新记录
                    if (srcRule != null)
                    {
                        _cmd = new OracleCommand(SQL_RecoverRuleDefine_ups, cn);
                        _cmd.Parameters.Add(":GZSF", srcRule.MethodDefine);
                        _cmd.Parameters.Add(":ID", decimal.Parse(TargetRuleID));
                        _cmd.ExecuteNonQuery();
                    }
                    #endregion

                    _txn.Commit();
                    cn.Close();
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("以审核规则{1}覆盖规则{2}时出错,错误信息为:{0}!\n",
                       e.Message, SrcRuleID, TargetRuleID);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    _txn.Rollback();
                    cn.Close();
                }
            }
        }

        public string GetSjshInfo_HGJS(MDQuery_Request _queryRequest, string MainKeyID)
        {
            MDModel_QueryModel _qv = GetMDQueryModelDefine(_queryRequest.QueryModelName);
            string _ret = "";
            string _sql = "select zhcx.Get_SjshInfo_HGJS(AJID) MSG from ";
            _sql += _queryRequest.MainResultTable.TableName;
            _sql += string.Format(" where {0}=:MAINKEYID ", _qv.MainTable.TableDefine.Table.MainKey);

            try
            {
                OracleParameter[] _param = { new OracleParameter(":MAINKEYID", OracleDbType.Varchar2) };
                _param[0].Value = MainKeyID;
                object _retObj = OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);
                if (_retObj != null) _ret = _retObj.ToString();
            }
            catch (Exception e)
            {
                string _errmsg = string.Format("取审核信息zhcx.Get_SjshInfo_HGJS({1})时出错,错误信息为:{0}!\n",
                   e.Message, MainKeyID);
                OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
            }

            return _ret;
        }

        private const string SQL_GetDataCheckBoardList = @"select ID,SHJLID,(select JGMC from ZZJGB WHERE ZZJGDM = FBDW) FBDWMC, FBDW,FBR,FBSJ,XXBT,
                                                           (select JGMC from ZZJGB where ZZJGDM = CDDW) CDDWMC,FKJG,SFYC from SJSH_GGXX
                                                            where  FBDW = :FBDW OR (ZH_SHANGJI(:FBDW2,FBDW) ='1' AND SFYC=0) ORDER BY FBSJ DESC";
        public DataTable GetDataCheckBoardList()
        {
            DataTable _ret = new DataTable();

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_GetDataCheckBoardList, cn);
                    _cmd.Parameters.Add(":FBDW", SinoUserCtx.CurUser.CurrentPost.PostDWDM);
                    _cmd.Parameters.Add(":FBDW2", SinoUserCtx.CurUser.CurrentPost.PostDWDM);
                    OracleDataAdapter _da = new OracleDataAdapter(_cmd);
                    _da.Fill(_ret);
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("取审核公告列表时出错,错误信息为:{0}!FBDW={1}\n SQL语句：{2}",
                        e.Message, SinoUserCtx.CurUser.CurrentPost.PostDwID, SQL_GetDataCheckBoardList);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");

                }
                cn.Close();
            }
            return _ret;

        }

        private const string SQL_GetDataCheckMsg = @"select ID,SHJLID,BH,FBDW,(select JGMC from ZZJGB WHERE ZZJGDM = FBDW) FBDWMC,FBSJ, FBR,
                                                        LXDH,DZYJ,XXBT,XXNR,CDDW,
                                                         (select JGMC from ZZJGB where ZZJGDM = CDDW) CDDWMC,FKJG,FKSJ,SFYC from SJSH_GGXX
                                                         where  (FBDW = :FBDW OR (ZH_SHANGJI(:FBDW2,FBDW) ='1' AND SFYC=0) ) 
                                                         and ID=:ID ORDER BY FBSJ DESC";
        public MD_DataCheckMsg GetDataCheckMsg(string _ggjlid)
        {
            MD_DataCheckMsg _ret = null;
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_GetDataCheckMsg, cn);
                    _cmd.Parameters.Add(":FBDW", SinoUserCtx.CurUser.CurrentPost.PostDWDM);
                    _cmd.Parameters.Add(":FBDW2", SinoUserCtx.CurUser.CurrentPost.PostDWDM);
                    _cmd.Parameters.Add(":ID", decimal.Parse(_ggjlid));
                    using (OracleDataReader _dr = _cmd.ExecuteReader())
                    {
                        while (_dr.Read())
                        {
                            _ret = new MD_DataCheckMsg(
                                    _dr.IsDBNull(0) ? "" : _dr.GetDecimal(0).ToString(),
                                    _dr.IsDBNull(1) ? "" : _dr.GetDecimal(1).ToString(),
                                    _dr.IsDBNull(2) ? "" : _dr.GetString(2),
                                    _dr.IsDBNull(3) ? "" : _dr.GetString(3),
                                    _dr.IsDBNull(4) ? "" : _dr.GetString(4),
                                    _dr.IsDBNull(5) ? DateTime.MinValue : _dr.GetDateTime(5),
                                    _dr.IsDBNull(6) ? "" : _dr.GetString(6),
                                    _dr.IsDBNull(7) ? "" : _dr.GetString(7),
                                    _dr.IsDBNull(8) ? "" : _dr.GetString(8),
                                    _dr.IsDBNull(9) ? "" : _dr.GetString(9),
                                    _dr.IsDBNull(10) ? "" : _dr.GetString(10),
                                    _dr.IsDBNull(11) ? "" : _dr.GetString(11),
                                    _dr.IsDBNull(12) ? "" : _dr.GetString(12),
                                    _dr.IsDBNull(13) ? "" : _dr.GetString(13),
                                    _dr.IsDBNull(14) ? null : (object)_dr.GetDateTime(14),
                                    _dr.IsDBNull(15) ? (decimal)0 : _dr.GetDecimal(15)
                             );
                        }
                    }
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("取审核公告信息时出错,错误信息为:{0}!ID={1}\n SQL语句：{2}",
                        e.Message, _ggjlid, SQL_GetDataCheckMsg);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");

                }
                cn.Close();
            }
            return _ret;
        }



        public bool InsertNewDataCheckMsg(string _shjlid, string _title, string _context, string _cddw, string _tel, string _email, decimal _sfkj)
        {
            string _sql = "insert into SJSH_GGXX ";
            _sql += " ( ID,SHJLID,BH,FBDW,FBSJ,FBR,LXDH,DZYJ,XXBT,XXNR,CDDW,SFYC) ";
            _sql += " values (  SEQUENCES_META.NEXTVAL,:SHJLID,'',:FBDW,sysdate,:FBR,:LXDH,:DZYJ,:XXBT,:XXNR,:CDDW,:SFYC) ";
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    List<OracleParameter> _plist = new List<OracleParameter>(); //OracleCommand _cmd = new OracleCommand(_sql, cn);
                    _plist.Add(new OracleParameter(":SHJLID", decimal.Parse(_shjlid)));
                    _plist.Add(new OracleParameter(":FBDW", SinoUserCtx.CurUser.CurrentPost.PostDWDM));
                    _plist.Add(new OracleParameter(":FBR", SinoUserCtx.CurUser.UserName));
                    _plist.Add(new OracleParameter(":LXDH", _tel));
                    _plist.Add(new OracleParameter(":DZYJ", _email));
                    _plist.Add(new OracleParameter(":XXBT", _title));
                    _plist.Add(new OracleParameter(":XXNR", _context));
                    _plist.Add(new OracleParameter(":CDDW", _cddw));
                    _plist.Add(new OracleParameter(":SFYC", _sfkj));
                    OracleHelper.ExecuteNonQuery(cn, CommandType.Text, _sql, _plist.ToArray());//_cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("插入审核公告信息时出错,错误信息为:{0}!",
                       e.Message);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    return false;
                }
            }
            return true;
        }

        private const string SQL_UpdateDataCheckMsg = @"update SJSH_GGXX set 
                                                        XXBT=:XXBT,XXNR=:XXNR,CDDW=:CDDW,LXDH=:LXDH,DZYJ=:DZYJ,SFYC=:SFYC
                                                        where ID=:ID";
        public bool UpdateDataCheckMsg(string _ggjlid, string _title, string _context, string _cddw, string _tel, string _email, decimal _sfkj)
        {

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_UpdateDataCheckMsg, cn);
                    _cmd.Parameters.Add(":XXBT", _title);
                    _cmd.Parameters.Add(":XXNR", _context);
                    _cmd.Parameters.Add(":CDDW", _cddw);
                    _cmd.Parameters.Add(":LXDH", _tel);
                    _cmd.Parameters.Add(":DZYJ", _email);
                    _cmd.Parameters.Add(":SFYC", _sfkj);
                    _cmd.Parameters.Add(":ID", decimal.Parse(_ggjlid));
                    _cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("保存修改的审核公告信息时出错,错误信息为:{0}!",
                       e.Message);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    return false;
                }
            }
            return true;
        }


        private const string SQL_GetSjshInfo_DWID = "select ZHTJ_ZZJG2.GETDWID_hgjs(DWDM) from SJSH_JGJLB WHERE SHJLID=:SHJLID ";
        public string GetSjshInfo_DWID(string _shjlid)
        {
            string _ret = "";
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_GetSjshInfo_DWID, cn);
                    _cmd.Parameters.Add(":SHJLID", decimal.Parse(_shjlid));
                    object _retObj = _cmd.ExecuteScalar();
                    if (_retObj != null) _ret = _retObj.ToString();
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("取审核记录[{1}]对应的单位ID时出错,错误信息为:{0}!\n",
                       e.Message, _shjlid);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                }
            }
            return _ret;
        }



        public bool SendDataCheckMsgFK(string _ggjlid, string _fkjg)
        {

            string _sql = "update SJSH_GGXX set FKJG=:FKJG,FKSJ=sysdate where ID=:ID ";
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(_sql, cn);
                    _cmd.Parameters.Add(":FKJG", _fkjg);
                    _cmd.Parameters.Add(":ID", decimal.Parse(_ggjlid));
                    _cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("反馈审核公告信息[{1}]时出错,错误信息为:{0}!\n",
                       e.Message, _ggjlid);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    return false;
                }
            }
            return true;
        }



        public bool DeleteDataCheckMsg(string _ggjlid)
        {
            string _sql = "delete SJSH_GGXX where ID=:ID and FBDW=:FBDW";
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(_sql, cn);
                    _cmd.Parameters.Add(":ID", decimal.Parse(_ggjlid));
                    _cmd.Parameters.Add(":FBDW", SinoUserCtx.CurUser.CurrentPost.PostDWDM);
                    _cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("删除审核公告信息[{1}]时出错,错误信息为:{0}!\n",
                       e.Message, _ggjlid);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    return false;
                }
            }
            return true;
        }



        public MD_GuideLine_ParamSetting GetGuideLineParamSetting(string _guideLineID)
        {
            MD_GuideLine_ParamSetting _ret = null;
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    //判断本单位参数设置记录是否存在
                    _ret = Ora_GuideLineParamSetting.GetCurrentPostRecord(_guideLineID, cn);
                    if (_ret == null) _ret = Ora_GuideLineParamSetting.GetDefaultRecord(_guideLineID, cn);
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("取指定指标[{1}]在本单位[{2}]的参数设置时出错,错误信息为:{0}!\n",
                       e.Message, _guideLineID, SinoUserCtx.CurUser.CurrentPost.PostDwID);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");

                }
            }
            return _ret;
        }


        public bool SaveGuideLineParamSetting(MD_GuideLine_ParamSetting _paramSetting, List<MDQuery_GuideLineParameter> _paramters)
        {
            MD_GuideLine_ParamSetting SavedSetting = null;
            string _guideLineID = _paramSetting.GuideLineID;
            string _queryStr = "";
            //建查询语句
            try
            {
                List<MD_GuideLine> _gls = GetRootGuideLineList(_guideLineID);
                if (_gls.Count < 1) return false;
                int _GetQueryFinishedTime = Environment.TickCount;
                MD_GuideLine _glDefine = _gls[0];
                _queryStr = _glDefine.GuideLineMethod;
                foreach (MDQuery_GuideLineParameter _gp in _paramters)
                {
                    _queryStr = OraQueryBuilder.RebuildGuideLineQueryString(_queryStr, _gp);
                }
                _queryStr = OraQueryBuilder.ReplaceExtSecret(_queryStr, "");
            }
            catch (Exception e2)
            {
                string _errmsg = string.Format("在创建指标[{1}]在单位[{2}]的参数设置下的查询语句时出错,错误信息为:{0}!\n",
                         e2.Message, _guideLineID, SinoUserCtx.CurUser.CurrentPost.PostDwID);
                OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                return false;
            }

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                try
                {
                    //判断本单位参数设置记录是否存在
                    SavedSetting = Ora_GuideLineParamSetting.GetCurrentPostRecord(_guideLineID, cn);
                    if (SavedSetting == null)
                    {
                        SavedSetting = _paramSetting;
                        Ora_GuideLineParamSetting.InsertCurrentPostRecord(SavedSetting, _queryStr, cn);
                    }
                    else
                    {
                        SavedSetting.ParamMeta = _paramSetting.ParamMeta;
                        Ora_GuideLineParamSetting.SaveCurrentPostRecord(SavedSetting, _queryStr, cn);
                    }


                    _txn.Commit();
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("保存指标[{1}]在本单位[{2}]的参数设置时出错,错误信息为:{0}!\n",
                       e.Message, _guideLineID, SinoUserCtx.CurUser.CurrentPost.PostDwID);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    _txn.Rollback();
                    return false;
                }
            }
            return true;
        }

        private void RebuildCurrentGuideLineParamSetting(MD_GuideLine _rgl)
        {
            MDQuery_GuideLineParameter _ret;
            if (_rgl.GuideLineMethod.Trim() != "")
            {

                MD_GuideLine_ParamSetting _gp = GetGuideLineParamSetting(_rgl.ID);
                List<MDQuery_GuideLineParameter> _params = new List<MDQuery_GuideLineParameter>();
                foreach (MD_GuideLineParameter _p in MC_GuideLine.GetParametersFromMeta(_rgl.GuideLineMeta))
                {
                    _ret = null;
                    string _valueStr = StrUtils.GetMetaByName(_p.ParameterName, _gp.ParamMeta);
                    switch (_p.ParameterType)
                    {
                        case "代码表":
                            string _s2 = StrUtils.GetMetaByName("REF_CODE", _valueStr);
                            _ret = new MDQuery_GuideLineParameter(_p, _s2);
                            break;
                        default:
                            _ret = new MDQuery_GuideLineParameter(_p, _valueStr);
                            break;
                    }
                    if (_ret != null) _params.Add(_ret);
                }


                SaveGuideLineParamSetting(_gp, _params);
            }
        }

        public bool RebuildGuideLineParamSetting(string GuideLineID)
        {
            List<MD_GuideLine> _rootGls = GetRootGuideLineList(GuideLineID);
            foreach (MD_GuideLine _rgl in _rootGls)
            {
                //生成本指标的算法
                RebuildCurrentGuideLineParamSetting(_rgl);
                //生成下载指标算法
                ReBuildChildGuideLineParamSetting(_rgl.ID);
            }
            return true;
        }

        private void ReBuildChildGuideLineParamSetting(string GuideLineID)
        {
            List<MD_GuideLine> _gls = GetGuideLineListByFatherID(GuideLineID);
            foreach (MD_GuideLine _rgl in _gls)
            {
                //生成本指标的算法
                RebuildCurrentGuideLineParamSetting(_rgl);
                //递归生成下载指标算法
                ReBuildChildGuideLineParamSetting(_rgl.ID);
            }
        }

        private const string SQL_GetInputGroupByID = @"select IVG_ID,IV_ID,DISPLAYTITLE,DISPLAYORDER,GROUPTYPE,APPREGURL,GROUPCS
                                                            from md_inputgroup where IVG_ID=:IVGID";
        public MD_InputModel_ColumnGroup GetInputGroupByID(string InputGroupID)
        {
            MD_InputModel_ColumnGroup _ret = null;

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand(SQL_GetInputGroupByID, cn);
                _cmd.Parameters.Add(":IVGID", decimal.Parse(InputGroupID));

                OracleDataReader _dr = _cmd.ExecuteReader();
                while (_dr.Read())
                {
                    string _groupid = _dr.IsDBNull(0) ? "0" : _dr.GetDecimal(0).ToString();
                    string _ivid = _dr.IsDBNull(1) ? "" : _dr.GetDecimal(1).ToString();
                    string _title = _dr.IsDBNull(2) ? "" : _dr.GetString(2);
                    int _order = _dr.IsDBNull(3) ? 0 : Convert.ToInt32(_dr.GetDecimal(3));
                    _ret = new MD_InputModel_ColumnGroup(_groupid, _ivid, _title, _order);
                    _ret.GroupType = _dr.IsDBNull(4) ? "DEFAULT" : _dr.GetString(4).ToUpper();
                    _ret.AppRegUrl = _dr.IsDBNull(5) ? "" : _dr.GetString(5);
                    _ret.GroupParam = _dr.IsDBNull(6) ? "" : _dr.GetString(6);
                    GetColumnsOfInputGroup(_ret, cn);
                }
                _dr.Close();
                cn.Clone();
            }
            return _ret;
        }




        public bool DelComputeFieldDefine(string ColumnName)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    string _sql = "delete from MD_COMPUTECOLUMN where ID=:ID";
                    OracleCommand _cmd = new OracleCommand(_sql, cn);
                    _cmd.Parameters.Add(":ID", ColumnName);
                    _cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("删除收藏的计算项字段[{1}]时出错,错误信息为:{0}!\n",
                    e.Message, ColumnName);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    return false;
                }
            }

        }




        public DataSet CompareData(MDCompare_Request compareRequest, DataTable srcData)
        {
            DataSet _ret = new DataSet();
            int _startTime = Environment.TickCount;
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            MDModel_QueryModel _qv = _of.GetMDQueryModelDefine(compareRequest.QueryModelName);

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction txn = cn.BeginTransaction();
                try
                {

                    //先将数据存入临时表
                    string _cmdStr = "select * from TEMP_IMPDATA";
                    OracleDataAdapter adapter = new OracleDataAdapter(_cmdStr, cn);
                    OracleCommandBuilder builder = new OracleCommandBuilder(adapter);
                    adapter.Update(srcData);

#if DEBUG
                    DataTable _testSrcData = new DataTable();
                    OracleDataAdapter _oda2 = new OracleDataAdapter(_cmdStr, cn);
                    _oda2.Fill(_testSrcData);
#endif

                    //执行主查询
                    string _CompareStr = CompareBuilder.CreateCompareSQL(_qv, compareRequest);
                    OracleHelper.ExecuteNonQuery(cn, CommandType.Text, _CompareStr);



#if DEBUG
                    DataTable _testCompareResultData = new DataTable();
                    OracleDataAdapter _oda3 = new OracleDataAdapter("select * from COMP_TEMP", cn);
                    _oda3.Fill(_testCompareResultData);
#endif
                    //取匹配结果
                    Dictionary<string, string> _getResults = CompareBuilder.GetAllResultSQL(_qv, compareRequest);
                    foreach (string _key in _getResults.Keys)
                    {
                        adapter = new OracleDataAdapter();

                        string _queryStr = (string)_getResults[_key];
                        DataTable _lsdt = OracleHelper.FillDataTable(cn, CommandType.Text, _queryStr);
                        _lsdt.TableName = _key;
                        _ret.Tables.Add(_lsdt);
                    }


                    ////取目标未匹配剩余
                    //string _residualStr = "select * from TEMP_IMPDATA where xh not in (select pk_c from COMP_TEMP)";
                    //OracleDataAdapter _adapter3 = new OracleDataAdapter();
                    //_adapter3.SelectCommand = new OracleCommand(_residualStr, cn);
                    //_adapter3.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                    //_adapter3.Fill(_ret, "RESIDUAL");

                    int _timecount = Environment.TickCount - _startTime;
                    WriteQueryLog(_CompareStr, _timecount);

                    return _ret;
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("数据比对时发生错误,错误信息为:{0}!\n",
                    e.Message);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");

                }
            }
            return _ret;
        }




        public string GetAttachFileName(string IndexString, string FieldName)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    string[] _fs = FieldName.Split('.');
                    if (_fs.Length < 2)
                    {
                        throw new Exception("字段名称参数格式不正确，要求格式为：表名.字段名");
                    }


                    string _sql = string.Format("select {0} from {1} where ID=:ID", _fs[1], _fs[0]);

                    OracleParameter[] _param = { new OracleParameter(":ID", IndexString) };
                    object _retObj = OracleHelper.ExecuteScalar(cn, CommandType.Text, _sql, _param);

                    if (_retObj == null) return "";
                    return _retObj.ToString();

                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("取附件的文件名称时出错,IndexString={1} FieldName={2} 错误信息为:{0}!\n",
                    e.Message, IndexString, FieldName);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    return "";
                }
            }
        }

        public byte[] GetAttachFileBytes(string IndexString, string FieldName)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    string[] _fs = FieldName.Split('.');
                    if (_fs.Length < 2)
                    {
                        throw new Exception("字段名称参数格式不正确，要求格式为：表名.字段名");
                    }
                    string _sql = string.Format("select {0} from {1} where ID=:ID", _fs[1], _fs[0]);

                    OracleParameter[] _param = {
                                 new OracleParameter(":ID",OracleDbType.Varchar2)};
                    _param[0].Value = IndexString;
                    OracleDataReader myOracleDataReader = OracleHelper.ExecuteReader(cn, CommandType.Text, _sql, _param);

                    myOracleDataReader.Read();
                    OracleBlob myOracleBlob = myOracleDataReader.GetOracleBlob(0);
                    myOracleBlob.Position = 0;
                    long lobLength = myOracleBlob.Length;
                    byte[] cbuffer = new byte[lobLength];
                    int actual = myOracleBlob.Read(cbuffer, 0, cbuffer.Length);
                    myOracleDataReader.Close();
                    return cbuffer;
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("取附件内容时出错,IndexString={1} FieldName={2} 错误信息为:{0}!\n",
                    e.Message, IndexString, FieldName);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    return null;
                }
            }
        }


        public string GetFLWSFileName(string IndexString, string FieldName)
        {
            string _ret = "";
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    string[] _fn = FieldName.Split(',');
                    string mczd = _fn[0];
                    string dkfszd = _fn[1];

                    string[] _fs = mczd.Split('.');
                    if (_fs.Length < 2)
                    {
                        throw new Exception("字段名称参数格式不正确，要求格式为：表名.字段名");
                    }
                    string _sql = string.Format("select {0},{1} from {2} where WSID=:ID", _fn[0], _fn[1], _fs[0]);


                    OracleParameter[] _param = {
                                 new OracleParameter(":ID",OracleDbType.Varchar2) };
                    _param[0].Value = IndexString;

                    using (OracleDataReader _dr = OracleHelper.ExecuteReader(cn, CommandType.Text, _sql, _param))
                    {
                        while (_dr.Read())
                        {
                            string _wjm = _dr.IsDBNull(0) ? "noname" : _dr.GetString(0);
                            string _dkfs = _dr.IsDBNull(1) ? "" : _dr.GetString(1);
                            switch (_dkfs)
                            {
                                case "1":
                                    _ret = _wjm + ".info";
                                    break;
                                case "2":
                                    _ret = _wjm + ".xls";
                                    break;
                                case "3":
                                    _ret = _wjm + ".doc";
                                    break;
                                case "4":
                                    _ret = _wjm + ".pdf";
                                    break;
                                default:
                                    _ret = _wjm + ".temp";
                                    break;
                            }
                        }
                        _dr.Close();
                    }
                    return _ret;

                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("取法律文书的文件名称时出错,IndexString={1} FieldName={2} 错误信息为:{0}!\n",
                    e.Message, IndexString, FieldName);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    return "";
                }
            }
        }

        public byte[] GetFLWSFileBytes(string IndexString, string FieldName)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    string[] _fs = FieldName.Split('.');
                    if (_fs.Length < 2)
                    {
                        throw new Exception("字段名称参数格式不正确，要求格式为：表名.字段名");
                    }
                    string _sql = string.Format("select {0} from {1} where WSID=:ID", _fs[1], _fs[0]);
                    OracleParameter[] _param = {
                                new OracleParameter(":ID",OracleDbType.Varchar2)
                               
                        };
                    _param[0].Value = IndexString;

                    OracleDataReader myOracleDataReader = OracleHelper.ExecuteReader(cn, CommandType.Text, _sql, _param);
                    myOracleDataReader.Read();
                    OracleBlob myOracleBlob = myOracleDataReader.GetOracleBlob(0);
                    myOracleBlob.Position = 0;
                    long lobLength = myOracleBlob.Length;
                    byte[] cbuffer = new byte[lobLength];
                    int actual = myOracleBlob.Read(cbuffer, 0, cbuffer.Length);
                    myOracleDataReader.Close();
                    return cbuffer;

                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("取法律文书内容时出错,IndexString={1} FieldName={2} 错误信息为:{0}!\n",
                    e.Message, IndexString, FieldName);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    return null;
                }
            }
        }


        private const string SQL_GetTaskQueryLog = @"select * from TASK_QUERY_SQL_LOG where TASK_ID=:TASKID order by ACTIONTIME";
        public DataTable GetTaskQueryLog(string TaskID)
        {
            OracleParameter[] _param = {
                                new OracleParameter(":TASKID",OracleDbType.Varchar2)
                               
                        };
            _param[0].Value = TaskID;
            return OracleHelper.FillDataTable(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_GetTaskQueryLog, _param);

        }


        private const string SQL_ChangeQueryTaskRequestTime = @"update task_query set REQUESTTIME=:REQUESTTIME where ID=:ID";
        public bool ChangeQueryTaskRequestTime(string TaskID, DateTime RequestTime)
        {
            OracleParameter[] _param = {
                                new OracleParameter(":REQUESTTIME",OracleDbType.Date),
				new OracleParameter(":ID",OracleDbType.Varchar2)
                        };
            _param[0].Value = RequestTime;
            _param[1].Value = TaskID;
            int _ret = OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_ChangeQueryTaskRequestTime, _param);
            return true;
        }


        public List<ReportHisDataRow> GetSjsh_HisData(string QueryModelName, string MainKeyID, string WHXH)
        {
            DataTable _olddt, _rkdt, _cdt;
            List<MDModel_Table_Column> NeedColums;
            DataRow _crow = null;
            DataRow _orow = null;
            DataRow _rkrow = null;
            MDModel_QueryModel _modelDefine = GetMDQueryModelDefine(QueryModelName);
            List<ReportHisDataRow> _ret = new List<ReportHisDataRow>();

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {

                //作者：读取历史数据
                DataTable _HisTable = null;
                DataTable _RKTable = null;
                DataTable _CurTable = null;
                string _hisTname = string.Format("{0}_HIS", _modelDefine.MainTable.TableName);

                #region 读数据
                //作者：林添喜 2005-11-11  说明：取历史表的结构
                DataTable _HisTableStruct = GetHisStruct(_hisTname, cn);
                NeedColums = GetNeedColums(_HisTableStruct, _modelDefine.MainTable);
                string _fieldstr = CreateTableHisFields(NeedColums);

                //取当前记录数据
                try
                {
                    string _getData = string.Format("SELECT {3} FROM {0} WHERE {1}='{2}' ", _modelDefine.MainTable.TableName, _modelDefine.MainTable.MainKey
                                                                , MainKeyID, _fieldstr);
                    _CurTable = OracleHelper.Get_Data(_getData, "MAINDATA");
                    if (_CurTable != null)
                    {
                        if (_CurTable.Rows.Count > 0) _crow = _CurTable.Rows[0];
                    }
                }
                catch (Exception ex)
                {
                    OralceLogWriter.WriteSystemLog(string.Format("查看数据审核历史数据时失败：取当前记录数据失败，{0}", ex.Message), "ERROR");

                }

                //取历史记录数据
                if (WHXH != null && WHXH != "")
                {
                    try
                    {
                        string _getHisData = string.Format("SELECT {4} FROM {0} WHERE {1}='{2}' and WHXH={3} ", _hisTname, _modelDefine.MainTable.MainKey
                                                                    , MainKeyID, WHXH, _fieldstr);
                        _HisTable = OracleHelper.Get_Data(_getHisData, "HISDATA");
                        if (_HisTable != null)
                        {
                            _olddt = _HisTable;
                            if (_HisTable.Rows.Count > 0) _orow = _olddt.Rows[0];
                        }
                    }
                    catch (Exception ex)
                    {
                        OralceLogWriter.WriteSystemLog(string.Format("查看数据审核历史数据时失败：取历史记录数据失败，{0}", ex.Message), "ERROR");
                    }
                }

                //取入库记录数据
                try
                {
                    string _getRKData = string.Format("SELECT {4} FROM {0} WHERE {1}='{2}' and WHXH=ZHCX_HGJS.Get_TJSH_WHXH('{3}','{1}','{2}') ",
                        _hisTname, _modelDefine.MainTable.MainKey, MainKeyID, _modelDefine.MainTable.TableName, _fieldstr);
                    _RKTable = OracleHelper.Get_Data(_getRKData, "RKDATA");
                    if (_RKTable != null)
                    {
                        _rkdt = _RKTable;
                        if (_RKTable.Rows.Count > 0) _rkrow = _rkdt.Rows[0];
                    }
                }
                catch (Exception ex)
                {
                    OralceLogWriter.WriteSystemLog(string.Format("查看数据审核历史数据时失败：取入库记录数据失败，{0}", ex.Message), "ERROR");
                }
                #endregion

            }

            #region 处理数据
            foreach (MDModel_Table_Column _tc in NeedColums)
            {
                if (_tc.CanDisplay)
                {
                    ReportHisDataRow _row = new ReportHisDataRow();
                    if (_crow != null)
                    {
                        _row.DataValue = _crow.IsNull(_tc.ColumnName) ? "" : _crow[_tc.ColumnName].ToString();
                    }
                    else
                    {
                        _row.DataValue = "";
                    }

                    if (_orow != null)
                    {
                        _row.OldValue = _orow.IsNull(_tc.ColumnName) ? "" : _orow[_tc.ColumnName].ToString();
                    }
                    else
                    {
                        _row.OldValue = "";
                    }
                    if (_rkrow != null)
                    {
                        _row.RKValue = _rkrow.IsNull(_tc.ColumnName) ? "" : _rkrow[_tc.ColumnName].ToString();
                    }
                    else
                    {
                        _row.RKValue = "";
                    }
                    _row.FieldsName = _tc.ColumnTitle;
                    _row.IsTitle = false;
                    _row.State = ((_row.DataValue == _row.OldValue) && (_row.OldValue == _row.RKValue)) || ((_row.DataValue == _row.OldValue) && (_row.RKValue == ""));

                    _ret.Add(_row);
                }
            }

            #endregion

            return _ret;

        }



        private string CreateTableHisFields(List<MDModel_Table_Column> Cols)
        {
            string _ret = "";
            foreach (MDModel_Table_Column _tc in Cols)
            {
                if (_tc.ColumnRefDMB != null && _tc.ColumnRefDMB != "")
                {
                    _ret += string.Format(",ZHCX.GETCT(TO_CHAR({0}),'{1}') {0}", _tc.ColumnName, _tc.ColumnRefDMB);
                }
                else
                {
                    _ret += string.Format(",{0}", _tc.ColumnName);
                }

            }
            if (_ret.Length > 0)
            {
                return _ret.Substring(1);
            }
            else return _ret;
        }

        private const string SQL_GetHisStruct = @"select col.column_name
                                                     from ALL_TAB_COLUMNS col,ALL_COL_COMMENTS comm where col.OWNER='ZHTJ' AND col.table_name = :TNAME
                                                     and col.table_name = comm.table_name and col.column_name = comm.column_name and col.owner = comm.owner";
        private DataTable GetHisStruct(string _hisTname, OracleConnection cn)
        {
            OracleCommand _cmd = new OracleCommand(SQL_GetHisStruct, cn);
            _cmd.Parameters.Add(":TNAME", _hisTname);
            OracleDataReader _dr = _cmd.ExecuteReader();
            DataTable _dt = new DataTable();
            _dt.TableName = _hisTname;
            OracleHelper.FillTableByReader(_dt, _dr);
            _dr.Close();
            return _dt;
        }

        private List<MDModel_Table_Column> GetNeedColums(DataTable _HisTableStruct, MDModel_Table TableDefine)
        {
            List<MDModel_Table_Column> _ret = new List<MDModel_Table_Column>();
            foreach (DataRow _dr in _HisTableStruct.Rows)
            {
                string _cname = _dr[0].ToString();
                var _col = from _c in TableDefine.Columns
                           where _c.ColumnName == _cname
                           select _c;
                if (_col != null && _col.Count() > 0)
                {
                    _ret.Add(_col.First());
                }
            }
            return _ret;
        }

        #endregion

    }
}
