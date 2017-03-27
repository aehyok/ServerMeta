namespace SinoSZClientBase.ShowChart
{
        partial class ChartUC_Pie
        {
                /// <summary> 
                /// Required designer variable.
                /// </summary>
                private System.ComponentModel.IContainer components = null;

                /// <summary> 
                /// Clean up any resources being used.
                /// </summary>
                /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
                protected override void Dispose(bool disposing)
                {
                        if (disposing && (components != null))
                        {
                                components.Dispose();
                        }
                        base.Dispose(disposing);
                }

                #region Component Designer generated code

                /// <summary> 
                /// Required method for Designer support - do not modify 
                /// the contents of this method with the code editor.
                /// </summary>
                private void InitializeComponent()
                {
                        DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
                        DevExpress.XtraCharts.SeriesPoint seriesPoint1 = new DevExpress.XtraCharts.SeriesPoint("a", new object[] {
            ((object)(30))}, 0);
                        DevExpress.XtraCharts.SeriesPoint seriesPoint2 = new DevExpress.XtraCharts.SeriesPoint("b", new object[] {
            ((object)(50))}, 1);
                        DevExpress.XtraCharts.SeriesPoint seriesPoint3 = new DevExpress.XtraCharts.SeriesPoint("c", new object[] {
            ((object)(66))}, 2);
                        DevExpress.XtraCharts.PieSeriesView pieSeriesView1 = new DevExpress.XtraCharts.PieSeriesView();
                        DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel1 = new DevExpress.XtraCharts.PieSeriesLabel();
                        DevExpress.XtraCharts.PiePointOptions piePointOptions1 = new DevExpress.XtraCharts.PiePointOptions();
                        DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
                        DevExpress.XtraCharts.PieSeriesView pieSeriesView2 = new DevExpress.XtraCharts.PieSeriesView();
                        DevExpress.XtraCharts.PiePointOptions piePointOptions2 = new DevExpress.XtraCharts.PiePointOptions();
                        DevExpress.XtraCharts.PieSeriesView pieSeriesView3 = new DevExpress.XtraCharts.PieSeriesView();
                        this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
                        ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(pieSeriesView2)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(pieSeriesView3)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // chartControl1
                        // 
                        this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.chartControl1.Location = new System.Drawing.Point(0, 0);
                        this.chartControl1.Name = "chartControl1";
                        series1.Name = "Series 1";
                        series1.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
            seriesPoint1,
            seriesPoint2,
            seriesPoint3});
                        pieSeriesView1.Rotation = 10;
                        pieSeriesView1.RuntimeExploding = true;
                        series1.View = pieSeriesView1;
                        pieSeriesLabel1.Position = DevExpress.XtraCharts.PieSeriesLabelPosition.TwoColumns;
                        pieSeriesLabel1.ColumnIndent = 1;
                        pieSeriesLabel1.HiddenSerializableString = "to be serialized";
                        series1.Label = pieSeriesLabel1;
                        //piePointOptions1.PercentOptions.ValuePercentPrecision = 4;
                        piePointOptions1.PercentOptions.PercentageAccuracy = 4;
                        piePointOptions1.HiddenSerializableString = "to be serialized";
                        piePointOptions1.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues;
                        piePointOptions1.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                        series1.PointOptions = piePointOptions1;
                        series1.PointOptionsTypeName = "PiePointOptions";
                        series2.Name = "Series 2";
                        series2.View = pieSeriesView2;
                        piePointOptions2.HiddenSerializableString = "to be serialized";
                        piePointOptions2.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues;
                        series2.PointOptions = piePointOptions2;
                        series2.PointOptionsTypeName = "PiePointOptions";
                        this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
                        this.chartControl1.SeriesTemplate.View = pieSeriesView3;
                        this.chartControl1.SeriesTemplate.PointOptionsTypeName = "PiePointOptions";
                        this.chartControl1.Size = new System.Drawing.Size(692, 408);
                        this.chartControl1.TabIndex = 1;
                        this.chartControl1.ObjectSelected += new DevExpress.XtraCharts.HotTrackEventHandler(this.chartControl1_ObjectSelected);
                        // 
                        // ChartUC_Pie
                        // 
                        this.Appearance.BackColor = System.Drawing.Color.Transparent;
                        this.Appearance.Options.UseBackColor = true;
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.chartControl1);
                        this.Name = "ChartUC_Pie";
                        this.Size = new System.Drawing.Size(692, 408);
                        ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(pieSeriesView2)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(pieSeriesView3)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraCharts.ChartControl chartControl1;
        }
}
