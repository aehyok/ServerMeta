using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZPluginFramework.ServerPlugin
{
        public interface IServerPluginService
        {
                IServerApplication Application { get;set;}
                void AddPlugin(String pluginName, String pluginType, String Assembly, String pluginDescription);
                void RemovePlugin(String pluginName);
                String[] GetAllPluginNames();
                Boolean Contains(String pluginName);
                Boolean LoadPlugin(String pluginName);
                Boolean UnLoadPlugin(String pluginName);
                IServerPlugin GetPluginInstance(String pluginName);
                void LoadAllPlugin();
        }
}
