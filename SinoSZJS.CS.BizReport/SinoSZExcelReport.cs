using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using SinoSZJS.Base.Misc;
using SinoSZJS.Base.Authorize;
using SinoSZJS.DataAccess;
using SinoSZJS.Base.Report;
using System.Data.SqlClient;
using SinoSZJS.DataAccess.Sql;

namespace SinoSZJS.CS.BizReport
{
    /// <summary>
    /// �пƸ���   Excelģ�屨����
    /// </summary>
    public class SinoSZExcelReport
    {
        /// <summary>
        /// ���ɱ���
        /// </summary>
        /// <param name="_reportItem"></param>
        /// <param name="_sDate"></param>
        /// <param name="_eDate"></param>
        /// <returns></returns>
        public static bool CreateReport(MD_ReportName _reportItem, DateTime _sDate, DateTime _eDate, string _dwdm)
        {
            DataTable _rData = null, _mxData = new DataTable(), _cellData = null;
            DataSet _hmcData;

            #region ���ɱ���ͳ������
            if (!CreateReportData(_reportItem.ReportName, _sDate, _eDate, _dwdm))
            {
                LogWriter.WriteSystemLog(string.Format("���ɱ���������({0},{1},{2},{3})", _reportItem.ReportName, _dwdm, _sDate, _eDate), "ERROR");
                return false;
            }
            #endregion
            #region ȡ����ͳ�ƽ������
            if (!GetReportData(_reportItem.ReportName, _sDate, _eDate, _dwdm, out _rData))
            {
                LogWriter.WriteSystemLog(string.Format("ȡ��������ʱ��������({0},{1},{2},{3})", _reportItem.ReportName, _dwdm, _sDate, _eDate), "ERROR");
                return false;
            }
            #endregion

            #region ȡ����������/�еĽ������
            if (!GetReportSpecialData(_reportItem.ReportName, _sDate, _eDate, _dwdm, out _cellData))
            {
                LogWriter.WriteSystemLog(string.Format("ȡ��������������������ʱ��������({0},{1},{2},{3})", _reportItem.ReportName, _dwdm, _sDate, _eDate), "ERROR");
                return false;
            }
            #endregion

            #region ȡ������
            if (!GetReportDefine(_reportItem.ReportName, _sDate, _eDate, _dwdm, out _hmcData))
            {
                LogWriter.WriteSystemLog(string.Format("ȡ����������ʱ��������({0},{1},{2},{3})", _reportItem.ReportName, _dwdm, _sDate, _eDate), "ERROR");
                return false;
            }
            #endregion

            #region ȡ������ϸ����
            if (!GetReportMXData(_reportItem.ReportName, _sDate, _eDate, _dwdm, out _mxData))
            {
                LogWriter.WriteSystemLog(string.Format("ȡ������ϸ����ʱ��������({0},{1},{2},{3})", _reportItem.ReportName, _dwdm, _sDate, _eDate), "ERROR");
                return false;
            }
            #endregion

            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlTransaction txn = cn.BeginTransaction();
                try
                {
                    //��ʼ���ɱ���������ORALCE��CLOB�ֶ�
                    ProcessExcelReport oReport = new ProcessExcelReport();
                    oReport.ReportTemplate = Utils.ExeDir + string.Format(@"ReportTemp\{0}.xlsx", _reportItem.ReportName);
                    oReport.ReportTitle = _reportItem.ReportTitle;
                    oReport.DataTemplate = "\\TestData.xml"; //��ʱ����
                    oReport.ReportIndex = 1;
                    oReport.ExportFormat = "HTML";
                    oReport.OutputCache = Utils.ExeDir + @"OutputCache";

                    string excelReportFile, htmReportFile, sMessage;
                    string _bbid = GetReportID(_reportItem.ReportName, _sDate, _eDate, _dwdm);

                    if (!oReport.CreateReportFiles(_bbid, _rData, _cellData, _mxData, _hmcData, out excelReportFile, out htmReportFile, out sMessage))
                    {
                        //ShowError(sMessage,true);
                    }
                    else
                    {
                        //��HTML�ļ�����CLOB�ֶ�
                        //��EXCELд��BLOG�ֶ�
                        //StreamReader sr = new StreamReader(htmReportFile, System.Text.Encoding.Default);
                        string strHtml = "";//sr.ReadToEnd();
                        //sr.Close();
                        FileStream fs = new FileStream(excelReportFile, FileMode.OpenOrCreate);
                        byte[] blob = new byte[fs.Length];
                        fs.Read(blob, 0, blob.Length);
                        fs.Close();
                        SqlCommand _cmd = new SqlCommand();
                        _cmd.CommandText = @"update TJ_ZDYBBFJXXB set TBR = :TBR,TBRQ = sysdate,TBDW=:TBDW,BBZT='δ���',BBJG_C=:HTMFILE,BBJG_B=:EXEFILE where 
                                                                        BBMC = :BBMC AND TJDW=:TJDW AND KSRQ=:KSRQ AND JZRQ=:JZRQ";
                        _cmd.CommandType = CommandType.Text;
                        _cmd.Parameters.Add(":TBR", SinoUserCtx.CurUser.UserName);
                        _cmd.Parameters.Add(":TBDW", SinoUserCtx.CurUser.QxszDWMC);
                        //_cmd.Parameters.Add(new SqlParameter(":HTMFILE", SqlDbType.Clob, strHtml.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, strHtml));
                        //_cmd.Parameters.Add(new SqlParameter(":EXEFILE", SqlDbType.Blob, blob.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, blob));
                        _cmd.Parameters.Add(":BBMC", _reportItem.ReportName);
                        _cmd.Parameters.Add(":TJDW", _dwdm);
                        _cmd.Parameters.Add(":KSRQ", _sDate);
                        _cmd.Parameters.Add(":JZRQ", _eDate);
                        _cmd.Connection = cn;
                        int _updateflag = _cmd.ExecuteNonQuery();
                        txn.Commit();

#if ! DEBUG
						FileInfo oFInfo = new FileInfo(excelReportFile);
						if (oFInfo.Exists)
							File.Delete(excelReportFile);

                        //oFInfo = new FileInfo(htmReportFile);
                        //if (oFInfo.Exists)
                        //    File.Delete(htmReportFile);
#endif
                        return true;

                    }

                }
                catch (Exception e)
                {
                    txn.Rollback();
                    string _eStr = string.Format(" ϵͳ���ɱ�������ʱ��������\n  Error Message:{0}", e.Message);
                    LogWriter.WriteSystemLog(_eStr, "ERROR");
                    return false;
                }
            }
            return true;
        }










