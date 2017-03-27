namespace SinoSZClientBase
{
        partial class frmSetParameter
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.bLogin = new DevExpress.XtraEditors.SimpleButton();
            this.bCancel = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.te_liveupdate = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_liveupdate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.panelControl1.Location = new System.Drawing.Point(1, 96);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(867, 3);
            this.panelControl1.TabIndex = 16;
            // 
            // bLogin
            // 
            this.bLogin.Location = new System.Drawing.Point(584, 121);
            this.bLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(85, 34);
            this.bLogin.TabIndex = 15;
            this.bLogin.Text = "保存参数";
            this.bLogin.Click += new System.EventHandler(this.bLogin_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(678, 121);
            this.bCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(76, 34);
            this.bCancel.TabIndex = 14;
            this.bCancel.Text = "取消";
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 49);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 24;
            this.label4.Text = "自动更新地址";
            // 
            // te_liveupdate
            // 
            this.te_liveupdate.Location = new System.Drawing.Point(135, 44);
            this.te_liveupdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.te_liveupdate.Name = "te_liveupdate";
            this.te_liveupdate.Size = new System.Drawing.Size(641, 24);
            this.te_liveupdate.TabIndex = 25;
            // 
            // frmSetParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 171);
            this.Controls.Add(this.te_liveupdate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.bLogin);
            this.Controls.Add(this.bCancel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmSetParameter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "配置系统参数";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_liveupdate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

                }

                #endregion

                private DevExpress.XtraEditors.PanelControl panelControl1;
                private DevExpress.XtraEditors.SimpleButton bLogin;
                private DevExpress.XtraEditors.SimpleButton bCancel;
                private System.Windows.Forms.Label label4;
                private DevExpress.XtraEditors.TextEdit te_liveupdate;
        }
}