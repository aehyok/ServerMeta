namespace SinoSZMetaDataQuery.AlertMonitor
{
        partial class frmAlertMonitor
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
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlertMonitor));
                        DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition();
                        this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
                        this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
                        this.objectImageList = new System.Windows.Forms.ImageList(this.components);
                        this.treeList1 = new DevExpress.XtraTreeList.TreeList();
                        this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
                        this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
                        this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
                        this.label1 = new System.Windows.Forms.Label();
                        this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
                        this.sinoSZUC_AlertResult1 = new SinoSZMetaDataQuery.AlertMonitor.SinoSZUC_AlertResult();
                        this.panel2 = new System.Windows.Forms.Panel();
                        this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
                        this.sinoSZUC_GuideLineDynamicInput21 = new SinoSZMetaDataQuery.GuideLineQuery.SinoSZUC_GuideLineDynamicInput2();
                        this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
                        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
                        this.splitContainerControl1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
                        this.panelControl1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
                        this.panel2.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
                        this.panelControl2.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // treeListColumn3
                        // 
                        this.treeListColumn3.Caption = "treeListColumn3";
                        this.treeListColumn3.FieldName = "State";
                        this.treeListColumn3.Name = "treeListColumn3";
                        this.treeListColumn3.OptionsColumn.FixedWidth = true;
                        this.treeListColumn3.OptionsColumn.ReadOnly = true;
                        // 
                        // treeListColumn1
                        // 
                        this.treeListColumn1.AppearanceHeader.Image = global::SinoSZMetaDataQuery.Properties.Resources.x3;
                        this.treeListColumn1.AppearanceHeader.Options.UseImage = true;
                        this.treeListColumn1.Caption = "指标列表";
                        this.treeListColumn1.FieldName = "COLUMN1";
                        this.treeListColumn1.MinWidth = 43;
                        this.treeListColumn1.Name = "treeListColumn1";
                        this.treeListColumn1.OptionsColumn.AllowEdit = false;
                        this.treeListColumn1.OptionsColumn.ReadOnly = true;
                        this.treeListColumn1.Visible = true;
                        this.treeListColumn1.VisibleIndex = 0;
                        // 
                        // objectImageList
                        // 
                        this.objectImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("objectImageList.ImageStream")));
                        this.objectImageList.TransparentColor = System.Drawing.Color.Transparent;
                        this.objectImageList.Images.SetKeyName(0, "mainPack2.ico");
                        this.objectImageList.Images.SetKeyName(1, "childPack.ico");
                        this.objectImageList.Images.SetKeyName(2, "title.ico");
                        this.objectImageList.Images.SetKeyName(3, "title.ico");
                        this.objectImageList.Images.SetKeyName(4, "title.ico");
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
            this.treeListColumn3,
            this.treeListColumn2});
                        this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
                        styleFormatCondition1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
                        styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
                        styleFormatCondition1.Appearance.Options.UseFont = true;
                        styleFormatCondition1.Appearance.Options.UseForeColor = true;
                        styleFormatCondition1.ApplyToRow = true;
                        styleFormatCondition1.Column = this.treeListColumn3;
                        styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
                        styleFormatCondition1.Value1 = "1";
                        this.treeList1.FormatConditions.AddRange(new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition[] {
            styleFormatCondition1});
                        this.treeList1.Location = new System.Drawing.Point(5, 4);
                        this.treeList1.Name = "treeList1";
                        this.treeList1.OptionsSelection.EnableAppearanceFocusedCell = false;
                        this.treeList1.OptionsView.ShowColumns = false;
                        this.treeList1.OptionsView.ShowHorzLines = false;
                        this.treeList1.OptionsView.ShowIndicator = false;
                        this.treeList1.OptionsView.ShowVertLines = false;
                        this.treeList1.SelectImageList = this.objectImageList;
                        this.treeList1.Size = new System.Drawing.Size(379, 482);
                        this.treeList1.TabIndex = 2;
                        this.treeList1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseDoubleClick);
                        this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
                        this.treeList1.GetSelectImage += new DevExpress.XtraTreeList.GetSelectImageEventHandler(this.treeList1_GetSelectImage);
                        // 
                        // treeListColumn2
                        // 
                        this.treeListColumn2.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
                        this.treeListColumn2.AppearanceCell.Options.UseForeColor = true;
                        this.treeListColumn2.Format.FormatString = "({0})";
                        this.treeListColumn2.Name = "treeListColumn2";
                        this.treeListColumn2.OptionsColumn.AllowEdit = false;
                        this.treeListColumn2.OptionsColumn.FixedWidth = true;
                        this.treeListColumn2.OptionsColumn.ReadOnly = true;
                        this.treeListColumn2.Visible = true;
                        this.treeListColumn2.VisibleIndex = 1;
                        this.treeListColumn2.Width = 60;
                        // 
                        // splitContainerControl1
                        // 
                        this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.splitContainerControl1.Location = new System.Drawing.Point(10, 11);
                        this.splitContainerControl1.Name = "splitContainerControl1";
                        this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                        this.splitContainerControl1.Panel1.Controls.Add(this.treeList1);
                        this.splitContainerControl1.Panel1.Controls.Add(this.panelControl1);
                        this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(5);
                        this.splitContainerControl1.Panel1.Text = "Panel1";
                        this.splitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                        this.splitContainerControl1.Panel2.Controls.Add(this.sinoSZUC_AlertResult1);
                        this.splitContainerControl1.Panel2.Controls.Add(this.panel2);
                        this.splitContainerControl1.Panel2.Text = "Panel2";
                        this.splitContainerControl1.Size = new System.Drawing.Size(892, 515);
                        this.splitContainerControl1.SplitterPosition = 389;
                        this.splitContainerControl1.TabIndex = 2;
                        this.splitContainerControl1.Text = "splitContainerControl1";
                        // 
                        // panelControl1
                        // 
                        this.panelControl1.Controls.Add(this.label1);
                        this.panelControl1.Controls.Add(this.marqueeProgressBarControl1);
                        this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.panelControl1.Location = new System.Drawing.Point(5, 486);
                        this.panelControl1.Name = "panelControl1";
                        this.panelControl1.Size = new System.Drawing.Size(379, 24);
                        this.panelControl1.TabIndex = 3;
                        this.panelControl1.Visible = false;
                        // 
                        // label1
                        // 
                        this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.label1.Location = new System.Drawing.Point(102, 2);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(275, 20);
                        this.label1.TabIndex = 1;
                        this.label1.Text = "正在查询数据,请稍候 ...";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // marqueeProgressBarControl1
                        // 
                        this.marqueeProgressBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
                        this.marqueeProgressBarControl1.EditValue = 0;
                        this.marqueeProgressBarControl1.Location = new System.Drawing.Point(2, 2);
                        this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
                        this.marqueeProgressBarControl1.Size = new System.Drawing.Size(100, 20);
                        this.marqueeProgressBarControl1.TabIndex = 0;
                        // 
                        // sinoSZUC_AlertResult1
                        // 
                        this.sinoSZUC_AlertResult1.CanGrouped = true;
                        this.sinoSZUC_AlertResult1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.sinoSZUC_AlertResult1.Location = new System.Drawing.Point(0, 50);
                        this.sinoSZUC_AlertResult1.Name = "sinoSZUC_AlertResult1";
                        this.sinoSZUC_AlertResult1.Size = new System.Drawing.Size(497, 465);
                        this.sinoSZUC_AlertResult1.TabIndex = 6;
                        this.sinoSZUC_AlertResult1.DataChanged += new System.EventHandler(this.sinoSZUC_AlertResult1_DataChanged);
                        this.sinoSZUC_AlertResult1.QueryFinished += new System.EventHandler(this.sinoSZUC_AlertResult1_QueryFinished);
                        // 
                        // panel2
                        // 
                        this.panel2.Controls.Add(this.panelControl2);
                        this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
                        this.panel2.Location = new System.Drawing.Point(0, 0);
                        this.panel2.Name = "panel2";
                        this.panel2.Padding = new System.Windows.Forms.Padding(5);
                        this.panel2.Size = new System.Drawing.Size(497, 50);
                        this.panel2.TabIndex = 5;
                        // 
                        // panelControl2
                        // 
                        this.panelControl2.Controls.Add(this.sinoSZUC_GuideLineDynamicInput21);
                        this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.panelControl2.Location = new System.Drawing.Point(5, 5);
                        this.panelControl2.Name = "panelControl2";
                        this.panelControl2.Padding = new System.Windows.Forms.Padding(8);
                        this.panelControl2.Size = new System.Drawing.Size(487, 40);
                        this.panelControl2.TabIndex = 0;
                        // 
                        // sinoSZUC_GuideLineDynamicInput21
                        // 
                        this.sinoSZUC_GuideLineDynamicInput21.BackColor = System.Drawing.Color.Transparent;
                        this.sinoSZUC_GuideLineDynamicInput21.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.sinoSZUC_GuideLineDynamicInput21.Location = new System.Drawing.Point(8, 8);
                        this.sinoSZUC_GuideLineDynamicInput21.Name = "sinoSZUC_GuideLineDynamicInput21";
                        this.sinoSZUC_GuideLineDynamicInput21.Size = new System.Drawing.Size(471, 24);
                        this.sinoSZUC_GuideLineDynamicInput21.TabIndex = 2;
                        this.sinoSZUC_GuideLineDynamicInput21.InputChanged += new System.EventHandler(this.sinoSZUC_GuideLineDynamicInput21_InputChanged);
                        // 
                        // backgroundWorker1
                        // 
                        this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
                        this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
                        // 
                        // frmAlertMonitor
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(912, 537);
                        this.Controls.Add(this.splitContainerControl1);
                        this.Name = "frmAlertMonitor";
                        this.Padding = new System.Windows.Forms.Padding(10, 11, 10, 11);
                        this.Text = "frmAlertMonitor";
                        this.Load += new System.EventHandler(this.frmAlertMonitor_Load);
                        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
                        this.splitContainerControl1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
                        this.panelControl1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
                        this.panel2.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
                        this.panelControl2.ResumeLayout(false);
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
                private System.Windows.Forms.ImageList objectImageList;
                private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
                private DevExpress.XtraTreeList.TreeList treeList1;
                private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
                private System.Windows.Forms.Panel panel2;
                private SinoSZMetaDataQuery.GuideLineQuery.SinoSZUC_GuideLineDynamicInput2 sinoSZUC_GuideLineDynamicInput21;
                private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
                private System.ComponentModel.BackgroundWorker backgroundWorker1;
                private DevExpress.XtraEditors.PanelControl panelControl1;
                private System.Windows.Forms.Label label1;
                private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
                private DevExpress.XtraEditors.PanelControl panelControl2;
                private SinoSZUC_AlertResult sinoSZUC_AlertResult1;
        }
}