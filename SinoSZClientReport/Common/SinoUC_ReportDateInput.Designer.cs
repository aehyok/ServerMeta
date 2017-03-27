namespace SinoSZClientReport.Common
{
        partial class SinoUC_ReportDateInput
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
                        this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
                        this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
                        this.te_EndDate = new DevExpress.XtraEditors.DateEdit();
                        this.te_StartDate = new DevExpress.XtraEditors.DateEdit();
                        ((System.ComponentModel.ISupportInitialize)(this.CB_Report.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_EndDate.Properties.VistaTimeProperties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_EndDate.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_StartDate.Properties.VistaTimeProperties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_StartDate.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // CB_Report
                        // 
                        this.CB_Report.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.CB_Report.Location = new System.Drawing.Point(378, 0);
                        this.CB_Report.Name = "CB_Report";
                        this.CB_Report.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.CB_Report.Size = new System.Drawing.Size(219, 21);
                        this.CB_Report.TabIndex = 12;
                        // 
                        // labelControl3
                        // 
                        this.labelControl3.Appearance.Options.UseTextOptions = true;
                        this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
                        this.labelControl3.Dock = System.Windows.Forms.DockStyle.Left;
                        this.labelControl3.Location = new System.Drawing.Point(299, 0);
                        this.labelControl3.Name = "labelControl3";
                        this.labelControl3.Size = new System.Drawing.Size(79, 21);
                        this.labelControl3.TabIndex = 11;
                        this.labelControl3.Text = "报表名称  ";
                        // 
                        // labelControl2
                        // 
                        this.labelControl2.Appearance.Options.UseTextOptions = true;
                        this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
                        this.labelControl2.Dock = System.Windows.Forms.DockStyle.Left;
                        this.labelControl2.Location = new System.Drawing.Point(177, 0);
                        this.labelControl2.Name = "labelControl2";
                        this.labelControl2.Size = new System.Drawing.Size(22, 21);
                        this.labelControl2.TabIndex = 10;
                        this.labelControl2.Text = "至";
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
                        this.labelControl4.TabIndex = 13;
                        this.labelControl4.Text = "统计日期 ";
                        // 
                        // te_EndDate
                        // 
                        this.te_EndDate.Dock = System.Windows.Forms.DockStyle.Left;
                        this.te_EndDate.EditValue = null;
                        this.te_EndDate.Location = new System.Drawing.Point(199, 0);
                        this.te_EndDate.Name = "te_EndDate";
                        this.te_EndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.te_EndDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
                        this.te_EndDate.Size = new System.Drawing.Size(100, 21);
                        this.te_EndDate.TabIndex = 14;
                        // 
                        // te_StartDate
                        // 
                        this.te_StartDate.Dock = System.Windows.Forms.DockStyle.Left;
                        this.te_StartDate.EditValue = null;
                        this.te_StartDate.Location = new System.Drawing.Point(77, 0);
                        this.te_StartDate.Name = "te_StartDate";
                        this.te_StartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.te_StartDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
                        this.te_StartDate.Size = new System.Drawing.Size(100, 21);
                        this.te_StartDate.TabIndex = 15;
                        // 
                        // SinoUC_ReportDateInput
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.CB_Report);
                        this.Controls.Add(this.labelControl3);
                        this.Controls.Add(this.te_EndDate);
                        this.Controls.Add(this.labelControl2);
                        this.Controls.Add(this.te_StartDate);
                        this.Controls.Add(this.labelControl4);
                        this.Name = "SinoUC_ReportDateInput";
                        this.Size = new System.Drawing.Size(597, 21);
                        ((System.ComponentModel.ISupportInitialize)(this.CB_Report.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_EndDate.Properties.VistaTimeProperties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_EndDate.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_StartDate.Properties.VistaTimeProperties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_StartDate.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.ComboBoxEdit CB_Report;
                private DevExpress.XtraEditors.LabelControl labelControl3;
                private DevExpress.XtraEditors.LabelControl labelControl2;
                private DevExpress.XtraEditors.LabelControl labelControl4;
                private DevExpress.XtraEditors.DateEdit te_EndDate;
                private DevExpress.XtraEditors.DateEdit te_StartDate;
        }
}
