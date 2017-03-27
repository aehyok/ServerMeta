namespace SinoSZMetaDataManager.QueryModelEditor
{
        partial class SinoUC_QME_QueryModelInfo
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
                        this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
                        this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
                        this.label9 = new System.Windows.Forms.Label();
                        this.label5 = new System.Windows.Forms.Label();
                        this.TE_DISPLAY = new SinoSZMetaDataManager.SinoSZTextEdit();
                        this.TE_DES = new SinoSZMetaDataManager.SinoSZMemoEdit();
                        ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
                        this.groupControl1.SuspendLayout();
                        this.tableLayoutPanel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_DISPLAY.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_DES.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // groupControl1
                        // 
                        this.groupControl1.Controls.Add(this.tableLayoutPanel1);
                        this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.groupControl1.Location = new System.Drawing.Point(0, 0);
                        this.groupControl1.Name = "groupControl1";
                        this.groupControl1.Padding = new System.Windows.Forms.Padding(8, 10, 8, 8);
                        this.groupControl1.Size = new System.Drawing.Size(753, 438);
                        this.groupControl1.TabIndex = 1;
                        this.groupControl1.Text = "查询模型管理";
                        // 
                        // tableLayoutPanel1
                        // 
                        this.tableLayoutPanel1.ColumnCount = 2;
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
                        this.tableLayoutPanel1.Controls.Add(this.TE_DISPLAY, 1, 0);
                        this.tableLayoutPanel1.Controls.Add(this.label9, 0, 1);
                        this.tableLayoutPanel1.Controls.Add(this.TE_DES, 1, 1);
                        this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 29);
                        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
                        this.tableLayoutPanel1.RowCount = 2;
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tableLayoutPanel1.Size = new System.Drawing.Size(737, 401);
                        this.tableLayoutPanel1.TabIndex = 0;
                        // 
                        // label9
                        // 
                        this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.label9.Location = new System.Drawing.Point(3, 36);
                        this.label9.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
                        this.label9.Name = "label9";
                        this.label9.Size = new System.Drawing.Size(114, 365);
                        this.label9.TabIndex = 9;
                        this.label9.Text = "内容及范围说明";
                        this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
                        // 
                        // label5
                        // 
                        this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
                        this.label5.AutoSize = true;
                        this.label5.Location = new System.Drawing.Point(62, 7);
                        this.label5.Name = "label5";
                        this.label5.Size = new System.Drawing.Size(55, 14);
                        this.label5.TabIndex = 5;
                        this.label5.Text = "显示名称";
                        // 
                        // TE_DISPLAY
                        // 
                        this.TE_DISPLAY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.TE_DISPLAY.Location = new System.Drawing.Point(123, 3);
                        this.TE_DISPLAY.Name = "TE_DISPLAY";
                        this.TE_DISPLAY.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
                        this.TE_DISPLAY.Properties.Appearance.Options.UseForeColor = true;
                        this.TE_DISPLAY.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
                        this.TE_DISPLAY.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Blue;
                        this.TE_DISPLAY.Properties.AppearanceFocused.Options.UseBackColor = true;
                        this.TE_DISPLAY.Properties.AppearanceFocused.Options.UseForeColor = true;
                        this.TE_DISPLAY.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
                        this.TE_DISPLAY.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
                        this.TE_DISPLAY.Properties.AppearanceReadOnly.Options.UseBackColor = true;
                        this.TE_DISPLAY.Properties.AppearanceReadOnly.Options.UseForeColor = true;
                        this.TE_DISPLAY.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
                        this.TE_DISPLAY.Size = new System.Drawing.Size(611, 21);
                        this.TE_DISPLAY.TabIndex = 26;
                        this.TE_DISPLAY.EditValueChanged += new System.EventHandler(this.TE_DISPLAY_EditValueChanged);
                        // 
                        // TE_DES
                        // 
                        this.TE_DES.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.TE_DES.Location = new System.Drawing.Point(123, 31);
                        this.TE_DES.Name = "TE_DES";
                        this.TE_DES.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
                        this.TE_DES.Properties.Appearance.Options.UseForeColor = true;
                        this.TE_DES.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
                        this.TE_DES.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Blue;
                        this.TE_DES.Properties.AppearanceFocused.Options.UseBackColor = true;
                        this.TE_DES.Properties.AppearanceFocused.Options.UseForeColor = true;
                        this.TE_DES.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
                        this.TE_DES.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
                        this.TE_DES.Properties.AppearanceReadOnly.Options.UseBackColor = true;
                        this.TE_DES.Properties.AppearanceReadOnly.Options.UseForeColor = true;
                        this.TE_DES.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
                        this.TE_DES.Size = new System.Drawing.Size(611, 367);
                        this.TE_DES.TabIndex = 28;
                        this.TE_DES.EditValueChanged += new System.EventHandler(this.TE_DES_EditValueChanged);
                        // 
                        // SinoUC_QME_QueryModelInfo
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.groupControl1);
                        this.Name = "SinoUC_QME_QueryModelInfo";
                        this.Size = new System.Drawing.Size(753, 438);
                        ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
                        this.groupControl1.ResumeLayout(false);
                        this.tableLayoutPanel1.ResumeLayout(false);
                        this.tableLayoutPanel1.PerformLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_DISPLAY.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_DES.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.GroupControl groupControl1;
                private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
                private SinoSZTextEdit TE_DISPLAY;
                private System.Windows.Forms.Label label9;
                private SinoSZMemoEdit TE_DES;
                private System.Windows.Forms.Label label5;
        }
}
