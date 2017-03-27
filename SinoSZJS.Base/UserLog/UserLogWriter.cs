using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.Authorize;

namespace SinoSZJS.Base.UserLog
{
        public class UserLogWriter
        {
                private static IUserLog _ics_UserLog = null;
                public static IUserLog ICS_UserLog
                {
                        get
                        {
                                return _ics_UserLog;
                        }
                        set
                        {
                                _ics_UserLog = value;
                        }

                }

                /// <summary>
                /// 写用户操作日志
                /// </summary>
                /// <param name="_yhid">用户ID</param>
                /// <param name="_czlx">操作类型</param>
                /// <param name="_cxnr">日志内容</param>
                /// <param name="_resulttype">操作结果类型　0.未知　1.成功　　2.失败　</param>
                /// <param name="_ipaddr">客户端IP地址</param>
                /// <param name="_hostName">客户端主机名称</param>
                /// <param name="_systemID">记录日志的系统ID</param>
                /// <returns></returns>             
                public static bool WriteLog(decimal _yhid, string _czlx, string _cxnr, decimal _resulttype, string _ipaddr, string _hostName, string _systemID)
                {
                        if (_ics_UserLog != null) return _ics_UserLog.WriteUserLog(_yhid, _czlx, _cxnr, _resulttype, _ipaddr, _hostName, _systemID);
                        return true;
                }

                /// <summary>
                /// 使用当前进程用户写操作日志
                /// </summary>
                /// <param name="_czlx">操作类型</param>
                /// <param name="_cxnr">日志内容</param>
                /// <param name="_resulttype">操作结果类型　0.未知　1.成功　　2.失败</param>
                /// <returns></returns>
                public static bool WriteLogByDefaultUser(string _czlx, string _cxnr, decimal _resulttype)
                {
                        if (_ics_UserLog != null) return _ics_UserLog.WriteUserLog(decimal.Parse(SinoUserCtx.CurUser.UserID), _czlx, _cxnr, _resulttype, SinoUserCtx.CurUser.IPAddress, SinoUserCtx.CurUser.HostName,SinoUserCtx.CurUser.SystemID);
                        return true;
                } 
        }
}
