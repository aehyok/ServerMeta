using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SinoSZJS.Base.Authorize;
using DevExpress.XtraEditors;

namespace SinoSZClientUser.UserManager
{
	public partial class Dialog_AddOrgInfo : DevExpress.XtraEditors.XtraForm
	{
		private SinoOrganize OrgID = null;
		public Dialog_AddOrgInfo()
		{
			InitializeComponent();
		}

		public Dialog_AddOrgInfo(SinoOrganize OrgCode)
		{
			InitializeComponent();
			OrgID = OrgCode;
			this.TE_SSDW.EditValue = OrgCode.FullName;
		}
		private void simpleButton1_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		public string OrgShotName
		{
			get
			{
				if (this.TE_ORGNAME.EditValue == null) return "";
				return this.TE_ORGNAME.EditValue.ToString().Trim();
			}
		}

		public string OrgFullName
		{
			get
			{
				if (this.TE_ORGFULLNAME.EditValue == null) return "";
				return this.TE_ORGFULLNAME.EditValue.ToString().Trim();
			}
		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{
			if (OrgShotName == "" || OrgFullName == "")
			{
				XtraMessageBox.Show("机构名称与机构全称是必填项!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			else
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}
	}
}