        /// <summary>
        /// ���ɱ���ͳ������
        /// </summary>
        /// <param name="_reportName"></param>
        /// <param name="_sDate"></param>
        /// <param name="_eDate"></param>
        /// <param name="_dwdm"></param>
        /// <returns></returns>
        private static bool CreateReportData(string _reportName, DateTime _sDate, DateTime _eDate, string _dwdm)
        {
            int _ret = 0;
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                try
                {
                    SqlCommand _cmd = new SqlCommand();
                    _cmd.CommandText = "zhtj_zdybb.bb";
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.Add("strtjdw", _dwdm);
                    _cmd.Parameters.Add("dtbegin_p", _sDate);
                    _cmd.Parameters.Add("dtend_p", _eDate);
                    _cmd.Parameters.Add("strbbmc", _reportName);
                    SqlParameter _p1 = _cmd.Parameters.Add("recret", SqlDbType.Decimal);
                    _p1.Direction = ParameterDirection.Output;
                    _cmd.Connection = cn;
                    _cmd.ExecuteNonQuery();
                    _ret = int.Parse(_p1.Value.ToString());
                    cn.Close();
                    return (_ret == 0);

                }
                catch (Exception e)
                {
                    string _emsg = string.Format("����ͳ�Ʊ������ɱ���ͳ�����ݣ�ʱ��������reportName={0} _dwdm={1} DATE={2} - {3} ", _reportName, _dwdm, _sDate, _eDate);
                    _emsg += string.Format(" \n ������Ϣ��{0}", e.Message);
                    LogWriter.WriteSystemLog(_emsg, "ERROR");
                    return false;
                }
            }
        }

        /// <summary>
        /// ȡ����ͳ�ƽ������
        /// </summary>
        /// <param name="_reportName"></param>
        /// <param name="_sDate"></param>
        /// <param name="_eDate"></param>
        /// <param name="_dwdm"></param>
        /// <param name="_rData"></param>
        /// <returns></returns>
        private static bool GetReportData(string _reportName, DateTime _sDate, DateTime _eDate, string _dwdm, out DataTable _dt)
        {
            _dt = new DataTable();

            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                try
                {
                    SqlCommand _cmd = new SqlCommand();
                    _cmd.CommandText = "zhtj_zdybb.getbb";
                    _cmd.Connection = cn;
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.Add("strtjdw", _dwdm);
                    _cmd.Parameters.Add("dtbegin_p", _sDate);
                    _cmd.Parameters.Add("dtend_p", _eDate);
                    _cmd.Parameters.Add("strbbmc", _reportName);
                    //_cmd.Parameters.Add("recret", SqlDbType.RefCursor, DBNull.Value, ParameterDirection.Output);

                    SqlDataAdapter _adapter = new SqlDataAdapter(_cmd);
                    _adapter.Fill(_dt);
                    cn.Close();
                    return true;

                }
                catch (Exception e)
                {
                    string _emsg = string.Format("����ͳ�Ʊ���(ȡ����ͳ�ƽ������)ʱ��������reportName={0} _dwdm={1} DATE={2} - {3} ", _reportName, _dwdm, _sDate, _eDate);
                    _emsg += string.Format(" \n ������Ϣ��{0}", e.Message);
                    LogWriter.WriteSystemLog(_emsg, "ERROR");
                    return false;
                }
            }
        }

        /// <summary>
        /// ȡͳ�Ʊ���������/�����н������
        /// </summary>
        /// <param name="_reportName"></param>
        /// <param name="_sDate"></param>
        /// <param name="_eDate"></param>
        /// <param name="_dwdm"></param>
        /// <param name="_cellData"></param>
        /// <returns></returns>
        private static bool GetReportSpecialData(string _reportName, DateTime _sDate, DateTime _eDate, string _dwdm, out DataTable _dt)
        {
            _dt = new DataTable();
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                try
                {
                    SqlCommand _cmd = new SqlCommand();
                    _cmd.Connection = cn;
                    _cmd.CommandText = "ZHTJ_ZDYBB.GetBB_DYG";
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.Add("strtjdw", _dwdm);
                    _cmd.Parameters.Add("dtbegin_p", _sDate);
                    _cmd.Parameters.Add("dtend_p", _eDate);
                    _cmd.Parameters.Add("strbbmc", _reportName);
                    //_cmd.Parameters.Add("recret", SqlDbType.RefCursor, DBNull.Value, ParameterDirection.Output);

                    SqlDataAdapter _adapter = new SqlDataAdapter(_cmd);
                    _adapter.Fill(_dt);
                    cn.Close();
                    return true;
                }
                catch (Exception e)
                {
                    string _emsg = string.Format("����ͳ�Ʊ���(ȡ����ͳ�ƽ�������С�������)ʱ��������reportName={0} _dwdm={1} DATE={2} - {3} ", _reportName, _dwdm, _sDate, _eDate);
                    _emsg += string.Format(" \n ������Ϣ��{0}", e.Message);
                    LogWriter.WriteSystemLog(_emsg, "ERROR");
                    return false;
                }
            }
        }

        /// <summary>
        /// ȡ����������
        /// </summary>
        /// <param name="_reportName"></param>
        /// <param name="_sDate"></param>
        /// <param name="_eDate"></param>
        /// <param name="_dwdm"></param>
        /// <param name="_hmcData"></param>
        /// <returns></returns>
        private static bool GetReportDefine(string _reportName, DateTime _sDate, DateTime _eDate, string _dwdm, out DataSet _ds)
        {
            _ds = new DataSet();
            try
            {
                using (SqlConnection cn = SqlHelper.OpenConnection())
                {
                    //ȡ����
                    DataTable _dt = new DataTable("REPORT_DEFINE");
                    SqlCommand _cmd = new SqlCommand();
                    _cmd.Connection = cn;
                    _cmd.CommandText = "select * from TJ_ZDYBBMCB a where a.BBMC =:BBMC";
                    _cmd.CommandType = CommandType.Text;
                    _cmd.Parameters.Add(":BBMC", _reportName);
                    SqlDataAdapter _adapter = new SqlDataAdapter(_cmd);
                    _adapter.Fill(_dt);
                    _ds.Tables.Add(_dt);

                    //ȡ�ж���
                    DataTable _coldt = new DataTable("COL_DEFINE");
                    _cmd = new SqlCommand();
                    _cmd.Connection = cn;
                    _cmd.CommandText = "select * from TJ_ZDYBBDYB_DTLJL a where a.bbmc =:BBMC and TJDW = :TJDW and KSRQ = :KSRQ and JZRQ = :JZRQ order by LX";
                    _cmd.CommandType = CommandType.Text;
                    _cmd.Parameters.Add(":BBMC", _reportName);
                    _cmd.Parameters.Add(":TJDW", _dwdm);
                    _cmd.Parameters.Add(":KSRQ", _sDate);
                    _cmd.Parameters.Add(":JZRQ", _eDate);

                    _adapter = new SqlDataAdapter(_cmd);
                    _adapter.Fill(_coldt);
                    _ds.Tables.Add(_coldt);

                    //ȡ�ж���
                    DataTable _rowdt = new DataTable("ROW_DEFINE");
                    _cmd = new SqlCommand();
                    _cmd.Connection = cn;
                    _cmd.CommandText = "select * from TJ_ZDYBBDYB_DTHJL a where a.bbmc =:BBMC and TJDW = :TJDW and KSRQ = :KSRQ and JZRQ = :JZRQ order by HX";
                    _cmd.CommandType = CommandType.Text;
                    _cmd.Parameters.Add(":BBMC", _reportName);
                    _cmd.Parameters.Add(":TJDW", _dwdm);
                    _cmd.Parameters.Add(":KSRQ", _sDate);
                    _cmd.Parameters.Add(":JZRQ", _eDate);

                    _adapter = new SqlDataAdapter(_cmd);
                    _adapter.Fill(_rowdt);
                    _ds.Tables.Add(_rowdt);
                    cn.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                string _emsg = string.Format("����ͳ�Ʊ���(ȡ����������)ʱ��������reportName={0} _dwdm={1} DATE={2} - {3} ", _reportName, _dwdm, _sDate, _eDate);
                _emsg += string.Format(" \n ������Ϣ��{0}", e.Message);
                LogWriter.WriteSystemLog(_emsg, "ERROR");
                return false;
            }
        }


        /// <summary>
        /// ȡ������ϸ����
        /// </summary>
        /// <param name="_reportName"></param>
        /// <param name="_sDate"></param>
        /// <param name="_eDate"></param>
        /// <param name="_dwdm"></param>
        /// <param name="_mxData"></param>
        /// <returns></returns>
        private static bool GetReportMXData(string _reportName, DateTime _sDate, DateTime _eDate, string _dwdm, out DataTable _dt)
        {
            _dt = new DataTable();
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                try
                {
                    SqlCommand _cmd = new SqlCommand();
                    _cmd.Connection = cn;
                    _cmd.CommandText = "select hx,lx from TJ_ZDYBBJLB_MX where BBMC=:BBMC AND TJDW=:TJDW AND KSRQ=:KSRQ and JZRQ=:JZRQ and MX is not null";
                    _cmd.CommandType = CommandType.Text;
                    _cmd.Parameters.Add(":BBMC", _reportName);
                    _cmd.Parameters.Add(":TJDW", _dwdm);
                    _cmd.Parameters.Add(":KSRQ", _sDate);
                    _cmd.Parameters.Add(":JZRQ", _eDate);

                    SqlDataAdapter _adapter = new SqlDataAdapter(_cmd);
                    _adapter.Fill(_dt);
                    cn.Close();
                    return true;
                }
                catch (Exception e)
                {
                    string _emsg = string.Format("����ͳ�Ʊ���(ȡ������ϸ����)ʱ��������reportName={0} _dwdm={1} DATE={2} - {3} ", _reportName, _dwdm, _sDate, _eDate);
                    _emsg += string.Format(" \n ������Ϣ��{0}", e.Message);
                    LogWriter.WriteSystemLog(_emsg, "ERROR");
                    return false;
                }
            }
        }

        /// <summary>
        /// �����ɵı���ID
        /// </summary>
        /// <param name="_reportName"></param>
        /// <param name="_sDate"></param>
        /// <param name="_eDate"></param>
        /// <param name="_dwdm"></param>
        /// <returns></returns>
        private static string GetReportID(string _reportName, DateTime _sDate, DateTime _eDate, string _dwdm)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                try
                {
                    SqlCommand _cmd = new SqlCommand();
                    _cmd.Connection = cn;
                    _cmd.CommandText = "select ID from TJ_ZDYBBFJXXB where BBMC=:BBMC AND TJDW=:TJDW AND KSRQ=:KSRQ and JZRQ=:JZRQ ";
                    _cmd.CommandType = CommandType.Text;
                    _cmd.Parameters.Add(":BBMC", _reportName);
                    _cmd.Parameters.Add(":TJDW", _dwdm);
                    _cmd.Parameters.Add(":KSRQ", _sDate);
                    _cmd.Parameters.Add(":JZRQ", _eDate);
                    object _obj = _cmd.ExecuteScalar();
                    cn.Close();
                    return (_obj == null) ? "" : _obj.ToString();
                }
                catch (Exception e)
                {
                    string _emsg = string.Format("����ͳ�Ʊ���(�����ɵı���ID)ʱ��������reportName={0} _dwdm={1} DATE={2} - {3} ", _reportName, _dwdm, _sDate, _eDate);
                    _emsg += string.Format(" \n ������Ϣ��{0}", e.Message);
                    LogWriter.WriteSystemLog(_emsg, "ERROR");
                    return "";
                }
            }
        }

    }
}
