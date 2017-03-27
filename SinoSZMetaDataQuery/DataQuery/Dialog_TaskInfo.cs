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
        public partial class Dialog_TaskInfo : DevExpress.XtraEditors.XtraForm
        {
                public string Task_Name = "";
                public Dialog_TaskInfo()
                {
                        InitializeComponent();
                }

                private void simpleButton1_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                }

                private void simpleButton2_Click(object sender, EventArgs e)
                {
                        if (this.memoEdit1.EditValue == null || this.memoEdit1.EditValue.ToString() == "")
                        {
                                XtraMessageBox.Show("请输入任务的内容说明!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                        }
                        Task_Name = this.memoEdit1.EditValue.ToString();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                }
        }
}