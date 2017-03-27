using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.SystemLog;
using SinoSZJS.DataAccess;


namespace SinoSZServerBase
{
    public class OraSysLogWriter : ISystemLog
    {
        #region ISystemLog Members

        public bool WriteLog(string _log, System.Diagnostics.EventLogEntryType _logType)
        {
            string _typeStr = "INFO";
            switch (_logType)
            {
                case System.Diagnostics.EventLogEntryType.Error:
                    _typeStr = "ERROR";
                    break;
                default:
                    _typeStr = "INFO";
                    break;
            }
            OralceLogWriter.WriteSystemLog(_log, _typeStr);
            return true;
        }

        #endregion


        public bool WriteUserLog(decimal _yhid, string _czlx, string _cxnr, decimal _resulttype, string _ipaddr, string _hostName, string _systemID)
        {
            OralceLogWriter.WriteUserLog(_yhid, _czlx, _cxnr, _resulttype, _ipaddr, _hostName, _systemID);
            return true;
        }
    }
}
