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
        public partial class SinoUC_ReportHalfYearInput : SinoUC_ReportInputBase
        {
                private List<MD_ReportName> ReportItems = new List<MD_ReportName>();
                public SinoUC_ReportHalfYearInput()
                {
                        InitializeComponent();
                }

                public SinoUC_ReportHalfYearInput(List<MD_ReportName> _reports)
                {
                        InitializeComponent();
                        ReportItems = _reports;
                        InitControl();
                }

                private void InitControl()
                {
                        DateTime _now = DateTime.Now;

                        for (int i = (_now.Year - 4); i < (_now.Year + 4); i++)
                        {
                                this.CB_Year.Properties.Items.Add(i.ToString());
                        }
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
                                try
                                {
                                        int _year = int.Parse(this.CB_Year.EditValue.ToString());

                                        return (this.cb_Half.EditValue != null);
                                }
                                catch
                                {
                                        return false;
                                }
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
                                try
                                {
                                        int _year = int.Parse(this.CB_Year.EditValue.ToString());
                                        string _half = this.cb_Half.EditValue.ToString();

                                        int _month = (_half == "上半年") ? 1 : 7;
                                        DateTime _ret = new DateTime(_year, _month, 1);
                                        return _ret;
                                }
                                catch
                                {
                                        return DateTime.MinValue;
                                }
                        }
                        set
                        {
                                this.CB_Year.EditValue = value.Year.ToString();
                                int _half = (value.Month > 6) ? 1 : 0;
                                this.cb_Half.SelectedIndex = _half;

                        }
                }

                public override DateTime EndDate
                {
                        get
                        {
                                try
                                {
                                        int _year = int.Parse(this.CB_Year.EditValue.ToString());
                                        int _month = (this.cb_Half.SelectedIndex == 0) ? 6: 12;
                                        DateTime _ret = new DateTime(_year, _month, 1);
                                        _ret = _ret.AddMonths(1).AddSeconds(-1);
                                        return _ret;
                                }
                                catch
                                {
                                        return DateTime.MinValue;
                                }
                        }
                        set
                        {
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
                        this.CB_Year.EditValue = _startDate.Year.ToString();
                        StartDate = _startDate;
                }
        }
}
