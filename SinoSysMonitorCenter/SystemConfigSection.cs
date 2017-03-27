using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace SinoSysMonitorCenter
{
    public class SystemConfigSection :ConfigurationSection
    {
        public SystemConfigSection()
        {
        }

        [ConfigurationProperty("", IsDefaultCollection = true)]
        public SystemConfigurationCollection PluginCollection
        {
            get
            {
                return (SystemConfigurationCollection)base[""];
            }
        }
    }

}
