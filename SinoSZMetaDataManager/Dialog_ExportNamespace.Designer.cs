namespace SinoSZMetaDataManager
{
        partial class Dialog_ExportNamespace
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
                        this.labelProgress = new System.Windows.Forms.Label();
                        this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
                        this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
                        this.te_File = new DevExpress.XtraEditors.ButtonEdit();
                        this.label1 = new System.Windows.Forms.Label();
                        this.panelWait = new System.Windows.Forms.Panel();
                        this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
                        ((System.ComponentModel.ISupportInitialize)(this.te_File.Properties)).BeginInit();
                        this.panelWait.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // labelProgress
                        // 
                        this.labelProgress.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.labelProgress.Location = new System.Drawing.Point(100, 0);
                        this.labelProgress.Name = "labelProgress";
                        this.labelProgress.Size = new System.Drawing.Size(265, 23);
                        this.labelProgress.TabIndex = 9;
                        this.labelProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // simpleButton2
                        // 
                        this.simpleButton2.Location = new System.Drawing.Point(464, 65);
                        this.simpleButton2.Name = "simpleButton2";
                        this.simpleButton2.Size = new System.Drawing.Size(61, 23);
                        this.simpleButton2.TabIndex = 8;
                        this.simpleButton2.Text = "取消";
                        this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
                        // 
                        // simpleButton1
                        // 
                        this.simpleButton1.Location = new System.Drawing.Point(397, 65);
                        this.simpleButton1.Name = "simpleButton1";
                        this.simpleButton1.Size = new System.Drawing.Size(61, 23);
                        this.simpleButton1.TabIndex = 7;
                        this.simpleButton1.Text = "导出";
                        this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
                        // 
                        // te_File
                        // 
                        this.te_File.Location = new System.Drawing.Point(84, 26);
                        this.te_File.Name = "te_File";
                        this.te_File.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
                        this.te_File.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                        this.te_File.Size = new System.Drawing.Size(441, 21);
                        this.te_File.TabIndex = 6;
                        this.te_File.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.te_File_ButtonClick);
                        // 
                        // label1
                        // 
                        this.label1.AutoSize = true;
                        this.label1.Location = new System.Drawing.Point(23, 29);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(55, 14);
                        this.label1.TabIndex = 5;
                        this.label1.Text = "导出文件";
                        // 
                        // panelWait
                        // 
                        this.panelWait.Controls.Add(this.labelProgress);
                        this.panelWait.Controls.Add(this.progressBarControl1);
                        this.panelWait.Location = new System.Drawing.Point(26, 65);
                        this.panelWait.Name = "panelWait";
                        this.panelWait.Size = new System.Drawing.Size(365, 23);
                        this.panelWait.TabIndex = 10;
                        this.panelWait.Visible = false;
                        // 
                        // progressBarControl1
                        // 
                        this.progressBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
                        this.progressBarControl1.Location = new System.Drawing.Point(0, 0);
                        this.progressBarControl1.Name = "progressBarControl1";
                        this.progressBarControl1.Size = new System.Drawing.Size(100, 23);
                        this.progressBarControl1.TabIndex = 0;
                        // 
                        // Dialog_ExportNamespace
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(545, 111);
                        this.Controls.Add(this.panelWait);
                        this.Controls.Add(this.simpleButton2);
                        this.Controls.Add(this.simpleButton1);
                        this.Controls.Add(this.te_File);
                        this.Controls.Add(this.label1);
                        this.Name = "Dialog_ExportNamespace";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "导出命名空间";
                        ((System.ComponentModel.ISupportInitialize)(this.te_File.Properties)).EndInit();
                        this.panelWait.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private System.Windows.Forms.Label labelProgress;
                private DevExpress.XtraEditors.SimpleButton simpleButton2;
                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private DevExpress.XtraEditors.ButtonEdit te_File;
                private System.Windows.Forms.Label label1;
                private System.Windows.Forms.Panel panelWait;
                private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        }
}