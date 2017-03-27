using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SinoSystemWatch.InfoShow
{
    public partial class Dialog_AddWinServiceCheck : DevExpress.XtraEditors.XtraForm
    {
        public Dialog_AddWinServiceCheck()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (WinSvcName != "")
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("请输入需要监控的服务名称！", "系统提示");
            }
        }

        public string WinSvcName
        {
            get
            {
                string _name = (this.te_Name.EditValue == null) ? "" : this.te_Name.EditValue.ToString();
                return _name;
            }
        }

        public string WinSvcDes
        {
            get
            {
                string _des = (this.te_Des.EditValue == null) ? WinSvcName : this.te_Des.EditValue.ToString();
                return _des;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}