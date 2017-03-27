using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SinoSZClientReport.Common
{
        public partial class SinoUC_InputReportYear : SinoUC_InputReportDateBase
        {
                public SinoUC_InputReportYear()
                {
                        InitializeComponent();
                        InitControl();
                }

                public SinoUC_InputReportYear(DateTime _date)
                {
                        InitializeComponent();
                        this.comboBoxEdit1.EditValue = _date.Year;
                        InitControl();
                }

                private void InitControl()
                {
                        DateTime _now = DateTime.Now;

                        for (int i = (_now.Year - 4); i < (_now.Year + 4); i++)
                        {
                                this.comboBoxEdit1.Properties.Items.Add(i.ToString());
                        }
                }

                public override bool DateInputed
                {
                        get
                        {
                                try
                                {
                                        int _year = int.Parse(this.comboBoxEdit1.EditValue.ToString());
                                        return true;
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
                                        int _year = int.Parse(this.comboBoxEdit1.EditValue.ToString());
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
                                        int _year = int.Parse(this.comboBoxEdit1.EditValue.ToString());
                                        DateTime _ret = new DateTime(_year, 12, 1);
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
