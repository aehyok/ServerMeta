using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.LogEnity
{
    [DataContract]
    public class SinoSystemLog
    {
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string LogType { get; set; }
        [DataMember]
        public string LogMsg { get; set; }
        [DataMember]
        public DateTime LogTime { get; set; }
    }
}
