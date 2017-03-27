using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;
using SinoSZClientBase.MetaDataService;

namespace SinoSZMetaDataManager
{
        public partial class Dialog_AddTableRelationView : DevExpress.XtraEditors.XtraForm
        {
                public string SelectdModelName
                {
                        get
                        {
                                if (this.comboBoxEdit1.EditValue == null)
                                {
                                        return "";
                                }
                                else
                                {
                                        return this.comboBoxEdit1.EditValue.ToString();
                                }
                        }
                }

                public Dialog_AddTableRelationView()
                {
                        InitializeComponent();
                }

                public Dialog_AddTableRelationView(string _tid)
                {
                        InitializeComponent();
                        InitForm();
                }

                private void InitForm()
                {
                        this.comboBoxEdit1.Properties.Items.Clear();
                        using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
                        {
                            string[] _modelNames = _mdc.GetAllQueryModelNames();
                            foreach (string _qv in _modelNames)
                            {
                                this.comboBoxEdit1.Properties.Items.Add(_qv);
                            }
                        }
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
        }
}