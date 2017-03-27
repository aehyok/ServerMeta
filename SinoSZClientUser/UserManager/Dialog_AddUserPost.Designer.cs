namespace SinoSZClientUser.UserManager
{
        partial class Dialog_AddUserPost
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
                        this.panel1 = new System.Windows.Forms.Panel();
                        this.panel3 = new System.Windows.Forms.Panel();
                        this.panel2 = new System.Windows.Forms.Panel();
                        this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
                        this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
                        this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
                        this.sinoUC_OrgTree1 = new SinoSZClientBase.Organize.SinoUC_OrgTree();
                        this.postList1 = new SinoSZClientUser.Controls.PostList();
                        this.panel1.SuspendLayout();
                        this.panel2.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
                        this.splitContainerControl1.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // panel1
                        // 
                        this.panel1.Controls.Add(this.panel3);
                        this.panel1.Controls.Add(this.panel2);
                        this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.panel1.Location = new System.Drawing.Point(5, 473);
                        this.panel1.Name = "panel1";
                        this.panel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
                        this.panel1.Size = new System.Drawing.Size(782, 35);
                        this.panel1.TabIndex = 1;
                        // 
                        // panel3
                        // 
                        this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.panel3.Location = new System.Drawing.Point(0, 5);
                        this.panel3.Name = "panel3";
                        this.panel3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
                        this.panel3.Size = new System.Drawing.Size(640, 30);
                        this.panel3.TabIndex = 1;
                        // 
                        // panel2
                        // 
                        this.panel2.Controls.Add(this.simpleButton2);
                        this.panel2.Controls.Add(this.simpleButton1);
                        this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
                        this.panel2.Location = new System.Drawing.Point(640, 5);
                        this.panel2.Name = "panel2";
                        this.panel2.Size = new System.Drawing.Size(142, 30);
                        this.panel2.TabIndex = 0;
                        // 
                        // simpleButton2
                        // 
                        this.simpleButton2.Location = new System.Drawing.Point(75, 3);
                        this.simpleButton2.Name = "simpleButton2";
                        this.simpleButton2.Size = new System.Drawing.Size(58, 23);
                        this.simpleButton2.TabIndex = 1;
                        this.simpleButton2.Text = "返回";
                        this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
                        // 
                        // simpleButton1
                        // 
                        this.simpleButton1.Location = new System.Drawing.Point(5, 3);
                        this.simpleButton1.Name = "simpleButton1";
                        this.simpleButton1.Size = new System.Drawing.Size(64, 23);
                        this.simpleButton1.TabIndex = 0;
                        this.simpleButton1.Text = "添加岗位";
                        this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
                        // 
                        // splitContainerControl1
                        // 
                        this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.splitContainerControl1.Location = new System.Drawing.Point(5, 5);
                        this.splitContainerControl1.Name = "splitContainerControl1";
                        this.splitContainerControl1.Panel1.Controls.Add(this.sinoUC_OrgTree1);
                        this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(5);
                        this.splitContainerControl1.Panel1.Text = "Panel1";
                        this.splitContainerControl1.Panel2.Controls.Add(this.postList1);
                        this.splitContainerControl1.Panel2.Padding = new System.Windows.Forms.Padding(5);
                        this.splitContainerControl1.Panel2.Text = "Panel2";
                        this.splitContainerControl1.Size = new System.Drawing.Size(782, 468);
                        this.splitContainerControl1.SplitterPosition = 303;
                        this.splitContainerControl1.TabIndex = 2;
                        this.splitContainerControl1.Text = "splitContainerControl1";
                        // 
                        // sinoUC_OrgTree1
                        // 
                        this.sinoUC_OrgTree1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.sinoUC_OrgTree1.Location = new System.Drawing.Point(5, 4);
                        this.sinoUC_OrgTree1.Name = "sinoUC_OrgTree1";
                        this.sinoUC_OrgTree1.Size = new System.Drawing.Size(289, 455);
                        this.sinoUC_OrgTree1.TabIndex = 1;
                        this.sinoUC_OrgTree1.FocusChanged += new System.EventHandler<SinoSZClientBase.Organize.OrgEventArgs>(this.sinoUC_OrgTree1_FocusChanged);
                        // 
                        // postList1
                        // 
                        this.postList1.BackColor = System.Drawing.Color.Transparent;
                        this.postList1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.postList1.Location = new System.Drawing.Point(5, 4);
                        this.postList1.Name = "postList1";
                        this.postList1.Size = new System.Drawing.Size(459, 455);
                        this.postList1.TabIndex = 0;
                        // 
                        // Dialog_AddUserPost
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(792, 513);
                        this.Controls.Add(this.splitContainerControl1);
                        this.Controls.Add(this.panel1);
                        this.Name = "Dialog_AddUserPost";
                        this.Padding = new System.Windows.Forms.Padding(5);
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "添加岗位";
                        this.panel1.ResumeLayout(false);
                        this.panel2.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
                        this.splitContainerControl1.ResumeLayout(false);
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.Panel panel1;
                private System.Windows.Forms.Panel panel3;
                private System.Windows.Forms.Panel panel2;
                private DevExpress.XtraEditors.SimpleButton simpleButton2;
                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
                private SinoSZClientBase.Organize.SinoUC_OrgTree sinoUC_OrgTree1;
                private SinoSZClientUser.Controls.PostList postList1;
        }
}