using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SinoSystemWatch.Base.Application
{
    public class CheckWCFServiceConfigSection: ConfigurationSection
    {
        public CheckWCFServiceConfigSection()
        {
        }

        [ConfigurationProperty("", IsDefaultCollection = true)]
        public CheckWCFServiceConfigurationCollection PluginCollection
        {
            get
            {
                return (CheckWCFServiceConfigurationCollection)base[""];
            }
        }
    }
}

