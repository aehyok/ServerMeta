namespace SinoSZMetaDataManager
{
        partial class Dialog_EditGuideLineRefTable
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
                        this.label2 = new System.Windows.Forms.Label();
                        this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
                        ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(45, 21);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(79, 19);
                        this.label1.TabIndex = 0;
                        this.label1.Text = "代码表名称";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // buttonEdit1
                        // 
                        this.buttonEdit1.Location = new System.Drawing.Point(130, 18);
                        this.buttonEdit1.Name = "buttonEdit1";
                        this.buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
                        this.buttonEdit1.Size = new System.Drawing.Size(220, 21);
                        this.buttonEdit1.TabIndex = 1;
                        // 
                        // checkEdit1
                        // 
                        this.checkEdit1.Location = new System.Drawing.Point(129, 73);
                        this.checkEdit1.Name = "checkEdit1";
                        this.checkEdit1.Properties.Caption = "代码表为树型时,包含下级代码";
                        this.checkEdit1.Size = new System.Drawing.Size(238, 19);
                        this.checkEdit1.TabIndex = 2;
                        // 
                        // simpleButton1
                        // 
                        this.simpleButton1.Location = new System.Drawing.Point(287, 108);
                        this.simpleButton1.Name = "simpleButton1";
                        this.simpleButton1.Size = new System.Drawing.Size(57, 23);
                        this.simpleButton1.TabIndex = 3;
                        this.simpleButton1.Text = "取消";
                        this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
                        // 
                        // simpleButton2
                        // 
                        this.simpleButton2.Location = new System.Drawing.Point(224, 108);
                        this.simpleButton2.Name = "simpleButton2";
                        this.simpleButton2.Size = new System.Drawing.Size(57, 23);
                        this.simpleButton2.TabIndex = 4;
                        this.simpleButton2.Text = "确定";
                        this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(12, 48);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(124, 19);
                        this.label2.TabIndex = 5;
                        this.label2.Text = "选择\"全部\"的代码";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // textEdit1
                        // 
                        this.textEdit1.Location = new System.Drawing.Point(130, 46);
                        this.textEdit1.Name = "textEdit1";
                        this.textEdit1.Size = new System.Drawing.Size(219, 21);
                        this.textEdit1.TabIndex = 6;
                        // 
                        // Dialog_EditGuideLineRefTable
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(373, 156);
                        this.Controls.Add(this.textEdit1);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.simpleButton2);
                        this.Controls.Add(this.simpleButton1);
                        this.Controls.Add(this.checkEdit1);
                        this.Controls.Add(this.buttonEdit1);
                        this.Controls.Add(this.label1);
                        this.Name = "Dialog_EditGuideLineRefTable";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "使用代码表参数定义";
                        this.Load += new System.EventHandler(this.Dialog_EditGuideLineRefTable_Load);
                        ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.Label label1;
                private DevExpress.XtraEditors.ButtonEdit buttonEdit1;
                private DevExpress.XtraEditors.CheckEdit checkEdit1;
                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private DevExpress.XtraEditors.SimpleButton simpleButton2;
                private System.Windows.Forms.Label label2;
                private DevExpress.XtraEditors.TextEdit textEdit1;
        }
}