using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SinoSZJS.Base.Report;
using SinoSZJS.Base.Authorize;
using SinoSZJS.Base.Report.ReportGuideLine;
using System.Data;

namespace SinoSZJS.WCF.Lib
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IReportService”。
    [ServiceContract]
    public interface IReportService
    {
        [OperationContract]
        bool HeartBeat();

        #region 取报表名称
        /// <summary>
        /// 取报表名称列表
        /// </summary>
        /// <param name="_reportNames">报表名称集合</param>
        /// <param name="_reportType">报表类型</param>
        /// <returns></returns>
        [OperationContract]
        List<MD_ReportName> GetReportNames(string ReportNames, string ReportType);

        #endregion

        #region 取已生成的报表项
        /// <summary>
        /// 取指定了报表名称的报表列表　(报表的统计单位为用户当前岗位所在的单位)
        /// </summary>
        /// <param name="_ReportName"></param>
        /// <param name="reportType"></param>
        /// <returns></returns>
        [OperationContract]
        List<MD_ReportItem> GetReportsByName(MD_ReportName ReportName, string ReportType);

        /// <summary>
        /// 取指定了日期和报表名称范围和类型的报表列表　(报表的统计单位为用户当前岗位所在的单位)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="dateTime_2"></param>
        /// <param name="reportItems"></param>
        /// <param name="reportType"></param>
        /// <returns></returns>
        [OperationContract]
        List<MD_ReportItem> GetReports(DateTime StartDate, DateTime EndDate, List<MD_ReportName> ReportItems, string ReportType);
        /// <summary>
        /// 取提定了统计单位和报表名称的报表列表　
        /// </summary>
        /// <param name="_ReportName"></param>
        /// <param name="_OrgID"></param>
        /// <param name="reportType"></param>
        /// <returns></returns>
        [OperationContract]
        List<MD_ReportItem> GetReportsOfOrg(MD_ReportName ReportName, SinoOrganize Org, string ReportType);

        /// <summary>
        /// 取指定了统计时间\统计单位和报表名称范围的报表列表
        /// </summary>
        /// <param name="_startDate"></param>
        /// <param name="_endDate"></param>
        /// <param name="_selectReportNames"></param>
        /// <param name="_OrgID"></param>
        /// <param name="reportType"></param>
        /// <returns></returns>
        [OperationContract]
        List<MD_ReportItem> GetReportsBySelected(DateTime StartDate, DateTime EndDate, List<MD_ReportName> SelectReportNames, SinoOrganize Org, string ReportType);

        #endregion

        #region 取报表内容

        /// <summary>
        /// 取报表的字节
        /// </summary>
        /// <param name="_reportItem"></param>
        /// <param name="Format"></param>
        /// <returns></returns>
        [OperationContract]
        Byte[] GetReport(MD_ReportItem ReportItem, string Format, string ReportType);

        /// <summary>
        /// 取报表审核信息
        /// </summary>
        /// <param name="_ritem"></param>
        /// <param name="reportType"></param>
        /// <returns></returns>
        [OperationContract]
        MD_ReportVerifyInfo GetReportVerifyInfo(MD_ReportItem ReportItem, string ReportType);

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
        [OperationContract]
        bool CreateReport(MD_ReportName ReportName, DateTime StartDate, DateTime EndDate, string ReportType);

        /// <summary>
        /// 重新计算报表
        /// </summary>
        /// <param name="_ritem"></param>
        /// <returns></returns>
        [OperationContract]
        bool ReBuildReport(MD_ReportItem ReportItem, string ReportType);

        /// <summary>
        /// 审核报表
        /// </summary>
        /// <param name="_reportItem"></param>
        /// <param name="_veryfyDate"></param>
        /// <param name="_reportType"></param>
        /// <returns></returns>
        [OperationContract]
        bool VerifyReport(MD_ReportItem ReportItem, DateTime VerifyDate, string ReportType);
        #endregion

        #region 报表指标查询相关
        [OperationContract]
        List<MD_ReportGuideLineItem> GetReportGuideLines(MD_ReportName ReportName);

        [OperationContract]
        MD_ReportGuideLineDefine GetReportGuideLineDefine(string ID);

        [OperationContract]
        DataSet GetReportGuideLineData(MD_ReportGuideLineDefine ReportGuideLineDefine, DateTime StartDate, DateTime EndDate, string DWDM);

        [OperationContract]
        DataSet GetReportGuideLineDetailData(MD_ReportGuideLineDefine ReportGuideLineDefine, DateTime StartDate, DateTime EndDate, string DWDM);
        #endregion
    }
}
