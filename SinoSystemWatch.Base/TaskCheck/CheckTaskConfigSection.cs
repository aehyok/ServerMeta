using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SinoSystemWatch.Base.TaskCheck
{
   public class CheckTaskConfigSection: ConfigurationSection
    {
       public CheckTaskConfigSection()
        {
        }

        [ConfigurationProperty("", IsDefaultCollection = true)]
       public CheckTaskConfigurationCollection PluginCollection
        {
            get
            {
                return (CheckTaskConfigurationCollection)base[""];
            }
        }
    }
}

