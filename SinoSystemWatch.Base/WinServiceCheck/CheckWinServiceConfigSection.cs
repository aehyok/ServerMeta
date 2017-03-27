using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SinoSystemWatch.Base.WinServiceCheck
{
    public class CheckWinServiceConfigSection : ConfigurationSection
    {
        public CheckWinServiceConfigSection()
        {
        }

        [ConfigurationProperty("", IsDefaultCollection = true)]
        public CheckWinServiceConfigurationCollection PluginCollection
        {
            get
            {
                return (CheckWinServiceConfigurationCollection)base[""];
            }
        }
    }
}
