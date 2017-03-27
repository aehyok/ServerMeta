using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZClientBase;
using SinoSZJS.Base.Misc;


namespace SinoSZClientSysManager.ResetServer
{
    public partial class frmResetIISApp : frmBase
    {
        private string AppName { get; set; }

        public frmResetIISApp()
        {
            InitializeComponent();
        }

        public override void Init(string _title, string _menuName, object _param)
        {
            this.Text = _title;
            this._menuPageName = _menuName;
            this._initFinished = true;
            string _pstr = _param.ToString();
            AppName = StrUtils.GetMetaByName2("AppPoolName", _pstr);
            this.Text = StrUtils.GetMetaByName2("TITLE", _pstr);
            this.txt_AppName.Text = AppName;
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SinoSZClientBase.CommonService.CommonServiceClient _csc = new SinoSZClientBase.CommonService.CommonServiceClient())
                {
                    string _ret = _csc.RecycleIISPool(AppName);
                    if (_ret != "回收成功")
                    {
                        MessageBox.Show(_ret, "失败");
                    }
                    else
                    {
                        MessageBox.Show(_ret, "系统提示");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "启动失败");
            }
        }
    }
}