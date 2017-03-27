namespace SinoSZMetaDataManager.QueryModelEditor
{
        partial class frmQueryModelEditor
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
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQueryModelEditor));
                        this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
                        this.treeList1 = new DevExpress.XtraTreeList.TreeList();
                        this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
                        this.imageList1 = new System.Windows.Forms.ImageList(this.components);
                        this.panel1 = new System.Windows.Forms.Panel();
                        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // splitterControl1
                        // 
                        this.splitterControl1.Location = new System.Drawing.Point(391, 10);
                        this.splitterControl1.Name = "splitterControl1";
                        this.splitterControl1.Size = new System.Drawing.Size(6, 540);
                        this.splitterControl1.TabIndex = 4;
                        this.splitterControl1.TabStop = false;
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
                        this.treeList1.Location = new System.Drawing.Point(10, 10);
                        this.treeList1.Name = "treeList1";
                        this.treeList1.OptionsBehavior.AllowExpandOnDblClick = false;
                        this.treeList1.OptionsBehavior.Editable = false;
                        this.treeList1.OptionsView.ShowColumns = false;
                        this.treeList1.OptionsView.ShowHorzLines = false;
                        this.treeList1.OptionsView.ShowVertLines = false;
                        this.treeList1.SelectImageList = this.imageList1;
                        this.treeList1.Size = new System.Drawing.Size(381, 540);
                        this.treeList1.TabIndex = 3;
                        this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
                        this.treeList1.BeforeExpand += new DevExpress.XtraTreeList.BeforeExpandEventHandler(this.treeList1_BeforeExpand);
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
                        // 
                        // panel1
                        // 
                        this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.panel1.Location = new System.Drawing.Point(397, 10);
                        this.panel1.Name = "panel1";
                        this.panel1.Size = new System.Drawing.Size(513, 540);
                        this.panel1.TabIndex = 5;
                        // 
                        // frmQueryModelEditor
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(920, 560);
                        this.Controls.Add(this.panel1);
                        this.Controls.Add(this.splitterControl1);
                        this.Controls.Add(this.treeList1);
                        this.Name = "frmQueryModelEditor";
                        this.Padding = new System.Windows.Forms.Padding(10);
                        this.Text = "frmQueryModelEditor";
                        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.SplitterControl splitterControl1;
                private DevExpress.XtraTreeList.TreeList treeList1;
                private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
                private System.Windows.Forms.ImageList imageList1;
                private System.Windows.Forms.Panel panel1;
        }
}