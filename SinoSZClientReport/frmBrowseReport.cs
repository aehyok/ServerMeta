using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZPluginFramework;
using SinoSZClientReport.RDSLReport;
using SinoSZClientReport.Common;
using SinoSZClientReport.HTMLReport;
using SinoSZJS.Base.Report;
using SinoSZJS.Base.DataFormater;
using SinoSZJS.Base.Misc;
using SinoSZJS.Base.Authorize;
using System.Linq;
using SinoSZClientReport.ExcelReport;

namespace SinoSZClientReport
{
    public partial class frmBrowseReport : DevExpress.XtraEditors.XtraForm, IChildForm
    {
        private IApplication _application = null;
        private bool _initFinished = false;
        private string inputType = "Customs";
        private string reportType = "";
        private string rootDWID = "";
        private bool _showNopass = false;
        private SinoUC_BrowseReportInputBase CurrentInput = null;
        private List<MD_ReportName> reportItems = new List<MD_ReportName>();


        private List<MD_ReportItem> ReportQueryResultList = new List<MD_ReportItem>();

        public frmBrowseReport()
        {
            InitializeComponent();
        }
        public frmBrowseReport(string _title, string _param)
        {
            InitializeComponent();
            this.Text = _title;
            string _createType = StrUtils.GetMetaByName("统计类型", _param).Split(',')[0];
            string _reportNames = StrUtils.GetMetaByName("报表名称", _param);
            string _reportType = StrUtils.GetMetaByName("报表类型", _param).Split(',')[0];
            _showNopass = (StrUtils.GetMetaByName("是否显示未审核报表", _param).ToUpper() == "YES");
            //rootDWID = StrUtils.GetMetaByName("统计单位根ID", _param);
            rootDWID = SessionClass.CurrentSinoUser.CurrentPost.PostDwID;
            inputType = _createType;
            reportType = _reportType;
            using (SinoSZClientBase.ReportService.ReportServiceClient _rsc = new SinoSZClientBase.ReportService.ReportServiceClient())
            {
                reportItems = _rsc.GetReportNames(_reportNames, _reportType).ToList<MD_ReportName>();
                ReDrawForm();
            }

            string _newTitle = StrUtils.GetMetaByName("标题", _param);
            if (_newTitle != "") this.Text = _newTitle;
        }

