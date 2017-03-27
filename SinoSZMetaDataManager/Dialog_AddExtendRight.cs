using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SinoSZMetaDataManager
{
        public partial class Dialog_AddExtendRight : DevExpress.XtraEditors.XtraForm
        {
                public Dialog_AddExtendRight()
                {
                        InitializeComponent();
                }

                private void button2_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                }

                public string RightValue
                {
                        get
                        {
                                if (this.te_value.EditValue == null || this.te_value.EditValue.ToString().Trim() == "")
                                {
                                        return "";
                                }
                                else
                                {
                                        return this.te_value.EditValue.ToString().Trim();
                                }
                        }
                }

                public string RightTitle
                {
                        get
                        {
                                if (this.te_title.EditValue == null || this.te_title.EditValue.ToString().Trim() == "")
                                {
                                        return "";
                                }
                                else
                                {
                                        return this.te_title.EditValue.ToString().Trim();
                                }
                        }
                }

                private void button1_Click(object sender, EventArgs e)
                {
                        if (this.te_value.EditValue == null || this.te_value.EditValue.ToString().Trim() == "")
                        {
                                MessageBox.Show("������Ȩ��ֵ", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                        }

                        if (this.te_title.EditValue == null || this.te_title.EditValue.ToString().Trim() == "")
                        {
                                MessageBox.Show("������Ȩ����ʾ����", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                        }

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                }
        }
}