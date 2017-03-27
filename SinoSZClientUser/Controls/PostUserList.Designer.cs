namespace SinoSZClientUser.Controls
{
        partial class PostUserList
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
                        this.sinoCommonGrid1 = new SinoSZClientBase.SinoCommonGrid();
                        this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
                        this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
                        ((System.ComponentModel.ISupportInitialize)(this.sinoCommonGrid1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // sinoCommonGrid1
                        // 
                        this.sinoCommonGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.sinoCommonGrid1.EmbeddedNavigator.Name = "";
                        this.sinoCommonGrid1.Location = new System.Drawing.Point(0, 0);
                        this.sinoCommonGrid1.MainView = this.gridView1;
                        this.sinoCommonGrid1.Name = "sinoCommonGrid1";
                        this.sinoCommonGrid1.Size = new System.Drawing.Size(817, 313);
                        this.sinoCommonGrid1.TabIndex = 1;
                        this.sinoCommonGrid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
                        // 
                        // gridView1
                        // 
                        this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(255)))), ((int)(((byte)(229)))));
                        this.gridView1.Appearance.EvenRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(255)))), ((int)(((byte)(229)))));
                        this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
                        this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
                        this.gridView1.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
                        this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
                        this.gridView1.Appearance.FocusedCell.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
                        this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
                        this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
                        this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
                        this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
                        this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
                        this.gridView1.Appearance.FocusedRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
                        this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
                        this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
                        this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
                        this.gridView1.GridControl = this.sinoCommonGrid1;
                        this.gridView1.Name = "gridView1";
                        this.gridView1.OptionsView.ColumnAutoWidth = false;
                        this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
                        // 
                        // gridColumn1
                        // 
                        this.gridColumn1.Caption = "登录名";
                        this.gridColumn1.FieldName = "LoginName";
                        this.gridColumn1.Name = "gridColumn1";
                        this.gridColumn1.OptionsColumn.FixedWidth = true;
                        this.gridColumn1.OptionsColumn.ReadOnly = true;
                        this.gridColumn1.Visible = true;
                        this.gridColumn1.VisibleIndex = 0;
                        this.gridColumn1.Width = 134;
                        // 
                        // gridColumn2
                        // 
                        this.gridColumn2.Caption = "姓名";
                        this.gridColumn2.FieldName = "UserName";
                        this.gridColumn2.Name = "gridColumn2";
                        this.gridColumn2.OptionsColumn.FixedWidth = true;
                        this.gridColumn2.OptionsColumn.ReadOnly = true;
                        this.gridColumn2.Visible = true;
                        this.gridColumn2.VisibleIndex = 1;
                        this.gridColumn2.Width = 146;
                        // 
                        // gridColumn3
                        // 
                        this.gridColumn3.Caption = "所属单位";
                        this.gridColumn3.FieldName = "OrgShortName";
                        this.gridColumn3.Name = "gridColumn3";
                        this.gridColumn3.OptionsColumn.FixedWidth = true;
                        this.gridColumn3.OptionsColumn.ReadOnly = true;
                        this.gridColumn3.Visible = true;
                        this.gridColumn3.VisibleIndex = 2;
                        this.gridColumn3.Width = 441;
                        // 
                        // PostUserList
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.sinoCommonGrid1);
                        this.Name = "PostUserList";
                        this.Size = new System.Drawing.Size(817, 313);
                        ((System.ComponentModel.ISupportInitialize)(this.sinoCommonGrid1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private SinoSZClientBase.SinoCommonGrid sinoCommonGrid1;
                private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        }
}
