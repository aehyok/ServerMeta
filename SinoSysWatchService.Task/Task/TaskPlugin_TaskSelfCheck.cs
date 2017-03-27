using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.PluginFramework;

namespace SinoSysWatchService.Task.Task
{
    public class TaskPlugin_TaskSelfCheck : ITaskPlugin
    {
        public string Name
        {
            get { return "TaskSelfCheck"; }
        }

        public string CheckType
        {
            get { return "TASK"; }
        }

        public string Description
        {
            get { return "系统任务自检任务"; }
        }

        public int Interval
        {
            get { return 120; }
        }

        public object GetTaskObject()
        {
            Task_TaskSelfCheck _t = new Task_TaskSelfCheck();
            return _t;
        }

    }
}

