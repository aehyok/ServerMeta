using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using SinoSZJS.DataAccess.Sql;

namespace SinoSZJS.CS.BizMetaDataManager.MTS
{
    public class SinoBestMTSDataReader
    {

        private const string SQL_GetNextMTSMessage = @"dbcm_msg.getmsgplan";

        /// <summary>
        /// 取下一条要传送的报文
        /// </summary>
        /// <returns></returns>
        public static MTSMessage GetNextMsg(string DeployID, ref string TargetAddr)
        {
            TargetAddr = "";
            try
            {
                SqlParameter[] _param = {
                              new SqlParameter("strdeployid",SqlDbType.VarChar),
                               //new SqlParameter("strmsgguid",SqlDbType.VarChar,ParameterDirection.Output),
                               //new SqlParameter("strtargetserviceip",SqlDbType.VarChar, ParameterDirection.Output),
                               //new SqlParameter("nret",SqlDbType.Decimal, ParameterDirection.Output), 
                               //new SqlParameter("strerr",SqlDbType.VarChar, ParameterDirection.Output)
                           };
                _param[0].Value = DeployID;
                _param[1].Size = 50;
                _param[2].Size = 1000;
                _param[4].Size = 40000;
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.StoredProcedure, SQL_GetNextMTSMessage, _param);
                decimal _ret = -1;// (((SqlDecimal)_param[3].Value).IsNull) ? (decimal)1 : (decimal)(SqlDecimal.SetPrecision((SqlDecimal)_param[3].Value, 28));
                if (_ret > 0)
                {
                    throw new Exception(string.Format("取待发报文失败! {0}", (_param[4].Value == DBNull.Value) ? "" : _param[4].Value.ToString()));
                }
                else
                {
                    string _id = (((SqlString)_param[1].Value).IsNull) ? "" : _param[1].Value.ToString();
                    TargetAddr = (((SqlString)_param[2].Value).IsNull) ? "" : _param[2].Value.ToString();
                    if (_id == null || _id == "")
                    {
                        return null;
                    }
                    else
                    {
                        //取报文内容
                        MTSMessage _retMsg = GetMTSMessgeByID(_id);
                        return _retMsg;
                    }
                }
            }
            catch (Exception ex)
            {
                LogWriter.WriteSystemLog(ex.Message, "ERROR");
                throw ex;
            }


        }

        private const string SQL_ChangeMTSMessageStatus = @"update CM_MSG_Sendbuffer set PROSTATUS=:ST where PKGUID=:ID";
        private const string SQL_GetMTSMessgeByID = @"select PKGUID,DEPLOYID_TX,DEPLOYID_RX,DATAPKG,PROCMETHOD from CM_MSG_Sendbuffer where PKGUID=:ID";
        private static MTSMessage GetMTSMessgeByID(string _id)
        {
            MTSMessage _msg = new MTSMessage();
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlTransaction _tx = cn.BeginTransaction();
                try
                {
                    ////先改记录标识
                    SqlCommand _upCmd = new SqlCommand(SQL_ChangeMTSMessageStatus, cn);
                    _upCmd.Parameters.Add(":ST", "TX正在发送");
                    _upCmd.Parameters.Add(":ID", _id);
                    _upCmd.ExecuteNonQuery();
                    //取记录内容
                    SqlCommand _cmd = new SqlCommand(SQL_GetMTSMessgeByID, cn);
                    _cmd.Parameters.Add(":ID", _id);
                    using (SqlDataReader dr = _cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            _msg.PKGuid = dr.IsDBNull(0) ? "" : dr.GetString(0);
                            _msg.DEPLOYID_TX = dr.IsDBNull(1) ? "" : dr.GetString(1);
                            _msg.DEPLOYID_RX = dr.IsDBNull(2) ? "" : dr.GetString(2);
                            _msg.DataPKG = dr.IsDBNull(3) ? "" : dr.GetString(3);
                            _msg.PROCMETHOD = dr.IsDBNull(4) ? "" : dr.GetString(4);
                        }
                        dr.Close();
                    }
                    _tx.Commit();
                }
                catch (Exception ex)
                {
                    LogWriter.WriteSystemLog(ex.Message, "ERROR");
                    _tx.Rollback();
                    return null;
                }
            }
            return _msg;
        }

        private const string SQL_WriteMTSStatus = @"update CM_MSG_Sendbuffer set PROSTATUS=:ST,PROCMSG=:MSG where PKGUID=:ID";      
        public static bool WriteMTSStatus(string PKGUID, string STATUS, string MSG)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlTransaction _tx = cn.BeginTransaction();
                try
                {
                    ////先改记录标识
                    SqlCommand _upCmd = new SqlCommand(SQL_WriteMTSStatus, cn);
                    _upCmd.Parameters.Add(":ST", STATUS);
                    _upCmd.Parameters.Add(":MSG", MSG);
                    _upCmd.Parameters.Add(":ID", PKGUID);
                    _upCmd.ExecuteNonQuery();
                    _tx.Commit();
                }
                catch (Exception ex)
                {
                    LogWriter.WriteSystemLog(ex.Message, "ERROR");
                    _tx.Rollback();
                    return false;
                }
            }
            return true;
        }
    }
}
