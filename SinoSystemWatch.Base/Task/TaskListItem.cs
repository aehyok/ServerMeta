using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.PluginFramework;

namespace SinoSystemWatch.Base.Task
{
    public class TaskListItem
    {
        public string TaskName { get; set; }

        //任务检测规类  SYSTEM系统  DATABASE 数据库 APPLICATION 应用程序 INTERFACE接口 TASK任务
        public string TaskCheckType { get; set; }

        //任务当前状态 0:空闲  1：忙 
        public int State { get; set; }

        //任务上次执行时间
        public DateTime LastFinishedTime { get; set; }

        //任务下次开始时间
        public DateTime NextStartTime { get; set; }

        //上次执行结果 0:成功  1：失败  9:未知
        public int LastResult { get; set; }

        //上次执行错误信息
        public string LastErrorMsg { get; set; }

        //任务插件
        public ITaskPlugin TaskPlugin { get; set; }


        //任务执行结果情况
        public TaskRunResult TaskRunResult { get; set; }
    }
}
