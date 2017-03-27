using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SinoSystemWatch.Base.Application
{
    public class CheckSystemLogConfigSection: ConfigurationSection
    {
        public CheckSystemLogConfigSection()
        {
        }

        [ConfigurationProperty("", IsDefaultCollection = true)]
        public CheckSystemLogConfigurationCollection PluginCollection
        {
            get
            {
                return (CheckSystemLogConfigurationCollection)base[""];
            }
        }
    }
}
