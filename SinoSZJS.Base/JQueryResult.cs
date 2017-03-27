using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSZJS.Base
{
    /// <summary>
    /// 异步调用出错时，返回的Json对象
    /// </summary>
    public class JQueryResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess{set;get;}
        /// <summary>
        /// 跳转到的url 
        /// </summary>
        public string RedirectTo { set; get; }
    }
}
