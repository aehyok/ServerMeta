using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZPluginFramework
{
    public interface IPluginService
    {
        IApplication Application { get;set;}
        void AddPlugin(String pluginName, String pluginType, String Assembly, String pluginDescription);
        void RemovePlugin(String pluginName);
        String[] GetAllPluginNames();
        Boolean Contains(String pluginName);
        Boolean LoadPlugin(String pluginName);
        Boolean UnLoadPlugin(String pluginName);
        IPlugin GetPluginInstance(String pluginName);
        void LoadAllPlugin();
    }
}
