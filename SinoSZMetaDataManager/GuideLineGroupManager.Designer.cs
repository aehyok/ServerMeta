namespace SinoSZMetaDataManager
{
        partial class GuideLineGroupManager
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.TE_GroupName = new SinoSZMetaDataManager.SinoSZTextEdit();
            this.TE_Namespace = new SinoSZMetaDataManager.SinoSZTextEdit();
            this.TE_Type = new SinoSZMetaDataManager.SinoSZComboEdit();
            this.TE_RightType = new SinoSZMetaDataManager.SinoSZComboEdit();
            this.TE_Descript = new SinoSZMetaDataManager.SinoSZTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TE_GroupName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_Namespace.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_Type.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_RightType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_Descript.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "指标组名称";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(639, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "命名空间";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "类型";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(639, 54);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 18);
            this.label7.TabIndex = 24;
            this.label7.Text = "权限类型";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tableLayoutPanel1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(0, 15, 11, 12);
            this.groupControl1.Size = new System.Drawing.Size(1096, 804);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "指标组管理";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.TE_GroupName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.TE_Namespace, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.TE_Type, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.TE_RightType, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.TE_Descript, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 41);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1081, 749);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 96);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "说明";
            // 
            // TE_GroupName
            // 
            this.TE_GroupName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TE_GroupName.Location = new System.Drawing.Point(176, 9);
            this.TE_GroupName.Margin = new System.Windows.Forms.Padding(4);
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
            this.TE_GroupName.Size = new System.Drawing.Size(359, 24);
            this.TE_GroupName.TabIndex = 25;
            this.TE_GroupName.EditValueChanged += new System.EventHandler(this.TE_GroupName_EditValueChanged);
            // 
            // TE_Namespace
            // 
            this.TE_Namespace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TE_Namespace.Location = new System.Drawing.Point(715, 9);
            this.TE_Namespace.Margin = new System.Windows.Forms.Padding(4);
            this.TE_Namespace.Name = "TE_Namespace";
            this.TE_Namespace.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.TE_Namespace.Properties.Appearance.Options.UseForeColor = true;
            this.TE_Namespace.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.TE_Namespace.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Blue;
            this.TE_Namespace.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.TE_Namespace.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.TE_Namespace.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.TE_Namespace.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.TE_Namespace.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.TE_Namespace.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.TE_Namespace.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.TE_Namespace.Size = new System.Drawing.Size(362, 24);
            this.TE_Namespace.TabIndex = 26;
            this.TE_Namespace.EditValueChanged += new System.EventHandler(this.TE_Namespace_EditValueChanged);
            // 
            // TE_Type
            // 
            this.TE_Type.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TE_Type.Location = new System.Drawing.Point(176, 51);
            this.TE_Type.Margin = new System.Windows.Forms.Padding(4);
            this.TE_Type.Name = "TE_Type";
            this.TE_Type.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.TE_Type.Properties.Appearance.Options.UseForeColor = true;
            this.TE_Type.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.TE_Type.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Blue;
            this.TE_Type.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.TE_Type.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.TE_Type.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.TE_Type.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.TE_Type.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.TE_Type.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.TE_Type.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.TE_Type.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TE_Type.Properties.Items.AddRange(new object[] {
            "统计指标",
            "报表指标"});
            this.TE_Type.Properties.ReadOnly = true;
            this.TE_Type.Size = new System.Drawing.Size(359, 24);
            this.TE_Type.TabIndex = 27;
            this.TE_Type.SelectedIndexChanged += new System.EventHandler(this.TE_Type_SelectedIndexChanged);
            // 
            // TE_RightType
            // 
            this.TE_RightType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TE_RightType.Location = new System.Drawing.Point(715, 51);
            this.TE_RightType.Margin = new System.Windows.Forms.Padding(4);
            this.TE_RightType.Name = "TE_RightType";
            this.TE_RightType.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.TE_RightType.Properties.Appearance.Options.UseForeColor = true;
            this.TE_RightType.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.TE_RightType.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Blue;
            this.TE_RightType.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.TE_RightType.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.TE_RightType.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.TE_RightType.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.TE_RightType.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.TE_RightType.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.TE_RightType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.TE_RightType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TE_RightType.Size = new System.Drawing.Size(362, 24);
            this.TE_RightType.TabIndex = 28;
            this.TE_RightType.SelectedIndexChanged += new System.EventHandler(this.TE_RightType_SelectedIndexChanged);
            // 
            // TE_Descript
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.TE_Descript, 3);
            this.TE_Descript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TE_Descript.Location = new System.Drawing.Point(176, 88);
            this.TE_Descript.Margin = new System.Windows.Forms.Padding(4);
            this.TE_Descript.Name = "TE_Descript";
            this.TE_Descript.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.TE_Descript.Properties.Appearance.Options.UseForeColor = true;
            this.TE_Descript.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.TE_Descript.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Blue;
            this.TE_Descript.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.TE_Descript.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.TE_Descript.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.TE_Descript.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.TE_Descript.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.TE_Descript.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.TE_Descript.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.TE_Descript.Size = new System.Drawing.Size(901, 24);
            this.TE_Descript.TabIndex = 29;
            this.TE_Descript.EditValueChanged += new System.EventHandler(this.TE_Descript_EditValueChanged);
            // 
            // GuideLineGroupManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GuideLineGroupManager";
            this.Size = new System.Drawing.Size(1096, 804);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TE_GroupName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_Namespace.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_Type.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_RightType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_Descript.Properties)).EndInit();
            this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.Label label2;
                private System.Windows.Forms.Label label3;
                private System.Windows.Forms.Label label1;
                private System.Windows.Forms.Label label7;
                private DevExpress.XtraEditors.GroupControl groupControl1;
                private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
                private System.Windows.Forms.Label label4;
                private SinoSZTextEdit TE_GroupName;
                private SinoSZTextEdit TE_Namespace;
                private SinoSZComboEdit TE_Type;
                private SinoSZComboEdit TE_RightType;
                private SinoSZTextEdit TE_Descript;
        }
}
