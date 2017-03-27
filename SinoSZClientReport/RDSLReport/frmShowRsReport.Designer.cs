namespace SinoSZClientReport.RDSLReport
{
        partial class frmShowRsReport
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
                        this.sinoUC_ShowRDSLReport1 = new SinoSZClientReport.RDSLReport.SinoUC_ShowRDSLReport();
                        this.SuspendLayout();
                        // 
                        // sinoUC_ShowRDSLReport1
                        // 
                        this.sinoUC_ShowRDSLReport1.BackColor = System.Drawing.Color.Transparent;
                        this.sinoUC_ShowRDSLReport1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.sinoUC_ShowRDSLReport1.Location = new System.Drawing.Point(10, 10);
                        this.sinoUC_ShowRDSLReport1.Name = "sinoUC_ShowRDSLReport1";
                        this.sinoUC_ShowRDSLReport1.Size = new System.Drawing.Size(902, 539);
                        this.sinoUC_ShowRDSLReport1.TabIndex = 0;
                        // 
                        // frmShowRsReport
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(922, 559);
                        this.Controls.Add(this.sinoUC_ShowRDSLReport1);
                        this.Name = "frmShowRsReport";
                        this.Padding = new System.Windows.Forms.Padding(10);
                        this.Text = "浏览报表";
                        this.Load += new System.EventHandler(this.frmShowRsReport_Load);
                        this.ResumeLayout(false);

                }

                #endregion

                private SinoUC_ShowRDSLReport sinoUC_ShowRDSLReport1;
        }
}