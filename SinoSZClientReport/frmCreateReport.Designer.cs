namespace SinoSZClientReport
{
        partial class frmCreateReport
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

                #region Windows Form Designer generated code

                /// <summary>
                /// Required method for Designer support - do not modify
                /// the contents of this method with the code editor.
                /// </summary>
                private void InitializeComponent()
                {
            this.PanelBox = new DevExpress.XtraEditors.PanelControl();
            this.panelInput = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sinoCommonGrid1 = new SinoSZClientBase.SinoCommonGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelWait = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.BW_Query = new System.ComponentModel.BackgroundWorker();
            this.BW_Create = new System.ComponentModel.BackgroundWorker();
            this.BW_Rebuild = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.PanelBox)).BeginInit();
            this.PanelBox.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sinoCommonGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.panelWait.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelBox
            // 
            this.PanelBox.Controls.Add(this.panelInput);
            this.PanelBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelBox.Location = new System.Drawing.Point(13, 15);
            this.PanelBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PanelBox.Name = "PanelBox";
            this.PanelBox.Padding = new System.Windows.Forms.Padding(7, 20, 7, 21);
            this.PanelBox.Size = new System.Drawing.Size(1158, 75);
            this.PanelBox.TabIndex = 0;
            this.PanelBox.Resize += new System.EventHandler(this.PanelBox_Resize);
            // 
            // panelInput
            // 
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelInput.Location = new System.Drawing.Point(9, 22);
            this.panelInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(673, 30);
            this.panelInput.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sinoCommonGrid1);
            this.panel1.Controls.Add(this.panelWait);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(13, 90);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 22, 0, 8);
            this.panel1.Size = new System.Drawing.Size(1158, 663);
            this.panel1.TabIndex = 1;
            // 
            // sinoCommonGrid1
            // 
            this.sinoCommonGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sinoCommonGrid1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sinoCommonGrid1.Location = new System.Drawing.Point(0, 22);
            this.sinoCommonGrid1.MainView = this.gridView1;
            this.sinoCommonGrid1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sinoCommonGrid1.Name = "sinoCommonGrid1";
            this.sinoCommonGrid1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.sinoCommonGrid1.Size = new System.Drawing.Size(1158, 603);
            this.sinoCommonGrid1.TabIndex = 0;
            this.sinoCommonGrid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(255)))), ((int)(((byte)(229)))));
            this.gridView1.Appearance.EvenRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(255)))), ((int)(((byte)(229)))));
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(205)))));
            this.gridView1.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(191)))), ((int)(((byte)(18)))));
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedCell.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(205)))));
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(191)))), ((int)(((byte)(18)))));
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gridView1.GridControl = this.sinoCommonGrid1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "报表名称";
            this.gridColumn1.FieldName = "ReportTitle";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 197;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "统计开始时间";
            this.gridColumn2.DisplayFormat.FormatString = "yyyy年MM月dd日";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "StartDate";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.FixedWidth = true;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 120;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "统计结束时间";
            this.gridColumn3.DisplayFormat.FormatString = "yyyy年MM月dd日";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn3.FieldName = "EndDate";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.FixedWidth = true;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 120;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "统计单位";
            this.gridColumn4.FieldName = "ReportDWName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.FixedWidth = true;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 260;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "已审核";
            this.gridColumn5.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn5.FieldName = "Audited";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.FixedWidth = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "统计时间段";
            this.gridColumn6.DisplayFormat.FormatString = "yyyy年MM月";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn6.FieldName = "StartDate";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.FixedWidth = true;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 120;
            // 
            // panelWait
            // 
            this.panelWait.Controls.Add(this.label1);
            this.panelWait.Controls.Add(this.marqueeProgressBarControl1);
            this.panelWait.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelWait.Location = new System.Drawing.Point(0, 625);
            this.panelWait.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelWait.Name = "panelWait";
            this.panelWait.Size = new System.Drawing.Size(1158, 30);
            this.panelWait.TabIndex = 7;
            this.panelWait.Visible = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(133, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1025, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "正在处理数据，请稍候 ...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // marqueeProgressBarControl1
            // 
            this.marqueeProgressBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.marqueeProgressBarControl1.EditValue = 0;
            this.marqueeProgressBarControl1.Location = new System.Drawing.Point(0, 0);
            this.marqueeProgressBarControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
            this.marqueeProgressBarControl1.Size = new System.Drawing.Size(133, 30);
            this.marqueeProgressBarControl1.TabIndex = 0;
            // 
            // BW_Query
            // 
            this.BW_Query.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_Query_DoWork);
            this.BW_Query.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BW_Query_RunWorkerCompleted);
            // 
            // BW_Create
            // 
            this.BW_Create.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_Create_DoWork);
            this.BW_Create.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BW_Create_RunWorkerCompleted);
            // 
            // BW_Rebuild
            // 
            this.BW_Rebuild.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_Rebuild_DoWork);
            this.BW_Rebuild.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BW_Rebuild_RunWorkerCompleted);
            // 
            // frmCreateReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 768);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PanelBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmCreateReport";
            this.Padding = new System.Windows.Forms.Padding(13, 15, 13, 15);
            this.Text = "frmCreateReport";
            this.Load += new System.EventHandler(this.frmCreateReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PanelBox)).EndInit();
            this.PanelBox.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sinoCommonGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.panelWait.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
            this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.PanelControl PanelBox;
                private System.Windows.Forms.Panel panel1;
                private SinoSZClientBase.SinoCommonGrid sinoCommonGrid1;
                private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
                private System.Windows.Forms.Panel panelInput;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
                private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
                private System.Windows.Forms.Panel panelWait;
                private System.Windows.Forms.Label label1;
                private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
                private System.ComponentModel.BackgroundWorker BW_Query;
                private System.ComponentModel.BackgroundWorker BW_Create;
                private System.ComponentModel.BackgroundWorker BW_Rebuild;
        }
}