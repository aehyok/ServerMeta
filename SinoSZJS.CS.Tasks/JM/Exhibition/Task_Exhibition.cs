using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSZServerBase;
using SinoSZJS.Base.Misc;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Web.Script.Serialization;
using Oracle.DataAccess.Client;
using SinoSZJS.DataAccess;
using SinoSZJS.DataAccess.Sql;

namespace SinoSZJS.CS.Tasks.JM.Exhibition
{
    class Task_Exhibition : Task_Base
    {

        #region 成员变量

        private SqlConnection _cn = new SqlConnection();
        private int j = 0;

        #endregion

        #region 通用函数（主程序）

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="rwid">任务ID</param>
        /// <param name="param">参数</param>
        public Task_Exhibition(string rwid, string param)
        {
            _Rwid = rwid;
            string stepstr = StrUtils.GetMetaByName("STEP", param);	//STEP: 任务时间间隔

            try
            {
                _TimeStep = int.Parse(stepstr);
            }
            catch
            {
                _TimeStep = 1;
            }

            string connStr = StrUtils.GetMetaByName("CONNECTSTR", param); //CONNECTSTR：对方数据库相关信息
            _cn.ConnectionString = connStr;

        }

        /// <summary>
        /// 主程序
        /// </summary>
        public override void ThreadProc()
        {
            int ret = 0;
            WriteRWState();
            DataTable tableDt = new DataTable();
            DataTable chartDt1 = new DataTable();
            DataTable chartDt2 = new DataTable();

            try
            {
                tableDt = GetTableData("JM_YTJ_执法概况简表");
                chartDt1 = GetChartData("QD页面_执法概况行政", out ret);

                chartDt2 = GetChartData("QD页面_执法概况刑事", out ret);

                _cn.Open();
                using (_cn)
                {
                    //传输表格数据
                    TransmitTableData(tableDt);
                    //传输3年对比图数据
                    TransmitChartData(chartDt1, "ajsj3", _cn);
                    TransmitChartData(chartDt2, "ajsj4", _cn);

                    //写任务成功结果
                    if (ret == 0)
                        WriteResult();
                }
            }
            catch (Exception ex)
            {
                LogWriter.WriteSystemLog(String.Format("江门任务失败！{0}", ex.Message), "ERROR");
            }

        }

        #endregion

        #region 获取数据

        #region 表格

        /// <summary>
        /// 获取表格数据
        /// </summary>
        /// <param name="reportName">报表名称</param>
        /// <returns>表格数据</returns>
        private DataTable GetTableData(string reportName)
        {
            DataTable dt = new DataTable();
            const string dwdm = "846800000030";
            DateTime sdate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);//DateTime.Parse(String.Format("{0}/{1}/1", DateTime.Now.Year, DateTime.Now.Month));
            DateTime edate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);

