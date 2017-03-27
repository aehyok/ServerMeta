using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.Design;

namespace SinoSZPluginFramework
{
        public interface IServerApplication : IServiceContainer
        {
                bool WriteUserLog(object UserObj, string _log);
                bool WriteMessage(string _message);
                bool AddRemotingService(string _serviceName,IServerPlugin _servicePlugin);
                bool AddTask(string _taskName,ITaskPlugin _taskPlugin);
        }
}
