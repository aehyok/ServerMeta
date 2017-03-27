using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SinoSystemWatch.Base.TaskCheck
{
    public class CheckTaskConfigurationElement : ConfigurationElement
    {
        public CheckTaskConfigurationElement()
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

        [ConfigurationProperty("ConnectName")]
        public String ConnectName
        {
            get
            {
                return (String)this["ConnectName"];
            }
            set
            {
                this["ConnectName"] = value;
            }
        }

        [ConfigurationProperty("RWID")]
        public String RWID
        {
            get
            {
                return (String)this["RWID"];
            }
            set
            {
                this["RWID"] = value;
            }
        }

    }
}
