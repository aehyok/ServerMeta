using System;
using System.Collections.Generic;
using System.Text;
using SinoSZPluginFramework.ServerPlugin;
using SinoSZPluginFramework;
using SinoSZJS.Base.Authorize;
using System.Runtime.Remoting.Messaging;
using SinoSZJS.Base.Misc;

namespace SinoSZServerBase
{
        public class BizServiceFactory : MarshalByRefObject, IServiceFactory
        {
                private static string _loginType = "";

                private static string LoginType
                {
                        get
                        {
                                if (_loginType == "")
                                {
                                        _loginType = ConfigFile.LoginType;
                                }
                                return _loginType;
                        }
                }
                #region IServiceFactory Members



                public object GetInterFace(string _serviceName)
                {
                        if (LoginType == "NONE" || _serviceName == "AuthorizeServerPlugin")
                        {
                                return GetInterFaceObject(_serviceName);
                        }
                        else
                        {
                                SinoSZTicketInfo _currentUserInfo = CallContext.GetData("UserIdentity") as SinoSZTicketInfo;

                                if (_currentUserInfo != null)
                                {
                                        if (TicketLib.CheckUserTicket(_currentUserInfo))
                                        {
                                                return GetInterFaceObject(_serviceName);
                                        }
                                        else
                                        {
                                                throw new Exception("用户未登录系统或没有使用授权!");
                                        }
                                }
                                else
                                {
                                        throw new Exception("用户未登录系统或没有使用授权!");
                                }
                        }
                }

                private object GetInterFaceObject(string _serviceName)
                {
                        IServerPlugin _plugin = ServiceLib.GetService(_serviceName);

                        if (_plugin == null)
                        {
                                throw new Exception(string.Format("服务器端未提供此服务:{0}", _serviceName));
                        }
                        else
                        {
                                return _plugin.GetServiceObject(_serviceName);
                        }
                }

                #endregion
        }
}
