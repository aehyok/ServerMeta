using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.Misc;
using System.Configuration;
using System.Reflection;
using SinoSZJS.Base.Authorize;
using System.Data;
using SinoSZJS.Base.Report;
using SinoSZJS.Base.Report.ReportGuideLine;

namespace SinoSZJS.CS.BizReport
{
    public class BIZ_Report : IReportFactroy
    {
        private static IReportFactroy _iReportFactroy;
        public static IReportFactroy ReportFactroy
        {
            get
            {
                if (_iReportFactroy == null)
                {
                    _iReportFactroy = GetDataConfig();
                }
                return _iReportFactroy;
            }

            set
            {
                _iReportFactroy = value;
            }
        }

        private static IReportFactroy GetDataConfig()
        {
            OraReportFactroy _of = new OraReportFactroy();
            return _of as IReportFactroy;
        }


        #region IReportFactroy Members

        public List<MD_ReportName> GetReportNams(string _reportNames, string _reportType)
        {
            return ReportFactroy.GetReportNams(_reportNames, _reportType);
        }


        public List<MD_ReportItem> GetReports(MD_ReportName _ReportName, string reportType)
        {
            return ReportFactroy.GetReports(_ReportName, reportType);
        }

        public List<MD_ReportItem> GetReports(DateTime _startDate, DateTime _endDate, List<MD_ReportName> reportItems, string reportType)
        {
            return ReportFactroy.GetReports(_startDate, _endDate, reportItems, reportType);
        }

        public List<MD_ReportItem> GetReports(MD_ReportName _ReportName, SinoOrganize _Org, string reportType)
        {
            return ReportFactroy.GetReports(_ReportName, _Org, reportType);
        }

        public List<MD_ReportItem> GetReports(DateTime _startDate, DateTime _endDate, List<MD_ReportName> _selectReportNames, SinoOrganize _Org, string reportType)
        {
            return ReportFactroy.GetReports(_startDate, _endDate, _selectReportNames, _Org, reportType);
        }


        public byte[] GetReport(MD_ReportItem _reportItem, string Format, string reportType)
        {
            return ReportFactroy.GetReport(_reportItem, Format, reportType);
        }
        #endregion



        #region 创建报表


        public bool CreateReport(MD_ReportName _reportName, DateTime _startDate, DateTime _endDate, string _reportType)
        {
            return ReportFactroy.CreateReport(_reportName, _startDate, _endDate, _reportType);
        }

        public bool ReBuildReport(MD_ReportItem _ritem, string _reportType)
        {
            return ReportFactroy.ReBuildReport(_ritem, _reportType);
        }

        public bool VerifyReport(MD_ReportItem _reportItem, DateTime _verifyDate, string _reportType)
        {
            return ReportFactroy.VerifyReport(_reportItem, _verifyDate, _reportType);
        }

        public MD_ReportVerifyInfo GetReportVerifyInof(MD_ReportItem _ritem, string reportType)
        {
            return ReportFactroy.GetReportVerifyInof(_ritem, reportType);
        }



        public List<MD_ReportGuideLineItem> GetReportGuideLines(MD_ReportName mD_ReportName)
        {
            return ReportFactroy.GetReportGuideLines(mD_ReportName);
        }


        public MD_ReportGuideLineDefine GetReportGuideLineDefine(string _id)
        {
            return ReportFactroy.GetReportGuideLineDefine(_id);
        }

        public DataTable GetReportGuideLineData(MD_ReportGuideLineDefine ReportGuideLineDefine, DateTime StartDate, DateTime EndDate, string DWDM)
        {
            return ReportFactroy.GetReportGuideLineData(ReportGuideLineDefine, StartDate, EndDate, DWDM);
        }



        public DataTable GetReportGuideLineDetailData(MD_ReportGuideLineDefine ReportGuideLineDefine, DateTime StartDate, DateTime EndDate, string DWDM)
        {
            return ReportFactroy.GetReportGuideLineDetailData(ReportGuideLineDefine, StartDate, EndDate, DWDM);
        }

        #endregion
    }
}
