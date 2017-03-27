using System;
using System.Collections.Generic;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;
using SinoSZJS.Base.Authorize;
using Oracle.DataAccess.Types;
using System.IO;
using SinoSZJS.Base.Report;
using SinoSZJS.Base.Report.ReportGuideLine;
using SinoSZJS.DataAccess;
using SinoSZJS.CS.BizReport.ReportService2008;
using System.Web.Services.Protocols;


namespace SinoSZJS.CS.BizReport
{
    public class OraReportFactroy : IReportFactroy
    {
        #region IReportFactroy Members

        public List<MD_ReportName> GetReportNams(string _reportNames, string _reportType)
        {
            string[] _rNames = _reportNames.Split(',');
            switch (_reportType)
            {
                case "RS报表":
                    return GetRSReportNames(_rNames);

                default:
                    return GetSinoSZDefineReportNames(_rNames);

            }
            return new List<MD_ReportName>();
        }


        public List<MD_ReportItem> GetReports(MD_ReportName _ReportName, string reportType)
        {
            switch (reportType)
            {
                case "RS报表":
                    return GetRSReports(_ReportName);

                default:
                    return GetSinoSZDefineReports(_ReportName);

            }
            return new List<MD_ReportItem>();
        }



        public List<MD_ReportItem> GetReports(DateTime _startDate, DateTime _endDate, List<MD_ReportName> reportItems, string reportType)
        {
            switch (reportType)
            {
                case "RS报表":
                    return GetRsReports(_startDate, _endDate, reportItems);

                default:
                    return GetSinoSZDefineReports(_startDate, _endDate, reportItems);

            }
            return new List<MD_ReportItem>();
        }


        public List<MD_ReportItem> GetReports(MD_ReportName _ReportName, SinoOrganize _Org, string reportType)
        {
            switch (reportType)
            {
                case "RS报表":
                    return GetRsReports(_ReportName, _Org);

                default:
                    return GetSinoSZDefineReports(_ReportName, _Org);

            }
            return new List<MD_ReportItem>();
        }

        public List<MD_ReportItem> GetReports(DateTime _startDate, DateTime _endDate, List<MD_ReportName> _selectReportNames, SinoOrganize _Org, string reportType)
        {
            switch (reportType)
            {
                case "RS报表":
                    return GetRsReports(_startDate, _endDate, _selectReportNames, _Org);

                default:
                    return GetSinoSZDefineReports(_startDate, _endDate, _selectReportNames, _Org);

            }
            return new List<MD_ReportItem>();
        }




        #endregion

        #region 私有方法
        /// <summary>
        /// 取ReportingService格式的报表名称列表
        /// </summary>
        /// <param name="_rNames"></param>
        /// <returns></returns>
        private List<MD_ReportName> GetRSReportNames(string[] _rNames)
        {
            string _fg = "";
            string zjbbstr = "select BBMC,BBJC from BB_BBMCB where BBMC in (";
            foreach (string _rs in _rNames)
            {
                zjbbstr += _fg;
                zjbbstr += string.Format("'{0}'", _rs);
                _fg = ",";
            }
            zjbbstr += ") ORDER BY BBMC";

            List<MD_ReportName> _ret = new List<MD_ReportName>();
            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, zjbbstr, null);

            while (dr.Read())
            {
                MD_ReportName _mitem = new MD_ReportName(dr.IsDBNull(0) ? "" : dr.GetString(0),
                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                        SinoSZReportType.ReportingService);
                _ret.Add(_mitem);
            }
            dr.Close();
            return _ret;
        }

        /// <summary>
        /// 取中科富星自定义报表名称列表
        /// </summary>
        /// <param name="_rNames"></param>
        /// <returns></returns>
        private List<MD_ReportName> GetSinoSZDefineReportNames(string[] _rNames)
        {
            List<MD_ReportName> _ret = new List<MD_ReportName>();
            string _fg = "";
            string zjbbstr = "select BBMC,XSBBMC from tj_zdybbmcb where BBMC in (";
            foreach (string _rs in _rNames)
            {
                zjbbstr += _fg;
                zjbbstr += string.Format("'{0}'", _rs);
                _fg = ",";
            }
            zjbbstr += ") ORDER BY BBMC";


            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, zjbbstr, null);

