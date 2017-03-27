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
    public partial class Dialog_AddCallParam : DevExpress.XtraEditors.XtraForm
    {
        public Dialog_AddCallParam()
        {
            InitializeComponent();
        }


        public string ParamName
        {
            get
            {
                return (this.te_PName.EditValue == null) ? "" : this.te_PName.EditValue.ToString();
            }
        }

        public string ParamValue
        {
            get
            {
                return (this.te_PValue.EditValue == null) ? "" : this.te_PValue.EditValue.ToString();
            }
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
    }
}