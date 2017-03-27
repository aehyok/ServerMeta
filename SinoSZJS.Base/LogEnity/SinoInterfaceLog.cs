using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.LogEnity
{
    [DataContract]
    public class SinoInterfaceLog
    {
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string TaskID { get; set; }
        [DataMember]
        public string TaskName { get; set; }
        [DataMember]
        public DateTime RunTime { get; set; }
        [DataMember]
        public string RunFlag { get; set; }
        [DataMember]
        public string ResultDescription { get; set; }
    }
}
