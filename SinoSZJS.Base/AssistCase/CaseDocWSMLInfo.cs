using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.AssistCase
{
    [DataContract]
    public class CaseDocWSMLInfo
    {
        /// <summary>
        /// 目录Id
        /// </summary>
        [DataMember]
        public decimal MLID { get; set; }
        /// <summary>
        /// 案件ID
        /// </summary>
        [DataMember]
        public decimal AJID { get; set; }
        /// <summary>
        /// 文书名称
        /// </summary>
        [DataMember]
        public string WSBHMC { get; set; }
        /// <summary>
        /// 生成时间
        /// </summary>
        [DataMember]
        public DateTime SCSJ { get; set; }
        /// <summary>
        /// 文书序号
        /// </summary>
        [DataMember]
        public decimal WSXH { get; set; }
        /// <summary>
        /// 文书页数
        /// </summary>
        [DataMember]
        public string WSYS { get; set; }
        /// <summary>
        /// 文书页号
        /// </summary>
        [DataMember]
        public string WSYH { get; set; }

        /// <summary>
        /// 文书分类
        /// </summary>
        [DataMember]
        public string WSFL { get; set; }

        /// <summary>
        /// 文书字号
        /// </summary>
        [DataMember]
        public string WSZH { get; set; }

        /// <summary>
        /// 文书ID
        /// </summary>
        [DataMember]
        public decimal WSID { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        [DataMember]
        public string ANNEX { get; set; }

        public CaseDocWSMLInfo()
        { 
        
        }

        public CaseDocWSMLInfo(decimal mlid, decimal ajid, string wsbhmc, DateTime scsj, decimal wsxh, string wsys, string wsyh,string wsfl,string wszh,decimal wsid,string annex)
        {
            this.MLID = mlid;
            this.AJID = ajid;
            this.WSBHMC = wsbhmc;
            this.SCSJ = scsj;
            this.WSXH = wsxh;
            this.WSYS = wsys;
            this.WSYH = wsyh;
            this.WSFL = wsfl;
            this.WSZH = wszh;
            this.WSID = wsid;
            this.ANNEX = annex;
        }

    }
}
