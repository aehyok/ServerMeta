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
                                XtraMessageBox.Show("����������ƣ�", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                        }

                        if (this.CreateNew)
                        {
                                if (PersonAnalizeSapceName == "")
                                {
                                        XtraMessageBox.Show("��������˷����ռ����ƣ�", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                }
                                else
                                {
                                        //if (SinoSZQueryConfig.MetaDataFactroy.IsPASpaceExist(PersonAnalizeSapceName))
                                        //{
                                        //        XtraMessageBox.Show(string.Format(" ����Ϊ\"{0}\"�ĸ��˷����ռ��Ѿ����ڣ����������룡", PersonAnalizeSapceName)
                                        //                , "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                        XtraMessageBox.Show("��ѡ�����еĸ��˷����ռ����ƣ�", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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