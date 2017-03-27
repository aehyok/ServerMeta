using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;

namespace SinoSZJS.DataAccess
{
    public class IcsLogHelper
    {
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="Direction">访问方向  1.被访问 2.向外访问其它系统接口</param>
        /// <param name="IcsType">接口类型</param>
        /// <param name="SrcIP">来源IP地址</param>
        /// <param name="DesIP">目标IP地址</param>
        /// <param name="CallParam">调用参数</param>
        /// <param name="LogMsg">日志消息内容</param>
        /// <param name="CallResult">执行结果情况 0成功 1失败</param>
        /// <returns></returns>
        public static bool WirteLog(string Direction, string IcsType, string SrcIP, string DesIP, string CallParam, string LogMsg, string CallResult)
        {
            try
            {
                using (OracleConnection cn = OracleHelper.OpenConnection())
                {
                    bool _ret = WirteLog(Direction, IcsType, SrcIP, DesIP, CallParam, LogMsg, CallResult, cn);
                    return _ret;
                }
            }
            catch (Exception ex)
            {
                OralceLogWriter.WriteSystemLog(string.Format("插入接口日志记录出错！{0}", ex.Message), "ERROR");
                return false;
            }
        }

        private const string SQL_WriteLog = @"insert into xt_icslog (ID,SJ,FX,ICSTYPE,SRCIP,DESIP,CALLPARAM,LOGMSG,CALLRESULT)
                                                             values (:ID,sysdate,:FX,:ICSTYPE,:SRCIP,:DESIP,:CALLPARAM,:LOGMSG,:CALLRESULT)";

        private static bool WirteLog(string Direction, string IcsType, string SrcIP, string DesIP, string CallParam, string LogMsg, string CallResult, OracleConnection cn)
        {
            OracleCommand _cmd = new OracleCommand(SQL_WriteLog, cn);
            _cmd.Parameters.Add("ID", Guid.NewGuid().ToString());
            _cmd.Parameters.Add(":FX", Direction);
            _cmd.Parameters.Add(":ICSTYPE", IcsType);
            _cmd.Parameters.Add(":SRCIP", SrcIP);
            _cmd.Parameters.Add(":DESIP", DesIP);
            _cmd.Parameters.Add(":CALLPARAM", (CallParam.Length > 2000) ? CallParam.Substring(0, 3000) : CallParam);
            _cmd.Parameters.Add(":LOGMSG", (LogMsg.Length > 2000) ? LogMsg.Substring(0, 3000) : LogMsg);
            _cmd.Parameters.Add(":CALLRESULT", (CallResult.Length > 3000) ? CallResult.Substring(0, 3000) : CallResult);
            _cmd.ExecuteNonQuery();

            return true;
        }


    }
}
