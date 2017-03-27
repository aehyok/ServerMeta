using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using SinoSZClientBase.Export;

namespace SinoSZClientBase.ShowChart
{
    public partial class ChartUC_Pie : DevExpress.XtraEditors.XtraUserControl, ChartUC_ICS
    {
        protected bool showLabel = true;
        protected bool showLegend = true;
        protected bool showAxisYAsLog = true;
        protected bool canSelect = false;
        protected string chartTitle = "";
        protected DataTable chartData = null;
        protected string AxisXField = "";
        protected List<string> AxisYFields = null;
        protected Dictionary<string, string> AxisYTitle = null;
        protected int dataPrecision = 0;

        public ChartUC_Pie()
        {
            InitializeComponent();
        }


        #region 实现作图接口

        public void InitChart(DataTable _dt, string _Xfields, List<string> _Yfields, Dictionary<string, string> _Titles, bool _ShowLable, bool _ShowLegend, bool _ShowAxisYAsLog, bool _CanSelect, int _precision)
        {
            InitChart(_dt, _Xfields, _Yfields, _Titles, _ShowLable, _ShowLegend, _ShowAxisYAsLog, _CanSelect, _precision, "");
        }

        public void InitChart(DataTable _dt, string _Xfields, List<string> _Yfields, Dictionary<string, string> _Titles, bool _ShowLable, bool _ShowLegend, bool _ShowAxisYAsLog, bool _CanSelect, int _precision, string _title)
        {
            chartData = _dt;
            AxisXField = _Xfields;
            AxisYFields = _Yfields;
            chartTitle = _title;
            AxisYTitle = _Titles;
            dataPrecision = _precision;
            DrawBars();
            ShowLabel = _ShowLable;
            ShowLegend = _ShowLegend;
            ShowAxisYAsLog = _ShowAxisYAsLog;
            CanSelect = _CanSelect;
        }

        public bool CanSelect
        {
            get
            {
                return canSelect;
            }
            set
            {
                canSelect = value;
                DrawCanSelect();
            }
        }



        public bool ShowLabel
        {
            get
            {
                return showLabel;
            }
            set
            {
                showLabel = value;
                DrawChartLabel();
            }
        }

        public bool ShowLegend
        {
            get
            {
                return showLegend;
            }
            set
            {
                showLegend = value;
                DrawChartLegend();
            }
        }



        public bool ShowAxisYAsLog
        {
            get
            {
                return showAxisYAsLog;
            }
            set
            {
                showAxisYAsLog = value;
                DrawAxisYAsLog();
            }
        }

        #endregion

        #region 画柱图
        private void DrawBars()
        {
            this.chartControl1.Series.Clear();
            foreach (string _yfield in AxisYFields)
            {
                Series _se = new DevExpress.XtraCharts.Series();
                _se.View = new DevExpress.XtraCharts.PieSeriesView();
                PieSeriesView _pv = _se.View as PieSeriesView;
                _pv.RuntimeExploding = true;


                PieSeriesLabel _ps = _se.Label as PieSeriesLabel;
                _ps.Position = PieSeriesLabelPosition.TwoColumns;

                PiePointOptions _piePointOptions = _se.PointOptions as PiePointOptions;
                _se.PointOptions.HiddenSerializableString = "to be serialized";
                _se.PointOptions.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues;
                _piePointOptions.PercentOptions.ValueAsPercent = true;
                _piePointOptions.PercentOptions.PercentageAccuracy = dataPrecision + 2;
                //_piePointOptions.PercentOptions.ValuePercentPrecision = dataPrecision + 2;
                _se.PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                _se.PointOptions.ValueNumericOptions.Precision = dataPrecision;
                _se.PointOptionsTypeName = "PiePointOptions";
                _se.ValueDataMembers.Clear();
                _se.DataSource = chartData;
                _se.ArgumentDataMember = AxisXField;
                _se.ValueDataMembers.AddRange(new string[] { _yfield });
                _se.LegendText = AxisYTitle[_yfield];
                this.chartControl1.Series.Add(_se);
            }
            int _rowCount = chartData.Rows.Count;


        }
        #endregion

        #region 显示图形的标签
        private void DrawChartLabel()
        {
            foreach (Series _se in this.chartControl1.Series)
            {
                _se.Label.Visible = showLabel;
            }
        }
        #endregion

        #region 显示图形的注解
        private void DrawChartLegend()
        {
            this.chartControl1.Legend.Visible = showLegend;
        }
        #endregion

        #region 显示指标座标
        private void DrawAxisYAsLog()
        {

        }
        #endregion

        #region 是否可以鼠标选择
        private void DrawCanSelect()
        {
            this.chartControl1.RuntimeSelection = canSelect;
        }
        #endregion

        private void chartControl1_ObjectSelected(object sender, HotTrackEventArgs e)
        {

        }private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }



        public int DataPrecision
        {
            get
            {
                return dataPrecision;
            }
            set
            {
                this.dataPrecision = value;
                foreach (Series _se in this.chartControl1.Series)
                {
                    PiePointOptions _piePointOptions = _se.PointOptions as PiePointOptions;
                    //_piePointOptions.PercentOptions.ValuePercentPrecision = DataPrecision + 2;
                    _piePointOptions.PercentOptions.PercentageAccuracy = DataPrecision + 2;
                    _se.PointOptions.ValueNumericOptions.Precision = DataPrecision;
                }
            }
        }



        public bool ExportChart()
        {

            if (SinoSZEXport_DevChart.Export(this.chartControl1))
            {
                XtraMessageBox.Show("导出图表成功！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                XtraMessageBox.Show("导出图表失败！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


    }
}
