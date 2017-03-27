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
        public partial class SinoUC_ReportSeasonInput : SinoUC_ReportInputBase
        {
                private List<MD_ReportName> ReportItems = new List<MD_ReportName>();
                public SinoUC_ReportSeasonInput()
                {
                        InitializeComponent();
                }


                public SinoUC_ReportSeasonInput(List<MD_ReportName> _reports)
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
                                        int _season = int.Parse(this.cb_Season.EditValue.ToString());

                                        return true;
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
                                        int _season = int.Parse(this.cb_Season.EditValue.ToString());
                                        int _month = (_season - 1) * 3 + 1;
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
                                int _month = value.Month;
                                int _season = (_month - 1) / 3;
                                this.cb_Season.SelectedIndex = _season;
                        }
                }

                public override DateTime EndDate
                {
                        get
                        {
                                try
                                {
                                        int _year = int.Parse(this.CB_Year.EditValue.ToString());
                                        int _season = int.Parse(this.cb_Season.EditValue.ToString());
                                        int _month = (_season - 1) * 3 + 3;
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
