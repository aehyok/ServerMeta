using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.ReportEnity
{
    [DataContract]
    public class ReportDefined
    {
        
        /// <summary>
        /// 报表名称
        /// </summary>
        [DataMember]
        public string BBMC { set; get; }
        /// <summary>
        /// 是否行定义
        /// </summary>
        [DataMember]
        public string SFHDY { set; get; }
        /// <summary>
        /// 报表类型
        /// </summary>
        [DataMember]
        public string BBLX { set; get; }

        /// <summary>
        /// 横向、纵向设置
        /// </summary>
        [DataMember]
        public string PDFYMSZ { set; get; }
        /// <summary>
        /// PDF每列宽度
        /// </summary>
        [DataMember]
        public string PDFLK { set; get; }
        public ReportDefined(string _bbmc, string _sfhdy, string _bblx, string _pdfymsz, string _pdflk)
        {

            this.BBMC = _bbmc;
            this.SFHDY = _sfhdy;
            this.BBLX = _bblx;
            this.PDFYMSZ = _pdfymsz;
            this.PDFLK = _pdflk;
        }

    }
}
