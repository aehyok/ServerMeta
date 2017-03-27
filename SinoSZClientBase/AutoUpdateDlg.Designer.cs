namespace SinoSZClientBase
{
        partial class AutoUpdateDlg
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
                        this.label1 = new System.Windows.Forms.Label();
                        this.progressBar1 = new System.Windows.Forms.ProgressBar();
                        this.timer1 = new System.Windows.Forms.Timer(this.components);
                        this.SuspendLayout();
                        // 
                        // label1
                        // 
                        this.label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
                        this.label1.Location = new System.Drawing.Point(12, 23);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(365, 40);
                        this.label1.TabIndex = 0;
                        this.label1.Text = "正在下载最新版本程序，请稍候。。。";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // progressBar1
                        // 
                        this.progressBar1.Location = new System.Drawing.Point(12, 76);
                        this.progressBar1.Name = "progressBar1";
                        this.progressBar1.Size = new System.Drawing.Size(363, 16);
                        this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
                        this.progressBar1.TabIndex = 1;
                        // 
                        // timer1
                        // 
                        this.timer1.Interval = 500;
                        this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
                        // 
                        // AutoUpdateDlg
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(389, 139);
                        this.Controls.Add(this.progressBar1);
                        this.Controls.Add(this.label1);
                        this.Name = "AutoUpdateDlg";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "自动更新系统";
                        this.Activated += new System.EventHandler(this.AutoUpdateDlg_Activated);
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.Label label1;
                private System.Windows.Forms.ProgressBar progressBar1;
                private System.Windows.Forms.Timer timer1;
        }
}