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
        public partial class ChartUC_Line : DevExpress.XtraEditors.XtraUserControl, ChartUC_ICS
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
                public ChartUC_Line()
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
                        DrawLines();
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
                private void DrawLines()
                {
                        this.chartControl1.Series.Clear();
                        foreach (string _yfield in AxisYFields)
                        {
                                Series _se = new DevExpress.XtraCharts.Series();
                                _se.View = new DevExpress.XtraCharts.LineSeriesView();
                                _se.PointOptionsTypeName = "PointOptions";
                                _se.PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
                                _se.PointOptions.ValueNumericOptions.Precision = DataPrecision;
                                _se.ValueDataMembers.Clear();
                                _se.DataSource = chartData;
                                _se.ArgumentDataMember = AxisXField;
                                _se.ValueDataMembers.AddRange(new string[] { _yfield });
                                _se.LegendText = AxisYTitle[_yfield];
                                this.chartControl1.Series.Add(_se);
                        }
                        int _rowCount = chartData.Rows.Count;
                        if (_rowCount > 4 && _rowCount <= 8)
                        {
                                XYDiagram _xyDiagram = this.chartControl1.Diagram as XYDiagram;
                                _xyDiagram.AxisX.Label.Staggered = true;
                        }

                        if (_rowCount > 8)
                        {
                                XYDiagram _xyDiagram = this.chartControl1.Diagram as XYDiagram;
                                _xyDiagram.AxisX.Label.Staggered = false;
                                _xyDiagram.AxisX.Label.Angle = 45;
                        }


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
                        //选择线
                        if (e.Object is Series)
                        {
                                Series _se = e.Object as Series;

                                foreach (Series _se1 in this.chartControl1.Series)
                                {
                                        _se1.Label.Visible = showLabel;
                                }

                                _se.Label.Visible = true;
                        }
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
                                        _se.PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
                                        _se.PointOptions.ValueNumericOptions.Precision = DataPrecision;
                                }
                        }
                }

                #region ChartUC_ICS Members


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

                #endregion
        }
}
