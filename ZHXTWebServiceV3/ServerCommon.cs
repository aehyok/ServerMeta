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



        #region ϵͳ����
        public static void Init()
        {
            //	��ʼ��������������
            Config.LoadConfig();
            WriteLog(string.Format("ZHXTWebServiceV3���������ɹ���ʱ�䣺{0}", DateTime.Now), EventLogEntryType.Information);
        }



        #endregion


        //����Sql�������������ݼ�
        public static DataSet GetDataBySql(string Sql)
        {
            try
            {
                DataSet _ds = OracleHelper.FillDataSet(Sql, "RESULTTABLE");
                return _ds;

            }
            catch (Exception e)
            {
                string _eStr = string.Format(" ZHXTWebServiceV3ϵͳ�ڲ�ѯ����ʱ��������\n Command String:{0} \n  Error Message:{1}", Sql, e.Message);
                WriteLog(_eStr, EventLogEntryType.Error);
                return null;
            }
        }

        //����Sql����һ����ֵ��ѯֵ
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
                string _eStr = string.Format(" ZHXTWebServiceV3ϵͳ�ڲ�ѯ����ʱ��������\n Command String:{0} \n  Error Message:{1}", Sql, e.Message);
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

        //����Sql����һ���ַ�����ѯֵ
        static public string Get_SelectString(string Sql)
        {

            using (OracleConnection conn = OracleHelper.OpenConnection())
            {
                OracleCommand comm = new OracleCommand(Sql, conn);
                return (string)comm.ExecuteScalar();
            }

        }

        //д��־
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