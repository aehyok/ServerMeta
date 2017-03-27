using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.ReportEnity
{
    [DataContract]
    public class ReportBody
    {
     
        /// <summary>
        /// 报表名称
        /// </summary>
        [DataMember]
        public string BBMC { set; get; }
        /// <summary>
        /// 表体行序
        /// </summary>
        [DataMember]
        public decimal HX { set; get; }
        /// <summary>
        /// 行内容
        /// </summary>
        [DataMember]
        public string HNR { set; get; }
        /// <summary>
        /// 行类型标示
        /// </summary>
        [DataMember]
        public string HLXBS { set; get; }
        /// <summary>
        /// 行标示分组
        /// </summary>
        [DataMember]
        public string HBSFZ { set; get; }
        /// <summary>
        /// PDF行内容
        /// </summary>
        [DataMember]
        public string PDFHNR { set; get; }
        public ReportBody(string _bbmc, decimal _hx,string _hnr,string _hlxbs, string _hbsfz,string _pdfhnr)
        {
            this.BBMC = _bbmc;
            this.HX = _hx;
            this.HNR = _hnr;
            this.HLXBS = _hlxbs;
            this.HBSFZ = _hbsfz;
            this.PDFHNR = _pdfhnr;
        }
    }
}
