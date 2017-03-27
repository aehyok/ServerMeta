namespace SinoSZMetaDataManager
{
        partial class frmGuideLineManager
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
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGuideLineManager));
                        this.panel1 = new System.Windows.Forms.Panel();
                        this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
                        this.imageList1 = new System.Windows.Forms.ImageList(this.components);
                        this.treeList1 = new DevExpress.XtraTreeList.TreeList();
                        this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
                        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // panel1
                        // 
                        this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.panel1.Location = new System.Drawing.Point(395, 10);
                        this.panel1.Name = "panel1";
                        this.panel1.Size = new System.Drawing.Size(426, 417);
                        this.panel1.TabIndex = 5;
                        // 
                        // splitterControl1
                        // 
                        this.splitterControl1.Location = new System.Drawing.Point(391, 10);
                        this.splitterControl1.Name = "splitterControl1";
                        this.splitterControl1.Size = new System.Drawing.Size(4, 417);
                        this.splitterControl1.TabIndex = 4;
                        this.splitterControl1.TabStop = false;
                        // 
                        // imageList1
                        // 
                        this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
                        this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
                        this.imageList1.Images.SetKeyName(0, "title.ico");
                        this.imageList1.Images.SetKeyName(1, "y16.ico");
                        this.imageList1.Images.SetKeyName(2, "y1.ico");
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
                        this.treeList1.OptionsBehavior.Editable = false;
                        this.treeList1.OptionsView.ShowColumns = false;
                        this.treeList1.OptionsView.ShowHorzLines = false;
                        this.treeList1.OptionsView.ShowVertLines = false;
                        this.treeList1.SelectImageList = this.imageList1;
                        this.treeList1.Size = new System.Drawing.Size(381, 417);
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
                        // frmGuideLineManager
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(831, 437);
                        this.Controls.Add(this.panel1);
                        this.Controls.Add(this.splitterControl1);
                        this.Controls.Add(this.treeList1);
                        this.Name = "frmGuideLineManager";
                        this.Padding = new System.Windows.Forms.Padding(10);
                        this.Text = "元数据-指标定义";
                        this.Load += new System.EventHandler(this.frmGuideLineManager_Load);
                        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.Panel panel1;
                private DevExpress.XtraEditors.SplitterControl splitterControl1;
                private System.Windows.Forms.ImageList imageList1;
                private DevExpress.XtraTreeList.TreeList treeList1;
                private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        }
}