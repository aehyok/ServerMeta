using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.AssistCase
{
    [DataContract]
    public class GoodsInfo
    {
        /// <summary>
        /// 物品ID
        /// </summary>
        [DataMember]
        public string ID { get; set; }

        /// <summary>
        /// 物品编号
        /// </summary>
        [DataMember]
        public string WPID { get; set; }
        /// <summary>
        /// 物品名称
        /// </summary>
        [DataMember]
        public string WPMC{ get; set; }

        /// <summary>
        /// 物品数量
        /// </summary>
        [DataMember]
        public decimal WPSL{ get; set; }

        /// <summary>
        /// 物品单价
        /// </summary>
        [DataMember]
        public decimal WPCGDJ{get;set;}

        /// <summary>
        /// 物品仓单号
        /// </summary>
        [DataMember]
        public string WPCDH{get;set;}

        /// <summary>
        /// 物品计量单位
        /// </summary>
        [DataMember]
        public string JLDWDM { get; set; }

        [DataMember]
        public decimal JDID { get; set; }

        [DataMember]
        public decimal WPCount { get; set; }

        [DataMember]
        public decimal AJID { get; set; }

        public GoodsInfo(string wpid, string wpmc, decimal wpsl,decimal wpcgdj,decimal jdid,string wpcdh,string jldwdm,decimal ajid)
        {
            this.WPID = wpid;
            this.WPMC = wpmc;
            this.WPSL = wpsl;
            this.WPCGDJ = wpcgdj;
            this.JDID = jdid;
            this.WPCDH = wpcdh;
            this.JLDWDM = jldwdm;
            this.AJID = ajid;
        }
        
    }
}
