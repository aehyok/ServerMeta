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
    public partial class Dialog_AddDBConnection : DevExpress.XtraEditors.XtraForm
    {
        public Dialog_AddDBConnection()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (ConnectionName != "")
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("请输入数据库连接名称！", "系统提示");
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void Dialog_AddDBConnection_Load(object sender, EventArgs e)
        {
            this.comboBoxEdit1.SelectedIndex = 0;
        }

        public string ConnectionName
        {
            get
            {
                string _name = (this.te_Name.EditValue == null) ? "" : this.te_Name.EditValue.ToString();
                return _name;
            }
        }

        public string ConnectionString
        {
            get
            {
                string _des = (this.te_Des.EditValue == null) ? ConnectionName : this.te_Des.EditValue.ToString();
                return _des;
            }
        }

        public string ConnectionType
        {
            get
            {
                string _des = this.comboBoxEdit1.EditValue.ToString();
                return _des;
            }
        }
    }
}