using System;
using System.Collections.Generic;
using System.Text;
using SinoSZPluginFramework;

namespace SinoSZServerBase
{
        public class ServiceLib
        {
                static Dictionary<string, IServerPlugin> _serviceLib = new Dictionary<string, IServerPlugin>();

                public static void AddService(string _serviceName, IServerPlugin _iplugin)
                {
                        if (!_serviceLib.ContainsKey(_serviceName))
                        {
                                _serviceLib.Add(_serviceName, _iplugin);
                        }
                }

                public static IServerPlugin GetService(string _serviceName)
                {
                        if (!_serviceLib.ContainsKey(_serviceName))
                        {
                                return null;
                        }
                        else
                        {
                                return _serviceLib[_serviceName];
                        }
                }
        }
}
