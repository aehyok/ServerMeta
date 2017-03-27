using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Report.DataCheck
{
    [DataContract]
    public class ReportHisDataRow
    {
        [DataMember]
        public string FieldsName { get; set; }
        [DataMember]
        public string DataValue { get; set; }
        [DataMember]
        public string OldValue { get; set; }
        [DataMember]
        public string RKValue { get; set; }
        [DataMember]
        public string IsShow { get; set; }
        [DataMember]
        public bool State { get; set; }
        [DataMember]
        public bool IsTitle { get; set; }
    }
}
