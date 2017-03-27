using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.Authorize;

namespace SinoSZClientUser.PostManager
{
        public partial class Dialog_AddPost : DevExpress.XtraEditors.XtraForm
        {
                public Dialog_AddPost()
                {
                        InitializeComponent();
                }

                public Dialog_AddPost(SinoPost _post)
                {
                        InitializeComponent();
                        this.textEdit1.EditValue = _post.PostName;
                        this.textEdit2.EditValue = _post.PostDescript;
                        this.textEdit3.EditValue = _post.SecretLevel;
                }

                private void simpleButton1_Click(object sender, EventArgs e)
                {
                        if (this.textEdit1.EditValue == null || this.textEdit1.EditValue == "")
                        {
                                XtraMessageBox.Show("请输入岗位名称", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                public string PostName
                {
                        get { return this.textEdit1.EditValue.ToString(); }
                }

                public string PostDescript
                {
                        get
                        {
                                if (this.textEdit2.EditValue == null)
                                {
                                        return this.textEdit1.EditValue.ToString();
                                }
                                else
                                {
                                        return this.textEdit2.EditValue.ToString();
                                }
                        }
                }
                public int PostLevel
                {
                        get
                        {
                                if (this.textEdit3.EditValue == null) return 0;
                                return int.Parse(this.textEdit3.EditValue.ToString());
                        }
                }

        }
}