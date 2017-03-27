using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.ReportEnity
{
    [DataContract]
    public class ReportCell
    {
        [DataMember]
        public string KPID { set; get; }
        [DataMember]
        public int RowIndex { set; get; }
        [DataMember]
        public int ColIndex { set; get; }
        [DataMember]
        public string DataValue{ set; get; }
        [DataMember]
        public string DataZBID { set; get; }
        [DataMember]
        public string LiftValue { set; get; }
        [DataMember]
        public string LiftZBID { set; get; }
        [DataMember]
        public string DetailZBID { set; get; }
        [DataMember]
        public string CellMeta { set; get; }
    }
}
