using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Flow
{
   
    [DataContract]
    public class Flow_StateDefine
    {
        [DataMember]
        public string FlowID { get; set; }

        [DataMember]
        public decimal Order { get; set; }

        [DataMember]
        public string ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string DisplayName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Type { get; set; }

        public Flow_StateDefine() { }
        public Flow_StateDefine(string _id, string _name, string _displayName, string _description, string _type, string _flowid, decimal _order)
        {
            this.FlowID = _flowid;
            this.ID = _id;
            this.Name = _name;
            this.DisplayName = _displayName;
            this.Description = _description;
            this.Type = _type;
            this.Order = _order;
        }





    }
}
