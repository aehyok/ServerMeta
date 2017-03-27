using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.WorkCalendar
{
    [DataContract]
    public class WC_DataInfo
    {
        [DataMember]
        public DateTime GZ_Date { get; set; }
        [DataMember]
        public string Meta { get; set; }
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public int Month { get; set; }
        [DataMember]
        public int Day { get; set; }
        [DataMember]
        public bool IsTJSBR { get; set; }
        [DataMember]
        public bool IsWorkDay { get; set; }
        [DataMember]
        public bool IsFXSBR { get; set; }
    }
}
