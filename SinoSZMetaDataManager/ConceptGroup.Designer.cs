namespace SinoSZMetaDataManager
{
        partial class ConceptGroup
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
                        this.label3 = new System.Windows.Forms.Label();
                        this.label1 = new System.Windows.Forms.Label();
                        this.label4 = new System.Windows.Forms.Label();
                        this.TE_GroupName = new SinoSZMetaDataManager.SinoSZTextEdit();
                        this.TE_Order = new SinoSZMetaDataManager.SinoSZTextEdit();
                        this.TE_DWDM = new SinoSZMetaDataManager.SinoSZTextEdit();
                        this.TE_DESCRIPT = new SinoSZMetaDataManager.SinoSZMemoEdit();
                        ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
                        this.groupControl1.SuspendLayout();
                        this.tableLayoutPanel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_GroupName.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_Order.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_DWDM.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_DESCRIPT.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // groupControl1
                        // 
                        this.groupControl1.Controls.Add(this.tableLayoutPanel1);
                        this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.groupControl1.Location = new System.Drawing.Point(0, 0);
                        this.groupControl1.Name = "groupControl1";
                        this.groupControl1.Padding = new System.Windows.Forms.Padding(0, 10, 8, 8);
                        this.groupControl1.Size = new System.Drawing.Size(564, 379);
                        this.groupControl1.TabIndex = 2;
                        this.groupControl1.Text = "概念组";
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
                        this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
                        this.tableLayoutPanel1.Controls.Add(this.TE_GroupName, 1, 0);
                        this.tableLayoutPanel1.Controls.Add(this.TE_Order, 1, 1);
                        this.tableLayoutPanel1.Controls.Add(this.TE_DWDM, 3, 1);
                        this.tableLayoutPanel1.Controls.Add(this.TE_DESCRIPT, 1, 2);
                        this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 29);
                        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
                        this.tableLayoutPanel1.RowCount = 3;
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tableLayoutPanel1.Size = new System.Drawing.Size(554, 342);
                        this.tableLayoutPanel1.TabIndex = 0;
                        // 
                        // label9
                        // 
                        this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.label9.AutoSize = true;
                        this.label9.Location = new System.Drawing.Point(54, 59);
                        this.label9.Margin = new System.Windows.Forms.Padding(3);
                        this.label9.Name = "label9";
                        this.label9.Size = new System.Drawing.Size(31, 14);
                        this.label9.TabIndex = 16;
                        this.label9.Text = "描述";
                        // 
                        // label3
                        // 
                        this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
                        this.label3.AutoSize = true;
                        this.label3.Location = new System.Drawing.Point(30, 35);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(55, 14);
                        this.label3.TabIndex = 4;
                        this.label3.Text = "显示顺序";
                        // 
                        // label1
                        // 
                        this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
                        this.label1.AutoSize = true;
                        this.label1.Location = new System.Drawing.Point(54, 7);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(31, 14);
                        this.label1.TabIndex = 0;
                        this.label1.Text = "名称";
                        // 
                        // label4
                        // 
                        this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
                        this.label4.AutoSize = true;
                        this.label4.Location = new System.Drawing.Point(306, 35);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(55, 14);
                        this.label4.TabIndex = 6;
                        this.label4.Text = "节点编码";
                        // 
                        // TE_GroupName
                        // 
                        this.TE_GroupName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.tableLayoutPanel1.SetColumnSpan(this.TE_GroupName, 3);
                        this.TE_GroupName.Location = new System.Drawing.Point(91, 3);
                        this.TE_GroupName.Name = "TE_GroupName";
                        this.TE_GroupName.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
                        this.TE_GroupName.Properties.Appearance.Options.UseForeColor = true;
                        this.TE_GroupName.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
                        this.TE_GroupName.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Blue;
                        this.TE_GroupName.Properties.AppearanceFocused.Options.UseBackColor = true;
                        this.TE_GroupName.Properties.AppearanceFocused.Options.UseForeColor = true;
                        this.TE_GroupName.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
                        this.TE_GroupName.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
                        this.TE_GroupName.Properties.AppearanceReadOnly.Options.UseBackColor = true;
                        this.TE_GroupName.Properties.AppearanceReadOnly.Options.UseForeColor = true;
                        this.TE_GroupName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
                        this.TE_GroupName.Properties.ReadOnly = true;
                        this.TE_GroupName.Size = new System.Drawing.Size(460, 21);
                        this.TE_GroupName.TabIndex = 17;
                        this.TE_GroupName.EditValueChanged += new System.EventHandler(this.TE_GroupName_EditValueChanged);
                        // 
                        // TE_Order
                        // 
                        this.TE_Order.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.TE_Order.Location = new System.Drawing.Point(91, 31);
                        this.TE_Order.Name = "TE_Order";
                        this.TE_Order.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
                        this.TE_Order.Properties.Appearance.Options.UseForeColor = true;
                        this.TE_Order.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
                        this.TE_Order.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Blue;
                        this.TE_Order.Properties.AppearanceFocused.Options.UseBackColor = true;
                        this.TE_Order.Properties.AppearanceFocused.Options.UseForeColor = true;
                        this.TE_Order.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
                        this.TE_Order.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
                        this.TE_Order.Properties.AppearanceReadOnly.Options.UseBackColor = true;
                        this.TE_Order.Properties.AppearanceReadOnly.Options.UseForeColor = true;
                        this.TE_Order.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
                        this.TE_Order.Size = new System.Drawing.Size(182, 21);
                        this.TE_Order.TabIndex = 19;
                        this.TE_Order.EditValueChanged += new System.EventHandler(this.TE_Order_EditValueChanged);
                        // 
                        // TE_DWDM
                        // 
                        this.TE_DWDM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.TE_DWDM.Location = new System.Drawing.Point(367, 31);
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
                        this.TE_DWDM.Properties.ReadOnly = true;
                        this.TE_DWDM.Size = new System.Drawing.Size(184, 21);
                        this.TE_DWDM.TabIndex = 20;
                        this.TE_DWDM.EditValueChanged += new System.EventHandler(this.TE_DWDM_EditValueChanged);
                        // 
                        // TE_DESCRIPT
                        // 
                        this.tableLayoutPanel1.SetColumnSpan(this.TE_DESCRIPT, 3);
                        this.TE_DESCRIPT.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.TE_DESCRIPT.Location = new System.Drawing.Point(91, 59);
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
                        this.TE_DESCRIPT.Size = new System.Drawing.Size(460, 280);
                        this.TE_DESCRIPT.TabIndex = 21;
                        this.TE_DESCRIPT.EditValueChanged += new System.EventHandler(this.TE_DESCRIPT_EditValueChanged);
                        // 
                        // ConceptGroup
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.groupControl1);
                        this.Name = "ConceptGroup";
                        this.Size = new System.Drawing.Size(564, 379);
                        this.Load += new System.EventHandler(this.ConceptGroup_Load);
                        ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
                        this.groupControl1.ResumeLayout(false);
                        this.tableLayoutPanel1.ResumeLayout(false);
                        this.tableLayoutPanel1.PerformLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_GroupName.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_Order.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_DWDM.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_DESCRIPT.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.Label label4;
                private SinoSZTextEdit TE_GroupName;
                private DevExpress.XtraEditors.GroupControl groupControl1;
                private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
                private System.Windows.Forms.Label label9;
                private System.Windows.Forms.Label label3;
                private System.Windows.Forms.Label label1;
                private SinoSZTextEdit TE_Order;
                private SinoSZMemoEdit TE_DESCRIPT;
                private SinoSZTextEdit TE_DWDM;
        }
}
