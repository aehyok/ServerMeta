using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.AssistCase
{
    [DataContract]
    public class Case_WPCQLIST
    {
        [DataMember]
        public decimal ID { get; set; }

        /// <summary>
        /// 案件呈请审批表ID
        /// </summary>
        [DataMember]
        public decimal AJCQSPID { get; set; }

        /// <summary>
        /// 案件标识
        /// </summary>
        [DataMember]
        public decimal AJID { get; set; }

        /// <summary>
        /// 物品ID
        /// </summary>
        [DataMember]
        public decimal WPID { get; set; }

        /// <summary>
        ///物品单元ID 
        /// </summary>
        [DataMember]
        public decimal WPUID { get; set; }

        /// <summary>
        /// 呈请审批数量
        /// </summary>
        [DataMember]
        public decimal SL_CQSP { get; set; }

        /// <summary>
        /// 当前数量（剩余数量）
        /// </summary>
        [DataMember]
        public decimal SL_CRUUENT { get; set; }

        /// <summary>
        /// 处理事项名称
        /// </summary>
        [DataMember]
        public string CLSXMC { get; set; }

        /// <summary>
        /// 处理事项编号
        /// </summary>
        [DataMember]
        public string CLSXBH { get; set; }

    }
}
