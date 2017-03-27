using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSZJS.Base.SinoBestMTS
{
    public interface ISinoBestMTSAdatper
    {
        /// <summary>
        /// 对报文消息的处理接口
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string Excute(string id);
    }
}
