namespace SinoSZMetaDataQuery.PAnalize
{
        partial class Dialog_SelectPAnalize
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
                        this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
                        this.groupBox1 = new System.Windows.Forms.GroupBox();
                        this.radioButton1 = new System.Windows.Forms.RadioButton();
                        this.radioButton2 = new System.Windows.Forms.RadioButton();
                        this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
                        this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
                        this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
                        this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
                        ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
                        this.groupBox1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(23, 20);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(65, 19);
                        this.label1.TabIndex = 0;
                        this.label1.Text = "表名称";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // textEdit1
                        // 
                        this.textEdit1.Location = new System.Drawing.Point(95, 18);
                        this.textEdit1.Name = "textEdit1";
                        this.textEdit1.Size = new System.Drawing.Size(400, 22);
                        this.textEdit1.TabIndex = 1;
                        // 
                        // groupBox1
                        // 
                        this.groupBox1.Controls.Add(this.comboBoxEdit1);
                        this.groupBox1.Controls.Add(this.textEdit2);
                        this.groupBox1.Controls.Add(this.radioButton2);
                        this.groupBox1.Controls.Add(this.radioButton1);
                        this.groupBox1.Location = new System.Drawing.Point(26, 59);
                        this.groupBox1.Name = "groupBox1";
                        this.groupBox1.Size = new System.Drawing.Size(469, 146);
                        this.groupBox1.TabIndex = 2;
                        this.groupBox1.TabStop = false;
                        this.groupBox1.Text = " 存贮于 ";
                        // 
                        // radioButton1
                        // 
                        this.radioButton1.AutoSize = true;
                        this.radioButton1.Checked = true;
                        this.radioButton1.Location = new System.Drawing.Point(69, 22);
                        this.radioButton1.Name = "radioButton1";
                        this.radioButton1.Size = new System.Drawing.Size(138, 21);
                        this.radioButton1.TabIndex = 0;
                        this.radioButton1.TabStop = true;
                        this.radioButton1.Text = "新建个人分析空间";
                        this.radioButton1.UseVisualStyleBackColor = true;
                        this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
                        // 
                        // radioButton2
                        // 
                        this.radioButton2.AutoSize = true;
                        this.radioButton2.Location = new System.Drawing.Point(69, 78);
                        this.radioButton2.Name = "radioButton2";
                        this.radioButton2.Size = new System.Drawing.Size(138, 21);
                        this.radioButton2.TabIndex = 1;
                        this.radioButton2.Text = "已有个人分析空间";
                        this.radioButton2.UseVisualStyleBackColor = true;
                        this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
                        // 
                        // textEdit2
                        // 
                        this.textEdit2.Location = new System.Drawing.Point(90, 50);
                        this.textEdit2.Name = "textEdit2";
                        this.textEdit2.Size = new System.Drawing.Size(361, 22);
                        this.textEdit2.TabIndex = 2;
                        // 
                        // comboBoxEdit1
                        // 
                        this.comboBoxEdit1.Enabled = false;
                        this.comboBoxEdit1.Location = new System.Drawing.Point(90, 106);
                        this.comboBoxEdit1.Name = "comboBoxEdit1";
                        this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.comboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                        this.comboBoxEdit1.Size = new System.Drawing.Size(361, 22);
                        this.comboBoxEdit1.TabIndex = 3;
                        // 
                        // simpleButton1
                        // 
                        this.simpleButton1.Location = new System.Drawing.Point(379, 237);
                        this.simpleButton1.Name = "simpleButton1";
                        this.simpleButton1.Size = new System.Drawing.Size(55, 23);
                        this.simpleButton1.TabIndex = 3;
                        this.simpleButton1.Text = "确定";
                        this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
                        // 
                        // simpleButton2
                        // 
                        this.simpleButton2.Location = new System.Drawing.Point(440, 237);
                        this.simpleButton2.Name = "simpleButton2";
                        this.simpleButton2.Size = new System.Drawing.Size(55, 23);
                        this.simpleButton2.TabIndex = 4;
                        this.simpleButton2.Text = "取消";
                        this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
                        // 
                        // Dialog_SelectPAnalize
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(516, 274);
                        this.Controls.Add(this.simpleButton2);
                        this.Controls.Add(this.simpleButton1);
                        this.Controls.Add(this.groupBox1);
                        this.Controls.Add(this.textEdit1);
                        this.Controls.Add(this.label1);
                        this.Name = "Dialog_SelectPAnalize";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "数据转存";
                        ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
                        this.groupBox1.ResumeLayout(false);
                        this.groupBox1.PerformLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.Label label1;
                private DevExpress.XtraEditors.TextEdit textEdit1;
                private System.Windows.Forms.GroupBox groupBox1;
                private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
                private DevExpress.XtraEditors.TextEdit textEdit2;
                private System.Windows.Forms.RadioButton radioButton2;
                private System.Windows.Forms.RadioButton radioButton1;
                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private DevExpress.XtraEditors.SimpleButton simpleButton2;

        }
}