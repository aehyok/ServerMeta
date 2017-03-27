using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Document
{
    /// <summary>
    /// 文书列表
    /// </summary>
    [DataContract]
    public class WSLXEntity
    {
        /// <summary>
        /// 文书ID
        /// </summary>
        [DataMember]
        public string ID { get; set; }

        /// <summary>
        /// 文书名称
        /// </summary>
        [DataMember]
        public string WSMC { get; set; }

        /// <summary>
        /// 案件系统文书ID
        /// </summary>        
        [DataMember]
        public string AJWSBH { get; set; }
        
        /// <summary>
        /// 文书所属单位ID
        /// </summary>        
        [DataMember]
        public string DWID { get; set; }
        
        /// <summary>
        /// 文书类型
        /// </summary>
        [DataMember]
        public string WSFLID { get; set; }

        /// <summary>
        /// 文书类型名称
        /// </summary>
        [DataMember]
        public string WSFLMC { get; set; }

        public WSLXEntity() { }

        public WSLXEntity(string _id, string _wsmc, string _ajwsbh, string _dwid, string _wsflid,string _wslxmc)
        {
            this.ID = _id;
            this.WSMC = _wsmc;
            this.AJWSBH = _ajwsbh;
            this.DWID = _dwid;
            this.WSFLID = _wsflid;
            this.WSFLMC = _wslxmc;
        }
    }
}
