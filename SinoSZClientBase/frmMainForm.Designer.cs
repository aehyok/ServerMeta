namespace SinoSZClientBase
{
        partial class frmMainForm
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
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainForm));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barCurrentUser = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barCurrentPost = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.barCurrentOrg = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barLogout = new DevExpress.XtraBars.BarButtonItem();
            this.barChangePass = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barVersion = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageCategory1 = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.MdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.popupControlContainer1 = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.SysMsgBox = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer_PandingAlert = new System.Windows.Forms.Timer(this.components);
            this.popupControlContainer2 = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer_Iconflash = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MdiManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainer1)).BeginInit();
            this.popupControlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainer2)).BeginInit();
            this.popupControlContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationIcon = global::SinoSZClientBase.Properties.Resources.logo_1;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barCurrentUser,
            this.barCurrentPost,
            this.barCurrentOrg,
            this.barLogout,
            this.barChangePass,
            this.barButtonItem1,
            this.barVersion});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ribbon.MaxItemId = 9;
            this.ribbon.Name = "ribbon";
            this.ribbon.PageCategories.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageCategory[] {
            this.ribbonPageCategory1});
            this.ribbon.PageCategoryAlignment = DevExpress.XtraBars.Ribbon.RibbonPageCategoryAlignment.Right;
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemComboBox1,
            this.repositoryItemTextEdit2});
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(1186, 50);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ItemLinks.Add(this.barLogout);
            this.ribbon.Toolbar.ItemLinks.Add(this.barChangePass);
            this.ribbon.Toolbar.ItemLinks.Add(this.barVersion);
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // barCurrentUser
            // 
            this.barCurrentUser.Caption = " 当前用户";
            this.barCurrentUser.Edit = this.repositoryItemTextEdit1;
            this.barCurrentUser.Glyph = global::SinoSZClientBase.Properties.Resources.y12;
            this.barCurrentUser.Id = 0;
            this.barCurrentUser.Name = "barCurrentUser";
            this.barCurrentUser.Width = 120;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.repositoryItemTextEdit1.AppearanceReadOnly.BackColor2 = System.Drawing.Color.White;
            this.repositoryItemTextEdit1.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.repositoryItemTextEdit1.AppearanceReadOnly.Options.UseBackColor = true;
            this.repositoryItemTextEdit1.AppearanceReadOnly.Options.UseForeColor = true;
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.ReadOnly = true;
            // 
            // barCurrentPost
            // 
            this.barCurrentPost.Caption = " 当前岗位";
            this.barCurrentPost.Edit = this.repositoryItemComboBox1;
            this.barCurrentPost.Glyph = global::SinoSZClientBase.Properties.Resources.y11;
            this.barCurrentPost.Id = 1;
            this.barCurrentPost.Name = "barCurrentPost";
            this.barCurrentPost.Width = 230;
            this.barCurrentPost.EditValueChanged += new System.EventHandler(this.barCurrentPost_EditValueChanged);
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.repositoryItemComboBox1.AppearanceReadOnly.BackColor2 = System.Drawing.Color.White;
            this.repositoryItemComboBox1.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.repositoryItemComboBox1.AppearanceReadOnly.Options.UseBackColor = true;
            this.repositoryItemComboBox1.AppearanceReadOnly.Options.UseForeColor = true;
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // barCurrentOrg
            // 
            this.barCurrentOrg.Caption = " 当前单位";
            this.barCurrentOrg.Edit = this.repositoryItemTextEdit2;
            this.barCurrentOrg.Glyph = global::SinoSZClientBase.Properties.Resources.finances__add__16x16;
            this.barCurrentOrg.Id = 2;
            this.barCurrentOrg.Name = "barCurrentOrg";
            this.barCurrentOrg.Width = 250;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.repositoryItemTextEdit2.AppearanceReadOnly.BackColor2 = System.Drawing.Color.White;
            this.repositoryItemTextEdit2.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.repositoryItemTextEdit2.AppearanceReadOnly.Options.UseBackColor = true;
            this.repositoryItemTextEdit2.AppearanceReadOnly.Options.UseForeColor = true;
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            this.repositoryItemTextEdit2.ReadOnly = true;
            // 
            // barLogout
            // 
            this.barLogout.Caption = "注销";
            this.barLogout.Glyph = global::SinoSZClientBase.Properties.Resources.y3;
            this.barLogout.Id = 3;
            this.barLogout.Name = "barLogout";
            toolTipTitleItem1.Appearance.Image = global::SinoSZClientBase.Properties.Resources.y3;
            toolTipTitleItem1.Appearance.Options.UseImage = true;
            toolTipTitleItem1.Image = global::SinoSZClientBase.Properties.Resources.y3;
            toolTipTitleItem1.Text = "注销";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "退出系统,并可以使用其它用户的口令重新进入系统。";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.barLogout.SuperTip = superToolTip1;
            this.barLogout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barLogout_ItemClick);
            // 
            // barChangePass
            // 
            this.barChangePass.Caption = "修改口令";
            this.barChangePass.Glyph = global::SinoSZClientBase.Properties.Resources.y2;
            this.barChangePass.Id = 4;
            this.barChangePass.Name = "barChangePass";
            toolTipTitleItem2.Appearance.Image = global::SinoSZClientBase.Properties.Resources.y2;
            toolTipTitleItem2.Appearance.Options.UseImage = true;
            toolTipTitleItem2.Image = global::SinoSZClientBase.Properties.Resources.y2;
            toolTipTitleItem2.Text = "修改口令";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "修改用户的登录密码，以保证口令的安全。";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.barChangePass.SuperTip = superToolTip2;
            this.barChangePass.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barChangePass_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem1.Glyph = global::SinoSZClientBase.Properties.Resources.information_16x16;
            this.barButtonItem1.Id = 6;
            this.barButtonItem1.LargeWidth = 20;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            toolTipTitleItem3.Appearance.Image = global::SinoSZClientBase.Properties.Resources.Alert;
            toolTipTitleItem3.Appearance.Options.UseImage = true;
            toolTipTitleItem3.Image = global::SinoSZClientBase.Properties.Resources.Alert;
            toolTipTitleItem3.Text = "系统信息";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "显示系统运行过程中产生的异常信息及提示。";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem3);
            this.barButtonItem1.SuperTip = superToolTip3;
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barVersion
            // 
            this.barVersion.Caption = "版本变更信息";
            this.barVersion.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barVersion.Glyph = global::SinoSZClientBase.Properties.Resources.comment1_16x16;
            this.barVersion.Id = 8;
            this.barVersion.Name = "barVersion";
            toolTipTitleItem4.Appearance.Image = global::SinoSZClientBase.Properties.Resources.comment1_16x16;
            toolTipTitleItem4.Appearance.Options.UseImage = true;
            toolTipTitleItem4.Image = global::SinoSZClientBase.Properties.Resources.comment1_16x16;
            toolTipTitleItem4.Text = "版本变更信息";
            toolTipItem4.LeftIndent = 6;
            toolTipItem4.Text = "显示所有版本修正和功能变更的情况";
            superToolTip4.Items.Add(toolTipTitleItem4);
            superToolTip4.Items.Add(toolTipItem4);
            this.barVersion.SuperTip = superToolTip4;
            this.barVersion.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barVersion_ItemClick);
            // 
            // ribbonPageCategory1
            // 
            this.ribbonPageCategory1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ribbonPageCategory1.Name = "ribbonPageCategory1";
            this.ribbonPageCategory1.Text = "功能区";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barCurrentUser);
            this.ribbonStatusBar.ItemLinks.Add(this.barCurrentPost);
            this.ribbonStatusBar.ItemLinks.Add(this.barCurrentOrg);
            this.ribbonStatusBar.ItemLinks.Add(this.barButtonItem1);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 674);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1186, 31);
            // 
            // MdiManager
            // 
            this.MdiManager.AllowDragDrop = DevExpress.Utils.DefaultBoolean.True;
            this.MdiManager.HeaderButtonsShowMode = DevExpress.XtraTab.TabButtonShowMode.Always;
            this.MdiManager.MdiParent = this;
            this.MdiManager.ShowHeaderFocus = DevExpress.Utils.DefaultBoolean.True;
            this.MdiManager.SelectedPageChanged += new System.EventHandler(this.MdiManager_SelectedPageChanged);
            this.MdiManager.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MdiManager_MouseDown);
            this.MdiManager.PageRemoved += new DevExpress.XtraTabbedMdi.MdiTabPageEventHandler(this.MdiManager_PageRemoved);
            // 
            // popupControlContainer1
            // 
            this.popupControlContainer1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupControlContainer1.Controls.Add(this.groupControl1);
            this.popupControlContainer1.Location = new System.Drawing.Point(801, 264);
            this.popupControlContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.popupControlContainer1.Name = "popupControlContainer1";
            this.popupControlContainer1.Ribbon = this.ribbon;
            this.popupControlContainer1.Size = new System.Drawing.Size(304, 187);
            this.popupControlContainer1.TabIndex = 3;
            this.popupControlContainer1.Visible = false;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Image = global::SinoSZClientBase.Properties.Resources.attention1_16x16;
            this.groupControl1.AppearanceCaption.Options.UseImage = true;
            this.groupControl1.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.groupControl1.Controls.Add(this.SysMsgBox);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(304, 187);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "系统信息";
            // 
            // SysMsgBox
            // 
            this.SysMsgBox.AcceptsReturn = true;
            this.SysMsgBox.BackColor = System.Drawing.Color.LightCyan;
            this.SysMsgBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SysMsgBox.ForeColor = System.Drawing.Color.Blue;
            this.SysMsgBox.Location = new System.Drawing.Point(2, 22);
            this.SysMsgBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SysMsgBox.Multiline = true;
            this.SysMsgBox.Name = "SysMsgBox";
            this.SysMsgBox.ReadOnly = true;
            this.SysMsgBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SysMsgBox.Size = new System.Drawing.Size(300, 163);
            this.SysMsgBox.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer_PandingAlert
            // 
            this.timer_PandingAlert.Interval = 120000;
            this.timer_PandingAlert.Tick += new System.EventHandler(this.timer_PandingAlert_Tick);
            // 
            // popupControlContainer2
            // 
            this.popupControlContainer2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupControlContainer2.Controls.Add(this.panelControl1);
            this.popupControlContainer2.Location = new System.Drawing.Point(815, 527);
            this.popupControlContainer2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.popupControlContainer2.Name = "popupControlContainer2";
            this.popupControlContainer2.Ribbon = this.ribbon;
            this.popupControlContainer2.Size = new System.Drawing.Size(318, 218);
            this.popupControlContainer2.TabIndex = 4;
            this.popupControlContainer2.Visible = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.panel1);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(318, 218);
            this.panelControl1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 188);
            this.panel1.TabIndex = 1;
            // 
            // panelControl2
            // 
            this.panelControl2.ContentImage = global::SinoSZClientBase.Properties.Resources.comment1_16x16;
            this.panelControl2.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(314, 26);
            this.panelControl2.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(28, 5);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "待办事项提醒";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.notifyIcon1.BalloonTipText = "您有新的待办事项";
            this.notifyIcon1.BalloonTipTitle = "待办事项提示";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "待办事项提醒";
            this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_BalloonTipClicked);
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // timer_Iconflash
            // 
            this.timer_Iconflash.Interval = 500;
            this.timer_Iconflash.Tag = "0";
            this.timer_Iconflash.Tick += new System.EventHandler(this.timer_Iconflash_Tick);
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 705);
            this.Controls.Add(this.popupControlContainer2);
            this.Controls.Add(this.popupControlContainer1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmMainForm";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMainForm_FormClosed);
            this.Load += new System.EventHandler(this.frmMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MdiManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainer1)).EndInit();
            this.popupControlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainer2)).EndInit();
            this.popupControlContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

                }

                #endregion

                private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
                private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
                protected DevExpress.XtraTabbedMdi.XtraTabbedMdiManager MdiManager;
                private DevExpress.XtraBars.BarEditItem barCurrentUser;
                private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
                private DevExpress.XtraBars.BarEditItem barCurrentPost;
                private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
                private DevExpress.XtraBars.BarEditItem barCurrentOrg;
                private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
                private DevExpress.XtraBars.BarButtonItem barLogout;
                private DevExpress.XtraBars.BarButtonItem barChangePass;
                private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategory1;
                private DevExpress.XtraBars.BarButtonItem barButtonItem1;
                private DevExpress.XtraBars.PopupControlContainer popupControlContainer1;
                private DevExpress.XtraEditors.GroupControl groupControl1;
                private System.Windows.Forms.Timer timer1;
                private System.Windows.Forms.TextBox SysMsgBox;
                private System.Windows.Forms.Timer timer_PandingAlert;
                private DevExpress.XtraBars.PopupControlContainer popupControlContainer2;
                private DevExpress.XtraEditors.PanelControl panelControl1;
                private DevExpress.XtraEditors.PanelControl panelControl2;
                private System.Windows.Forms.Panel panel1;
                private DevExpress.XtraEditors.LabelControl labelControl1;
                private System.Windows.Forms.NotifyIcon notifyIcon1;
                private System.Windows.Forms.Timer timer_Iconflash;
                private DevExpress.XtraBars.BarButtonItem barVersion;
        }
}