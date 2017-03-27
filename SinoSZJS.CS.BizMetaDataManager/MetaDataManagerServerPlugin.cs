using System;
using System.Collections.Generic;
using System.Text;
using SinoSZPluginFramework;

namespace SinoSZJS.CS.BizMetaDataManager
{
        public class MetaDataManagerServerPlugin : IServerPlugin
        {
                private IServerApplication application;
                private string pluginName = "MetaDataManagerServerPlugin";
                private string description="元数据管理业务逻辑插件";
              

                public MetaDataManagerServerPlugin()
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
                        BIZ_MetaDataManager bizMetaDataManager = new BIZ_MetaDataManager();                       
                        return bizMetaDataManager;
                }

          



                #endregion
        }
}
