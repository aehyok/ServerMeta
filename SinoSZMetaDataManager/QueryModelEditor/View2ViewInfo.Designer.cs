namespace SinoSZMetaDataManager.QueryModelEditor
{
        partial class View2ViewInfo
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
                        this.TE_DisplayName = new SinoSZMetaDataManager.SinoSZTextEdit();
                        this.TE_Order = new SinoSZMetaDataManager.SinoSZTextEdit();
                        this.TE_MODEL = new SinoSZMetaDataManager.SinoSZTextEdit();
                        this.TE_RELATION = new SinoSZMetaDataManager.SinoSZMemoEdit();
                        ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
                        this.groupControl1.SuspendLayout();
                        this.tableLayoutPanel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_DisplayName.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_Order.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_MODEL.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_RELATION.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // groupControl1
                        // 
                        this.groupControl1.Controls.Add(this.tableLayoutPanel1);
                        this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.groupControl1.Location = new System.Drawing.Point(0, 0);
                        this.groupControl1.Name = "groupControl1";
                        this.groupControl1.Padding = new System.Windows.Forms.Padding(0, 10, 8, 8);
                        this.groupControl1.Size = new System.Drawing.Size(663, 454);
                        this.groupControl1.TabIndex = 3;
                        this.groupControl1.Text = "关联查询模型定义";
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
                        this.tableLayoutPanel1.Controls.Add(this.TE_DisplayName, 1, 0);
                        this.tableLayoutPanel1.Controls.Add(this.TE_Order, 1, 1);
                        this.tableLayoutPanel1.Controls.Add(this.TE_MODEL, 3, 1);
                        this.tableLayoutPanel1.Controls.Add(this.TE_RELATION, 1, 2);
                        this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 29);
                        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
                        this.tableLayoutPanel1.RowCount = 3;
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tableLayoutPanel1.Size = new System.Drawing.Size(653, 417);
                        this.tableLayoutPanel1.TabIndex = 0;
                        // 
                        // label9
                        // 
                        this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.label9.AutoSize = true;
                        this.label9.Location = new System.Drawing.Point(46, 59);
                        this.label9.Margin = new System.Windows.Forms.Padding(3);
                        this.label9.Name = "label9";
                        this.label9.Size = new System.Drawing.Size(55, 14);
                        this.label9.TabIndex = 16;
                        this.label9.Text = "关联算法";
                        // 
                        // label3
                        // 
                        this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
                        this.label3.AutoSize = true;
                        this.label3.Location = new System.Drawing.Point(46, 35);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(55, 14);
                        this.label3.TabIndex = 4;
                        this.label3.Text = "显示顺序";
                        // 
                        // label1
                        // 
                        this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
                        this.label1.AutoSize = true;
                        this.label1.Location = new System.Drawing.Point(46, 7);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(55, 14);
                        this.label1.TabIndex = 0;
                        this.label1.Text = "显示名称";
                        // 
                        // label4
                        // 
                        this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
                        this.label4.AutoSize = true;
                        this.label4.Location = new System.Drawing.Point(348, 35);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(79, 14);
                        this.label4.TabIndex = 6;
                        this.label4.Text = "关联模型名称";
                        // 
                        // TE_DisplayName
                        // 
                        this.TE_DisplayName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.tableLayoutPanel1.SetColumnSpan(this.TE_DisplayName, 3);
                        this.TE_DisplayName.Location = new System.Drawing.Point(107, 3);
                        this.TE_DisplayName.Name = "TE_DisplayName";
                        this.TE_DisplayName.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
                        this.TE_DisplayName.Properties.Appearance.Options.UseForeColor = true;
                        this.TE_DisplayName.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
                        this.TE_DisplayName.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Blue;
                        this.TE_DisplayName.Properties.AppearanceFocused.Options.UseBackColor = true;
                        this.TE_DisplayName.Properties.AppearanceFocused.Options.UseForeColor = true;
                        this.TE_DisplayName.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
                        this.TE_DisplayName.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
                        this.TE_DisplayName.Properties.AppearanceReadOnly.Options.UseBackColor = true;
                        this.TE_DisplayName.Properties.AppearanceReadOnly.Options.UseForeColor = true;
                        this.TE_DisplayName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
                        this.TE_DisplayName.Size = new System.Drawing.Size(543, 21);
                        this.TE_DisplayName.TabIndex = 17;
                        this.TE_DisplayName.EditValueChanged += new System.EventHandler(this.TE_DisplayName_EditValueChanged);
                        // 
                        // TE_Order
                        // 
                        this.TE_Order.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.TE_Order.Location = new System.Drawing.Point(107, 31);
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
                        this.TE_Order.Size = new System.Drawing.Size(216, 21);
                        this.TE_Order.TabIndex = 19;
                        this.TE_Order.EditValueChanged += new System.EventHandler(this.TE_DisplayName_EditValueChanged);
                        // 
                        // TE_MODEL
                        // 
                        this.TE_MODEL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.TE_MODEL.Location = new System.Drawing.Point(433, 31);
                        this.TE_MODEL.Name = "TE_MODEL";
                        this.TE_MODEL.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
                        this.TE_MODEL.Properties.Appearance.Options.UseForeColor = true;
                        this.TE_MODEL.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
                        this.TE_MODEL.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Blue;
                        this.TE_MODEL.Properties.AppearanceFocused.Options.UseBackColor = true;
                        this.TE_MODEL.Properties.AppearanceFocused.Options.UseForeColor = true;
                        this.TE_MODEL.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
                        this.TE_MODEL.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
                        this.TE_MODEL.Properties.AppearanceReadOnly.Options.UseBackColor = true;
                        this.TE_MODEL.Properties.AppearanceReadOnly.Options.UseForeColor = true;
                        this.TE_MODEL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
                        this.TE_MODEL.Size = new System.Drawing.Size(217, 21);
                        this.TE_MODEL.TabIndex = 20;
                        this.TE_MODEL.EditValueChanged += new System.EventHandler(this.TE_DisplayName_EditValueChanged);
                        // 
                        // TE_RELATION
                        // 
                        this.tableLayoutPanel1.SetColumnSpan(this.TE_RELATION, 3);
                        this.TE_RELATION.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.TE_RELATION.Location = new System.Drawing.Point(107, 59);
                        this.TE_RELATION.Name = "TE_RELATION";
                        this.TE_RELATION.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
                        this.TE_RELATION.Properties.Appearance.Options.UseForeColor = true;
                        this.TE_RELATION.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
                        this.TE_RELATION.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Blue;
                        this.TE_RELATION.Properties.AppearanceFocused.Options.UseBackColor = true;
                        this.TE_RELATION.Properties.AppearanceFocused.Options.UseForeColor = true;
                        this.TE_RELATION.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
                        this.TE_RELATION.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
                        this.TE_RELATION.Properties.AppearanceReadOnly.Options.UseBackColor = true;
                        this.TE_RELATION.Properties.AppearanceReadOnly.Options.UseForeColor = true;
                        this.TE_RELATION.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
                        this.TE_RELATION.Size = new System.Drawing.Size(543, 355);
                        this.TE_RELATION.TabIndex = 21;
                        this.TE_RELATION.EditValueChanged += new System.EventHandler(this.TE_DisplayName_EditValueChanged);
                        // 
                        // View2ViewInfo
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.groupControl1);
                        this.Name = "View2ViewInfo";
                        this.Size = new System.Drawing.Size(663, 454);
                        this.Load += new System.EventHandler(this.View2ViewInfo_Load);
                        ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
                        this.groupControl1.ResumeLayout(false);
                        this.tableLayoutPanel1.ResumeLayout(false);
                        this.tableLayoutPanel1.PerformLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_DisplayName.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_Order.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_MODEL.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_RELATION.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.GroupControl groupControl1;
                private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
                private System.Windows.Forms.Label label9;
                private System.Windows.Forms.Label label3;
                private System.Windows.Forms.Label label1;
                private System.Windows.Forms.Label label4;
                private SinoSZTextEdit TE_DisplayName;
                private SinoSZTextEdit TE_Order;
                private SinoSZTextEdit TE_MODEL;
                private SinoSZMemoEdit TE_RELATION;
        }
}
