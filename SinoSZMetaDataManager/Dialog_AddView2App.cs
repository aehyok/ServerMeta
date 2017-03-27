using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.MetaData.Define;

namespace SinoSZMetaDataManager
{
    public partial class Dialog_AddView2App : DevExpress.XtraEditors.XtraForm
    {
        public Dialog_AddView2App()
        {
            InitializeComponent();
        }

        public Dialog_AddView2App(MD_View2App _data)
        {
            InitializeComponent();
            this.sinoUC_QME_View2APP1.InitData(_data);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public MD_View2App GetInputData()
        {
            return this.sinoUC_QME_View2APP1.GetData();
        }
    }
}