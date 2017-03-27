namespace SinoSZToolUpdatePacker
{
        partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.be_TargetDir = new DevExpress.XtraEditors.ButtonEdit();
            this.be_SourceDir = new DevExpress.XtraEditors.ButtonEdit();
            this.te_Out = new DevExpress.XtraEditors.MemoEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.te_URL = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonEdit1 = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.be_TargetDir.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.be_SourceDir.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Out.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_URL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "源文件目录";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "目标文件目录";
            // 
            // be_TargetDir
            // 
            this.be_TargetDir.Location = new System.Drawing.Point(167, 30);
            this.be_TargetDir.Name = "be_TargetDir";
            this.be_TargetDir.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.be_TargetDir.Size = new System.Drawing.Size(722, 24);
            this.be_TargetDir.TabIndex = 5;
            this.be_TargetDir.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.be_TargetDir_ButtonClick);
            // 
            // be_SourceDir
            // 
            this.be_SourceDir.Location = new System.Drawing.Point(167, 66);
            this.be_SourceDir.Name = "be_SourceDir";
            this.be_SourceDir.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.be_SourceDir.Size = new System.Drawing.Size(722, 24);
            this.be_SourceDir.TabIndex = 6;
            this.be_SourceDir.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.be_SourceDir_ButtonClick);
            // 
            // te_Out
            // 
            this.te_Out.Location = new System.Drawing.Point(58, 234);
            this.te_Out.Name = "te_Out";
            this.te_Out.Size = new System.Drawing.Size(831, 361);
            this.te_Out.TabIndex = 8;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(790, 198);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(99, 29);
            this.simpleButton1.TabIndex = 9;
            this.simpleButton1.Text = "开始生成";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "下载包URL";
            // 
            // te_URL
            // 
            this.te_URL.Location = new System.Drawing.Point(167, 129);
            this.te_URL.Name = "te_URL";
            this.te_URL.Size = new System.Drawing.Size(722, 24);
            this.te_URL.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "源配置文件";
            // 
            // buttonEdit1
            // 
            this.buttonEdit1.Location = new System.Drawing.Point(167, 97);
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit1.Size = new System.Drawing.Size(722, 24);
            this.buttonEdit1.TabIndex = 13;
            this.buttonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit1_ButtonClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 627);
            this.Controls.Add(this.buttonEdit1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.te_URL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.te_Out);
            this.Controls.Add(this.be_SourceDir);
            this.Controls.Add(this.be_TargetDir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动升级包制作工具 V4.0";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.be_TargetDir.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.be_SourceDir.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Out.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_URL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

                }

                #endregion

                private System.Windows.Forms.Label label2;
                private System.Windows.Forms.Label label3;
                private DevExpress.XtraEditors.ButtonEdit be_TargetDir;
                private DevExpress.XtraEditors.ButtonEdit be_SourceDir;
                private DevExpress.XtraEditors.MemoEdit te_Out;
                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private System.Windows.Forms.Label label1;
                private DevExpress.XtraEditors.TextEdit te_URL;
                private System.Windows.Forms.Label label4;
                private DevExpress.XtraEditors.ButtonEdit buttonEdit1;
        }
}

