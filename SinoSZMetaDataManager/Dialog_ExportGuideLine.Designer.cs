namespace SinoSZMetaDataManager
{
        partial class Dialog_ExportGuideLine
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
                        this.label1 = new System.Windows.Forms.Label();
                        this.buttonEdit1 = new DevExpress.XtraEditors.ButtonEdit();
                        this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
                        this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
                        this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
                        ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(13, 26);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(68, 16);
                        this.label1.TabIndex = 0;
                        this.label1.Text = "导出文件名";
                        // 
                        // buttonEdit1
                        // 
                        this.buttonEdit1.Location = new System.Drawing.Point(88, 24);
                        this.buttonEdit1.Name = "buttonEdit1";
                        this.buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
                        this.buttonEdit1.Size = new System.Drawing.Size(316, 21);
                        this.buttonEdit1.TabIndex = 1;
                        this.buttonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit1_ButtonClick);
                        // 
                        // checkEdit1
                        // 
                        this.checkEdit1.Location = new System.Drawing.Point(88, 52);
                        this.checkEdit1.Name = "checkEdit1";
                        this.checkEdit1.Properties.Caption = "同时导出下级指标";
                        this.checkEdit1.Size = new System.Drawing.Size(283, 19);
                        this.checkEdit1.TabIndex = 2;
                        // 
                        // simpleButton1
                        // 
                        this.simpleButton1.Location = new System.Drawing.Point(280, 87);
                        this.simpleButton1.Name = "simpleButton1";
                        this.simpleButton1.Size = new System.Drawing.Size(59, 23);
                        this.simpleButton1.TabIndex = 3;
                        this.simpleButton1.Text = "确定";
                        this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
                        // 
                        // simpleButton2
                        // 
                        this.simpleButton2.Location = new System.Drawing.Point(345, 87);
                        this.simpleButton2.Name = "simpleButton2";
                        this.simpleButton2.Size = new System.Drawing.Size(59, 23);
                        this.simpleButton2.TabIndex = 4;
                        this.simpleButton2.Text = "取消";
                        this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
                        // 
                        // Dialog_ExportGuideLine
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(416, 125);
                        this.Controls.Add(this.simpleButton2);
                        this.Controls.Add(this.simpleButton1);
                        this.Controls.Add(this.checkEdit1);
                        this.Controls.Add(this.buttonEdit1);
                        this.Controls.Add(this.label1);
                        this.Name = "Dialog_ExportGuideLine";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "导出指标";
                        ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.Label label1;
                private DevExpress.XtraEditors.ButtonEdit buttonEdit1;
                private DevExpress.XtraEditors.CheckEdit checkEdit1;
                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private DevExpress.XtraEditors.SimpleButton simpleButton2;
        }
}