using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using SinoSZJS.Base.MetaData.Define;

namespace SinoSZJS.Base.MetaData.Define
{
    [DataContract]
    public class MD_QueryModelGroupItem
    {
        /// <summary>
        /// 显示顺序
        /// </summary>
        [DataMember]
        public int ItemDisplayOrder { get; set; }
        /// <summary>
        /// 对应的查询主题
        /// </summary>
        [DataMember]
        public string QueryModelGroupID { get; set; }

        /// <summary>
        /// 节点编号
        /// </summary>
        [DataMember]
        public string ItemDWDM { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public string ID { get; set; }

        [DataMember]
        public MD_QueryModel QueryModel { get; set; }
    }
}
