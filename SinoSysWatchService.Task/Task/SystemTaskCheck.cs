using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.WatchNode;
using SinoSystemWatch.Base.TaskCheck;
using System.Web.Script.Serialization;
using System.Configuration;
using Oracle.DataAccess.Client;
using System.Data;
using SinoSystemWatch.Base.Application;
using System.IO;
using System.IO.Compression;

namespace SinoSysWatchService.Task.Task
{
    public class SystemTaskCheck : ICheckProject
    {
        public int Check(ref string json)
        {
            List<CheckTaskStatus> TaskInfo = GetTaskStatus();
            int _ret = CheckError(TaskInfo);
            var jser = new JavaScriptSerializer();
            //序列化
            json = jser.Serialize(TaskInfo);

            return _ret;

        }

        private int CheckError(List<CheckTaskStatus> TaskInfo)
        {
            int _ret = 1;
            foreach (CheckTaskStatus _ct in TaskInfo)
            {
                if (_ct.RWZT == 9) _ret = 3;
                if (_ct.LastRunFlag == 9) _ret = 3;
                if (_ct.ErrorNum > 0) _ret = Math.Max(_ret, 2);
            }
            return _ret;
        }

        private List<CheckTaskStatus> GetTaskStatus()
        {
            List<CheckTaskStatus> _ret = new List<CheckTaskStatus>();

            Dictionary<string, string> _connList = new Dictionary<string, string>();
            foreach (ConnectionStringSettings _cstr in ConfigurationManager.ConnectionStrings)
            {
                if (_cstr.ProviderName == "System.Data.OracleClient")
                {
                    _connList.Add(_cstr.Name, _cstr.ConnectionString);
                }
            }

            CheckTaskConfigSection TaskList = (CheckTaskConfigSection)ConfigurationManager.GetSection("CheckTaskList");
            foreach (CheckTaskConfigurationElement _el in TaskList.PluginCollection)
            {
                CheckTaskStatus _wss = new CheckTaskStatus();
                _wss.Name = _el.Name;
                _wss.Description = _el.Description;
                _wss.RWID = _el.RWID;
                GetTaskRunFlag(_wss, _el.ConnectName, _connList);

                _ret.Add(_wss);
            }
            return _ret;
        }


        private const string SQL_GetTaskRunFlag = @"select rwmc,runflag,rwzt from gzrw where RWID=:RWID";
        private const string SQL_GetErrorNum = @"select count(rzid) from gzrw_rz  where runtime>:RUNTIME and runflag=9 and rwid=:RWID";
        private void GetTaskRunFlag(CheckTaskStatus _wss, string cName, Dictionary<string, string> _connList)
        {
            if (_connList.ContainsKey(cName))
            {
                string _cstr = _connList[cName];

                using (OracleConnection cn = new OracleConnection(_cstr))
                {
                    try
                    {
                        cn.Open();
                        OracleCommand _cmd = new OracleCommand(SQL_GetTaskRunFlag, cn);
                        _cmd.Parameters.Add(":RWID", decimal.Parse(_wss.RWID));
                        using (OracleDataReader _dr = _cmd.ExecuteReader())
                        {
                            while (_dr.Read())
                            {
                                _wss.Description = _dr.IsDBNull(0) ? "" : _dr.GetString(0);
                                _wss.LastRunFlag = _dr.IsDBNull(1) ? (int)-1 : Convert.ToInt32(_dr.GetDecimal(1));
                                _wss.RWZT = _dr.IsDBNull(2) ? (int)-1 : Convert.ToInt32(_dr.GetDecimal(2));

                            }
                            _dr.Close();
                        }

                        OracleCommand _cmd2 = new OracleCommand(SQL_GetErrorNum, cn);
                        _cmd2.Parameters.Add(":RUNTIME", DateTime.Now.Date.AddDays(-7));
                        _cmd2.Parameters.Add(":RWID", decimal.Parse(_wss.RWID));
                        decimal _count = (decimal)_cmd2.ExecuteScalar();
                        _wss.ErrorNum = Convert.ToInt32(_count);

                    }
                    catch (Exception ex)
                    {
                        _wss.LastRunFlag = -1;
                        _wss.RWZT = -1;
                    }
                }
            }
            else
            {
                _wss.ErrorNum = -1;
                _wss.LastRunFlag = -1;
                _wss.RWZT = -1;
            }
        }

        private const string SQL_GetSystemlog1 = @"select RZID,RWID,RWMC,RUNTIME,RUNFLAG,RUNRESULT from gzrw_rz where RUNTIME >= :COUNTDATE and RUNFLAG=:LOGTYPE";
        private const string SQL_GetSystemlog2 = @"select RZID,RWID,RWMC,RUNTIME,RUNFLAG,RUNRESULT from gzrw_rz where RUNTIME >= :COUNTDATE  ";
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
                        _cmd = new OracleCommand(SQL_GetSystemlog2, cn);
                        _cmd.CommandType = System.Data.CommandType.Text;
                        _cmd.Parameters.Add(":COUNTDATE", DateTime.Now.Date.AddDays(-7));
                    }
                    else
                    {
                        _cmd = new OracleCommand(SQL_GetSystemlog1, cn);
                        _cmd.CommandType = System.Data.CommandType.Text;
                        _cmd.Parameters.Add(":COUNTDATE", DateTime.Now.Date.AddDays(-7));
                        _cmd.Parameters.Add(":LOGTYPE", (_type=="ERROR"?(decimal)9:(decimal)0));
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
