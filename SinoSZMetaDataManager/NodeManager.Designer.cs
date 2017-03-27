namespace SinoSZMetaDataManager
{
        partial class NodeManager
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
                        this.label3 = new System.Windows.Forms.Label();
                        this.label1 = new System.Windows.Forms.Label();
                        this.label2 = new System.Windows.Forms.Label();
                        this.label9 = new System.Windows.Forms.Label();
                        this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
                        this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
                        this.label4 = new System.Windows.Forms.Label();
                        this.TE_XH = new SinoSZMetaDataManager.SinoSZTextEdit();
                        this.TE_NAME = new SinoSZMetaDataManager.SinoSZTextEdit();
                        this.TE_DISPLAY = new SinoSZMetaDataManager.SinoSZTextEdit();
                        this.TE_DWDM = new SinoSZMetaDataManager.SinoSZTextEdit();
                        this.TE_DESCRIPT = new SinoSZMetaDataManager.SinoSZMemoEdit();
                        ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
                        this.groupControl1.SuspendLayout();
                        this.tableLayoutPanel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_XH.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_NAME.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_DISPLAY.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_DWDM.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_DESCRIPT.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // label3
                        // 
                        this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
                        this.label3.AutoSize = true;
                        this.label3.Location = new System.Drawing.Point(44, 36);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(53, 12);
                        this.label3.TabIndex = 4;
                        this.label3.Text = "显示名称";
                        // 
                        // label1
                        // 
                        this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
                        this.label1.AutoSize = true;
                        this.label1.Location = new System.Drawing.Point(68, 8);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(29, 12);
                        this.label1.TabIndex = 0;
                        this.label1.Text = "序号";
                        // 
                        // label2
                        // 
                        this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
                        this.label2.AutoSize = true;
                        this.label2.Location = new System.Drawing.Point(358, 8);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(53, 12);
                        this.label2.TabIndex = 2;
                        this.label2.Text = "节点名称";
                        // 
                        // label9
                        // 
                        this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.label9.AutoSize = true;
                        this.label9.Location = new System.Drawing.Point(68, 59);
                        this.label9.Margin = new System.Windows.Forms.Padding(3);
                        this.label9.Name = "label9";
                        this.label9.Size = new System.Drawing.Size(29, 12);
                        this.label9.TabIndex = 16;
                        this.label9.Text = "备注";
                        // 
                        // groupControl1
                        // 
                        this.groupControl1.Controls.Add(this.tableLayoutPanel1);
                        this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.groupControl1.Location = new System.Drawing.Point(0, 0);
                        this.groupControl1.Name = "groupControl1";
                        this.groupControl1.Padding = new System.Windows.Forms.Padding(0, 10, 8, 8);
                        this.groupControl1.Size = new System.Drawing.Size(641, 484);
                        this.groupControl1.TabIndex = 1;
                        this.groupControl1.Text = "元数据节点配置";
                        // 
                        // tableLayoutPanel1
                        // 
                        this.tableLayoutPanel1.ColumnCount = 4;
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
                        this.tableLayoutPanel1.Controls.Add(this.label9, 0, 2);
                        this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
                        this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
                        this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
                        this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
                        this.tableLayoutPanel1.Controls.Add(this.TE_XH, 1, 0);
                        this.tableLayoutPanel1.Controls.Add(this.TE_NAME, 3, 0);
                        this.tableLayoutPanel1.Controls.Add(this.TE_DISPLAY, 1, 1);
                        this.tableLayoutPanel1.Controls.Add(this.TE_DWDM, 3, 1);
                        this.tableLayoutPanel1.Controls.Add(this.TE_DESCRIPT, 1, 2);
                        this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 29);
                        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
                        this.tableLayoutPanel1.RowCount = 3;
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tableLayoutPanel1.Size = new System.Drawing.Size(631, 447);
                        this.tableLayoutPanel1.TabIndex = 0;
                        // 
                        // label4
                        // 
                        this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
                        this.label4.AutoSize = true;
                        this.label4.Location = new System.Drawing.Point(358, 36);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(53, 12);
                        this.label4.TabIndex = 6;
                        this.label4.Text = "节点编码";
                        // 
                        // TE_XH
                        // 
                        this.TE_XH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.TE_XH.Location = new System.Drawing.Point(103, 3);
                        this.TE_XH.Name = "TE_XH";
                        this.TE_XH.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
                        this.TE_XH.Properties.Appearance.Options.UseForeColor = true;
                        this.TE_XH.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
                        this.TE_XH.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Blue;
                        this.TE_XH.Properties.AppearanceFocused.Options.UseBackColor = true;
                        this.TE_XH.Properties.AppearanceFocused.Options.UseForeColor = true;
                        this.TE_XH.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
                        this.TE_XH.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
                        this.TE_XH.Properties.AppearanceReadOnly.Options.UseBackColor = true;
                        this.TE_XH.Properties.AppearanceReadOnly.Options.UseForeColor = true;
                        this.TE_XH.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
                        this.TE_XH.Properties.ReadOnly = true;
                        this.TE_XH.Size = new System.Drawing.Size(208, 21);
                        this.TE_XH.TabIndex = 17;
                        // 
                        // TE_NAME
                        // 
                        this.TE_NAME.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.TE_NAME.Location = new System.Drawing.Point(417, 3);
                        this.TE_NAME.Name = "TE_NAME";
                        this.TE_NAME.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
                        this.TE_NAME.Properties.Appearance.Options.UseForeColor = true;
                        this.TE_NAME.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
                        this.TE_NAME.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Blue;
                        this.TE_NAME.Properties.AppearanceFocused.Options.UseBackColor = true;
                        this.TE_NAME.Properties.AppearanceFocused.Options.UseForeColor = true;
                        this.TE_NAME.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
                        this.TE_NAME.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
                        this.TE_NAME.Properties.AppearanceReadOnly.Options.UseBackColor = true;
                        this.TE_NAME.Properties.AppearanceReadOnly.Options.UseForeColor = true;
                        this.TE_NAME.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
                        this.TE_NAME.Size = new System.Drawing.Size(211, 21);
                        this.TE_NAME.TabIndex = 18;
                        this.TE_NAME.EditValueChanged += new System.EventHandler(this.TE_NAME_EditValueChanged);
                        // 
                        // TE_DISPLAY
                        // 
                        this.TE_DISPLAY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.TE_DISPLAY.Location = new System.Drawing.Point(103, 31);
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
                        this.TE_DISPLAY.Size = new System.Drawing.Size(208, 21);
                        this.TE_DISPLAY.TabIndex = 19;
                        this.TE_DISPLAY.EditValueChanged += new System.EventHandler(this.TE_DISPLAY_EditValueChanged);
                        // 
                        // TE_DWDM
                        // 
                        this.TE_DWDM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.TE_DWDM.Location = new System.Drawing.Point(417, 31);
                        this.TE_DWDM.Name = "TE_DWDM";
                        this.TE_DWDM.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
                        this.TE_DWDM.Properties.Appearance.Options.UseForeColor = true;
                        this.TE_DWDM.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
                        this.TE_DWDM.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Blue;
                        this.TE_DWDM.Properties.AppearanceFocused.Options.UseBackColor = true;
                        this.TE_DWDM.Properties.AppearanceFocused.Options.UseForeColor = true;
                        this.TE_DWDM.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
                        this.TE_DWDM.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
                        this.TE_DWDM.Properties.AppearanceReadOnly.Options.UseBackColor = true;
                        this.TE_DWDM.Properties.AppearanceReadOnly.Options.UseForeColor = true;
                        this.TE_DWDM.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
                        this.TE_DWDM.Size = new System.Drawing.Size(211, 21);
                        this.TE_DWDM.TabIndex = 20;
                        this.TE_DWDM.EditValueChanged += new System.EventHandler(this.TE_DWDM_EditValueChanged);
                        // 
                        // TE_DESCRIPT
                        // 
                        this.tableLayoutPanel1.SetColumnSpan(this.TE_DESCRIPT, 3);
                        this.TE_DESCRIPT.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.TE_DESCRIPT.Location = new System.Drawing.Point(103, 59);
                        this.TE_DESCRIPT.Name = "TE_DESCRIPT";
                        this.TE_DESCRIPT.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
                        this.TE_DESCRIPT.Properties.Appearance.Options.UseForeColor = true;
                        this.TE_DESCRIPT.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
                        this.TE_DESCRIPT.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Blue;
                        this.TE_DESCRIPT.Properties.AppearanceFocused.Options.UseBackColor = true;
                        this.TE_DESCRIPT.Properties.AppearanceFocused.Options.UseForeColor = true;
                        this.TE_DESCRIPT.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
                        this.TE_DESCRIPT.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
                        this.TE_DESCRIPT.Properties.AppearanceReadOnly.Options.UseBackColor = true;
                        this.TE_DESCRIPT.Properties.AppearanceReadOnly.Options.UseForeColor = true;
                        this.TE_DESCRIPT.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
                        this.TE_DESCRIPT.Size = new System.Drawing.Size(525, 385);
                        this.TE_DESCRIPT.TabIndex = 21;
                        this.TE_DESCRIPT.EditValueChanged += new System.EventHandler(this.TE_DESCRIPT_EditValueChanged);
                        // 
                        // NodeManager
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.groupControl1);
                        this.Name = "NodeManager";
                        this.Size = new System.Drawing.Size(641, 484);
                        this.Load += new System.EventHandler(this.NodeManager_Load);
                        ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
                        this.groupControl1.ResumeLayout(false);
                        this.tableLayoutPanel1.ResumeLayout(false);
                        this.tableLayoutPanel1.PerformLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_XH.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_NAME.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_DISPLAY.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_DWDM.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_DESCRIPT.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.Label label3;
                private System.Windows.Forms.Label label1;
                private System.Windows.Forms.Label label2;
                private System.Windows.Forms.Label label9;
                private DevExpress.XtraEditors.GroupControl groupControl1;
                private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
                private System.Windows.Forms.Label label4;
                private SinoSZTextEdit TE_XH;
                private SinoSZTextEdit TE_NAME;
                private SinoSZTextEdit TE_DISPLAY;
                private SinoSZTextEdit TE_DWDM;
                private SinoSZMemoEdit TE_DESCRIPT;
        }
}
