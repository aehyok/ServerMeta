namespace SinoSZClientReport.Common
{
        partial class SinoUC_ReportYearInput
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
                        this.CB_Year = new DevExpress.XtraEditors.ComboBoxEdit();
                        this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
                        this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
                        this.CB_Report = new DevExpress.XtraEditors.ComboBoxEdit();
                        this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
                        ((System.ComponentModel.ISupportInitialize)(this.CB_Year.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.CB_Report.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // CB_Year
                        // 
                        this.CB_Year.Dock = System.Windows.Forms.DockStyle.Right;
                        this.CB_Year.EditValue = "";
                        this.CB_Year.Location = new System.Drawing.Point(514, 0);
                        this.CB_Year.Name = "CB_Year";
                        this.CB_Year.Properties.Appearance.Options.UseTextOptions = true;
                        this.CB_Year.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        this.CB_Year.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.CB_Year.Size = new System.Drawing.Size(61, 21);
                        this.CB_Year.TabIndex = 0;
                        // 
                        // labelControl1
                        // 
                        this.labelControl1.Appearance.Options.UseTextOptions = true;
                        this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
                        this.labelControl1.Dock = System.Windows.Forms.DockStyle.Right;
                        this.labelControl1.Location = new System.Drawing.Point(575, 0);
                        this.labelControl1.Name = "labelControl1";
                        this.labelControl1.Size = new System.Drawing.Size(22, 21);
                        this.labelControl1.TabIndex = 1;
                        this.labelControl1.Text = "年";
                        // 
                        // labelControl3
                        // 
                        this.labelControl3.Appearance.Options.UseTextOptions = true;
                        this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
                        this.labelControl3.Dock = System.Windows.Forms.DockStyle.Left;
                        this.labelControl3.Location = new System.Drawing.Point(0, 0);
                        this.labelControl3.Name = "labelControl3";
                        this.labelControl3.Size = new System.Drawing.Size(79, 21);
                        this.labelControl3.TabIndex = 4;
                        this.labelControl3.Text = "报表名称  ";
                        // 
                        // CB_Report
                        // 
                        this.CB_Report.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.CB_Report.Location = new System.Drawing.Point(79, 0);
                        this.CB_Report.Name = "CB_Report";
                        this.CB_Report.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.CB_Report.Size = new System.Drawing.Size(358, 21);
                        this.CB_Report.TabIndex = 5;
                        // 
                        // labelControl4
                        // 
                        this.labelControl4.Appearance.Options.UseTextOptions = true;
                        this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
                        this.labelControl4.Dock = System.Windows.Forms.DockStyle.Right;
                        this.labelControl4.Location = new System.Drawing.Point(437, 0);
                        this.labelControl4.Name = "labelControl4";
                        this.labelControl4.Size = new System.Drawing.Size(77, 21);
                        this.labelControl4.TabIndex = 6;
                        this.labelControl4.Text = "统计年份  ";
                        // 
                        // SinoUC_ReportYearInput
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.BackColor = System.Drawing.Color.Transparent;
                        this.Controls.Add(this.CB_Report);
                        this.Controls.Add(this.labelControl4);
                        this.Controls.Add(this.CB_Year);
                        this.Controls.Add(this.labelControl3);
                        this.Controls.Add(this.labelControl1);
                        this.Name = "SinoUC_ReportYearInput";
                        this.Size = new System.Drawing.Size(597, 21);
                        ((System.ComponentModel.ISupportInitialize)(this.CB_Year.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.CB_Report.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.ComboBoxEdit CB_Year;
                private DevExpress.XtraEditors.LabelControl labelControl1;
                private DevExpress.XtraEditors.LabelControl labelControl3;
                private DevExpress.XtraEditors.ComboBoxEdit CB_Report;
                private DevExpress.XtraEditors.LabelControl labelControl4;
        }
}
