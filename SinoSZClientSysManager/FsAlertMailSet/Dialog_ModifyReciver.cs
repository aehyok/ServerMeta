using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SinoSZClientSysManager.FsAlertMailSet
{
	public partial class Dialog_ModifyReciver : DevExpress.XtraEditors.XtraForm
	{

		public Dialog_ModifyReciver()
		{
			InitializeComponent();
		}

		public Dialog_ModifyReciver(string _email)
		{
			InitializeComponent();
			this.te_Email.EditValue = _email;
		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		public string EmailAddr
		{
			get
			{
				if (this.te_Email.EditValue == null || this.te_Email.EditValue.ToString().Trim() == "")
				{
					return "";
				}
				else
				{
					return this.te_Email.EditValue.ToString().Trim();
				}
			}
		}
		private void simpleButton1_Click(object sender, EventArgs e)
		{
			if (this.te_Email.EditValue != null && this.te_Email.EditValue.ToString().Trim() != "")
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else
			{
				XtraMessageBox.Show("请输入接收人的邮件地址!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

		}
	}
}