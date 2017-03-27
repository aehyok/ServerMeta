namespace SinoSZClientSysManager.TaskManager
{
        partial class frmTaskManager
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaskManager));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TE_RWMS = new DevExpress.XtraEditors.TextEdit();
            this.TE_RWID = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TE_RWMC = new DevExpress.XtraEditors.TextEdit();
            this.TE_RWZT = new DevExpress.XtraEditors.TextEdit();
            this.TE_NEXTTIME = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TE_LASTTIME = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TE_LASTFLAG = new DevExpress.XtraEditors.TextEdit();
            this.TE_LASTRESULT = new DevExpress.XtraEditors.MemoEdit();
            this.PB_FLAG = new System.Windows.Forms.PictureBox();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.CB_LOG_ALL = new System.Windows.Forms.CheckBox();
            this.sinoCommonGrid1 = new SinoSZClientBase.SinoCommonGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CK_LOG_ERROR = new System.Windows.Forms.CheckBox();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.ParamPanel = new DevExpress.XtraEditors.PanelControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TE_RWMS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_RWID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_RWMC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_RWZT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_NEXTTIME.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TE_LASTTIME.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_LASTFLAG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_LASTRESULT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_FLAG)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sinoCommonGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParamPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.TE_RWMS, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.TE_RWID, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TE_RWMC, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.TE_RWZT, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.TE_NEXTTIME, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.xtraTabControl1, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 15);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1346, 855);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TE_RWMS
            // 
            this.TE_RWMS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.TE_RWMS, 3);
            this.TE_RWMS.Location = new System.Drawing.Point(137, 49);
            this.TE_RWMS.Margin = new System.Windows.Forms.Padding(4);
            this.TE_RWMS.Name = "TE_RWMS";
            this.TE_RWMS.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.TE_RWMS.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.TE_RWMS.Properties.AutoHeight = false;
            this.TE_RWMS.Properties.ReadOnly = true;
            this.TE_RWMS.Size = new System.Drawing.Size(1205, 37);
            this.TE_RWMS.TabIndex = 7;
            // 
            // TE_RWID
            // 
            this.TE_RWID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TE_RWID.Location = new System.Drawing.Point(810, 4);
            this.TE_RWID.Margin = new System.Windows.Forms.Padding(4);
            this.TE_RWID.Name = "TE_RWID";
            this.TE_RWID.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.TE_RWID.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.TE_RWID.Properties.AutoHeight = false;
            this.TE_RWID.Properties.ReadOnly = true;
            this.TE_RWID.Size = new System.Drawing.Size(532, 37);
            this.TE_RWID.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "任务名称";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(677, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 45);
            this.label2.TabIndex = 1;
            this.label2.Text = "任务ID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(4, 45);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 45);
            this.label3.TabIndex = 2;
            this.label3.Text = "任务描述";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(677, 90);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 45);
            this.label4.TabIndex = 3;
            this.label4.Text = "下次执行时间";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(4, 90);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 45);
            this.label5.TabIndex = 4;
            this.label5.Text = "任务状态";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TE_RWMC
            // 
            this.TE_RWMC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TE_RWMC.Location = new System.Drawing.Point(137, 4);
            this.TE_RWMC.Margin = new System.Windows.Forms.Padding(4);
            this.TE_RWMC.Name = "TE_RWMC";
            this.TE_RWMC.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.TE_RWMC.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.TE_RWMC.Properties.AutoHeight = false;
            this.TE_RWMC.Properties.ReadOnly = true;
            this.TE_RWMC.Size = new System.Drawing.Size(532, 37);
            this.TE_RWMC.TabIndex = 5;
            // 
            // TE_RWZT
            // 
            this.TE_RWZT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TE_RWZT.Location = new System.Drawing.Point(137, 94);
            this.TE_RWZT.Margin = new System.Windows.Forms.Padding(4);
            this.TE_RWZT.Name = "TE_RWZT";
            this.TE_RWZT.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.TE_RWZT.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.TE_RWZT.Properties.AutoHeight = false;
            this.TE_RWZT.Properties.ReadOnly = true;
            this.TE_RWZT.Size = new System.Drawing.Size(532, 37);
            this.TE_RWZT.TabIndex = 8;
            // 
            // TE_NEXTTIME
            // 
            this.TE_NEXTTIME.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TE_NEXTTIME.Location = new System.Drawing.Point(810, 94);
            this.TE_NEXTTIME.Margin = new System.Windows.Forms.Padding(4);
            this.TE_NEXTTIME.Name = "TE_NEXTTIME";
            this.TE_NEXTTIME.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.TE_NEXTTIME.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.TE_NEXTTIME.Properties.AutoHeight = false;
            this.TE_NEXTTIME.Properties.ReadOnly = true;
            this.TE_NEXTTIME.Size = new System.Drawing.Size(532, 37);
            this.TE_NEXTTIME.TabIndex = 9;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.xtraTabControl1, 4);
            this.xtraTabControl1.Location = new System.Drawing.Point(13, 150);
            this.xtraTabControl1.Margin = new System.Windows.Forms.Padding(13, 15, 13, 15);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1320, 690);
            this.xtraTabControl1.TabIndex = 10;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.tableLayoutPanel2);
            this.xtraTabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Padding = new System.Windows.Forms.Padding(13, 15, 13, 15);
            this.xtraTabPage1.Size = new System.Drawing.Size(1314, 657);
            this.xtraTabPage1.Text = "最后一次执行情况";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.TE_LASTTIME, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label8, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.TE_LASTFLAG, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.TE_LASTRESULT, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.PB_FLAG, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(13, 15);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1288, 627);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // TE_LASTTIME
            // 
            this.TE_LASTTIME.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TE_LASTTIME.Location = new System.Drawing.Point(431, 4);
            this.TE_LASTTIME.Margin = new System.Windows.Forms.Padding(4);
            this.TE_LASTTIME.Name = "TE_LASTTIME";
            this.TE_LASTTIME.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.TE_LASTTIME.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.TE_LASTTIME.Properties.AutoHeight = false;
            this.TE_LASTTIME.Properties.ReadOnly = true;
            this.TE_LASTTIME.Size = new System.Drawing.Size(853, 37);
            this.TE_LASTTIME.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(271, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 45);
            this.label6.TabIndex = 11;
            this.label6.Text = "上次完成时间";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(271, 45);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 45);
            this.label7.TabIndex = 12;
            this.label7.Text = "上次完成结果";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Location = new System.Drawing.Point(271, 90);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 45);
            this.label8.TabIndex = 13;
            this.label8.Text = "上次结果说明";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TE_LASTFLAG
            // 
            this.TE_LASTFLAG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TE_LASTFLAG.Location = new System.Drawing.Point(431, 49);
            this.TE_LASTFLAG.Margin = new System.Windows.Forms.Padding(4);
            this.TE_LASTFLAG.Name = "TE_LASTFLAG";
            this.TE_LASTFLAG.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.TE_LASTFLAG.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.TE_LASTFLAG.Properties.AutoHeight = false;
            this.TE_LASTFLAG.Properties.ReadOnly = true;
            this.TE_LASTFLAG.Size = new System.Drawing.Size(853, 37);
            this.TE_LASTFLAG.TabIndex = 14;
            // 
            // TE_LASTRESULT
            // 
            this.TE_LASTRESULT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TE_LASTRESULT.Location = new System.Drawing.Point(431, 94);
            this.TE_LASTRESULT.Margin = new System.Windows.Forms.Padding(4);
            this.TE_LASTRESULT.Name = "TE_LASTRESULT";
            this.TE_LASTRESULT.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.TE_LASTRESULT.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.TE_LASTRESULT.Properties.ReadOnly = true;
            this.tableLayoutPanel2.SetRowSpan(this.TE_LASTRESULT, 2);
            this.TE_LASTRESULT.Size = new System.Drawing.Size(853, 529);
            this.TE_LASTRESULT.TabIndex = 15;
            // 
            // PB_FLAG
            // 
            this.PB_FLAG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PB_FLAG.Location = new System.Drawing.Point(4, 4);
            this.PB_FLAG.Margin = new System.Windows.Forms.Padding(4);
            this.PB_FLAG.Name = "PB_FLAG";
            this.tableLayoutPanel2.SetRowSpan(this.PB_FLAG, 4);
            this.PB_FLAG.Size = new System.Drawing.Size(259, 619);
            this.PB_FLAG.TabIndex = 16;
            this.PB_FLAG.TabStop = false;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.tableLayoutPanel3);
            this.xtraTabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Padding = new System.Windows.Forms.Padding(13, 15, 13, 15);
            this.xtraTabPage2.Size = new System.Drawing.Size(1314, 657);
            this.xtraTabPage2.Text = "任务处理日志";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 333F));
            this.tableLayoutPanel3.Controls.Add(this.CB_LOG_ALL, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.sinoCommonGrid1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.CK_LOG_ERROR, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(13, 15);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1288, 627);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // CB_LOG_ALL
            // 
            this.CB_LOG_ALL.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CB_LOG_ALL.AutoSize = true;
            this.CB_LOG_ALL.Checked = true;
            this.CB_LOG_ALL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_LOG_ALL.Location = new System.Drawing.Point(1028, 11);
            this.CB_LOG_ALL.Margin = new System.Windows.Forms.Padding(4);
            this.CB_LOG_ALL.Name = "CB_LOG_ALL";
            this.CB_LOG_ALL.Size = new System.Drawing.Size(256, 22);
            this.CB_LOG_ALL.TabIndex = 2;
            this.CB_LOG_ALL.Text = "仅显示距现在最近的30条日志记录";
            this.CB_LOG_ALL.UseVisualStyleBackColor = true;
            this.CB_LOG_ALL.CheckedChanged += new System.EventHandler(this.CB_LOG_ALL_CheckedChanged);
            // 
            // sinoCommonGrid1
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.sinoCommonGrid1, 2);
            this.sinoCommonGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sinoCommonGrid1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.sinoCommonGrid1.Location = new System.Drawing.Point(4, 49);
            this.sinoCommonGrid1.MainView = this.gridView1;
            this.sinoCommonGrid1.Margin = new System.Windows.Forms.Padding(4);
            this.sinoCommonGrid1.Name = "sinoCommonGrid1";
            this.sinoCommonGrid1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.sinoCommonGrid1.Size = new System.Drawing.Size(1280, 574);
            this.sinoCommonGrid1.TabIndex = 0;
            this.sinoCommonGrid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(255)))), ((int)(((byte)(229)))));
            this.gridView1.Appearance.EvenRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(255)))), ((int)(((byte)(229)))));
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.DarkOrange;
            this.gridView1.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.DarkOrange;
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedCell.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkOrange;
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkOrange;
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.sinoCommonGrid1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "处理时间";
            this.gridColumn1.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn1.FieldName = "RUNTIME";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 160;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "处理状态";
            this.gridColumn2.ColumnEdit = this.repositoryItemImageComboBox1;
            this.gridColumn2.FieldName = "RUNFLAG";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.FixedWidth = true;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 100;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("成功", new decimal(new int[] {
                            0,
                            0,
                            0,
                            0}), -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("警告", new decimal(new int[] {
                            1,
                            0,
                            0,
                            0}), -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("错误", new decimal(new int[] {
                            9,
                            0,
                            0,
                            0}), -1)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "处理信息";
            this.gridColumn3.FieldName = "RUNRESULT";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 679;
            // 
            // CK_LOG_ERROR
            // 
            this.CK_LOG_ERROR.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CK_LOG_ERROR.AutoSize = true;
            this.CK_LOG_ERROR.Location = new System.Drawing.Point(801, 11);
            this.CK_LOG_ERROR.Margin = new System.Windows.Forms.Padding(4);
            this.CK_LOG_ERROR.Name = "CK_LOG_ERROR";
            this.CK_LOG_ERROR.Size = new System.Drawing.Size(150, 22);
            this.CK_LOG_ERROR.TabIndex = 1;
            this.CK_LOG_ERROR.Text = "仅显示警告和错误";
            this.CK_LOG_ERROR.UseVisualStyleBackColor = true;
            this.CK_LOG_ERROR.CheckedChanged += new System.EventHandler(this.CK_LOG_ERROR_CheckedChanged);
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.ParamPanel);
            this.xtraTabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Padding = new System.Windows.Forms.Padding(13, 15, 13, 15);
            this.xtraTabPage3.Size = new System.Drawing.Size(1314, 657);
            this.xtraTabPage3.Text = "任务执行参数";
            // 
            // ParamPanel
            // 
            this.ParamPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParamPanel.Location = new System.Drawing.Point(13, 15);
            this.ParamPanel.Margin = new System.Windows.Forms.Padding(4);
            this.ParamPanel.Name = "ParamPanel";
            this.ParamPanel.Size = new System.Drawing.Size(1280, 612);
            this.ParamPanel.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ni_png_0907.png");
            this.imageList1.Images.SetKeyName(1, "ni_png_0910.png");
            this.imageList1.Images.SetKeyName(2, "ni_png_0901.png");
            // 
            // timer1
            // 
            this.timer1.Interval = 180000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // frmTaskManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1372, 885);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "frmTaskManager";
            this.Padding = new System.Windows.Forms.Padding(13, 15, 13, 15);
            this.Text = "frmTaskManager";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TE_RWMS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_RWID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_RWMC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_RWZT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_NEXTTIME.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TE_LASTTIME.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_LASTFLAG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_LASTRESULT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_FLAG)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sinoCommonGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ParamPanel)).EndInit();
            this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
                private System.Windows.Forms.Label label1;
                private System.Windows.Forms.Label label2;
                private System.Windows.Forms.Label label3;
                private System.Windows.Forms.Label label4;
                private DevExpress.XtraEditors.TextEdit TE_RWMS;
                private DevExpress.XtraEditors.TextEdit TE_RWID;
                private System.Windows.Forms.Label label5;
                private DevExpress.XtraEditors.TextEdit TE_RWMC;
                private DevExpress.XtraEditors.TextEdit TE_RWZT;
                private DevExpress.XtraEditors.TextEdit TE_NEXTTIME;
                private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
                private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
                private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
                private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
                private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
                private System.Windows.Forms.Label label6;
                private System.Windows.Forms.Label label7;
                private DevExpress.XtraEditors.TextEdit TE_LASTTIME;
                private System.Windows.Forms.Label label8;
                private DevExpress.XtraEditors.TextEdit TE_LASTFLAG;
                private DevExpress.XtraEditors.MemoEdit TE_LASTRESULT;
                private System.Windows.Forms.PictureBox PB_FLAG;
                private System.Windows.Forms.ImageList imageList1;
                private System.Windows.Forms.Timer timer1;
                private SinoSZClientBase.SinoCommonGrid sinoCommonGrid1;
                private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
                private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
                private System.Windows.Forms.CheckBox CK_LOG_ERROR;
                private DevExpress.XtraEditors.PanelControl ParamPanel;
                private System.Windows.Forms.CheckBox CB_LOG_ALL;
                private System.ComponentModel.BackgroundWorker backgroundWorker1;
                private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        }
}