using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.PluginFramework;
using SinoSysWatchService.Task.Task;
using System.Diagnostics;
using SinoSystemWatch.Base.Common;

namespace SinoSysWatchService.Task
{
    class WatchTaskServerPlugin : IServerPlugin
    {
         private IServerApplication application;
         private string pluginName = "WatchTaskServerPlugin";
        private string description = "系统任务监控插件";


        public WatchTaskServerPlugin()
        {
        }

        #region IServerPlugin Members

        public IServerApplication ServerApplication
        {
            get
            {
                return application;
            }
            set
            {
                application = value;
            }
        }

        public string Name
        {
            get
            {
                return pluginName;
            }
            set
            {
                pluginName = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public void Load()
        {
            application.WriteMessage(string.Format("开始加载插件[{0}{1}]!", Name, description), EventLogEntryType.Information);

            //加载所有任务
            ITaskPlugin _t1 = new TaskPlugin_TaskSelfCheck();
            application.AddTask(_t1.Name, _t1);

            //加载所有命令处理器
            //application.AddCommandExecuter(pluginName, this);
            application.WriteMessage(string.Format("插件[{0}{1}]加载成功!", Name, description), EventLogEntryType.Information);
        }

        public void UnLoad()
        {
            application.WriteMessage(string.Format("开始卸载插件[{0}{1}]!", Name, description), EventLogEntryType.Information);
            //卸载所有任务

            //卸载所有命令处理器
            application.WriteMessage(string.Format("插件[{0}{1}]卸载成功!", Name, description), EventLogEntryType.Information);
        }

        public event EventHandler<EventArgs> Loading;

        public event EventHandler<EventArgs> ShowErrorMessage;


        public object GetServiceObject(string _serviceName)
        {           
            return null;
        }





        #endregion


        public byte[] DoCommand(string CommandName, byte[] ParameterData)
        {
            switch (CommandName)
            {
                case "Tasklog_Export":
                    return DoSystemTaskExport(ParameterData);
                default:
                    return null;

            }
        }


        private byte[] DoSystemTaskExport(byte[] ParameterData)
        {
            SystemTaskCheck _l = new SystemTaskCheck();
            string _type = CommandCommon.GetParamDataObj<string>(ParameterData);
            return _l.GetLogData(_type);
        }
    }

}

