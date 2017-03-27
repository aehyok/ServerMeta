namespace SinoSZMetaDataManager.QueryModelEditor
{
        partial class View2ViewGroupInfo
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
                        this.label3 = new System.Windows.Forms.Label();
                        this.label1 = new System.Windows.Forms.Label();
                        this.TE_GroupName = new SinoSZMetaDataManager.SinoSZTextEdit();
                        this.TE_Order = new SinoSZMetaDataManager.SinoSZTextEdit();
                        ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
                        this.groupControl1.SuspendLayout();
                        this.tableLayoutPanel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_GroupName.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_Order.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // groupControl1
                        // 
                        this.groupControl1.Controls.Add(this.tableLayoutPanel1);
                        this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.groupControl1.Location = new System.Drawing.Point(0, 0);
                        this.groupControl1.Name = "groupControl1";
                        this.groupControl1.Padding = new System.Windows.Forms.Padding(0, 10, 8, 8);
                        this.groupControl1.Size = new System.Drawing.Size(517, 393);
                        this.groupControl1.TabIndex = 3;
                        this.groupControl1.Text = "关到查询模型的分组信息";
                        // 
                        // tableLayoutPanel1
                        // 
                        this.tableLayoutPanel1.ColumnCount = 4;
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
                        this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
                        this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
                        this.tableLayoutPanel1.Controls.Add(this.TE_GroupName, 1, 0);
                        this.tableLayoutPanel1.Controls.Add(this.TE_Order, 1, 1);
                        this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 29);
                        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
                        this.tableLayoutPanel1.RowCount = 3;
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tableLayoutPanel1.Size = new System.Drawing.Size(507, 356);
                        this.tableLayoutPanel1.TabIndex = 0;
                        // 
                        // label3
                        // 
                        this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
                        this.label3.AutoSize = true;
                        this.label3.Location = new System.Drawing.Point(23, 35);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(55, 14);
                        this.label3.TabIndex = 4;
                        this.label3.Text = "显示顺序";
                        // 
                        // label1
                        // 
                        this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
                        this.label1.AutoSize = true;
                        this.label1.Location = new System.Drawing.Point(47, 7);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(31, 14);
                        this.label1.TabIndex = 0;
                        this.label1.Text = "名称";
                        // 
                        // TE_GroupName
                        // 
                        this.TE_GroupName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.tableLayoutPanel1.SetColumnSpan(this.TE_GroupName, 3);
                        this.TE_GroupName.Location = new System.Drawing.Point(84, 3);
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
                        this.TE_GroupName.Size = new System.Drawing.Size(420, 21);
                        this.TE_GroupName.TabIndex = 17;
                        this.TE_GroupName.EditValueChanged += new System.EventHandler(this.TE_GroupName_EditValueChanged);
                        // 
                        // TE_Order
                        // 
                        this.TE_Order.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.TE_Order.Location = new System.Drawing.Point(84, 31);
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
                        this.TE_Order.Size = new System.Drawing.Size(166, 21);
                        this.TE_Order.TabIndex = 19;
                        this.TE_Order.EditValueChanged += new System.EventHandler(this.TE_Order_EditValueChanged);
                        // 
                        // View2ViewGroupInfo
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.groupControl1);
                        this.Name = "View2ViewGroupInfo";
                        this.Size = new System.Drawing.Size(517, 393);
                        this.Load += new System.EventHandler(this.View2ViewGroupInfo_Load);
                        ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
                        this.groupControl1.ResumeLayout(false);
                        this.tableLayoutPanel1.ResumeLayout(false);
                        this.tableLayoutPanel1.PerformLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_GroupName.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_Order.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.GroupControl groupControl1;
                private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
                private System.Windows.Forms.Label label3;
                private System.Windows.Forms.Label label1;
                private SinoSZTextEdit TE_GroupName;
                private SinoSZTextEdit TE_Order;
        }
}
