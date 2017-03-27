using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SinoSZMetaDataQuery.DataQuery
{
	public partial class Dialog_ChangeTaskRequestTime : DevExpress.XtraEditors.XtraForm
	{
		public Dialog_ChangeTaskRequestTime()
		{
			InitializeComponent();
		}

		public Dialog_ChangeTaskRequestTime(DateTime _dt)
		{
			InitializeComponent();
			this.dateEdit1.EditValue = _dt;
		}
		private void timeEdit1_EditValueChanged(object sender, EventArgs e)
		{

		}
		public DateTime RequestTime
		{
			get
			{
				if (this.dateEdit1.EditValue == null) return DateTime.Now;
				return (DateTime)this.dateEdit1.EditValue;
			}
		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}


	}
}