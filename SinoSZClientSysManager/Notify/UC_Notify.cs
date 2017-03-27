using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SinoSZPluginFramework;
using SinoSZPluginFramework.ClientPlugin;

namespace SinoSZClientSysManager.Notify
{
    public partial class UC_Notify : SinoSZClientBase.PortalItem.SinoSZUC_PortalItemBase
    {
        private IApplication Application = null;
        public UC_Notify()
        {
            InitializeComponent();
        }

        public UC_Notify(string _param, IApplication _application)
        {
            InitializeComponent();
            this.Title = "通知通告";
            Application = _application;
            InitForm();
        }

        private void InitForm()
        {
            using (SinoSZClientBase.CommonService.CommonServiceClient _csc = new SinoSZClientBase.CommonService.CommonServiceClient())
            {
                DataTable _dt = _csc.GetNotifyList(15);
                this.gridControl1.DataSource = _dt;
            }
        }



        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            int _index = this.gridView1.FocusedRowHandle;
            if (_index >= 0)
            {
                DataRow _dr = this.gridView1.GetDataRow(_index);
                string _msgid = _dr["ID"].ToString();
                Dialog_NotifyInfo _f = new Dialog_NotifyInfo(_msgid, true);
                _f.ShowDialog();

            }
        }

        public override void ClickMore()
        {
            if (this.Application != null)
            {
                frmNotifyInfo _frm = MenuFunctions.AddPage<frmNotifyInfo>("通知通告", Application);
                if (_frm != null)
                {
                    _frm.Init("通知通告", "通知通告", "");
                }
            }
        }
    }
}

