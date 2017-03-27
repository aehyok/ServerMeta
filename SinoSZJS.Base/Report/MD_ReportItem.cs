using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Report
{
    /// <summary>
    /// 报表项定义
    /// </summary>
    [DataContract(IsReference=true)]
    public class MD_ReportItem
    {

        public MD_ReportItem() { }
        public MD_ReportItem(DateTime _startDate, DateTime _endDate, MD_ReportName _reportName, string _dwid, string _dwname, bool _audited)
        {
            StartDate = _startDate;
            EndDate = _endDate;
            ReportName = _reportName;
            ReportDWID = _dwid;
            ReportDWName = _dwname;
            Audited = _audited;
            ReportTitle = _reportName.ReportTitle;
        }

        /// <summary>
        /// 取表显示名称
        /// </summary>
        [DataMember]
        public string ReportTitle { get; set; }

        /// <summary>
        /// 是否已审核
        /// </summary>
        [DataMember]
        public bool Audited { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        [DataMember]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        [DataMember]
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 报表名称
        /// </summary>
        [DataMember]
        public MD_ReportName ReportName { get; set; }
        /// <summary>
        /// 报表统计单位ID
        /// </summary>
        [DataMember]
        public string ReportDWID { get; set; }

        /// <summary>
        /// 报表统计单位名称
        /// </summary>
        [DataMember]
        public string ReportDWName { get; set; }

    }
}
