using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SinoSystemWatch.Base.Application
{
    public class CheckWCFServiceConfigurationElement : ConfigurationElement
    {
        public CheckWCFServiceConfigurationElement()
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

        [ConfigurationProperty("Type")]
        public String Type
        {
            get
            {
                return (String)this["Type"];
            }
            set
            {
                this["Type"] = value;
            }
        }

    }
}
