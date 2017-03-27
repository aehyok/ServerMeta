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
        public partial class Dialog_AddConceptGroup : DevExpress.XtraEditors.XtraForm
        {
                public string GroupName
                {
                        get { return this.textEdit1.EditValue.ToString(); }
                }

                public Dialog_AddConceptGroup()
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
                                XtraMessageBox.Show("请输入概念标签组名称!","系统提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                return;
                        }
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                }

                private void textEdit1_EditValueChanged(object sender, EventArgs e)
                {

                }
        }
}