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
        public partial class Dialog_AddGuideLineGroup : DevExpress.XtraEditors.XtraForm
        {
                public Dialog_AddGuideLineGroup()
                {
                        InitializeComponent();
                }

                public Dialog_AddGuideLineGroup(MD_Nodes _nodes, string _groupType)
                {
                        InitializeComponent();
                        this.guideLineGroupManager1.InserNew(_nodes,_groupType);
                }

                private void simpleButton1_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                }

                private void simpleButton2_Click(object sender, EventArgs e)
                {
                        string _msg = "";
                        if (this.guideLineGroupManager1.InputCheck(out _msg))
                        {
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                        }
                        else
                        {
                                XtraMessageBox.Show(_msg);
                        }
                }

                public bool SaveData()
                {
                        return this.guideLineGroupManager1.SaveNew();
                }
        }
}