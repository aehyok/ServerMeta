namespace SinoSZClientUser.PostManager
{
        partial class frmPostDefine
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
                        this.sinoUC_OrgTree1 = new SinoSZClientBase.Organize.SinoUC_OrgTree();
                        this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
                        this.postList1 = new SinoSZClientUser.Controls.PostList();
                        this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
                        this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
                        this.postRoleList1 = new SinoSZClientUser.Controls.PostRoleList();
                        this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
                        this.postUserList1 = new SinoSZClientUser.Controls.PostUserList();
                        ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
                        this.splitContainerControl1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
                        this.splitContainerControl2.SuspendLayout();
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
                        this.splitContainerControl1.Panel1.Controls.Add(this.sinoUC_OrgTree1);
                        this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(5);
                        this.splitContainerControl1.Panel1.Text = "Panel1";
                        this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
                        this.splitContainerControl1.Panel2.Padding = new System.Windows.Forms.Padding(5);
                        this.splitContainerControl1.Panel2.Text = "Panel2";
                        this.splitContainerControl1.Size = new System.Drawing.Size(910, 546);
                        this.splitContainerControl1.SplitterPosition = 303;
                        this.splitContainerControl1.TabIndex = 0;
                        this.splitContainerControl1.Text = "splitContainerControl1";
                        // 
                        // sinoUC_OrgTree1
                        // 
                        this.sinoUC_OrgTree1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.sinoUC_OrgTree1.Location = new System.Drawing.Point(5, 4);
                        this.sinoUC_OrgTree1.Name = "sinoUC_OrgTree1";
                        this.sinoUC_OrgTree1.Size = new System.Drawing.Size(289, 533);
                        this.sinoUC_OrgTree1.TabIndex = 1;
                        this.sinoUC_OrgTree1.FocusChanged += new System.EventHandler<SinoSZClientBase.Organize.OrgEventArgs>(this.sinoUC_OrgTree1_FocusChanged);
                        // 
                        // splitContainerControl2
                        // 
                        this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.splitContainerControl2.Horizontal = false;
                        this.splitContainerControl2.Location = new System.Drawing.Point(5, 4);
                        this.splitContainerControl2.Name = "splitContainerControl2";
                        this.splitContainerControl2.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                        this.splitContainerControl2.Panel1.Controls.Add(this.postList1);
                        this.splitContainerControl2.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
                        this.splitContainerControl2.Panel1.Text = "Panel1";
                        this.splitContainerControl2.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                        this.splitContainerControl2.Panel2.Controls.Add(this.xtraTabControl1);
                        this.splitContainerControl2.Panel2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
                        this.splitContainerControl2.Panel2.Text = "Panel2";
                        this.splitContainerControl2.Size = new System.Drawing.Size(587, 533);
                        this.splitContainerControl2.SplitterPosition = 196;
                        this.splitContainerControl2.TabIndex = 0;
                        this.splitContainerControl2.Text = "splitContainerControl2";
                        // 
                        // postList1
                        // 
                        this.postList1.BackColor = System.Drawing.Color.Transparent;
                        this.postList1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.postList1.Location = new System.Drawing.Point(0, 0);
                        this.postList1.Name = "postList1";
                        this.postList1.Size = new System.Drawing.Size(587, 191);
                        this.postList1.TabIndex = 0;
                        this.postList1.FocusPostChanged += new System.EventHandler<System.EventArgs>(this.postList1_FocusPostChanged);
                        // 
                        // xtraTabControl1
                        // 
                        this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.xtraTabControl1.Location = new System.Drawing.Point(0, 4);
                        this.xtraTabControl1.Name = "xtraTabControl1";
                        this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
                        this.xtraTabControl1.Size = new System.Drawing.Size(587, 327);
                        this.xtraTabControl1.TabIndex = 1;
                        this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
                        this.xtraTabControl1.Text = "xtraTabControl1";
                        this.xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
                        // 
                        // xtraTabPage1
                        // 
                        this.xtraTabPage1.Controls.Add(this.postRoleList1);
                        this.xtraTabPage1.Name = "xtraTabPage1";
                        this.xtraTabPage1.Size = new System.Drawing.Size(578, 295);
                        this.xtraTabPage1.Text = "角色授权";
                        // 
                        // postRoleList1
                        // 
                        this.postRoleList1.BackColor = System.Drawing.Color.Transparent;
                        this.postRoleList1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.postRoleList1.Location = new System.Drawing.Point(0, 0);
                        this.postRoleList1.Name = "postRoleList1";
                        this.postRoleList1.Size = new System.Drawing.Size(578, 295);
                        this.postRoleList1.TabIndex = 0;
                        this.postRoleList1.DataChanged += new System.EventHandler<System.EventArgs>(this.postRoleList1_DataChanged);
                        // 
                        // xtraTabPage2
                        // 
                        this.xtraTabPage2.Controls.Add(this.postUserList1);
                        this.xtraTabPage2.Name = "xtraTabPage2";
                        this.xtraTabPage2.Size = new System.Drawing.Size(578, 295);
                        this.xtraTabPage2.Text = "岗位用户列表";
                        // 
                        // postUserList1
                        // 
                        this.postUserList1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.postUserList1.Location = new System.Drawing.Point(0, 0);
                        this.postUserList1.Name = "postUserList1";
                        this.postUserList1.Size = new System.Drawing.Size(578, 295);
                        this.postUserList1.TabIndex = 0;
                        // 
                        // frmPostDefine
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(910, 546);
                        this.Controls.Add(this.splitContainerControl1);
                        this.Name = "frmPostDefine";
                        this.Text = "岗位管理";
                        this.Load += new System.EventHandler(this.frmPostDefine_Load);
                        ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
                        this.splitContainerControl1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
                        this.splitContainerControl2.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
                        this.xtraTabControl1.ResumeLayout(false);
                        this.xtraTabPage1.ResumeLayout(false);
                        this.xtraTabPage2.ResumeLayout(false);
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
                private SinoSZClientBase.Organize.SinoUC_OrgTree sinoUC_OrgTree1;
                private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
                private SinoSZClientUser.Controls.PostList postList1;
                private SinoSZClientUser.Controls.PostRoleList postRoleList1;
                private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
                private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
                private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
                private SinoSZClientUser.Controls.PostUserList postUserList1;
        }
}