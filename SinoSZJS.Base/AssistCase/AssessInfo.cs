using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.AssistCase
{
    [DataContract]
    public class AssessInfo
    {
        ///<summary>
        ///商品ID
        /// </summary>
        [DataMember]
        public decimal SPID { get; set; }

        ///<summary>
        ///商品编号
        /// </summary>
        [DataMember]
        public string SPBH { get; set; }

        ///<summary>
        ///商品名称
        /// </summary>
        [DataMember]
        public string SPMC { get; set; }

        ///<summary>
        ///商品数量
        /// </summary>
        [DataMember]
        public decimal SPSL { get; set; }

        ///<summary>
        ///商品单位
        /// </summary>
        [DataMember]
        public string SPDW { get; set; }


        ///<summary>
        ///商品产地
        /// </summary>
        [DataMember]
        public string SPCD { get; set; }

        ///<summary>
        ///商品已缴税款
        /// </summary>
        [DataMember]
        public decimal SPYJSK { get; set; }

        ///<summary>
        ///申报单价
        /// </summary>
        [DataMember]
        public decimal SBDJ { get; set; }

        ///<summary>
        ///实际成交价
        /// </summary>
        [DataMember]
        public decimal SJCJJ { get; set; }

        ///<summary>
        ///申报单价的币制
        /// </summary>
        [DataMember]
        public string SBBZ { get; set; }

        ///<summary>
        ///实际成交价的币制
        /// </summary>
        [DataMember]
        public string SJBZ { get; set; }

        ///<summary>
        ///计核单价
        /// </summary>
        [DataMember]
        public decimal JHDJ { get; set; }

        ///<summary>
        ///计核币制
        /// </summary>
        [DataMember]
        public string JHBZ { get; set; }

        ///<summary>
        ///计税汇率
        /// </summary>
        [DataMember]
        public decimal JSHL { get; set; }

        ///<summary>
        ///税则号
        /// </summary>
        [DataMember]
        public string SZH { get; set; }

        ///<summary>
        ///关税税率
        /// </summary>
        [DataMember]
        public decimal GSSL { get; set; }

        ///<summary>
        ///关税税款
        /// </summary>
        [DataMember]
        public decimal GSSK { get; set; }

        ///<summary>
        ///消费税税率
        /// </summary>
        [DataMember]
        public decimal XFSSL { get; set; }

        ///<summary>
        ///消费税税款
        /// </summary>
        [DataMember]
        public decimal XFSSK { get; set; }

        ///<summary>
        ///反倾销税率
        /// </summary>
        [DataMember]
        public decimal FQXSL { get; set; }

        ///<summary>
        ///反倾销税款
        /// </summary>
        [DataMember]
        public decimal FQXSK { get; set; }

        ///<summary>
        ///增值税率
        /// </summary>
        [DataMember]
        public decimal ZZSL { get; set; }

        ///<summary>
        ///增值税款
        /// </summary>
        [DataMember]
        public decimal ZZSK { get; set; }

        ///<summary>
        ///说明
        /// </summary>
        [DataMember]
        public string SM { get; set; }

        ///<summary>
        ///价格相关
        /// </summary>
        [DataMember]
        public string JGXG { get; set; }

        ///<summary>
        ///价格来源
        /// </summary>
        [DataMember]
        public string JGLY { get; set; }

        ///<summary>
        ///查获/进出口时间
        /// </summary>
        [DataMember]
        public string CHSJ { get; set; }

        ///<summary>
        ///走私方式
        /// </summary>
        [DataMember]
        public string ZSFS { get; set; }

        ///<summary>
        ///查获地点
        /// </summary>
        [DataMember]
        public string CHDD { get; set; }

        /// <summary>
        /// 案件ID
        /// </summary>
        [DataMember]
        public decimal AJID { get; set; }

        /// <summary>
        /// 估价计税单头ID
        /// </summary>
        [DataMember]
        public decimal GJJSID { get; set; }

        public AssessInfo(decimal spid, string spmc, decimal spsl, decimal sbdj, decimal gjjsid,decimal ajid)
        {
            this.SPID = spid;
            this.SPMC = spmc;
            this.SPSL = spsl;
            this.SBDJ = sbdj;
            this.GJJSID = gjjsid;
            this.AJID = ajid;
        }
    }
}