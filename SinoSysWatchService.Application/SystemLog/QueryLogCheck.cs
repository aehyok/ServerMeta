using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.Application;
using System.Web.Script.Serialization;
using System.Configuration;
using Oracle.DataAccess.Client;
using SinoSystemWatch.Base.WatchNode;
using System.IO;
using System.IO.Compression;
using System.Data;

namespace SinoSysWatchService.Application.SystemLog
{
    public class QueryLogCheck: ICheckProject
    {
        public int Check(ref string json)
        {
            List<SystemLogStatus> QueryLogInfo = GetQuerylogStatus();
            int _ret = CheckError(QueryLogInfo);
            var jser = new JavaScriptSerializer();
            //序列化
            json = jser.Serialize(QueryLogInfo);

            return _ret;
          
        }

        private int CheckError(List<SystemLogStatus> SystemLogInfo)
        {
            var ls = from _c in SystemLogInfo
                     where _c.ErrorNum > 0
                     select _c;
            if (ls.Count() > 0)
            {
                return 3;
            }
            else
                return 1;
        }

        private List<SystemLogStatus> GetQuerylogStatus()
        {
            List<SystemLogStatus> _ret = new List<SystemLogStatus>();

            Dictionary<string, string> _connList = new Dictionary<string, string>();
            foreach (ConnectionStringSettings _cstr in ConfigurationManager.ConnectionStrings)
            {
                if (_cstr.ProviderName == "System.Data.OracleClient")
                {
                    _connList.Add(_cstr.Name, _cstr.ConnectionString);
                }
            }

            CheckSystemLogConfigSection SystemList = (CheckSystemLogConfigSection)ConfigurationManager.GetSection("CheckSystemLogList");
            foreach (CheckSystemLogConfigurationElement _el in SystemList.PluginCollection)
            {
                SystemLogStatus _wss = new SystemLogStatus();
                _wss.Name = _el.Name;
                _wss.Description = _el.Description;
                CheckSystemLogConfigSection(_wss, _el.ConnectName, _connList);

                _ret.Add(_wss);
            }
            return _ret;
        }

        private const string SQL_CountQueryLogError = @"select count(*) from query_log
                                                            WHERE QUERY_STR LIKE ' 系统在查询数据时发生错误！%' and SJ >= :COUNTDATE";
        private const string SQL_CountQueryLogAll = @"select count(*) from query_log WHERE SJ >= :COUNTDATE";

        private void CheckSystemLogConfigSection(SystemLogStatus _wss, string cName, Dictionary<string, string> _connList)
        {
            if (_connList.ContainsKey(cName))
            {
                string _cstr = _connList[cName];
                _wss.ErrorNum = 0;
                _wss.InfoNum = 0;
                using (OracleConnection cn = new OracleConnection(_cstr))
                {
                    try
                    {
                        cn.Open();
                        OracleCommand _cmd = new OracleCommand(SQL_CountQueryLogError, cn);
                        _cmd.Parameters.Add(":COUNTDATE", DateTime.Now.Date.AddDays(-7));
                        decimal _errnum = (decimal)_cmd.ExecuteScalar();
                        _wss.ErrorNum = Convert.ToInt32(_errnum);

                        OracleCommand _cmd2 = new OracleCommand(SQL_CountQueryLogAll, cn);
                        _cmd2.Parameters.Add(":COUNTDATE", DateTime.Now.Date.AddDays(-7));
                        decimal _allnum = (decimal)_cmd2.ExecuteScalar();
                        _wss.InfoNum = Convert.ToInt32(_allnum - _errnum);

                    }
                    catch (Exception ex)
                    {
                        _wss.ErrorNum = -1;
                        _wss.InfoNum = -1;
                    }
                }
            }
            else
            {
                _wss.ErrorNum = -1;
                _wss.InfoNum = -1;
            }
        }






        private const string SQL_GetQuerylog1 = @"select ID,SJ,USETIME,QUERY_STR,LX,YHID,BZ from QUERY_LOG where SJ >= :COUNTDATE and USETIME<1";
        private const string SQL_GetQuerylog2 = @"select ID,SJ,USETIME,QUERY_STR,LX,YHID,BZ from QUERY_LOG where SJ >= :COUNTDATE ";
        public byte[] GetLogData(string _type)
        {
            byte[] _ret, _retbytes;
            OracleCommand _cmd;
            DataSet _ds = new DataSet();
            Dictionary<string, string> _connList = GetLogConnectionList();
            foreach (string _key in _connList.Keys)
            {
                using (OracleConnection cn = new OracleConnection(_connList[_key]))
                {
                    if (_type == "ALL")
                    {
                        _cmd = new OracleCommand(SQL_GetQuerylog2, cn);
                        _cmd.CommandType = System.Data.CommandType.Text;
                        _cmd.Parameters.Add(":COUNTDATE", DateTime.Now.Date.AddDays(-7));
                    }
                    else
                    {
                        _cmd = new OracleCommand(SQL_GetQuerylog1, cn);
                        _cmd.CommandType = System.Data.CommandType.Text;
                        _cmd.Parameters.Add(":COUNTDATE", DateTime.Now.Date.AddDays(-7));                      
                    }
                    DataTable _newdt = new DataTable();
                    _newdt.TableName = _key;
                    OracleDataAdapter _oda = new OracleDataAdapter(_cmd);
                    _oda.Fill(_newdt);

                    _ds.Tables.Add(_newdt);

                }
            }
            using (MemoryStream ms2 = new MemoryStream())
            {
                _ds.WriteXml(ms2);
                _ret = ms2.ToArray();
            }

            //压缩字节并返回
            using (MemoryStream _ms = new MemoryStream())
            {
                GZipStream compStream = new GZipStream(_ms, CompressionMode.Compress);

                try
                {
                    compStream.Write(_ret, 0, _ret.Length);
                }
                finally
                {
                    compStream.Dispose();
                }
                compStream.Close();
                _retbytes = _ms.ToArray();
            }
            return _retbytes;
        }

        Dictionary<string, string> GetLogConnectionList()
        {
            Dictionary<string, string> _ret = new Dictionary<string, string>();
            Dictionary<string, string> _connList = new Dictionary<string, string>();
            foreach (ConnectionStringSettings _cstr in ConfigurationManager.ConnectionStrings)
            {
                if (_cstr.ProviderName == "System.Data.OracleClient")
                {
                    _connList.Add(_cstr.Name, _cstr.ConnectionString);
                }
            }

            CheckSystemLogConfigSection SystemList = (CheckSystemLogConfigSection)ConfigurationManager.GetSection("CheckSystemLogList");
            foreach (CheckSystemLogConfigurationElement _el in SystemList.PluginCollection)
            {
                if (_connList.ContainsKey(_el.ConnectName))
                {
                    _ret.Add(_el.ConnectName, _connList[_el.ConnectName]);
                }

            }
            return _ret;
        }
    }
}

