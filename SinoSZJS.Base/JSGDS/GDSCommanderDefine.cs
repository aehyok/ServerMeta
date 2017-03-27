using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.JSGDS
{
    [DataContract]
    public class GDSCommanderDefine
    {
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string CommandName { get; set; }
        [DataMember]
        public string DWDM { get; set; }
        [DataMember]
        public string Descript { get; set; }
        [DataMember]
        public string IcsType { get; set; }
        [DataMember]
        public string CallParamDefine { get; set; }
        [DataMember]
        public string ReturnDefine { get; set; }
        [DataMember]
        public string TokenType { get; set; }
        [DataMember]
        public string IcsConfig { get; set; }
        [DataMember]
        public string State { get; set; }

    }
}
