using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SinoSZClientUser.RoleManager
{
        public partial class Dialog_AddRole : DevExpress.XtraEditors.XtraForm
        {
                public Dialog_AddRole()
                {
                        InitializeComponent();
                }

                public string RoleName
                {
                        get { return this.textEdit1.EditValue.ToString(); }
                }

                public string RoleDes
                {
                        get { return this.textEdit2.EditValue.ToString(); }
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
                                XtraMessageBox.Show("请输入角色名称!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                        }
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                }
        }
}