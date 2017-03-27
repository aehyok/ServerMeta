using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SinoSystemWatch.Base.WinServiceCheck
{
    public class CheckWinServiceConfigurationElement : ConfigurationElement
    {
        public CheckWinServiceConfigurationElement()
        {
        }

        [ConfigurationProperty("Name")]
        public String Name
        {
            get
            {
                return (String)this["Name"];
            }
            set
            {
                this["Name"] = value;
            }
        }

        [ConfigurationProperty("Description")]
        public String Description
        {
            get
            {
                return (String)this["Description"];
            }
            set
            {
                this["Description"] = value;
            }
        }
    }
}
