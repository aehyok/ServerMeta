namespace SinoSZMetaDataQuery.GuideLineQuery
{
        partial class SinoSZ_GuideLineQuery
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
                        this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
                        this.sinoSZUC_GuideLineQueryInput1 = new SinoSZMetaDataQuery.GuideLineQuery.SinoSZUC_GuideLineQueryInput();
                        this.sinoSZUC_GuideLineQueryResult1 = new SinoSZMetaDataQuery.GuideLineQuery.SinoSZUC_GuideLineQueryResult();
                        ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
                        this.splitContainerControl1.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // splitContainerControl1
                        // 
                        this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.splitContainerControl1.Horizontal = false;
                        this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
                        this.splitContainerControl1.Name = "splitContainerControl1";
                        this.splitContainerControl1.Panel1.Controls.Add(this.sinoSZUC_GuideLineQueryInput1);
                        this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(5);
                        this.splitContainerControl1.Panel1.Text = "Panel1";
                        this.splitContainerControl1.Panel2.Controls.Add(this.sinoSZUC_GuideLineQueryResult1);
                        this.splitContainerControl1.Panel2.Padding = new System.Windows.Forms.Padding(5);
                        this.splitContainerControl1.Panel2.Text = "Panel2";
                        this.splitContainerControl1.Size = new System.Drawing.Size(560, 546);
                        this.splitContainerControl1.SplitterPosition = 142;
                        this.splitContainerControl1.TabIndex = 0;
                        this.splitContainerControl1.Text = "splitContainerControl1";
                        // 
                        // sinoSZUC_GuideLineQueryInput1
                        // 
                        this.sinoSZUC_GuideLineQueryInput1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.sinoSZUC_GuideLineQueryInput1.Location = new System.Drawing.Point(5, 4);
                        this.sinoSZUC_GuideLineQueryInput1.Name = "sinoSZUC_GuideLineQueryInput1";
                        this.sinoSZUC_GuideLineQueryInput1.Size = new System.Drawing.Size(546, 129);
                        this.sinoSZUC_GuideLineQueryInput1.TabIndex = 0;
                        this.sinoSZUC_GuideLineQueryInput1.InputChanged += new System.EventHandler(this.sinoSZUC_GuideLineQueryInput1_InputChanged);
                        // 
                        // sinoSZUC_GuideLineQueryResult1
                        // 
                        this.sinoSZUC_GuideLineQueryResult1.CanGrouped = true;
                        this.sinoSZUC_GuideLineQueryResult1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.sinoSZUC_GuideLineQueryResult1.Location = new System.Drawing.Point(5, 4);
                        this.sinoSZUC_GuideLineQueryResult1.Name = "sinoSZUC_GuideLineQueryResult1";
                        this.sinoSZUC_GuideLineQueryResult1.Size = new System.Drawing.Size(546, 385);
                        this.sinoSZUC_GuideLineQueryResult1.TabIndex = 0;
                        this.sinoSZUC_GuideLineQueryResult1.QueryFinished += new System.EventHandler(this.sinoSZUC_GuideLineQueryResult1_QueryFinished);
                        this.sinoSZUC_GuideLineQueryResult1.ShowDetailData += new System.EventHandler(this.sinoSZUC_GuideLineQueryResult1_ShowDetailData);
                        // 
                        // SinoSZ_GuideLineQuery
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.splitContainerControl1);
                        this.Name = "SinoSZ_GuideLineQuery";
                        this.Size = new System.Drawing.Size(560, 546);
                        ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
                        this.splitContainerControl1.ResumeLayout(false);
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
                private SinoSZUC_GuideLineQueryInput sinoSZUC_GuideLineQueryInput1;
                private SinoSZUC_GuideLineQueryResult sinoSZUC_GuideLineQueryResult1;
        }
}
