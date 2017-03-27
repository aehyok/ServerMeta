using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SinoSZJS.Base.Report;

namespace SinoSZClientReport.Common
{
        public partial class SinoUC_ReportYearInput : SinoUC_ReportInputBase
        {
                private List<MD_ReportName> ReportItems = new List<MD_ReportName>();
                public SinoUC_ReportYearInput()
                {
                        InitializeComponent();
                }

                public SinoUC_ReportYearInput(List<MD_ReportName> _reports)
                {
                        InitializeComponent();
                        ReportItems = _reports;
                        InitControl();
                }

                private void InitControl()
                {
                        DateTime _now = DateTime.Now;
                        this.CB_Year.EditValue = _now.Year.ToString();
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

                public override DateTime StartDate
                {
                        get
                        {
                                try
                                {
                                        int _year = int.Parse(this.CB_Year.EditValue.ToString());
                                        DateTime _ret = new DateTime(_year, 1, 1);
                                        return _ret;
                                }
                                catch
                                {
                                        return DateTime.MinValue;
                                }
                        }
                }

                public override DateTime EndDate
                {
                        get
                        {
                                try
                                {
                                        int _year = int.Parse(this.CB_Year.EditValue.ToString());
                                        DateTime _ret = new DateTime(_year, 1, 1);
                                        _ret = _ret.AddYears(1).AddSeconds(-1);
                                        return _ret;
                                }
                                catch
                                {
                                        return DateTime.MinValue;
                                }
                        }

                }

                public override MD_ReportName ReportName
                {
                        get
                        {
                                try
                                {
                                        MD_ReportName _rp = this.CB_Report.SelectedItem as MD_ReportName;
                                        return _rp;
                                }
                                catch
                                {
                                        return null;
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
        }
}
