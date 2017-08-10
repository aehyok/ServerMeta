using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using SinoSZJS.Base.SystemLog;

namespace SinoSZJS.Base.Misc
{
    public class ConfigFile
    {
        public static string SZ_CustomsQueryUrl
        {
            get
            {
                try
                {
                    string s = ConfigurationManager.AppSettings["SZ_CustomsQueryUrl"];
                    return s;
                }
                catch (Exception e)
                {
                    //SystemLogWriter.WriteLog(string.Format("无法取到配置参数：SZ_CustomsQueryUrl，错误信息{0}", e.Message)
                    //    , System.Diagnostics.EventLogEntryType.Error);
                    return "";
                }
            }
        }

     

        public static string OraleSerivceName
        {
            get
            {
                try
                {
                    string s = ConfigurationManager.AppSettings["OraleSerivceName"];
                    return s;
                }
                catch (Exception e)
                {
                    //SystemLogWriter.WriteLog(string.Format("无法取到配置参数：OraleSerivceName，错误信息{0}", e.Message)
                    //    , System.Diagnostics.EventLogEntryType.Error);
                    return "";
                }
            }
        }

        public static string TitleImage
        {
            get
            {
                try
                {
                    string s = ConfigurationManager.AppSettings["TitleImage"];
                    return s;
                }
                catch (Exception e)
                {
                    //SystemLogWriter.WriteLog(string.Format("无法取到配置参数：TitleImage，错误信息{0}", e.Message)
                    //   , System.Diagnostics.EventLogEntryType.Error);
                    return "";
                }
            }
        }

        public static string SystemDisplayName
        {
            get
            {
                try
                {
                    string s = ConfigurationManager.AppSettings["SystemDisplayName"];
                    return s;
                }
                catch (Exception e)
                {
                    //SystemLogWriter.WriteLog(string.Format("无法取到配置参数：SystemDisplayName，错误信息{0}", e.Message)
                    //   , System.Diagnostics.EventLogEntryType.Error);
                    return "";
                }
            }
        }

        public static bool RunTask
        {
            get
            {
                string _ics_Compress_str = ConfigurationManager.AppSettings["RunTask"] as string;
                if (_ics_Compress_str == null) return false;
                string s = _ics_Compress_str.Trim().ToUpper();
                if (s == "1" || s == "TRUE" || s == "ENABLE" || s == "YES")
                {
                    return true;
                }

                return false;
            }
        }

        public static bool DebugClient
        {
            get
            {
                string _ics_Compress_str = ConfigurationManager.AppSettings["DebugClient"] as string;
                if (_ics_Compress_str == null) return false;
                string s = _ics_Compress_str.Trim().ToUpper();
                if (s == "1" || s == "TRUE" || s == "ENABLE" || s == "YES")
                {
                    return true;
                }

                return false;
            }
        }
        private static bool ics_Compress = false;
        public static bool ICS_Compress
        {
            get
            {
                // 是否压缩
                string _ics_Compress_str = ConfigurationManager.AppSettings["ICS_Compress"] as string;
                string s = _ics_Compress_str.Trim().ToUpper();
                if (s == "1" || s == "TRUE" || s == "ENABLE" || s == "YES")
                {
                    ics_Compress = true;
                }

                return ics_Compress;

            }
        }

        private static bool ics_HttpProxy_Enable = false;
        public static bool ICS_HttpProxy_Enable
        {
            get
            {
                string _ics_HttpProxy = ConfigurationManager.AppSettings["ICS_HttpProxy_Server"].Trim();
                if (_ics_HttpProxy == string.Empty)
                {
                    ics_HttpProxy_Enable = false;
                }
                else
                {
                    ics_HttpProxy_Enable = true;
                }
                return ics_HttpProxy_Enable;
            }
        }

        private static string ics_HttpProxy_Addr = "";
        public static string ICS_HttpProxy_Addr
        {
            get
            {
                string _ics_HttpProxy = ConfigurationManager.AppSettings["ICS_HttpProxy_Server"].Trim();
                string[] httpProxyServerStrs = _ics_HttpProxy.Split(':');
                if (httpProxyServerStrs.Length != 2)
                    throw new Exception("配置文件中的ICS_HttpProxy_Server格式错误!");

                ics_HttpProxy_Addr = httpProxyServerStrs[0];
                return ics_HttpProxy_Addr;
            }
        }

