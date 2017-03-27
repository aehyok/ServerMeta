using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SinoSZClientReport.Common
{
        public partial class SinoUC_InputReportDateBase : UserControl
        {
                public SinoUC_InputReportDateBase()
                {
                        InitializeComponent();
                }
                virtual public bool DateInputed
                {
                        get { return true; }
                }

                /// <summary>
                /// 开始日期
                /// </summary>
                virtual public DateTime StartDate
                {
                        get { return DateTime.MinValue; }
                }
                /// <summary>
                /// 结束日期
                /// </summary>
                virtual public DateTime EndDate
                {
                        get { return DateTime.MaxValue; }
                }
        }
}
