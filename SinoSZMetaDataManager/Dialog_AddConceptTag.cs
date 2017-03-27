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
        public partial class Dialog_AddConceptTag : DevExpress.XtraEditors.XtraForm
        {
                public string TagName
                {
                        get { return string.Format("<{0}>", this.textEdit1.EditValue); }
                }

                public string Descript
                {
                        get
                        {
                                if (this.textEdit2.EditValue == null)
                                {
                                        return "";
                                }
                                else
                                {
                                        return this.textEdit2.EditValue.ToString();
                                }
                        }
                }

                public Dialog_AddConceptTag()
                {
                        InitializeComponent();
                }

                private void simpleButton2_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                }

                private void simpleButton1_Click(object sender, EventArgs e)
                {
                        if (this.textEdit1.EditValue == null || this.textEdit1.EditValue.ToString() == "")
                        {
                                XtraMessageBox.Show("请输入概念标签!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                        }
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                }
        }
}