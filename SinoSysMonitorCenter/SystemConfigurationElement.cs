using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace SinoSysMonitorCenter
{
    public class SystemConfigurationElement: ConfigurationElement
    {
        public SystemConfigurationElement()
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

        [ConfigurationProperty("URL")]
        public String URL
        {
            get
            {
                return (String)this["URL"];
            }
            set
            {
                this["URL"] = value;
            }
        }

        [ConfigurationProperty("Token")]
        public String Token
        {
            get
            {
                return (String)this["Token"];
            }
            set
            {
                this["Token"] = value;
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

        [ConfigurationProperty("DeployID")]
        public String DeployID
        {
            get
            {
                return (String)this["DeployID"];
            }
            set
            {
                this["DeployID"] = value;
            }
        }
    }

}
