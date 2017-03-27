using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Report
{

    /// <summary>
    /// 报表类型
    /// </summary>
    [DataContract]
    public enum SinoSZReportType
    {
        [EnumMember]
        None = 0,
        /// <summary>
        /// 采用ReportingService类型的报表
        /// </summary>
        [EnumMember]
        ReportingService = 1,
        /// <summary>
        /// 采用中科富星自定义格式报表
        /// </summary>
        [EnumMember]
        SinoSZDefineReport = 2,
        [EnumMember]
        All = 3
    }
}
