using System;
using System.Collections.Generic;
using System.Text;
using SinoSZPluginFramework;

namespace SinoSZServerBase
{
    public class TaskLib
    {
        static Dictionary<string, ITaskPlugin> _taskLib = new Dictionary<string, ITaskPlugin>();

        public static void AddTask(string _taskName, ITaskPlugin _iplugin)
        {
            if (!_taskLib.ContainsKey(_taskName))
            {
                _taskLib.Add(_taskName, _iplugin);
            }
            else
            {
                _taskLib[_taskName] = _iplugin;
            }
        }

        public static ITaskPlugin GetService(string _taskName)
        {
            if (!_taskLib.ContainsKey(_taskName))
            {
                return null;
            }
            else
            {
                return _taskLib[_taskName];
            }
        }
    }
}
