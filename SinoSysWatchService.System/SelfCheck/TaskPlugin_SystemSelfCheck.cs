using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.PluginFramework;

namespace SinoSysWatchService.System.SelfCheck
{
    public class TaskPlugin_SystemSelfCheck : ITaskPlugin
    {
        public string Name
        {
            get { return "SystemSelfCheck"; }
        }

        public string CheckType
        {
            get { return "SYSTEM"; }
        }

        public string Description
        {
            get { return "操作系统自检任务"; }
        }

        public int Interval
        {
            get { return 120; }
        }

        public object GetTaskObject()
        {
            Task_SystemSelfCheck _t = new Task_SystemSelfCheck();
            return _t;
        }

    }
}
