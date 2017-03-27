using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Document
{
    /// <summary>
    /// 文书列表
    /// </summary>
    [DataContract(IsReference=true)]
    public class WSFLEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public string ID { get; set; }

        /// <summary>
        /// 类型名称
        /// </summary>
        [DataMember]
        public string LXMC { get; set; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        [DataMember]
        public string SX { get; set; }

        /// <summary>
        /// 文书列表
        /// </summary>
        [DataMember]
        public List<WSLXEntity> WSLX { set; get; }

        public WSFLEntity() { }

        public WSFLEntity(string _id, string _lxmc, string _sx)
        {
            this.ID = _id;
            this.LXMC = _lxmc;
            this.SX = _sx;
        }
    }
}
