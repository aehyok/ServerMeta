using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Text.RegularExpressions;
using DevExpress.XtraGrid.Columns;
using SinoSZClientBase.Export;
using SinoSZClientBase.ShowChart;
using SinoSZJS.Base.Report.ReportGuideLine;

namespace SinoSZClientReport.ReportGuideLine
{
    public partial class ReportGuideLineUC_Query : DevExpress.XtraEditors.XtraUserControl
    {
        private DateTime startDate = DateTime.Now;
        private DateTime endDate = DateTime.Now;
        private string dwdm = "";
        private MD_ReportGuideLineItem currentGuideLine = null;
        private string runningGuideLineID = "";
        private MD_ReportGuideLineDefine currentDefine = null;
        private Dictionary<string, MD_RGL_FieldDefine> fieldDict = new Dictionary<string, MD_RGL_FieldDefine>();
        private DataTable _zbData = null;
        private DataTable _detailData = null;

        public ReportGuideLineUC_Query()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            this.gridControl1.BeginUpdate();
            this.gridControl1.DataSource = null;
            this.gridView1.Columns.Clear();
            this.gridControl1.EndUpdate();


            this.sinoCommonGrid1.BeginUpdate();
            this.sinoCommonGrid1.DataSource = null;
            this.gridView2.Columns.Clear();
            this.sinoCommonGrid1.EndUpdate();
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public string DWDM
        {
            get { return dwdm; }
            set { dwdm = value; }
        }

        public MD_ReportGuideLineItem CurrentGuideLine
        {
            get { return currentGuideLine; }
            set { currentGuideLine = value; }
        }

        public void ShowData()
        {
            if (this.currentGuideLine == null) return;
            if (this.currentGuideLine.Type == Enum_ReportGuideLineItemType.GuideLine)
            {
                if (!this.backgroundWorker1.IsBusy)
                {
                    this.panelWait.Visible = true;
                    this.backgroundWorker1.RunWorkerAsync();
                }
            }
            else
            {
                this.runningGuideLineID = "";
                Clear();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            runningGuideLineID = this.currentGuideLine.ID;
            using (SinoSZClientBase.ReportService.ReportServiceClient _rsc = new SinoSZClientBase.ReportService.ReportServiceClient())
            {
                currentDefine = _rsc.GetReportGuideLineDefine(this.currentGuideLine.ID);
                fieldDict = CreateFieldDictionary(currentDefine.ZBMeta);
                DataSet _ds = _rsc.GetReportGuideLineData(this.currentDefine, StartDate, EndDate, DWDM);
                _zbData = (_ds.Tables.Count > 0) ? _ds.Tables[0] : null;
                DataSet _detailds = _rsc.GetReportGuideLineDetailData(this.currentDefine, StartDate, EndDate, DWDM);
                _detailData = (_detailds.Tables.Count > 0) ? _detailds.Tables[0] : null;
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.currentGuideLine != null && this.currentGuideLine.ID != runningGuideLineID)
            {
                this.panelWait.Visible = true;
                this.backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                if (_zbData.Rows.Count > 0)
                {
                    _zbData.Columns.Add("ZBMC");
                    _zbData.Rows[0]["ZBMC"] = currentDefine.DisplayName;
                }
                this.gridView1.BeginUpdate();
                CreateGridColumns(_zbData, fieldDict, this.gridView1);
                this.gridControl1.DataSource = _zbData;
                this.gridView1.EndUpdate();

                this.gridView2.BeginUpdate();
                CreateGridColumns(_detailData, fieldDict, this.gridView2);
                this.sinoCommonGrid1.DataSource = _detailData;
                this.gridView2.IndicatorWidth = this.gridView2.RowCount.ToString().Length * 10 + 15;
                this.gridView2.EndUpdate();
                this.panelWait.Visible = false;
            }

        }

        private void CreateGridColumns(DataTable _zbData, Dictionary<string, MD_RGL_FieldDefine> fieldDict, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            gridView.Columns.Clear();
            List<MD_RGL_FieldDefine> _usedList = new List<MD_RGL_FieldDefine>();
            foreach (DataColumn _dc in _zbData.Columns)
            {
                if (fieldDict.ContainsKey(_dc.ColumnName))
                {
                    MD_RGL_FieldDefine _item = fieldDict[_dc.ColumnName];
                    _usedList.Add(_item);
                }
            }

            _usedList.Sort(new Comparer_RGL_FieldDefine());
            int _index = 0;
            foreach (MD_RGL_FieldDefine _item in _usedList)
            {
                GridColumn _gc = gridView.Columns.Add();
                _gc.FieldName = _item.FieldName;
                _gc.Caption = _item.DisplayName;
                _gc.Width = (_item.DisplayWidth > 10) ? _gc.Width : 10;
                _gc.OptionsColumn.ReadOnly = true;
                _gc.Visible = true;
                _gc.VisibleIndex = _index++;
            }

        }

        private Dictionary<string, MD_RGL_FieldDefine> CreateFieldDictionary(string _meta)
        {
            RegexOptions options = RegexOptions.None;
            Regex regeMeta = new Regex(@"<FN>[^<]{1,}</FN>", options);

            Dictionary<string, MD_RGL_FieldDefine> _ret = new Dictionary<string, MD_RGL_FieldDefine>();
            _ret.Add("ZBMC", new MD_RGL_FieldDefine("ZBMC", "Ö¸±ê", 0, 200));

            MatchCollection _mc = regeMeta.Matches(_meta);
            foreach (Match _m in _mc)
            {
                string _s2 = _m.Value.Substring(4, _m.Length - 9);
                string[] _s3 = _s2.Split(':');
                if (_s3.Length > 1)
                {
                    MD_RGL_FieldDefine _item = new MD_RGL_FieldDefine(_s3[0],
                            (_s3.Length > 1) ? _s3[1] : "",
                            (_s3.Length > 2) ? int.Parse(_s3[2]) : 0,
                            (_s3.Length > 3) ? int.Parse(_s3[3]) : 0);

                    _ret.Add(_s3[0], _item);
                }

            }

            return _ret;
        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                e.Info.DisplayText = e.RowHandle >= 0 ? (e.RowHandle + 1).ToString() : "";
            }
        }



        public void ExportData()
        {
            SinoSZExport_GridViewData.Export(this.gridView2);
        }


        public void ShowChart(SinoSZPluginFramework.IApplication _application)
        {
            DataTable _dt = this.sinoCommonGrid1.DataSource as DataTable;
            Dictionary<string, string> _fdict = new Dictionary<string, string>();
            foreach (MD_RGL_FieldDefine _f in this.fieldDict.Values)
            {
                _fdict.Add(_f.FieldName, _f.DisplayName);
            }
            frmChartShow _form = new frmChartShow(_dt, _fdict);
            _application.AddForm(Guid.NewGuid().ToString(), _form);
        }



    }
}
