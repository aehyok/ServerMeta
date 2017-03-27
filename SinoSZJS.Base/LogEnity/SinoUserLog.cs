using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.LogEnity
{
    [DataContract]
    public class SinoUserLog
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
        public string LogType { get; set; }
        [DataMember]
        public string LogMsg { get; set; }
        [DataMember]
        public string FromIP { get; set; }
        [DataMember]
        public string FromHost { get; set; }
        [DataMember]
        public string PostID { set; get; }
        [DataMember]
        public string PostName { set; get; }
    }
}
