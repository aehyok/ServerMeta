using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SinoSZJS.DataAccess.Sql;

namespace SinoSZJS.CS.BizMetaDataManager.MTS
{
    public class SinoBestMTSWriter
    {
        private const string SQL_CheckReceiveBuffer = @"select count(PKGUID) from CM_MSG_RECIVEBUFFER where PKGUID=:PKGUID";
        private const string SQL_SaveReceiveBufferData = @"insert into  CM_MSG_RECIVEBUFFER (PKGUID,DEPLOYID_TX, DEPLOYID_RX, PROSTATUS,PROCMSG,TRANTIME,DATAPKG,PROCMETHOD)
            values (:PKGUID,:DEPLOYID_TX, :DEPLOYID_RX, :PROSTATUS,:PROCMSG,:TRANTIME,:DATAPKG,:PROCMETHOD)";
        public static bool SaveBufferData(string PKGuid, string DEPLOYID_TX, string DEPLOYID_RX, string PROSTATUS, string MSG, int TRANTIME, string DataPKG, string PROCMETHOD)
        {
            decimal _checkret = 0;
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlTransaction _txn = cn.BeginTransaction();

                //判断接收区是否有GUID，
                using (SqlCommand _cmd_check = new SqlCommand(SQL_CheckReceiveBuffer, cn))
                {
                    _cmd_check.Parameters.Add(":PKGUID", PKGuid);
                    _checkret = (decimal)_cmd_check.ExecuteScalar();
                }

                if (_checkret < 1)
                {
                    //如果接收区没有，则写入
                    using (SqlCommand _cmd = new SqlCommand(SQL_SaveReceiveBufferData, cn))
                    {
                        _cmd.Parameters.Add(":PKGUID", PKGuid);
                        _cmd.Parameters.Add(":DEPLOYID_TX", DEPLOYID_TX);
                        _cmd.Parameters.Add(":DEPLOYID_RX", DEPLOYID_RX);
                        _cmd.Parameters.Add(":PROSTATUS", PROSTATUS);
                        _cmd.Parameters.Add(":PROCMSG", MSG);
                        _cmd.Parameters.Add(":TRANTIME", Convert.ToDecimal(TRANTIME));
                        _cmd.Parameters.Add(":DATAPKG", DataPKG);
                        _cmd.Parameters.Add(":PROCMETHOD", PROCMETHOD);
                        _cmd.ExecuteNonQuery();
                    }
                    _txn.Commit();
                }
                else
                {
                    _txn.Rollback();
                }

            }
            return true;
        }

        private const string SQL_ChangeStatus = @"update CM_MSG_RECIVEBUFFER set PROSTATUS=:PROSTATUS,PROCMSG=:PROCMSG where PKGUID=:PKGUID";
        public static void ChangeStatus(string status, string PkGuid, string Message)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlTransaction _txn = cn.BeginTransaction();

                try
                {//如果接收区没有，则写入
                    using (SqlCommand _cmd = new SqlCommand(SQL_ChangeStatus, cn))
                    {
                        _cmd.Parameters.Add(":PROSTATUS", status);
                        _cmd.Parameters.Add(":PROCMSG", Message);
                        _cmd.Parameters.Add(":PKGUID", PkGuid);
                        _cmd.ExecuteNonQuery();
                    }
                    _txn.Commit();
                }
                catch (Exception ex)
                {
                    _txn.Rollback();
                    throw ex;
                }

            }
        }
    }
}
