using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using SinoSZJS.Base.Authorize;


namespace SinoSZClientBase.Export
{
    public partial class Dialog_ExportGridViewData : DevExpress.XtraEditors.XtraForm
    {
        protected BaseView CurrentView = null;
        private IAuthorize ics_Auth = null;


        public Dialog_ExportGridViewData()
        {
            InitializeComponent();
        }

        public Dialog_ExportGridViewData(BaseView _view)
        {
            InitializeComponent();
            CurrentView = _view;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.buttonEdit1.EditValue == null || this.buttonEdit1.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("�����뵼���ļ�����", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.comboBoxEdit1.EditValue == null)
            {
                XtraMessageBox.Show("��ѡ�񵼳����ͣ�", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (CurrentView != null)
            {
                string _fname = this.buttonEdit1.EditValue.ToString();
                string _type = this.comboBoxEdit1.EditValue.ToString();
                switch (_type)
                {
                    case "Excle":
                        CurrentView.ExportToXls(_fname, true);
                        break;
                    case "Pdf":
                        CurrentView.ExportToPdf(_fname);
                        break;
                    case "Mht":
                        CurrentView.ExportToMht(_fname);
                        break;
                    case "Text":
                        CurrentView.ExportToText(_fname);
                        break;
                }
            }
            int _exportRowCount = CurrentView.RowCount;
            using (CommonService.CommonServiceClient _csc = new CommonService.CommonServiceClient())
            {
                _csc.WriteExportLog(_exportRowCount, (CurrentView.Tag != null) ? CurrentView.Tag.ToString() : "");
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SaveFileDialog _sf = new SaveFileDialog();
            _sf.Filter = "Excle�ļ�|*.xls|PDF�ļ�|*.pdf|HTML�ļ�|*.mht|�ı��ļ�|*.TXT";
            _sf.FilterIndex = 1;
            if (_sf.ShowDialog() == DialogResult.OK)
            {
                this.buttonEdit1.EditValue = _sf.FileName;
                this.comboBoxEdit1.SelectedIndex = _sf.FilterIndex - 1;
            }
        }
    }
}