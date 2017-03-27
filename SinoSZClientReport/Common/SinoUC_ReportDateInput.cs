using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.Report;

namespace SinoSZClientReport.Common
{
        public partial class SinoUC_ReportDateInput : SinoUC_ReportInputBase
        {
                private List<MD_ReportName> ReportItems = new List<MD_ReportName>();
                public SinoUC_ReportDateInput()
                {
                        InitializeComponent();
                }

                public SinoUC_ReportDateInput(List<MD_ReportName> _reports)
                {
                        InitializeComponent();
                        ReportItems = _reports;
                        InitControl();
                }

                private void InitControl()
                {
                        DateTime _now = DateTime.Now;

                        this.te_StartDate.EditValue = new DateTime(_now.Year, _now.Month, 1);
                        this.te_EndDate.EditValue = _now;
                        this.CB_Report.Properties.Items.Clear();
                        this.CB_Report.Properties.Items.Add(new MD_ReportName("全部", "全部", SinoSZReportType.All));
                        foreach (MD_ReportName _rn in ReportItems)
                        {
                                this.CB_Report.Properties.Items.Add(_rn);
                        }
                }

                public override bool DateInputed
                {
                        get
                        {
                                return (this.te_StartDate.EditValue != null && this.te_EndDate.EditValue != null);
                        }
                }

                public override bool NameInputed
                {
                        get
                        {
                                return (this.ReportName != null);
                        }
                }

                public override DateTime StartDate
                {
                        get
                        {
                                if (this.te_StartDate.EditValue != null)
                                {
                                        DateTime _dt = (DateTime)this.te_StartDate.EditValue;
                                        return _dt.Date;
                                }
                                else
                                {
                                        return DateTime.MinValue;
                                }
                        }
                        set
                        {
                                this.te_StartDate.EditValue = value;
                        }
                }

                public override DateTime EndDate
                {
                        get
                        {
                                if (this.te_EndDate.EditValue != null)
                                {
                                        DateTime _dt = (DateTime)this.te_EndDate.EditValue;
                                        return _dt.Date.AddDays(1).AddSeconds(-1);
                                }
                                else
                                {
                                        return DateTime.MaxValue;
                                }
                        }
                        set
                        {
                                this.te_EndDate.EditValue = value;
                        }

                }

                public override MD_ReportName ReportName
                {
                        get
                        {
                                try
                                {
                                        MD_ReportName _rp = this.CB_Report.SelectedItem as MD_ReportName;
                                        if (_rp != null && _rp.ReportType == SinoSZReportType.All) return null;
                                        return _rp;
                                }
                                catch
                                {
                                        return null;
                                }
                        }

                }

                public override void SetDate(DateTime _startDate, DateTime _endDate)
                {
                        StartDate = _startDate;
                        EndDate = _endDate;
                }

        }
}
