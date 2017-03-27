namespace SinoSZMetaDataQuery.Common
{
        partial class SinoSZUC_ConditionItem
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
                        this.components = new System.ComponentModel.Container();
                        DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
                        DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
                        DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
                        this.panel2 = new System.Windows.Forms.Panel();
                        this.teOption = new DevExpress.XtraEditors.ComboBoxEdit();
                        this.panel1 = new System.Windows.Forms.Panel();
                        this.teColName = new DevExpress.XtraEditors.TextEdit();
                        this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
                        this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
                        this.te_Value = new DevExpress.XtraEditors.ButtonEdit();
                        this.te_xh = new DevExpress.XtraEditors.TextEdit();
                        this.panel3 = new System.Windows.Forms.Panel();
                        ((System.ComponentModel.ISupportInitialize)(this.teOption.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.teColName.Properties)).BeginInit();
                        this.contextMenuStrip1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.te_Value.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_xh.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // panel2
                        // 
                        this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
                        this.panel2.Location = new System.Drawing.Point(313, 1);
                        this.panel2.Name = "panel2";
                        this.panel2.Size = new System.Drawing.Size(2, 22);
                        this.panel2.TabIndex = 9;
                        // 
                        // teOption
                        // 
                        this.teOption.Dock = System.Windows.Forms.DockStyle.Left;
                        this.teOption.Location = new System.Drawing.Point(234, 1);
                        this.teOption.Name = "teOption";
                        this.teOption.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
                        this.teOption.Properties.Appearance.Options.UseForeColor = true;
                        this.teOption.Properties.AutoHeight = false;
                        toolTipTitleItem1.Text = "操作符";
                        toolTipItem1.LeftIndent = 6;
                        toolTipItem1.Text = "下拉可以选择操作符";
                        superToolTip1.Items.Add(toolTipTitleItem1);
                        superToolTip1.Items.Add(toolTipItem1);
                        this.teOption.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", superToolTip1)});
                        this.teOption.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
                        this.teOption.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                        this.teOption.Size = new System.Drawing.Size(79, 22);
                        this.teOption.TabIndex = 6;
                        this.teOption.SelectedIndexChanged += new System.EventHandler(this.teOption_SelectedIndexChanged);
                        // 
                        // panel1
                        // 
                        this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
                        this.panel1.Location = new System.Drawing.Point(232, 1);
                        this.panel1.Name = "panel1";
                        this.panel1.Size = new System.Drawing.Size(2, 22);
                        this.panel1.TabIndex = 8;
                        // 
                        // teColName
                        // 
                        this.teColName.Dock = System.Windows.Forms.DockStyle.Left;
                        this.teColName.Location = new System.Drawing.Point(27, 1);
                        this.teColName.Name = "teColName";
                        this.teColName.Properties.Appearance.BackColor = System.Drawing.Color.White;
                        this.teColName.Properties.Appearance.Options.UseBackColor = true;
                        this.teColName.Properties.AutoHeight = false;
                        this.teColName.Properties.ContextMenuStrip = this.contextMenuStrip1;
                        this.teColName.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
                        this.teColName.Properties.ReadOnly = true;
                        this.teColName.Size = new System.Drawing.Size(205, 22);
                        this.teColName.TabIndex = 5;
                        // 
                        // contextMenuStrip1
                        // 
                        this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
                        this.contextMenuStrip1.Name = "contextMenuStrip1";
                        this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
                        this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
                        // 
                        // toolStripMenuItem1
                        // 
                        this.toolStripMenuItem1.Image = global::SinoSZMetaDataQuery.Properties.Resources.del;
                        this.toolStripMenuItem1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.toolStripMenuItem1.Name = "toolStripMenuItem1";
                        this.toolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
                        this.toolStripMenuItem1.Text = "移除条件";
                        // 
                        // te_Value
                        // 
                        this.te_Value.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.te_Value.Location = new System.Drawing.Point(315, 1);
                        this.te_Value.Name = "te_Value";
                        this.te_Value.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
                        this.te_Value.Properties.Appearance.Options.UseForeColor = true;
                        this.te_Value.Properties.AutoHeight = false;
                        this.te_Value.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, global::SinoSZMetaDataQuery.Properties.Resources.y7, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "区分大小写")});
                        this.te_Value.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
                        this.te_Value.Size = new System.Drawing.Size(135, 22);
                        this.te_Value.TabIndex = 10;
                        this.te_Value.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.te_Value_ButtonClick);
                        // 
                        // te_xh
                        // 
                        this.te_xh.Dock = System.Windows.Forms.DockStyle.Left;
                        this.te_xh.EditValue = "1";
                        this.te_xh.Location = new System.Drawing.Point(0, 1);
                        this.te_xh.Name = "te_xh";
                        this.te_xh.Properties.Appearance.BackColor = System.Drawing.Color.White;
                        this.te_xh.Properties.Appearance.Options.UseBackColor = true;
                        this.te_xh.Properties.Appearance.Options.UseTextOptions = true;
                        this.te_xh.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        this.te_xh.Properties.AutoHeight = false;
                        this.te_xh.Properties.ContextMenuStrip = this.contextMenuStrip1;
                        this.te_xh.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
                        this.te_xh.Properties.ReadOnly = true;
                        this.te_xh.Size = new System.Drawing.Size(25, 22);
                        this.te_xh.TabIndex = 11;
                        // 
                        // panel3
                        // 
                        this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
                        this.panel3.Location = new System.Drawing.Point(25, 1);
                        this.panel3.Name = "panel3";
                        this.panel3.Size = new System.Drawing.Size(2, 22);
                        this.panel3.TabIndex = 12;
                        // 
                        // SinoSZUC_ConditionItem
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.BackColor = System.Drawing.Color.Transparent;
                        this.ContextMenuStrip = this.contextMenuStrip1;
                        this.Controls.Add(this.te_Value);
                        this.Controls.Add(this.panel2);
                        this.Controls.Add(this.teOption);
                        this.Controls.Add(this.panel1);
                        this.Controls.Add(this.teColName);
                        this.Controls.Add(this.panel3);
                        this.Controls.Add(this.te_xh);
                        this.Name = "SinoSZUC_ConditionItem";
                        this.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
                        this.Size = new System.Drawing.Size(450, 24);
                        this.Leave += new System.EventHandler(this.SinoSZUC_ConditionItem_Leave);
                        this.Enter += new System.EventHandler(this.SinoSZUC_ConditionItem_Enter);
                        ((System.ComponentModel.ISupportInitialize)(this.teOption.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.teColName.Properties)).EndInit();
                        this.contextMenuStrip1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.te_Value.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_xh.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.Panel panel2;
                private System.Windows.Forms.Panel panel1;
                protected DevExpress.XtraEditors.ComboBoxEdit teOption;
                protected DevExpress.XtraEditors.TextEdit teColName;
                protected DevExpress.XtraEditors.ButtonEdit te_Value;
                protected DevExpress.XtraEditors.TextEdit te_xh;
                private System.Windows.Forms.Panel panel3;
                private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
                protected System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        }
}
