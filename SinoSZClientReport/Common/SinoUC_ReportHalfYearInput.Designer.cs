namespace SinoSZClientReport.Common
{
        partial class SinoUC_ReportHalfYearInput
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
                        this.CB_Report = new DevExpress.XtraEditors.ComboBoxEdit();
                        this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
                        this.cb_Half = new DevExpress.XtraEditors.ComboBoxEdit();
                        this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
                        this.CB_Year = new DevExpress.XtraEditors.ComboBoxEdit();
                        this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
                        ((System.ComponentModel.ISupportInitialize)(this.CB_Report.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.cb_Half.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.CB_Year.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // CB_Report
                        // 
                        this.CB_Report.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.CB_Report.Location = new System.Drawing.Point(309, 0);
                        this.CB_Report.Name = "CB_Report";
                        this.CB_Report.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.CB_Report.Size = new System.Drawing.Size(262, 21);
                        this.CB_Report.TabIndex = 19;
                        // 
                        // labelControl3
                        // 
                        this.labelControl3.Appearance.Options.UseTextOptions = true;
                        this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
                        this.labelControl3.Dock = System.Windows.Forms.DockStyle.Left;
                        this.labelControl3.Location = new System.Drawing.Point(230, 0);
                        this.labelControl3.Name = "labelControl3";
                        this.labelControl3.Size = new System.Drawing.Size(79, 21);
                        this.labelControl3.TabIndex = 18;
                        this.labelControl3.Text = "报表名称  ";
                        // 
                        // cb_Half
                        // 
                        this.cb_Half.Dock = System.Windows.Forms.DockStyle.Left;
                        this.cb_Half.EditValue = "上半年";
                        this.cb_Half.Location = new System.Drawing.Point(160, 0);
                        this.cb_Half.Name = "cb_Half";
                        this.cb_Half.Properties.Appearance.Options.UseTextOptions = true;
                        this.cb_Half.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        this.cb_Half.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.cb_Half.Properties.Items.AddRange(new object[] {
            "上半年",
            "下半年"});
                        this.cb_Half.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                        this.cb_Half.Size = new System.Drawing.Size(70, 21);
                        this.cb_Half.TabIndex = 16;
                        // 
                        // labelControl1
                        // 
                        this.labelControl1.Appearance.Options.UseTextOptions = true;
                        this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
                        this.labelControl1.Dock = System.Windows.Forms.DockStyle.Left;
                        this.labelControl1.Location = new System.Drawing.Point(138, 0);
                        this.labelControl1.Name = "labelControl1";
                        this.labelControl1.Size = new System.Drawing.Size(22, 21);
                        this.labelControl1.TabIndex = 15;
                        this.labelControl1.Text = "年";
                        // 
                        // CB_Year
                        // 
                        this.CB_Year.Dock = System.Windows.Forms.DockStyle.Left;
                        this.CB_Year.EditValue = "";
                        this.CB_Year.Location = new System.Drawing.Point(77, 0);
                        this.CB_Year.Name = "CB_Year";
                        this.CB_Year.Properties.Appearance.Options.UseTextOptions = true;
                        this.CB_Year.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        this.CB_Year.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.CB_Year.Size = new System.Drawing.Size(61, 21);
                        this.CB_Year.TabIndex = 14;
                        // 
                        // labelControl4
                        // 
                        this.labelControl4.Appearance.Options.UseTextOptions = true;
                        this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
                        this.labelControl4.Dock = System.Windows.Forms.DockStyle.Left;
                        this.labelControl4.Location = new System.Drawing.Point(0, 0);
                        this.labelControl4.Name = "labelControl4";
                        this.labelControl4.Size = new System.Drawing.Size(77, 21);
                        this.labelControl4.TabIndex = 20;
                        this.labelControl4.Text = "统计时间";
                        // 
                        // SinoUC_ReportHalfYearInput
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.CB_Report);
                        this.Controls.Add(this.labelControl3);
                        this.Controls.Add(this.cb_Half);
                        this.Controls.Add(this.labelControl1);
                        this.Controls.Add(this.CB_Year);
                        this.Controls.Add(this.labelControl4);
                        this.Name = "SinoUC_ReportHalfYearInput";
                        this.Size = new System.Drawing.Size(571, 21);
                        ((System.ComponentModel.ISupportInitialize)(this.CB_Report.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.cb_Half.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.CB_Year.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.ComboBoxEdit CB_Report;
                private DevExpress.XtraEditors.LabelControl labelControl3;
                private DevExpress.XtraEditors.ComboBoxEdit cb_Half;
                private DevExpress.XtraEditors.LabelControl labelControl1;
                private DevExpress.XtraEditors.ComboBoxEdit CB_Year;
                private DevExpress.XtraEditors.LabelControl labelControl4;
        }
}
