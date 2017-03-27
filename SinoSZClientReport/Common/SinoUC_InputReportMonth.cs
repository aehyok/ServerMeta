using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SinoSZClientReport.Common
{
        public partial class SinoUC_InputReportMonth : SinoUC_InputReportDateBase
        {
           
                public SinoUC_InputReportMonth()
                {
                        InitializeComponent();
                        InitControl();
                }

                public SinoUC_InputReportMonth(string _yearStr,string _monthStr)
                {
                        InitializeComponent();
                        this.CB_Year.EditValue = _yearStr;
                        this.CB_Month.EditValue = _monthStr;
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
                                        int _month = int.Parse(this.CB_Month.EditValue.ToString());
                                        DateTime _ret = new DateTime(_year, _month, 1);
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
                                        int _year = int.Parse(this.CB_Year.EditValue.ToString());
                                        int _month = int.Parse(this.CB_Month.EditValue.ToString());
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
                                        int _month = int.Parse(this.CB_Month.EditValue.ToString());
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
