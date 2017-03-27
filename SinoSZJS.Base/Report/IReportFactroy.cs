using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.Authorize;
using System.Data;
using SinoSZJS.Base.Report.ReportGuideLine;

namespace SinoSZJS.Base.Report
{
        public interface IReportFactroy
        {
                #region 取报表名称
                /// <summary>
                /// 取报表名称列表
                /// </summary>
                /// <param name="_reportNames">报表名称集合</param>
                /// <param name="_reportType">报表类型</param>
                /// <returns></returns>
                List<MD_ReportName> GetReportNams(string _reportNames, string _reportType);

                #endregion

                #region 取已生成的报表项
                /// <summary>
                /// 取指定了报表名称的报表列表　(报表的统计单位为用户当前岗位所在的单位)
                /// </summary>
                /// <param name="_ReportName"></param>
                /// <param name="reportType"></param>
                /// <returns></returns>
                List<MD_ReportItem> GetReports(MD_ReportName _ReportName, string reportType);

                /// <summary>
                /// 取指定了日期和报表名称范围和类型的报表列表　(报表的统计单位为用户当前岗位所在的单位)
                /// </summary>
                /// <param name="dateTime"></param>
                /// <param name="dateTime_2"></param>
                /// <param name="reportItems"></param>
                /// <param name="reportType"></param>
                /// <returns></returns>
                List<MD_ReportItem> GetReports(DateTime _startDate, DateTime _endDate, List<MD_ReportName> reportItems, string reportType);
                /// <summary>
                /// 取提定了统计单位和报表名称的报表列表　
                /// </summary>
                /// <param name="_ReportName"></param>
                /// <param name="_OrgID"></param>
                /// <param name="reportType"></param>
                /// <returns></returns>
                List<MD_ReportItem> GetReports(MD_ReportName _ReportName, SinoOrganize _Org, string reportType);

                /// <summary>
                /// 取指定了统计时间\统计单位和报表名称范围的报表列表
                /// </summary>
                /// <param name="_startDate"></param>
                /// <param name="_endDate"></param>
                /// <param name="_selectReportNames"></param>
                /// <param name="_OrgID"></param>
                /// <param name="reportType"></param>
                /// <returns></returns>
                List<MD_ReportItem> GetReports(DateTime _startDate, DateTime _endDate, List<MD_ReportName> _selectReportNames, SinoOrganize OrgID, string reportType);

                #endregion

                #region 取报表内容

                /// <summary>
                /// 取报表的字节
                /// </summary>
                /// <param name="_reportItem"></param>
                /// <param name="Format"></param>
                /// <returns></returns>
                Byte[] GetReport(MD_ReportItem _reportItem, string Format, string reportType);

                /// <summary>
                /// 取报表审核信息
                /// </summary>
                /// <param name="_ritem"></param>
                /// <param name="reportType"></param>
                /// <returns></returns>
                MD_ReportVerifyInfo GetReportVerifyInof(MD_ReportItem _ritem, string reportType);

                #endregion

                #region 创建报表
                /// <summary>
                /// 　创建报表,　报表单位为当前用户岗位的单位
                /// </summary>
                /// <param name="_reportName"></param>
                /// <param name="_startDate"></param>
                /// <param name="_endDate"></param>
                /// <param name="_reportType"></param>
                /// <returns></returns>
                bool CreateReport(MD_ReportName _reportName, DateTime _startDate, DateTime _endDate, string _reportType);

                /// <summary>
                /// 重新计算报表
                /// </summary>
                /// <param name="_ritem"></param>
                /// <returns></returns>
                bool ReBuildReport(MD_ReportItem _ritem, string _reportType);

                /// <summary>
                /// 审核报表
                /// </summary>
                /// <param name="_reportItem"></param>
                /// <param name="_veryfyDate"></param>
                /// <param name="_reportType"></param>
                /// <returns></returns>
                bool VerifyReport(MD_ReportItem _reportItem, DateTime _verifyDate, string _reportType);
                #endregion

                #region 报表指标查询相关
                List<MD_ReportGuideLineItem> GetReportGuideLines(MD_ReportName mD_ReportName);

                MD_ReportGuideLineDefine GetReportGuideLineDefine(string _id);

                DataTable GetReportGuideLineData(MD_ReportGuideLineDefine ReportGuideLineDefine, DateTime StartDate, DateTime EndDate, string DWDM);

                DataTable GetReportGuideLineDetailData(MD_ReportGuideLineDefine ReportGuideLineDefine, DateTime StartDate, DateTime EndDate, string DWDM);
                #endregion
        }
}
