using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.PluginFramework;

namespace SinoSysWatchService.DataBase.SelfCheck
{
    public class TaskPlugin_DataBaseSelfCheck :ITaskPlugin
    {
        public string Name
        {
            get { return "DataBaseSelfCheck"; }
        }

        public string CheckType
        {
            get { return "DATABASE"; }
        }

        public string Description
        {
            get { return "ORACLE数据库自检任务"; }
        }

        public int Interval
        {
            get { return 5; }
        }

        public object GetTaskObject()
        {
            Task_DataBaseSelfCheck _t = new Task_DataBaseSelfCheck();
            return _t;
        }

    }
}
