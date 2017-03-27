using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.Report.DataCheck;
using System.Linq;

namespace SinoSZClientReport.DataCheck
{
    public partial class Dialog_ShowHisData : DevExpress.XtraEditors.XtraForm
    {
        private DataTable _dt = null;
        private MDModel_QueryModel QueryModel = null;
        private DataRow CurrentRow = null;
        private string HisWHXH = "";
        private string MainKeyID = "";
        public Dialog_ShowHisData()
        {
            InitializeComponent();
        }

        private void Dialog_ShowHisData_Load(object sender, EventArgs e)
        {

        }

        public void InitData(DataRow _crow, string _hiswhxh, MDModel_QueryModel _model,string _mainkey)
        {
            QueryModel = _model;
            CurrentRow = _crow;
            HisWHXH = _hiswhxh;
            MainKeyID = _mainkey;
            ShowData();
        }

        private void ShowData()
        {
            using (SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient _rsc = new SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient())
            {
                List<ReportHisDataRow> _ret = _rsc.GetSjsh_HisData(this.QueryModel.FullQueryModelName, MainKeyID, HisWHXH).ToList<ReportHisDataRow>();
                this.gridControl1.DataSource = _ret;
            }
          
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}