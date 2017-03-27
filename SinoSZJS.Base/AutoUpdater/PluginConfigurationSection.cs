using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace SinoSZPluginFramework
{
    public class PluginConfigurationSection : ConfigurationSection
    {
        public PluginConfigurationSection()
        {
        }

        [ConfigurationProperty("", IsDefaultCollection = true)]
        public PluginConfigurationCollection PluginCollection
        {
            get
            {
                return (PluginConfigurationCollection)base[""];
            }
        }
    }
}
