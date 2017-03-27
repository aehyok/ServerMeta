namespace SinoSZMetaDataQuery.Common
{
        partial class SinoSZUC_ConditionPanel
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
                        this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
                        this.panel1 = new System.Windows.Forms.Panel();
                        this.textEdit1 = new DevExpress.XtraEditors.PopupContainerEdit();
                        this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
                        this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
                        this.label1 = new System.Windows.Forms.Label();
                        ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
                        this.xtraTabControl1.SuspendLayout();
                        this.xtraTabPage1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
                        this.panelControl1.SuspendLayout();
                        this.panel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
                        this.popupContainerControl1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // xtraTabControl1
                        // 
                        this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
                        this.xtraTabControl1.LookAndFeel.UseDefaultLookAndFeel = false;
                        this.xtraTabControl1.Name = "xtraTabControl1";
                        this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
                        this.xtraTabControl1.Size = new System.Drawing.Size(592, 464);
                        this.xtraTabControl1.TabIndex = 6;
                        this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
                        this.xtraTabControl1.Text = "xtraTabControl1";
                        // 
                        // xtraTabPage1
                        // 
                        this.xtraTabPage1.Controls.Add(this.panelControl1);
                        this.xtraTabPage1.Controls.Add(this.panel1);
                        this.xtraTabPage1.Name = "xtraTabPage1";
                        this.xtraTabPage1.Padding = new System.Windows.Forms.Padding(5);
                        this.xtraTabPage1.Size = new System.Drawing.Size(583, 432);
                        this.xtraTabPage1.Text = "查询条件设置";
                        // 
                        // panelControl1
                        // 
                        this.panelControl1.Controls.Add(this.xtraScrollableControl1);
                        this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.panelControl1.Location = new System.Drawing.Point(5, 5);
                        this.panelControl1.Name = "panelControl1";
                        this.panelControl1.Size = new System.Drawing.Size(573, 387);
                        this.panelControl1.TabIndex = 2;
                        // 
                        // xtraScrollableControl1
                        // 
                        this.xtraScrollableControl1.AllowDrop = true;
                        this.xtraScrollableControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(240)))));
                        this.xtraScrollableControl1.Appearance.BackColor2 = System.Drawing.Color.White;
                        this.xtraScrollableControl1.Appearance.Options.UseBackColor = true;
                        this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.xtraScrollableControl1.Location = new System.Drawing.Point(2, 2);
                        this.xtraScrollableControl1.Name = "xtraScrollableControl1";
                        this.xtraScrollableControl1.Padding = new System.Windows.Forms.Padding(3);
                        this.xtraScrollableControl1.Size = new System.Drawing.Size(569, 383);
                        this.xtraScrollableControl1.TabIndex = 1;
                        this.xtraScrollableControl1.DragDrop += new System.Windows.Forms.DragEventHandler(this.xtraScrollableControl1_DragDrop);
                        this.xtraScrollableControl1.DragLeave += new System.EventHandler(this.xtraScrollableControl1_DragLeave);
                        this.xtraScrollableControl1.DragEnter += new System.Windows.Forms.DragEventHandler(this.xtraScrollableControl1_DragEnter);
                        // 
                        // panel1
                        // 
                        this.panel1.Controls.Add(this.textEdit1);
                        this.panel1.Controls.Add(this.label1);
                        this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.panel1.Location = new System.Drawing.Point(5, 392);
                        this.panel1.Name = "panel1";
                        this.panel1.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
                        this.panel1.Size = new System.Drawing.Size(573, 35);
                        this.panel1.TabIndex = 0;
                        // 
                        // textEdit1
                        // 
                        this.textEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.textEdit1.Location = new System.Drawing.Point(96, 6);
                        this.textEdit1.Name = "textEdit1";
                        this.textEdit1.Properties.AutoHeight = false;
                        this.textEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, global::SinoSZMetaDataQuery.Properties.Resources._00984)});
                        this.textEdit1.Properties.PopupControl = this.popupContainerControl1;
                        this.textEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                        this.textEdit1.Size = new System.Drawing.Size(477, 23);
                        this.textEdit1.TabIndex = 0;
                        this.textEdit1.SizeChanged += new System.EventHandler(this.textEdit1_SizeChanged);
                        // 
                        // popupContainerControl1
                        // 
                        this.popupContainerControl1.Appearance.Options.UseTextOptions = true;
                        this.popupContainerControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        this.popupContainerControl1.AutoSize = true;
                        this.popupContainerControl1.Controls.Add(this.memoEdit1);
                        this.popupContainerControl1.Location = new System.Drawing.Point(100, 300);
                        this.popupContainerControl1.Name = "popupContainerControl1";
                        this.popupContainerControl1.Size = new System.Drawing.Size(300, 200);
                        this.popupContainerControl1.TabIndex = 7;
                        // 
                        // memoEdit1
                        // 
                        this.memoEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.memoEdit1.EditValue = "条件表达式以项目序号和逻辑运算符构成。其中：\r\n\t星号（*）代表“and”逻辑\r\n\t加号（+）代表“or”逻辑\r\n\t叹号（！）代表“not”逻辑\r\n在条件表" +
                            "达式中可以使用括号来改变逻辑运算的优先级。如\r\n 1*（2+3）  表示满足： 条件项1 且 （条件项2 或 条件项3）";
                        this.memoEdit1.Location = new System.Drawing.Point(0, 0);
                        this.memoEdit1.Name = "memoEdit1";
                        this.memoEdit1.Properties.Appearance.BackColor = System.Drawing.Color.LightCyan;
                        this.memoEdit1.Properties.Appearance.Options.UseBackColor = true;
                        this.memoEdit1.Properties.ReadOnly = true;
                        this.memoEdit1.Size = new System.Drawing.Size(300, 200);
                        this.memoEdit1.TabIndex = 0;
                        // 
                        // label1
                        // 
                        this.label1.Dock = System.Windows.Forms.DockStyle.Left;
                        this.label1.Location = new System.Drawing.Point(0, 6);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(96, 23);
                        this.label1.TabIndex = 0;
                        this.label1.Text = "设置条件表达式";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // SinoSZUC_ConditionPanel
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.BackColor = System.Drawing.Color.Transparent;
                        this.Controls.Add(this.popupContainerControl1);
                        this.Controls.Add(this.xtraTabControl1);
                        this.Name = "SinoSZUC_ConditionPanel";
                        this.Size = new System.Drawing.Size(592, 464);
                        ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
                        this.xtraTabControl1.ResumeLayout(false);
                        this.xtraTabPage1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
                        this.panelControl1.ResumeLayout(false);
                        this.panel1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
                        this.popupContainerControl1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
                private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
                private DevExpress.XtraEditors.PanelControl panelControl1;
                private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
                private System.Windows.Forms.Panel panel1;
                private System.Windows.Forms.Label label1;
                private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
                private DevExpress.XtraEditors.PopupContainerEdit textEdit1;
                private DevExpress.XtraEditors.MemoEdit memoEdit1;
        }
}
