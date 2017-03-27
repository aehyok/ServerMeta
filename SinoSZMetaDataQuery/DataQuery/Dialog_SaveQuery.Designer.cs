namespace SinoSZMetaDataQuery.DataQuery
{
        partial class Dialog_SaveQuery
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
                        this.panel2 = new System.Windows.Forms.Panel();
                        this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
                        this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
                        this.label1 = new System.Windows.Forms.Label();
                        this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
                        this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
                        this.panel1.SuspendLayout();
                        this.panel2.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // panel1
                        // 
                        this.panel1.Controls.Add(this.panel2);
                        this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.panel1.Location = new System.Drawing.Point(5, 103);
                        this.panel1.Name = "panel1";
                        this.panel1.Size = new System.Drawing.Size(368, 36);
                        this.panel1.TabIndex = 0;
                        // 
                        // panel2
                        // 
                        this.panel2.Controls.Add(this.simpleButton2);
                        this.panel2.Controls.Add(this.simpleButton1);
                        this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
                        this.panel2.Location = new System.Drawing.Point(230, 0);
                        this.panel2.Name = "panel2";
                        this.panel2.Size = new System.Drawing.Size(138, 36);
                        this.panel2.TabIndex = 0;
                        // 
                        // simpleButton1
                        // 
                        this.simpleButton1.Location = new System.Drawing.Point(78, 4);
                        this.simpleButton1.Name = "simpleButton1";
                        this.simpleButton1.Size = new System.Drawing.Size(53, 23);
                        this.simpleButton1.TabIndex = 0;
                        this.simpleButton1.Text = "取消";
                        this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
                        // 
                        // simpleButton2
                        // 
                        this.simpleButton2.Location = new System.Drawing.Point(21, 4);
                        this.simpleButton2.Name = "simpleButton2";
                        this.simpleButton2.Size = new System.Drawing.Size(53, 23);
                        this.simpleButton2.TabIndex = 1;
                        this.simpleButton2.Text = "确定";
                        this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
                        // 
                        // label1
                        // 
                        this.label1.AutoSize = true;
                        this.label1.Location = new System.Drawing.Point(8, 31);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(55, 14);
                        this.label1.TabIndex = 1;
                        this.label1.Text = "保存名称";
                        // 
                        // textEdit1
                        // 
                        this.textEdit1.Location = new System.Drawing.Point(69, 28);
                        this.textEdit1.Name = "textEdit1";
                        this.textEdit1.Size = new System.Drawing.Size(299, 21);
                        this.textEdit1.TabIndex = 2;
                        // 
                        // checkEdit1
                        // 
                        this.checkEdit1.Location = new System.Drawing.Point(69, 56);
                        this.checkEdit1.Name = "checkEdit1";
                        this.checkEdit1.Properties.Caption = "其它人也可以使用";
                        this.checkEdit1.Size = new System.Drawing.Size(203, 19);
                        this.checkEdit1.TabIndex = 3;
                        // 
                        // Dialog_SaveQuery
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(378, 144);
                        this.Controls.Add(this.checkEdit1);
                        this.Controls.Add(this.textEdit1);
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.panel1);
                        this.Name = "Dialog_SaveQuery";
                        this.Padding = new System.Windows.Forms.Padding(5);
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "保存查询";
                        this.panel1.ResumeLayout(false);
                        this.panel2.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private System.Windows.Forms.Panel panel1;
                private System.Windows.Forms.Panel panel2;
                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private DevExpress.XtraEditors.SimpleButton simpleButton2;
                private System.Windows.Forms.Label label1;
                private DevExpress.XtraEditors.TextEdit textEdit1;
                private DevExpress.XtraEditors.CheckEdit checkEdit1;
        }
}