using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.Misc;
using System.ServiceModel;

namespace SinoSZClientSysManager.GDSManager
{
    public partial class UC_GDSTest : UserControl
    {
        private List<MD_GuideLineSimpleParam> ParamList = new List<MD_GuideLineSimpleParam>();
        private string CommandName = "";
        public UC_GDSTest()
        {
            InitializeComponent();
        }

        public void InitData(string _cmdname)
        {
            CommandName = _cmdname;
        }

        private void UC_GDSTest_Load(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = ParamList;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Dialog_AddCallParam _f = new Dialog_AddCallParam();
            DialogResult _dr = _f.ShowDialog();
            if (_dr == DialogResult.OK)
            {
                MD_GuideLineSimpleParam _p = new MD_GuideLineSimpleParam();
                _p.ParameterName = _f.ParamName;
                _p.ParameterValue = _f.ParamValue;
                this.gridView1.BeginDataUpdate();
                ParamList.Add(_p);
                this.gridView1.EndDataUpdate();
                this.gridView1.RefreshData();
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                MD_GuideLineSimpleParam _p = gridView1.GetRow(this.gridView1.FocusedRowHandle) as MD_GuideLineSimpleParam;
                this.gridView1.BeginDataUpdate();
                ParamList.Remove(_p);
                this.gridView1.EndDataUpdate();
                this.gridView1.RefreshData();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string _url = (te_URL.EditValue == null) ? "" : te_URL.EditValue.ToString();
            string _token = (te_Token.EditValue == null) ? "" : te_Token.EditValue.ToString();
            string _xmlData = DataConvert.Serializer(typeof(List<MD_GuideLineSimpleParam>), ParamList);
            this.te_CallData.Text = _xmlData;
            JSGeneralDataService.JSGeneralDataServiceClient _jdsc = new JSGeneralDataService.JSGeneralDataServiceClient();
            _jdsc.Endpoint.Address = new EndpointAddress(new Uri(_url));

            try
            {
                string _msg = _jdsc.Do(_token, CommandName, _xmlData);
                this.te_Return.Text = _msg;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误");
            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string _url = (te_URL.EditValue == null) ? "" : te_URL.EditValue.ToString();
            string _token = (te_Token.EditValue == null) ? "" : te_Token.EditValue.ToString();
            Dialog_PerformanceTest _dpf = new Dialog_PerformanceTest(_url, _token, this.CommandName);
            _dpf.ShowDialog();
        }



    }
}
