namespace SinoSZMetaDataQuery.Common
{
        partial class SinoSZUC_GridControlEx_FullRelation
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
                        this.components = new System.ComponentModel.Container();
                        this.gridControl1 = new DevExpress.XtraGrid.GridControl();
                        this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
                        this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
                        this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                        this.imageList1 = new System.Windows.Forms.ImageList(this.components);
                        ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // gridControl1
                        // 
                        this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.gridControl1.EmbeddedNavigator.Name = "";
                        this.gridControl1.Location = new System.Drawing.Point(0, 0);
                        this.gridControl1.MainView = this.bandedGridView1;
                        this.gridControl1.Name = "gridControl1";
                        this.gridControl1.Size = new System.Drawing.Size(743, 539);
                        this.gridControl1.TabIndex = 0;
                        this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1});
                        // 
                        // bandedGridView1
                        // 
                        this.bandedGridView1.Appearance.BandPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(224)))), ((int)(((byte)(203)))));
                        this.bandedGridView1.Appearance.BandPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(131)))), ((int)(((byte)(113)))));
                        this.bandedGridView1.Appearance.BandPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
                        this.bandedGridView1.Appearance.BandPanel.Options.UseBackColor = true;
                        this.bandedGridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(232)))), ((int)(((byte)(136)))));
                        this.bandedGridView1.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(232)))), ((int)(((byte)(136)))));
                        this.bandedGridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
                        this.bandedGridView1.Appearance.FocusedCell.Options.UseBackColor = true;
                        this.bandedGridView1.Appearance.FocusedCell.Options.UseForeColor = true;
                        this.bandedGridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(232)))), ((int)(((byte)(136)))));
                        this.bandedGridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(232)))), ((int)(((byte)(136)))));
                        this.bandedGridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
                        this.bandedGridView1.Appearance.FocusedRow.Options.UseBackColor = true;
                        this.bandedGridView1.Appearance.FocusedRow.Options.UseForeColor = true;
                        this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
                        this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn1});
                        this.bandedGridView1.GridControl = this.gridControl1;
                        this.bandedGridView1.Images = this.imageList1;
                        this.bandedGridView1.Name = "bandedGridView1";
                        this.bandedGridView1.OptionsSelection.MultiSelect = true;
                        this.bandedGridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
                        this.bandedGridView1.OptionsView.AllowCellMerge = true;
                        this.bandedGridView1.OptionsView.ColumnAutoWidth = false;
                        this.bandedGridView1.OptionsView.ShowFooter = true;
                        this.bandedGridView1.OptionsView.ShowGroupPanel = false;
                        this.bandedGridView1.GridMenuItemClick += new DevExpress.XtraGrid.Views.Grid.GridMenuItemClickEventHandler(this.bandedGridView1_GridMenuItemClick);
                        this.bandedGridView1.CellMerge += new DevExpress.XtraGrid.Views.Grid.CellMergeEventHandler(this.bandedGridView1_CellMerge);
                        this.bandedGridView1.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.bandedGridView1_CustomSummaryCalculate);
                        this.bandedGridView1.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(this.bandedGridView1_ShowGridMenu);
                        this.bandedGridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.bandedGridView1_RowStyle);
                        // 
                        // gridBand1
                        // 
                        this.gridBand1.AppearanceHeader.BackColor = System.Drawing.Color.Red;
                        this.gridBand1.AppearanceHeader.BackColor2 = System.Drawing.Color.Red;
                        this.gridBand1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
                        this.gridBand1.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
                        this.gridBand1.AppearanceHeader.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
                        this.gridBand1.AppearanceHeader.Options.UseBackColor = true;
                        this.gridBand1.AppearanceHeader.Options.UseFont = true;
                        this.gridBand1.AppearanceHeader.Options.UseForeColor = true;
                        this.gridBand1.Caption = "gridBand1";
                        this.gridBand1.Columns.Add(this.bandedGridColumn1);
                        this.gridBand1.Name = "gridBand1";
                        this.gridBand1.Width = 75;
                        // 
                        // bandedGridColumn1
                        // 
                        this.bandedGridColumn1.Caption = "bandedGridColumn1";
                        this.bandedGridColumn1.Name = "bandedGridColumn1";
                        this.bandedGridColumn1.Visible = true;
                        // 
                        // imageList1
                        // 
                        this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
                        this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
                        this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
                        // 
                        // SinoSZUC_GridControlEx_FullRelation
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.gridControl1);
                        this.Name = "SinoSZUC_GridControlEx_FullRelation";
                        this.Size = new System.Drawing.Size(743, 539);
                        ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraGrid.GridControl gridControl1;
                private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
                private System.Windows.Forms.ImageList imageList1;
                private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn1;
                private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        }
}
