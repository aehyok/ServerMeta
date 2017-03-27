using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.ReportEnity
{
    [DataContract]
    public class ReportTitleColumn
    {
        [DataMember]
        public string KPID { set; get; }
        [DataMember]
        public string DisplayTitle { set; get; }
        [DataMember]
        public int ColIndex { set; get; }
        [DataMember]
        public string GroupTitle { set; get; }
        [DataMember]
        public int ColWidth { set; get; }
        [DataMember]
        public string FieldName { set; get; }
        [DataMember]
        public string ColDataType { set; get; }
        [DataMember]
        public string ColMeta { set; get; }
        [DataMember]
        public string DisplayFormat { set; get; }
        [DataMember]
        public string TextAlign { set; get; }
        [DataMember]
        public string CanAlter { set; get; }
    }
}
