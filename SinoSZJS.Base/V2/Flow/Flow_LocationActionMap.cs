using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Flow
{
    /// <summary>
    /// 状态单位动作配置
    /// </summary>
    [DataContract]
    public class Flow_LocationActionMap
    {
        /// <summary>
        /// GUID
        /// </summary>
        [DataMember]
        public string ID { get; set; }

        /// <summary>
        /// 动作名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 是否拥有
        /// </summary>
        [DataMember]
        public bool IsHave { get; set; }
    }
}
