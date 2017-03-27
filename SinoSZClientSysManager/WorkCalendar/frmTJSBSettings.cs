using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.WorkCalendar;

namespace SinoSZClientSysManager.WorkCalendar
{
    public partial class frmTJSBSettings : DevExpress.XtraEditors.XtraForm
    {
        public frmTJSBSettings()
        {
            InitializeComponent();
        }

        public frmTJSBSettings(WC_TJSB_Settings Settings)
        {
            InitializeComponent();
            this.te_SBR.EditValue = Settings.SBDay;
            this.te_FTPAddr.EditValue = Settings.FTP_Addr;
            this.te_FTPPort.EditValue = Settings.FTP_Port;
            this.te_FTPPath.EditValue = Settings.FTP_Path;
            this.te_FTPUser.EditValue = Settings.FTP_User;
            this.te_FTPPass.EditValue = Settings.FTP_Pass;
            this.te_DataBackPath.EditValue = Settings.Backup_Path;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        public WC_TJSB_Settings CurrentSet()
        {
            WC_TJSB_Settings _ret = new WC_TJSB_Settings();
            _ret.SBDay = (this.te_SBR.EditValue == null) ? 1 : int.Parse(this.te_SBR.EditValue.ToString());
            _ret.FTP_Addr = (this.te_FTPAddr.EditValue == null) ? "" : this.te_FTPAddr.EditValue.ToString();
            _ret.FTP_Port=(this.te_FTPPort.EditValue == null) ? 21 : int.Parse(this.te_FTPPort.EditValue.ToString());
            _ret.FTP_Path = (this.te_FTPPath.EditValue == null) ? "" : this.te_FTPPath.EditValue.ToString();
            _ret.FTP_User = (this.te_FTPUser.EditValue == null) ? "" : this.te_FTPUser.EditValue.ToString();
            _ret.FTP_Pass = (this.te_FTPPass.EditValue == null) ? "" : this.te_FTPPass.EditValue.ToString();
            _ret.Backup_Path = (this.te_DataBackPath.EditValue == null) ? "" : this.te_DataBackPath.EditValue.ToString();
            return _ret;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}