using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SinoSystemWatch.Base.Define;

namespace SinoSystemWatch.ServerNode
{
    public partial class Dialog_AddNode : Form
    {
        public Dialog_AddNode()
        {
            InitializeComponent();
        }

        public Dialog_AddNode(SystemStateItem item)
        {
            InitializeComponent();
            this.te_Name.EditValue = item.SystemName;
            this.te_Name.Properties.ReadOnly = true;
            this.te_Des.EditValue = item.SystemDescription;
            this.te_URL.EditValue = item.SystemURL;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

        }

        private bool CheckInput()
        {
            if (this.te_Name.EditValue == null || this.te_Name.EditValue.ToString() == "")
            {
                MessageBox.Show("请输入系统名称!", "系统提示");
                return false;
            }

            if (this.te_Des.EditValue == null || this.te_Des.EditValue.ToString() == "")
            {
                MessageBox.Show("请输入系统描述!", "系统提示");
                return false;
            }

            if (this.te_URL.EditValue == null || this.te_URL.EditValue.ToString() == "")
            {
                MessageBox.Show("请输入系统URL监控地址!", "系统提示");
                return false;
            }
            return true;
        }

        public SystemStateItem GetSystemStateItem()
        {
            string _name = this.te_Name.EditValue.ToString();
            string _url = this.te_URL.EditValue.ToString();
            string _des = this.te_Des.EditValue.ToString();
            SystemStateItem _item = new SystemStateItem(_name, _url, _des);
            return _item;
        }
    }
}
