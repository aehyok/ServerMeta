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
        public partial class Dialog_AddQueryModel : DevExpress.XtraEditors.XtraForm
        {
                private MD_QueryModel _model = null;
                public Dialog_AddQueryModel()
                {
                        InitializeComponent();
                }

                public Dialog_AddQueryModel(MD_Namespace _ns)
                {
                        InitializeComponent();
                        this.queryModelManager1.SetNamespace(_ns);
                }
                private void simpleButton1_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                }

                private void simpleButton2_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                }

                public MD_QueryModel SaveData()
                {
                       _model=  this.queryModelManager1.SaveNew();
                       return _model;
                        
                }
        }
}