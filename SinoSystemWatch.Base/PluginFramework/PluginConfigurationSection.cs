using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SinoSystemWatch.Base.PluginFramework
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
