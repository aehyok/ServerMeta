using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SinoSZMetaDataManager
{
        public partial class Dialog_MoveFieldToGroup : DevExpress.XtraEditors.XtraForm
        {
                public Dialog_MoveFieldToGroup()
                {
                        InitializeComponent();
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

                public void InitItems(List<string> _items)
                {
                        foreach (string _s in _items)
                        {
                                this.comboBoxEdit1.Properties.Items.Add(_s);
                        }
                }

                public string SelectdGroupName
                {
                        get
                        {
                                if (this.comboBoxEdit1.SelectedItem == null) return "";
                                return this.comboBoxEdit1.SelectedItem.ToString();
                        }
                }
        }
}