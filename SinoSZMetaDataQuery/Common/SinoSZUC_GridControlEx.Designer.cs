namespace SinoSZMetaDataQuery.Common
{
        partial class SinoSZUC_GridControlEx
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
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridControl2 = new DevExpress.XtraGrid.GridControl();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			this.SuspendLayout();
			// 
			// gridControl1
			// 
			this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridControl1.EmbeddedNavigator.Name = "";
			this.gridControl1.Location = new System.Drawing.Point(0, 0);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.Size = new System.Drawing.Size(852, 532);
			this.gridControl1.TabIndex = 1;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			this.gridControl1.ViewRegistered += new DevExpress.XtraGrid.ViewOperationEventHandler(this.gridControl1_ViewRegistered);
			// 
			// gridView1
			// 
			this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(255)))), ((int)(((byte)(229)))));
			this.gridView1.Appearance.EvenRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(255)))), ((int)(((byte)(229)))));
			this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
			this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.Gold;
			this.gridView1.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Gold;
			this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
			this.gridView1.Appearance.FocusedCell.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
			this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
			this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Gold;
			this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Gold;
			this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
			this.gridView1.Appearance.FocusedRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
			this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
			this.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsBehavior.KeepFocusedRowOnUpdate = false;
			this.gridView1.OptionsView.ColumnAutoWidth = false;
			this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
			this.gridView1.OptionsView.ShowFooter = true;
			this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this._gv_CustomDrawRowIndicator);
			this.gridView1.DragObjectDrop += new DevExpress.XtraGrid.Views.Base.DragObjectDropEventHandler(this.gridView1_DragObjectDrop);
			// 
			// gridControl2
			// 
			this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridControl2.EmbeddedNavigator.Name = "";
			this.gridControl2.Location = new System.Drawing.Point(0, 0);
			this.gridControl2.MainView = this.gridView2;
			this.gridControl2.Name = "gridControl2";
			this.gridControl2.Size = new System.Drawing.Size(852, 532);
			this.gridControl2.TabIndex = 2;
			this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
			this.gridControl2.ViewRegistered += new DevExpress.XtraGrid.ViewOperationEventHandler(this.gridControl2_ViewRegistered);
			// 
			// gridView2
			// 
			this.gridView2.Appearance.FocusedCell.BackColor = System.Drawing.Color.Gold;
			this.gridView2.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Gold;
			this.gridView2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
			this.gridView2.Appearance.FocusedCell.Options.UseBackColor = true;
			this.gridView2.Appearance.FocusedCell.Options.UseForeColor = true;
			this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.Color.Gold;
			this.gridView2.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Gold;
			this.gridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
			this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
			this.gridView2.Appearance.FocusedRow.Options.UseForeColor = true;
			this.gridView2.GridControl = this.gridControl2;
			this.gridView2.Name = "gridView2";
			this.gridView2.OptionsBehavior.KeepFocusedRowOnUpdate = false;
			this.gridView2.OptionsView.ColumnAutoWidth = false;
			this.gridView2.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this._gv_CustomDrawRowIndicator);
			// 
			// labelControl1
			// 
			this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Brown;
			this.labelControl1.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelControl1.Appearance.Options.UseForeColor = true;
			this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.labelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.labelControl1.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftBottom;
			this.labelControl1.Location = new System.Drawing.Point(0, 532);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.labelControl1.Size = new System.Drawing.Size(852, 22);
			this.labelControl1.TabIndex = 3;
			this.labelControl1.Text = "共检索到 0 条记录!";
			// 
			// SinoSZUC_GridControlEx
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.gridControl1);
			this.Controls.Add(this.gridControl2);
			this.Controls.Add(this.labelControl1);
			this.Name = "SinoSZUC_GridControlEx";
			this.Size = new System.Drawing.Size(852, 554);
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraGrid.GridControl gridControl1;
                private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
                private DevExpress.XtraGrid.GridControl gridControl2;
                private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
                private DevExpress.XtraEditors.LabelControl labelControl1;
        }
}
