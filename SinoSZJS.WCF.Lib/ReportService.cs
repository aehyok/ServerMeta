using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SinoSZJS.CS.BizReport;
using SinoSZJS.Base.Report;
using SinoSZJS.Base.Report.ReportGuideLine;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using SinoSZJS.DataAccess;

namespace SinoSZJS.WCF.Lib
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“ReportService”。
    public class ReportService : IReportService
    {

        public List<MD_ReportName> GetReportNames(string ReportNames, string ReportType)
        {
            OraReportFactroy _of = new OraReportFactroy();
            return _of.GetReportNams(ReportNames, ReportType);
        }

        public List<MD_ReportItem> GetReportsByName(MD_ReportName ReportName, string ReportType)
        {
            OraReportFactroy _of = new OraReportFactroy();
            return _of.GetReports(ReportName, ReportType);
        }

        public List<MD_ReportItem> GetReports(DateTime StartDate, DateTime EndDate, List<MD_ReportName> ReportItems, string ReportType)
        {
            OraReportFactroy _of = new OraReportFactroy();
            return _of.GetReports(StartDate, EndDate, ReportItems, ReportType);
        }

        public List<MD_ReportItem> GetReportsOfOrg(MD_ReportName ReportName, Base.Authorize.SinoOrganize Org, string ReportType)
        {
            OraReportFactroy _of = new OraReportFactroy();
            return _of.GetReports(ReportName, Org, ReportType);
        }

        public List<MD_ReportItem> GetReportsBySelected(DateTime StartDate, DateTime EndDate, List<MD_ReportName> SelectReportNames, Base.Authorize.SinoOrganize Org, string ReportType)
        {
            OraReportFactroy _of = new OraReportFactroy();
            return _of.GetReports(StartDate, EndDate, SelectReportNames, Org, ReportType);
        }

        public byte[] GetReport(MD_ReportItem ReportItem, string Format, string ReportType)
        {
            OraReportFactroy _of = new OraReportFactroy();
            return _of.GetReport(ReportItem, Format, ReportType);
        }

        public MD_ReportVerifyInfo GetReportVerifyInfo(MD_ReportItem ReportItem, string ReportType)
        {
            OraReportFactroy _of = new OraReportFactroy();
            return _of.GetReportVerifyInof(ReportItem, ReportType);
        }

        public bool CreateReport(MD_ReportName ReportName, DateTime StartDate, DateTime EndDate, string ReportType)
        {
            OraReportFactroy _of = new OraReportFactroy();
            bool result = _of.CreateReport(ReportName, StartDate, EndDate, ReportType);
            return result;
        }

        public bool ReBuildReport(MD_ReportItem ReportItem, string ReportType)
        {
            OraReportFactroy _of = new OraReportFactroy();
            return _of.ReBuildReport(ReportItem, ReportType);
        }

        public bool VerifyReport(MD_ReportItem ReportItem, DateTime VerifyDate, string ReportType)
        {
            OraReportFactroy _of = new OraReportFactroy();
            return _of.VerifyReport(ReportItem, VerifyDate, ReportType);
        }

        public List<MD_ReportGuideLineItem> GetReportGuideLines(MD_ReportName ReportName)
        {
            OraReportFactroy _of = new OraReportFactroy();
            return _of.GetReportGuideLines(ReportName);
        }

        public MD_ReportGuideLineDefine GetReportGuideLineDefine(string ID)
        {
            OraReportFactroy _of = new OraReportFactroy();
            return _of.GetReportGuideLineDefine(ID);
        }

        public DataSet GetReportGuideLineData(MD_ReportGuideLineDefine ReportGuideLineDefine, DateTime StartDate, DateTime EndDate, string DWDM)
        {
            DataSet _ds = new DataSet();
            OraReportFactroy _of = new OraReportFactroy();
            DataTable _dt = _of.GetReportGuideLineData(ReportGuideLineDefine, StartDate, EndDate, DWDM);
            _ds.Tables.Add(_dt);
            return _ds;
        }

        public DataSet GetReportGuideLineDetailData(MD_ReportGuideLineDefine ReportGuideLineDefine, DateTime StartDate, DateTime EndDate, string DWDM)
        {
            DataSet _ds = new DataSet();
            OraReportFactroy _of = new OraReportFactroy();
            DataTable _dt = _of.GetReportGuideLineDetailData(ReportGuideLineDefine, StartDate, EndDate, DWDM);
            _ds.Tables.Add(_dt);
            return _ds;
        }

        public bool HeartBeat()
        {
            return true;
        }
    }
}
