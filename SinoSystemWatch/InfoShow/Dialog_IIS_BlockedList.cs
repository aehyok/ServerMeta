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
    public partial class Dialog_IIS_BlockedList : DevExpress.XtraEditors.XtraForm
    {
        public Dialog_IIS_BlockedList()
        {
            InitializeComponent();
        }

        public Dialog_IIS_BlockedList(string _blockedList)
        {
            InitializeComponent();
            this.textBox1.Text = _blockedList;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        public string BlockedList
        {
            get { return this.textBox1.Text; }
        }
    }
}