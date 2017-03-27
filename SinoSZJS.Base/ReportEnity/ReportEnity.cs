using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.ReportEnity
{
    [DataContract]
    public class ReportEnity
    {
        [DataMember]
        public string KPID { set; get; }
        [DataMember]
        /// <summary>
        /// 取表显示名称
        /// </summary>
        public string ReportTitle { get; set; }
        [DataMember]
        /// <summary>
        /// 报表元数据
        /// </summary>
        public string ReportMeta { set; get; }
        [DataMember]
        public List<ReportTitleColumn> TitleColumns { set; get; }
        [DataMember]
        public List<ReportTitleRow> TitleRows { set; get; }
        [DataMember]
        public List<ReportCell> ReportCells { set; get; }
    }
}
