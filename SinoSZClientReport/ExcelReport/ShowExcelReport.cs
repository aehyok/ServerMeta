
using System.Collections.Generic;
using SinoSZJS.Base.Report;
using DevExpress.Spreadsheet;
using SinoSZClientBase;
using SinoSZPluginFramework;

namespace SinoSZClientReport.ExcelReport
{
    public partial class ShowExcelReport : frmBase
    {
        private MD_ReportItem _selectedReport = null;private string _reportType = "";

        /// <summary>
        /// 主程序
        /// </summary>
        /// <param name="report">查询报表所需信息</param>
        /// <param name="type">报表类型</param>
        public ShowExcelReport(MD_ReportItem report, string type)
        {
            InitializeComponent();
            _selectedReport = report;
            _reportType = type;
            Text = string.Format("浏览报表[{0}]", report.ReportTitle);

            IWorkbook workbook = spreadsheetControl1.Document;
            byte[] reportBytes = GetReportData(_selectedReport, _reportType);
            workbook.LoadDocument(reportBytes,DocumentFormat.Xlsx);
            SetStyle(workbook);
        }

        /// <summary>
        /// 获取报表数据
        /// </summary>
        /// <param name="selectedReport">查询报表所需信息</param>
        /// <param name="reportType">报表类型</param>
        /// <returns></returns>
        private byte[] GetReportData(MD_ReportItem selectedReport,string reportType)
        {
            using (SinoSZClientBase.ReportService.ReportServiceClient rsc = new SinoSZClientBase.ReportService.ReportServiceClient())
            {
                byte[] reportBytes = rsc.GetReport(selectedReport, "EXCEL", reportType);
                return reportBytes;
            }
        }

        /// <summary>
        /// 加载菜单
        /// </summary>
        /// <param name="pagename"></param>
        /// <returns></returns>
        protected override IList<FrmMenuGroup> GetMenuGroups(string pagename)
        {
            IList<FrmMenuGroup> ret = new List<FrmMenuGroup>();

            FrmMenuGroup thisGroup = new FrmMenuGroup("信息处理");
            thisGroup.MenuItems = new List<FrmMenuItem>();
            FrmMenuItem item = new FrmMenuItem("导出", "导出", Properties.Resources.x3, true);
            thisGroup.MenuItems.Add(item);
            ret.Add(thisGroup);

            return ret;
        }

        protected override bool ExcuteCommand(string cmdName)
        {
            switch (cmdName)
            {
                case "导出":
                    ExportData();
                    break;
            }
            return true;
        }

        private void ExportData()
        {
            spreadsheetControl1.SaveDocumentAs();
        }



        private void SetStyle(IWorkbook workbook)
        {
            //workbook.Worksheets.Remove(workbook.Worksheets["Sheet2"]);
            //workbook.Worksheets.Remove(workbook.Worksheets["Sheet3"]);

            workbook.Worksheets[0].ActiveView.ShowGridlines = false;
            workbook.Worksheets[0].ActiveView.ShowHeadings = false;

            spreadsheetControl1.ReadOnly = true;
        }
    }
}
