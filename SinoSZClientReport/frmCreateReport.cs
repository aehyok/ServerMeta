using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZClientReport.Common;
using SinoSZPluginFramework;
using SinoSZClientReport.RDSLReport;
using SinoSZClientReport.HTMLReport;
using DevExpress.XtraGrid.Columns;
using SinoSZJS.Base.Report;
using SinoSZJS.Base.DataFormater;
using SinoSZJS.Base.Misc;
using System.Linq;
using SinoSZClientReport.ExcelReport;
namespace SinoSZClientReport
{
    public partial class frmCreateReport : DevExpress.XtraEditors.XtraForm, IChildForm
    {
        private IApplication _application = null;
        private bool _initFinished = false;
        private string inputType = "Customs";
        private string reportType = ""; private List<MD_ReportItem> ReportQueryResultList = new List<MD_ReportItem>();

        private bool _createResult = false;
        private MD_ReportName _ToBeCreate_ReportName = null;
        private DateTime _ToBeCreate_StartDate = DateTime.Now;
        private DateTime _ToBeCreate_EndDate = DateTime.Now;
        private string _ToBeCreate_InputType = "";

        private MD_ReportItem _ToBeRebuild_Report = null;

        /// <summary>
        /// 取表输入类型:　　年报表,月报表,季报表,自定义
        /// </summary>
        public string InputType
        {
            get { return inputType; }
            set
            {
                if (inputType != value)
                {
                    inputType = value;
                    ReDrawForm();
                }
            }
        }
        private SinoUC_ReportInputBase CurrentInput = null;

        private List<MD_ReportName> reportItems = new List<MD_ReportName>();
        public frmCreateReport()
        {
            InitializeComponent();
        }

        public frmCreateReport(string _title, string _param)
        {
            InitializeComponent();
            this.Text = _title;
            string _createType = StrUtils.GetMetaByName("统计类型", _param).Split(',')[0];
            string _reportNames = StrUtils.GetMetaByName("报表名称", _param);
            string _reportType = StrUtils.GetMetaByName("报表类型", _param).Split(',')[0];

            inputType = _createType;
            reportType = _reportType; using (SinoSZClientBase.ReportService.ReportServiceClient _rsc = new SinoSZClientBase.ReportService.ReportServiceClient())
            {
                reportItems = _rsc.GetReportNames(_reportNames, _reportType).ToList<MD_ReportName>();
                ReDrawForm();
                string _newTitle = StrUtils.GetMetaByName("标题", _param);
                if (_newTitle != "") this.Text = _newTitle;
            }

        }



        private void ReDrawForm()
        {
            switch (inputType)
            {
                case "月报表":
                    SinoUC_ReportMonthInput _minput = new SinoUC_ReportMonthInput(reportItems);
                    _minput.Dock = DockStyle.Fill;
                    this.CurrentInput = _minput as SinoUC_ReportInputBase;
                    this.panelInput.Controls.Clear();
                    this.panelInput.Controls.Add(_minput);
                    _minput.BringToFront();
                    this.gridColumn3.Visible = false;
                    this.gridColumn2.Visible = false;
                    this.gridColumn6.Visible = true;

                    break;

                case "年报表":
                    SinoUC_ReportYearInput _yinput = new SinoUC_ReportYearInput(reportItems);
                    _yinput.Dock = DockStyle.Fill;
                    this.CurrentInput = _yinput as SinoUC_ReportInputBase;
                    this.panelInput.Controls.Clear();
                    this.panelInput.Controls.Add(_yinput);
                    this.gridColumn3.Visible = false;
                    this.gridColumn2.Visible = false;
                    this.gridColumn6.Visible = true;
                    this.gridColumn6.DisplayFormat.FormatString = "yyyy年";
                    _yinput.BringToFront();
                    break;

                case "季报表":
                    SinoUC_ReportSeasonInput _sinput = new SinoUC_ReportSeasonInput(reportItems);
                    _sinput.Dock = DockStyle.Fill;
                    this.CurrentInput = _sinput as SinoUC_ReportInputBase;
                    this.panelInput.Controls.Clear();
                    this.panelInput.Controls.Add(_sinput);
                    this.gridColumn3.Visible = false;
                    this.gridColumn2.Visible = false;
                    this.gridColumn6.Visible = true;
                    DateTimeSeasonFormater _seasonFormat = new DateTimeSeasonFormater();
                    this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                    this.gridColumn6.DisplayFormat.Format = _seasonFormat as IFormatProvider;

                    _sinput.BringToFront();
                    break;
                case "半年报表":
                    SinoUC_ReportHalfYearInput _hinput = new SinoUC_ReportHalfYearInput(reportItems);
                    _hinput.Dock = DockStyle.Fill;
                    this.CurrentInput = _hinput as SinoUC_ReportInputBase;
                    this.panelInput.Controls.Clear();
                    this.panelInput.Controls.Add(_hinput);
                    this.gridColumn3.Visible = false;
                    this.gridColumn2.Visible = false;
                    this.gridColumn6.Visible = true;
                    DateTimeHalfYearFormater _halfYearFormat = new DateTimeHalfYearFormater();
                    this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                    this.gridColumn6.DisplayFormat.Format = _halfYearFormat as IFormatProvider;
                    _hinput.BringToFront();
                    break;
                case "自定义":
                    SinoUC_ReportDateInput _dinput = new SinoUC_ReportDateInput(reportItems);
                    _dinput.Dock = DockStyle.Fill;
                    this.CurrentInput = _dinput as SinoUC_ReportInputBase;
                    this.panelInput.Controls.Clear();
                    this.panelInput.Controls.Add(_dinput);
                    this.gridColumn3.Visible = true;
                    this.gridColumn2.Visible = true;
                    this.gridColumn6.Visible = false;
                    _dinput.BringToFront();
                    break;
            }
            if (this.CurrentInput != null) this.CurrentInput.SetDate(DateTime.Now, DateTime.Now);


        }

