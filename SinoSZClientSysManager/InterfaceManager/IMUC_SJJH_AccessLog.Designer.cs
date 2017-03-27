namespace SinoSZClientSysManager.InterfaceManager
{
        partial class IMUC_SJJH_AccessLog
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
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.panelWait = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lb_xz_bs = new System.Windows.Forms.Label();
			this.lb_xz_time = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.lb_dmbgx_time = new System.Windows.Forms.Label();
			this.lb_scsj_time = new System.Windows.Forms.Label();
			this.lb_dmbgx_bs = new System.Windows.Forms.Label();
			this.lb_scsj_bs = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.bt_Refresh = new DevExpress.XtraEditors.SimpleButton();
			this.label3 = new System.Windows.Forms.Label();
			this.te_end = new DevExpress.XtraEditors.DateEdit();
			this.te_start = new DevExpress.XtraEditors.DateEdit();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.sinoCommonGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			this.panelWait.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.te_end.Properties.VistaTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_end.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_start.Properties.VistaTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_start.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// sinoCommonGrid1
			// 
			this.sinoCommonGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sinoCommonGrid1.EmbeddedNavigator.Name = "";
			this.sinoCommonGrid1.Location = new System.Drawing.Point(0, 132);
			this.sinoCommonGrid1.MainView = this.gridView1;
			this.sinoCommonGrid1.Name = "sinoCommonGrid1";
			this.sinoCommonGrid1.Size = new System.Drawing.Size(865, 405);
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
            this.gridColumn4,
            this.gridColumn2,
            this.gridColumn3});
			this.gridView1.GridControl = this.sinoCommonGrid1;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "下载数据表";
			this.gridColumn1.FieldName = "TableName";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.OptionsColumn.ReadOnly = true;
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			this.gridColumn1.Width = 423;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "下载操作类型";
			this.gridColumn4.FieldName = "ActionType";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.OptionsColumn.ReadOnly = true;
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 1;
			this.gridColumn4.Width = 141;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "下载时间";
			this.gridColumn2.DisplayFormat.FormatString = "yyyy年MM月dd日 HH:mm:ss";
			this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.gridColumn2.FieldName = "DownloadTime";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.OptionsColumn.FixedWidth = true;
			this.gridColumn2.OptionsColumn.ReadOnly = true;
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 2;
			this.gridColumn2.Width = 160;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "进度标识号";
			this.gridColumn3.FieldName = "ODS_ID";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.OptionsColumn.FixedWidth = true;
			this.gridColumn3.OptionsColumn.ReadOnly = true;
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 3;
			this.gridColumn3.Width = 120;
			// 
			// panelWait
			// 
			this.panelWait.Controls.Add(this.label2);
			this.panelWait.Controls.Add(this.marqueeProgressBarControl1);
			this.panelWait.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelWait.Location = new System.Drawing.Point(0, 537);
			this.panelWait.Name = "panelWait";
			this.panelWait.Size = new System.Drawing.Size(865, 20);
			this.panelWait.TabIndex = 13;
			this.panelWait.Visible = false;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Location = new System.Drawing.Point(100, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(765, 20);
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
			this.marqueeProgressBarControl1.Size = new System.Drawing.Size(100, 20);
			this.marqueeProgressBarControl1.TabIndex = 0;
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.groupControl1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.panel1.Size = new System.Drawing.Size(865, 100);
			this.panel1.TabIndex = 15;
			// 
			// groupControl1
			// 
			this.groupControl1.Controls.Add(this.tableLayoutPanel1);
			this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl1.Location = new System.Drawing.Point(0, 0);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(865, 95);
			this.groupControl1.TabIndex = 0;
			this.groupControl1.Text = "用户最后下载进度";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 5;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 260F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.lb_xz_bs, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.lb_xz_time, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.label7, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.label8, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.label9, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.lb_dmbgx_time, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.lb_scsj_time, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.lb_dmbgx_bs, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.lb_scsj_bs, 3, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 21);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(861, 72);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// lb_xz_bs
			// 
			this.lb_xz_bs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.lb_xz_bs.AutoSize = true;
			this.lb_xz_bs.ForeColor = System.Drawing.Color.Blue;
			this.lb_xz_bs.Location = new System.Drawing.Point(623, 0);
			this.lb_xz_bs.Name = "lb_xz_bs";
			this.lb_xz_bs.Size = new System.Drawing.Size(154, 24);
			this.lb_xz_bs.TabIndex = 9;
			this.lb_xz_bs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lb_xz_time
			// 
			this.lb_xz_time.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.lb_xz_time.AutoSize = true;
			this.lb_xz_time.ForeColor = System.Drawing.Color.Blue;
			this.lb_xz_time.Location = new System.Drawing.Point(263, 0);
			this.lb_xz_time.Name = "lb_xz_time";
			this.lb_xz_time.Size = new System.Drawing.Size(234, 24);
			this.lb_xz_time.TabIndex = 6;
			this.lb_xz_time.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(254, 24);
			this.label4.TabIndex = 0;
			this.label4.Text = "新增修改进度最后一次更新时间为:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(254, 24);
			this.label5.TabIndex = 1;
			this.label5.Text = "代码表更新进度最后一次更新时间为:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 48);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(254, 24);
			this.label6.TabIndex = 2;
			this.label6.Text = "删除数据更新进度最后一次更新时间为:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(503, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(114, 24);
			this.label7.TabIndex = 3;
			this.label7.Text = "更新进度标识:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(503, 24);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(114, 24);
			this.label8.TabIndex = 4;
			this.label8.Text = "更新进度标识:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(503, 48);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(114, 24);
			this.label9.TabIndex = 5;
			this.label9.Text = "更新进度标识:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lb_dmbgx_time
			// 
			this.lb_dmbgx_time.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.lb_dmbgx_time.AutoSize = true;
			this.lb_dmbgx_time.ForeColor = System.Drawing.Color.Blue;
			this.lb_dmbgx_time.Location = new System.Drawing.Point(263, 24);
			this.lb_dmbgx_time.Name = "lb_dmbgx_time";
			this.lb_dmbgx_time.Size = new System.Drawing.Size(234, 24);
			this.lb_dmbgx_time.TabIndex = 7;
			this.lb_dmbgx_time.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lb_scsj_time
			// 
			this.lb_scsj_time.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.lb_scsj_time.AutoSize = true;
			this.lb_scsj_time.ForeColor = System.Drawing.Color.Blue;
			this.lb_scsj_time.Location = new System.Drawing.Point(263, 48);
			this.lb_scsj_time.Name = "lb_scsj_time";
			this.lb_scsj_time.Size = new System.Drawing.Size(234, 24);
			this.lb_scsj_time.TabIndex = 8;
			this.lb_scsj_time.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lb_dmbgx_bs
			// 
			this.lb_dmbgx_bs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.lb_dmbgx_bs.AutoSize = true;
			this.lb_dmbgx_bs.ForeColor = System.Drawing.Color.Blue;
			this.lb_dmbgx_bs.Location = new System.Drawing.Point(623, 24);
			this.lb_dmbgx_bs.Name = "lb_dmbgx_bs";
			this.lb_dmbgx_bs.Size = new System.Drawing.Size(154, 24);
			this.lb_dmbgx_bs.TabIndex = 10;
			this.lb_dmbgx_bs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lb_scsj_bs
			// 
			this.lb_scsj_bs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.lb_scsj_bs.AutoSize = true;
			this.lb_scsj_bs.ForeColor = System.Drawing.Color.Blue;
			this.lb_scsj_bs.Location = new System.Drawing.Point(623, 48);
			this.lb_scsj_bs.Name = "lb_scsj_bs";
			this.lb_scsj_bs.Size = new System.Drawing.Size(154, 24);
			this.lb_scsj_bs.TabIndex = 11;
			this.lb_scsj_bs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.bt_Refresh);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.te_end);
			this.panel2.Controls.Add(this.te_start);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 100);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(865, 32);
			this.panel2.TabIndex = 16;
			// 
			// bt_Refresh
			// 
			this.bt_Refresh.Location = new System.Drawing.Point(365, 4);
			this.bt_Refresh.Name = "bt_Refresh";
			this.bt_Refresh.Size = new System.Drawing.Size(60, 23);
			this.bt_Refresh.TabIndex = 4;
			this.bt_Refresh.Text = "刷新";
			this.bt_Refresh.Click += new System.EventHandler(this.bt_Refresh_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(233, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(19, 14);
			this.label3.TabIndex = 3;
			this.label3.Text = "至";
			// 
			// te_end
			// 
			this.te_end.EditValue = null;
			this.te_end.Location = new System.Drawing.Point(258, 5);
			this.te_end.Name = "te_end";
			this.te_end.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.te_end.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.te_end.Size = new System.Drawing.Size(100, 21);
			this.te_end.TabIndex = 2;
			// 
			// te_start
			// 
			this.te_start.EditValue = null;
			this.te_start.Location = new System.Drawing.Point(127, 5);
			this.te_start.Name = "te_start";
			this.te_start.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.te_start.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.te_start.Size = new System.Drawing.Size(100, 21);
			this.te_start.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(115, 14);
			this.label1.TabIndex = 0;
			this.label1.Text = "数据下载日志时间段";
			// 
			// IMUC_SJJH_AccessLog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.sinoCommonGrid1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panelWait);
			this.Controls.Add(this.panel1);
			this.Name = "IMUC_SJJH_AccessLog";
			this.Size = new System.Drawing.Size(865, 557);
			((System.ComponentModel.ISupportInitialize)(this.sinoCommonGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			this.panelWait.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.te_end.Properties.VistaTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_end.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_start.Properties.VistaTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_start.Properties)).EndInit();
			this.ResumeLayout(false);

                }

                #endregion

                private SinoSZClientBase.SinoCommonGrid sinoCommonGrid1;
                private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
                private System.Windows.Forms.Panel panelWait;
                private System.Windows.Forms.Label label2;
                private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
                private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.Panel panel1;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel2;
		private DevExpress.XtraEditors.SimpleButton bt_Refresh;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.DateEdit te_end;
		private DevExpress.XtraEditors.DateEdit te_start;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lb_xz_bs;
		private System.Windows.Forms.Label lb_xz_time;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label lb_dmbgx_time;
		private System.Windows.Forms.Label lb_scsj_time;
		private System.Windows.Forms.Label lb_dmbgx_bs;
		private System.Windows.Forms.Label lb_scsj_bs;

        }
}
