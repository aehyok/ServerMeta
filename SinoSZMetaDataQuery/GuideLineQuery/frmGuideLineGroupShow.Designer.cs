namespace SinoSZMetaDataQuery.GuideLineQuery
{
        partial class frmGuideLineGroupShow
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
                        this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
                        this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
                        this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
                        this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
                        this.sinoSZUC_GuideLineQueryResult1 = new SinoSZMetaDataQuery.GuideLineQuery.SinoSZUC_GuideLineQueryResult();
                        this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
                        this.sinoSZUC_GuideLineDynamicInput1 = new SinoSZMetaDataQuery.GuideLineQuery.SinoSZUC_GuideLineDynamicInput();
                        ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
                        this.splitContainerControl1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
                        this.xtraTabControl1.SuspendLayout();
                        this.xtraTabPage1.SuspendLayout();
                        this.xtraTabPage2.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // splitContainerControl1
                        // 
                        this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
                        this.splitContainerControl1.Name = "splitContainerControl1";
                        this.splitContainerControl1.Panel1.Controls.Add(this.navBarControl1);
                        this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(10, 10, 5, 10);
                        this.splitContainerControl1.Panel1.Text = "Panel1";
                        this.splitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                        this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControl1);
                        this.splitContainerControl1.Panel2.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
                        this.splitContainerControl1.Panel2.Text = "Panel2";
                        this.splitContainerControl1.Size = new System.Drawing.Size(876, 530);
                        this.splitContainerControl1.SplitterPosition = 170;
                        this.splitContainerControl1.TabIndex = 0;
                        this.splitContainerControl1.Text = "splitContainerControl1";
                        // 
                        // navBarControl1
                        // 
                        this.navBarControl1.ActiveGroup = null;
                        this.navBarControl1.AllowSelectedLink = true;
                        this.navBarControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                        this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.navBarControl1.EachGroupHasSelectedLink = true;
                        this.navBarControl1.Location = new System.Drawing.Point(10, 9);
                        this.navBarControl1.Name = "navBarControl1";
                        this.navBarControl1.OptionsNavPane.ExpandedWidth = 217;
                        this.navBarControl1.Size = new System.Drawing.Size(151, 507);
                        this.navBarControl1.SkinExplorerBarViewScrollStyle = DevExpress.XtraNavBar.SkinExplorerBarViewScrollStyle.ScrollBar;
                        this.navBarControl1.TabIndex = 0;
                        this.navBarControl1.Text = "navBarControl1";
                        this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.SkinExplorerBarViewInfoRegistrator();
                        this.navBarControl1.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarControl1_LinkClicked);
                        // 
                        // xtraTabControl1
                        // 
                        this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.xtraTabControl1.Location = new System.Drawing.Point(5, 0);
                        this.xtraTabControl1.Name = "xtraTabControl1";
                        this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
                        this.xtraTabControl1.Size = new System.Drawing.Size(690, 530);
                        this.xtraTabControl1.TabIndex = 1;
                        this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
                        // 
                        // xtraTabPage1
                        // 
                        this.xtraTabPage1.Controls.Add(this.sinoSZUC_GuideLineQueryResult1);
                        this.xtraTabPage1.Name = "xtraTabPage1";
                        this.xtraTabPage1.Size = new System.Drawing.Size(681, 498);
                        this.xtraTabPage1.Text = "　　　　　";
                        // 
                        // sinoSZUC_GuideLineQueryResult1
                        // 
                        this.sinoSZUC_GuideLineQueryResult1.CanGrouped = true;
                        this.sinoSZUC_GuideLineQueryResult1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.sinoSZUC_GuideLineQueryResult1.Location = new System.Drawing.Point(0, 0);
                        this.sinoSZUC_GuideLineQueryResult1.Name = "sinoSZUC_GuideLineQueryResult1";
                        this.sinoSZUC_GuideLineQueryResult1.Size = new System.Drawing.Size(681, 498);
                        this.sinoSZUC_GuideLineQueryResult1.TabIndex = 0;
                        this.sinoSZUC_GuideLineQueryResult1.QueryFinished += new System.EventHandler(this.sinoSZUC_GuideLineQueryResult1_QueryFinished);
                        this.sinoSZUC_GuideLineQueryResult1.ShowDetailData += new System.EventHandler(this.sinoSZUC_GuideLineQueryResult1_ShowDetailData);
                        // 
                        // xtraTabPage2
                        // 
                        this.xtraTabPage2.Controls.Add(this.sinoSZUC_GuideLineDynamicInput1);
                        this.xtraTabPage2.Name = "xtraTabPage2";
                        this.xtraTabPage2.Padding = new System.Windows.Forms.Padding(10);
                        this.xtraTabPage2.PageVisible = false;
                        this.xtraTabPage2.Size = new System.Drawing.Size(681, 498);
                        this.xtraTabPage2.Text = "条件参数设置";
                        // 
                        // sinoSZUC_GuideLineDynamicInput1
                        // 
                        this.sinoSZUC_GuideLineDynamicInput1.BackColor = System.Drawing.Color.Transparent;
                        this.sinoSZUC_GuideLineDynamicInput1.Dock = System.Windows.Forms.DockStyle.Top;
                        this.sinoSZUC_GuideLineDynamicInput1.Location = new System.Drawing.Point(10, 10);
                        this.sinoSZUC_GuideLineDynamicInput1.Name = "sinoSZUC_GuideLineDynamicInput1";
                        this.sinoSZUC_GuideLineDynamicInput1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
                        this.sinoSZUC_GuideLineDynamicInput1.Size = new System.Drawing.Size(661, 5);
                        this.sinoSZUC_GuideLineDynamicInput1.TabIndex = 0;
                        // 
                        // frmGuideLineGroupShow
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(876, 530);
                        this.Controls.Add(this.splitContainerControl1);
                        this.Name = "frmGuideLineGroupShow";
                        this.Text = "frmGuideLineGroupShow";
                        ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
                        this.splitContainerControl1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
                        this.xtraTabControl1.ResumeLayout(false);
                        this.xtraTabPage1.ResumeLayout(false);
                        this.xtraTabPage2.ResumeLayout(false);
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
                private DevExpress.XtraNavBar.NavBarControl navBarControl1;
                private SinoSZUC_GuideLineQueryResult sinoSZUC_GuideLineQueryResult1;
                private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
                private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
                private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
                private SinoSZUC_GuideLineDynamicInput sinoSZUC_GuideLineDynamicInput1;
        }
}