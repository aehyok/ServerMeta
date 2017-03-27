using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Flow
{
    
    [DataContract]
    public class Flow_BaseDefine
    {
        [DataMember]
        public string RootDWID { get; set; }

        [DataMember]
        public string ID { get; set; }

        [DataMember]
        public string FlowName { get; set; }

        [DataMember]
        public string Description { get; set; }

        public Flow_BaseDefine() { }

        public Flow_BaseDefine(string _id, string _name, string _description, string _rootdwid)
        {
            this.ID = _id;
            this.FlowName = _name;
            this.Description = _description;
            this.RootDWID = _rootdwid;
        }


    }
}
