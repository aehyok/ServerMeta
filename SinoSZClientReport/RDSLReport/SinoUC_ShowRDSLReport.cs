using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Reporting.WinForms;

namespace SinoSZClientReport.RDSLReport
{
        public partial class SinoUC_ShowRDSLReport : UserControl
        {
                public SinoUC_ShowRDSLReport()
                {
                        InitializeComponent();
                }

                public void ShowReport(DataTable _dt)
                {
                        ReportParameter[] _param = new ReportParameter[] {
                                new ReportParameter("Report_Parameter_Year","2005"),
                                new ReportParameter("Report_Parameter_month","07"),
                                new ReportParameter("Report_Parameter_Dw","海关总署缉私局")
                        };
                        this.reportViewer1.LocalReport.SetParameters(_param);
                        this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Data", _dt));
                        this.reportViewer1.RefreshReport();

                }
        }
}
