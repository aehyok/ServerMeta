namespace SinoSZMetaDataManager
{
        partial class Dialog_MoveFieldToGroup
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
                        this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
                        this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
                        this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
                        ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // label1
                        // 
                        this.label1.AutoSize = true;
                        this.label1.Location = new System.Drawing.Point(13, 31);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(67, 14);
                        this.label1.TabIndex = 0;
                        this.label1.Text = "移往组名称";
                        // 
                        // comboBoxEdit1
                        // 
                        this.comboBoxEdit1.Location = new System.Drawing.Point(87, 28);
                        this.comboBoxEdit1.Name = "comboBoxEdit1";
                        this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.comboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                        this.comboBoxEdit1.Size = new System.Drawing.Size(213, 21);
                        this.comboBoxEdit1.TabIndex = 1;
                        // 
                        // simpleButton1
                        // 
                        this.simpleButton1.Location = new System.Drawing.Point(168, 81);
                        this.simpleButton1.Name = "simpleButton1";
                        this.simpleButton1.Size = new System.Drawing.Size(63, 23);
                        this.simpleButton1.TabIndex = 2;
                        this.simpleButton1.Text = "确定";
                        this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
                        // 
                        // simpleButton2
                        // 
                        this.simpleButton2.Location = new System.Drawing.Point(237, 81);
                        this.simpleButton2.Name = "simpleButton2";
                        this.simpleButton2.Size = new System.Drawing.Size(63, 23);
                        this.simpleButton2.TabIndex = 3;
                        this.simpleButton2.Text = "取消";
                        this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
                        // 
                        // Dialog_MoveFieldToGroup
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(320, 125);
                        this.Controls.Add(this.simpleButton2);
                        this.Controls.Add(this.simpleButton1);
                        this.Controls.Add(this.comboBoxEdit1);
                        this.Controls.Add(this.label1);
                        this.Name = "Dialog_MoveFieldToGroup";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "移往其它组";
                        ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private System.Windows.Forms.Label label1;
                private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private DevExpress.XtraEditors.SimpleButton simpleButton2;
        }
}