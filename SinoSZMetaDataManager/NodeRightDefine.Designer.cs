namespace SinoSZMetaDataManager
{
        partial class NodeRightDefine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NodeRightDefine));
            this.pWait = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.pBarLoad = new DevExpress.XtraEditors.ProgressBarControl();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pWait)).BeginInit();
            this.pWait.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBarLoad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.SuspendLayout();
            // 
            // pWait
            // 
            this.pWait.Controls.Add(this.label1);
            this.pWait.Controls.Add(this.pBarLoad);
            this.pWait.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pWait.Location = new System.Drawing.Point(0, 726);
            this.pWait.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pWait.Name = "pWait";
            this.pWait.Size = new System.Drawing.Size(1069, 33);
            this.pWait.TabIndex = 5;
            this.pWait.Visible = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(229, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(838, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = " 正在查询详细信息 ...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pBarLoad
            // 
            this.pBarLoad.Dock = System.Windows.Forms.DockStyle.Left;
            this.pBarLoad.Location = new System.Drawing.Point(2, 2);
            this.pBarLoad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pBarLoad.Name = "pBarLoad";
            this.pBarLoad.Properties.ShowTitle = true;
            this.pBarLoad.Size = new System.Drawing.Size(227, 29);
            this.pBarLoad.TabIndex = 1;
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsPrint.UsePrintStyles = true;
            this.treeList1.SelectImageList = this.imageList1;
            this.treeList1.Size = new System.Drawing.Size(1069, 726);
            this.treeList1.TabIndex = 6;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "系统权限树";
            this.treeListColumn1.FieldName = "Column1";
            this.treeListColumn1.MinWidth = 33;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.ReadOnly = true;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "title.ico");
            this.imageList1.Images.SetKeyName(1, "childPack.ico");
            this.imageList1.Images.SetKeyName(2, "front.ico");
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // NodeRightDefine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.pWait);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "NodeRightDefine";
            this.Size = new System.Drawing.Size(1069, 759);
            ((System.ComponentModel.ISupportInitialize)(this.pWait)).EndInit();
            this.pWait.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBarLoad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.PanelControl pWait;
                private System.Windows.Forms.Label label1;
                private DevExpress.XtraEditors.ProgressBarControl pBarLoad;
                private DevExpress.XtraTreeList.TreeList treeList1;
                private System.Windows.Forms.Timer timer1;
                private System.ComponentModel.BackgroundWorker backgroundWorker1;
                private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
                private System.Windows.Forms.ImageList imageList1;
                private System.ComponentModel.BackgroundWorker backgroundWorker2;
        }
}
