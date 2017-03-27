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
        public partial class Dialog_AddNode : DevExpress.XtraEditors.XtraForm
        {
                private MD_Nodes _nodesData = null;
                public Dialog_AddNode()
                {
                        InitializeComponent();
                }

              

                private void simpleButton2_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                }

                private void simpleButton1_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                }

                public MD_Nodes SaveData()
                {
                        _nodesData = this.nodeManager1.SaveNew();
                        return _nodesData;
                }
        }
}