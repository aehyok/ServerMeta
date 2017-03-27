using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SinoSZJS.Base.Authorize;
using SinoSZJS.Base.Report;

namespace SinoSZClientReport.Common
{
        public partial class SinoUC_BrowseReportInputBase : UserControl
        {
                /// <summary>
                /// 用户选择的单位
                /// </summary>
                virtual public SinoOrganize SelectedOrg
                {
                        get { return null; }
                }

                /// <summary>
                /// 用户选择的报表名称
                /// </summary>
                virtual public MD_ReportName SelectedReport
                {
                        get { return null; }
                }

                /// <summary>
                /// 时间已录入
                /// </summary>
                virtual public bool DateInputed
                {
                        get { return true; }
                }
                
                /// <summary>
                /// 用户选择的开始时间
                /// </summary>
                virtual public DateTime StartDate
                {
                        get { return DateTime.MinValue; }
                }


                /// <summary>
                /// 用户选择的结束时间
                /// </summary>
                virtual public DateTime EndDate
                {
                        get { return DateTime.MaxValue; }
                }

                public SinoUC_BrowseReportInputBase()
                {
                        InitializeComponent();
                }

                /// <summary>
                /// 设置时间段
                /// </summary>
                /// <param name="_startDate"></param>
                /// <param name="_endDate"></param>
                virtual public void SetDate(DateTime _startDate,DateTime _endDate)
                {

                }

                /// <summary>
                /// 设置选择单位
                /// </summary>
                /// <param name="_dwid"></param>
                virtual public void SetSelectedOrg(string _dwid)
                {
                        
                }
        }
}
