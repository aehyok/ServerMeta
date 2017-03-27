using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SinoSystemWatch
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        private int InputTimes = 0;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SessionCache.CurrentTokenString = this.textEdit1.EditValue.ToString().Trim();
            if (CheckToken())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("您的令牌错误或无效！", "系统提示");
                InputTimes++;
                if (this.InputTimes > 2)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    this.Close();
                }
            }
        }

        private bool CheckToken()
        {
            string _ret = SinoCommandExcute.Do(SessionCache.CurrentTokenString, "GetSystemList", "", null);
            if (_ret.StartsWith("身份认证失败"))
            {
                //表示返回有错误，记日志
                return false;
            }
            if (_ret.StartsWith("错误"))
            {
                MessageBox.Show(_ret, "系统提示");
                return false;
            }
            else
            {

                return true;
            }
        }
    }
}