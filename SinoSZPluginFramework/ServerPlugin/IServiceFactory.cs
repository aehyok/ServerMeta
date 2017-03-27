using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZPluginFramework.ServerPlugin
{
        public interface IServiceFactory
        {
                object GetInterFace(string _serviceName);                
        }
}
