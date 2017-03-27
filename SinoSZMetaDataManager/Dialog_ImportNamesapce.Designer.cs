namespace SinoSZMetaDataManager
{
        partial class Dialog_ImportNamesapce
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
			this.te_File = new DevExpress.XtraEditors.ButtonEdit();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			this.label2 = new System.Windows.Forms.Label();
			this.te_Type = new DevExpress.XtraEditors.RadioGroup();
			this.label3 = new System.Windows.Forms.Label();
			this.TE_NEWNAME = new DevExpress.XtraEditors.TextEdit();
			this.te_Mode = new DevExpress.XtraEditors.RadioGroup();
			((System.ComponentModel.ISupportInitialize)(this.te_File.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_Type.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TE_NEWNAME.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_Mode.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 47);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 14);
			this.label1.TabIndex = 0;
			this.label1.Text = "导入文件";
			// 
			// te_File
			// 
			this.te_File.Location = new System.Drawing.Point(75, 44);
			this.te_File.Name = "te_File";
			this.te_File.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.te_File.Size = new System.Drawing.Size(441, 21);
			this.te_File.TabIndex = 1;
			this.te_File.Click += new System.EventHandler(this.te_File_Click);
			// 
			// simpleButton1
			// 
			this.simpleButton1.Location = new System.Drawing.Point(388, 125);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new System.Drawing.Size(61, 23);
			this.simpleButton1.TabIndex = 2;
			this.simpleButton1.Text = "导入";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// simpleButton2
			// 
			this.simpleButton2.Location = new System.Drawing.Point(455, 125);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.Size = new System.Drawing.Size(61, 23);
			this.simpleButton2.TabIndex = 3;
			this.simpleButton2.Text = "取消";
			this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(17, 125);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(365, 23);
			this.label2.TabIndex = 4;
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label2.Visible = false;
			// 
			// te_Type
			// 
			this.te_Type.Location = new System.Drawing.Point(75, 69);
			this.te_Type.Name = "te_Type";
			this.te_Type.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.te_Type.Properties.Appearance.Options.UseBackColor = true;
			this.te_Type.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.te_Type.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("0", "旧版导出格式"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "新版导出格式")});
			this.te_Type.Size = new System.Drawing.Size(220, 23);
			this.te_Type.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(17, 18);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 14);
			this.label3.TabIndex = 6;
			this.label3.Text = "新名称";
			// 
			// TE_NEWNAME
			// 
			this.TE_NEWNAME.Location = new System.Drawing.Point(75, 18);
			this.TE_NEWNAME.Name = "TE_NEWNAME";
			this.TE_NEWNAME.Size = new System.Drawing.Size(441, 21);
			this.TE_NEWNAME.TabIndex = 7;
			// 
			// te_Mode
			// 
			this.te_Mode.EditValue = "0";
			this.te_Mode.Location = new System.Drawing.Point(75, 98);
			this.te_Mode.Name = "te_Mode";
			this.te_Mode.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.te_Mode.Properties.Appearance.Options.UseBackColor = true;
			this.te_Mode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.te_Mode.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("0", "变更序列号"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "保持原序列号")});
			this.te_Mode.Size = new System.Drawing.Size(220, 23);
			this.te_Mode.TabIndex = 8;
			// 
			// Dialog_ImportNamesapce
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(528, 161);
			this.Controls.Add(this.te_Mode);
			this.Controls.Add(this.TE_NEWNAME);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.te_Type);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.simpleButton2);
			this.Controls.Add(this.simpleButton1);
			this.Controls.Add(this.te_File);
			this.Controls.Add(this.label1);
			this.Name = "Dialog_ImportNamesapce";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "导入命名空间";
			((System.ComponentModel.ISupportInitialize)(this.te_File.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_Type.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TE_NEWNAME.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_Mode.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

                }

                #endregion

                private System.Windows.Forms.Label label1;
                private DevExpress.XtraEditors.ButtonEdit te_File;
                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private DevExpress.XtraEditors.SimpleButton simpleButton2;
                private System.Windows.Forms.Label label2;
                private DevExpress.XtraEditors.RadioGroup te_Type;
                private System.Windows.Forms.Label label3;
                private DevExpress.XtraEditors.TextEdit TE_NEWNAME;
		private DevExpress.XtraEditors.RadioGroup te_Mode;
        }
}