        private void PanelBox_Resize(object sender, EventArgs e)
        {
            this.panelInput.Width = Convert.ToInt32(this.PanelBox.Width * 0.6);
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

            FrmMenuGroup _thisGroup = new FrmMenuGroup("报表管理");

            _thisGroup.MenuItems = new List<FrmMenuItem>();
            FrmMenuItem _item = new FrmMenuItem("查询报表", "查询报表", global::SinoSZClientReport.Properties.Resources.d3, true);
            _thisGroup.MenuItems.Add(_item);
            _item = new FrmMenuItem("生成报表", "生成报表", global::SinoSZClientReport.Properties.Resources.d2, true);
            _thisGroup.MenuItems.Add(_item);
            _item = new FrmMenuItem("重新计算", "重新计算", global::SinoSZClientReport.Properties.Resources.d4, true);
            _thisGroup.MenuItems.Add(_item);
            _item = new FrmMenuItem("报表审核", "报表审核", global::SinoSZClientReport.Properties.Resources.d5, true);
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
                case "生成报表":
                    if (!this.BW_Create.IsBusy) BuildReport();
                    break;
                case "重新计算":
                    if (!this.BW_Rebuild.IsBusy) ReBuildReport();
                    break;
                case "报表审核":
                    VerifyReport();
                    break;

            }

            return true;
        }



        private void BrowseReport()
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

