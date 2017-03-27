using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.Authorize;
using System.Reflection;
using System.Configuration;
using SinoSZJS.Base.Config;
using SinoSZJS.Base.UserLog;
using System.Runtime.Remoting.Messaging;
using System.Net;

namespace SinoSZJS.CS.BizAuthorize
{
    public class BIZ_Authorize : MarshalByRefObject, IAuthorize
    {
        private static IAuthorize _iAuthorize = null;
        private static ServerConfig _serverConfigData = null;

        public static IAuthorize AuthorizeFactory
        {
            get
            {
                if (_iAuthorize == null)
                {
                    _iAuthorize = GetDataConfig();
                }
                return _iAuthorize;
            }
        }

        private static IAuthorize GetDataConfig()
        {
            OraAuthorizeFactroy _of = new OraAuthorizeFactroy();
            return _of as IAuthorize;
        }



        #region IAuthorize Members

        public SinoUser LoginSys(string _sysid, string _name, string _pass,string CheckType)
        {
            try
            {
                SinoUser _ret = AuthorizeFactory.LoginSys(_sysid, _name, _pass,CheckType);

                UserLogWriter.WriteLog(decimal.Parse(_ret.UserID), "系统登录",
                        string.Format("用户{0}(登录名{1})使用CS客户端用登录系统成功!", _ret.UserName, _name),
                        1, _ret.IPAddress, _ret.HostName, _ret.SystemID);

                return _ret;
            }
            catch (Exception e)
            {
                string _ipaddr = CallContext.GetData("ClientIP").ToString();
                string _hostName = "";
                try
                {
                    _hostName = Dns.GetHostEntry(_ipaddr).HostName;
                }
                catch
                {
                    _hostName = _ipaddr;
                }
                UserLogWriter.WriteLog(-1, "系统登录",
                      string.Format("未知用户{0}(登录名{1})使用CS客户端用登录系统失败!失败信息:{2}", _name, _name, e.Message),
                      2, _ipaddr, _hostName, _sysid);
                return null;
            }
        }

        public bool CheckPassword(string _uname, string old_pass,string CheckType)
        {
            return AuthorizeFactory.CheckPassword(_uname, old_pass,CheckType);
        }

        public bool ChangePassWord(string uname, string old_pass, string new_pass)
        {
            try
            {
                bool _ret = AuthorizeFactory.ChangePassWord(uname, old_pass, new_pass);
                if (_ret)
                {
                    UserLogWriter.WriteLogByDefaultUser("修改口令", "修改个人口令密码成功!", 1);
                }
                else
                {
                    UserLogWriter.WriteLogByDefaultUser("修改口令", "修改个人口令密码失败!失败原因:旧口令不正确!", 2);
                }
                return _ret;
            }
            catch (Exception e)
            {
                UserLogWriter.WriteLogByDefaultUser("修改口令",
                        string.Format("修改个人口令密码失败!失败原因:{0}", e.Message), 2);
                return false;
            }
        }

        public List<SinoOrganize> GetRootDwList(string _rootDwid, decimal _levelNum)
        {
            return AuthorizeFactory.GetRootDwList(_rootDwid, _levelNum);
        }

        public List<SinoOrganize> GetRootDwListEx(string _rootDwid, decimal _levelNum, string _type)
        {
            return AuthorizeFactory.GetRootDwListEx(_rootDwid, _levelNum, _type);
        }

        public decimal GetDWIDByDWDM(string _dwdm)
        {
            return AuthorizeFactory.GetDWIDByDWDM(_dwdm);
        }

        public void WriteExportLog(int _exportRowCount, string ExportDataMsg)
        {
            AuthorizeFactory.WriteExportLog(_exportRowCount, ExportDataMsg);
        }

        #endregion



        #region IAuthorize Members


        public ServerConfig GetServerConfig()
        {
            if (_serverConfigData == null)
            {
                _serverConfigData = LocalConfigData.InitServerConfig();
            }

            return _serverConfigData;
        }






        #endregion
    }
}
