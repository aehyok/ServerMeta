using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSystemWatch.Base.WatchNode
{
    public class CheckInfoResult
    {
        public string CheckProjectName { get; set; }
        public int StateFlag { get; set; }
        public string CheckResult { get; set; }
        public CheckInfoResult() { }
        public CheckInfoResult(string _name, string _result, int _flag)
        {
            CheckProjectName = _name;
            CheckResult = _result;
            StateFlag = _flag;
        }
    }
}
