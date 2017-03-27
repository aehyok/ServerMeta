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
    public partial class Dialog_InputSHInfo : DevExpress.XtraEditors.XtraForm
    {
        protected List<DataRow> SelectedRows = new List<DataRow>();
        private string QueryModelName = "";
        private string MainTableName = "";
        private string MainKeyName = "";
        private string CurrentLevel = "";
        public Dialog_InputSHInfo()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string _msg = "";
            using (SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient _rsc = new SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient())
            {
                if (this.sinoUC_SHInput1.CheckInput(ref _msg))
                {
                    foreach (DataRow _dr in this.SelectedRows)
                    {
                        string _mainkeyId = _dr["MAINID"].ToString();
                        string CurrentWHXH = _rsc.GetDataCheckWHXH(MainTableName, MainKeyName, _mainkeyId);
                        string SHID = "";
                        string SHJLID = _rsc.GetDataCheckInfoJLID(QueryModelName, _mainkeyId, this.CurrentLevel, ref SHID);
                        bool _ret = this.sinoUC_SHInput1.ShData(_dr, CurrentWHXH, this.CurrentLevel, SHID, SHJLID);
                        if (_ret)
                        {
                            _dr["GX_STATE"] = 0;
                        }
                    }
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show(_msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void InitForm()
        {

        }

        internal void InitForm(List<DataRow> _selectedRows, string _queryModelName, string _mainTableName, string _mainKey)
        {
            QueryModelName = _queryModelName;
            MainTableName = _mainTableName;
            MainKeyName = _mainKey;
            using (SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient _rsc = new SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient())
            {
                CurrentLevel = _rsc.GetUserLevel();
            }
            SelectedRows = _selectedRows;
            this.sinoUC_SHInput1.SetCurrentSHR();
            this.sinoUC_SHInput1.CanEdit = true;

        }
    }
}