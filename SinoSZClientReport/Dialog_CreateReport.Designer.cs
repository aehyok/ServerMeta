namespace SinoSZClientReport
{
        partial class Dialog_CreateReport
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
            this.label1 = new System.Windows.Forms.Label();
            this.CB_Report = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.CB_ORG = new DevExpress.XtraEditors.ComboBoxEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sinoUC_InputReportMonth1 = new SinoSZClientReport.Common.SinoUC_InputReportMonth();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.CB_Report.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CB_ORG.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "报表名称";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CB_Report
            // 
            this.CB_Report.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.CB_Report, 3);
            this.CB_Report.Location = new System.Drawing.Point(104, 12);
            this.CB_Report.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CB_Report.Name = "CB_Report";
            this.CB_Report.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CB_Report.Size = new System.Drawing.Size(364, 20);
            this.CB_Report.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(13, 39);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "统计单位";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CB_ORG
            // 
            this.CB_ORG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.CB_ORG, 3);
            this.CB_ORG.Location = new System.Drawing.Point(104, 40);
            this.CB_ORG.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CB_ORG.Name = "CB_ORG";
            this.CB_ORG.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.CB_ORG.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.White;
            this.CB_ORG.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.CB_ORG.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.CB_ORG.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.CB_ORG.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CB_ORG.Properties.ReadOnly = true;
            this.CB_ORG.Size = new System.Drawing.Size(364, 20);
            this.CB_ORG.TabIndex = 7;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(336, 188);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(62, 22);
            this.simpleButton1.TabIndex = 8;
            this.simpleButton1.Text = "生成报表";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(406, 188);
            this.simpleButton2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(62, 22);
            this.simpleButton2.TabIndex = 9;
            this.simpleButton2.Text = "取 消";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 4);
            this.panel1.Controls.Add(this.sinoUC_InputReportMonth1);
            this.panel1.Location = new System.Drawing.Point(13, 67);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(455, 115);
            this.panel1.TabIndex = 10;
            // 
            // sinoUC_InputReportMonth1
            // 
            this.sinoUC_InputReportMonth1.BackColor = System.Drawing.Color.Transparent;
            this.sinoUC_InputReportMonth1.Dock = System.Windows.Forms.DockStyle.Top;
            this.sinoUC_InputReportMonth1.Location = new System.Drawing.Point(0, 0);
            this.sinoUC_InputReportMonth1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.sinoUC_InputReportMonth1.Name = "sinoUC_InputReportMonth1";
            this.sinoUC_InputReportMonth1.Size = new System.Drawing.Size(455, 58);
            this.sinoUC_InputReportMonth1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Controls.Add(this.simpleButton1, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.simpleButton2, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.CB_ORG, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.CB_Report, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(481, 222);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // Dialog_CreateReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 222);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Dialog_CreateReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生成报表";
            ((System.ComponentModel.ISupportInitialize)(this.CB_Report.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CB_ORG.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.Label label1;
                private DevExpress.XtraEditors.ComboBoxEdit CB_Report;
                private System.Windows.Forms.Label label4;
                private DevExpress.XtraEditors.ComboBoxEdit CB_ORG;
                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private DevExpress.XtraEditors.SimpleButton simpleButton2;
                private System.Windows.Forms.Panel panel1;
                private SinoSZClientReport.Common.SinoUC_InputReportMonth sinoUC_InputReportMonth1;
                private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        }
}