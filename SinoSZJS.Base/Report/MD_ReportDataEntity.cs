using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Report
{
    [DataContract]
    public class MD_ReportDataEntity
    {
        /// <summary>
        ///  报表名称
        /// </summary>
        [DataMember]
        public string BBMC { get; set; }
        /// <summary>
        /// 报表生成数据
        /// </summary>
        [DataMember]
        public string ReportData { get; set; }

        /// <summary>
        /// 统计方式
        /// </summary>
        [DataMember]
        public string DataType { get; set; }

    }
}
