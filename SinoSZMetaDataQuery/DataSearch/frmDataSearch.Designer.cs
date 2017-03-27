namespace SinoSZMetaDataQuery.DataSearch
{
        partial class frmDataSearch
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
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDataSearch));
                        this.sinoSZUC_SearchInput1 = new SinoSZMetaDataQuery.DataSearch.SinoSZUC_SearchInput();
                        this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
                        this.treeList1 = new DevExpress.XtraTreeList.TreeList();
                        this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
                        this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
                        this.imageList1 = new System.Windows.Forms.ImageList(this.components);
                        this.stateImageList = new System.Windows.Forms.ImageList(this.components);
                        this.panel1 = new System.Windows.Forms.Panel();
                        this.sinoCommonGrid1 = new SinoSZClientBase.SinoCommonGrid();
                        this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
                        this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.panel2 = new System.Windows.Forms.Panel();
                        this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
                        this.labelState = new System.Windows.Forms.Label();
                        this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
                        this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
                        ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
                        this.splitContainerControl2.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
                        this.panel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.sinoCommonGrid1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
                        this.panelControl1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // sinoSZUC_SearchInput1
                        // 
                        this.sinoSZUC_SearchInput1.Appearance.BackColor = System.Drawing.Color.Transparent;
                        this.sinoSZUC_SearchInput1.Appearance.Options.UseBackColor = true;
                        this.sinoSZUC_SearchInput1.Dock = System.Windows.Forms.DockStyle.Top;
                        this.sinoSZUC_SearchInput1.Location = new System.Drawing.Point(7, 0);
                        this.sinoSZUC_SearchInput1.Name = "sinoSZUC_SearchInput1";
                        this.sinoSZUC_SearchInput1.Size = new System.Drawing.Size(980, 103);
                        this.sinoSZUC_SearchInput1.TabIndex = 0;
                        // 
                        // splitContainerControl2
                        // 
                        this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.splitContainerControl2.Location = new System.Drawing.Point(12, 11);
                        this.splitContainerControl2.Name = "splitContainerControl2";
                        this.splitContainerControl2.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                        this.splitContainerControl2.Panel1.Controls.Add(this.treeList1);
                        this.splitContainerControl2.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
                        this.splitContainerControl2.Panel1.Text = "Panel1";
                        this.splitContainerControl2.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                        this.splitContainerControl2.Panel2.Controls.Add(this.panel1);
                        this.splitContainerControl2.Panel2.Controls.Add(this.sinoSZUC_SearchInput1);
                        this.splitContainerControl2.Panel2.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
                        this.splitContainerControl2.Panel2.Text = "Panel2";
                        this.splitContainerControl2.Size = new System.Drawing.Size(1053, 558);
                        this.splitContainerControl2.SplitterPosition = 201;
                        this.splitContainerControl2.TabIndex = 3;
                        this.splitContainerControl2.Text = "splitContainerControl2";
                        // 
                        // treeList1
                        // 
                        this.treeList1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
                        this.treeList1.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
                        this.treeList1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
                        this.treeList1.Appearance.FocusedCell.Options.UseBackColor = true;
                        this.treeList1.Appearance.FocusedCell.Options.UseForeColor = true;
                        this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn3});
                        this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.treeList1.Location = new System.Drawing.Point(0, 0);
                        this.treeList1.Name = "treeList1";
                        this.treeList1.SelectImageList = this.imageList1;
                        this.treeList1.Size = new System.Drawing.Size(227, 605);
                        this.treeList1.StateImageList = this.stateImageList;
                        this.treeList1.TabIndex = 1;
                        this.treeList1.StateImageClick += new DevExpress.XtraTreeList.NodeClickEventHandler(this.treeList1_StateImageClick);
                        this.treeList1.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.treeList1_GetStateImage);
                        // 
                        // treeListColumn1
                        // 
                        this.treeListColumn1.Caption = "数据源";
                        this.treeListColumn1.FieldName = "COLUMN1";
                        this.treeListColumn1.MinWidth = 43;
                        this.treeListColumn1.Name = "treeListColumn1";
                        this.treeListColumn1.OptionsColumn.AllowEdit = false;
                        this.treeListColumn1.OptionsColumn.ReadOnly = true;
                        this.treeListColumn1.Visible = true;
                        this.treeListColumn1.VisibleIndex = 0;
                        // 
                        // treeListColumn3
                        // 
                        this.treeListColumn3.Caption = "treeListColumn3";
                        this.treeListColumn3.FieldName = "State";
                        this.treeListColumn3.Name = "treeListColumn3";
                        this.treeListColumn3.OptionsColumn.FixedWidth = true;
                        this.treeListColumn3.OptionsColumn.ReadOnly = true;
                        // 
                        // imageList1
                        // 
                        this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
                        this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
                        this.imageList1.Images.SetKeyName(0, "title.ico");
                        this.imageList1.Images.SetKeyName(1, "childPack.ico");
                        // 
                        // stateImageList
                        // 
                        this.stateImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("stateImageList.ImageStream")));
                        this.stateImageList.TransparentColor = System.Drawing.Color.Magenta;
                        this.stateImageList.Images.SetKeyName(0, "check2.ico");
                        this.stateImageList.Images.SetKeyName(1, "check00.ico");
                        this.stateImageList.Images.SetKeyName(2, "check11.ico");
                        this.stateImageList.Images.SetKeyName(3, "check33.ico");
                        // 
                        // panel1
                        // 
                        this.panel1.Controls.Add(this.sinoCommonGrid1);
                        this.panel1.Controls.Add(this.panel2);
                        this.panel1.Controls.Add(this.panelControl1);
                        this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.panel1.Location = new System.Drawing.Point(7, 103);
                        this.panel1.Name = "panel1";
                        this.panel1.Padding = new System.Windows.Forms.Padding(0, 11, 2, 0);
                        this.panel1.Size = new System.Drawing.Size(980, 502);
                        this.panel1.TabIndex = 3;
                        // 
                        // sinoCommonGrid1
                        // 
                        this.sinoCommonGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.sinoCommonGrid1.EmbeddedNavigator.Name = "";
                        this.sinoCommonGrid1.Location = new System.Drawing.Point(0, 11);
                        this.sinoCommonGrid1.MainView = this.gridView1;
                        this.sinoCommonGrid1.Name = "sinoCommonGrid1";
                        this.sinoCommonGrid1.Size = new System.Drawing.Size(978, 462);
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
                        this.gridView1.OptionsView.ColumnAutoWidth = false;
                        this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
                        this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
                        this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
                        // 
                        // gridColumn1
                        // 
                        this.gridColumn1.Caption = "信息内容";
                        this.gridColumn1.FieldName = "Content";
                        this.gridColumn1.Name = "gridColumn1";
                        this.gridColumn1.OptionsColumn.ReadOnly = true;
                        this.gridColumn1.Visible = true;
                        this.gridColumn1.VisibleIndex = 0;
                        this.gridColumn1.Width = 500;
                        // 
                        // gridColumn2
                        // 
                        this.gridColumn2.Caption = "数据源";
                        this.gridColumn2.FieldName = "DataSource";
                        this.gridColumn2.Name = "gridColumn2";
                        this.gridColumn2.OptionsColumn.FixedWidth = true;
                        this.gridColumn2.OptionsColumn.ReadOnly = true;
                        this.gridColumn2.Visible = true;
                        this.gridColumn2.VisibleIndex = 1;
                        this.gridColumn2.Width = 140;
                        // 
                        // gridColumn3
                        // 
                        this.gridColumn3.Caption = "[数据表].[数据字段]";
                        this.gridColumn3.FieldName = "DataLocation";
                        this.gridColumn3.Name = "gridColumn3";
                        this.gridColumn3.OptionsColumn.FixedWidth = true;
                        this.gridColumn3.OptionsColumn.ReadOnly = true;
                        this.gridColumn3.Visible = true;
                        this.gridColumn3.VisibleIndex = 2;
                        this.gridColumn3.Width = 200;
                        // 
                        // gridColumn4
                        // 
                        this.gridColumn4.Caption = "信息标识";
                        this.gridColumn4.FieldName = "MainKey";
                        this.gridColumn4.Name = "gridColumn4";
                        this.gridColumn4.OptionsColumn.FixedWidth = true;
                        this.gridColumn4.OptionsColumn.ReadOnly = true;
                        this.gridColumn4.Width = 120;
                        // 
                        // panel2
                        // 
                        this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.panel2.Location = new System.Drawing.Point(0, 473);
                        this.panel2.Name = "panel2";
                        this.panel2.Size = new System.Drawing.Size(978, 5);
                        this.panel2.TabIndex = 2;
                        // 
                        // panelControl1
                        // 
                        this.panelControl1.Controls.Add(this.labelState);
                        this.panelControl1.Controls.Add(this.progressBarControl1);
                        this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.panelControl1.Location = new System.Drawing.Point(0, 478);
                        this.panelControl1.Name = "panelControl1";
                        this.panelControl1.Size = new System.Drawing.Size(978, 24);
                        this.panelControl1.TabIndex = 1;
                        // 
                        // labelState
                        // 
                        this.labelState.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.labelState.ForeColor = System.Drawing.Color.Brown;
                        this.labelState.Location = new System.Drawing.Point(2, 2);
                        this.labelState.Name = "labelState";
                        this.labelState.Size = new System.Drawing.Size(773, 20);
                        this.labelState.TabIndex = 0;
                        // 
                        // progressBarControl1
                        // 
                        this.progressBarControl1.Dock = System.Windows.Forms.DockStyle.Right;
                        this.progressBarControl1.Location = new System.Drawing.Point(775, 2);
                        this.progressBarControl1.Name = "progressBarControl1";
                        this.progressBarControl1.Properties.ShowTitle = true;
                        this.progressBarControl1.Size = new System.Drawing.Size(201, 20);
                        this.progressBarControl1.TabIndex = 1;
                        // 
                        // backgroundWorker1
                        // 
                        this.backgroundWorker1.WorkerReportsProgress = true;
                        this.backgroundWorker1.WorkerSupportsCancellation = true;
                        this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
                        this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
                        this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
                        // 
                        // frmDataSearch
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(1077, 580);
                        this.Controls.Add(this.splitContainerControl2);
                        this.Name = "frmDataSearch";
                        this.Padding = new System.Windows.Forms.Padding(12, 11, 12, 11);
                        this.Text = "信息检索";
                        this.Load += new System.EventHandler(this.frmDataSearch_Load);
                        ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
                        this.splitContainerControl2.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
                        this.panel1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.sinoCommonGrid1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
                        this.panelControl1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private SinoSZUC_SearchInput sinoSZUC_SearchInput1;
                private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
                private System.Windows.Forms.Panel panel1;
                private SinoSZClientBase.SinoCommonGrid sinoCommonGrid1;
                private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
                private DevExpress.XtraTreeList.TreeList treeList1;
                private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
                private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
                private System.Windows.Forms.ImageList imageList1;
                private System.Windows.Forms.ImageList stateImageList;
                private System.ComponentModel.BackgroundWorker backgroundWorker1;
                private DevExpress.XtraEditors.PanelControl panelControl1;
                private System.Windows.Forms.Label labelState;
                private System.Windows.Forms.Panel panel2;
                private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        }
}