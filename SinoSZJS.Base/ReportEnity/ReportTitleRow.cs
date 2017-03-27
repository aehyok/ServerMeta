using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.ReportEnity
{
    [DataContract]
    public class ReportTitleRow
    {
        [DataMember]
        public string KPID { set; get; }
        [DataMember]
        public string DisplayTitle { set; get; }
        [DataMember]
        public int RowIndex { set; get; }
        [DataMember]
        public string GroupTitle { set; get; }
        [DataMember]
        public int RowWidth { set; get; }
        [DataMember]
        public string RowMeta { set; get; }
        [DataMember]
        public string DWID { set; get; }
    }
}
