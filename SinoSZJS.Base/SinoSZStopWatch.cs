using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base
{
        public class SinoSZStopWatch
        {
                private int _startTime = 0;
                private List<SinoSZStopWatchRecord> _records = new List<SinoSZStopWatchRecord>();
                public SinoSZStopWatch()
                {
                        _startTime = Environment.TickCount;
                }

                public void Tick(string _message)
                {
                        _records.Add(new SinoSZStopWatchRecord(_message, Environment.TickCount));
                }

                public string GetHistory()
                {
                        string _ret = "";
                        int _preTime = _startTime;
                        foreach (SinoSZStopWatchRecord _sr in _records)
                        {
                                _ret += string.Format("{0} : 用时{1}毫秒\n", _sr.Message, _sr.TickTime - _preTime);
                                _preTime = _sr.TickTime;
                        }
                        return _ret;
                }

        }
        public class SinoSZStopWatchRecord
        {
                private string message = "";
                private int tickTime = 0;

                public string Message
                {
                        get { return message; }
                }

                public int TickTime
                {
                        get { return tickTime; }
                }

                public SinoSZStopWatchRecord(string _message, int _tickTime)
                {
                        message = _message;
                        tickTime = _tickTime;
                }
        }
}
