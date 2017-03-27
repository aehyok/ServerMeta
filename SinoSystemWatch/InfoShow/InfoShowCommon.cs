using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSystemWatch.InfoShow
{
    public class InfoShowCommon
    {
        public static string GetCNString(string EnString)
        {
            switch (EnString)
            {
                case "WinServiceCheck":
                    return "Windows服务状态";
                case "HardDiskSpaceCheck":
                    return "服务器硬盘空间";
                case "OracleConnectCheck":
                    return "ORACLE数据库连接状态";
                case "WCFStatusCheck":
                    return "WCF服务状态";
                case "IISLogCheck":
                    return "IIS日志";
                case "SystemLogCheck":
                    return "系统日志(XT_SystemLog)";
                case "UserLogCheck":
                    return "用户操作日志(XT_UserLog)";
                case "QueryLogCheck":
                    return "查询日志(XT_QueryLog)";
                case "SystemTaskCheck":
                    return "系统任务(GZRW)";

                default:
                    return EnString;
            }
        }
    }
}
