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
        public partial class SinoUC_BrowseReportInputSeason : SinoUC_BrowseReportInputBase
        {
                private string RootDWID = "";
                private List<MD_ReportName> ReportItems = new List<MD_ReportName>();
                public SinoUC_BrowseReportInputSeason()
                {
                        InitializeComponent();
                }


                public SinoUC_BrowseReportInputSeason(List<MD_ReportName> _reportItems, string _rootDWID)
                {
                        InitializeComponent();
                        ReportItems = _reportItems;
                        RootDWID = _rootDWID;
                        InitControl();
                }

                private void InitControl()
                {
                        DateTime _now = DateTime.Now;

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
                                        int _year = int.Parse(this.CB_Year.EditValue.ToString());
                                        return (this.cb_Season.EditValue != null);

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
                                        int _month = this.cb_Season.SelectedIndex * 3 + 1;
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
                                        int _month = this.cb_Season.SelectedIndex * 3 + 3;
                                        DateTime _ret = new DateTime(_year, _month, 1);
                                        _ret = _ret.AddMonths(1).AddSeconds(-1);
                                        return _ret;
                                }
                                catch
                                {
                                        return DateTime.MinValue;
                                }
                        }

                }

                public override void SetDate(DateTime _startDate, DateTime _endDate)
                {
                        this.CB_Year.EditValue = _startDate.Year.ToString();
                        this.cb_Season.SelectedIndex =( _startDate.Month-1) /3;
                }

                public override void SetSelectedOrg(string _dwid)
                {
                        this.sinoUC_OrgComboBox1.SelectedCode(decimal.Parse(_dwid));
                }
                #endregion
        }
}
