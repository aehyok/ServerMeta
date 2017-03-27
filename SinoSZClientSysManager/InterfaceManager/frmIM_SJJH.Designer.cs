namespace SinoSZClientSysManager.InterfaceManager
{
        partial class frmIM_SJJH
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIM_SJJH));
			this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
			this.treeList1 = new DevExpress.XtraTreeList.TreeList();
			this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.objectImageList = new System.Windows.Forms.ImageList(this.components);
			this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
			this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
			this.imuC_SJJH_InterfaceInfo1 = new SinoSZClientSysManager.InterfaceManager.IMUC_SJJH_InterfaceInfo();
			this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
			this.imuC_SJJH_DataDefine1 = new SinoSZClientSysManager.InterfaceManager.IMUC_SJJH_DataDefine();
			this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
			this.imuC_SJJH_AccessLog1 = new SinoSZClientSysManager.InterfaceManager.IMUC_SJJH_AccessLog();
			this.panelWait = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
			this.splitContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
			this.xtraTabControl1.SuspendLayout();
			this.xtraTabPage3.SuspendLayout();
			this.xtraTabPage1.SuspendLayout();
			this.xtraTabPage2.SuspendLayout();
			this.panelWait.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainerControl1
			// 
			this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl1.Location = new System.Drawing.Point(9, 9);
			this.splitContainerControl1.Name = "splitContainerControl1";
			this.splitContainerControl1.Panel1.Controls.Add(this.treeList1);
			this.splitContainerControl1.Panel1.Text = "Panel1";
			this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControl1);
			this.splitContainerControl1.Panel2.Text = "Panel2";
			this.splitContainerControl1.Size = new System.Drawing.Size(905, 508);
			this.splitContainerControl1.SplitterPosition = 470;
			this.splitContainerControl1.TabIndex = 0;
			this.splitContainerControl1.Text = "splitContainerControl1";
			// 
			// treeList1
			// 
			this.treeList1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.treeList1.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.treeList1.Appearance.FocusedCell.BorderColor = System.Drawing.Color.Blue;
			this.treeList1.Appearance.FocusedCell.Options.UseBackColor = true;
			this.treeList1.Appearance.FocusedCell.Options.UseBorderColor = true;
			this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
			this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeList1.Location = new System.Drawing.Point(0, 0);
			this.treeList1.Name = "treeList1";
			this.treeList1.OptionsBehavior.Editable = false;
			this.treeList1.OptionsView.ShowColumns = false;
			this.treeList1.SelectImageList = this.objectImageList;
			this.treeList1.Size = new System.Drawing.Size(466, 504);
			this.treeList1.TabIndex = 11;
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
			// treeListColumn2
			// 
			this.treeListColumn2.Caption = "treeListColumn2";
			this.treeListColumn2.FieldName = "Selected";
			this.treeListColumn2.Name = "treeListColumn2";
			// 
			// objectImageList
			// 
			this.objectImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("objectImageList.ImageStream")));
			this.objectImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.objectImageList.Images.SetKeyName(0, "001_21.ico");
			this.objectImageList.Images.SetKeyName(1, "001_20.ico");
			this.objectImageList.Images.SetKeyName(2, "001_54.ico");
			// 
			// xtraTabControl1
			// 
			this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
			this.xtraTabControl1.Name = "xtraTabControl1";
			this.xtraTabControl1.SelectedTabPage = this.xtraTabPage3;
			this.xtraTabControl1.Size = new System.Drawing.Size(425, 504);
			this.xtraTabControl1.TabIndex = 0;
			this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage3,
            this.xtraTabPage1,
            this.xtraTabPage2});
			this.xtraTabControl1.Text = "xtraTabControl1";
			// 
			// xtraTabPage3
			// 
			this.xtraTabPage3.Controls.Add(this.imuC_SJJH_InterfaceInfo1);
			this.xtraTabPage3.Name = "xtraTabPage3";
			this.xtraTabPage3.Size = new System.Drawing.Size(416, 472);
			this.xtraTabPage3.Text = "接口说明";
			// 
			// imuC_SJJH_InterfaceInfo1
			// 
			this.imuC_SJJH_InterfaceInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imuC_SJJH_InterfaceInfo1.Location = new System.Drawing.Point(0, 0);
			this.imuC_SJJH_InterfaceInfo1.Name = "imuC_SJJH_InterfaceInfo1";
			this.imuC_SJJH_InterfaceInfo1.Size = new System.Drawing.Size(416, 472);
			this.imuC_SJJH_InterfaceInfo1.TabIndex = 0;
			// 
			// xtraTabPage1
			// 
			this.xtraTabPage1.Controls.Add(this.imuC_SJJH_DataDefine1);
			this.xtraTabPage1.Name = "xtraTabPage1";
			this.xtraTabPage1.Size = new System.Drawing.Size(416, 472);
			this.xtraTabPage1.Text = "数据定义";
			// 
			// imuC_SJJH_DataDefine1
			// 
			this.imuC_SJJH_DataDefine1.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.imuC_SJJH_DataDefine1.Appearance.Options.UseBackColor = true;
			this.imuC_SJJH_DataDefine1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imuC_SJJH_DataDefine1.Location = new System.Drawing.Point(0, 0);
			this.imuC_SJJH_DataDefine1.Name = "imuC_SJJH_DataDefine1";
			this.imuC_SJJH_DataDefine1.Size = new System.Drawing.Size(416, 472);
			this.imuC_SJJH_DataDefine1.TabIndex = 0;
			// 
			// xtraTabPage2
			// 
			this.xtraTabPage2.Controls.Add(this.imuC_SJJH_AccessLog1);
			this.xtraTabPage2.Name = "xtraTabPage2";
			this.xtraTabPage2.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.xtraTabPage2.Size = new System.Drawing.Size(568, 514);
			this.xtraTabPage2.Text = "访问日志";
			// 
			// imuC_SJJH_AccessLog1
			// 
			this.imuC_SJJH_AccessLog1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imuC_SJJH_AccessLog1.Location = new System.Drawing.Point(3, 5);
			this.imuC_SJJH_AccessLog1.Name = "imuC_SJJH_AccessLog1";
			this.imuC_SJJH_AccessLog1.Size = new System.Drawing.Size(562, 504);
			this.imuC_SJJH_AccessLog1.TabIndex = 0;
			// 
			// panelWait
			// 
			this.panelWait.Controls.Add(this.label2);
			this.panelWait.Controls.Add(this.marqueeProgressBarControl1);
			this.panelWait.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelWait.Location = new System.Drawing.Point(9, 517);
			this.panelWait.Name = "panelWait";
			this.panelWait.Size = new System.Drawing.Size(905, 20);
			this.panelWait.TabIndex = 11;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Location = new System.Drawing.Point(100, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(805, 20);
			this.label2.TabIndex = 1;
			this.label2.Text = "正在处理数据，请稍候 ...";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// marqueeProgressBarControl1
			// 
			this.marqueeProgressBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
			this.marqueeProgressBarControl1.EditValue = 0;
			this.marqueeProgressBarControl1.Location = new System.Drawing.Point(0, 0);
			this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
			this.marqueeProgressBarControl1.Size = new System.Drawing.Size(100, 20);
			this.marqueeProgressBarControl1.TabIndex = 0;
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			// 
			// frmIM_SJJH
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(923, 546);
			this.Controls.Add(this.splitContainerControl1);
			this.Controls.Add(this.panelWait);
			this.Name = "frmIM_SJJH";
			this.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
			this.Text = "frmIM_SJJH";
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
			this.splitContainerControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
			this.xtraTabControl1.ResumeLayout(false);
			this.xtraTabPage3.ResumeLayout(false);
			this.xtraTabPage1.ResumeLayout(false);
			this.xtraTabPage2.ResumeLayout(false);
			this.panelWait.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
			this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
                private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
                private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
                private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
                private System.Windows.Forms.Panel panelWait;
                private System.Windows.Forms.Label label2;
                private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
                private System.ComponentModel.BackgroundWorker backgroundWorker1;
                private IMUC_SJJH_DataDefine imuC_SJJH_DataDefine1;
                private IMUC_SJJH_AccessLog imuC_SJJH_AccessLog1;
                private DevExpress.XtraTreeList.TreeList treeList1;
                private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
                private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
                private System.Windows.Forms.ImageList objectImageList;
                private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
                private IMUC_SJJH_InterfaceInfo imuC_SJJH_InterfaceInfo1;
        }
}