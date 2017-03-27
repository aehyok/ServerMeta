using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSZJS.Base.Document
{
    public class DocItemMX
    {
        /// <summary>
        /// 文书id
        /// </summary>
        public string WSID { set; get; }
        /// <summary>
        /// 文书title
        /// </summary>
        public string DYSX { set; get; }
        /// <summary>
        /// 文书名
        /// </summary>
        public string DocName { set; get; }
        public override string ToString()
        {
            return this.DYSX;
        }
    }
}
