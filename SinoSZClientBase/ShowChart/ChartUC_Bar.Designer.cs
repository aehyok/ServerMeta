namespace SinoSZClientBase.ShowChart
{
        partial class ChartUC_Bar
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
                        DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
                        DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
                        DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
                        this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
                        ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // chartControl1
                        // 
                        xyDiagram1.AxisX.Label.Antialiasing = true;
                        xyDiagram1.AxisX.Interlaced = true;
                        xyDiagram1.AxisX.Range.SideMarginsEnabled = true;
                        xyDiagram1.AxisY.MinorCount = 1;
                        xyDiagram1.AxisY.Range.SideMarginsEnabled = true;
                        //14.1版本不支持缩放    
                    //xyDiagram1.EnableZooming = true;
                        this.chartControl1.Diagram = xyDiagram1;
                        this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.chartControl1.Location = new System.Drawing.Point(0, 0);
                        this.chartControl1.Name = "chartControl1";
                        series1.Name = "Series 1";
                        series1.PointOptionsTypeName = "PointOptions";
                        series2.Name = "Series 2";
                        series2.PointOptionsTypeName = "PointOptions";
                        this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
                        this.chartControl1.SeriesTemplate.PointOptionsTypeName = "PointOptions";
                        this.chartControl1.Size = new System.Drawing.Size(669, 443);
                        this.chartControl1.TabIndex = 0;
                        this.chartControl1.ObjectSelected += new DevExpress.XtraCharts.HotTrackEventHandler(this.chartControl1_ObjectSelected);
                        // 
                        // ChartUC_Bar
                        // 
                        this.Appearance.BackColor = System.Drawing.Color.Transparent;
                        this.Appearance.Options.UseBackColor = true;
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.chartControl1);
                        this.Name = "ChartUC_Bar";
                        this.Size = new System.Drawing.Size(669, 443);
                        ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraCharts.ChartControl chartControl1;
        }
}
