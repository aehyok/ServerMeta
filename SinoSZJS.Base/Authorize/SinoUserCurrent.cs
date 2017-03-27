using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSZJS.Base.Authorize
{
    public class SinoUserCurrent
    {
        public static ISinoCurrent SinoCurrent { get; set; }
        public static string CurrentLogonUserName
        {
            get
            {
                if (SinoCurrent == null) throw new Exception("未注册ISinoCurrent接口");
                return SinoCurrent.CurrentLogonUserName;
            }
        }
        public static SinoUserBaseInfo CurrentUser
        {
            get
            {
                if (SinoCurrent == null) throw new Exception("未注册ISinoCurrent接口");
                return SinoCurrent.CurrentUser;
            }
        }

        public static bool IsAuthenticated
        {
            get
            {
                if (SinoCurrent == null) throw new Exception("未注册ISinoCurrent接口");
                return SinoCurrent.IsAuthenticated;
            }
        }

        public static string SessionID
        {
            get
            {
                if (SinoCurrent == null) throw new Exception("未注册ISinoCurrent接口");
                return SinoCurrent.SessionID;
            }
        }

        public static SinoPost CurrentPost
        {
            get
            {
                if (SinoCurrent == null) throw new Exception("未注册ISinoCurrent接口");
                return SinoCurrent.CurrentPost;
            }
        }
    }
}
