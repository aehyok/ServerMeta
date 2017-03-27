using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SinoSZClientReport.Common
{
        public partial class SinoUC_InputReportDate : SinoUC_InputReportDateBase
        {
                public SinoUC_InputReportDate()
                {
                        InitializeComponent();

                }
                public SinoUC_InputReportDate(DateTime _sdate, DateTime _edate)
                {
                        InitializeComponent();
                        this.te_StartDate.EditValue = _sdate;
                        this.te_EndDate.EditValue = _edate;

                }

                public override bool DateInputed
                {
                        get
                        {
                                return (this.te_StartDate.EditValue != null && this.te_EndDate.EditValue != null);
                        }
                }
                public override DateTime StartDate
                {
                        get
                        {
                                DateTime _dt = (DateTime)this.te_StartDate.EditValue;
                                return _dt.Date;
                        }
                }

                public override DateTime EndDate
                {
                        get
                        {
                                DateTime _dt = (DateTime)this.te_EndDate.EditValue;
                                return _dt.Date.AddDays(1).AddSeconds(-1);
                        }
                }
        }
}
