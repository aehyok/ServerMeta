using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.ReportEnity
{
    [DataContract]
    public class ReportHeader_Footer
    {
        
        /// <summary>
        /// 报表名称
        /// </summary>
        [DataMember]
        public string BBMC { set; get; }
        /// <summary>
        /// 表头定义
        /// </summary>
        [DataMember]
        public string BTDY { set; get; }
        /// <summary>
        /// 表尾定义
        /// </summary>
        [DataMember]
        public string BWDY { set; get; }

        /// <summary>
        /// PDF表头定义
        /// </summary>
        [DataMember]
        public string PDFBTDY { set; get; }
        /// <summary>
        /// PDF表尾定义
        /// </summary>
        [DataMember]
        public string PDFBWDY { set; get; }

        public ReportHeader_Footer(string _bbmc, string _btdy, string _bwdy,string _pdfbtdy,string _pdfbwdy)
        {
            this.BBMC = _bbmc;
            this.BTDY = _btdy;
            this.BWDY = _bwdy;
            this.PDFBTDY = _pdfbtdy;
            this.PDFBWDY = _pdfbwdy;
        }
    }
}
