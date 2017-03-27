namespace SinoSZClientBase.Organize
{
        partial class SinoUC_OrgTree
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
                        this.components = new System.ComponentModel.Container();
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SinoUC_OrgTree));
                        this.treeList1 = new DevExpress.XtraTreeList.TreeList();
                        this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
                        this.imageList1 = new System.Windows.Forms.ImageList(this.components);
                        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // treeList1
                        // 
                        this.treeList1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                        this.treeList1.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
                        this.treeList1.Appearance.FocusedCell.BorderColor = System.Drawing.Color.Blue;
                        this.treeList1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
                        this.treeList1.Appearance.FocusedCell.Options.UseBackColor = true;
                        this.treeList1.Appearance.FocusedCell.Options.UseBorderColor = true;
                        this.treeList1.Appearance.FocusedCell.Options.UseForeColor = true;
                        this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
                        this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.treeList1.Location = new System.Drawing.Point(0, 0);
                        this.treeList1.Name = "treeList1";
                        this.treeList1.OptionsBehavior.AllowExpandOnDblClick = false;
                        this.treeList1.OptionsView.ShowColumns = false;
                        this.treeList1.SelectImageList = this.imageList1;
                        this.treeList1.Size = new System.Drawing.Size(359, 557);
                        this.treeList1.TabIndex = 0;
                        this.treeList1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseDoubleClick);
                        this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
                        this.treeList1.BeforeExpand += new DevExpress.XtraTreeList.BeforeExpandEventHandler(this.treeList1_BeforeExpand);
                        // 
                        // treeListColumn1
                        // 
                        this.treeListColumn1.Caption = "单位ID";
                        this.treeListColumn1.FieldName = "ID";
                        this.treeListColumn1.MinWidth = 27;
                        this.treeListColumn1.Name = "treeListColumn1";
                        this.treeListColumn1.OptionsColumn.AllowEdit = false;
                        this.treeListColumn1.OptionsColumn.ReadOnly = true;
                        this.treeListColumn1.Visible = true;
                        this.treeListColumn1.VisibleIndex = 0;
                        this.treeListColumn1.Width = 101;
                        // 
                        // imageList1
                        // 
                        this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
                        this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
                        this.imageList1.Images.SetKeyName(0, "y1.ico");
                        this.imageList1.Images.SetKeyName(1, "childPack2.ico");
                        // 
                        // SinoUC_OrgTree
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.treeList1);
                        this.Name = "SinoUC_OrgTree";
                        this.Size = new System.Drawing.Size(359, 557);
                        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                protected DevExpress.XtraTreeList.TreeList treeList1;
                protected System.Windows.Forms.ImageList imageList1;
                protected DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        }
}
