using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SinoSZClientReport.DataCheck
{
    public partial class Dialog_ImportRules : DevExpress.XtraEditors.XtraForm
    {
        private string QueryModelName = "";
        private DataTable RuleList = null;
        public Dialog_ImportRules()
        {
            InitializeComponent();
        }

        public List<DataRow> SelectedRules
        {
            get
            {
                List<DataRow> _ret = new List<DataRow>();
                foreach (DataRow _dr in RuleList.Rows)
                {
                    if ((bool)_dr["STATE"])
                    {
                        _ret.Add(_dr);
                    }
                }
                return _ret;
            }
        }
        public void InitRuleList(string _qv)
        {
            DataSet _ds;
            QueryModelName = _qv;
            using (SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient _rsc = new SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient())
            {
                _ds = _rsc.GetRuleList(QueryModelName);
            }
            if (_ds != null && _ds.Tables.Count > 0)
            {
                RuleList = _ds.Tables[0];
                RuleList.Columns.Add("STATE", typeof(bool));
                foreach (DataRow _dr in RuleList.Rows)
                {
                    _dr["STATE"] = false;
                }
                RuleList.AcceptChanges();

                this.gridControl1.DataSource = RuleList;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            CurrencyManager cm_Meta2 = (CurrencyManager)this.BindingContext[RuleList, ""];
            cm_Meta2.EndCurrentEdit();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}