using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.AssistCase
{
    public class ExTaxInfo
    {
        /// <summary>
        /// 估价计税ID
        /// </summary>
        [DataMember]
        public string ID { get; set; }

        /// <summary>
        /// 案件ID
        /// </summary>
        [DataMember]
        public string AJID { get; set; }

        /// <summary>
        /// 送核单位代码
        /// </summary>
        [DataMember]
        public string SHDWDM { get; set; }

         /// <summary>
         /// 送核经办人
         /// </summary>
        [DataMember]
        public string SHJBR { get; set; }

        /// <summary>
        /// 送核时间
        /// </summary>
        [DataMember]
        public string SHSJ { get; set; }

        /// <summary>
        /// 计核单位编号
        /// </summary>
        [DataMember]
        public string JHJBR { get; set; }

        /// <summary>
        /// 计核部门
        /// </summary>
        [DataMember]
        public string JHBM { get; set; }

        /// <summary>
        /// 计核时间
        /// </summary>
        [DataMember]
        public string JHSJ { get; set; }


        [DataMember]
        public decimal State { get; set; }

        public ExTaxInfo(string ajid, string shbm, string jbr, string shsj)
        {
            this.AJID = ajid;
            this.SHDWDM = shbm;
            this.SHJBR = jbr;
            this.SHSJ = shsj;
        }

        public ExTaxInfo(string gjid, string jhdw, string jhr, string date,decimal state)
        {
            this.ID = gjid;
            this.JHBM = jhdw;
            this.JHJBR = jhr;
            this.JHSJ = date;
            this.State = state;
        }

        public ExTaxInfo() { }
    }
}
