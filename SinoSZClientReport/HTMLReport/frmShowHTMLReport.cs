using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using SinoSZPluginFramework;
using SinoSZJS.Base.Report;
using SinoSZJS.Base.Misc;

namespace SinoSZClientReport.HTMLReport
{
    public partial class frmShowHTMLReport : DevExpress.XtraEditors.XtraForm, IChildForm
    {
        private IApplication _application = null;
        private bool _initFinished = false;
        private MD_ReportItem SelectedReport = null;
        private string reportType = "";
        private string TempFileName = "";
        private bool _formClosed = false;
        private string RunErrorMsg = "";
        public frmShowHTMLReport()
        {
            InitializeComponent();
        }

        public frmShowHTMLReport(MD_ReportItem _report, string _type)
        {
            InitializeComponent();
            this.SelectedReport = _report;
            this.reportType = _type;
            this.Text = string.Format("浏览报表[{0}]", _report.ReportTitle);
        }



        private void frmShowHTMLReport_Load(object sender, EventArgs e)
        {
            this.backgroundWorker1.RunWorkerAsync();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                File.Delete(TempFileName);
            }
            catch (Exception ex)
            {
                RunErrorMsg = ex.Message;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.SelectedReport == null) return;
            using (SinoSZClientBase.ReportService.ReportServiceClient _rsc = new SinoSZClientBase.ReportService.ReportServiceClient())
            {
                byte[] _reportBytes = _rsc.GetReport(SelectedReport, "MHTML", reportType);
                if (_reportBytes == null) return;
                switch (this.SelectedReport.ReportName.ReportType)
                {
                    case SinoSZReportType.ReportingService:
                        SaveAsMHTMLService(_reportBytes);
                        break;
                    case SinoSZReportType.SinoSZDefineReport:
                        SaveAsHTMLData(_reportBytes);
                        break;
                }
            }

        }

        private void SaveAsHTMLData(byte[] _reportBytes)
        {
            string _hz = "html";
            System.Text.Encoding _encode = System.Text.Encoding.Default;
            System.Text.UnicodeEncoding converter = new System.Text.UnicodeEncoding();
            string reportString = converter.GetString(_reportBytes);
            string _lx = reportString.Substring(0, 5);

            if (_lx == "MIME-")
            {
                _hz = "mht";
            }


            string _tempDir = Utils.ExeDir + "ReportTemp\\";
            if (!Directory.Exists(_tempDir))
            {
                Directory.CreateDirectory(_tempDir);
            }
            TempFileName = _tempDir + string.Format("temp{0}.{1}", Guid.NewGuid().ToString(), _hz);



            StreamWriter sw = new StreamWriter(TempFileName, false, _encode);
            sw.Write(reportString);
            sw.Close();

        }

        private void SaveAsMHTMLService(byte[] _reportBytes)
        {
            string _tempDir = Utils.ExeDir + "ReportTemp\\";
            if (!Directory.Exists(_tempDir))
            {
                Directory.CreateDirectory(_tempDir);
            }
            TempFileName = _tempDir + string.Format("temp{0}.MHTML", Guid.NewGuid().ToString());
            FileStream stream = File.OpenWrite(TempFileName);
            int _count = _reportBytes.Length;
            stream.Write(_reportBytes, 0, _count);
            stream.Close();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!_formClosed)
            {
                this.webBrowser1.Navigate(TempFileName);
                this.tableLayoutPanel1.Visible = false;
            }
        }




        #region 实现IChildForm接口

        public IApplication Application
        {
            get { return _application; }
            set { _application = value; }
        }

        public event EventHandler<EventArgs> MenuChanged;
        virtual public void RaiseMenuChanged()
        {
            if (this._initFinished && MenuChanged != null)
            {
                MenuChanged(this, new EventArgs());
            }
        }


        public IList<FrmMenuPage> GetMenuPages()
        {
            IList<FrmMenuPage> _ret = new List<FrmMenuPage>();
            FrmMenuPage _page = new FrmMenuPage("报表功能");
            _page.MenuGroups = GetMenuGroups(_page.PageTitle);
            _ret.Add(_page);
            return _ret;
        }

        private IList<FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();

            FrmMenuGroup _thisGroup = new FrmMenuGroup("浏览报表");

            _thisGroup.MenuItems = new List<FrmMenuItem>();
            FrmMenuItem _item = new FrmMenuItem("导出报表", "导出报表", global::SinoSZClientReport.Properties.Resources.x3, true);
            _thisGroup.MenuItems.Add(_item);
            _item = new FrmMenuItem("打印报表", "打印报表", global::SinoSZClientReport.Properties.Resources.x4, true);
            _thisGroup.MenuItems.Add(_item);
            _ret.Add(_thisGroup);
            return _ret;
        }


        public bool DoCommand(string _cmdName)
        {
            switch (_cmdName)
            {
                case "导出报表":
                    ExportReport();
                    break;

                case "打印报表":
                    //this.webBrowser1.Print();
                    this.webBrowser1.ShowPrintPreviewDialog();
                    break;

            }

            return true;
        }


        #endregion

        private void frmShowHTMLReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            _formClosed = true;
        }


        private void ExportReport()
        {
            string _fn = "";
            if (SelectedReport != null)
            {
                _fn = string.Format("{0}_{1}_{2}.xls", SelectedReport.ReportTitle, SelectedReport.StartDate.ToString("yyyyMMdd"),
                    SelectedReport.EndDate.ToString("yyyyMMdd"));
            }
            Dialog_ExportReport _dialog = new Dialog_ExportReport(_fn);
            if (_dialog.ShowDialog() == DialogResult.OK)
            {
                string _fileName = _dialog.SelectedFileName;
                using (SinoSZClientBase.ReportService.ReportServiceClient _rsc = new SinoSZClientBase.ReportService.ReportServiceClient())
                {
                    byte[] _reportBytes = _rsc.GetReport(SelectedReport, "EXCEL", reportType);
                    FileStream stream = File.OpenWrite(_fileName);
                    int _count = _reportBytes.Length;
                    stream.Write(_reportBytes, 0, _count);
                    stream.Close();
                    XtraMessageBox.Show("导出报表成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}