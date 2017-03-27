using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZClientBase.MetaDataService;

namespace SinoSZMetaDataManager
{
    public partial class Dialog_AddGuideLine : DevExpress.XtraEditors.XtraForm
    {
        private string _guideLineGroupName = null;
        private decimal _fatherGuideLineID = 1;
        private MD_GuideLineGroup GlGroup = null;
        public Dialog_AddGuideLine()
        {
            InitializeComponent();
        }

        public Dialog_AddGuideLine(MD_GuideLineGroup _glg)
        {
            InitializeComponent();
            _guideLineGroupName = _glg.ZBZTMC;
            GlGroup = _glg;

        }

        public Dialog_AddGuideLine(string _groupName, decimal _fid)
        {
            InitializeComponent();
            _guideLineGroupName = _groupName;
            _fatherGuideLineID = _fid;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (this.textEdit2.EditValue != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("请输入指标名称!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        internal bool SaveData()
        {
            string _guideLineName = this.textEdit2.EditValue.ToString();
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                return _mdc.InsertNewGuideLineItem(_guideLineName, _fatherGuideLineID, _guideLineGroupName);
            }
        }
    }
}