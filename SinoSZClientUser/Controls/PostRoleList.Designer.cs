namespace SinoSZClientUser.Controls
{
        partial class PostRoleList
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
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostRoleList));
                        this.stateImageList = new System.Windows.Forms.ImageList(this.components);
                        this.imageList1 = new System.Windows.Forms.ImageList(this.components);
                        this.treeList1 = new DevExpress.XtraTreeList.TreeList();
                        this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
                        this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
                        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // stateImageList
                        // 
                        this.stateImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("stateImageList.ImageStream")));
                        this.stateImageList.TransparentColor = System.Drawing.Color.Magenta;
                        this.stateImageList.Images.SetKeyName(0, "check2.ico");
                        this.stateImageList.Images.SetKeyName(1, "check11.ico");
                        // 
                        // imageList1
                        // 
                        this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
                        this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
                        this.imageList1.Images.SetKeyName(0, "user2_16x16.gif");
                        // 
                        // treeList1
                        // 
                        this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
                        this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.treeList1.Location = new System.Drawing.Point(0, 0);
                        this.treeList1.Name = "treeList1";
                        this.treeList1.OptionsSelection.EnableAppearanceFocusedCell = false;
                        this.treeList1.SelectImageList = this.imageList1;
                        this.treeList1.Size = new System.Drawing.Size(720, 295);
                        this.treeList1.StateImageList = this.stateImageList;
                        this.treeList1.TabIndex = 2;
                        this.treeList1.StateImageClick += new DevExpress.XtraTreeList.NodeClickEventHandler(this.treeList1_StateImageClick);
                        this.treeList1.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.treeList1_GetStateImage);
                        // 
                        // treeListColumn1
                        // 
                        this.treeListColumn1.Caption = "角色列表";
                        this.treeListColumn1.FieldName = "角色列表";
                        this.treeListColumn1.MinWidth = 43;
                        this.treeListColumn1.Name = "treeListColumn1";
                        this.treeListColumn1.OptionsColumn.AllowEdit = false;
                        this.treeListColumn1.OptionsColumn.ReadOnly = true;
                        this.treeListColumn1.Visible = true;
                        this.treeListColumn1.VisibleIndex = 0;
                        // 
                        // treeListColumn2
                        // 
                        this.treeListColumn2.Caption = "treeListColumn2";
                        this.treeListColumn2.FieldName = "IsChecked";
                        this.treeListColumn2.Name = "treeListColumn2";
                        // 
                        // PostRoleList
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.BackColor = System.Drawing.Color.Transparent;
                        this.Controls.Add(this.treeList1);
                        this.Name = "PostRoleList";
                        this.Size = new System.Drawing.Size(720, 295);
                        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.ImageList stateImageList;
                private System.Windows.Forms.ImageList imageList1;
                private DevExpress.XtraTreeList.TreeList treeList1;
                private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
                private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;

        }
}
