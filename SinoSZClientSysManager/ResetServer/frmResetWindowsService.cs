using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZClientBase;
using SinoSZJS.Base.V2.Misc;

namespace SinoSZClientSysManager.ResetServer
{
    public partial class frmResetWindowsService : frmBase
    {
        private string ServiceName { get; set; }

        public frmResetWindowsService()
        {
            InitializeComponent();
        }

        public override void Init(string _title, string _menuName, object _param)
        {
            this.Text = _title;
            this._menuPageName = _menuName;
            this._initFinished = true;
            string _pstr = _param.ToString();
            ServiceName = StrUtils.GetMetaByName2(_pstr, "ServiceName");
            this.Text = StrUtils.GetMetaByName2(_pstr, "TITLE");
            this.txt_ServiceName.Text = ServiceName;
            this.button1.Visible = false;
            this.timer1.Enabled = false;
            RunGetState();
        }

        private void RunGetState()
        {
            if (!this.backgroundWorker1.IsBusy)
            {
                this.backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                this.timer1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool _ret;
            this.button1.Enabled = false;
            using (SinoSZClientBase.CommonService.CommonServiceClient _csc = new SinoSZClientBase.CommonService.CommonServiceClient())
            {
                switch (this.button1.Text)
                {
                    case "停止服务":
                        _ret = _csc.ResetService(ServiceName, "STOP");
                        break;
                    case "启动服务":
                        _ret = _csc.ResetService(ServiceName, "START");
                        break;

                }

            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            using (SinoSZClientBase.CommonService.CommonServiceClient _csc = new SinoSZClientBase.CommonService.CommonServiceClient())
            {
                e.Result = _csc.GetServiceState(ServiceName);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string _st = e.Result.ToString();
            this.txt_ServiceState.Text = e.Result.ToString();
            switch (_st)
            {
                case "Running":
                    this.button1.Text = "停止服务";
                    this.button1.Visible = true;
                    this.button1.Enabled = true;
                    break;
                case "Stopped":
                    this.button1.Text = "启动服务";
                    this.button1.Visible = true;
                    this.button1.Enabled = true;
                    break;
                default:
                    this.button1.Visible = false;
                    this.button1.Enabled = false;
                    break;
            }
            this.timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            RunGetState();
        }
    }
}