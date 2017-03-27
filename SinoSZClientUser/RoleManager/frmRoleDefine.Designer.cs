namespace SinoSZClientUser.RoleManager
{
        partial class frmRoleDefine
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
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRoleDefine));
                        this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
                        this.treeList1 = new DevExpress.XtraTreeList.TreeList();
                        this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
                        this.imageList1 = new System.Windows.Forms.ImageList(this.components);
                        this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
                        ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
                        this.splitContainerControl1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // splitContainerControl1
                        // 
                        this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
                        this.splitContainerControl1.Name = "splitContainerControl1";
                        this.splitContainerControl1.Panel1.Controls.Add(this.treeList1);
                        this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(5);
                        this.splitContainerControl1.Panel1.Text = "Panel1";
                        this.splitContainerControl1.Panel2.Padding = new System.Windows.Forms.Padding(5);
                        this.splitContainerControl1.Panel2.Text = "Panel2";
                        this.splitContainerControl1.Size = new System.Drawing.Size(884, 552);
                        this.splitContainerControl1.SplitterPosition = 356;
                        this.splitContainerControl1.TabIndex = 0;
                        this.splitContainerControl1.Text = "splitContainerControl1";
                        // 
                        // treeList1
                        // 
                        this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
                        this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.treeList1.Location = new System.Drawing.Point(5, 4);
                        this.treeList1.Name = "treeList1";
                        this.treeList1.OptionsSelection.EnableAppearanceFocusedCell = false;
                        this.treeList1.SelectImageList = this.imageList1;
                        this.treeList1.Size = new System.Drawing.Size(342, 539);
                        this.treeList1.TabIndex = 0;
                        this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
                        // 
                        // treeListColumn1
                        // 
                        this.treeListColumn1.Caption = "角色列表";
                        this.treeListColumn1.FieldName = "角色列表";
                        this.treeListColumn1.MinWidth = 27;
                        this.treeListColumn1.Name = "treeListColumn1";
                        this.treeListColumn1.OptionsColumn.AllowEdit = false;
                        this.treeListColumn1.OptionsColumn.ReadOnly = true;
                        this.treeListColumn1.Visible = true;
                        this.treeListColumn1.VisibleIndex = 0;
                        // 
                        // imageList1
                        // 
                        this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
                        this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
                        this.imageList1.Images.SetKeyName(0, "user2_16x16.gif");
                        // 
                        // layoutControlItem1
                        // 
                        this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
                        this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
                        this.layoutControlItem1.Name = "layoutControlItem1";
                        this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
                        this.layoutControlItem1.Size = new System.Drawing.Size(506, 481);
                        this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
                        this.layoutControlItem1.Text = "layoutControlItem1";
                        this.layoutControlItem1.TextSize = new System.Drawing.Size(105, 20);
                        // 
                        // frmRoleDefine
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(884, 552);
                        this.Controls.Add(this.splitContainerControl1);
                        this.Name = "frmRoleDefine";
                        this.Text = "角色管理";
                        this.Load += new System.EventHandler(this.frmRoleDefine_Load);
                        ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
                        this.splitContainerControl1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
                private DevExpress.XtraTreeList.TreeList treeList1;
                private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
                private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
                private System.Windows.Forms.ImageList imageList1;
        }
}