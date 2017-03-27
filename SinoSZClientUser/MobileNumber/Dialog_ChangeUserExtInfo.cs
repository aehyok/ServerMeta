using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.User;

namespace SinoSZClientUser.MobileNumber
{
	public partial class Dialog_ChangeUserExtInfo : DevExpress.XtraEditors.XtraForm
	{
		private UserExtInfo UserInfo = null;
		public Dialog_ChangeUserExtInfo()
		{
			InitializeComponent();
		}

		public string Mobile
		{
			get
			{
				if (this.te_Mobile.EditValue == null) return "";
				return this.te_Mobile.EditValue.ToString();
			}
		}
		public string Email
		{
			get
			{
				if (this.te_Email.EditValue == null) return "";
				return this.te_Email.EditValue.ToString();
			}
		}



		public Dialog_ChangeUserExtInfo(UserExtInfo info)
		{
			InitializeComponent();
			UserInfo = info;
			InitData();
		}

		private void InitData()
		{
			this.te_LogonName.EditValue = UserInfo.LogonName;
			this.te_UserName.EditValue = UserInfo.UserName;
			this.te_Mobile.EditValue = UserInfo.Mobile;
			this.te_Email.EditValue = UserInfo.EMAIL;
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}