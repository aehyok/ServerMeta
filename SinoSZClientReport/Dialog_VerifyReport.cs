using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.Report;
using SinoSZJS.Base.Authorize;

namespace SinoSZClientReport
{
        public partial class Dialog_VerifyReport : DevExpress.XtraEditors.XtraForm
        {
                public Dialog_VerifyReport()
                {
                        InitializeComponent();
                }

                public Dialog_VerifyReport(MD_ReportItem _ritem,string _reportType)
                {
                        InitializeComponent();
                        InitForm();
                }

                public Dialog_VerifyReport(MD_ReportVerifyInfo _info)
                {
                        InitializeComponent();
                        InitInfoForm(_info);
                }

                private void InitInfoForm(MD_ReportVerifyInfo _info)
                {
                        this.CB_ORG.EditValue = _info.OrgName;
                        this.CB_USER.EditValue = _info.UserName;
                        this.CB_DATE.EditValue = _info.VerifyDate;
                        this.simpleButton1.Visible = false;
                        this.simpleButton2.Text = "关闭";
                        this.Text = "报表审核信息";
                }

                public DateTime VerifyDate
                {
                        get
                        {
                                return (DateTime) this.CB_DATE.EditValue;
                        }
                }

                private void InitForm()
                {
                        this.CB_ORG.EditValue = SessionClass.CurrentSinoUser.CurrentPost.PostDWMC;
                        this.CB_USER.EditValue = SessionClass.CurrentSinoUser.UserName;
                        this.CB_DATE.EditValue = DateTime.Now;
                }

                private void simpleButton2_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                }

                private void simpleButton1_Click(object sender, EventArgs e)
                {
                        if (this.CB_DATE.EditValue == null)
                        {
                                XtraMessageBox.Show("请选择审核日期", "系统提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                return;
                        }
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                }
        }
}