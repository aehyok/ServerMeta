using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.ReportEnity
{
    [DataContract]
    public class ReportEntity_TJ
    {
        /// <summary>
        /// 表报定义
        /// </summary>
        [DataMember]
        public ReportDefined _ReportDefined { set; get; }
        /// <summary>
        /// 表头表尾定义
        /// </summary>
        [DataMember]
        public ReportHeader_Footer _ReportHeaderFooter { set; get; }
        /// <summary>
        /// 表体定义
        /// </summary>
        [DataMember]
        public List<ReportBody> _ReportBody { set; get; }
    }
}
