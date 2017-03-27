using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SinoSZClientSysManager.GDSManager
{
    public partial class Dialog_TokenSet : DevExpress.XtraEditors.XtraForm
    {
        private SinoSZJS.Base.JSGDS.GDSTokenRecord CurrentToken;

        public Dialog_TokenSet()
        {
            InitializeComponent();
        }

        public Dialog_TokenSet(SinoSZJS.Base.JSGDS.GDSTokenRecord _g)
        {
            InitializeComponent();

            // TODO: Complete member initialization
            this.CurrentToken = _g;
            this.te_IP.EditValue = _g.RemoteIP;
            this.te_IP.Properties.ReadOnly = true;
        }

        public string TokenIP
        {
            get
            {
                return (this.te_IP.EditValue == null) ? "" : this.te_IP.EditValue.ToString();
            }
            set
            {
                this.te_IP.EditValue = value;
            }
        }

        public string TokenString
        {
            get
            {
                return (this.te_Token.EditValue == null) ? "" : this.te_Token.EditValue.ToString();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (this.TokenIP == "" || this.TokenString == "")
            {
                MessageBox.Show("访问端IP和令牌明文均不可以为空！请重新输入！", "系统提示", MessageBoxButtons.OK);
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}