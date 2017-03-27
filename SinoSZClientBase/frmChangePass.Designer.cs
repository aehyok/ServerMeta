namespace SinoSZClientBase
{
        partial class frmChangePass
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
                        DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
                        DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
                        DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
                        DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
                        DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
                        DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangePass));
                        this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
                        this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
                        this.label1 = new System.Windows.Forms.Label();
                        this.te_oldPass = new DevExpress.XtraEditors.TextEdit();
                        this.label2 = new System.Windows.Forms.Label();
                        this.te_newPass = new DevExpress.XtraEditors.TextEdit();
                        this.te_newPass2 = new DevExpress.XtraEditors.TextEdit();
                        this.label3 = new System.Windows.Forms.Label();
                        ((System.ComponentModel.ISupportInitialize)(this.te_oldPass.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_newPass.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_newPass2.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // simpleButton1
                        // 
                        this.simpleButton1.Location = new System.Drawing.Point(130, 127);
                        this.simpleButton1.Name = "simpleButton1";
                        this.simpleButton1.Size = new System.Drawing.Size(67, 23);
                        this.simpleButton1.TabIndex = 0;
                        this.simpleButton1.Text = "确 定";
                        this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
                        // 
                        // simpleButton2
                        // 
                        this.simpleButton2.Location = new System.Drawing.Point(203, 127);
                        this.simpleButton2.Name = "simpleButton2";
                        this.simpleButton2.Size = new System.Drawing.Size(67, 23);
                        this.simpleButton2.TabIndex = 1;
                        this.simpleButton2.Text = "取 消";
                        this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(20, 30);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(75, 20);
                        this.label1.TabIndex = 2;
                        this.label1.Text = "原 口 令";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // te_oldPass
                        // 
                        this.te_oldPass.Location = new System.Drawing.Point(102, 30);
                        this.te_oldPass.Name = "te_oldPass";
                        this.te_oldPass.Properties.PasswordChar = '*';
                        this.te_oldPass.Size = new System.Drawing.Size(168, 21);
                        this.te_oldPass.TabIndex = 3;
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(20, 59);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(75, 20);
                        this.label2.TabIndex = 4;
                        this.label2.Text = "新 口 令";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // te_newPass
                        // 
                        this.te_newPass.Location = new System.Drawing.Point(102, 58);
                        this.te_newPass.Name = "te_newPass";
                        this.te_newPass.Properties.PasswordChar = '*';
                        this.te_newPass.Size = new System.Drawing.Size(168, 21);
                        toolTipTitleItem1.Appearance.Image = global::SinoSZClientBase.Properties.Resources.key;
                        toolTipTitleItem1.Appearance.Options.UseImage = true;
                        toolTipTitleItem1.Image = global::SinoSZClientBase.Properties.Resources.key;
                        toolTipTitleItem1.Text = "口令规则:";
                        toolTipItem1.LeftIndent = 6;
                        toolTipItem1.Text = "1.长度必须大于8位\r\n2.必须有字符、数字和符号\r\n3.不能有汉字";
                        superToolTip1.Items.Add(toolTipTitleItem1);
                        superToolTip1.Items.Add(toolTipItem1);
                        this.te_newPass.SuperTip = superToolTip1;
                        this.te_newPass.TabIndex = 5;
                        // 
                        // te_newPass2
                        // 
                        this.te_newPass2.Location = new System.Drawing.Point(102, 86);
                        this.te_newPass2.Name = "te_newPass2";
                        this.te_newPass2.Properties.PasswordChar = '*';
                        this.te_newPass2.Size = new System.Drawing.Size(168, 21);
                        toolTipTitleItem2.Appearance.Image = global::SinoSZClientBase.Properties.Resources.key;
                        toolTipTitleItem2.Appearance.Options.UseImage = true;
                        toolTipTitleItem2.Image = global::SinoSZClientBase.Properties.Resources.key;
                        toolTipTitleItem2.Text = "口令规则:";
                        toolTipItem2.LeftIndent = 6;
                        toolTipItem2.Text = "1.长度必须大于8位\r\n2.必须有字符、数字和符号\r\n3.不能有汉字";
                        superToolTip2.Items.Add(toolTipTitleItem2);
                        superToolTip2.Items.Add(toolTipItem2);
                        this.te_newPass2.SuperTip = superToolTip2;
                        this.te_newPass2.TabIndex = 6;
                        this.te_newPass2.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
                        // 
                        // label3
                        // 
                        this.label3.Location = new System.Drawing.Point(21, 88);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(75, 20);
                        this.label3.TabIndex = 7;
                        this.label3.Text = "重复新口令";
                        this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // frmChangePass
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(300, 178);
                        this.Controls.Add(this.label3);
                        this.Controls.Add(this.te_newPass2);
                        this.Controls.Add(this.te_newPass);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.te_oldPass);
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.simpleButton2);
                        this.Controls.Add(this.simpleButton1);
                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                        this.MaximizeBox = false;
                        this.MinimizeBox = false;
                        this.Name = "frmChangePass";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "修改口令";
                        ((System.ComponentModel.ISupportInitialize)(this.te_oldPass.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_newPass.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_newPass2.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private DevExpress.XtraEditors.SimpleButton simpleButton2;
                private System.Windows.Forms.Label label1;
                private DevExpress.XtraEditors.TextEdit te_oldPass;
                private System.Windows.Forms.Label label2;
                private DevExpress.XtraEditors.TextEdit te_newPass;
                private DevExpress.XtraEditors.TextEdit te_newPass2;
                private System.Windows.Forms.Label label3;
        }
}