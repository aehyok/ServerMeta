using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace SinoSystemWatch.Base.PluginFramework
{
    public interface IServerApplication : IServiceContainer
    {      
        bool WriteMessage(string _message,EventLogEntryType LogType);     
        bool AddTask(string _taskName, ITaskPlugin _taskPlugin);
        bool RemoveTask(string _taskName);
        bool AddCommandExecuter(string _commandName, ICommandPlugin _commandPlugin);
    }
}
