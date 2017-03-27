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
        public partial class Dialog_SaveQuery : DevExpress.XtraEditors.XtraForm
        {
                public Dialog_SaveQuery()
                {
                        InitializeComponent();
                }
                public string SaveName
                {
                        get
                        {
                                if (this.textEdit1.EditValue == null) return "";
                                return this.textEdit1.EditValue.ToString();
                        }
                }

                public bool IsPublic
                {
                        get
                        {
                                return this.checkEdit1.Checked;
                        }
                }

                private void simpleButton1_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                }

                private void simpleButton2_Click(object sender, EventArgs e)
                {
                        if (SaveName != "")
                        {
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                        }
                        else
                        {
                                XtraMessageBox.Show("请输入保存的名称!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                }
        }
}