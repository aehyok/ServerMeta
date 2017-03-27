using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using SinoSZPluginFramework;
using SinoSZPluginFramework.ServerPlugin;
using System.ComponentModel.Design;
using SinoSZJS.Base.SystemLog;
using System.Threading;
using SinoSZJS.DataAccess;
using System.ServiceModel;
using SinoSZJS.Base.Misc;

namespace SinoSZServerBase
{
    public partial class SinoSZMainService : ServiceBase, IServerApplication
    {
        private ServerPluginService serverPluginService;
        private ServiceContainer serviceContainer = new ServiceContainer();
        private Dictionary<string, ServiceHost> WcfHostLib = null;
        public SinoSZMainService(Dictionary<string, ServiceHost> hostLib)
        {
            InitializeComponent();
            WcfHostLib = hostLib;
            serverPluginService = new ServerPluginService(this);
            serviceContainer.AddService(typeof(IServerPluginService), serverPluginService);
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.        
            bool _oracleReady = OracleHelper.IsReady();
            int _count = 0;
            while (!_oracleReady && (_count < 15))
            {
                Thread.Sleep(new System.TimeSpan(0, 1, 0));
                _oracleReady = OracleHelper.IsReady();
                if (!_oracleReady)
                {
                    WriteMessage(string.Format("第{0}次测试ORACLE连接失败！", _count));
                }
                _count++;
            }
            ServerCommon.Init(this as IServerApplication, false);
            serverPluginService.LoadAllPlugin();
            serverPluginService.LoadAllWCFService(this.WcfHostLib);
            WriteMessage(string.Format("{0}启动成功!", ConfigFile.SystemDisplayName));

        }

        protected override void OnStop()
        {
            WriteMessage(string.Format("{0}中止运行!", ConfigFile.SystemDisplayName));
        }


        #region IServerApplication Members

        public bool WriteUserLog(object UserObj, string _log)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("[");
            _sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            _sb.Append("] ");
            _sb.Append(_log);

            //WriteToUserLog(_sb.ToString());
            return true;
        }

        public bool WriteMessage(string _message)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("[");
            _sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            _sb.Append("] ");
            _sb.Append(_message);

            SystemLogWriter.WriteLog(_sb.ToString(), EventLogEntryType.Information);
            return true;
        }

        public bool AddRemotingService(string _serviceName, IServerPlugin _plugin)
        {
            //ServiceLib.AddService(_serviceName, _plugin);
            //WriteMessage(string.Format("{0}的服务接口注册成功!", _serviceName));
            return true;
        }

        public bool AddTask(string _plugInName, ITaskPlugin _taskPlugin)
        {
            TaskLib.AddTask(_plugInName, _taskPlugin);
            WriteMessage(string.Format("[ {0} ]的任务注册成功!", _taskPlugin.Description));
            return true;
        }

        #endregion

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


    }
}
