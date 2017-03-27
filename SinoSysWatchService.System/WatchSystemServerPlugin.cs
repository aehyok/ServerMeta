using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.PluginFramework;
using SinoSysWatchService.System.SelfCheck;
using System.Diagnostics;
using SinoSystemWatch.Base.Common;
using System.Configuration;
using SinoSystemWatch.Base.WinServiceCheck;
using SinoSystemWatch.Base.Task;
using SinoSystemWatch.Base.SystemCheck;

namespace SinoSysWatchService.System
{

    public class WatchSystemServerPlugin : IServerPlugin
    {
        private IServerApplication application;
        private string pluginName = "WatchSystemServerPlugin";
        private string description = "操作系统运行监控插件";


        public WatchSystemServerPlugin()
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
            ITaskPlugin _t1 = new TaskPlugin_SystemSelfCheck();
            application.AddTask(_t1.Name, _t1);

            //加载所有命令处理器
            //application.AddCommandExecuter(pluginName, this);
            application.WriteMessage(string.Format("插件[{0}{1}]加载成功!", Name, description), EventLogEntryType.Information);
        }

        public void UnLoad()
        {
            application.WriteMessage(string.Format("开始卸载插件[{0}{1}]!", Name, description), EventLogEntryType.Information);
            //卸载所有任务
            application.RemoveTask("SystemSelfCheck");
            //卸载所有命令处理器
            application.WriteMessage(string.Format("插件[{0}{1}]卸载成功!", Name, description), EventLogEntryType.Information);
        }

        public event EventHandler<EventArgs> Loading;

        public event EventHandler<EventArgs> ShowErrorMessage;


        public object GetServiceObject(string _serviceName)
        {
            //BIZ_MetaDataManager bizMetaDataManager = new BIZ_MetaDataManager();
            //return bizMetaDataManager;
            return null;
        }





        #endregion


        public byte[] DoCommand(string CommandName, byte[] ParameterData)
        {
            switch (CommandName)
            {
                case "WinService_Del":
                    return DoWinService_Del(ParameterData);
                case "WinService_Add":
                    return DoWinService_Add(ParameterData);
                default:
                    return null;

            }
        }

        private byte[] DoWinService_Add(byte[] ParameterData)
        {
            WinServiceStatus _wss = CommandCommon.GetParamDataObj<WinServiceStatus>(ParameterData);
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            CheckWinServiceConfigSection CurrentSeviceList = (CheckWinServiceConfigSection)cfa.GetSection("CheckWinServiceList");
            CheckWinServiceConfigurationElement _new = new CheckWinServiceConfigurationElement();
            _new.Name = _wss.ServiceName;
            _new.Description = _wss.Description;
            CurrentSeviceList.PluginCollection.Add(_new);
            cfa.Save();
            ConfigurationManager.RefreshSection("CheckWinServiceList");
            string _ret = "TRUE";
            TaskList.RunTaskImmediately("SystemSelfCheck");
            byte[] _data = Encoding.Unicode.GetBytes(_ret);
            return _data;
        }

        private byte[] DoWinService_Del(byte[] ParameterData)
        {
            string _ret;

            string ServiceName = CommandCommon.GetParamDataObj<string>(ParameterData);

            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            CheckWinServiceConfigSection CurrentSeviceList = (CheckWinServiceConfigSection)cfa.GetSection("CheckWinServiceList");
            CurrentSeviceList.PluginCollection.Remove(ServiceName);
            cfa.Save();
            ConfigurationManager.RefreshSection("CheckWinServiceList");
            _ret = "TRUE";
            TaskList.RunTaskImmediately("SystemSelfCheck");
            byte[] _data = Encoding.Unicode.GetBytes(_ret);
            return _data;
        }
    }
}
