using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.PluginFramework;

namespace SinoSysWatchService.Application.SelfCheck
{
    public class TaskPlugin_ApplicationSelfCheck : ITaskPlugin
    {
        public string Name
        {
            get { return "ApplicationSelfCheck"; }
        }

        public string CheckType
        {
            get { return "APPLICATION"; }
        }

        public string Description
        {
            get { return "应用系统自检任务"; }
        }

        public int Interval
        {
            get { return 120; }
        }

        public object GetTaskObject()
        {
            Task_ApplicationSelfCheck _t = new Task_ApplicationSelfCheck();
            return _t;
        }

    }
}

