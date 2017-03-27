namespace SinoSZMetaDataQuery.DataSearch
{
        partial class SinoSZUC_SearchItem
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

                #region Component Designer generated code

                /// <summary> 
                /// Required method for Designer support - do not modify 
                /// the contents of this method with the code editor.
                /// </summary>
                private void InitializeComponent()
                {
                        this.panel1 = new System.Windows.Forms.Panel();
                        this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
                        this.panel2 = new System.Windows.Forms.Panel();
                        this.label1 = new System.Windows.Forms.Label();
                        this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
                        this.panel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // panel1
                        // 
                        this.panel1.Controls.Add(this.textEdit1);
                        this.panel1.Controls.Add(this.panel2);
                        this.panel1.Controls.Add(this.label1);
                        this.panel1.Controls.Add(this.radioGroup1);
                        this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
                        this.panel1.Location = new System.Drawing.Point(20, 16);
                        this.panel1.Name = "panel1";
                        this.panel1.Size = new System.Drawing.Size(633, 23);
                        this.panel1.TabIndex = 0;
                        // 
                        // textEdit1
                        // 
                        this.textEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.textEdit1.Location = new System.Drawing.Point(65, 0);
                        this.textEdit1.Name = "textEdit1";
                        this.textEdit1.Properties.AutoHeight = false;
                        this.textEdit1.Size = new System.Drawing.Size(457, 23);
                        this.textEdit1.TabIndex = 1;
                        // 
                        // panel2
                        // 
                        this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
                        this.panel2.Location = new System.Drawing.Point(522, 0);
                        this.panel2.Name = "panel2";
                        this.panel2.Size = new System.Drawing.Size(11, 23);
                        this.panel2.TabIndex = 2;
                        // 
                        // label1
                        // 
                        this.label1.Dock = System.Windows.Forms.DockStyle.Left;
                        this.label1.Location = new System.Drawing.Point(0, 0);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(65, 23);
                        this.label1.TabIndex = 0;
                        this.label1.Text = "检索内容";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // radioGroup1
                        // 
                        this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Right;
                        this.radioGroup1.Location = new System.Drawing.Point(533, 0);
                        this.radioGroup1.Name = "radioGroup1";
                        this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
                        this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
                        this.radioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                        this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("模糊", "模糊"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("精确", "精确")});
                        this.radioGroup1.Size = new System.Drawing.Size(100, 23);
                        this.radioGroup1.TabIndex = 1;
                        // 
                        // SinoSZUC_SearchItem
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.panel1);
                        this.Name = "SinoSZUC_SearchItem";
                        this.Padding = new System.Windows.Forms.Padding(20, 16, 20, 0);
                        this.Size = new System.Drawing.Size(673, 67);
                        this.panel1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.Panel panel1;
                private System.Windows.Forms.Label label1;
                private DevExpress.XtraEditors.TextEdit textEdit1;
                private System.Windows.Forms.Panel panel2;
                private DevExpress.XtraEditors.RadioGroup radioGroup1;
        }
}
