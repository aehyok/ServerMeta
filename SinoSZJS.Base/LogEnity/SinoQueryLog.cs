using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.LogEnity
{
    [DataContract]
    public class SinoQueryLog
    {

        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string UserID { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public DateTime LogTime { get; set; }
        [DataMember]
        public string QueryContent { get; set; }
        [DataMember]
        public decimal UsedTime { get; set; }
        [DataMember]
        public string RetCount { get; set; }

    }
}
