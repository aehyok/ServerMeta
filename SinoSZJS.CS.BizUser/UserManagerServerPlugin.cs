using System;
using System.Collections.Generic;
using System.Text;
using SinoSZPluginFramework;

namespace SinoSZJS.CS.BizUser
{
        public class UserManagerServerPlugin : IServerPlugin
        {
                private IServerApplication application;
                private string pluginName = "UserManagerServerPlugin";
                private string description = "用户及授权管理逻辑插件";
                private static BIZ_UserManager bizUserManager = new BIZ_UserManager();
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
                                return this.pluginName;
                        }
                        set
                        {
                                this.pluginName = value;
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
                        application.WriteMessage(string.Format("{0}加载成功!", description));
                        application.AddRemotingService(pluginName, this);
                }

                public void UnLoad()
                {
                        throw new Exception("The method or operation is not implemented.");
                }

                public event EventHandler<EventArgs> Loading;

                public event EventHandler<EventArgs> ShowErrorMessage;

                public object GetServiceObject(string _serviceName)
                {
                        return bizUserManager;
                }




                #endregion
        }
}
