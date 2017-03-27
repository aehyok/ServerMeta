namespace SinoSZClientReport.ReportGuideLine
{
        partial class ReportGuideLineUC_InputTJRQ
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
                        this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
                        this.label1 = new System.Windows.Forms.Label();
                        this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
                        this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
                        this.te_EndDate = new DevExpress.XtraEditors.DateEdit();
                        this.te_StartDate = new DevExpress.XtraEditors.DateEdit();
                        this.label2 = new System.Windows.Forms.Label();
                        this.label3 = new System.Windows.Forms.Label();
                        this.tableLayoutPanel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
                        this.tableLayoutPanel2.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.te_EndDate.Properties.VistaTimeProperties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_EndDate.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_StartDate.Properties.VistaTimeProperties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_StartDate.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // tableLayoutPanel1
                        // 
                        this.tableLayoutPanel1.ColumnCount = 3;
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
                        this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
                        this.tableLayoutPanel1.Controls.Add(this.dateEdit1, 2, 0);
                        this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
                        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
                        this.tableLayoutPanel1.RowCount = 1;
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tableLayoutPanel1.Size = new System.Drawing.Size(310, 36);
                        this.tableLayoutPanel1.TabIndex = 0;
                        // 
                        // label1
                        // 
                        this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.label1.Location = new System.Drawing.Point(133, 0);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(74, 36);
                        this.label1.TabIndex = 0;
                        this.label1.Text = "统计月份";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // dateEdit1
                        // 
                        this.dateEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.dateEdit1.EditValue = null;
                        this.dateEdit1.Location = new System.Drawing.Point(213, 7);
                        this.dateEdit1.Name = "dateEdit1";
                        this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.dateEdit1.Properties.DisplayFormat.FormatString = "yyyy年MM月";
                        this.dateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        this.dateEdit1.Properties.EditFormat.FormatString = "yyyy年MM月";
                        this.dateEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        this.dateEdit1.Properties.Mask.EditMask = "yyyy年MM月";
                        this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
                        this.dateEdit1.Size = new System.Drawing.Size(94, 21);
                        this.dateEdit1.TabIndex = 1;
                        // 
                        // tableLayoutPanel2
                        // 
                        this.tableLayoutPanel2.ColumnCount = 5;
                        this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
                        this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
                        this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                        this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
                        this.tableLayoutPanel2.Controls.Add(this.label3, 1, 0);
                        this.tableLayoutPanel2.Controls.Add(this.te_EndDate, 5, 0);
                        this.tableLayoutPanel2.Controls.Add(this.te_StartDate, 2, 0);
                        this.tableLayoutPanel2.Controls.Add(this.label2, 3, 0);
                        this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
                        this.tableLayoutPanel2.Name = "tableLayoutPanel2";
                        this.tableLayoutPanel2.RowCount = 1;
                        this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tableLayoutPanel2.Size = new System.Drawing.Size(310, 36);
                        this.tableLayoutPanel2.TabIndex = 1;
                        this.tableLayoutPanel2.Visible = false;
                        // 
                        // te_EndDate
                        // 
                        this.te_EndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.te_EndDate.EditValue = null;
                        this.te_EndDate.Location = new System.Drawing.Point(213, 7);
                        this.te_EndDate.Name = "te_EndDate";
                        this.te_EndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.te_EndDate.Properties.DisplayFormat.FormatString = "yyyy年MM月";
                        this.te_EndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        this.te_EndDate.Properties.EditFormat.FormatString = "yyyy年MM月";
                        this.te_EndDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        this.te_EndDate.Properties.Mask.EditMask = "yyyy年MM月";
                        this.te_EndDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
                        this.te_EndDate.Size = new System.Drawing.Size(94, 21);
                        this.te_EndDate.TabIndex = 2;
                        // 
                        // te_StartDate
                        // 
                        this.te_StartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.te_StartDate.EditValue = null;
                        this.te_StartDate.Location = new System.Drawing.Point(93, 7);
                        this.te_StartDate.Name = "te_StartDate";
                        this.te_StartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.te_StartDate.Properties.DisplayFormat.FormatString = "yyyy年MM月";
                        this.te_StartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        this.te_StartDate.Properties.EditFormat.FormatString = "yyyy年MM月";
                        this.te_StartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        this.te_StartDate.Properties.Mask.EditMask = "yyyy年MM月";
                        this.te_StartDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
                        this.te_StartDate.Size = new System.Drawing.Size(94, 21);
                        this.te_StartDate.TabIndex = 3;
                        // 
                        // label2
                        // 
                        this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.label2.Location = new System.Drawing.Point(193, 0);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(14, 36);
                        this.label2.TabIndex = 4;
                        this.label2.Text = "至";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // label3
                        // 
                        this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.label3.Location = new System.Drawing.Point(13, 0);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(74, 36);
                        this.label3.TabIndex = 5;
                        this.label3.Text = "统计日期";
                        this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // ReportGuideLineUC_InputTJRQ
                        // 
                        this.Appearance.BackColor = System.Drawing.Color.Transparent;
                        this.Appearance.Options.UseBackColor = true;
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.tableLayoutPanel2);
                        this.Controls.Add(this.tableLayoutPanel1);
                        this.Name = "ReportGuideLineUC_InputTJRQ";
                        this.Size = new System.Drawing.Size(310, 36);
                        this.Load += new System.EventHandler(this.ReportGuideLineUC_InputTJRQ_Load);
                        this.tableLayoutPanel1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
                        this.tableLayoutPanel2.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.te_EndDate.Properties.VistaTimeProperties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_EndDate.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_StartDate.Properties.VistaTimeProperties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_StartDate.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
                private System.Windows.Forms.Label label1;
                private DevExpress.XtraEditors.DateEdit dateEdit1;
                private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
                private System.Windows.Forms.Label label3;
                private DevExpress.XtraEditors.DateEdit te_EndDate;
                private DevExpress.XtraEditors.DateEdit te_StartDate;
                private System.Windows.Forms.Label label2;

        }
}
