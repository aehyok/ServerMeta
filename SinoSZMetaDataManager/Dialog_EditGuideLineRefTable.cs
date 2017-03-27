using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZMetaDataManager
{
        public partial class Dialog_EditGuideLineRefTable : DevExpress.XtraEditors.XtraForm
        {
                private MD_GuideLineParameter _parameterDefine = null;
                public Dialog_EditGuideLineRefTable()
                {
                        InitializeComponent();
                }

                public Dialog_EditGuideLineRefTable(MD_GuideLineParameter _p)
                {
                        InitializeComponent();
                        _parameterDefine = _p;
                        InitForm();
                }
                public string SelectAllCode
                {
                        get
                        {
                                return (this.textEdit1.EditValue == null) ? "" : this.textEdit1.EditValue.ToString();
                        }
                }

                public string RefTableName
                {
                        get
                        {
                                return (this.buttonEdit1.EditValue == null) ? "" : this.buttonEdit1.EditValue.ToString();
                        }
                }
                public bool IncludeChildren
                {
                        get
                        {
                                return this.checkEdit1.Checked;
                        }
                }

                private void InitForm()
                {
                        this.buttonEdit1.EditValue = _parameterDefine.RefTableName;
                        this.checkEdit1.Checked = _parameterDefine.IncludeChildren;
                        this.textEdit1.EditValue = _parameterDefine.SelectAllCode;
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

                private void Dialog_EditGuideLineRefTable_Load(object sender, EventArgs e)
                {

                }
        }
}