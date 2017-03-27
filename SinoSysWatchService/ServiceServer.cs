using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.PluginFramework;
using System.ComponentModel.Design;
using SinoSystemWatch.Base.Task;
using SinoSZJS.Base.SystemLog;
using System.Diagnostics;
using System.IO;
using SinoSZJS.Base.Misc;

namespace SinoSysWatchService
{
    public class ServiceServer : IServerApplication
    {
        private ServerPluginService serverPluginService;
        private ServiceContainer serviceContainer = new ServiceContainer();
        public static List<AppPluginInfo> PluginDescriptList = new List<AppPluginInfo>();
        public void Start()
        {
            WriteMessage("缉私系统运行监控维护服务开始启动（服务方式)!", EventLogEntryType.Information);
            serverPluginService = new ServerPluginService(this);
            serviceContainer.AddService(typeof(IServerPluginService), serverPluginService);

            //启动所有的WCF服务
            serverPluginService.LoadAllPlugin();
            serverPluginService.LoadPluginDescript();
            ServerCommon _sc = new ServerCommon();
            _sc.Init(this as IServerApplication, false);
        }

        #region IServiceContainer Members

        public void AddService(Type serviceType, System.ComponentModel.Design.ServiceCreatorCallback callback, bool promote)
        {
            serviceContainer.AddService(serviceType, callback, promote);
        }

        public void AddService(Type serviceType, System.ComponentModel.Design.ServiceCreatorCallback callback)
        {
            serviceContainer.AddService(serviceType, callback);
        }

        public void AddService(Type serviceType, object serviceInstance, bool promote)
        {
            serviceContainer.AddService(serviceType, serviceInstance, promote);
        }

        public void AddService(Type serviceType, object serviceInstance)
        {
            serviceContainer.AddService(serviceType, serviceInstance);
        }

        public void RemoveService(Type serviceType, bool promote)
        {
            serviceContainer.RemoveService(serviceType, promote);
        }

        public void RemoveService(Type serviceType)
        {
            serviceContainer.RemoveService(serviceType);
        }

        public new object GetService(Type serviceType)
        {
            return serviceContainer.GetService(serviceType);
        }

        #endregion


        public bool WriteMessage(string _message, EventLogEntryType LogType)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append(string.Format("[{0}]", DateTime.Now.ToString("yyyyMMdd HH:mm:ss")));
            _sb.Append(_message);
            _sb.Append("\r\n");

            EventLogSystemLog _log = new EventLogSystemLog("SinoSysWatchServiceLog");
            _log.WriteLog(_sb.ToString(), LogType);
            return true;
        }

        public bool AddTask(string _taskName, ITaskPlugin _taskPlugin)
        {
            TaskList.AddByTaskplugin(_taskPlugin);
            WriteMessage(string.Format("任务[{0}]加载成功！", _taskName), EventLogEntryType.Information);
            return true;
        }

        public bool RemoveTask(string _taskName)
        {
            TaskList.RemoveTask(_taskName);
            WriteMessage(string.Format("任务[{0}]卸载成功！", _taskName), EventLogEntryType.Information);
            return true;
        }


        public bool AddCommandExecuter(string _commandName, ICommandPlugin _commandPlugin)
        {
            throw new NotImplementedException();
        }
    }
}
