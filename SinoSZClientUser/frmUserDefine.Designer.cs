namespace SinoSZClientUser
{
        partial class frmUserDefine
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.sinoUC_OrgTree1 = new SinoSZClientBase.Organize.SinoUC_OrgTree();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.userList1 = new SinoSZClientUser.Controls.UserList();
            this.pWaitUserList = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.pBarUserList = new DevExpress.XtraEditors.ProgressBarControl();
            this.userPostList1 = new SinoSZClientUser.Controls.UserPostList();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pWaitUserList)).BeginInit();
            this.pWaitUserList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBarUserList.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.sinoUC_OrgTree1);
            this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1026, 621);
            this.splitContainerControl1.SplitterPosition = 296;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // sinoUC_OrgTree1
            // 
            this.sinoUC_OrgTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sinoUC_OrgTree1.Location = new System.Drawing.Point(7, 7);
            this.sinoUC_OrgTree1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sinoUC_OrgTree1.Name = "sinoUC_OrgTree1";
            this.sinoUC_OrgTree1.Size = new System.Drawing.Size(282, 607);
            this.sinoUC_OrgTree1.TabIndex = 0;
            this.sinoUC_OrgTree1.FocusChanged += new System.EventHandler<SinoSZClientBase.Organize.OrgEventArgs>(this.sinoUC_OrgTree1_FocusChanged);
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.userList1);
            this.splitContainerControl2.Panel1.Controls.Add(this.pWaitUserList);
            this.splitContainerControl2.Panel1.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.userPostList1);
            this.splitContainerControl2.Panel2.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(725, 621);
            this.splitContainerControl2.SplitterPosition = 211;
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // userList1
            // 
            this.userList1.DataSource = null;
            this.userList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userList1.Location = new System.Drawing.Point(7, 7);
            this.userList1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userList1.Name = "userList1";
            this.userList1.Size = new System.Drawing.Size(711, 171);
            this.userList1.TabIndex = 0;
            this.userList1.UserFocusChanged += new System.EventHandler<System.EventArgs>(this.userList1_UserFocusChanged);
            // 
            // pWaitUserList
            // 
            this.pWaitUserList.Controls.Add(this.label1);
            this.pWaitUserList.Controls.Add(this.pBarUserList);
            this.pWaitUserList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pWaitUserList.Location = new System.Drawing.Point(7, 178);
            this.pWaitUserList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pWaitUserList.Name = "pWaitUserList";
            this.pWaitUserList.Size = new System.Drawing.Size(711, 26);
            this.pWaitUserList.TabIndex = 4;
            this.pWaitUserList.Visible = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(201, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(508, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = " 正在查询详细信息 ...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pBarUserList
            // 
            this.pBarUserList.Dock = System.Windows.Forms.DockStyle.Left;
            this.pBarUserList.Location = new System.Drawing.Point(2, 2);
            this.pBarUserList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pBarUserList.Name = "pBarUserList";
            this.pBarUserList.Properties.ShowTitle = true;
            this.pBarUserList.Size = new System.Drawing.Size(199, 22);
            this.pBarUserList.TabIndex = 1;
            // 
            // userPostList1
            // 
            this.userPostList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userPostList1.Location = new System.Drawing.Point(7, 7);
            this.userPostList1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userPostList1.Name = "userPostList1";
            this.userPostList1.Size = new System.Drawing.Size(711, 391);
            this.userPostList1.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmUserDefine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 621);
            this.Controls.Add(this.splitContainerControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmUserDefine";
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.frmUserDefine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pWaitUserList)).EndInit();
            this.pWaitUserList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBarUserList.Properties)).EndInit();
            this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
                private SinoSZClientBase.Organize.SinoUC_OrgTree sinoUC_OrgTree1;
                private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
                private SinoSZClientUser.Controls.UserList userList1;
                private System.ComponentModel.BackgroundWorker backgroundWorker1;
                private DevExpress.XtraEditors.PanelControl pWaitUserList;
                private System.Windows.Forms.Label label1;
                private DevExpress.XtraEditors.ProgressBarControl pBarUserList;
                private System.Windows.Forms.Timer timer1;
                private SinoSZClientUser.Controls.UserPostList userPostList1;

        }
}