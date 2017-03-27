using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SinoSZJS.Base.Report;

namespace SinoSZClientReport.Common
{
        public class SinoUC_ReportInputBase: UserControl
        {
                protected DateTime _startDate = DateTime.Now;
                protected DateTime _endDate = DateTime.Now;
                protected MD_ReportName _reportName = null;
                virtual public DateTime StartDate
                {
                        get { return _startDate; }
                        set { _startDate = value; }
                }
                
                virtual public DateTime EndDate
                {
                        get { return _endDate; }
                        set { _endDate = value; }
                }

                virtual public MD_ReportName ReportName
                {
                        get { return _reportName; }
                        set { _reportName = value; }
                }

                virtual public bool DateInputed
                {
                        get { return true; }
                }

                virtual public bool NameInputed
                {
                        get { return true; }
                }

                private void InitializeComponent()
                {
                        this.SuspendLayout();
                        // 
                        // SinoUC_ReportInputBase
                        // 
                        this.Name = "SinoUC_ReportInputBase";
                        this.Size = new System.Drawing.Size(509, 62);
                        this.ResumeLayout(false);

                }

                /// <summary>
                /// 设置时间段
                /// </summary>
                /// <param name="_startDate"></param>
                /// <param name="_endDate"></param>
                virtual public void SetDate(DateTime _startDate, DateTime _endDate)
                {

                }

            
        }
}