        private static int ics_HttpProxy_Port = 0;
        public static int ICS_HttpProxy_Port
        {
            get
            {
                string _ics_HttpProxy = ConfigurationManager.AppSettings["ICS_HttpProxy_Server"].Trim();
                string[] httpProxyServerStrs = _ics_HttpProxy.Split(':');
                if (httpProxyServerStrs.Length != 2)
                    throw new Exception("配置文件中的ICS_HttpProxy_Server格式错误!");

                ics_HttpProxy_Port = int.Parse(httpProxyServerStrs[1]);
                return ics_HttpProxy_Port;
            }
        }

        private static bool ics_HttpProxy_NeedAccount = false;
        public static bool ICS_HttpProxy_NeedAccount
        {
            get
            {
                string httpProxyAccount = ConfigurationManager.AppSettings["ICS_HttpProxy_Account"].Replace(" ", "");
                if (httpProxyAccount == string.Empty || httpProxyAccount == ":" || httpProxyAccount == "::")
                    ics_HttpProxy_NeedAccount = false;
                else
                {
                    ics_HttpProxy_NeedAccount = true;
                }
                return ics_HttpProxy_NeedAccount;
            }
        }

        private static string ics_HttpProxy_UserName = "";
        public static string ICS_HttpProxy_UserName
        {
            get
            {
                string httpProxyAccount = ConfigurationManager.AppSettings["ICS_HttpProxy_Account"].Replace(" ", "");
                string[] httpProxyAccountStrs = httpProxyAccount.Split(':');
                if (httpProxyAccountStrs.Length < 1)
                    throw new Exception("配置文件中的ICS_HttpProxy_Account格式错误!");
                ics_HttpProxy_UserName = httpProxyAccountStrs[0];
                return ics_HttpProxy_UserName;
            }
        }

        private static string ics_HttpProxy_Password = "";
        public static string ICS_HttpProxy_Password
        {
            get
            {
                string httpProxyAccount = ConfigurationManager.AppSettings["ICS_HttpProxy_Account"].Replace(" ", "");
                string[] httpProxyAccountStrs = httpProxyAccount.Split(':');
                if (httpProxyAccountStrs.Length < 2)
                    throw new Exception("配置文件中的ICS_HttpProxy_Account格式错误!");
                ics_HttpProxy_Password = httpProxyAccountStrs[1];
                return ics_HttpProxy_Password;
            }
        }

        private static string ics_HttpProxy_Domain = "";
        public static string ICS_HttpProxy_Domain
        {
            get
            {
                string httpProxyAccount = ConfigurationManager.AppSettings["ICS_HttpProxy_Account"].Replace(" ", "");
                string[] httpProxyAccountStrs = httpProxyAccount.Split(':');
                if (httpProxyAccountStrs.Length < 3) return "";
                ics_HttpProxy_Domain = httpProxyAccountStrs[2];
                return ics_HttpProxy_Domain;
            }
        }


        public static string ICS_UriPrefix_TCP
        {
            get
            {
                string ics_UriPrefix_TCP = ConfigurationManager.AppSettings["ICS_UriPrefix_TCP"];
                return ics_UriPrefix_TCP;
            }
        }


        public static string ICS_UriPrefix_HTTP
        {
            get
            {
                string ics_UriPrefix_HTTP = ConfigurationManager.AppSettings["ICS_UriPrefix_HTTP"];
                return ics_UriPrefix_HTTP;
            }
        }

