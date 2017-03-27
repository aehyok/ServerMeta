using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.Report;
using SinoSZJS.Base.Authorize;

namespace SinoSZClientReport.Common
{
        public partial class SinoUC_BrowseReportInputDate : SinoUC_BrowseReportInputBase
        {
                private string RootDWID = "";
                private List<MD_ReportName> ReportItems = new List<MD_ReportName>();
                public SinoUC_BrowseReportInputDate()
                {
                        InitializeComponent();
                }

                public SinoUC_BrowseReportInputDate(List<MD_ReportName> _reportItems, string _rootDWID)
                {
                        InitializeComponent();
                        ReportItems = _reportItems;
                        RootDWID = _rootDWID;
                        InitControl();
                }

                private void InitControl()
                {
                        DateTime _now = DateTime.Now;

                        this.te_StartDate.EditValue = new DateTime(_now.Year, _now.Month, 1);
                        this.te_EndDate.EditValue = _now;
                        this.CB_Report.Properties.Items.Add(new MD_ReportName("全部", "全部", SinoSZReportType.All));
                        foreach (MD_ReportName _rn in ReportItems)
                        {
                                this.CB_Report.Properties.Items.Add(_rn);
                        }
                        this.sinoUC_OrgComboBox1.InitRootDWID(RootDWID);
                }

                #region 重载方法
                public override SinoOrganize SelectedOrg
                {
                        get
                        {
                                return this.sinoUC_OrgComboBox1.OrgItem;
                        }
                }

                public override MD_ReportName SelectedReport
                {
                        get
                        {

                                MD_ReportName _rp = this.CB_Report.SelectedItem as MD_ReportName;
                                if (_rp != null && _rp.ReportType == SinoSZReportType.All) return null;
                                return _rp;
                        }
                }

                public override bool DateInputed
                {
                        get
                        {
                                try
                                {
                                        return (this.te_StartDate.EditValue != null && this.te_EndDate.EditValue != null);
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
                                        DateTime _dt = (DateTime)this.te_StartDate.EditValue;
                                        return _dt.Date;
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
                                        DateTime _dt = (DateTime)this.te_EndDate.EditValue;
                                        return _dt.Date.AddDays(1).AddSeconds(-1);
                                }
                                catch
                                {
                                        return DateTime.MinValue;
                                }
                        }

                }

                public override void SetDate(DateTime _startDate, DateTime _endDate)
                {
                        this.te_StartDate.EditValue = _startDate;
                        this.te_EndDate.EditValue = _endDate;
                }

                public override void SetSelectedOrg(string _dwid)
                {
                        this.sinoUC_OrgComboBox1.SelectedCode(decimal.Parse(_dwid));
                }
                #endregion
        }
}
