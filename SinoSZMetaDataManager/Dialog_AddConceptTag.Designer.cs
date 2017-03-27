namespace SinoSZMetaDataManager
{
        partial class Dialog_AddConceptTag
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
                        this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
                        this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
                        this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
                        this.label1 = new System.Windows.Forms.Label();
                        this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
                        this.label2 = new System.Windows.Forms.Label();
                        ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // simpleButton2
                        // 
                        this.simpleButton2.Location = new System.Drawing.Point(269, 95);
                        this.simpleButton2.Name = "simpleButton2";
                        this.simpleButton2.Size = new System.Drawing.Size(55, 23);
                        this.simpleButton2.TabIndex = 7;
                        this.simpleButton2.Text = "取 消";
                        this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
                        // 
                        // simpleButton1
                        // 
                        this.simpleButton1.Location = new System.Drawing.Point(208, 95);
                        this.simpleButton1.Name = "simpleButton1";
                        this.simpleButton1.Size = new System.Drawing.Size(55, 23);
                        this.simpleButton1.TabIndex = 6;
                        this.simpleButton1.Text = "确 定";
                        this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
                        // 
                        // textEdit1
                        // 
                        this.textEdit1.Location = new System.Drawing.Point(73, 26);
                        this.textEdit1.Name = "textEdit1";
                        this.textEdit1.Size = new System.Drawing.Size(254, 21);
                        this.textEdit1.TabIndex = 5;
                        // 
                        // label1
                        // 
                        this.label1.AutoSize = true;
                        this.label1.Location = new System.Drawing.Point(12, 29);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(55, 14);
                        this.label1.TabIndex = 4;
                        this.label1.Text = "概念标签";
                        // 
                        // textEdit2
                        // 
                        this.textEdit2.Location = new System.Drawing.Point(73, 53);
                        this.textEdit2.Name = "textEdit2";
                        this.textEdit2.Size = new System.Drawing.Size(254, 21);
                        this.textEdit2.TabIndex = 9;
                        // 
                        // label2
                        // 
                        this.label2.AutoSize = true;
                        this.label2.Location = new System.Drawing.Point(12, 56);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(55, 14);
                        this.label2.TabIndex = 10;
                        this.label2.Text = "标签名称";
                        // 
                        // Dialog_AddConceptTag
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(347, 140);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.textEdit2);
                        this.Controls.Add(this.simpleButton2);
                        this.Controls.Add(this.simpleButton1);
                        this.Controls.Add(this.textEdit1);
                        this.Controls.Add(this.label1);
                        this.Name = "Dialog_AddConceptTag";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "添加概念标签";
                        ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private DevExpress.XtraEditors.SimpleButton simpleButton2;
                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private DevExpress.XtraEditors.TextEdit textEdit1;
                private System.Windows.Forms.Label label1;
                private DevExpress.XtraEditors.TextEdit textEdit2;
                private System.Windows.Forms.Label label2;
        }
}