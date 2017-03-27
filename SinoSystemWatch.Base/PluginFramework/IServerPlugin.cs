using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSystemWatch.Base.PluginFramework
{
    public interface IServerPlugin
    {
        IServerApplication ServerApplication { get; set; }
        String Name { get; set; }
        String Description { get; set; }
        void Load();
        void UnLoad();
        event EventHandler<EventArgs> Loading;
        event EventHandler<EventArgs> ShowErrorMessage;
        object GetServiceObject(string _serviceName);
        byte[] DoCommand(string CommandName,byte[] ParameterData);
    }
}
