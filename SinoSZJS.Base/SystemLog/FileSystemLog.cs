using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SinoSZJS.Base.SystemLog
{
    public class FileSystemLog : ISystemLog
    {
        private string logFileName = "SystemLog.log";

        public FileSystemLog() { }
        public FileSystemLog(string _fname)
        {
            logFileName = _fname;
        }

        #region ISystemLog Members


        public bool WriteLog(string _log, System.Diagnostics.EventLogEntryType _logType)
        {
            StreamWriter _fs;
            if (File.Exists(logFileName))
            {
                _fs = File.AppendText(logFileName);
            }
            else
            {
                _fs = File.CreateText(logFileName);
            }
            _fs.WriteLine(string.Format("[{2}] {0}:{1}", _logType.ToString(), _log, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            _fs.Close();
            return true;
        }

        #endregion


        public bool WriteUserLog(decimal _yhid, string _czlx, string _cxnr, decimal _resulttype, string _ipaddr, string _hostName, string _systemID)
        {
            StreamWriter _fs;
            if (File.Exists(logFileName))
            {
                _fs = File.AppendText(logFileName);
            }
            else
            {
                _fs = File.CreateText(logFileName);
            }
            string _log = string.Format("系统:{6}\n\r用户{0}[{1},{2}]执行{3}\n\r操作内容：{4}\n\r操作结果:{5}\n\r",
                                _yhid, _ipaddr, _hostName, _czlx, _cxnr, _resulttype, _systemID);
            _fs.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            _fs.WriteLine(_log);
            _fs.Close();
            return true;
        }
    }
}
