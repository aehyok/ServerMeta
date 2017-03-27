using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.Misc;

namespace SinoSZClientSysManager.GDSManager
{
    public partial class UC_GDSLog : DevExpress.XtraEditors.XtraUserControl
    {
        public string CommandName { get; set; }
        public UC_GDSLog()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string _stCount = this.textEdit1.EditValue.ToString();
            if (StrUtils.IsDigit(_stCount))
            {
                decimal _count = decimal.Parse(_stCount);
                using (SinoSZClientBase.CommonService.CommonServiceClient _csc = new SinoSZClientBase.CommonService.CommonServiceClient())
                {
                   DataTable _dt=   _csc.GetICSLogRecord(CommandName, _count);
                   this.gridControl1.BeginUpdate();
                   this.gridControl1.DataSource = _dt;
                   this.gridControl1.EndUpdate();
                   this.gridView1.RefreshData();
                }
            }
        }
    }
}
