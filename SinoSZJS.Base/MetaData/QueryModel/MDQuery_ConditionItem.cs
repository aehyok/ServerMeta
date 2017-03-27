using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MetaData.QueryModel
{
    [Serializable]
    [DataContract]
    public class   MDQuery_ConditionItem
    {
        /// <summary>
        /// 是否区分大小写
        /// </summary>
        [DataMember]
        public bool CaseSensitive { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        [DataMember]
        public string ColumnIndex { get; set; }
        /// <summary>
        /// 字段定义
        /// </summary>
        [DataMember]
        public MDQuery_TableColumn Column { get; set; }
        /// <summary>
        /// 操作符
        /// </summary>
        [DataMember]
        public string Operator { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        [DataMember]
        public List<string> Values { get; set; }

    }
}
