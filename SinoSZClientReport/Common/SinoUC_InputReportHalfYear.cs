using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SinoSZClientReport.Common
{
        public partial class SinoUC_InputReportHalfYear : SinoUC_InputReportDateBase
        {
                public SinoUC_InputReportHalfYear()
                {
                        InitializeComponent();
                        InitControl();
                }

                public SinoUC_InputReportHalfYear(DateTime _date)
                {
                        InitializeComponent();
                        this.CB_Year.EditValue = _date.Year;
                        this.CB_Season.SelectedIndex = (_date.Month - 1) /6;
                        InitControl();
                }

                private void InitControl()
                {
                        DateTime _now = DateTime.Now;

                        for (int i = (_now.Year - 4); i < (_now.Year + 4); i++)
                        {
                                this.CB_Year.Properties.Items.Add(i.ToString());
                        }
                }

                public override bool DateInputed
                {
                        get
                        {
                                try
                                {
                                        int _year = int.Parse(this.CB_Year.EditValue.ToString());
                                        return (this.CB_Season.EditValue != null);
                                }
                                catch
                                {
                                        return false;
                                }
                        }
                }

                public override DateTime StartDate
                {
                        get
                        {
                                try
                                {
                                        int _year = int.Parse(this.CB_Year.EditValue.ToString());
                                        int _month = this.CB_Season.SelectedIndex * 6+ 1;
                                        DateTime _ret = new DateTime(_year, _month, 1);
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
                                        int _month = this.CB_Season.SelectedIndex * 6+ 6;
                                        DateTime _ret = new DateTime(_year, _month, 1);
                                        return _ret.AddMonths(1).AddSeconds(-1);
                                }
                                catch
                                {
                                        return DateTime.MaxValue;
                                }
                        }
                }
        }
}
