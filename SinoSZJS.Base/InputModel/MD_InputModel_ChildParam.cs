using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.InputModel
{
    
    [DataContract]
    public class MD_InputModel_ChildParam
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string DataType { get; set; }
        [DataMember]
        public string Value { get; set; }

        public MD_InputModel_ChildParam() { }
        public MD_InputModel_ChildParam(string _name, string _type, string _value)
        {
            Name = _name;
            DataType = _type;
            Value = _value;
        }
    }
}
