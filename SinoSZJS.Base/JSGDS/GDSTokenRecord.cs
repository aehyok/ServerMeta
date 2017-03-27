using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.JSGDS
{
    [DataContract]
    public class GDSTokenRecord
    {
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string CommandName { get; set; }
        [DataMember]
        public string RemoteIP { get; set; }
        [DataMember]
        public string TokenData { get; set; }
    }
}
