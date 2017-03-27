namespace SinoSZClientBase
{
        partial class frmProgress
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
                        this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
                        this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
                        ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // marqueeProgressBarControl1
                        // 
                        this.marqueeProgressBarControl1.EditValue = 0;
                        this.marqueeProgressBarControl1.Location = new System.Drawing.Point(29, 101);
                        this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
                        this.marqueeProgressBarControl1.Size = new System.Drawing.Size(325, 16);
                        this.marqueeProgressBarControl1.TabIndex = 2;
                        this.marqueeProgressBarControl1.UseWaitCursor = true;
                        // 
                        // labelControl1
                        // 
                        this.labelControl1.Location = new System.Drawing.Point(29, 60);
                        this.labelControl1.Name = "labelControl1";
                        this.labelControl1.Size = new System.Drawing.Size(140, 14);
                        this.labelControl1.TabIndex = 3;
                        this.labelControl1.Text = "正在处理数据，请稍候 ....";
                        // 
                        // frmProgress
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(397, 185);
                        this.ControlBox = false;
                        this.Controls.Add(this.labelControl1);
                        this.Controls.Add(this.marqueeProgressBarControl1);
                        this.Name = "frmProgress";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "系统提示";
                        this.TopMost = true;
                        ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
                private DevExpress.XtraEditors.LabelControl labelControl1;
        }
}