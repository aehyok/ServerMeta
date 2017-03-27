namespace SinoSZMetaDataQuery.DataQuery
{
        partial class frmSinoSZ_TaskList
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
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSinoSZ_TaskList));
                        this.sinoCommonGrid1 = new SinoSZClientBase.SinoCommonGrid();
                        this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
                        this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
                        this.imageList1 = new System.Windows.Forms.ImageList(this.components);
                        this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
                        this.imageList2 = new System.Windows.Forms.ImageList(this.components);
                        this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
                        this.timer1 = new System.Windows.Forms.Timer(this.components);
                        ((System.ComponentModel.ISupportInitialize)(this.sinoCommonGrid1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // sinoCommonGrid1
                        // 
                        this.sinoCommonGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.sinoCommonGrid1.EmbeddedNavigator.Name = "";
                        this.sinoCommonGrid1.Location = new System.Drawing.Point(10, 10);
                        this.sinoCommonGrid1.MainView = this.gridView1;
                        this.sinoCommonGrid1.Name = "sinoCommonGrid1";
                        this.sinoCommonGrid1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1,
            this.repositoryItemImageComboBox2});
                        this.sinoCommonGrid1.Size = new System.Drawing.Size(867, 502);
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
            this.gridColumn6,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
                        this.gridView1.GridControl = this.sinoCommonGrid1;
                        this.gridView1.Name = "gridView1";
                        this.gridView1.OptionsBehavior.Editable = false;
                        this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
                        this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
                        this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
                        // 
                        // gridColumn1
                        // 
                        this.gridColumn1.Caption = "任务名称";
                        this.gridColumn1.FieldName = "TaskName";
                        this.gridColumn1.Name = "gridColumn1";
                        this.gridColumn1.OptionsColumn.ReadOnly = true;
                        this.gridColumn1.Visible = true;
                        this.gridColumn1.VisibleIndex = 2;
                        // 
                        // gridColumn2
                        // 
                        this.gridColumn2.Caption = "开始执行时间";
                        this.gridColumn2.DisplayFormat.FormatString = "yyyy年MM月dd日 HH:mm:ss";
                        this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        this.gridColumn2.FieldName = "RequestTime";
                        this.gridColumn2.Name = "gridColumn2";
                        this.gridColumn2.OptionsColumn.FixedWidth = true;
                        this.gridColumn2.OptionsColumn.ReadOnly = true;
                        this.gridColumn2.Visible = true;
                        this.gridColumn2.VisibleIndex = 3;
                        this.gridColumn2.Width = 200;
                        // 
                        // gridColumn6
                        // 
                        this.gridColumn6.Caption = "执行结束时间";
                        this.gridColumn6.DisplayFormat.FormatString = "yyyy年MM月dd日 HH:mm:ss";
                        this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        this.gridColumn6.FieldName = "FinishedTime";
                        this.gridColumn6.Name = "gridColumn6";
                        this.gridColumn6.OptionsColumn.FixedWidth = true;
                        this.gridColumn6.OptionsColumn.ReadOnly = true;
                        this.gridColumn6.Visible = true;
                        this.gridColumn6.VisibleIndex = 4;
                        this.gridColumn6.Width = 170;
                        // 
                        // gridColumn3
                        // 
                        this.gridColumn3.Caption = "查询岗位";
                        this.gridColumn3.FieldName = "PostName";
                        this.gridColumn3.Name = "gridColumn3";
                        this.gridColumn3.OptionsColumn.FixedWidth = true;
                        this.gridColumn3.OptionsColumn.ReadOnly = true;
                        this.gridColumn3.Visible = true;
                        this.gridColumn3.VisibleIndex = 5;
                        this.gridColumn3.Width = 300;
                        // 
                        // gridColumn4
                        // 
                        this.gridColumn4.Caption = "状态";
                        this.gridColumn4.ColumnEdit = this.repositoryItemImageComboBox1;
                        this.gridColumn4.FieldName = "TaskState";
                        this.gridColumn4.Name = "gridColumn4";
                        this.gridColumn4.OptionsColumn.FixedWidth = true;
                        this.gridColumn4.OptionsColumn.ReadOnly = true;
                        this.gridColumn4.Visible = true;
                        this.gridColumn4.VisibleIndex = 1;
                        this.gridColumn4.Width = 100;
                        // 
                        // repositoryItemImageComboBox1
                        // 
                        this.repositoryItemImageComboBox1.AutoHeight = false;
                        this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("请求中", 0, 5),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("调度中", 1, 5),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("执行中", 2, 5),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("完成", 3, 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("取消", 4, 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("超时", 9, 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("错误", 10, 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("已清除", 11, 7)});
                        this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
                        this.repositoryItemImageComboBox1.SmallImages = this.imageList1;
                        // 
                        // imageList1
                        // 
                        this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
                        this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
                        this.imageList1.Images.SetKeyName(0, "q1.ico");
                        this.imageList1.Images.SetKeyName(1, "q2.ico");
                        this.imageList1.Images.SetKeyName(2, "q3.ico");
                        this.imageList1.Images.SetKeyName(3, "q4.ico");
                        this.imageList1.Images.SetKeyName(4, "q5.ico");
                        this.imageList1.Images.SetKeyName(5, "q6.ico");
                        this.imageList1.Images.SetKeyName(6, "q7.ico");
                        this.imageList1.Images.SetKeyName(7, "q9.ico");
                        // 
                        // gridColumn5
                        // 
                        this.gridColumn5.ColumnEdit = this.repositoryItemImageComboBox2;
                        this.gridColumn5.FieldName = "ResultLocked";
                        this.gridColumn5.Name = "gridColumn5";
                        this.gridColumn5.OptionsColumn.FixedWidth = true;
                        this.gridColumn5.OptionsColumn.ReadOnly = true;
                        this.gridColumn5.Visible = true;
                        this.gridColumn5.VisibleIndex = 0;
                        this.gridColumn5.Width = 30;
                        // 
                        // repositoryItemImageComboBox2
                        // 
                        this.repositoryItemImageComboBox2.AutoHeight = false;
                        this.repositoryItemImageComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.repositoryItemImageComboBox2.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
                        this.repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("锁定", true, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("未锁定", false, -1)});
                        this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
                        this.repositoryItemImageComboBox2.SmallImages = this.imageList2;
                        // 
                        // imageList2
                        // 
                        this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
                        this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
                        this.imageList2.Images.SetKeyName(0, "q8.ico");
                        // 
                        // backgroundWorker1
                        // 
                        this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
                        this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
                        // 
                        // timer1
                        // 
                        this.timer1.Interval = 60000;
                        this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
                        // 
                        // frmSinoSZ_TaskList
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(887, 522);
                        this.Controls.Add(this.sinoCommonGrid1);
                        this.Name = "frmSinoSZ_TaskList";
                        this.Padding = new System.Windows.Forms.Padding(10);
                        this.Text = "查询任务列表";
                        ((System.ComponentModel.ISupportInitialize)(this.sinoCommonGrid1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private SinoSZClientBase.SinoCommonGrid sinoCommonGrid1;
                private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
                private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
                private System.Windows.Forms.ImageList imageList1;
                private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
                private System.Windows.Forms.ImageList imageList2;
                private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.Timer timer1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;

        }
}