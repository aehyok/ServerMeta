using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.PluginFramework;
using SinoSysWatchService.DataBase.SelfCheck;
using System.Diagnostics;
using SinoSystemWatch.Base.DataBaseCheck;
using SinoSystemWatch.Base.Common;
using System.Configuration;
using System.Dynamic;

namespace SinoSysWatchService.DataBase
{
    public class WatchDataBaseServerPlugin : IServerPlugin
    {
        private IServerApplication application;
        private string pluginName = "WatchDataBaseServerPlugin";
        private string description = "数据库运行监控插件";


        public WatchDataBaseServerPlugin()
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
            ITaskPlugin _t1 = new TaskPlugin_DataBaseSelfCheck();
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
                case "DBConn_Del":
                    return DoDBConn_Del(ParameterData);
                case "DBConn_Add":
                    return DoDBConn_Add(ParameterData);
                default:
                    return null;

            }
        }

        private byte[] DoDBConn_Add(byte[] ParameterData)
        {
            dynamic _dbs = CommandCommon.GetParamDataObj<ExpandoObject>(ParameterData);
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConnectionStringsSection connSetting = (ConnectionStringsSection)cfa.ConnectionStrings;
            ConnectionStringSettings _st = new ConnectionStringSettings();
            _st.ConnectionString = _dbs.ConnectionString;
            _st.ProviderName = _dbs.ConnectionType;
            _st.Name = _dbs.ConnectionName;
            connSetting.ConnectionStrings.Add(_st);
            cfa.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
            string _ret = "TRUE";
            byte[] _data = Encoding.Unicode.GetBytes(_ret);
            return _data;
        }

        private byte[] DoDBConn_Del(byte[] ParameterData)
        {
            string _dbs = CommandCommon.GetParamDataObj<string>(ParameterData);
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConnectionStringsSection connSetting = (ConnectionStringsSection)cfa.ConnectionStrings;
            connSetting.ConnectionStrings.Remove(_dbs);
            cfa.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
            string _ret = "TRUE";
            byte[] _data = Encoding.Unicode.GetBytes(_ret);
            return _data;
        }
    }
}
