using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSystemWatch.Base.Define
{
    [DataContract(IsReference = false)]
    public class WatchNodeDBState
    {
        /// <summary>
        /// 24小时内未生成报告信息 0有生成 1：未生成
        /// </summary>
        /// 
        [DataMember]
        public int NoReport { get; set; }

        /// <summary>
        /// 重点检查的错误数 0：无错误
        /// </summary>
        /// 
        [DataMember]
        public int ReportError { get; set; }

        /// <summary>
        /// 数据结构错误
        /// </summary>
        /// 
        [DataMember]
        public int DbStructureError { get; set; }

        /// <summary>
        /// 数据库运行状态错误数
        /// </summary>
        /// 
        [DataMember]
        public int DbStatusError { get; set; }

        /// <summary>
        /// 表空间使用情况
        /// </summary>
        /// 
        [DataMember]
        public int TableSpaceUsage { get; set; }
    }
}
