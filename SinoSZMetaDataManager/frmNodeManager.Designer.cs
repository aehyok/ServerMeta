namespace SinoSZMetaDataManager
{
        partial class frmNodeManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNodeManager));
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList1
            // 
            this.treeList1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.treeList1.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.treeList1.Appearance.FocusedCell.BorderColor = System.Drawing.Color.Blue;
            this.treeList1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treeList1.Appearance.FocusedCell.Options.UseBorderColor = true;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treeList1.ColumnsImageList = this.imageList1;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeList1.Location = new System.Drawing.Point(13, 15);
            this.treeList1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.AllowExpandOnDblClick = false;
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsPrint.UsePrintStyles = true;
            this.treeList1.OptionsView.ShowColumns = false;
            this.treeList1.OptionsView.ShowHorzLines = false;
            this.treeList1.OptionsView.ShowVertLines = false;
            this.treeList1.SelectImageList = this.imageList1;
            this.treeList1.Size = new System.Drawing.Size(508, 696);
            this.treeList1.TabIndex = 0;
            this.treeList1.BeforeExpand += new DevExpress.XtraTreeList.BeforeExpandEventHandler(this.treeList1_BeforeExpand);
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "treeListColumn1";
            this.treeListColumn1.FieldName = "DisplayTitle";
            this.treeListColumn1.MinWidth = 95;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 79;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "y1.ico");
            this.imageList1.Images.SetKeyName(1, "childPack.ico");
            this.imageList1.Images.SetKeyName(2, "title.ico");
            this.imageList1.Images.SetKeyName(3, "box.ico");
            this.imageList1.Images.SetKeyName(4, "a16.ico");
            this.imageList1.Images.SetKeyName(5, "slicon.ico");
            this.imageList1.Images.SetKeyName(6, "lock_go.png");
            this.imageList1.Images.SetKeyName(7, "key.png");
            this.imageList1.Images.SetKeyName(8, "table_merge_cells_16x16.gif");
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(521, 15);
            this.splitterControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 696);
            this.splitterControl1.TabIndex = 1;
            this.splitterControl1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(526, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 696);
            this.panel1.TabIndex = 2;
            // 
            // frmNodeManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 726);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.treeList1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmNodeManager";
            this.Padding = new System.Windows.Forms.Padding(13, 15, 13, 15);
            this.Text = "元数据-节点配置";
            this.Load += new System.EventHandler(this.frmNodeManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraTreeList.TreeList treeList1;
                private DevExpress.XtraEditors.SplitterControl splitterControl1;
                private System.Windows.Forms.Panel panel1;
                private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
                private System.Windows.Forms.ImageList imageList1;

        }
}