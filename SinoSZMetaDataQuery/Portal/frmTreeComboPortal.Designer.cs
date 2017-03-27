namespace SinoSZMetaDataQuery.Portal
{
        partial class frmTreeComboPortal
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
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTreeComboPortal));
                        this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
                        this.treeList1 = new DevExpress.XtraTreeList.TreeList();
                        this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
                        this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                        this.imageList1 = new System.Windows.Forms.ImageList(this.components);
                        ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
                        this.splitContainerControl1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // splitContainerControl1
                        // 
                        this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
                        this.splitContainerControl1.Name = "splitContainerControl1";
                        this.splitContainerControl1.Panel1.Controls.Add(this.treeList1);
                        this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
                        this.splitContainerControl1.Panel1.Text = "Panel1";
                        this.splitContainerControl1.Panel2.Text = "Panel2";
                        this.splitContainerControl1.Size = new System.Drawing.Size(866, 538);
                        this.splitContainerControl1.SplitterPosition = 226;
                        this.splitContainerControl1.TabIndex = 0;
                        this.splitContainerControl1.Text = "splitContainerControl1";
                        // 
                        // treeList1
                        // 
                        this.treeList1.Appearance.FocusedCell.BackColor = System.Drawing.Color.Blue;
                        this.treeList1.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Blue;
                        this.treeList1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
                        this.treeList1.Appearance.FocusedCell.Options.UseBackColor = true;
                        this.treeList1.Appearance.FocusedCell.Options.UseForeColor = true;
                        this.treeList1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Blue;
                        this.treeList1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Blue;
                        this.treeList1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
                        this.treeList1.Appearance.FocusedRow.Options.UseBackColor = true;
                        this.treeList1.Appearance.FocusedRow.Options.UseForeColor = true;
                        this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
                        this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.treeList1.Location = new System.Drawing.Point(5, 4);
                        this.treeList1.Name = "treeList1";
                        this.treeList1.OptionsView.ShowHorzLines = false;
                        this.treeList1.OptionsView.ShowVertLines = false;
                        this.treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
                        this.treeList1.SelectImageList = this.imageList1;
                        this.treeList1.Size = new System.Drawing.Size(156, 418);
                        this.treeList1.TabIndex = 0;
                        this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
                        // 
                        // treeListColumn1
                        // 
                        this.treeListColumn1.Caption = "统计项目列表";
                        this.treeListColumn1.FieldName = "treeListColumn1";
                        this.treeListColumn1.MinWidth = 27;
                        this.treeListColumn1.Name = "treeListColumn1";
                        this.treeListColumn1.OptionsColumn.AllowEdit = false;
                        this.treeListColumn1.OptionsColumn.AllowSort = false;
                        this.treeListColumn1.OptionsColumn.ReadOnly = true;
                        this.treeListColumn1.Visible = true;
                        this.treeListColumn1.VisibleIndex = 0;
                        this.treeListColumn1.Width = 162;
                        // 
                        // repositoryItemCheckEdit1
                        // 
                        this.repositoryItemCheckEdit1.AutoHeight = false;
                        this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
                        // 
                        // imageList1
                        // 
                        this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
                        this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
                        this.imageList1.Images.SetKeyName(0, "y1.ico");
                        this.imageList1.Images.SetKeyName(1, "title.ico");
                        this.imageList1.Images.SetKeyName(2, "childPack2.ico");
                        // 
                        // frmTreeComboPortal
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(866, 538);
                        this.Controls.Add(this.splitContainerControl1);
                        this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
                        this.Name = "frmTreeComboPortal";
                        this.Text = "frmTreeComboPortal";
                        this.Load += new System.EventHandler(this.frmTreeComboPortal_Load);
                        ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
                        this.splitContainerControl1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
                private DevExpress.XtraTreeList.TreeList treeList1;
                private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
                private System.Windows.Forms.ImageList imageList1;
                private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        }
}