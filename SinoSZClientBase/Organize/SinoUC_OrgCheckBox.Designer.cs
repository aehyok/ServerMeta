namespace SinoSZClientBase.Organize
{
        partial class SinoUC_OrgCheckBox
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
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SinoUC_OrgCheckBox));
                        this.treeList1 = new DevExpress.XtraTreeList.TreeList();
                        this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
                        this.imageList1 = new System.Windows.Forms.ImageList(this.components);
                        this.stateImageList = new System.Windows.Forms.ImageList(this.components);
                        this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
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
            this.treeListColumn1,
            this.treeListColumn2});
                        this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.treeList1.Location = new System.Drawing.Point(0, 0);
                        this.treeList1.Name = "treeList1";
                        this.treeList1.OptionsView.ShowColumns = false;
                        this.treeList1.SelectImageList = this.imageList1;
                        this.treeList1.Size = new System.Drawing.Size(474, 665);
                        this.treeList1.StateImageList = this.stateImageList;
                        this.treeList1.TabIndex = 1;
                        this.treeList1.StateImageClick += new DevExpress.XtraTreeList.NodeClickEventHandler(this.treeList1_StateImageClick);
                        this.treeList1.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.treeList1_GetStateImage);
                        this.treeList1.BeforeExpand += new DevExpress.XtraTreeList.BeforeExpandEventHandler(this.treeList1_BeforeExpand);
                        // 
                        // treeListColumn1
                        // 
                        this.treeListColumn1.Caption = "µ¥Î»ID";
                        this.treeListColumn1.FieldName = "ID";
                        this.treeListColumn1.MinWidth = 43;
                        this.treeListColumn1.Name = "treeListColumn1";
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
                        // stateImageList
                        // 
                        this.stateImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("stateImageList.ImageStream")));
                        this.stateImageList.TransparentColor = System.Drawing.Color.Magenta;
                        this.stateImageList.Images.SetKeyName(0, "check2.ico");
                        this.stateImageList.Images.SetKeyName(1, "check11.ico");
                        // 
                        // treeListColumn2
                        // 
                        this.treeListColumn2.Caption = "treeListColumn2";
                        this.treeListColumn2.FieldName = "treeListColumn2";
                        this.treeListColumn2.Name = "treeListColumn2";
                        // 
                        // SinoUC_OrgCheckBox
                        // 
                        this.Appearance.BackColor = System.Drawing.Color.Transparent;
                        this.Appearance.Options.UseBackColor = true;
                        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.treeList1);
                        this.Name = "SinoUC_OrgCheckBox";
                        this.Size = new System.Drawing.Size(474, 665);
                        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                protected DevExpress.XtraTreeList.TreeList treeList1;
                protected DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
                protected System.Windows.Forms.ImageList imageList1;
                private System.Windows.Forms.ImageList stateImageList;
                private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        }
}
