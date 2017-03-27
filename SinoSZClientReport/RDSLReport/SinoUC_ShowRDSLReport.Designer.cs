namespace SinoSZClientReport.RDSLReport
{
        partial class SinoUC_ShowRDSLReport
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
                        this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
                        this.SuspendLayout();
                        // 
                        // reportViewer1
                        // 
                        this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "SinoSZClientReport.RDSLReport.JS01.rdlc";
                        this.reportViewer1.Location = new System.Drawing.Point(0, 0);
                        this.reportViewer1.Name = "reportViewer1";
                        this.reportViewer1.Size = new System.Drawing.Size(812, 554);
                        this.reportViewer1.TabIndex = 0;
                        // 
                        // SinoUC_ShowRDSLReport
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.BackColor = System.Drawing.Color.Transparent;
                        this.Controls.Add(this.reportViewer1);
                        this.Name = "SinoUC_ShowRDSLReport";
                        this.Size = new System.Drawing.Size(812, 554);
                        this.ResumeLayout(false);

                }

                #endregion

                private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        }
}
