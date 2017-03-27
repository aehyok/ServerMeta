using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SinoSZClientReport.HTMLReport
{
    public partial class Dialog_ExportReport : DevExpress.XtraEditors.XtraForm
    {
        private string PreFileName = "";
        public Dialog_ExportReport()
        {
            InitializeComponent();
        }

        public Dialog_ExportReport(string preFileName)
        {
            InitializeComponent();
            PreFileName = preFileName;
            //this.buttonEdit1.EditValue = PreFileName;
        }

        public string SelectedFileName
        {
            get
            {
                if (this.buttonEdit1.EditValue == null) return "";
                return this.buttonEdit1.EditValue.ToString();
            }
        }
        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SaveFileDialog _sf = new SaveFileDialog();
            _sf.Filter = "Excle文件|*.xls";
            _sf.FilterIndex = 1;
            _sf.FileName = PreFileName;
            if (_sf.ShowDialog() == DialogResult.OK)
            {
                this.buttonEdit1.EditValue = _sf.FileName;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (SelectedFileName == "")
            {
                XtraMessageBox.Show("请输入导出文件名!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}