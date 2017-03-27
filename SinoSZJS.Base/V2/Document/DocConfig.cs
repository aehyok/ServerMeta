using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Document
{
    /// <summary>
    /// 文书配置表信息
    /// </summary>
    [DataContract]
    public class DocConfig
    {
        /// <summary>
        /// GUID
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// 文书类型Id
        /// </summary>
        [DataMember]
        public string DocTypeId { get; set; }

        [DataMember]
        public string DocTitle { get; set; }

        /// <summary>
        /// 单位Id
        /// </summary>
        [DataMember]
        public string DWID { get; set; }

        /// <summary>
        /// 流程Id
        /// </summary>
        [DataMember]
        public string FlowId { get; set; }

        /// <summary>
        /// 签章字号
        /// </summary>
        [DataMember]
        public string SignPath { get; set; }

        /// <summary>
        /// 文书字号开头文字设置
        /// </summary>
        [DataMember]
        public string DocNoKey { get; set; }

        /// <summary>
        /// 签章方式 0不签章，1直接签章，2审批签章，3拟稿转换签章
        /// </summary>
        [DataMember]
        public string SignWay { get; set; }
    }
}
