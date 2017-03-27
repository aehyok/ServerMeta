using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.Authorize;
using SinoSZJS.Base.Misc;
using System.Configuration;

namespace SinoSZClientBase
{
    public partial class frmSetParameter : DevExpress.XtraEditors.XtraForm
    {
        public frmSetParameter()
        {
            InitializeComponent();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            Configuration configuration = null;                 //Configuration对象
            AppSettingsSection appSection = null;               //AppSection对象 

            configuration = ConfigurationManager.OpenExeConfiguration(Utils.ExeFullPath);

            //取得AppSetting节
            appSection = configuration.AppSettings;

            //赋值并保存
            appSection.Settings["LiveUpdate_SvrInfoUrl"].Value = this.te_liveupdate.EditValue.ToString();
            configuration.Save();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public void InitData()
        {
            //this.te_type.Properties.Items.Add(Config_IcsChannel.Tcp);
            //this.te_type.Properties.Items.Add(Config_IcsChannel.Http);
            //this.te_type.EditValue = ConfigFile.ICS_Channel;
            this.te_liveupdate.EditValue = ConfigFile.LiveUpdate_SvrInfoUrl;
        }
    }
}