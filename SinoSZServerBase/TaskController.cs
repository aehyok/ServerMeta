using System;
using System.Collections.Generic;
using System.Text;
using SinoSZPluginFramework;
using System.Threading;
using SinoSZJS.DataAccess;
using SinoSZJS.DataAccess.Sql;

namespace SinoSZServerBase
{
        public class TaskController
        {
                /// <summary>
                /// 任务管理器
                /// </summary>
                /// <param name="application"></param>
                /// <param name="_rwid">任务ID</param>
                /// <param name="_lb">任务类别</param>
                /// <param name="_ml">任务命令</param>
                public static void RunTask(string _rwid, string _lb, string _ml)
                {
                        string _pluginName = _lb.Trim();
                        ITaskPlugin _plugin = TaskLib.GetService(_pluginName);
                        if (_plugin == null) throw new Exception(string.Format("任务{0}接口未注册!", _pluginName));
                        try
                        {
                                Task_Base _task = _plugin.GetTaskObject(_rwid, _ml) as Task_Base;
                                Thread t = new Thread(new ThreadStart(_task.ThreadProc));
                                t.Start();
                        }
                        catch (Exception ex)
                        {
                                LogWriter.WriteSystemLog(ex.Message, "ERROR");
                        }
                }
        }
}
