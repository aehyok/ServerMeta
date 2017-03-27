using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZClientReport.Common;
using SinoSZJS.Base.Report;
using SinoSZJS.Base.Authorize;

namespace SinoSZClientReport
{
        public partial class Dialog_CreateReport : DevExpress.XtraEditors.XtraForm
        {
                private MD_ReportName _reportName = null;
                private DateTime _startDate = DateTime.Now;
                private DateTime _endDate = DateTime.Now;
                private string _inputType = "";
                private List<MD_ReportName> _reportItems = null;
                private SinoUC_InputReportDateBase CurrentInput = null;
                public Dialog_CreateReport()
                {
                        InitializeComponent();
                }

                public Dialog_CreateReport(MD_ReportName _selectReport, DateTime _sDate, DateTime _eDate, List<MD_ReportName> _reports, string _type)
                {
                        InitializeComponent();
                        _reportName = _selectReport;
                        _startDate = _sDate;
                        _endDate = _eDate;
                        _inputType = _type;
                        _reportItems = _reports;
                        ReDrawForm();
                }

                private void ReDrawForm()
                {
                        this.CB_ORG.EditValue = SessionClass.CurrentSinoUser.CurrentPost.PostDWMC;

                        switch (_inputType)
                        {
                                case "月报表":
                                        SinoUC_InputReportMonth _minput;
                                        if (this._startDate > DateTime.MinValue)
                                        {
                                                _minput = new SinoUC_InputReportMonth(_startDate.Year.ToString(), _startDate.Month.ToString("D2"));
                                        }
                                        else
                                        {
                                                _minput = new SinoUC_InputReportMonth();
                                        }

                                        _minput.Dock = DockStyle.Top;
                                        this.CurrentInput = _minput as SinoUC_InputReportDateBase;
                                        this.panel1.Controls.Clear();
                                        this.panel1.Controls.Add(_minput);
                                        _minput.BringToFront();
                                        break;

                                case "年报表":
                                        SinoUC_InputReportYear _yinput;
                                        if (this._startDate > DateTime.MinValue)
                                        {
                                                _yinput = new SinoUC_InputReportYear(this._startDate);
                                        }
                                        else
                                        {
                                                _yinput = new SinoUC_InputReportYear();
                                        }

                                        _yinput.Dock = DockStyle.Top;
                                        this.CurrentInput = _yinput as SinoUC_InputReportDateBase;
                                        this.panel1.Controls.Clear();
                                        this.panel1.Controls.Add(_yinput);
                                        _yinput.BringToFront();
                                        break;

                                case "季报表":
                                        SinoUC_InputReportSeason _sinput;
                                        if (this._startDate > DateTime.MinValue)
                                        {
                                                _sinput = new SinoUC_InputReportSeason(this._startDate);
                                        }
                                        else
                                        {
                                                _sinput = new SinoUC_InputReportSeason();
                                        }

                                        _sinput.Dock = DockStyle.Top;
                                        this.CurrentInput = _sinput as SinoUC_InputReportDateBase;
                                        this.panel1.Controls.Clear();
                                        this.panel1.Controls.Add(_sinput);
                                        _sinput.BringToFront();
                                        break;
                                case "半年报表":
                                        SinoUC_InputReportHalfYear _hinput;
                                        if (this._startDate > DateTime.MinValue)
                                        {
                                                _hinput = new SinoUC_InputReportHalfYear(this._startDate);
                                        }
                                        else
                                        {
                                                _hinput = new SinoUC_InputReportHalfYear();
                                        }

                                        _hinput.Dock = DockStyle.Top;
                                        this.CurrentInput = _hinput as SinoUC_InputReportDateBase;
                                        this.panel1.Controls.Clear();
                                        this.panel1.Controls.Add(_hinput);
                                        _hinput.BringToFront();
                                        break;
                                case "自定义":
                                        SinoUC_InputReportDate _dinput = new SinoUC_InputReportDate(this._startDate, this._endDate);
                                        _dinput.Dock = DockStyle.Top;
                                        this.CurrentInput = _dinput as SinoUC_InputReportDateBase;
                                        this.panel1.Controls.Clear();
                                        this.panel1.Controls.Add(_dinput);
                                        _dinput.BringToFront();

                                        break;
                        }
                        InitReportNames();

                }

                private void InitReportNames()
                {
                        foreach (MD_ReportName _rn in _reportItems)
                        {
                                this.CB_Report.Properties.Items.Add(_rn);
                        }
                        this.CB_Report.SelectedItem = this._reportName;

                }

                private void simpleButton2_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                }

                public bool IsReportInputed()
                {
                        return this.CB_Report.SelectedItem != null;
                }

                public bool IsDateInputed()
                {
                        return this.CurrentInput.DateInputed;
                }

                public DateTime StartDate
                {
                        get
                        {
                                return this.CurrentInput.StartDate;
                        }
                }

                public DateTime EndDate
                {
                        get { return this.CurrentInput.EndDate; }
                }

                public MD_ReportName SelectedReport
                {
                        get
                        {
                                return this.CB_Report.SelectedItem as MD_ReportName;
                        }
                }

                private void simpleButton1_Click(object sender, EventArgs e)
                {
                        //生成报表
                        if (!IsReportInputed())
                        {
                                XtraMessageBox.Show("请选择要生成的报表名称!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                        }

                        if (!IsDateInputed())
                        {
                                XtraMessageBox.Show("请选择要生成的报表时间!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                        }
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                }
        }
}