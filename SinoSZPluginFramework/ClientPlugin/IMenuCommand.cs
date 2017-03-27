using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZPluginFramework
{
        public interface IMenuCommand
        {
                bool DoCommand(string _menuid,string _commandName, string _commandTitle,object _commandParam);
        }
}
