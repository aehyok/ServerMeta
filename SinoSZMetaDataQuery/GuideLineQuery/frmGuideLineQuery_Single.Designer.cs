namespace SinoSZMetaDataQuery.GuideLineQuery
{
        partial class frmGuideLineQuery_Single
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
            this.sinoSZUC_GuideLineDynamicInput21 = new SinoSZMetaDataQuery.GuideLineQuery.SinoSZUC_GuideLineDynamicInput2();
            this.sinoSZUC_GuideLineQueryResult1 = new SinoSZMetaDataQuery.GuideLineQuery.SinoSZUC_GuideLineQueryResult();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sinoSZUC_GuideLineDynamicInput21
            // 
            this.sinoSZUC_GuideLineDynamicInput21.BackColor = System.Drawing.Color.Transparent;
            this.sinoSZUC_GuideLineDynamicInput21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sinoSZUC_GuideLineDynamicInput21.Location = new System.Drawing.Point(2, 22);
            this.sinoSZUC_GuideLineDynamicInput21.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.sinoSZUC_GuideLineDynamicInput21.Name = "sinoSZUC_GuideLineDynamicInput21";
            this.sinoSZUC_GuideLineDynamicInput21.Size = new System.Drawing.Size(1218, 31);
            this.sinoSZUC_GuideLineDynamicInput21.TabIndex = 2;
            this.sinoSZUC_GuideLineDynamicInput21.InputChanged += new System.EventHandler(this.sinoSZUC_GuideLineDynamicInput21_InputChanged);
            // 
            // sinoSZUC_GuideLineQueryResult1
            // 
            this.sinoSZUC_GuideLineQueryResult1.CanGrouped = true;
            this.sinoSZUC_GuideLineQueryResult1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sinoSZUC_GuideLineQueryResult1.Location = new System.Drawing.Point(13, 90);
            this.sinoSZUC_GuideLineQueryResult1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.sinoSZUC_GuideLineQueryResult1.Name = "sinoSZUC_GuideLineQueryResult1";
            this.sinoSZUC_GuideLineQueryResult1.Size = new System.Drawing.Size(1222, 709);
            this.sinoSZUC_GuideLineQueryResult1.TabIndex = 7;
            this.sinoSZUC_GuideLineQueryResult1.ShowDetailData += new System.EventHandler(this.sinoSZUC_GuideLineQueryResult1_ShowDetailData);
            this.sinoSZUC_GuideLineQueryResult1.QueryFinished += new System.EventHandler(this.sinoSZUC_GuideLineQueryResult1_QueryFinished);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.sinoSZUC_GuideLineDynamicInput21);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(13, 15);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.panelControl1.Size = new System.Drawing.Size(1222, 75);
            this.panelControl1.TabIndex = 8;
            // 
            // frmGuideLineQuery_Single
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 814);
            this.Controls.Add(this.sinoSZUC_GuideLineQueryResult1);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "frmGuideLineQuery_Single";
            this.Padding = new System.Windows.Forms.Padding(13, 15, 13, 15);
            this.Text = "frmGuideLineQuery_Single";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

                }

                #endregion

                private SinoSZUC_GuideLineDynamicInput2 sinoSZUC_GuideLineDynamicInput21;
                private SinoSZUC_GuideLineQueryResult sinoSZUC_GuideLineQueryResult1;
                private DevExpress.XtraEditors.PanelControl panelControl1;

        }
}