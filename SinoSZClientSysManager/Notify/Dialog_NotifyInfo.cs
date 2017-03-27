using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.Notify;

namespace SinoSZClientSysManager.Notify
{
    public partial class Dialog_NotifyInfo : DevExpress.XtraEditors.XtraForm
    {
        private string MsgID = "";
        private NotifyInfo _info = null;
        public Dialog_NotifyInfo()
        {
            InitializeComponent();
        }

        public Dialog_NotifyInfo(string _msgid, bool readOnly)
        {
            InitializeComponent();
            MsgID = _msgid;
            InitForm();
            SetEditState(readOnly);
        }

        private void SetEditState(bool readOnly)
        {
            this.te_xxbt.Properties.ReadOnly = readOnly;
            this.te_xxnr.Properties.ReadOnly = readOnly;
            this.te_fbdwmc.Properties.ReadOnly = readOnly;
            this.te_fbr.Properties.ReadOnly = readOnly;
            this.te_fbsj.Properties.ReadOnly = readOnly;
            this.te_tel.Properties.ReadOnly = readOnly;
            this.te_email.Properties.ReadOnly = readOnly;
        }

        private void InitForm()
        {
            using (SinoSZClientBase.CommonService.CommonServiceClient _csc = new SinoSZClientBase.CommonService.CommonServiceClient())
            {
                _info = _csc.GetNotifyInfo(MsgID);
            }
            if (_info != null)
            {
                ShowInofData();
            }
        }

        private void ShowInofData()
        {
            this.te_xxbt.EditValue = _info.Title;
            this.te_xxnr.EditValue = _info.Context;
            this.te_fbdwmc.EditValue = _info.FBdwmc;
            this.te_fbr.EditValue = _info.FByhmc;
            this.te_fbsj.EditValue = _info.SendTime;
            this.te_tel.EditValue = _info.TelNum;
            this.te_email.EditValue = _info.Email;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
    }
}