            while (dr.Read())
            {
                MD_ReportName _mitem = new MD_ReportName(dr.IsDBNull(0) ? "" : dr.GetString(0),
                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                        SinoSZReportType.SinoSZDefineReport);
                _ret.Add(_mitem);
            }
            dr.Close();
            return _ret;
        }

        /// <summary>
        /// 取ReporintService格式的报表列表
        /// </summary>
        /// <param name="_ReportName"></param>
        /// <returns></returns>
        private List<MD_ReportItem> GetRSReports(MD_ReportName _ReportName)
        {
            string _sql = "select t.BBMC,t.BBJC,t.TJDW,t.JGMC,t.NF,t.YF, ";
            _sql += " (select count(a2.bbmc) from bb_bbjlfjxxb a2 where a2.bbmc = t.bbmc AND a2.tjdw = t.TJDW  ";
            _sql += " and a2.nf = t.nf and a2.yf = t.yf and a2.tbrq is not null ) ysh ";
            _sql += " from BB_BBJLXXST t where t.bbmc=:BBMC and T.TJDW = :TJDW";

            OracleParameter[] _param = { new OracleParameter(":BBMC", OracleDbType.Varchar2,50),
                                                new OracleParameter(":TJDW",OracleDbType.Varchar2,12)};
            _param[0].Value = _ReportName.ReportName;
            _param[1].Value = SinoUserCtx.CurUser.CurrentPost.PostDWDM;

            List<MD_ReportItem> _ret = new List<MD_ReportItem>();
            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);

            while (dr.Read())
            {
                MD_ReportName _mitem = new MD_ReportName(dr.IsDBNull(0) ? "" : dr.GetString(0),
                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                        SinoSZReportType.ReportingService);
                int _year = int.Parse(dr.IsDBNull(4) ? "2000" : dr.GetString(4));
                int _month = int.Parse(dr.IsDBNull(5) ? "1" : dr.GetString(5));
                DateTime _startDate = new DateTime(_year, _month, 1);
                DateTime _endDate = _startDate.AddMonths(1).AddSeconds(-1);
                bool _isauth = dr.IsDBNull(6) ? false : (dr.GetDecimal(6) > 0);
                MD_ReportItem _ritem = new MD_ReportItem(_startDate, _endDate, _mitem, dr.IsDBNull(2) ? "" : dr.GetString(2), dr.IsDBNull(3) ? "" : dr.GetString(3), _isauth);
                _ret.Add(_ritem);
            }
            dr.Close();
            return _ret;
        }

        /// <summary>
        /// 取ReportingService格式的报表列表
        /// </summary>
        /// <param name="_ReportName"></param>
        /// <param name="_Org"></param>
        /// <returns></returns>
        private List<MD_ReportItem> GetRsReports(MD_ReportName _ReportName, SinoOrganize _Org)
        {
            string _sql = "select t.BBMC,t.BBJC,t.TJDW,t.JGMC,t.NF,t.YF, ";
            _sql += " (select count(a2.bbmc) from bb_bbjlfjxxb a2 where a2.bbmc = t.bbmc AND a2.tjdw = t.TJDW  ";
            _sql += " and a2.nf = t.nf and a2.yf = t.yf and a2.tbrq is not null ) ysh ";
            _sql += " from BB_BBJLXXST t where t.bbmc=:BBMC and T.TJDW = :TJDW";

            OracleParameter[] _param = { new OracleParameter(":BBMC", OracleDbType.Varchar2,50),
                                                new OracleParameter(":TJDW",OracleDbType.Varchar2,12)};
            _param[0].Value = _ReportName.ReportName;
            _param[1].Value = _Org.DWDM;

            List<MD_ReportItem> _ret = new List<MD_ReportItem>();
            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);

            while (dr.Read())
            {
                MD_ReportName _mitem = new MD_ReportName(dr.IsDBNull(0) ? "" : dr.GetString(0),
                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                        SinoSZReportType.ReportingService);
                int _year = int.Parse(dr.IsDBNull(4) ? "2000" : dr.GetString(4));
                int _month = int.Parse(dr.IsDBNull(5) ? "1" : dr.GetString(5));
                DateTime _startDate = new DateTime(_year, _month, 1);
                DateTime _endDate = _startDate.AddMonths(1).AddSeconds(-1);
                bool _isauth = dr.IsDBNull(6) ? false : (dr.GetDecimal(6) > 0);
                MD_ReportItem _ritem = new MD_ReportItem(_startDate, _endDate, _mitem, dr.IsDBNull(2) ? "" : dr.GetString(2), dr.IsDBNull(3) ? "" : dr.GetString(3), _isauth);
                _ret.Add(_ritem);
            }
            dr.Close();
            return _ret;
        }

        /// <summary>
        /// 取ReporintService格式的报表列表
        /// </summary>
        /// <param name="_startDate"></param>
        /// <param name="_endDate"></param>
        /// <param name="reportItems"></param>
        /// <returns></returns>
        private List<MD_ReportItem> GetRsReports(DateTime _startDate, DateTime _endDate, List<MD_ReportName> reportItems)
        {
            string _yearstr = _startDate.Year.ToString();
            string _monthstr = _startDate.Month.ToString("D2");

            string _sql = "select t.BBMC,t.BBJC,t.TJDW,t.JGMC,t.NF,t.YF, ";
            _sql += " (select count(a2.bbmc) from bb_bbjlfjxxb a2 where a2.bbmc = t.bbmc AND a2.tjdw = t.TJDW  ";
            _sql += " and a2.nf = t.nf and a2.yf = t.yf and a2.tbrq is not null ) ysh ";
            _sql += " from BB_BBJLXXST t where  T.TJDW = :TJDW";
            _sql += " and t.nf = :NF and t.yf = :YF and t.bbmc in (";
            string _fg = "";
            foreach (MD_ReportName _rn in reportItems)
            {
                _sql += string.Format(" {0}'{1}'", _fg, _rn.ReportName);
                _fg = ",";
            }
            _sql += ")";

            OracleParameter[] _param = { new OracleParameter(":TJDW",OracleDbType.Varchar2,12),
                                                new OracleParameter(":NF",OracleDbType.Char,4),
                                                new OracleParameter(":YF",OracleDbType.Char,2)
                                };
            _param[0].Value = SinoUserCtx.CurUser.CurrentPost.PostDWDM;
            _param[1].Value = _yearstr;
            _param[2].Value = _monthstr;

            List<MD_ReportItem> _ret = new List<MD_ReportItem>();
            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);

            while (dr.Read())
            {
                MD_ReportName _mitem = new MD_ReportName(dr.IsDBNull(0) ? "" : dr.GetString(0),
                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                        SinoSZReportType.ReportingService);
                int _year = int.Parse(dr.IsDBNull(4) ? "2000" : dr.GetString(4));
                int _month = int.Parse(dr.IsDBNull(5) ? "1" : dr.GetString(5));
                DateTime _sDate = new DateTime(_year, _month, 1);
                DateTime _eDate = _sDate.AddMonths(1).AddSeconds(-1);
                bool _isauth = dr.IsDBNull(6) ? false : (dr.GetDecimal(6) > 0);
                MD_ReportItem _ritem = new MD_ReportItem(_sDate, _eDate, _mitem, dr.IsDBNull(2) ? "" : dr.GetString(2), dr.IsDBNull(3) ? "" : dr.GetString(3), _isauth);
                _ret.Add(_ritem);
            }
            dr.Close();
            return _ret;

        }


        private List<MD_ReportItem> GetRsReports(DateTime _startDate, DateTime _endDate, List<MD_ReportName> _selectReportNames, SinoOrganize _Org)
        {
            string _yearstr = _startDate.Year.ToString();
            string _monthstr = _startDate.Month.ToString("D2");

            string _sql = "select t.BBMC,t.BBJC,t.TJDW,t.JGMC,t.NF,t.YF, ";
            _sql += " (select count(a2.bbmc) from bb_bbjlfjxxb a2 where a2.bbmc = t.bbmc AND a2.tjdw = t.TJDW  ";
            _sql += " and a2.nf = t.nf and a2.yf = t.yf and a2.tbrq is not null ) ysh ";
            _sql += " from BB_BBJLXXST t where  T.TJDW = :TJDW";
            _sql += " and t.nf = :NF and t.yf = :YF and t.bbmc in (";
            string _fg = "";
            foreach (MD_ReportName _rn in _selectReportNames)
            {
                _sql += string.Format(" {0}'{1}'", _fg, _rn.ReportName);
                _fg = ",";
            }
            _sql += ")";

            OracleParameter[] _param = { new OracleParameter(":TJDW",OracleDbType.Varchar2,12),
                                                new OracleParameter(":NF",OracleDbType.Char,4),
                                                new OracleParameter(":YF",OracleDbType.Char,2)
                                };
            _param[0].Value = _Org.DWDM;
            _param[1].Value = _yearstr;
            _param[2].Value = _monthstr;

            List<MD_ReportItem> _ret = new List<MD_ReportItem>();
            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);

            while (dr.Read())
            {
                MD_ReportName _mitem = new MD_ReportName(dr.IsDBNull(0) ? "" : dr.GetString(0),
                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                        SinoSZReportType.ReportingService);
                int _year = int.Parse(dr.IsDBNull(4) ? "2000" : dr.GetString(4));
                int _month = int.Parse(dr.IsDBNull(5) ? "1" : dr.GetString(5));
                DateTime _sDate = new DateTime(_year, _month, 1);
                DateTime _eDate = _sDate.AddMonths(1).AddSeconds(-1);
                bool _isauth = dr.IsDBNull(6) ? false : (dr.GetDecimal(6) > 0);
                MD_ReportItem _ritem = new MD_ReportItem(_sDate, _eDate, _mitem, dr.IsDBNull(2) ? "" : dr.GetString(2), dr.IsDBNull(3) ? "" : dr.GetString(3), _isauth);
                _ret.Add(_ritem);
            }
            dr.Close();
            return _ret;

        }



        /// <summary>
        /// 取中科富星自定义格式的报表名称列表
        /// </summary>
        /// <param name="_ReportName"></param>
        /// <returns></returns>
        private List<MD_ReportItem> GetSinoSZDefineReports(MD_ReportName _ReportName)
        {
            List<MD_ReportName> _rps = new List<MD_ReportName>();
            _rps.Add(_ReportName);
            return GetSinoSZDefineReports(DateTime.MinValue, DateTime.MaxValue, _rps);
        }

        private List<MD_ReportItem> GetSinoSZDefineReports(MD_ReportName _ReportName, SinoOrganize _Org)
        {
            List<MD_ReportName> _rps = new List<MD_ReportName>();
            _rps.Add(_ReportName);
            return GetSinoSZDefineReports(DateTime.MinValue, DateTime.MaxValue, _rps, _Org);
        }


        /// <summary>
        /// 取中科富星自定义格式的报表名称列表
        /// </summary>
        /// <param name="_startDate"></param>
        /// <param name="_endDate"></param>
        /// <param name="reportItems"></param>
        /// <returns></returns>
        private List<MD_ReportItem> GetSinoSZDefineReports(DateTime _startDate, DateTime _endDate, List<MD_ReportName> _selectReportNames)
        {
            List<MD_ReportItem> _ret = new List<MD_ReportItem>();
            string _rnString = "";
            string _fg = "";
            foreach (MD_ReportName _rn in _selectReportNames)
            {
                _rnString += string.Format("{0}{1}", _fg, _rn.ReportName);
                _fg = ",";
            }

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand();
                _cmd.CommandText = "zhtj_zdybb.getbbmc";
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Connection = cn;

                OracleParameter _p1 = _cmd.Parameters.Add("strtjdw", OracleDbType.Varchar2);
                _p1.Value = SinoUserCtx.CurUser.QxszDWDM;

                OracleParameter _p2 = _cmd.Parameters.Add("dtbegin_p", OracleDbType.Varchar2);
                _p2.Value = (_startDate == DateTime.MinValue) ? "" : _startDate.ToString("yyyyMMdd");

                OracleParameter _p3 = _cmd.Parameters.Add("dtend_p", OracleDbType.Varchar2);
                _p3.Value = (_endDate == DateTime.MaxValue) ? "" : _endDate.ToString("yyyyMMdd");

                OracleParameter _p4 = _cmd.Parameters.Add("strbbmc", OracleDbType.Varchar2);
                _p4.Value = _rnString;

                _cmd.Parameters.Add("recret", OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output);

                OracleDataReader _dr = _cmd.ExecuteReader();
                while (_dr.Read())
                {
                    bool _isauth = _dr.IsDBNull(6) ? false : (_dr.GetString(6) == "已审核");
                    MD_ReportItem _item = new MD_ReportItem(
                            _dr.IsDBNull(3) ? DateTime.MinValue : _dr.GetDateTime(3),
                            _dr.IsDBNull(4) ? DateTime.MaxValue : _dr.GetDateTime(4),
                            new MD_ReportName(_dr.IsDBNull(0) ? "" : _dr.GetString(0), _dr.IsDBNull(5) ? "" : _dr.GetString(5), SinoSZReportType.SinoSZDefineReport),
                            _dr.IsDBNull(1) ? "" : _dr.GetString(1),
                            _dr.IsDBNull(2) ? "" : _dr.GetString(2),
                            _isauth);
                    _ret.Add(_item);

                }
                _dr.Close();
                cn.Close();
            }

            return _ret;
        }

        private List<MD_ReportItem> GetSinoSZDefineReports(DateTime _startDate, DateTime _endDate, List<MD_ReportName> _selectReportNames, SinoOrganize _Org)
        {
            List<MD_ReportItem> _ret = new List<MD_ReportItem>();
            string _rnString = "";
            string _fg = "";
            foreach (MD_ReportName _rn in _selectReportNames)
            {
                _rnString += string.Format("{0}{1}", _fg, _rn.ReportName);
                _fg = ",";
            }

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand();
                _cmd.CommandText = "zhtj_zdybb.getbbmc";
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Connection = cn;

                OracleParameter _p1 = _cmd.Parameters.Add("strtjdw", OracleDbType.Varchar2);
                _p1.Value = _Org.DWDM;

                OracleParameter _p2 = _cmd.Parameters.Add("dtbegin_p", OracleDbType.Varchar2);
                _p2.Value = (_startDate == DateTime.MinValue) ? "" : _startDate.ToString("yyyyMMdd");

                OracleParameter _p3 = _cmd.Parameters.Add("dtend_p", OracleDbType.Varchar2);
                _p3.Value = (_endDate == DateTime.MaxValue) ? "" : _endDate.ToString("yyyyMMdd");

                OracleParameter _p4 = _cmd.Parameters.Add("strbbmc", OracleDbType.Varchar2);
                _p4.Value = _rnString;

                _cmd.Parameters.Add("recret", OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output);

                OracleDataReader _dr = _cmd.ExecuteReader();
                while (_dr.Read())
                {
                    bool _isauth = _dr.IsDBNull(6) ? false : (_dr.GetString(6) == "已审核");
                    MD_ReportItem _item = new MD_ReportItem(
                            _dr.IsDBNull(3) ? DateTime.MinValue : _dr.GetDateTime(3),
                            _dr.IsDBNull(4) ? DateTime.MaxValue : _dr.GetDateTime(4),
                            new MD_ReportName(_dr.IsDBNull(0) ? "" : _dr.GetString(0), _dr.IsDBNull(5) ? "" : _dr.GetString(5), SinoSZReportType.SinoSZDefineReport),
                            _dr.IsDBNull(1) ? "" : _dr.GetString(1),
                            _dr.IsDBNull(2) ? "" : _dr.GetString(2),
                            _isauth);
                    _ret.Add(_item);

                }
                _dr.Close();
                cn.Close();
            }

            return _ret;
        }


        #endregion

        #region 取报表内容
        public byte[] GetReport(MD_ReportItem _reportItem, string Format, string reportType)
        {
            switch (reportType)
            {
                case "RS报表":
                    return GetRsReport(_reportItem, Format);

                default:
                    return GetSinoSZDefineReport(_reportItem, Format);

            }
            return null;
        }

        /// <summary>
        /// 通过ReportingService取报表内容
        /// </summary>
        /// <param name="_reportItem"></param>
        /// <param name="Format"></param>
        /// <returns></returns>
        private byte[] GetRsReport(MD_ReportItem _reportItem, string Format)
        {
            switch (RsConfig.InterfaceType)
            {
                case "NEW":
                    return GetRsReport_New(_reportItem, Format);

                case "OLD":

                default:
                    return GetRsReport_OLD(_reportItem, Format);

            }
        }
        private byte[] GetRsReport_New(MD_ReportItem _reportItem, string Format)
        {
            byte[] results;

            ReportExecutionService rs = new ReportExecutionService();
            rs.Credentials = new System.Net.NetworkCredential(RsConfig.Name, RsConfig.Pass);
            rs.Url = RsConfig.RsURL;

            // Render arguments
            byte[] result = null;
            string reportPath = "/海关总署缉私局/" + _reportItem.ReportName.ReportName;
            string historyID = null;
            string devInfo = @"<DeviceInfo><Toolbar>False</Toolbar></DeviceInfo>";

            // Prepare report parameter.
            ReportService2008.ParameterValue[] param = new ReportService2008.ParameterValue[3];
            param[0] = new ReportService2008.ParameterValue();
            param[0].Name = "Report_Parameter_Year";
            param[0].Value = _reportItem.StartDate.Year.ToString();
            param[1] = new ReportService2008.ParameterValue();
            param[1].Name = "Report_Parameter_month";
            param[1].Value = _reportItem.StartDate.Month.ToString("D2");
            param[2] = new ReportService2008.ParameterValue();
            param[2].Name = "Report_Parameter_Dw";
            param[2].Value = _reportItem.ReportDWID;

            ReportService2008.DataSourceCredentials[] credentials = null;
            string showHideToggle = null;
            string encoding;
            string mimeType;
            string extension;
            ReportService2008.Warning[] warnings = null;
            ReportService2008.ParameterValue[] reportHistoryParameters = null;
            string[] streamIDs = null;

            ExecutionInfo execInfo = new ExecutionInfo();
            ExecutionHeader execHeader = new ExecutionHeader();

            rs.ExecutionHeaderValue = execHeader;

            execInfo = rs.LoadReport(reportPath, historyID);

            rs.SetExecutionParameters(param, "en-us");
            String SessionId = rs.ExecutionHeaderValue.ExecutionID;

            try
            {
                result = rs.Render(Format, devInfo, out extension, out encoding, out mimeType, out warnings, out streamIDs);

                execInfo = rs.GetExecutionInfo();

                //Console.WriteLine("Execution date and time: {0}", execInfo.ExecutionDateTime);
            }
            catch (SoapException e)
            {
                OralceLogWriter.WriteSystemLog(e.Detail.OuterXml, "ERROR");               
            }
            return result;
        }

        private byte[] GetRsReport_OLD(MD_ReportItem _reportItem, string Format)
        {
            ReportingService rs = new ReportingService();

            rs.Credentials = new System.Net.NetworkCredential(RsConfig.Name, RsConfig.Pass);
            //rs.Credentials =  new System.Net.NetworkCredential(Config.Rs_UserName, Config.Rs_UserPass);
            // Assign the URL of the Web service
            rs.Url = RsConfig.RsURL;

            string ReportPath = "/海关总署缉私局/" + _reportItem.ReportName.ReportName;
            // Prepare Render arguments
            string historyID = null;
            string deviceInfo = null;

            ParameterValue[] param = new ParameterValue[3];
            param[0] = new ParameterValue();
            param[0].Name = "Report_Parameter_Year";
            param[0].Value = _reportItem.StartDate.Year.ToString();
            param[1] = new ParameterValue();
            param[1].Name = "Report_Parameter_month";
            param[1].Value = _reportItem.StartDate.Month.ToString("D2");
            param[2] = new ParameterValue();
            param[2].Name = "Report_Parameter_Dw";
            param[2].Value = _reportItem.ReportDWID;

            string showHide = null;

            DataSourceCredentials[] credentials = null;
            Byte[] results;
            string encoding;
            string mimeType;
            Warning[] warnings = null;
            ParameterValue[] reportHistoryParameters = null;
            string[] streamIDs = null;
            //Exectute the report and save it into a file.
            try
            {
                results = rs.Render(ReportPath, Format, historyID, deviceInfo, param,
                        credentials, showHide, out encoding, out mimeType,
                        out reportHistoryParameters, out warnings, out streamIDs);
                return results;
            }
            catch (Exception e)
            {

                Exception e1 = e;


                string _eStr = string.Format(" 系统在生成报表时发出错误！\n Report Name:{0} \n Report Date:{1} \n Report Dw:{2} \n Report Error:{3}",
                        _reportItem.ReportName, _reportItem.StartDate.Year.ToString() + _reportItem.StartDate.Month.ToString("D2"),
                        string.Format("{0}[{1}]", _reportItem.ReportDWID, _reportItem.ReportDWName), e.Message);
                // Write an informational entry to the event log. 
                OralceLogWriter.WriteSystemLog(_eStr, "ERROR");
                return null;
            }
        }

        private byte[] GetSinoSZDefineReport(MD_ReportItem _reportItem, string Format)
        {
            switch (Format)
            {
                case "MHTML":
                    return GetSinoSZDefineReport_HTML(_reportItem);

                case "EXCEL":
                    return GetSinoSZDefineReport_Excel(_reportItem);
            }
            return null;
        }

        private const string SQL_GetSinoSZDefineReport_Excel = @"select BBJG_B from TJ_ZDYBBFJXXB where  BBMC = :BBMC AND TJDW=:TJDW
                                                                AND KSRQ=:KSRQ AND JZRQ=:JZRQ ";
        private byte[] GetSinoSZDefineReport_Excel(MD_ReportItem _reportItem)
        {
            byte[] cbuffer = null;

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                long actual = 0;
                OracleCommand _cmd = new OracleCommand();
                _cmd.CommandText = SQL_GetSinoSZDefineReport_Excel;
                _cmd.CommandType = CommandType.Text;
                _cmd.Connection = cn;
                _cmd.Parameters.Add(":BBMC", _reportItem.ReportName.ReportName);
                _cmd.Parameters.Add(":TJDW", _reportItem.ReportDWID);
                _cmd.Parameters.Add(":KSRQ", _reportItem.StartDate);
                _cmd.Parameters.Add(":JZRQ", _reportItem.EndDate);

                OracleDataReader myOracleDataReader = _cmd.ExecuteReader();
                bool _readflag = myOracleDataReader.Read();
                OracleBlob myOracleClob = myOracleDataReader.GetOracleBlob(0);
                long lobLength = myOracleClob.Length;
                cbuffer = new byte[lobLength];
                actual = myOracleClob.Read(cbuffer, 0, cbuffer.Length);

                myOracleDataReader.Close();

                return cbuffer;
            }
        }

        /// <summary>
        /// 取HTML格式的报表
        /// </summary>
        /// <param name="_reportItem"></param>
        /// <returns></returns>
        private byte[] GetSinoSZDefineReport_HTML(MD_ReportItem _reportItem)
        {
            int actual = 0;
            string _resStr = "";

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand();
                _cmd.CommandText = "select BBJG_C from TJ_ZDYBBFJXXB where  BBMC = :BBMC AND TJDW=:TJDW AND KSRQ=:KSRQ AND JZRQ=:JZRQ ";
                _cmd.CommandType = CommandType.Text;
                _cmd.Connection = cn;
                _cmd.Parameters.Add(":BBMC", _reportItem.ReportName.ReportName);
                _cmd.Parameters.Add(":TJDW", _reportItem.ReportDWID);
                _cmd.Parameters.Add(":KSRQ", _reportItem.StartDate);
                _cmd.Parameters.Add(":JZRQ", _reportItem.EndDate);

                using (OracleDataReader myOracleDataReader = _cmd.ExecuteReader())
                {
                    myOracleDataReader.Read();

                    OracleClob myOracleClob = myOracleDataReader.IsDBNull(0) ? null : myOracleDataReader.GetOracleClob(0);
                    if (myOracleClob == null) return null;

                    StreamReader streamreader = new StreamReader(myOracleClob, System.Text.Encoding.Unicode);

                    // step 3: get the CLOB data using the Read() method
                    char[] cbuffer = new char[100];
                    while ((actual = streamreader.Read(cbuffer, 0 /*buffer offset*/, cbuffer.Length /*count*/)) > 0)
                        _resStr += new string(cbuffer, 0, actual);

                    myOracleDataReader.Close();
                }
                cn.Close();
                System.Text.UnicodeEncoding converter = new System.Text.UnicodeEncoding();
                byte[] returnBytes = converter.GetBytes(_resStr);

                return returnBytes;
            }
        }


        public MD_ReportVerifyInfo GetReportVerifyInof(MD_ReportItem _ritem, string reportType)
        {
            switch (reportType)
            {
                case "RS报表":
                    return GetRsReportVerifyInof(_ritem);

                default:
                    return GetSinoSZDefineReportVerifyInfo(_ritem);

            }
            return null;
        }

        private MD_ReportVerifyInfo GetRsReportVerifyInof(MD_ReportItem _ritem)
        {
            MD_ReportVerifyInfo _ret = null;

            string _sql = "select TBR,TBRQ,TBDW from BB_BBJLFJXXB where ";
            _sql += " TJDW =:TJDW AND NF=:NF AND YF=:YF AND BBMC=:BBMC ";

            OracleParameter[] _param = { new OracleParameter(":TJDW",OracleDbType.Varchar2),
                                 new OracleParameter(":NF",OracleDbType.Varchar2),
                                 new OracleParameter(":YF",OracleDbType.Varchar2),
                                 new OracleParameter(":BBMC",OracleDbType.Varchar2)                
                         };
            _param[0].Value = _ritem.ReportDWID;
            _param[1].Value = _ritem.StartDate.Year.ToString();
            _param[2].Value = _ritem.StartDate.Month.ToString("D2");
            _param[3].Value = _ritem.ReportName.ReportName;

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text,
                                           _sql, _param);

            while (dr.Read())
            {
                _ret = new MD_ReportVerifyInfo(dr.IsDBNull(2) ? "" : dr.GetString(2),
                        dr.IsDBNull(0) ? "" : dr.GetString(0),
                        dr.IsDBNull(1) ? DateTime.MinValue : dr.GetDateTime(1));
            }
            dr.Close();
            return _ret;
        }

        private MD_ReportVerifyInfo GetSinoSZDefineReportVerifyInfo(MD_ReportItem _ritem)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion


        #region 创建报表


        public bool CreateReport(MD_ReportName _reportName, DateTime _startDate, DateTime _endDate, string _reportType)
        {
            switch (_reportType)
            {
                case "RS报表":
                    return CreateRsReport(_reportName, _startDate, _endDate);

                default:
                    return CreateSinoSZDefineReport(_reportName, _startDate, _endDate);

            }
            return false;
        }

        private bool CreateRsReport(MD_ReportName _reportItem, DateTime _startDate, DateTime _endDate)
        {
            string _sql = "HGZHTJ.bb";
            OracleParameter[] _param = {
                                new OracleParameter("dtTJRQ", OracleDbType.Date),
                                new OracleParameter("strTJDW",OracleDbType.Varchar2),
                                new OracleParameter("strBBMC_JS",OracleDbType.Varchar2), 
                        };
            _param[0].Value = _startDate;
            _param[1].Value = SinoUserCtx.CurUser.CurrentPost.PostDWDM;
            _param[2].Value = _reportItem.ReportName;



            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.StoredProcedure, _sql, _param);
            return true;
        }

        private bool CreateSinoSZDefineReport(MD_ReportName _reportItem, DateTime _startDate, DateTime _endDate)
        {
            bool result = SinoSZExcelReport.CreateReport(_reportItem, _startDate, _endDate, SinoUserCtx.CurUser.CurrentPost.PostDWDM);
            return result;
        }


        public bool ReBuildReport(MD_ReportItem _ritem, string _reportType)
        {

            switch (_reportType)
            {
                case "RS报表":
                    return ReBuildRsReport(_ritem);

                default:
                    return ReBuildSinoSZDefineReport(_ritem);

            }
            return false;
        }

        private bool ReBuildRsReport(MD_ReportItem _ritem)
        {
            string _sql = "HGZHTJ.bb";
            OracleParameter[] _param = {
                                new OracleParameter("dtTJRQ", OracleDbType.Date),
                                new OracleParameter("strTJDW",OracleDbType.Varchar2),
                                new OracleParameter("strBBMC_JS",OracleDbType.Varchar2), 
                        };
            _param[0].Value = _ritem.StartDate;
            _param[1].Value = _ritem.ReportDWID;
            _param[2].Value = _ritem.ReportName.ReportName;
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.StoredProcedure, _sql, _param);
            return true;
        }

        private bool ReBuildSinoSZDefineReport(MD_ReportItem _ritem)
        {
            return CreateSinoSZDefineReport(_ritem.ReportName, _ritem.StartDate, _ritem.EndDate);
        }

        public bool VerifyReport(MD_ReportItem _reportItem, DateTime _verifyDate, string _reportType)
        {
            switch (_reportType)
            {
                case "RS报表":
                    return VerifyRsReport(_reportItem, _verifyDate);

                default:
                    return VerifySinoSZDefineReport(_reportItem, _verifyDate);

            }
            return false;
        }



        private bool VerifyRsReport(MD_ReportItem _reportItem, DateTime _verifyDate)
        {
            string _CommandStr = "update BB_BBJLFJXXB SET TBR =:TBR,TBRQ =:TBRQ,TBDW =:TBDW  where TJDW =:TJDW AND NF=:NF AND YF=:YF AND BBMC=:BBMC ";
            OracleParameter[] _param = {
                                new OracleParameter(":TBR", OracleDbType.Varchar2),
                                new OracleParameter(":TBRQ",OracleDbType.Date),
                                 new OracleParameter(":TBDW",OracleDbType.Varchar2),
                                 new OracleParameter(":TJDW",OracleDbType.Varchar2),
                                 new OracleParameter(":NF",OracleDbType.Varchar2),
                                 new OracleParameter(":YF",OracleDbType.Varchar2),
                                 new OracleParameter(":BBMC",OracleDbType.Varchar2)                
                         };
            _param[0].Value = SinoUserCtx.CurUser.UserName;
            _param[1].Value = _verifyDate;
            _param[2].Value = SinoUserCtx.CurUser.CurrentPost.PostDWMC;
            _param[3].Value = _reportItem.ReportDWID;
            _param[4].Value = _reportItem.StartDate.Year.ToString();
            _param[5].Value = _reportItem.StartDate.Month.ToString("D2");
            _param[6].Value = _reportItem.ReportName.ReportName;

            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _CommandStr, _param);
            return true;
        }
        private const string SQL_VerifySinoSZDefineReport = @"update TJ_ZDYBBFJXXB a set BBZT = '已审核' where a.BBMC = :BBMC AND a.TJDW=:TJDW 
                                                            AND a.KSRQ=:KSRQ AND a.JZRQ=:JZRQ";
        private bool VerifySinoSZDefineReport(MD_ReportItem _reportItem, DateTime _verifyDate)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand();
                _cmd.CommandText = SQL_VerifySinoSZDefineReport;
                _cmd.Parameters.Add(":BBMC", _reportItem.ReportName.ReportName);
                _cmd.Parameters.Add(":TJDW", _reportItem.ReportDWID);
                _cmd.Parameters.Add(":KSRQ", _reportItem.StartDate);
                _cmd.Parameters.Add(":JZRQ", _reportItem.EndDate);
                _cmd.CommandType = CommandType.Text;
                _cmd.Connection = cn;
                _cmd.ExecuteNonQuery();
            }

            return true;
        }

        private const string SQL_GetReportGuideLines = @"select DISTINCT a.ZBZTMC,a.ZBLX,b.BBJC from tj_zbcxdyb a,bb_bbmcb b where a.zbztmc = b.bbmc and a.zbztmc = :ZTMC order by a.ZBZTMC";
        public List<MD_ReportGuideLineItem> GetReportGuideLines(MD_ReportName _reportName)
        {
            List<MD_ReportGuideLineItem> _ret = new List<MD_ReportGuideLineItem>();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_GetReportGuideLines, cn);
                    _cmd.Parameters.Add(":ZTMC", _reportName.ReportName);
                    OracleDataReader _dr = _cmd.ExecuteReader();
                    while (_dr.Read())
                    {
                        MD_ReportGuideLineItem _item = new MD_ReportGuideLineItem(
                               "1",
                                "",
                                _dr.IsDBNull(2) ? "" : _dr.GetString(2),
                                _dr.IsDBNull(0) ? "" : _dr.GetString(0),
                                Enum_ReportGuideLineItemType.Report
                                );

                        _item.Children = GetChildGuideLine(_item, cn);
                        _ret.Add(_item);
                    }
                    _dr.Close();
                    cn.Close();
                }
                catch (Exception ex)
                {
                    string _err = string.Format("取报表指标项时出错，错误信息:{0}   SQL语句：{1}", ex.Message, SQL_GetReportGuideLines);
                    OralceLogWriter.WriteSystemLog(_err, "ERROR");
                    throw ex;
                }
            }

            return _ret;
        }

        private List<MD_ReportGuideLineItem> GetChildGuideLine(MD_ReportGuideLineItem _fitem, OracleConnection cn)
        {
            List<MD_ReportGuideLineItem> _ret = new List<MD_ReportGuideLineItem>();
            string _sql = "select ID,FID,ZBMC,ZBZTMC from tj_zbcxdyb where fid =:FID and zbztmc =:ZTMC order by id ";
            OracleCommand _cmd = new OracleCommand(_sql, cn);
            _cmd.Parameters.Add(":FID", decimal.Parse(_fitem.ID));
            _cmd.Parameters.Add(":ZTMC", _fitem.ZTName);
            OracleDataReader _dr = _cmd.ExecuteReader();
            while (_dr.Read())
            {
                MD_ReportGuideLineItem _item = new MD_ReportGuideLineItem(
                         _dr.IsDBNull(0) ? "" : _dr.GetDecimal(0).ToString(),
                         _dr.IsDBNull(1) ? "" : _dr.GetDecimal(1).ToString(),
                        _dr.IsDBNull(2) ? "" : _dr.GetString(2),
                        _dr.IsDBNull(3) ? "" : _dr.GetString(3),
                        Enum_ReportGuideLineItemType.GuideLine
                        );

                _item.Children = GetChildGuideLine(_item, cn);
                _ret.Add(_item);
            }
            _dr.Close();
            return _ret;
        }


        private const string SQL_GetReportGuideLineDefine = "select ID,FID,ZBMC,ZBSF,ZBCXSF,ZBMETA from tj_zbcxdyb where id =:ID";
        public MD_ReportGuideLineDefine GetReportGuideLineDefine(string _id)
        {
            MD_ReportGuideLineDefine _ret = null;
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {

                OracleParameter[] _param = { new OracleParameter(":ID",OracleDbType.Decimal)   
                         };
                _param[0].Value = decimal.Parse(_id);
                OracleDataReader _dr = OracleHelper.ExecuteReader(cn, CommandType.Text, SQL_GetReportGuideLineDefine, _param);
                while (_dr.Read())
                {
                    _ret = new MD_ReportGuideLineDefine(
                            _dr.IsDBNull(0) ? "" : _dr.GetDecimal(0).ToString(),
                            _dr.IsDBNull(1) ? "" : _dr.GetDecimal(1).ToString(),
                            _dr.IsDBNull(2) ? "" : _dr.GetString(2),
                            _dr.IsDBNull(3) ? "" : _dr.GetString(3),
                            _dr.IsDBNull(4) ? "" : _dr.GetString(4),
                            _dr.IsDBNull(5) ? "" : _dr.GetString(5)
                            );
                }
                _dr.Close();
                cn.Close();
            }

            return _ret;
        }



        public DataTable GetReportGuideLineData(MD_ReportGuideLineDefine ReportGuideLineDefine, DateTime StartDate, DateTime EndDate, string DWDM)
        {
            DataTable _ret = new DataTable();
            _ret.TableName = "RESULT";
            string _zbsf = ReportGuideLineDefine.Method.Trim();
            try
            {
                using (OracleConnection cn = OracleHelper.OpenConnection())
                {

                    _zbsf = _zbsf.Replace("dtBegin", string.Format("to_date('{0}01','YYYYMMDD')", StartDate.ToString("yyyMM")));
                    _zbsf = _zbsf.Replace("dtEnd", string.Format("to_date('{0}235959','YYYYMMDDhh24miss')", EndDate.ToString("yyyMMdd")));
                    _zbsf = _zbsf.Replace("strTJDW", string.Format("'{0}'", DWDM));

                    _ret = OracleHelper.FillDataTable(cn, CommandType.Text, _zbsf);

                    cn.Close();
                }
                return _ret;
            }
            catch (Exception e)
            {
                string _errmsg = string.Format("执行报表指标{2}[{3}]查询出错,错误信息为:{0}!\n查询语句为:{1}\n",
                                e.Message, _zbsf, ReportGuideLineDefine.DisplayName, ReportGuideLineDefine.ID);
                OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                return _ret;
            }
        }


        public DataTable GetReportGuideLineDetailData(MD_ReportGuideLineDefine ReportGuideLineDefine, DateTime StartDate, DateTime EndDate, string DWDM)
        {
            DataTable _ret = new DataTable();
            _ret.TableName = "RESULT";
            string _zbsf = ReportGuideLineDefine.DetialMethod.Trim();
            try
            {
                using (OracleConnection cn = OracleHelper.OpenConnection())
                {

                    _zbsf = _zbsf.Replace("dtBegin", string.Format("to_date('{0}01','YYYYMMDD')", StartDate.ToString("yyyMM")));
                    _zbsf = _zbsf.Replace("dtEnd", string.Format("to_date('{0}235959','YYYYMMDDhh24miss')", EndDate.ToString("yyyMMdd")));
                    _zbsf = _zbsf.Replace("strTJDW", string.Format("'{0}'", DWDM));

                    _ret = OracleHelper.FillDataTable(cn, CommandType.Text, _zbsf);

                    cn.Close();
                }
                return _ret;
            }
            catch (Exception e)
            {
                string _errmsg = string.Format("执行报表指标{2}[{3}]的详细记录查询出错,错误信息为:{0}!\n查询语句为:{1}\n",
                                e.Message, _zbsf, ReportGuideLineDefine.DisplayName, ReportGuideLineDefine.ID);
                OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                return _ret;
            }
        }

        #endregion
    }
}