        public static string LiveUpdate_SvrInfoUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["LiveUpdate_SvrInfoUrl"];
            }
        }

        public static int ICS_TcpSvcPort
        {
            get
            {
                string s = ConfigurationManager.AppSettings["ICS_TcpSvcPort"];

                try
                {
                    return int.Parse(s);
                }
                catch (Exception e)
                {
                    //SystemLogWriter.WriteLog(string.Format("无法取到配置参数：ICS_TcpSvcPort，错误信息{0}", e.Message)
                     // , System.Diagnostics.EventLogEntryType.Error);
                    throw new Exception("配置文件中的ICS_TcpSvcPort错误!");
                }
            }
        }

        public static int ICS_HttpSvcPort
        {
            get
            {

                string s = ConfigurationManager.AppSettings["ICS_HttpSvcPort"];

                try
                {
                    return int.Parse(s);

                }
                catch (Exception e)
                {
                    //SystemLogWriter.WriteLog(string.Format("无法取到配置参数：ICS_HttpSvcPort，错误信息{0}", e.Message)
                     // , System.Diagnostics.EventLogEntryType.Error);
                    throw new Exception("配置文件中的ICS_TcpSvcPort错误!");
                }
            }
        }

        public static bool WindowsService
        {
            get
            {
                string _is_WindowsService = ConfigurationManager.AppSettings["WindowsService"].Trim();
                if (_is_WindowsService == string.Empty)
                {
                    return false;
                }
                else
                {
                    string s = _is_WindowsService.Trim().ToUpper();
                    if (s == "1" || s == "TRUE" || s == "ENABLE" || s == "YES")
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

        public static string SystemLogType
        {
            get
            {
                return ConfigurationManager.AppSettings["SystemLogType"].Trim().ToUpper();
            }
        }

        public static bool BeepOnSvcAction
        {
            get
            {
                string _is_BeepOnSvcAction = ConfigurationManager.AppSettings["BeepOnSvcAction"];
                if (_is_BeepOnSvcAction == string.Empty || _is_BeepOnSvcAction == null)
                {
                    return false;
                }
                else
                {
                    string s = _is_BeepOnSvcAction.Trim().ToUpper();
                    if (s == "1" || s == "TRUE" || s == "ENABLE" || s == "YES")
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

        public static bool WriteTaskStartInfo
        {
            get
            {
                string _writeInfo = ConfigurationManager.AppSettings["WriteTaskStartInfo"];
                if (_writeInfo == string.Empty || _writeInfo == null)
                {
                    return false;
                }
                else
                {
                    string s = _writeInfo.Trim().ToUpper();
                    return (s == "YES" || s == "Y" || s == "TRUE");
                }
            }

        }

        public static string LoginType
        {
            get
            {
                string _loginType = ConfigurationManager.AppSettings["LoginType"];
                if (_loginType == string.Empty || _loginType == null)
                {
                    return "NONE";
                }
                else
                {
                    string s = _loginType.Trim().ToUpper();
                    return s;
                }
            }

        }

        public static string SystemID
        {
            get
            {
                string _sysid = ConfigurationManager.AppSettings["SystemID"];
                if (_sysid == string.Empty || _sysid == null)
                {
                    return "";
                }
                else
                {
                    string s = _sysid.Trim().ToUpper();
                    return s;
                }
            }
        }


        public static string OracleServiceName
        {
            get
            {
                string _oracleServiceName = ConfigurationManager.AppSettings["OracleServiceName"];
                if (_oracleServiceName == string.Empty || _oracleServiceName == null)
                {
                    return "";
                }
                else
                {
                    return _oracleServiceName;
                }
            }
        }

        public static string SytemDWRootID
        {
            get
            {
                string _sysrootid = ConfigurationManager.AppSettings["SytemDWRootID"];
                if (_sysrootid == string.Empty || _sysrootid == null)
                {
                    return "";
                }
                else
                {
                    string s = _sysrootid.Trim().ToUpper();
                    return s;
                }
            }
        }

        public static string DeployID
        {
            get
            {
                string _deployid = ConfigurationManager.AppSettings["DeployID"];
                if (_deployid == string.Empty || _deployid == null)
                {
                    return "";
                }
                else
                {
                    string s = _deployid.Trim().ToUpper();
                    return s;
                }
            }
        }

        private static bool client_ShowPendingAlert = false;
        public static bool Client_ShowPendingAlert
        {
            get
            {
                return client_ShowPendingAlert;
            }
            set
            {
                client_ShowPendingAlert = value;
            }
        }

        public static int RemoteRenewValue
        {
            get
            {
                try
                {
                    string _valuestr = ConfigurationManager.AppSettings["RemoteRenewValue"];
                    if (_valuestr == string.Empty || _valuestr == null)
                    {
                        return 20;
                    }
                    else
                    {
                        return int.Parse(_valuestr);
                    }
                }
                catch
                {
                    return 20;
                }
            }
        }

    }
}
