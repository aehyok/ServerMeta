using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSZJS.Base.Authorize
{
    public interface ISinoCurrent
    {
        /// <summary>
        /// 当前登录用户名
        /// </summary>
        string CurrentLogonUserName { get; }
        /// <summary>
        /// 当前用户
        /// </summary>
        SinoUserBaseInfo CurrentUser { get; }
        /// <summary>
        /// 取当前用户操作岗位
        /// </summary>
        SinoPost CurrentPost { get; }
        /// <summary>
        /// 是否已经登录验证
        /// </summary>
        bool IsAuthenticated { get; }
        /// <summary>
        /// 用户标示
        /// </summary>
        string SessionID { get; }
    }
}
