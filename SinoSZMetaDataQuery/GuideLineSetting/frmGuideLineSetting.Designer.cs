namespace SinoSZMetaDataQuery.GuideLineSetting
{
        partial class frmGuideLineSetting
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
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGuideLineSetting));
                        this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
                        this.objectImageList = new System.Windows.Forms.ImageList(this.components);
                        this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
                        this.treeList1 = new DevExpress.XtraTreeList.TreeList();
                        this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
                        this.sinoSZUC_GuideLineQueryInput1 = new SinoSZMetaDataQuery.GuideLineQuery.SinoSZUC_GuideLineQueryInput();
                        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
                        this.splitContainerControl1.SuspendLayout();
                        this.SuspendLayout();
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
                        // treeListColumn3
                        // 
                        this.treeListColumn3.Caption = "treeListColumn3";
                        this.treeListColumn3.FieldName = "State";
                        this.treeListColumn3.Name = "treeListColumn3";
                        this.treeListColumn3.OptionsColumn.FixedWidth = true;
                        this.treeListColumn3.OptionsColumn.ReadOnly = true;
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
                        this.treeList1.Location = new System.Drawing.Point(5, 4);
                        this.treeList1.Name = "treeList1";
                        this.treeList1.SelectImageList = this.objectImageList;
                        this.treeList1.Size = new System.Drawing.Size(379, 567);
                        this.treeList1.TabIndex = 2;
                        this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
                        // 
                        // splitContainerControl1
                        // 
                        this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.splitContainerControl1.Location = new System.Drawing.Point(5, 5);
                        this.splitContainerControl1.Name = "splitContainerControl1";
                        this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                        this.splitContainerControl1.Panel1.Controls.Add(this.treeList1);
                        this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(5);
                        this.splitContainerControl1.Panel1.Text = "Panel1";
                        this.splitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                        this.splitContainerControl1.Panel2.Controls.Add(this.sinoSZUC_GuideLineQueryInput1);
                        this.splitContainerControl1.Panel2.Padding = new System.Windows.Forms.Padding(5);
                        this.splitContainerControl1.Panel2.Text = "Panel2";
                        this.splitContainerControl1.Size = new System.Drawing.Size(1045, 576);
                        this.splitContainerControl1.SplitterPosition = 389;
                        this.splitContainerControl1.TabIndex = 2;
                        this.splitContainerControl1.Text = "splitContainerControl1";
                        // 
                        // sinoSZUC_GuideLineQueryInput1
                        // 
                        this.sinoSZUC_GuideLineQueryInput1.DisplayTitle = "参数设置";
                        this.sinoSZUC_GuideLineQueryInput1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.sinoSZUC_GuideLineQueryInput1.Location = new System.Drawing.Point(5, 4);
                        this.sinoSZUC_GuideLineQueryInput1.Name = "sinoSZUC_GuideLineQueryInput1";
                        this.sinoSZUC_GuideLineQueryInput1.Size = new System.Drawing.Size(640, 567);
                        this.sinoSZUC_GuideLineQueryInput1.TabIndex = 0;
                        // 
                        // frmGuideLineSetting
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(1055, 586);
                        this.Controls.Add(this.splitContainerControl1);
                        this.Name = "frmGuideLineSetting";
                        this.Padding = new System.Windows.Forms.Padding(5);
                        this.Text = "frmGuideLineSetting";
                        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
                        this.splitContainerControl1.ResumeLayout(false);
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
                private System.Windows.Forms.ImageList objectImageList;
                private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
                private DevExpress.XtraTreeList.TreeList treeList1;
                private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
                private SinoSZMetaDataQuery.GuideLineQuery.SinoSZUC_GuideLineQueryInput sinoSZUC_GuideLineQueryInput1;

        }
}