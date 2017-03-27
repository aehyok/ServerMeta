using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base
{
        /// <summary>
        /// 通用事件参数
        /// </summary>
        public class CommonEventArgs : EventArgs
        {
                private string _msg = "";
                /// <summary>
                /// 事件消息
                /// </summary>
                public string Message
                {
                        get { return _msg; }
                        set { _msg = value; }
                }

                public CommonEventArgs()
                {
                }

                public CommonEventArgs(string _message)
                {
                        _msg = _message;

                }
        }
}
