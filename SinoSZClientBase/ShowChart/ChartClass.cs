using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace SinoSZClientBase.ShowChart
{
        /// <summary>
        /// ChartClass 的摘要说明。
        /// </summary>
        public class ChartClass
        {
                public ChartClass()
                {
                        //
                        // TODO: 在此处添加构造函数逻辑
                        //
                }
                //public static Color[] ChartColorSet = new Color[]{Color.Red,Color.Blue,Color.Green,Color.Yellow,Color.Aquamarine,
                //                                                                                                        Color.DarkRed,Color.DarkBlue,Color.DarkGreen,Color.Gold,Color.Gray,
                //                                                                                                        Color.Magenta,Color.LightBlue,Color.LightGreen,Color.LightGoldenrodYellow,Color.LightGray};

                //public static ChartControl CreateBarChart(DataTable _dt, string _Xfields, ArrayList _Yfields)
                //{
                //        return CreateBarChart(_dt, _Xfields, _Yfields, true);
                //}

                //public static ChartControl CreateBarChart(DataTable _dt, string _Xfields, ArrayList _Yfields, bool _ShowLable)
                //{
                //        ChartControl _resChart = new ChartControl();
                //        _resChart.Charts.Clear();
                //        //_resChart.Charts.Add(new  Xceed.Chart.Core.Chart());

                //        #region 初始化 chartControl1
                //        // 
                //        _resChart.AutoScrollMargin = new System.Drawing.Size(0, 0);
                //        _resChart.AutoScrollMinSize = new System.Drawing.Size(0, 0);
                //        _resChart.BackColor = System.Drawing.SystemColors.ActiveBorder;

                //        _resChart.Charts.Add(new Xceed.Chart.Core.Chart());
                //        _resChart.Location = new System.Drawing.Point(392, 8);
                //        _resChart.Name = "chartControl1";
                //        _resChart.Size = new System.Drawing.Size(184, 120);
                //        _resChart.TabIndex = 2;
                //        _resChart.Visible = true;
                //        _resChart.Dock = DockStyle.Fill;
                //        _resChart.BringToFront();

                //        _resChart.Background.FillEffect.SetGradient(GradientStyle.Horizontal, GradientVariant.Variant1, Color.LightSteelBlue, Color.White);
                //        _resChart.InteractivityOperations.Add(new GLTrackballDragOperation());
                //        _resChart.InteractivityOperations.Add(new GLTooltipInteractivityOperation());



                //        #endregion

                //        #region 显示表头
                //        ChartLabel header = _resChart.Labels.AddHeader("");
                //        header.TextProps.Backplane.Visible = false;
                //        header.TextProps.HasShadow = false;
                //        header.TextProps.HorizontalAlign = Xceed.Chart.GLCore.HorizontalAlign.Center;
                //        header.TextProps.VerticalAlign = Xceed.Chart.GLCore.VerticalAlign.Top;
                //        header.TextProps.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
                //        header.TextProps.Color = Color.Blue;
                //        header.HorizontalMargin = 20;
                //        header.VerticalMargin = 2;
                //        #endregion

                //        #region 建立CHART
                //        Xceed.Chart.Core.Chart chart = (Xceed.Chart.Core.Chart)_resChart.Charts[0];
                //        chart.Series.Clear();
                //        chart.Chart3DView.SetPredefinedProjection(PredefinedProjection.Perspective);
                //        chart.MarginFitStrategy = MarginFitStrategy.Fit;
                //        chart.Margins = new RectangleF(10, 10, 80, 80);
                //        chart.Chart3DView.Zoom = 80;
                //        chart.Chart3DView.YDepth = 50;

                //        #endregion

                //        #region 建立坐标系
                //        //chart.Axes.Clear();
                //        Axis _axis = chart.Axis(StandardAxis.PrimaryX);
                //        Axis _ayis = chart.Axis(StandardAxis.PrimaryY);
                //        _ayis.DimensionScale.AutoLabels = true;
                //        _axis.DimensionScale.AutoLabels = false;
                //        _axis.SetPredefinedTextLayout(PredefinedTextLayout.Horizontal);
                //        _axis.StaggerOffset = 0;

                //        if (_dt.Rows.Count > 3) _axis.SetPredefinedTextLayout(PredefinedTextLayout.Staggered2);
                //        if (_dt.Rows.Count > 8) _axis.SetPredefinedTextLayout(PredefinedTextLayout.TiltedAscending);
                //        foreach (DataRow _row1 in _dt.Rows)
                //        {
                //                _axis.Labels.Add(_row1[_Xfields].ToString());

                //        }
                //        #endregion

                //        #region 画图型
                //        int i = 1;
                //        int _transPercent = 30;
                //        if ((_Yfields.Count * _dt.Rows.Count) > 10) _transPercent = 0;
                //        foreach (string _n1 in _Yfields)
                //        {

                //                BarSeries bar1 = (BarSeries)chart.Series.Add(SeriesType.Bar);
                //                bar1.Interactivity.TooltipMode = SeriesTooltipMode.DataPoints;

                //                //是否显示Label
                //                if (_ShowLable)
                //                {
                //                        bar1.DataLabels.Mode = DataLabelsMode.Every;
                //                }
                //                else
                //                {
                //                        bar1.DataLabels.Mode = DataLabelsMode.None;
                //                }

                //                if (i == 1)
                //                {
                //                        bar1.MultiBarMode = MultiBarMode.Series;
                //                }
                //                else
                //                {
                //                        bar1.MultiBarMode = MultiBarMode.Clustered;
                //                }
                //                bar1.GapPercent = 30;
                //                bar1.Name = _dt.Columns[_n1].Caption;
                //                if (i <= ChartColorSet.Length) bar1.BarFillEffect.SetSolidColor(ChartColorSet[i - 1]);
                //                bar1.BarFillEffect.SetTransparencyPercent(_transPercent);
                //                bar1.Values.FillFromDataTable(_dt, _n1);
                //                foreach (DataRow _dr in _dt.Rows)
                //                {
                //                        bar1.Interactivity.Tooltips.Add(_dr[_n1].ToString());
                //                }

                //                i++;
                //        }
                //        #endregion
                //        return _resChart;
                //}

                //public static ChartControl CreatePieChart(DataTable _dt, string _Xfields, string _Yfields)
                //{
                //        return CreatePieChart(_dt, _Xfields, _Yfields, true, "");
                //}
                //public static ChartControl CreatePieChart(DataTable _dt, string _Xfields, string _Yfields, string _title)
                //{
                //        return CreatePieChart(_dt, _Xfields, _Yfields, true, _title);
                //}

                //public static ChartControl CreatePieChart(DataTable _indt, string _Xf, string _Yfields, bool _showLabel, string _title)
                //{
                //        string _format = "";
                //        ChartControl _resChart = new ChartControl();
                //        DataTable _dt = _indt.Copy();
                //        string _Xfields = _Xf;
                //        if (_dt.Columns[_Xf].DataType != typeof(string))
                //        {
                //                _Xfields += "_str";
                //                _dt.Columns.Add(_Xfields);
                //                if (_dt.Columns[_Xf].DataType == typeof(DateTime))
                //                {
                //                        _format = "yyyy年MM月dd日";
                //                        foreach (DataRow _dr in _dt.Rows)
                //                        {
                //                                DateTime _time = (DateTime)_dr[_Xf];
                //                                if (_time == DateTime.MinValue)
                //                                {
                //                                        _dr[_Xfields] ="其它";
                //                                }
                //                                else
                //                                {
                //                                        _dr[_Xfields] = _time.ToString(_format);
                //                                }
                //                        }
                //                }

                //        }

                //        _resChart.Background.FillEffect.SetGradient(GradientStyle.Horizontal, GradientVariant.Variant1, Color.LightSteelBlue, Color.White);
                //        _resChart.InteractivityOperations.Add(new GLTrackballDragOperation());
                //        _resChart.InteractivityOperations.Add(new GLTooltipInteractivityOperation());

                //        #region// add a header label
                //        ChartLabel header = _resChart.Labels.AddHeader(_title);
                //        header.TextProps.Backplane.Visible = false;
                //        header.TextProps.Color = Color.Black;
                //        header.TextProps.HasShadow = false;
                //        header.TextProps.HorizontalAlign = Xceed.Chart.GLCore.HorizontalAlign.Left;
                //        header.TextProps.VerticalAlign = Xceed.Chart.GLCore.VerticalAlign.Top;
                //        header.HorizontalMargin = 2;
                //        header.VerticalMargin = 2;
                //        header.TextProps.Font = new Font("宋体", 10);
                //        #endregion



                //        Xceed.Chart.Core.Chart m_Chart = _resChart.Charts[0];
                //        m_Chart.Chart3DView.SetPredefinedProjection(PredefinedProjection.OrthogonalElevated);

                //        PieSeries m_Pie = (PieSeries)m_Chart.Series.Add(SeriesType.Pie);

                //        #region 建组
                //        m_Pie.Labels.FillFromDataTable(_dt, _Xfields);
                //        m_Pie.Values.FillFromDataTable(_dt, _Yfields);
                //        #endregion


                //        #region 是否显示Label
                //        m_Pie.DataLabels.Format = "<percent>";
                //        if (_showLabel)
                //        {
                //                m_Pie.DataLabels.Mode = DataLabelsMode.Every;
                //        }
                //        else
                //        {
                //                m_Pie.DataLabels.Mode = DataLabelsMode.None;
                //        }

                //        m_Pie.Legend.Mode = SeriesLegendMode.DataPoints;
                //        m_Pie.Legend.Format = "<label>";
                //        #endregion

                //        m_Pie.Appearance.FillMode = AppearanceFillMode.DataPoints;

                //        // fill with random fill effects and data
                //        m_Pie.Appearance.FillEffects.FillRandom(m_Pie.Values.Count);
                //        m_Pie.Interactivity.TooltipMode = SeriesTooltipMode.DataPoints;
                //        foreach (DataRow _dr in _dt.Rows)
                //        {
                //                m_Pie.Interactivity.Tooltips.Add(string.Format("{0}:{1}", _dr[_Xfields].ToString(), _dr[_Yfields].ToString()));
                //        }

                //        _resChart.Dock = DockStyle.Fill;
                //        _resChart.BringToFront();

                //        return _resChart;
                //}

                //public static ChartControl CreateLineChart(DataTable _dt, string _Xfields, ArrayList _Yfields, string _title)
                //{
                //        return CreateLineChart(_dt, _Xfields, _Yfields, true, _title);
                //}

                //public static ChartControl CreateLineChart(DataTable _indt, string _Xf, ArrayList _Yfields, bool _showLabel, string _title)
                //{
                //        string _format = "";
                //        ChartControl _resChart = new ChartControl();
                //        DataTable _dt = _indt.Copy();
                //        string _Xfields = _Xf;
                //        if (_dt.Columns[_Xf].DataType != typeof(string))
                //        {
                //                _Xfields += "_str";
                //                _dt.Columns.Add(_Xfields);
                //                if (_dt.Columns[_Xf].DataType == typeof(DateTime))
                //                {
                //                        _format = "yyyy年MM月dd日";
                //                        foreach (DataRow _dr in _dt.Rows)
                //                        {
                //                                _dr[_Xfields] = ((DateTime)_dr[_Xf]).ToString(_format);
                //                        }
                //                }

                //        }

                //        _resChart.Background.FillEffect.SetGradient(GradientStyle.Horizontal, GradientVariant.Variant1, Color.LightSteelBlue, Color.White);
                //        _resChart.InteractivityOperations.Add(new GLTrackballDragOperation());
                //        _resChart.InteractivityOperations.Add(new GLTooltipInteractivityOperation());

                //        #region// add a header label
                //        ChartLabel header = _resChart.Labels.AddHeader(_title);
                //        header.TextProps.Backplane.Visible = false;
                //        header.TextProps.Color = Color.Black;
                //        header.TextProps.HasShadow = false;
                //        header.TextProps.HorizontalAlign = Xceed.Chart.GLCore.HorizontalAlign.Left;
                //        header.TextProps.VerticalAlign = Xceed.Chart.GLCore.VerticalAlign.Top;
                //        header.HorizontalMargin = 2;
                //        header.VerticalMargin = 2;
                //        header.TextProps.Font = new Font("宋体", 10);
                //        #endregion


                //        Xceed.Chart.Core.Chart m_Chart = _resChart.Charts[0];
                //        m_Chart.Axis(StandardAxis.Depth).Visible = false;
                //        m_Chart.Axis(StandardAxis.PrimaryY).NumericScale.AutoMin = false;
                //        m_Chart.Axis(StandardAxis.PrimaryY).NumericScale.Min = 0;

                //        Axis _axis = m_Chart.Axis(StandardAxis.PrimaryX);
                //        _axis.DimensionScale.AutoLabels = false;
                //        _axis.SetPredefinedTextLayout(PredefinedTextLayout.Horizontal);
                //        if (_dt.Rows.Count > 3) _axis.SetPredefinedTextLayout(PredefinedTextLayout.Staggered2);
                //        if (_dt.Rows.Count > 8) _axis.SetPredefinedTextLayout(PredefinedTextLayout.TiltedAscending);
                //        foreach (DataRow _row1 in _dt.Rows)
                //        {
                //                _axis.Labels.Add(_row1[_Xfields].ToString());

                //        }

                //        #region 画线条
                //        int i = 1;

                //        foreach (string _n1 in _Yfields)
                //        {

                //                LineSeries m_Line1 = (LineSeries)m_Chart.Series.Add(SeriesType.Line);
                //                m_Line1.Name = _n1;
                //                m_Line1.DataLabels.Format = "<value>";
                //                if (i <= ChartColorSet.Length) m_Line1.LineBorder.Color = ChartColorSet[i - 1];
                //                if (i <= ChartColorSet.Length) m_Line1.LineFillEffect.SetSolidColor(ChartColorSet[i - 1]);
                //                if (i > 1) m_Line1.MultiLineMode = MultiLineMode.Overlaped;
                //                m_Line1.Interactivity.TooltipMode = SeriesTooltipMode.DataPoints;
                //                m_Line1.Values.FillFromDataTable(_dt, _n1);
                //                m_Line1.LineBorder.Width = 2;

                //                //是否显示Label
                //                if (_showLabel)
                //                {
                //                        m_Line1.DataLabels.Mode = DataLabelsMode.Every;
                //                }
                //                else
                //                {
                //                        m_Line1.DataLabels.Mode = DataLabelsMode.None;
                //                }

                //                m_Line1.Name = _dt.Columns[_n1].Caption;

                //                foreach (DataRow _dr in _dt.Rows)
                //                {
                //                        m_Line1.Interactivity.Tooltips.Add(_dr[_n1].ToString());
                //                }

                //                i++;
                //        }
                //        #endregion
                //        _resChart.Dock = DockStyle.Fill;
                //        _resChart.BringToFront();

                //        return _resChart;
                //}



        }
}
