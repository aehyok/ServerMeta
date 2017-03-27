using System;
using System.Collections.Generic;
using System.Text;
using SinoSZPluginFramework;

namespace SinoSZJS.CS.BizReport
{
        public class ReportServerPlugin : IServerPlugin
        {
                private IServerApplication application;
                private string pluginName = "ReportServerPlugin";
                private string description = "报表逻辑插件";

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
                        return new BIZ_Report();
                }

            

                #endregion
        }
}
