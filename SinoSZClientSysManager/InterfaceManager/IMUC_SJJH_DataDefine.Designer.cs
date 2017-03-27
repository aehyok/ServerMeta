namespace SinoSZClientSysManager.InterfaceManager
{
        partial class IMUC_SJJH_DataDefine
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
                        this.panelWait = new System.Windows.Forms.Panel();
                        this.label2 = new System.Windows.Forms.Label();
                        this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
                        this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
                        this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
                        this.sinoCommonGrid1 = new SinoSZClientBase.SinoCommonGrid();
                        this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
                        this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
                        this.sinoCommonGrid2 = new SinoSZClientBase.SinoCommonGrid();
                        this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
                        this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
                        this.panelWait.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
                        this.splitContainerControl1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
                        this.groupControl1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.sinoCommonGrid1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
                        this.groupControl2.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.sinoCommonGrid2)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // panelWait
                        // 
                        this.panelWait.Controls.Add(this.label2);
                        this.panelWait.Controls.Add(this.marqueeProgressBarControl1);
                        this.panelWait.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.panelWait.Location = new System.Drawing.Point(0, 596);
                        this.panelWait.Name = "panelWait";
                        this.panelWait.Size = new System.Drawing.Size(991, 22);
                        this.panelWait.TabIndex = 12;
                        this.panelWait.Visible = false;
                        // 
                        // label2
                        // 
                        this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.label2.Location = new System.Drawing.Point(117, 0);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(874, 22);
                        this.label2.TabIndex = 1;
                        this.label2.Text = "正在处理数据，请稍候 ...";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // marqueeProgressBarControl1
                        // 
                        this.marqueeProgressBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
                        this.marqueeProgressBarControl1.EditValue = 0;
                        this.marqueeProgressBarControl1.Location = new System.Drawing.Point(0, 0);
                        this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
                        this.marqueeProgressBarControl1.Size = new System.Drawing.Size(117, 22);
                        this.marqueeProgressBarControl1.TabIndex = 0;
                        // 
                        // splitContainerControl1
                        // 
                        this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.splitContainerControl1.Horizontal = false;
                        this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
                        this.splitContainerControl1.Name = "splitContainerControl1";
                        this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
                        this.splitContainerControl1.Panel1.Text = "Panel1";
                        this.splitContainerControl1.Panel2.Controls.Add(this.groupControl2);
                        this.splitContainerControl1.Panel2.Text = "Panel2";
                        this.splitContainerControl1.Size = new System.Drawing.Size(991, 596);
                        this.splitContainerControl1.SplitterPosition = 261;
                        this.splitContainerControl1.TabIndex = 13;
                        this.splitContainerControl1.Text = "splitContainerControl1";
                        // 
                        // groupControl1
                        // 
                        this.groupControl1.Controls.Add(this.sinoCommonGrid1);
                        this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.groupControl1.Location = new System.Drawing.Point(0, 0);
                        this.groupControl1.Name = "groupControl1";
                        this.groupControl1.Size = new System.Drawing.Size(987, 257);
                        this.groupControl1.TabIndex = 0;
                        this.groupControl1.Text = "表定义";
                        // 
                        // sinoCommonGrid1
                        // 
                        this.sinoCommonGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.sinoCommonGrid1.EmbeddedNavigator.Name = "";
                        this.sinoCommonGrid1.Location = new System.Drawing.Point(2, 22);
                        this.sinoCommonGrid1.MainView = this.gridView1;
                        this.sinoCommonGrid1.Name = "sinoCommonGrid1";
                        this.sinoCommonGrid1.Size = new System.Drawing.Size(983, 233);
                        this.sinoCommonGrid1.TabIndex = 0;
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
            this.gridColumn3,
            this.gridColumn4});
                        this.gridView1.GridControl = this.sinoCommonGrid1;
                        this.gridView1.Name = "gridView1";
                        this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
                        this.gridView1.OptionsView.ShowDetailButtons = false;
                        this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
                        // 
                        // gridColumn1
                        // 
                        this.gridColumn1.Caption = "表名称";
                        this.gridColumn1.FieldName = "TableName";
                        this.gridColumn1.Name = "gridColumn1";
                        this.gridColumn1.OptionsColumn.FixedWidth = true;
                        this.gridColumn1.OptionsColumn.ReadOnly = true;
                        this.gridColumn1.Visible = true;
                        this.gridColumn1.VisibleIndex = 0;
                        this.gridColumn1.Width = 175;
                        // 
                        // gridColumn2
                        // 
                        this.gridColumn2.Caption = "说明";
                        this.gridColumn2.FieldName = "DisplayName";
                        this.gridColumn2.Name = "gridColumn2";
                        this.gridColumn2.OptionsColumn.FixedWidth = true;
                        this.gridColumn2.OptionsColumn.ReadOnly = true;
                        this.gridColumn2.Visible = true;
                        this.gridColumn2.VisibleIndex = 1;
                        this.gridColumn2.Width = 151;
                        // 
                        // gridColumn3
                        // 
                        this.gridColumn3.Caption = "下载条件定义";
                        this.gridColumn3.FieldName = "Condtion";
                        this.gridColumn3.Name = "gridColumn3";
                        this.gridColumn3.OptionsColumn.FixedWidth = true;
                        this.gridColumn3.OptionsColumn.ReadOnly = true;
                        this.gridColumn3.Visible = true;
                        this.gridColumn3.VisibleIndex = 2;
                        this.gridColumn3.Width = 170;
                        // 
                        // gridColumn4
                        // 
                        this.gridColumn4.Caption = "下载授权范围";
                        this.gridColumn4.FieldName = "SecretFun";
                        this.gridColumn4.Name = "gridColumn4";
                        this.gridColumn4.OptionsColumn.ReadOnly = true;
                        this.gridColumn4.Visible = true;
                        this.gridColumn4.VisibleIndex = 3;
                        this.gridColumn4.Width = 466;
                        // 
                        // groupControl2
                        // 
                        this.groupControl2.Controls.Add(this.sinoCommonGrid2);
                        this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.groupControl2.Location = new System.Drawing.Point(0, 0);
                        this.groupControl2.Name = "groupControl2";
                        this.groupControl2.Size = new System.Drawing.Size(987, 325);
                        this.groupControl2.TabIndex = 0;
                        this.groupControl2.Text = "字段定义";
                        // 
                        // sinoCommonGrid2
                        // 
                        this.sinoCommonGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.sinoCommonGrid2.EmbeddedNavigator.Name = "";
                        this.sinoCommonGrid2.Location = new System.Drawing.Point(2, 22);
                        this.sinoCommonGrid2.MainView = this.gridView2;
                        this.sinoCommonGrid2.Name = "sinoCommonGrid2";
                        this.sinoCommonGrid2.Size = new System.Drawing.Size(983, 301);
                        this.sinoCommonGrid2.TabIndex = 0;
                        this.sinoCommonGrid2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
                        // 
                        // gridView2
                        // 
                        this.gridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(255)))), ((int)(((byte)(229)))));
                        this.gridView2.Appearance.EvenRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(255)))), ((int)(((byte)(229)))));
                        this.gridView2.Appearance.EvenRow.Options.UseBackColor = true;
                        this.gridView2.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
                        this.gridView2.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
                        this.gridView2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
                        this.gridView2.Appearance.FocusedCell.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
                        this.gridView2.Appearance.FocusedCell.Options.UseBackColor = true;
                        this.gridView2.Appearance.FocusedCell.Options.UseForeColor = true;
                        this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
                        this.gridView2.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
                        this.gridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
                        this.gridView2.Appearance.FocusedRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
                        this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
                        this.gridView2.Appearance.FocusedRow.Options.UseForeColor = true;
                        this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
                        this.gridView2.GridControl = this.sinoCommonGrid2;
                        this.gridView2.Name = "gridView2";
                        this.gridView2.OptionsView.EnableAppearanceEvenRow = true;
                        // 
                        // gridColumn5
                        // 
                        this.gridColumn5.Caption = "字段名称";
                        this.gridColumn5.FieldName = "ColumnName";
                        this.gridColumn5.Name = "gridColumn5";
                        this.gridColumn5.OptionsColumn.ReadOnly = true;
                        this.gridColumn5.Visible = true;
                        this.gridColumn5.VisibleIndex = 0;
                        this.gridColumn5.Width = 120;
                        // 
                        // gridColumn6
                        // 
                        this.gridColumn6.Caption = "显示名称";
                        this.gridColumn6.Name = "gridColumn6";
                        this.gridColumn6.OptionsColumn.ReadOnly = true;
                        this.gridColumn6.Visible = true;
                        this.gridColumn6.VisibleIndex = 1;
                        this.gridColumn6.Width = 120;
                        // 
                        // gridColumn7
                        // 
                        this.gridColumn7.Caption = "数据类型";
                        this.gridColumn7.FieldName = "ColumnType";
                        this.gridColumn7.Name = "gridColumn7";
                        this.gridColumn7.OptionsColumn.FixedWidth = true;
                        this.gridColumn7.OptionsColumn.ReadOnly = true;
                        this.gridColumn7.Visible = true;
                        this.gridColumn7.VisibleIndex = 2;
                        this.gridColumn7.Width = 120;
                        // 
                        // gridColumn8
                        // 
                        this.gridColumn8.Caption = "数据长度";
                        this.gridColumn8.FieldName = "ColumnLength";
                        this.gridColumn8.Name = "gridColumn8";
                        this.gridColumn8.OptionsColumn.FixedWidth = true;
                        this.gridColumn8.OptionsColumn.ReadOnly = true;
                        this.gridColumn8.Visible = true;
                        this.gridColumn8.VisibleIndex = 3;
                        this.gridColumn8.Width = 120;
                        // 
                        // gridColumn9
                        // 
                        this.gridColumn9.Caption = "采用代码表";
                        this.gridColumn9.FieldName = "RefTableName";
                        this.gridColumn9.Name = "gridColumn9";
                        this.gridColumn9.OptionsColumn.ReadOnly = true;
                        this.gridColumn9.Visible = true;
                        this.gridColumn9.VisibleIndex = 4;
                        this.gridColumn9.Width = 482;
                        // 
                        // backgroundWorker1
                        // 
                        this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
                        this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
                        // 
                        // IMUC_SJJH_DataDefine
                        // 
                        this.Appearance.BackColor = System.Drawing.Color.Transparent;
                        this.Appearance.Options.UseBackColor = true;
                        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.splitContainerControl1);
                        this.Controls.Add(this.panelWait);
                        this.Name = "IMUC_SJJH_DataDefine";
                        this.Size = new System.Drawing.Size(991, 618);
                        this.panelWait.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
                        this.splitContainerControl1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
                        this.groupControl1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.sinoCommonGrid1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
                        this.groupControl2.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.sinoCommonGrid2)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.Panel panelWait;
                private System.Windows.Forms.Label label2;
                private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
                private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
                private DevExpress.XtraEditors.GroupControl groupControl1;
                private DevExpress.XtraEditors.GroupControl groupControl2;
                private SinoSZClientBase.SinoCommonGrid sinoCommonGrid1;
                private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
                private SinoSZClientBase.SinoCommonGrid sinoCommonGrid2;
                private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
                private System.ComponentModel.BackgroundWorker backgroundWorker1;
        }
}