            try
            {
                //创建表格数据
                CreateTableData(dwdm, sdate, edate, reportName);
                //得到表格数据
                dt = GetData(dwdm, sdate, edate, reportName);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("获取表格数据时出错！{0}", ex.Message));
            }
        }

        /// <summary>
        /// 创建表格数据
        /// </summary>
        /// <param name="dwdm">单位代码</param>
        /// <param name="sdate">开始日期</param>
        /// <param name="edate">结束日期</param>
        /// <param name="reportName">报表名称</param>
        private void CreateTableData(string dwdm, DateTime sdate, DateTime edate, string reportName)
        {
            try
            {
                using (SqlConnection cn = SqlHelper.OpenConnection())
                {

                    SqlCommand cmd = new SqlCommand
                    {
                        CommandText = "tj_zdybb_yyddjz.Temp_ZDYBB",
                        CommandType = CommandType.StoredProcedure,
                        Connection = cn
                    };

                    SqlParameter p1 = cmd.Parameters.Add("strTJDW", SqlDbType.VarChar);
                    p1.Value = dwdm;

                    SqlParameter p2 = cmd.Parameters.Add("dtbegin_p", SqlDbType.Date);
                    p2.Value = sdate;

                    SqlParameter p3 = cmd.Parameters.Add("dtedate_p", SqlDbType.Date);
                    p3.Value = edate;

                    SqlParameter p4 = cmd.Parameters.Add("strbbmc", SqlDbType.VarChar);
                    p4.Value = reportName;

                    SqlParameter p5 = cmd.Parameters.Add("nvalidhours", SqlDbType.Decimal);
                    p5.Value = 12;

                    SqlParameter p6 = cmd.Parameters.Add("nret", SqlDbType.Decimal);
                    p6.Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    var ret = p6.Value.ToString();
                    cn.Close();
                    if (ret == "1")
                        throw new Exception("预生成报表失败！");
                }
            }
            catch (OracleException ex)
            {
                throw new Exception(
                    string.Format(
                        "预生成数据时出错！存储过程为：tj_zdybb_yyddjz.Temp_ZDYBB,DWDM={0},sdateDATE={1},edateDATE={2},REPORTNAMES={3},错误信息为：{4}",
                        dwdm, sdate, edate, reportName, ex.Message));
            }
            catch (Exception e)
            {
                throw new Exception(
                string.Format(
                    "预生成数据时出错！存储过程为：tj_zdybb_yyddjz.Temp_ZDYBB,DWDM={0},sdateDATE={1},edateDATE={2},REPORTNAMES={3},错误信息为：{4}",
                    dwdm, sdate, edate, reportName, e.Message));
            }
        }

        #endregion

        #region 三年对比图

        /// <summary>
        /// 获取三年对比图的数据
        /// </summary>
        /// <param name="reportName">报表名称</param>
        /// <param name="ret">返回值</param>
        /// <returns></returns>
        private DataTable GetChartData(string reportName, out int ret)
        {
            //获取三年的数据
            const string dwdm = "846800000030";
            int year = DateTime.Now.Year;
            DateTime sdate = new DateTime(year, 1, 1);
            DateTime edate = sdate.AddYears(1).AddSeconds(-1);
            DataTable chartData;
            try
            {
                DataTable sourceTable = GetSourceData(dwdm, sdate, edate, reportName, out ret);
                chartData = new DataTable(sourceTable.TableName);
                chartData.Columns.Add("Year", typeof(string));
                chartData.Columns.Add("YF", typeof(string));
                chartData.Columns.Add("GS", typeof(decimal));
                chartData.Columns.Add("AZ", typeof(decimal));
                chartData.Columns.Add("SS", typeof(decimal));
                chartData.Columns.Add("ID", typeof(decimal));
                for (int i = 0; i < 3; i++)
                {
                    AddDataToResultTable(ref chartData, sourceTable, year - i);
                }
                j = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("获取3年对比图数据时出错！{0}", ex.Message));
            }
            return chartData;

        }

        /// <summary>
        /// 获取数据源（三年对比图）
        /// </summary>
        /// <param name="dwdm">单位代码</param>
        /// <param name="sdate">开始日期</param>
        /// <param name="edate">结束日期</param>
        /// <param name="reportName">报表名称</param>
        /// <param name="ret">返回值</param>
        /// <returns></returns>
        private DataTable GetSourceData(string dwdm, DateTime sdate, DateTime edate, string reportName, out int ret)
        {
            ret = 0;
            DataTable ds = new DataTable("Report");
            try
            {
                CreateSourceData(dwdm, sdate, edate, reportName);
                //是行定义的报表不需要HMC列
                ds = GetData(dwdm, sdate, edate, reportName);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("3年对比图中获取数据源数据时出错！{0}", ex.Message));
            }
            return ds;
        }

        /// <summary>
        /// 创建三年对比图
        /// </summary>
        /// <param name="dwdm">单位代码</param>
        /// <param name="sdate">开始日期</param>
        /// <param name="edate">结束日期</param>
        /// <param name="reportName">报表名称</param>
        private void CreateSourceData(string dwdm, DateTime sdate, DateTime edate, string reportName)
        {
            try
            {
                using (SqlConnection cn = SqlHelper.OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        CommandText = "zhtj_zdybb.bb_checkvalidtime",
                        CommandType = CommandType.StoredProcedure,
                        Connection = cn
                    };

                    SqlParameter p1 = cmd.Parameters.Add("strtjdw", SqlDbType.VarChar);
                    p1.Value = dwdm;

                    SqlParameter p2 = cmd.Parameters.Add("dtbegin_p", SqlDbType.Date);
                    p2.Value = sdate;

                    SqlParameter p3 = cmd.Parameters.Add("dtend_p", SqlDbType.Date);
                    p3.Value = edate;

                    SqlParameter p4 = cmd.Parameters.Add("strbbmc", SqlDbType.VarChar);
                    p4.Value = reportName;

                    SqlParameter p5 = cmd.Parameters.Add("nvalidhours", SqlDbType.Decimal);
                    p5.Value = decimal.Parse("24");

                    SqlParameter p6 = cmd.Parameters.Add("nret", SqlDbType.Decimal);
                    p6.Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    var ret = p6.Value.ToString();
                    cn.Close();
                    if (ret != "0")
                    {
                        throw new Exception("预生成报表失败！");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(
                  string.Format(
                      "预生成数据时出错！存储过程为：zhtj_zdybb.bb_checkvalidtime,DWDM={0},sdateDATE={1},edateDATE={2},REPORTNAMES={3},错误信息为：{4}",
                      dwdm, sdate, edate, reportName, e.Message));
            }
        }

        /// <summary>
        /// 组装3年图数据
        /// </summary>
        /// <param name="resultTable">结果集</param>
        /// <param name="sourceTable">数据源</param>
        /// <param name="year">年</param>
        private void AddDataToResultTable(ref DataTable resultTable, DataTable sourceTable, int year)
        {
            try
            {
                for (int i = 1; i < 13; i++, j++)
                {
                    //从源数据表中找到指定年指定月的行
                    DataRow sourceRow = sourceTable.Rows.Find(i);
                    DataRow dr = resultTable.NewRow();
                    if (sourceRow != null)
                    {
                        decimal gs;
                        decimal ss;
                        decimal az;
                        if (year == DateTime.Now.Year)
                        {
                            gs = sourceRow.IsNull("L3") ? 0m : (decimal)sourceRow["L3"];
                            ss = sourceRow.IsNull("L6") ? 0m : (decimal)sourceRow["L6"];
                            az = sourceRow.IsNull("L9") ? 0m : (decimal)sourceRow["L9"];
                        }
                        else if (year == DateTime.Now.Year - 1)
                        {
                            gs = sourceRow.IsNull("L3") ? 0m : (decimal)sourceRow["L2"];
                            ss = sourceRow.IsNull("L6") ? 0m : (decimal)sourceRow["L5"];
                            az = sourceRow.IsNull("L9") ? 0m : (decimal)sourceRow["L8"];
                        }
                        else
                        {
                            gs = sourceRow.IsNull("L3") ? 0m : (decimal)sourceRow["L1"];
                            ss = sourceRow.IsNull("L6") ? 0m : (decimal)sourceRow["L4"];
                            az = sourceRow.IsNull("L9") ? 0m : (decimal)sourceRow["L7"];
                        }
                        dr["GS"] = Math.Round(gs, 0);
                        dr["SS"] = Math.Round(ss, 0);
                        dr["AZ"] = Math.Round(az, 0);
                        dr["ID"] = j;
                    }
                    else
                    {
                        dr["GS"] = 0m;
                        dr["SS"] = 0m;
                        dr["AZ"] = 0m;
                    }
                    dr["Year"] = year.ToString();
                    dr["YF"] = string.Format("{0}月", i);
                    resultTable.Rows.Add(dr);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("从数据源填充指定数据时出错！{0}", ex.Message));
            }
        }

        #endregion

        #region 通用

        /// <summary>
        /// 获取数据（通用）
        /// </summary>
        /// <param name="dwdm"></param>
        /// <param name="sdate"></param>
        /// <param name="edate"></param>
        /// <param name="reportName"></param>
        /// <returns></returns>
        private DataTable GetData(string dwdm, DateTime sdate, DateTime edate, string reportName)
        {
            DataTable dt = new DataTable("ReportData");
            try
            {
                using (SqlConnection cn = SqlHelper.OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand
                              {
                                  CommandText = "zhtj_zdybb.getbb",
                                  CommandType = CommandType.StoredProcedure,
                                  Connection = cn
                              };

                    SqlParameter p1 = cmd.Parameters.Add("strtjdw", SqlDbType.VarChar);
                    p1.Value = dwdm;

                    SqlParameter p2 = cmd.Parameters.Add("dtbegin_p", SqlDbType.Date);
                    p2.Value = sdate;

                    SqlParameter p3 = cmd.Parameters.Add("dtedate_p", SqlDbType.Date);
                    p3.Value = edate;

                    SqlParameter p4 = cmd.Parameters.Add("strbbmc", SqlDbType.VarChar);
                    p4.Value = reportName;

                    //cmd.Parameters.Add("recret", SqlDbType.RefCursor, DBNull.Value, ParameterDirection.Output);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);

                    dt.PrimaryKey = new DataColumn[] { dt.Columns["HX"] };
                }
            }
            catch (Exception e)
            {
                throw new Exception(
               string.Format(
                   "获取预生成数据时出错！存储过程为：zhtj_zdybb.getbb,DWDM={0},sdateDATE={1},edateDATE={2},REPORTNAMES={3},错误信息为：{4}",
                   dwdm, sdate, edate, reportName, e.Message));
            }
            return dt;
        }

        #endregion

        #endregion

        #region 传输数据

        private const string Sql_Insert = "insert into ajsj1 (n,v1,v2,v3,v4,v5,v6,v7,v8,v9) values(@name,@value1,@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9)";
        /// <summary>
        /// 传输表格数据
        /// </summary>
        /// <param name="dt">表格数据</param>
        private void TransmitTableData(DataTable dt)
        {
            const string sqlStr = "delete from ajsj1";
            try
            {
                SqlCommand cmd = new SqlCommand(sqlStr, _cn);
                cmd.ExecuteNonQuery();

                foreach (DataRow dr in dt.Rows)
                {
                    SqlCommand ncmd = new SqlCommand(Sql_Insert, _cn);
                    string name = "";
                    if (dr["HX"].ToString() == "1" || dr["HX"].ToString() == "2" || dr["HX"].ToString() == "3" ||
                        dr["HX"].ToString() == "7")
                    {
                        switch (dr["HX"].ToString())
                        {
                            case "1":
                                name = "'刑事立案',";
                                break;
                            case "2":
                                name= "'移送起诉',";
                                break;
                            case "3":
                                name= "'行政立案',";
                                break;
                            case "7":
                                name= "'行政结案',";
                                break;
                        }
                        ncmd.Parameters.Add(new SqlParameter("@name", name));
                        ncmd.Parameters.Add(new SqlParameter("@value1", (Convert.ToString(dr["L1"]) == ""
                                      ? "0.0"
                                      : Convert.ToDouble(dr["L1"]).ToString("0.00"))));
                        ncmd.Parameters.Add(new SqlParameter("@value2", (Convert.ToString(dr["L2"]) == ""
                                      ? "0.0"
                                      : Convert.ToDouble(dr["L2"]).ToString("0.00"))));
                        ncmd.Parameters.Add(new SqlParameter("@value3", (Convert.ToString(dr["L3"]) == ""
                                      ? "0.0"
                                      : Convert.ToDouble(dr["L3"]).ToString("0.00"))));
                        ncmd.Parameters.Add(new SqlParameter("@value4", (Convert.ToString(dr["L4"]) == ""
                                      ? "0.0"
                                      : Convert.ToDouble(dr["L4"]).ToString("0.00"))));
                        ncmd.Parameters.Add(new SqlParameter("@value5", (Convert.ToString(dr["L5"]) == ""
                                      ? "0.0"
                                      : Convert.ToDouble(dr["L5"]).ToString("0.00"))));
                        ncmd.Parameters.Add(new SqlParameter("@value6", (Convert.ToString(dr["L6"]) == ""
                                      ? "0.0"
                                      : Convert.ToDouble(dr["L6"]).ToString("0.00"))));
                        ncmd.Parameters.Add(new SqlParameter("@value7", (Convert.ToString(dr["L7"]) == ""
                                      ? "0.0"
                                      : Convert.ToDouble(dr["L7"]).ToString("0.00"))));
                        ncmd.Parameters.Add(new SqlParameter("@value8", (Convert.ToString(dr["L8"]) == ""
                                      ? "0.0"
                                      : Convert.ToDouble(dr["L8"]).ToString("0.00"))));
                        ncmd.Parameters.Add(new SqlParameter("@value9", (Convert.ToString(dr["L9"]) == ""
                                      ? "0.0"
                                      : Convert.ToDouble(dr["L9"]).ToString("0.00"))));
                        
                        ncmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("传输表格数据到对方ajsj1表时出错！{0}sql:{1}", ex.Message, sqlStr));
            }
        }

        private const string SQL_TransmitChartData1 = @"Select * from ajsj3";
        private const string SQL_TransmitChartData2 = @"Select * from ajsj4";
        /// <summary>
        /// 传输3年对比图数据
        /// </summary>
        /// <param name="dt">数据</param>
        /// <param name="tableName">目标数据库表名</param>
        /// <param name="cn">连接</param>
        private void TransmitChartData(DataTable dt, string tableName, SqlConnection cn)
        {
            dt.TableName = tableName;
            dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };

            string sqlStr = (tableName == "ajsj3") ? SQL_TransmitChartData1 : SQL_TransmitChartData2;
            SqlDataAdapter thisAdapter = new SqlDataAdapter(sqlStr, cn);
            DataTable newDt = new DataTable();
            thisAdapter.Fill(newDt);
            if (newDt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        newDt.Rows[i][j] = dt.Rows[i][j];
                    }
                }
            }
            else
            {
                newDt = dt;
            }
            SqlCommandBuilder sb = new SqlCommandBuilder(thisAdapter);
            thisAdapter.UpdateCommand = sb.GetUpdateCommand();//更新
            thisAdapter.Update(newDt);
            dt.AcceptChanges();
        }

        #endregion

    }
}
