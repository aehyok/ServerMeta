using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.SystemLog
{
    //public class DataBaseSystemLog : ISystemLog
    //{
    //    private ISystemLog _dbLogwriter = null;

    //    #region ISystemLog Members

    //    public bool WriteLog(string _log, System.Diagnostics.EventLogEntryType _logType)
    //    {
    //        if (_dbLogwriter != null)
    //        {
    //            return _dbLogwriter.WriteLog(_log, _logType);
    //        }
    //        return false;
    //    }

    //    public ISystemLog DBLogWriter
    //    {
    //        get
    //        {
    //            return _dbLogwriter;
    //        }
    //        set
    //        {
    //            _dbLogwriter = value;
    //        }
    //    }

    //    #endregion


    //    public bool WriteUserLog(decimal _yhid, string _czlx, string _cxnr, decimal _resulttype, string _ipaddr, string _hostName, string _systemID)
    //    {
    //        if (_dbLogwriter != null)
    //        {
    //            return _dbLogwriter.WriteUserLog(_yhid, _czlx, _cxnr, _resulttype, _ipaddr, _hostName, _systemID);
    //        }
    //        return false;
    //    }
    //}
}
