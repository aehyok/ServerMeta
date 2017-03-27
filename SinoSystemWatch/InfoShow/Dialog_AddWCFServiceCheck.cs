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
    public partial class Dialog_AddWCFServiceCheck : DevExpress.XtraEditors.XtraForm
    {
        public Dialog_AddWCFServiceCheck()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (WCFSvcName != "")
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("请输入需要监控的WCF服务名称！", "系统提示");
            }
        }

        public string WCFSvcName
        {
            get
            {
                string _name = (this.te_Name.EditValue == null) ? "" : this.te_Name.EditValue.ToString();
                return _name;
            }
        }

        public string WCFSvcDes
        {
            get
            {
                string _des = (this.te_Des.EditValue == null) ? WCFSvcName : this.te_Des.EditValue.ToString();
                return _des;
            }
        }

        public string WCFSvcUrl
        {
            get
            {
                string _des = (this.te_URL.EditValue == null) ? "" : this.te_URL.EditValue.ToString();
                return _des;
            }
        }

        public string WCFSvcType
        {
            get
            {
                string _des = (this.te_Type.EditValue == null) ? "" : this.te_Type.EditValue.ToString();
                return _des;
            }
        }

    }
}