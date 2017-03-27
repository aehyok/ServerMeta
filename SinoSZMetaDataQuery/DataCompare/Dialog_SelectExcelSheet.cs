using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SinoSZMetaDataQuery.DataCompare
{
	public partial class Dialog_SelectExcelSheet : DevExpress.XtraEditors.XtraForm
	{
		public Dialog_SelectExcelSheet()
		{
			InitializeComponent();
		}

		public string SelectTableName
		{
			get
			{
				if (this.comboBoxEdit1.EditValue == null) return "";
				return this.comboBoxEdit1.EditValue.ToString();
			}
		}

		public Dialog_SelectExcelSheet(List<string> _tableNames)
		{
			InitializeComponent();
			this.comboBoxEdit1.Properties.Items.Clear();
			foreach (string _t in _tableNames)
			{
				this.comboBoxEdit1.Properties.Items.Add(_t);
			}
			if (_tableNames.Count > 0) this.comboBoxEdit1.SelectedIndex = 0;

		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}