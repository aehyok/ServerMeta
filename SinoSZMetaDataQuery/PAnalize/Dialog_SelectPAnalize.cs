using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.PAnalize;


namespace SinoSZMetaDataQuery.PAnalize
{
        public partial class Dialog_SelectPAnalize : DevExpress.XtraEditors.XtraForm
        {
                private MD_PAnalizeProject _project = null;
                public string TableDisplayName
                {
                        get
                        {
                                if (this.textEdit1.EditValue == null) return "";
                                return this.textEdit1.EditValue.ToString();
                        }
                }
                public MD_PAnalizeProject CurrentProject
                {
                        get
                        {
                                return _project;
                        }
                }


                public bool CreateNew
                {
                        get { return this.radioButton1.Checked; }
                }

                public string PersonAnalizeSapceName
                {
                        get
                        {
                                if (CreateNew)
                                {
                                        if (this.textEdit2.EditValue == null) return "";
                                        return this.textEdit2.EditValue.ToString();
                                }
                                else
                                {
                                        return "";
                                }
                        }
                }

                public Dialog_SelectPAnalize()
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
                        if (TableDisplayName == "")
                        {
                                XtraMessageBox.Show("请输入表名称！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                        }

                        if (this.CreateNew)
                        {
                                if (PersonAnalizeSapceName == "")
                                {
                                        XtraMessageBox.Show("请输入个人分析空间名称！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                }
                                else
                                {
                                        //if (SinoSZQueryConfig.MetaDataFactroy.IsPASpaceExist(PersonAnalizeSapceName))
                                        //{
                                        //        XtraMessageBox.Show(string.Format(" 名称为\"{0}\"的个人分析空间已经存在，请重新输入！", PersonAnalizeSapceName)
                                        //                , "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        //        return;
                                        //}
                                        //else
                                        //{
                                        //        _project = SinoSZQueryConfig.MetaDataFactroy.CreateNewPASpace(PersonAnalizeSapceName);
                                        //        this.DialogResult = DialogResult.OK;
                                        //        this.Close();
                                        //}
                                }
                        }
                        else
                        {
                                if (this.comboBoxEdit1.SelectedItem == null)
                                {
                                        XtraMessageBox.Show("请选择已有的个人分析空间名称！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                }
                                else
                                {
                                        _project = this.comboBoxEdit1.SelectedItem as MD_PAnalizeProject;
                                        this.DialogResult = DialogResult.OK;
                                        this.Close();
                                }
                        }
                }

                private void radioButton1_CheckedChanged(object sender, EventArgs e)
                {
                        this.textEdit2.Enabled = this.radioButton1.Checked;
                }

                private void radioButton2_CheckedChanged(object sender, EventArgs e)
                {
                        this.comboBoxEdit1.Enabled = this.radioButton2.Checked;
                }



                public void InitData()
                {
                        //List<MD_PAnalizeProject> ExistProjects = SinoSZQueryConfig.MetaDataFactroy.GetPAProjectOfUser();
                        //this.comboBoxEdit1.Properties.Items.Clear();
                        //foreach (MD_PAnalizeProject _p in ExistProjects)
                        //{
                        //        this.comboBoxEdit1.Properties.Items.Add(_p);
                        //}
                }
        }
}