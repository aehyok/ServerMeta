using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SinoSZJS.DataAccess.Sql
{
    /// <summary>
    /// 系统日志记录器
    /// </summary>
    public class LogWriter
    {
        private const string SQL_WriteSystemLog = @"insert into XT_SYSTEMLOG  (ID,CZSJ,LOGTYPE,LOGTEXT) values  (@ID,GETDATE(),@LOGTYPE,@LOGTEXT) ";
        /// <summary>
        /// 写系统日志
        /// </summary>
        /// <param name="_msg">系统日志信息</param>
        /// <param name="_type">类型　　INFO:信息　ERROR:错误</param>
        /// <returns></returns>
        static public bool WriteSystemLog(string _msg, string _type)
        {if (_msg.Length > 3700) _msg = _msg.Substring(0, 3700);
            using (SqlConnection cn = new SqlConnection(SqlHelper.ConnectionStringProfile))
            {
                cn.Open();
                //SqlTransaction _txn = cn.BeginTransaction();
                SqlCommand comm = new SqlCommand(SQL_WriteSystemLog, cn);
                comm.Parameters.Add("@ID", Guid.NewGuid().ToString());
                comm.Parameters.Add("@LOGTYPE", _type);
                comm.Parameters.Add("@LOGTEXT", _msg);
                comm.ExecuteScalar();
                //_txn.Commit();
                cn.Close();
            }
            return true;
        }



        private const string SQL_WriteUserLog = @"insert into XT_USERLOG (ID,YHID,CZSJ,CZLX,CZXXNR,FROMIP,SYSTEMID,RESULTTYPE,FROMHOST) values
                                                                             (:ID,:YHID,GETDATE(),:CZLX,:CZXXNR,:FROMIP,:SYSTEMID,:RESULTTYPE,:FROMHOST) ";
        private const string SQL_WriteUserLog2 = @"insert into XT_USERLOG (ID,YHID,gwid,CZSJ,CZLX,CZXXNR,FROMIP,SYSTEMID,RESULTTYPE,FROMHOST) values
          
                                                                      (:ID,:YHID,:GWID,GETDATE(),:CZLX,:CZXXNR,:FROMIP,:SYSTEMID,:RESULTTYPE,:FROMHOST) ";
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
        static public bool WriteUserLog(decimal _yhid, string _czlx, string _cxnr, decimal _resulttype, string _ipaddr, string _hostName, string _systemID)
        {
            if (_cxnr.Length > 3700) _cxnr = _cxnr.Substring(0, 3700);
            if (_czlx.Length > 70) _czlx = _czlx.Substring(0, 70);
            using (SqlConnection cn = new SqlConnection(SqlHelper.ConnectionStringProfile))
            {
                cn.Open();
                //SqlTransaction _txn = cn.BeginTransaction();
                SqlCommand comm = new SqlCommand(SQL_WriteUserLog, cn);
                comm.Parameters.Add(":ID", Guid.NewGuid().ToString());
                comm.Parameters.Add(":YHID", _yhid);
                comm.Parameters.Add(":CZLX", _czlx);
                comm.Parameters.Add(":CZXXNR", _cxnr);
                comm.Parameters.Add(":FROMIP", _ipaddr);
                comm.Parameters.Add(":SYSTEMID", _systemID);
                comm.Parameters.Add(":RESULTTYPE", _resulttype);
                comm.Parameters.Add(":FROMHOST", _hostName);
                comm.ExecuteScalar();
                //_txn.Commit();
                cn.Close();
            }
            return true;
        }

        static public bool WriteUserLog(decimal _yhid, string _czlx, string _cxnr, decimal _resulttype, string _ipaddr, string _hostName, string _systemID, SqlConnection cn)
        {
            if (_cxnr.Length > 3700) _cxnr = _cxnr.Substring(0, 3700);
            if (_czlx.Length > 70) _czlx = _czlx.Substring(0, 70);

            SqlCommand comm = new SqlCommand(SQL_WriteUserLog, cn);
            comm.Parameters.Add(":ID", Guid.NewGuid().ToString());
            comm.Parameters.Add(":YHID", _yhid);
            comm.Parameters.Add(":CZLX", _czlx);
            comm.Parameters.Add(":CZXXNR", _cxnr);
            comm.Parameters.Add(":FROMIP", _ipaddr);
            comm.Parameters.Add(":SYSTEMID", _systemID);
            comm.Parameters.Add(":RESULTTYPE", _resulttype);
            comm.Parameters.Add(":FROMHOST", _hostName);
            comm.ExecuteScalar();

            return true;
        }

        static public bool WriteUserLog(decimal _yhid, string gwid, string _czlx, string _cxnr, decimal _resulttype, string _ipaddr, string _hostName, string _systemID)
        {
            if (_cxnr.Length > 3700) _cxnr = _cxnr.Substring(0, 3700);
            if (_czlx.Length > 70) _czlx = _czlx.Substring(0, 70);
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlCommand comm = new SqlCommand(SQL_WriteUserLog2, cn);
                comm.Parameters.Add(":ID", Guid.NewGuid().ToString());
                comm.Parameters.Add(":YHID", _yhid);
                comm.Parameters.Add(":GWID", gwid);
                comm.Parameters.Add(":CZLX", _czlx);
                comm.Parameters.Add(":CZXXNR", _cxnr);
                comm.Parameters.Add(":FROMIP", _ipaddr);
                comm.Parameters.Add(":SYSTEMID", _systemID);
                comm.Parameters.Add(":RESULTTYPE", _resulttype);
                comm.Parameters.Add(":FROMHOST", _hostName);
                comm.ExecuteScalar();
            }
            return true;
        }




        private const string SQL_WriteQueryLog = @"insert into query_log (ID,SJ,USETIME,QUERY_STR,LX,YHID,BZ)
                                                   values (SEQ_ZHTJ.NEXTVAL,GETDATE(),:USETIME,:QUERY_STR,:LX,:YHID,:BZ)";
        /// <summary>
        /// 查询日志
        /// </summary>
        /// <param name="_sqlStr"></param>
        /// <param name="_userTime"></param>
        /// <param name="bz"></param>
        /// <param name="UserID"></param>
        /// <param name="lx">1-模型，2-指标</param>
        public static void WriteQueryLog(string _sqlStr, int _userTime, string bz, string UserID, string lx = "1")
        {
            SqlParameter[] _param = { 
                                new SqlParameter(":USETIME", SqlDbType.Decimal), 
                                new SqlParameter(":QUERY_STR", SqlDbType.NVarChar,4000), 
                                new SqlParameter(":LX", SqlDbType.NVarChar,10), 
                                new SqlParameter(":YHID", SqlDbType.Decimal),
                                new SqlParameter(":BZ",SqlDbType.NVarChar,1000)
                                };
            _param[0].Value = Convert.ToDecimal(_userTime);
            _param[1].Value = _sqlStr;
            _param[2].Value = lx;
            _param[3].Value = decimal.Parse(UserID);
            _param[4].Value = bz;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, SQL_WriteQueryLog, _param);
        }
    }
}
