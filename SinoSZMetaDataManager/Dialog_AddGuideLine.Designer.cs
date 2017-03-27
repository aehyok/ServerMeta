namespace SinoSZMetaDataManager
{
        partial class Dialog_AddGuideLine
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
                        this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
                        this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
                        this.label1 = new System.Windows.Forms.Label();
                        this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
                        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
                        this.panelControl1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // panelControl1
                        // 
                        this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                        this.panelControl1.Controls.Add(this.simpleButton2);
                        this.panelControl1.Controls.Add(this.simpleButton1);
                        this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.panelControl1.Location = new System.Drawing.Point(10, 55);
                        this.panelControl1.Name = "panelControl1";
                        this.panelControl1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
                        this.panelControl1.Size = new System.Drawing.Size(362, 45);
                        this.panelControl1.TabIndex = 3;
                        // 
                        // simpleButton2
                        // 
                        this.simpleButton2.Dock = System.Windows.Forms.DockStyle.Right;
                        this.simpleButton2.Location = new System.Drawing.Point(212, 10);
                        this.simpleButton2.Name = "simpleButton2";
                        this.simpleButton2.Size = new System.Drawing.Size(75, 25);
                        this.simpleButton2.TabIndex = 1;
                        this.simpleButton2.Text = "确定";
                        this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
                        // 
                        // simpleButton1
                        // 
                        this.simpleButton1.Dock = System.Windows.Forms.DockStyle.Right;
                        this.simpleButton1.Location = new System.Drawing.Point(287, 10);
                        this.simpleButton1.Name = "simpleButton1";
                        this.simpleButton1.Size = new System.Drawing.Size(75, 25);
                        this.simpleButton1.TabIndex = 0;
                        this.simpleButton1.Text = "取消";
                        this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
                        // 
                        // label1
                        // 
                        this.label1.AutoSize = true;
                        this.label1.Location = new System.Drawing.Point(13, 19);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(55, 14);
                        this.label1.TabIndex = 5;
                        this.label1.Text = "指标名称";
                        // 
                        // textEdit2
                        // 
                        this.textEdit2.Location = new System.Drawing.Point(74, 16);
                        this.textEdit2.Name = "textEdit2";
                        this.textEdit2.Size = new System.Drawing.Size(294, 21);
                        this.textEdit2.TabIndex = 6;
                        // 
                        // Dialog_AddGuideLine
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(382, 110);
                        this.Controls.Add(this.textEdit2);
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.panelControl1);
                        this.Name = "Dialog_AddGuideLine";
                        this.Padding = new System.Windows.Forms.Padding(10);
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "添加指标";
                        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
                        this.panelControl1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private DevExpress.XtraEditors.PanelControl panelControl1;
                private DevExpress.XtraEditors.SimpleButton simpleButton2;
                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private System.Windows.Forms.Label label1;
                private DevExpress.XtraEditors.TextEdit textEdit2;
        }
}