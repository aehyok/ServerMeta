using System;
using System.Collections;
using System.Diagnostics;
using System.Data;
using Oracle.DataAccess.Client;
using SinoSZJS.DataAccess;



namespace DIReport.ZHXTWebService
{
    public enum SvcAction
    {
        Starting,
        Started,
        Stopping,
        Stopped,
    }

    /// <summary>
    /// Summary description for ServerCommon
    /// </summary>
    public class ServerCommon
    {


        public static EventLog WinEventLog;						//	Windows Event Log



        #region 系统功能
        public static void Init()
        {
            //	初始化服务器端配置
            Config.LoadConfig();
            WriteLog(string.Format("ZHXTWebServiceV3服务启动成功！时间：{0}", DateTime.Now), EventLogEntryType.Information);
        }



        #endregion


        //根据Sql返回弱类型数据集
        public static DataSet GetDataBySql(string Sql)
        {
            try
            {
                DataSet _ds = OracleHelper.FillDataSet(Sql, "RESULTTABLE");
                return _ds;

            }
            catch (Exception e)
            {
                string _eStr = string.Format(" ZHXTWebServiceV3系统在查询数据时发生错误！\n Command String:{0} \n  Error Message:{1}", Sql, e.Message);
                WriteLog(_eStr, EventLogEntryType.Error);
                return null;
            }
        }

        //根据Sql返回一个数值查询值
        static public Decimal Get_SelectResultCount(string Sql)
        {
            try
            {
                using (OracleConnection conn = OracleHelper.OpenConnection())
                {
                    decimal _ret = (decimal)OracleHelper.ExecuteScalar(conn, CommandType.Text, Sql);
                    return _ret;
                }
            }
            catch (Exception e)
            {
                string _eStr = string.Format(" ZHXTWebServiceV3系统在查询数据时发生错误！\n Command String:{0} \n  Error Message:{1}", Sql, e.Message);
                WriteLog(_eStr, EventLogEntryType.Error);
                throw e;
            }
        }

        static public void Run_Sqltext(string sql)
        {
            using (OracleConnection conn = OracleHelper.OpenConnection())
            {
                OracleCommand comm = new OracleCommand(sql, conn);
                comm.ExecuteScalar();
            }
        }

        //根据Sql返回一个字符串查询值
        static public string Get_SelectString(string Sql)
        {

            using (OracleConnection conn = OracleHelper.OpenConnection())
            {
                OracleCommand comm = new OracleCommand(Sql, conn);
                return (string)comm.ExecuteScalar();
            }

        }

        //写日志
        private const string SQL_InsertEvent = @"insert into zhxtwebservice_log (id,sj,msg,lx) values (SEQUENCES_ZHCX.Nextval,Sysdate,:MSG,:LX)";
        public static void WriteLog(string _msg, EventLogEntryType _type)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand(SQL_InsertEvent, cn);
                _cmd.Parameters.Add(":MSG", (_msg.Length > 1000 ? _msg.Substring(0, 1000) : _msg));
                _cmd.Parameters.Add(":LX", (_type == EventLogEntryType.Error) ? "1" : "0");
                _cmd.ExecuteNonQuery();
            }

        }

    }
}