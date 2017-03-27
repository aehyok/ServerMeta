namespace SinoSZMetaDataQuery.GuideLineQuery
{
        partial class SinoSZUC_GuideLineQueryInput
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
                        this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
                        this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
                        this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
                        this.InputPanel = new DevExpress.XtraEditors.XtraScrollableControl();
                        ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
                        this.xtraTabControl1.SuspendLayout();
                        this.xtraTabPage1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
                        this.panelControl1.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // xtraTabControl1
                        // 
                        this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
                        this.xtraTabControl1.LookAndFeel.UseDefaultLookAndFeel = false;
                        this.xtraTabControl1.Name = "xtraTabControl1";
                        this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
                        this.xtraTabControl1.Size = new System.Drawing.Size(657, 185);
                        this.xtraTabControl1.TabIndex = 7;
                        this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
                        this.xtraTabControl1.Text = "xtraTabControl1";
                        // 
                        // xtraTabPage1
                        // 
                        this.xtraTabPage1.Controls.Add(this.panelControl1);
                        this.xtraTabPage1.Name = "xtraTabPage1";
                        this.xtraTabPage1.Padding = new System.Windows.Forms.Padding(5);
                        this.xtraTabPage1.Size = new System.Drawing.Size(648, 153);
                        this.xtraTabPage1.Text = "指标查询条件设置";
                        // 
                        // panelControl1
                        // 
                        this.panelControl1.Controls.Add(this.InputPanel);
                        this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.panelControl1.Location = new System.Drawing.Point(5, 5);
                        this.panelControl1.Name = "panelControl1";
                        this.panelControl1.Size = new System.Drawing.Size(638, 143);
                        this.panelControl1.TabIndex = 2;
                        // 
                        // InputPanel
                        // 
                        this.InputPanel.AllowDrop = true;
                        this.InputPanel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(240)))));
                        this.InputPanel.Appearance.BackColor2 = System.Drawing.Color.White;
                        this.InputPanel.Appearance.Options.UseBackColor = true;
                        this.InputPanel.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.InputPanel.Location = new System.Drawing.Point(2, 2);
                        this.InputPanel.Name = "InputPanel";
                        this.InputPanel.Padding = new System.Windows.Forms.Padding(3);
                        this.InputPanel.Size = new System.Drawing.Size(634, 139);
                        this.InputPanel.TabIndex = 1;
                        // 
                        // SinoSZUC_GuideLineQueryInput
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.xtraTabControl1);
                        this.Name = "SinoSZUC_GuideLineQueryInput";
                        this.Size = new System.Drawing.Size(657, 185);
                        ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
                        this.xtraTabControl1.ResumeLayout(false);
                        this.xtraTabPage1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
                        this.panelControl1.ResumeLayout(false);
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
                private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
                private DevExpress.XtraEditors.PanelControl panelControl1;
                private DevExpress.XtraEditors.XtraScrollableControl InputPanel;
        }
}
