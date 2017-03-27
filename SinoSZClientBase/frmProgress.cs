using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SinoSZClientBase
{
	public partial class frmProgress : DevExpress.XtraEditors.XtraForm
	{
		public frmProgress()
		{
			InitializeComponent();
		}

		public frmProgress(string _msg)
		{
			InitializeComponent();
			this.labelControl1.Text = _msg;
			this.marqueeProgressBarControl1.Properties.Stopped = false;
		}

		public void ShowMsg(string _msg)
		{
			this.labelControl1.Text = _msg;
			Application.DoEvents();
		}
	}
}