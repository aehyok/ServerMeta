using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SinoSZJS.Base.Authorize;
using SinoSZJS.CS.BizAuthorize;
using SinoSZJS.Base.SystemLog;
using SinoSZJS.Base.WCF.Service;
using System.Net;
using SinoSZJS.DataAccess.Sql;

namespace SinoSZJS.WCF.Lib
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“AuthorizeService”。
    public class AuthorizeService : IAuthorizeService
    {
        SinoUser _su;
        public SinoUser LoginSys(string SystemID, string UserName, string Password,string CheckType)
        {
            try
            {
                OraAuthorizeFactroy _of = new OraAuthorizeFactroy();
                _su = _of.LoginSys(SystemID, UserName, Password,CheckType);
                //LogWriter(decimal.Parse(_su.UserID), "系统登录(执法办案平台CS客户端)", string.Format("用户{0}登录执法办案平台CS客户端成功!", UserName),
                //    1, _su.IPAddress, _su.HostName, SystemID);
                LogWriter.WriteSystemLog("登录成功！", "Info");
                return _su;
            }
            catch (Exception ex)
            {
                string _ipaddr = WCFClientInfo.IPAddr;
                string _hostName = "";
                try
                {
                    _hostName = Dns.GetHostEntry(_ipaddr).HostName;
                }
                catch
                {
                    _hostName = _ipaddr;
                }
                //SystemLogWriter.WriteUserLog(-1, "系统登录(执法办案平台CS客户端)", string.Format("用户{0}登录执法办案平台CS客户端失败!", UserName),
                //    2, _ipaddr, _hostName, SystemID);
                return null;
            }
        }

        public bool CheckPassword(string UserName, string OldPass,string CheckType)
        {
            OraAuthorizeFactroy _of = new OraAuthorizeFactroy();
            return _of.CheckPassword(UserName, OldPass,CheckType);
        }

        public bool ChangePassWord(string UserName, string OldPass, string NewPass)
        {
            OraAuthorizeFactroy _of = new OraAuthorizeFactroy();
            return _of.ChangePassWord(UserName, OldPass, NewPass);
        }


        public bool HeartBeat()
        {
            return true;
        }
    }
}
