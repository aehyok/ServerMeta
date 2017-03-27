namespace SinoSZClientReport.Common
{
        partial class SinoUC_InputReportHalfYear
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
                        this.CB_Year = new DevExpress.XtraEditors.ComboBoxEdit();
                        this.panel3 = new System.Windows.Forms.Panel();
                        this.label4 = new System.Windows.Forms.Label();
                        this.panel2 = new System.Windows.Forms.Panel();
                        this.CB_Season = new DevExpress.XtraEditors.ComboBoxEdit();
                        this.panel4 = new System.Windows.Forms.Panel();
                        this.label1 = new System.Windows.Forms.Label();
                        this.panel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.CB_Year.Properties)).BeginInit();
                        this.panel2.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.CB_Season.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // panel1
                        // 
                        this.panel1.Controls.Add(this.CB_Year);
                        this.panel1.Controls.Add(this.panel3);
                        this.panel1.Controls.Add(this.label4);
                        this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
                        this.panel1.Location = new System.Drawing.Point(0, 0);
                        this.panel1.Name = "panel1";
                        this.panel1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
                        this.panel1.Size = new System.Drawing.Size(375, 25);
                        this.panel1.TabIndex = 4;
                        // 
                        // CB_Year
                        // 
                        this.CB_Year.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.CB_Year.Location = new System.Drawing.Point(78, 2);
                        this.CB_Year.Name = "CB_Year";
                        this.CB_Year.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.CB_Year.Size = new System.Drawing.Size(297, 21);
                        this.CB_Year.TabIndex = 11;
                        // 
                        // panel3
                        // 
                        this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
                        this.panel3.Location = new System.Drawing.Point(74, 2);
                        this.panel3.Name = "panel3";
                        this.panel3.Size = new System.Drawing.Size(4, 21);
                        this.panel3.TabIndex = 12;
                        // 
                        // label4
                        // 
                        this.label4.Dock = System.Windows.Forms.DockStyle.Left;
                        this.label4.Location = new System.Drawing.Point(0, 2);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(74, 21);
                        this.label4.TabIndex = 10;
                        this.label4.Text = "统计年份";
                        this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // panel2
                        // 
                        this.panel2.Controls.Add(this.CB_Season);
                        this.panel2.Controls.Add(this.panel4);
                        this.panel2.Controls.Add(this.label1);
                        this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
                        this.panel2.Location = new System.Drawing.Point(0, 25);
                        this.panel2.Name = "panel2";
                        this.panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
                        this.panel2.Size = new System.Drawing.Size(375, 25);
                        this.panel2.TabIndex = 5;
                        // 
                        // CB_Season
                        // 
                        this.CB_Season.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.CB_Season.EditValue = "上半年";
                        this.CB_Season.Location = new System.Drawing.Point(78, 2);
                        this.CB_Season.Name = "CB_Season";
                        this.CB_Season.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.CB_Season.Properties.Items.AddRange(new object[] {
            "上半年",
            "下半年"});
                        this.CB_Season.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                        this.CB_Season.Size = new System.Drawing.Size(297, 21);
                        this.CB_Season.TabIndex = 11;
                        // 
                        // panel4
                        // 
                        this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
                        this.panel4.Location = new System.Drawing.Point(74, 2);
                        this.panel4.Name = "panel4";
                        this.panel4.Size = new System.Drawing.Size(4, 21);
                        this.panel4.TabIndex = 12;
                        // 
                        // label1
                        // 
                        this.label1.Dock = System.Windows.Forms.DockStyle.Left;
                        this.label1.Location = new System.Drawing.Point(0, 2);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(74, 21);
                        this.label1.TabIndex = 10;
                        this.label1.Text = "统计年度";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // SinoUC_InputReportHalfYear
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.panel2);
                        this.Controls.Add(this.panel1);
                        this.Name = "SinoUC_InputReportHalfYear";
                        this.Size = new System.Drawing.Size(375, 50);
                        this.panel1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.CB_Year.Properties)).EndInit();
                        this.panel2.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.CB_Season.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.Panel panel1;
                private DevExpress.XtraEditors.ComboBoxEdit CB_Year;
                private System.Windows.Forms.Panel panel3;
                private System.Windows.Forms.Label label4;
                private System.Windows.Forms.Panel panel2;
                private DevExpress.XtraEditors.ComboBoxEdit CB_Season;
                private System.Windows.Forms.Panel panel4;
                private System.Windows.Forms.Label label1;
        }
}
