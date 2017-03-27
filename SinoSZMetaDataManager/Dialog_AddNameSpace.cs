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
        public partial class Dialog_AddNameSpace : DevExpress.XtraEditors.XtraForm
        {
                public Dialog_AddNameSpace()
                {
                        InitializeComponent();
                }

                public Dialog_AddNameSpace(MD_Nodes _node)
                {
                        InitializeComponent();
                        this.nameSpaceManager1.InsertNewNs(_node);
                }


                private void simpleButton2_Click(object sender, EventArgs e)
                {
                        string _msg = "";
                        if (this.nameSpaceManager1.InputCheck(out _msg))
                        {
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                        }
                        else
                        {
                                XtraMessageBox.Show(_msg);
                        }
                }

                private void simpleButton1_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                }

                public void SaveData(MD_Nodes _node)
                {
                        this.nameSpaceManager1.SaveNew(_node); 
                }
        }
}