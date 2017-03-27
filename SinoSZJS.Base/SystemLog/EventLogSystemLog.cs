using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace SinoSZJS.Base.SystemLog
{
    public class EventLogSystemLog : ISystemLog
    {
        private string LogName = "ZHTJLog";

        public EventLogSystemLog() { }

        public EventLogSystemLog(string _logName)
        {
            LogName = _logName;
        }

        #region ISystemLog Members

        public bool WriteLog(string _log, System.Diagnostics.EventLogEntryType _logType)
        {
            try
            {
                //日志写入操作系统的EventLog
                if (!EventLog.SourceExists(LogName))
                {
                    EventLog.CreateEventSource(LogName, LogName);
                }
                EventLog myLog = new EventLog(LogName);
                myLog.Source = LogName;
                myLog.WriteEntry(_log, _logType);

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }

        }




        public bool WriteUserLog(decimal _yhid, string _czlx, string _cxnr, decimal _resulttype, string _ipaddr, string _hostName, string _systemID)
        {
            try
            {
                //日志写入操作系统的EventLog
                if (!EventLog.SourceExists(LogName))
                {
                    EventLog.CreateEventSource(LogName, LogName);
                }
                EventLog myLog = new EventLog(LogName);
                myLog.Source = LogName;
                string _log = string.Format("系统:{6}\n\r用户{0}[{1},{2}]执行{3}\n\r操作内容：{4}\n\r操作结果:{5}\n\r", 
                    _yhid, _ipaddr, _hostName, _czlx, _cxnr, _resulttype, _systemID);
                myLog.WriteEntry(_log, EventLogEntryType.Information);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion
    }
}
