namespace SinoSZClientReport.Common
{
        partial class SinoUC_InputReportYear
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
                        this.label4 = new System.Windows.Forms.Label();
                        this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
                        this.panel1 = new System.Windows.Forms.Panel();
                        ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // label4
                        // 
                        this.label4.Dock = System.Windows.Forms.DockStyle.Left;
                        this.label4.Location = new System.Drawing.Point(0, 2);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(74, 21);
                        this.label4.TabIndex = 7;
                        this.label4.Text = "统计年份";
                        this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // comboBoxEdit1
                        // 
                        this.comboBoxEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.comboBoxEdit1.Location = new System.Drawing.Point(78, 2);
                        this.comboBoxEdit1.Name = "comboBoxEdit1";
                        this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.comboBoxEdit1.Size = new System.Drawing.Size(295, 21);
                        this.comboBoxEdit1.TabIndex = 8;
                        // 
                        // panel1
                        // 
                        this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
                        this.panel1.Location = new System.Drawing.Point(74, 2);
                        this.panel1.Name = "panel1";
                        this.panel1.Size = new System.Drawing.Size(4, 21);
                        this.panel1.TabIndex = 9;
                        // 
                        // SinoUC_InputReportYear
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.comboBoxEdit1);
                        this.Controls.Add(this.panel1);
                        this.Controls.Add(this.label4);
                        this.Name = "SinoUC_InputReportYear";
                        this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
                        this.Size = new System.Drawing.Size(373, 25);
                        ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.Label label4;
                private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
                private System.Windows.Forms.Panel panel1;
        }
}
