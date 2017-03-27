using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Report
{
    /// <summary>
    /// 取表名称定义
    /// </summary>
    [DataContract(IsReference = true)]
    public class MD_ReportName
    {
        /// <summary>
        /// 报表名称
        /// </summary>
        [DataMember]
        public string ReportName { get; set; }

        /// <summary>
        /// 报表显示名称
        /// </summary>
        [DataMember]
        public string ReportTitle { get; set; }

        /// <summary>
        /// 报表类型
        /// </summary>
        [DataMember]
        public SinoSZReportType ReportType { get; set; }

        public MD_ReportName() { }
        public MD_ReportName(string _reportName, string _title, SinoSZReportType _type)
        {
            this.ReportTitle = _title;
            this.ReportName = _reportName;
            this.ReportType = _type;
        }

        public override string ToString()
        {
            return ReportTitle;
        }


    }
}