        private void ReDrawForm()
        {
            switch (inputType)
            {
                case "月报表":
                    SinoUC_BrowseReportInputMonth _minput = new SinoUC_BrowseReportInputMonth(reportItems, rootDWID);
                    _minput.Dock = DockStyle.Fill;
                    this.CurrentInput = _minput as SinoUC_BrowseReportInputBase;
                    this.panelInput.Controls.Clear();
                    this.panelInput.Controls.Add(_minput);
                    _minput.BringToFront();
                    this.gridColumn3.Visible = false;
                    this.gridColumn2.Visible = false;
                    this.gridColumn6.Visible = true;

                    break;

                case "年报表":
                    SinoUC_BrowseReportInputYear _yinput = new SinoUC_BrowseReportInputYear(reportItems, rootDWID);
                    _yinput.Dock = DockStyle.Fill;
                    this.CurrentInput = _yinput as SinoUC_BrowseReportInputBase;
                    this.panelInput.Controls.Clear();
                    this.panelInput.Controls.Add(_yinput);
                    _yinput.BringToFront();
                    this.gridColumn3.Visible = false;
                    this.gridColumn2.Visible = false;
                    this.gridColumn6.Visible = true;
                    this.gridColumn6.DisplayFormat.FormatString = "yyyy年";
                    break;

                case "季报表":
                    SinoUC_BrowseReportInputSeason _sinput = new SinoUC_BrowseReportInputSeason(reportItems, rootDWID);
                    _sinput.Dock = DockStyle.Fill;
                    this.CurrentInput = _sinput as SinoUC_BrowseReportInputBase;
                    this.panelInput.Controls.Clear();
                    this.panelInput.Controls.Add(_sinput);
                    _sinput.BringToFront();
                    this.gridColumn3.Visible = false;
                    this.gridColumn2.Visible = false;
                    this.gridColumn6.Visible = true;
                    DateTimeSeasonFormater _seasonFormat = new DateTimeSeasonFormater();
                    this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                    this.gridColumn6.DisplayFormat.Format = _seasonFormat as IFormatProvider;
                    break;
                case "半年报表":
                    SinoUC_BrowseReportInputHalfYear _hinput = new SinoUC_BrowseReportInputHalfYear(reportItems, rootDWID);
                    _hinput.Dock = DockStyle.Fill;
                    this.CurrentInput = _hinput as SinoUC_BrowseReportInputBase;
                    this.panelInput.Controls.Clear();
                    this.panelInput.Controls.Add(_hinput);
                    _hinput.BringToFront();
                    this.gridColumn3.Visible = false;
                    this.gridColumn2.Visible = false;
                    this.gridColumn6.Visible = true;
                    DateTimeHalfYearFormater _halfYearFormat = new DateTimeHalfYearFormater();
                    this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                    this.gridColumn6.DisplayFormat.Format = _halfYearFormat as IFormatProvider;
                    break;

                case "自定义":
                    SinoUC_BrowseReportInputDate _dinput = new SinoUC_BrowseReportInputDate(reportItems, rootDWID);
                    _dinput.Dock = DockStyle.Fill;
                    this.CurrentInput = _dinput as SinoUC_BrowseReportInputBase;
                    this.panelInput.Controls.Clear();
                    this.panelInput.Controls.Add(_dinput);
                    _dinput.BringToFront();
                    this.gridColumn3.Visible = true;
                    this.gridColumn2.Visible = true;
                    this.gridColumn6.Visible = false;

                    break;
            }
            if (this.CurrentInput != null)
            {
                CurrentInput.SetDate(DateTime.Now, DateTime.Now);
                CurrentInput.SetSelectedOrg(rootDWID);
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
            FrmMenuItem _item = new FrmMenuItem("检索列表", "查询报表", global::SinoSZClientReport.Properties.Resources.d3, true);
            _thisGroup.MenuItems.Add(_item);
            _item = new FrmMenuItem("查看报表", "浏览报表", global::SinoSZClientReport.Properties.Resources.d6, (this.gridView1.FocusedRowHandle >= 0));
            _thisGroup.MenuItems.Add(_item);
            _ret.Add(_thisGroup);
            return _ret;
        }


        public bool DoCommand(string _cmdName)
        {
            switch (_cmdName)
            {
                case "查询报表":
                    if (!this.BW_Query.IsBusy) QueryReport();
                    break;

                case "浏览报表":
                    ShowReport();
                    break;

            }

            return true;
        }

        private void ShowReport()
        {
            int _selectReportIndex = this.gridView1.FocusedRowHandle;
            if (_selectReportIndex >= 0)
            {
                MD_ReportItem _ritem = this.gridView1.GetRow(_selectReportIndex) as MD_ReportItem;
                switch (this.reportType)
                {
                    case "RS报表":
                        frmShowHTMLReport _htmlForm = new frmShowHTMLReport(_ritem, reportType);
                        _application.AddForm(Guid.NewGuid().ToString(), _htmlForm);
                        break;
                    case "自定义报表":
                    default:
                        ShowExcelReport excelReport = new ShowExcelReport(_ritem, reportType);
                        _application.AddForm(Guid.NewGuid().ToString(), excelReport);
                        break;
                }


            }
            else
            {
                XtraMessageBox.Show("请选择要浏览的报表", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        /// <summary>
        /// 设置所有输入框的状态
        /// </summary>
        /// <param name="p"></param>
        private void SetInputItem(bool _canUsered)
        {
            this.panelInput.Enabled = _canUsered;
        }


        #region 查询报表
        /// <summary>
        /// 查询报表
        /// </summary>
        private bool QueryReport()
        {
            if (this.CurrentInput == null) return false;
            if (this.CurrentInput.SelectedOrg == null)
            {
                XtraMessageBox.Show("请选择单位!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (!this.CurrentInput.DateInputed)
            {
                //无日期的   
                if (this.CurrentInput.SelectedReport == null)
                {
                    XtraMessageBox.Show("请选择日期", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            this.panelWait.Visible = true;
            SetInputItem(false);
            ReportQueryResultList = null;
            this.BW_Query.RunWorkerAsync();

            return true;
        }

        private void BW_Query_DoWork(object sender, DoWorkEventArgs e)
        {
            using (SinoSZClientBase.ReportService.ReportServiceClient _rsc = new SinoSZClientBase.ReportService.ReportServiceClient())
            {
                if (!this.CurrentInput.DateInputed)
                {
                    //无日期的   
                    if (this.CurrentInput.SelectedReport != null)
                    {
                        ReportQueryResultList = _rsc.GetReportsOfOrg(this.CurrentInput.SelectedReport,
                                              this.CurrentInput.SelectedOrg,
                                              reportType).ToList<MD_ReportItem>();
                    }
                }
                else
                {
                    //有日期的
                    List<MD_ReportName> _selectReportNames = new List<MD_ReportName>();
                    if (this.CurrentInput.SelectedReport != null)
                    {
                        _selectReportNames.Add(this.CurrentInput.SelectedReport);
                    }
                    else
                    {
                        _selectReportNames = reportItems;
                    }
                    ReportQueryResultList = _rsc.GetReportsBySelected(this.CurrentInput.StartDate, this.CurrentInput.EndDate,
                        _selectReportNames.ToArray(),
                        this.CurrentInput.SelectedOrg,
                        reportType).ToList<MD_ReportItem>();
                }

            }
            #region 过滤已审核报表暂不使用
            if (ReportQueryResultList != null && !_showNopass)
            {
                List<MD_ReportItem> _removeItems = new List<MD_ReportItem>();
                foreach (MD_ReportItem _ritem in ReportQueryResultList)
                {
                    if (!_ritem.Audited) _removeItems.Add(_ritem);
                }

                foreach (MD_ReportItem _ritem in _removeItems)
                {
                    ReportQueryResultList.Remove(_ritem);
                }
            }
            #endregion

        }

        private void BW_Query_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.gridView1.BeginUpdate();
            this.sinoCommonGrid1.DataSource = ReportQueryResultList;
            this.gridView1.EndUpdate();
            this.panelWait.Visible = false;
            SetInputItem(true);
            RaiseMenuChanged();
        }
        #endregion

        private void sinoCommonGrid1_DoubleClick(object sender, EventArgs e)
        {
            ShowReport();
        }

        private void frmBrowseReport_Load(object sender, EventArgs e)
        {
            _initFinished = true;
            QueryReport();
        }





    }
}