namespace SinoSZMetaDataQuery.GuideLineQuery
{
        partial class frmGuideLineQueryWithoutInput
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
                        this.sinoSZUC_GuideLineQueryResult1 = new SinoSZMetaDataQuery.GuideLineQuery.SinoSZUC_GuideLineQueryResult();
                        this.SuspendLayout();
                        // 
                        // sinoSZUC_GuideLineQueryResult1
                        // 
                        this.sinoSZUC_GuideLineQueryResult1.CanGrouped = true;
                        this.sinoSZUC_GuideLineQueryResult1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.sinoSZUC_GuideLineQueryResult1.Location = new System.Drawing.Point(10, 10);
                        this.sinoSZUC_GuideLineQueryResult1.Name = "sinoSZUC_GuideLineQueryResult1";
                        this.sinoSZUC_GuideLineQueryResult1.Size = new System.Drawing.Size(837, 519);
                        this.sinoSZUC_GuideLineQueryResult1.TabIndex = 0;
                        this.sinoSZUC_GuideLineQueryResult1.QueryFinished += new System.EventHandler(this.sinoSZUC_GuideLineQueryResult1_QueryFinished);
                        this.sinoSZUC_GuideLineQueryResult1.ShowDetailData += new System.EventHandler(this.sinoSZUC_GuideLineQueryResult1_ShowDetailData);
                        // 
                        // frmGuideLineQueryWithoutInput
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(857, 539);
                        this.Controls.Add(this.sinoSZUC_GuideLineQueryResult1);
                        this.Name = "frmGuideLineQueryWithoutInput";
                        this.Padding = new System.Windows.Forms.Padding(10);
                        this.Text = "frmGuideLineQueryWithoutInput";
                        this.Load += new System.EventHandler(this.frmGuideLineQueryWithoutInput_Load);
                        this.ResumeLayout(false);

                }

                #endregion

                private SinoSZUC_GuideLineQueryResult sinoSZUC_GuideLineQueryResult1;
        }
}