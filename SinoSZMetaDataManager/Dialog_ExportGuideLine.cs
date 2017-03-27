using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using SinoSZJS.Base.MetaData.QueryModel;
using System.Linq;
using SinoSZClientBase.MetaDataService;

namespace SinoSZMetaDataManager
{
    public partial class Dialog_ExportGuideLine : DevExpress.XtraEditors.XtraForm
    {
        private MD_GuideLine GuideLine = null;
        private MD_GuideLine CurrentGuideLine = null;

        public Dialog_ExportGuideLine()
        {
            InitializeComponent();
        }

        public Dialog_ExportGuideLine(MD_GuideLine _guideLine)
        {
            InitializeComponent();
            CurrentGuideLine = _guideLine;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.buttonEdit1.EditValue == null || this.buttonEdit1.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("请输入文件名!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.checkEdit1.Checked)
            {
                GuideLine = Copy(CurrentGuideLine);
                using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
                {
                    GetAllChildGuideLine(GuideLine,_mdc);
                }
            }
            else
            {
                GuideLine = Copy(CurrentGuideLine);
            }

            string _fname = this.buttonEdit1.EditValue.ToString();

            DataContractSerializer s = new DataContractSerializer(typeof(MD_GuideLine));
            using (FileStream fs = File.Open(_fname, FileMode.Create))
            {
                s.WriteObject(fs, GuideLine);
            }


            //IFormatter formatter = new BinaryFormatter();
            //FileStream stream = new FileStream(_fname,FileMode.Create);
            //formatter.Serialize(stream, GuideLine);
            //long _ret = stream.Length;
            //stream.Close();                  

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private MD_GuideLine Copy(MD_GuideLine _guideLine)
        {
            MD_GuideLine _ret = new MD_GuideLine(_guideLine.ID, _guideLine.GuideLineName, _guideLine.GroupName, _guideLine.GuideLineMethod,
                    _guideLine.GuideLineMeta, _guideLine.FatherID, _guideLine.GuideLineQueryMethod, _guideLine.DetailMeta, _guideLine.DisplayOrder, _guideLine.Description);
            return _ret;
        }

        private void GetAllChildGuideLine(MD_GuideLine _guideLine, MetaDataServiceClient _mdc)
        {

            List<MD_GuideLine> _childGuideLineList = _mdc.GetChildGuideLines(_guideLine.ID).ToList<MD_GuideLine>();
            _guideLine.Children = _childGuideLineList;
            foreach (MD_GuideLine _gl in _childGuideLineList)
            {
                GetAllChildGuideLine(_gl, _mdc);
            }

        }



        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SaveFileDialog _f = new SaveFileDialog();
            _f.Filter = "备份文件 (*.bak) | *.bak";
            if (_f.ShowDialog() == DialogResult.OK)
            {
                this.buttonEdit1.EditValue = _f.FileName;
            }
        }
    }
}