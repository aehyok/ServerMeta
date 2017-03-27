using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.SystemLog
{
        public class SystemLogRecord
        {
                private string id = "";
                private DateTime czsj = DateTime.Now;
                private string logType = "";
                private string logText = "";

                public SystemLogRecord() { }
                public SystemLogRecord(string _id, DateTime _czsj, string _logType, string _logText)
                {
                        id = _id;
                        czsj = _czsj;
                        logType = _logType;
                        logText = _logText;
                }

                public string ID
                {
                        get { return id; }
                        set { id = value; }
                }
                public DateTime CZSJ
                {
                        get { return czsj; }
                        set { czsj = value; }
                }

                public string LogType
                {
                        get
                        {
                                return logType;
                        }
                        set { logType = value; }
                }

                public string LogText
                {
                        get { return logText; }
                        set { logText = value; }
                }

        }
}