        private void VerifyReport()
        {
            int _selectReportIndex = this.gridView1.FocusedRowHandle;
            if (_selectReportIndex >= 0)
            {

                MD_ReportItem _ritem = this.gridView1.GetRow(_selectReportIndex) as MD_ReportItem;
                Dialog_VerifyReport _dialog = new Dialog_VerifyReport(_ritem, this.reportType);
                if (_dialog.ShowDialog() == DialogResult.OK)
                {
                    using (SinoSZClientBase.ReportService.ReportServiceClient _rsc = new SinoSZClientBase.ReportService.ReportServiceClient())
                    {
                        bool _createResult = _rsc.VerifyReport(_ritem, _dialog.VerifyDate, this.reportType);
                        if (_createResult)
                        {
                            XtraMessageBox.Show("审核报表成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            QueryReport();
                        }
                        else
                        {
                            XtraMessageBox.Show("审核报表失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("请选择要审核的报表", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        #endregion

        #region 生成报表
        private void BuildReport()
        {
            Dialog_CreateReport _dialog = new Dialog_CreateReport(this.CurrentInput.ReportName, this.CurrentInput.StartDate, this.CurrentInput.EndDate, this.reportItems, this.inputType);
            if (_dialog.ShowDialog() == DialogResult.OK)
            {
                //生成报表
                this.panelWait.Visible = true;
                SetInputItem(false);
                _ToBeCreate_ReportName = _dialog.SelectedReport;
                _ToBeCreate_StartDate = _dialog.StartDate;
                _ToBeCreate_EndDate = _dialog.EndDate;
                _ToBeCreate_InputType = reportType;
                this.BW_Create.RunWorkerAsync();
            }
        }

        private void BW_Create_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (SinoSZClientBase.ReportService.ReportServiceClient _rsc = new SinoSZClientBase.ReportService.ReportServiceClient())
                {

                    _createResult = _rsc.CreateReport(_ToBeCreate_ReportName, _ToBeCreate_StartDate, _ToBeCreate_EndDate, _ToBeCreate_InputType);
                }

            }
            catch (Exception ex)
            {
                _createResult = false;
            }
        }

        private void BW_Create_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_createResult)
            {
                XtraMessageBox.Show("生成报表成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.CurrentInput.ReportName = _ToBeCreate_ReportName;
                this.CurrentInput.StartDate = _ToBeCreate_StartDate;
                this.CurrentInput.EndDate = _ToBeCreate_EndDate;
                QueryReport();
            }
            else
            {
                XtraMessageBox.Show("生成报表失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.panelWait.Visible = false;
            SetInputItem(true);
            RaiseMenuChanged();
        }
        #endregion

        #region 重新生成报表
        private void ReBuildReport()
        {
            int _selectReportIndex = this.gridView1.FocusedRowHandle;
            if (_selectReportIndex >= 0)
            {
                _ToBeRebuild_Report = this.gridView1.GetRow(_selectReportIndex) as MD_ReportItem;
                this.panelWait.Visible = true;
                SetInputItem(false);
                this.BW_Rebuild.RunWorkerAsync();
            }
            else
            {
                XtraMessageBox.Show("请选择要重新计算的报表", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void BW_Rebuild_DoWork(object sender, DoWorkEventArgs e)
        {
            using (SinoSZClientBase.ReportService.ReportServiceClient _rsc = new SinoSZClientBase.ReportService.ReportServiceClient())
            {
                _createResult = _rsc.ReBuildReport(this._ToBeRebuild_Report, this.reportType);
            }
        }

        private void BW_Rebuild_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_createResult)
            {
                XtraMessageBox.Show("重新计算报表成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QueryReport();
            }
            else
            {
                XtraMessageBox.Show("重新计算报表失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.panelWait.Visible = false;
            SetInputItem(true);
            RaiseMenuChanged();
        }

        #endregion

        #region 查询报表
        private void QueryReport()
        {
            if (this.CurrentInput == null) return;
            if (this.CurrentInput.DateInputed || this.CurrentInput.NameInputed)
            {
                this.panelWait.Visible = true;
                SetInputItem(false);
                ReportQueryResultList = null;
                this.BW_Query.RunWorkerAsync();
            }
            else
            {
                XtraMessageBox.Show("请输入日期或报表名称!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BW_Query_DoWork(object sender, DoWorkEventArgs e)
        {
            using (SinoSZClientBase.ReportService.ReportServiceClient _rsc = new SinoSZClientBase.ReportService.ReportServiceClient())
            {
                if (this.CurrentInput.DateInputed && this.CurrentInput.NameInputed)
                {

                    List<MD_ReportName> _selectReportNames = new List<MD_ReportName>();
                    _selectReportNames.Add(this.CurrentInput.ReportName);
                    ReportQueryResultList = _rsc.GetReports(this.CurrentInput.StartDate, this.CurrentInput.EndDate, _selectReportNames.ToArray(), reportType).ToList<MD_ReportItem>();

                }
                else
                {
                    if (!this.CurrentInput.DateInputed)
                    {
                        ReportQueryResultList = _rsc.GetReportsByName(this.CurrentInput.ReportName, reportType).ToList<MD_ReportItem>();
                    }

                    if (!this.CurrentInput.NameInputed)
                    {
                        ReportQueryResultList = _rsc.GetReports(this.CurrentInput.StartDate, this.CurrentInput.EndDate, reportItems.ToArray(), reportType).ToList<MD_ReportItem>();
                    }
                }
            }
        }

        private void BW_Query_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.sinoCommonGrid1.DataSource = ReportQueryResultList;
            this.panelWait.Visible = false;
            SetInputItem(true);
            RaiseMenuChanged();
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            int _selectReportIndex = this.gridView1.FocusedRowHandle;
            if (_selectReportIndex >= 0)
            {
                GridColumn _gc = this.gridView1.FocusedColumn;
                MD_ReportItem _ritem = this.gridView1.GetRow(_selectReportIndex) as MD_ReportItem;

                if (_gc.FieldName == "Audited")
                {
                    if (_ritem.Audited) ShowVerifyData(_ritem);
                }
                else
                {
                    BrowseReport();
                }

            }
        }

        private void ShowVerifyData(MD_ReportItem _ritem)
        {
            using (SinoSZClientBase.ReportService.ReportServiceClient _rsc = new SinoSZClientBase.ReportService.ReportServiceClient())
            {
                MD_ReportVerifyInfo _info = _rsc.GetReportVerifyInfo(_ritem, reportType);
                Dialog_VerifyReport _dialog = new Dialog_VerifyReport(_info);
                _dialog.ShowDialog();
            }
        }

        private void frmCreateReport_Load(object sender, EventArgs e)
        {
            QueryReport();
        }










    }
}