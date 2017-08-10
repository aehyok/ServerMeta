using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SinoSZJS.DataAccess.Sql;
using System.Data.SqlClient;

namespace SinoSZServerBase
{
    public class SQL_TaskCommon
    {
        /// <summary>
        /// 将所有任务状态置为空闲
        /// </summary>
        public static void InitAllTaskState()
        {
            string _rwql = string.Format("update GZRW set RWZT = 0 where RWZT =1");

            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _rwql);
            }
            catch (Exception ex)
            {
                string _log = string.Format("清除未执行完毕任务时出错：{0}", ex.Message);
                LogWriter.WriteSystemLog(_log, "ERROR");
            }
        }

        /// <summary>
        /// 取所有的达到执行时间的任务列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetTaskList()
        {
            DataTable detailData = null;
            StringBuilder _sb = new StringBuilder();
            _sb.Append("select RWID,RZLB,RWML from GZRW where RWZT = 0 and NEXTTIME<sysdate");

            try
            {
                detailData = SqlHelper.FillDataTable(SqlHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString());
                detailData.TableName = "TASKLIST";
                return detailData;
            }
            catch (Exception ex)
            {
                string _log = string.Format("取所有的达到执行时间的任务列表出错：{0}", ex.Message);
                LogWriter.WriteSystemLog(_log, "ERROR");
                return null;
            }

        }

        /// <summary>
        /// 写任务开始状态
        /// </summary>
        /// <param name="_Rwid"></param>
        /// <returns></returns>
        public static bool WriteRWState(string _Rwid)
        {
            string _cmd = "Update GZRW SET RWZT = 1 where RWID=:RWID";
            SqlParameter[] _param = { new SqlParameter(":RWID", SqlDbType.Decimal) };
            _param[0].Value = decimal.Parse(_Rwid);
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _cmd, _param);
            }
            catch (Exception e)
            {
                string _log = string.Format("设置任务{1}状态为正在执行时，出现错误：{0}", e.Message, _Rwid);
                LogWriter.WriteSystemLog(_log, "ERROR");
                return false;
            }
            return true;
        }

        public static bool WriteRWStateSetRunFlag(string _Rwid, int flag)
        {
            string _cmd = "Update GZRW SET RWZT=:RWZT where RWID=:RWID";
            SqlParameter[] _param = { 
                                 new SqlParameter(":RWID", SqlDbType.Decimal),
                                new SqlParameter(":RWID", SqlDbType.Decimal) };
            _param[0].Value = Convert.ToDecimal(flag);
            _param[1].Value = decimal.Parse(_Rwid);
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _cmd, _param);
            }
            catch (Exception e)
            {
                string _log = string.Format("设置任务{1}状态为正在执行时，出现错误：{0}", e.Message, _Rwid);
                LogWriter.WriteSystemLog(_log, "ERROR");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 写任务执行结果
        /// </summary>
        /// <returns></returns>
        public static bool WriteResult(string _Rwid, DateTime _startTime, DateTime _nextTime)
        {
            //清除执行状态，并写入执行结果，设置下次执行时间                        
            SqlCommand cmd;
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                try
                {
                    cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Update GZRW SET NEXTTIME=:NEXTTIME,LASTTIME =:LASTTIME,RUNFLAG=0,RWZT=0,RUNRESULT=:MSG  where RWID=:RWID";
                    cmd.Parameters.Add(new SqlParameter(":NEXTTIME", _nextTime));
                    cmd.Parameters.Add(new SqlParameter(":LASTTIME", _startTime));
                    cmd.Parameters.Add(new SqlParameter(":MSG", "任务正常执行完毕！"));
                    cmd.Parameters.Add(new SqlParameter(":RWID", decimal.Parse(_Rwid)));
                    cmd.ExecuteScalar();
                }
                catch (Exception e)
                {
                    string _log = string.Format("写入任务{1}结果时出现错误：{0}", e.Message, _Rwid);
                    LogWriter.WriteSystemLog(_log, "ERROR");
                    return false;
                }

                try
                {
                    cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into gzrw_rz (rzid,rwid,rwmc,runtime,runflag,runresult) values (SEQ_YW.NEXTVAL,:RWID,'',sysdate,0,:RUNRESULT)";
                    cmd.Parameters.Add(new SqlParameter(":RWID", decimal.Parse(_Rwid)));
                    cmd.Parameters.Add(new SqlParameter(":RUNRESULT", "任务正常执行完毕！"));
                    cmd.ExecuteScalar();
                }
                catch (Exception e)
                {
                    string _log = string.Format("写入任务{1}日志表时出现错误：{0}", e.Message, _Rwid);
                    LogWriter.WriteSystemLog(_log, "ERROR");
                    return false;
                }

                cn.Close();
            }
            return true;
        }

        public static bool WriteResultSetRunFlag(string _Rwid, DateTime _startTime, DateTime _nextTime, int flag)
        {
            //清除执行状态，并写入执行结果，设置下次执行时间                        
            SqlCommand cmd;
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                try
                {
                    cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Update GZRW SET NEXTTIME=:NEXTTIME,LASTTIME =:LASTTIME,RUNFLAG=0,RWZT=:RWZT,RUNRESULT=:MSG  where RWID=:RWID";
                    cmd.Parameters.Add(new SqlParameter(":NEXTTIME", _nextTime));
                    cmd.Parameters.Add(new SqlParameter(":LASTTIME", _startTime));
                    cmd.Parameters.Add(new SqlParameter(":RWZT", Convert.ToDecimal(flag)));
                    cmd.Parameters.Add(new SqlParameter(":MSG", "任务正常执行完毕！"));
                    cmd.Parameters.Add(new SqlParameter(":RWID", decimal.Parse(_Rwid)));
                    cmd.ExecuteScalar();
                }
                catch (Exception e)
                {
                    string _log = string.Format("写入任务{1}结果时出现错误：{0}", e.Message, _Rwid);
                    LogWriter.WriteSystemLog(_log, "ERROR");
                    return false;
                }

                try
                {
                    cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into gzrw_rz (rzid,rwid,rwmc,runtime,runflag,runresult) values (SEQ_YW.NEXTVAL,:RWID,'',sysdate,0,:RUNRESULT)";
                    cmd.Parameters.Add(new SqlParameter(":RWID", decimal.Parse(_Rwid)));
                    cmd.Parameters.Add(new SqlParameter(":RUNRESULT", "任务正常执行完毕！"));
                    cmd.ExecuteScalar();
                }
                catch (Exception e)
                {
                    string _log = string.Format("写入任务{1}日志表时出现错误：{0}", e.Message, _Rwid);
                    LogWriter.WriteSystemLog(_log, "ERROR");
                    return false;
                }

                cn.Close();
            }
            return true;
        }

        public static bool WriteErrorResult(string _Rwid, DateTime _startTime, DateTime _nextTime, string ErrorMsg)
        {
            return WriteErrorResultSetRunFlag(_Rwid, _startTime, _nextTime, ErrorMsg, 0);
        }

        public static bool WriteErrorResultSetRunFlag(string _Rwid, DateTime _startTime, DateTime _nextTime, string ErrorMsg, int flag)
        {
            //清除执行状态，并写入执行错误结果，设置下次执行时间                        
            SqlCommand cmd;
            string _newmsg = (ErrorMsg.Length > 2000) ? ErrorMsg.Substring(0, 2000) : ErrorMsg;
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlTransaction _txn = cn.BeginTransaction();
                try
                {
                    cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Update GZRW SET NEXTTIME=:NEXTTIME,LASTTIME =:LASTTIME,RUNFLAG=9,RWZT=:FLAG,RUNRESULT=:MSG  where RWID=:RWID";
                    cmd.Parameters.Add(new SqlParameter(":NEXTTIME", _nextTime));
                    cmd.Parameters.Add(new SqlParameter(":LASTTIME", _startTime));
                    cmd.Parameters.Add(new SqlParameter(":FLAG", Convert.ToDecimal(flag)));
                    cmd.Parameters.Add(new SqlParameter(":MSG", "任务执行失败！"));
                    cmd.Parameters.Add(new SqlParameter(":RWID", decimal.Parse(_Rwid)));
                    cmd.ExecuteScalar();
                }
                catch (Exception e)
                {
                    string _log = string.Format("写入任务{1}结果时出现错误：{0}", e.Message, _Rwid);
                    LogWriter.WriteSystemLog(_log, "ERROR");
                    _txn.Rollback();
                    return false;
                }

                try
                {
                    cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into gzrw_rz (rzid,rwid,rwmc,runtime,runflag,runresult) values (SEQ_YW.NEXTVAL,:RWID,'',sysdate,9,:RUNRESULT)";
                    cmd.Parameters.Add(new SqlParameter(":RWID", decimal.Parse(_Rwid)));
                    cmd.Parameters.Add(new SqlParameter(":RUNRESULT", _newmsg));
                    cmd.ExecuteScalar();
                }
                catch (Exception e)
                {
                    string _log = string.Format("写入任务{1}日志表时出现错误：{0}", e.Message, _Rwid);
                    LogWriter.WriteSystemLog(_log, "ERROR");
                    _txn.Rollback();
                    return false;
                }

                _txn.Commit();
                cn.Close();
            }
            return true;
        }

        public static void WriteTaskLog(string _Rwid, int state, string _msg)
        {
            SqlCommand cmd;

            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlTransaction txn = cn.BeginTransaction();
                try
                {
                    string _newmsg = (_msg.Length > 2000) ? _msg.Substring(0, 2000) : _msg;
                    cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into gzrw_rz (rzid,rwid,rwmc,runtime,runflag,runresult) values (SEQ_YW.NEXTVAL,:RWID,'',sysdate,:STATE,:RUNRESULT)";
                    cmd.Parameters.Add(new SqlParameter(":RWID", decimal.Parse(_Rwid)));
                    cmd.Parameters.Add(new SqlParameter(":STATE", Convert.ToDecimal(state)));
                    cmd.Parameters.Add(new SqlParameter(":RUNRESULT", _newmsg));
                    cmd.ExecuteScalar();
                    txn.Commit();
                }
                catch (Exception e)
                {
                    string _log = string.Format("写入任务{1}日志表时出现错误：{0}", e.Message, _Rwid);
                    LogWriter.WriteSystemLog(_log, "ERROR");
                    txn.Rollback();
                }


                cn.Close();
            }

        }






    }
}
