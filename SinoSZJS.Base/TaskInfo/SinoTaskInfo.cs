using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.TaskInfo
{
        public class SinoTaskInfo
        {
                private string rwid;
                private string rwzt;
                private string rwmc;
                private string rwms;
                private string rwlx;
                private string rwml;
                private DateTime nextTime;
                private DateTime lastTime;
                private string runflag;
                private string lastResult;

                public string RWID { get { return rwid; } set { rwid = value; } }
                public string RWZT { get { return rwzt; } set { rwzt = value; } }
                public string RWMC { get { return rwmc; } set { rwmc = value; } }
                public string RWMS { get { return rwms; } set { rwms = value; } }
                public string RWLX { get { return rwlx; } set { rwlx = value; } }
                public string RWML { get { return rwml; } set { rwml = value; } }
                public string RunFlag { get { return runflag; } set { runflag = value; } }
                public string LastResult { get { return lastResult; } set { lastResult = value; } }
                public DateTime LastTime { get { return lastTime; } set { lastTime = value; } }
                public DateTime NextTime { get { return nextTime; } set { nextTime = value; } }



        }
}
