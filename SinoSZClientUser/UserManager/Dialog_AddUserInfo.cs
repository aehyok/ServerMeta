using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.Authorize;

namespace SinoSZClientUser.UserManager
{
	public partial class Dialog_AddUserInfo : DevExpress.XtraEditors.XtraForm
	{
		private SinoOrganize OrgID = null;
		public Dialog_AddUserInfo()
		{
			InitializeComponent();
		}

		public Dialog_AddUserInfo(SinoOrganize OrgCode)
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

		private void simpleButton2_Click(object sender, EventArgs e)
		{
            using (SinoSZClientBase.UserManagerService.UserManagerServiceClient _umsc = new SinoSZClientBase.UserManagerService.UserManagerServiceClient())
            {
                if (TE_YHM.EditValue == null || TE_YHM.EditValue.ToString() == "")
                {
                    XtraMessageBox.Show("用户名为必填项!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string _yhm = TE_YHM.EditValue.ToString().Trim();
                if (_umsc.IsExistYHM(_yhm))
                {
                    XtraMessageBox.Show(string.Format("用户名{0}已经存在!", _yhm), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
		}

		public string YHM
		{
			get
			{
				if (TE_YHM.EditValue == null || TE_YHM.EditValue.ToString() == "")
				{
					return "";
				}
				else
				{
					return TE_YHM.EditValue.ToString().Trim();
				}
			}
		}

		public string XM
		{
			get
			{
				if (TE_XM.EditValue == null || TE_XM.EditValue.ToString() == "")
				{
					return "";
				}
				else
				{
					return TE_XM.EditValue.ToString().Trim();
				}
			}
		}

		public string XB
		{
			get
			{
				if (TE_XB.EditValue == null || TE_XB.EditValue.ToString() == "")
				{
					return "";
				}
				else
				{
					return TE_XB.EditValue.ToString();
				}
			}
		}


		public string SFZH
		{
			get
			{
				if (TE_SFZH.EditValue == null || TE_SFZH.EditValue.ToString() == "")
				{
					return "";
				}
				else
				{
					return TE_SFZH.EditValue.ToString().Trim();
				}
			}
		}

		public string HGGH
		{
			get
			{
				if (TE_HGGH.EditValue == null || TE_HGGH.EditValue.ToString() == "")
				{
					return "";
				}
				else
				{
					return TE_HGGH.EditValue.ToString().Trim();
				}
			}
		}

		public string JH
		{
			get
			{
				if (TE_JH.EditValue == null || TE_JH.EditValue.ToString() == "")
				{
					return "";
				}
				else
				{
					return TE_JH.EditValue.ToString().Trim();
				}
			}
		}

		public string ZWMC
		{
			get
			{
				if (TE_ZWMC.EditValue == null || TE_ZWMC.EditValue.ToString() == "")
				{
					return "";
				}
				else
				{
					return TE_ZWMC.EditValue.ToString().Trim();
				}
			}
		}

		public string ZWJB
		{
			get
			{
				if (TE_ZWJB.EditValue == null || TE_ZWJB.EditValue.ToString() == "")
				{
					return "";
				}
				else
				{
					return TE_ZWJB.EditValue.ToString().Trim();
				}
			}
		}

		public string EMAIL
		{
			get
			{
				if (TE_EMAIL.EditValue == null || TE_EMAIL.EditValue.ToString() == "")
				{
					return "";
				}
				else
				{
					return TE_EMAIL.EditValue.ToString().Trim();
				}
			}
		}

	}
}