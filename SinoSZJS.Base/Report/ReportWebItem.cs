using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSZJS.Base.Report
{
    [Serializable]
    public class ReportWebItem
    {


        public ReportWebItem() { }

        public ReportWebItem(string _reportName, string _dwdm, string _dwmc,
                string _nf, string _yf, string _jc)
        {
            ReportName = _reportName;
            ReportDWDM = _dwdm;
            ReportDWMC = _dwmc;
            RYear = _nf;
            RMonth = _yf;
            ReportJC = _jc;

        }
        /// <summary>
        /// 统计单位代码
        /// </summary>
        public string ReportDWDM { get; set; }
        /// <summary>
        /// 报表名称
        /// </summary>
        public string ReportName { get; set; }
        /// <summary>
        /// 统计单位名称
        /// </summary>
        public string ReportDWMC { get; set; }
        /// <summary>
        /// 统计年份
        /// </summary>
        public string RYear { get; set; }
        /// <summary>
        /// 统计月份
        /// </summary>
        public string RMonth { get; set; }
        /// <summary>
        /// 报表简称
        /// </summary>
        public string ReportJC { get; set; }

    }
}
