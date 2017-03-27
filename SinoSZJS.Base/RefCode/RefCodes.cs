using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSZJS.Base.RefCode
{
    public class RefCodes
    {
        /// <summary>
        /// 单代码
        /// </summary>
        public string Code { set; get; }

        /// <summary>
        /// 单名称
        /// </summary>
        public string Name { set; get; }


        /// <summary>
        /// 单数据
        /// </summary>
        public string Data { set; get; }

        /// <summary>
        /// 多代码
        /// </summary>
        public List<string> Codes { set; get; }


        /// <summary>
        /// 多名称
        /// </summary>
        public List<string> Names { set; get; }

        /// <summary>
        /// 多数据
        /// </summary>
        public List<string> Datas { set; get; }


    }
}
