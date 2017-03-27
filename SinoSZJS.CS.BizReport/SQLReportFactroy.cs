using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.Report;
using SinoSZJS.Base.Report.ReportGuideLine;

namespace SinoSZJS.CS.BizReport
{
        public class SQLReportFactroy : IReportFactroy
        {
                #region IReportFactroy Members

                public List<MD_ReportName> GetReportNams(string _reportNames, string _reportType)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

                #endregion

                #region IReportFactroy Members


                public List<MD_ReportItem> GetReports(MD_ReportName _ReportName, string reportType)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

                public List<MD_ReportItem> GetReports(DateTime _startDate, DateTime _endDate, List<MD_ReportName> reportItems, string reportType)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

                #endregion

                #region IReportFactroy Members


                public List<MD_ReportItem> GetReports(MD_ReportName _ReportName, SinoSZJS.Base.Authorize.SinoOrganize _Org, string reportType)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

                public List<MD_ReportItem> GetReports(DateTime _startDate, DateTime _endDate, List<MD_ReportName> _selectReportNames, SinoSZJS.Base.Authorize.SinoOrganize OrgID, string reportType)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

                #endregion

                #region IReportFactroy Members


                public byte[] GetReport(MD_ReportItem _reportItem, string Format, string reportType)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

                #endregion

                #region IReportFactroy Members


                public bool CreateReport(MD_ReportName _reportName, DateTime _startDate, DateTime _endDate, string _reportType)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

                #endregion

                #region IReportFactroy Members


                public bool ReBuildReport(MD_ReportItem _ritem)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

                #endregion

                #region IReportFactroy Members


                public bool ReBuildReport(MD_ReportItem _ritem, string _reportType)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

                public bool VerifyReport(MD_ReportItem _reportItem, DateTime _verifyDate, string _reportType)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

                #endregion

                #region IReportFactroy Members


                public MD_ReportVerifyInfo GetReportVerifyInof(MD_ReportItem _ritem, string reportType)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

                #endregion

                #region IReportFactroy Members


                public List<MD_ReportGuideLineItem> GetReportGuideLines(MD_ReportName mD_ReportName)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

                #endregion

                #region IReportFactroy Members


                public MD_ReportGuideLineDefine GetReportGuideLineDefine(string _id)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

                #endregion

                #region IReportFactroy Members


                public System.Data.DataTable GetReportGuideLineData(MD_ReportGuideLineDefine ReportGuideLineDefine, DateTime StartDate, DateTime EndDate, string DWDM)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

                #endregion

                #region IReportFactroy Members


                public System.Data.DataTable GetReportGuideLineDetailData(MD_ReportGuideLineDefine ReportGuideLineDefine, DateTime StartDate, DateTime EndDate, string DWDM)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

                #endregion
        }
}
