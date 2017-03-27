using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.PluginFramework;
using SinoSysWatchService.Application.SelfCheck;
using System.Diagnostics;
using SinoSystemWatch.Base.SystemCheck;
using SinoSystemWatch.Base.Common;
using SinoSystemWatch.Base.Application;
using System.Configuration;
using SinoSystemWatch.Base.Task;
using SinoSysWatchService.Application.IISLog;
using SinoSZJS.Base.Misc;
using System.IO;
using SinoSysWatchService.Application.SystemLog;

namespace SinoSysWatchService.Application
{
    public class WatchApplicationServerPlugin : IServerPlugin
    {
        private IServerApplication application;
        private string pluginName = "WatchApplicationServerPlugin";
        private string description = "应用系统监控插件";


        public WatchApplicationServerPlugin()
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
            ITaskPlugin _t1 = new TaskPlugin_ApplicationSelfCheck();
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
                case "WCFService_Del":
                    return DoWCFService_Del(ParameterData);
                case "WCFService_Add":
                    return DoWCFService_Add(ParameterData);
                case "IIS_Export":
                    return DoIIS_Export(ParameterData);
                case "IIS_GetBlockedList":
                    return DoGetBlockedList(ParameterData);
                case "IIS_SaveBlockedList":
                    return DoSaveBlockedList(ParameterData);
                case "Systemlog_Export":
                    return DoSystemLogExport(ParameterData);
            
                default:
                    return null;

            }
        }


        private byte[] DoSystemLogExport(byte[] ParameterData)
        {
            string _str = CommandCommon.GetParamDataObj<string>(ParameterData);

            string[] _cstr = _str.Split('.');
            switch (_cstr[0])
            {
                case "SystemLogCheck":
                    SystemLogCheck _l = new SystemLogCheck();
                    return _l.GetLogData(_cstr[1]);
                case "QueryLogCheck":
                    QueryLogCheck _q = new QueryLogCheck();
                    return _q.GetLogData(_cstr[1]);
                case "UserLogCheck":
                    UserLogCheck _u = new UserLogCheck();
                    return _u.GetLogData(_cstr[1]);
                default:
                    return null;
            }

        }

        private byte[] DoSaveBlockedList(byte[] ParameterData)
        {
            string _str = CommandCommon.GetParamDataObj<string>(ParameterData);
            string blockedListfn = Utils.ExeDir + "IISBlockedList.dat";
            if (File.Exists(blockedListfn))
            {
                File.Delete(blockedListfn);
            }
            File.WriteAllText(blockedListfn, _str);
            string _ret = "TRUE";
            TaskList.RunTaskImmediately("SystemSelfCheck");
            byte[] _data = Encoding.Unicode.GetBytes(_ret);
            return _data;
        }

        private byte[] DoGetBlockedList(byte[] ParameterData)
        {
            string blockedListfn = Utils.ExeDir + "IISBlockedList.dat";
            if (File.Exists(blockedListfn))
            {
                string str = File.ReadAllText(blockedListfn);
                byte[] _data = Encoding.Unicode.GetBytes(str);
                return _data;
            }
            else
            {
                return null;
            }
        }

        private byte[] DoIIS_Export(byte[] ParameterData)
        {
            IISLogCheck _l = new IISLogCheck();
            string _type = CommandCommon.GetParamDataObj<string>(ParameterData);
            return _l.GetLogData(_type);
        }

        private byte[] DoWCFService_Add(byte[] ParameterData)
        {
            WCFServiceStatus _wss = CommandCommon.GetParamDataObj<WCFServiceStatus>(ParameterData);

            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            CheckWCFServiceConfigSection CurrentSeviceList = (CheckWCFServiceConfigSection)cfa.GetSection("CheckWCFServiceList");
            CheckWCFServiceConfigurationElement _new = new CheckWCFServiceConfigurationElement();
            _new.Name = _wss.Name;
            _new.Description = _wss.Description;
            _new.Type = _wss.WCFType;
            _new.URL = _wss.URL;
            CurrentSeviceList.PluginCollection.Add(_new);
            cfa.Save();

            ConfigurationManager.RefreshSection("CheckWCFServiceList");
            string _ret = "TRUE";
            TaskList.RunTaskImmediately("SystemSelfCheck");
            byte[] _data = Encoding.Unicode.GetBytes(_ret);
            return _data;
        }

        private byte[] DoWCFService_Del(byte[] ParameterData)
        {
            string _wss = CommandCommon.GetParamDataObj<string>(ParameterData);

            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            CheckWCFServiceConfigSection CurrentSeviceList = (CheckWCFServiceConfigSection)cfa.GetSection("CheckWCFServiceList");
            CurrentSeviceList.PluginCollection.Remove(_wss);
            cfa.Save();

            ConfigurationManager.RefreshSection("CheckWCFServiceList");
            string _ret = "TRUE";
            TaskList.RunTaskImmediately("SystemSelfCheck");
            byte[] _data = Encoding.Unicode.GetBytes(_ret);
            return _data;
        }
    }

}
