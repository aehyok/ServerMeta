using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSystemWatch.Base.DataBaseCheck
{
    public class DBConnectStatus
    {
        public string ConnectionName { get; set; }
        /// <summary>
        /// 连接结果 0：未知  1：连接成功  2：失败
        /// </summary>
        public int ConnectResult { get; set; }
        public string ResultMessage { get; set; }
    }
}
