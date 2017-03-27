using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.PluginFramework;
using SinoSystemWatch.Base.Define;
using System.Diagnostics;
using SinoSZJS.Base.SystemLog;

namespace SinoSysMonitorCenter
{
    public class ServiceMain : IServerApplication
    {
        public void Init()
        {
            foreach (SystemStateItem _el in WatchSystemLib.SystemLib.Values)
            {
                WriteMessage(string.Format("已加载[{0}:{2}]的配置：{1}\r\n", _el.SystemName, _el.SystemURL, _el.SystemDescription), EventLogEntryType.Information);
            }
            ServerCommon _sc = new ServerCommon();
            _sc.Init(this);
        }

        public bool WriteMessage(string _message, System.Diagnostics.EventLogEntryType LogType)
        {
            EventLogSystemLog _log = new EventLogSystemLog("SinoMonitorCenterServiceLog");
            _log.WriteLog(_message, LogType);
            return true;
        }

        public bool AddTask(string _taskName, ITaskPlugin _taskPlugin)
        {
            throw new NotImplementedException();
        }

        public bool RemoveTask(string _taskName)
        {
            throw new NotImplementedException();
        }

        public bool AddCommandExecuter(string _commandName, ICommandPlugin _commandPlugin)
        {
            throw new NotImplementedException();
        }

        public void AddService(Type serviceType, System.ComponentModel.Design.ServiceCreatorCallback callback, bool promote)
        {
            throw new NotImplementedException();
        }

        public void AddService(Type serviceType, System.ComponentModel.Design.ServiceCreatorCallback callback)
        {
            throw new NotImplementedException();
        }

        public void AddService(Type serviceType, object serviceInstance, bool promote)
        {
            throw new NotImplementedException();
        }

        public void AddService(Type serviceType, object serviceInstance)
        {
            throw new NotImplementedException();
        }

        public void RemoveService(Type serviceType, bool promote)
        {
            throw new NotImplementedException();
        }

        public void RemoveService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}
