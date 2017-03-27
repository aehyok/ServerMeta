namespace SinoSZMetaDataManager
{
        partial class MenuManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuManager));
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TE_DISPLAYORDER = new SinoSZMetaDataManager.SinoSZTextEdit();
            this.TE_MENUNAME = new SinoSZMetaDataManager.SinoSZTextEdit();
            this.TE_ID = new SinoSZMetaDataManager.SinoSZTextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TE_CS = new SinoSZMetaDataManager.SinoSZMemoEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.TE_TOOLTIP = new SinoSZMetaDataManager.SinoSZTextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.TE_MenuType = new SinoSZMetaDataManager.SinoSZComboEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TE_TOOLBAR = new SinoSZMetaDataManager.SinoSZComboEdit();
            this.TE_ICON = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Pic_Show = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TE_DISPLAYORDER.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_MENUNAME.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_ID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_CS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_TOOLTIP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_MenuType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_TOOLBAR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_ICON.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Show)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "foward2.ico");
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tableLayoutPanel1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(0, 15, 11, 12);
            this.groupControl1.Size = new System.Drawing.Size(1081, 750);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "菜单管理";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.Controls.Add(this.TE_DISPLAYORDER, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.TE_MENUNAME, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.TE_ID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TE_CS, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.simpleButton1, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TE_TOOLTIP, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.TE_MenuType, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.TE_TOOLBAR, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.TE_ICON, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.Pic_Show, 2, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 41);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1066, 695);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // TE_DISPLAYORDER
            // 
            this.TE_DISPLAYORDER.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TE_DISPLAYORDER.Location = new System.Drawing.Point(174, 51);
            this.TE_DISPLAYORDER.Margin = new System.Windows.Forms.Padding(4);
            this.TE_DISPLAYORDER.Name = "TE_DISPLAYORDER";
            this.TE_DISPLAYORDER.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.TE_DISPLAYORDER.Properties.Appearance.Options.UseForeColor = true;
            this.TE_DISPLAYORDER.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.TE_DISPLAYORDER.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Blue;
            this.TE_DISPLAYORDER.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.TE_DISPLAYORDER.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.TE_DISPLAYORDER.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.TE_DISPLAYORDER.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.TE_DISPLAYORDER.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.TE_DISPLAYORDER.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.TE_DISPLAYORDER.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.TE_DISPLAYORDER.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TE_DISPLAYORDER.Properties.HideSelection = false;
            this.TE_DISPLAYORDER.Properties.Mask.EditMask = "d";
            this.TE_DISPLAYORDER.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.TE_DISPLAYORDER.Size = new System.Drawing.Size(354, 24);
            this.TE_DISPLAYORDER.TabIndex = 19;
            this.TE_DISPLAYORDER.EditValueChanged += new System.EventHandler(this.TE_DISPLAYORDER_EditValueChanged);
            // 
            // TE_MENUNAME
            // 
            this.TE_MENUNAME.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TE_MENUNAME.Location = new System.Drawing.Point(706, 9);
            this.TE_MENUNAME.Margin = new System.Windows.Forms.Padding(4);
            this.TE_MENUNAME.Name = "TE_MENUNAME";
            this.TE_MENUNAME.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.TE_MENUNAME.Properties.Appearance.Options.UseForeColor = true;
            this.TE_MENUNAME.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.TE_MENUNAME.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Blue;
            this.TE_MENUNAME.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.TE_MENUNAME.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.TE_MENUNAME.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.TE_MENUNAME.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.TE_MENUNAME.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.TE_MENUNAME.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.TE_MENUNAME.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.TE_MENUNAME.Size = new System.Drawing.Size(356, 24);
            this.TE_MENUNAME.TabIndex = 18;
            this.TE_MENUNAME.EditValueChanged += new System.EventHandler(this.TE_MENUNAME_EditValueChanged);
            // 
            // TE_ID
            // 
            this.TE_ID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TE_ID.Location = new System.Drawing.Point(174, 9);
            this.TE_ID.Margin = new System.Windows.Forms.Padding(4);
            this.TE_ID.Name = "TE_ID";
            this.TE_ID.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.TE_ID.Properties.Appearance.Options.UseForeColor = true;
            this.TE_ID.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.TE_ID.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Blue;
            this.TE_ID.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.TE_ID.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.TE_ID.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.TE_ID.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.TE_ID.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.TE_ID.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.TE_ID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.TE_ID.Properties.ReadOnly = true;
            this.TE_ID.Size = new System.Drawing.Size(354, 24);
            this.TE_ID.TabIndex = 17;
            this.TE_ID.EditValueChanged += new System.EventHandler(this.TE_ID_EditValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "菜单ID";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(630, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "菜单名称";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "显示顺序";
            // 
            // TE_CS
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.TE_CS, 3);
            this.TE_CS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TE_CS.Location = new System.Drawing.Point(174, 256);
            this.TE_CS.Margin = new System.Windows.Forms.Padding(4);
            this.TE_CS.Name = "TE_CS";
            this.TE_CS.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.TE_CS.Properties.Appearance.Options.UseForeColor = true;
            this.TE_CS.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.TE_CS.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Blue;
            this.TE_CS.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.TE_CS.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.TE_CS.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.TE_CS.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.TE_CS.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.TE_CS.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.TE_CS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.TE_CS.Size = new System.Drawing.Size(888, 435);
            this.TE_CS.TabIndex = 23;
            this.TE_CS.EditValueChanged += new System.EventHandler(this.TE_CS_EditValueChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(128, 256);
            this.label9.Margin = new System.Windows.Forms.Padding(4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 18);
            this.label9.TabIndex = 16;
            this.label9.Text = "参数";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.simpleButton1.Location = new System.Drawing.Point(962, 214);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(100, 33);
            this.simpleButton1.TabIndex = 26;
            this.simpleButton1.Text = "取参数定义";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(98, 96);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "浮动注解";
            // 
            // TE_TOOLTIP
            // 
            this.TE_TOOLTIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.TE_TOOLTIP, 3);
            this.TE_TOOLTIP.Location = new System.Drawing.Point(174, 93);
            this.TE_TOOLTIP.Margin = new System.Windows.Forms.Padding(4);
            this.TE_TOOLTIP.Name = "TE_TOOLTIP";
            this.TE_TOOLTIP.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.TE_TOOLTIP.Properties.Appearance.Options.UseForeColor = true;
            this.TE_TOOLTIP.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.TE_TOOLTIP.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Blue;
            this.TE_TOOLTIP.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.TE_TOOLTIP.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.TE_TOOLTIP.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.TE_TOOLTIP.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.TE_TOOLTIP.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.TE_TOOLTIP.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.TE_TOOLTIP.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.TE_TOOLTIP.Size = new System.Drawing.Size(888, 24);
            this.TE_TOOLTIP.TabIndex = 20;
            this.TE_TOOLTIP.EditValueChanged += new System.EventHandler(this.TE_TOOLTIP_EditValueChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(98, 138);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 18);
            this.label7.TabIndex = 24;
            this.label7.Text = "菜单类型";
            // 
            // TE_MenuType
            // 
            this.TE_MenuType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.TE_MenuType, 3);
            this.TE_MenuType.Location = new System.Drawing.Point(174, 135);
            this.TE_MenuType.Margin = new System.Windows.Forms.Padding(4);
            this.TE_MenuType.Name = "TE_MenuType";
            this.TE_MenuType.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.TE_MenuType.Properties.Appearance.Options.UseForeColor = true;
            this.TE_MenuType.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.TE_MenuType.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Blue;
            this.TE_MenuType.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.TE_MenuType.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.TE_MenuType.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.TE_MenuType.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.TE_MenuType.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.TE_MenuType.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.TE_MenuType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.TE_MenuType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TE_MenuType.Size = new System.Drawing.Size(888, 24);
            this.TE_MenuType.TabIndex = 25;
            this.TE_MenuType.SelectedIndexChanged += new System.EventHandler(this.TE_MenuType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(98, 180);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "显示图标";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(580, 54);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "在ToolBar中显示";
            // 
            // TE_TOOLBAR
            // 
            this.TE_TOOLBAR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TE_TOOLBAR.Location = new System.Drawing.Point(706, 51);
            this.TE_TOOLBAR.Margin = new System.Windows.Forms.Padding(4);
            this.TE_TOOLBAR.Name = "TE_TOOLBAR";
            this.TE_TOOLBAR.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.TE_TOOLBAR.Properties.Appearance.Options.UseForeColor = true;
            this.TE_TOOLBAR.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.TE_TOOLBAR.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Blue;
            this.TE_TOOLBAR.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.TE_TOOLBAR.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.TE_TOOLBAR.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.TE_TOOLBAR.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.TE_TOOLBAR.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.TE_TOOLBAR.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.TE_TOOLBAR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.TE_TOOLBAR.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TE_TOOLBAR.Properties.Items.AddRange(new object[] {
            "是",
            "否"});
            this.TE_TOOLBAR.Size = new System.Drawing.Size(356, 24);
            this.TE_TOOLBAR.TabIndex = 22;
            this.TE_TOOLBAR.SelectedIndexChanged += new System.EventHandler(this.TE_TOOLBAR_SelectedIndexChanged);
            // 
            // TE_ICON
            // 
            this.TE_ICON.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TE_ICON.Location = new System.Drawing.Point(174, 172);
            this.TE_ICON.Margin = new System.Windows.Forms.Padding(4);
            this.TE_ICON.Name = "TE_ICON";
            this.TE_ICON.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TE_ICON.Size = new System.Drawing.Size(354, 24);
            this.TE_ICON.TabIndex = 28;
            this.TE_ICON.SelectedIndexChanged += new System.EventHandler(this.TE_ICON_SelectedIndexChanged_1);
            this.TE_ICON.EditValueChanged += new System.EventHandler(this.TE_ICON_EditValueChanged_1);
            // 
            // Pic_Show
            // 
            this.Pic_Show.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Pic_Show.Location = new System.Drawing.Point(536, 172);
            this.Pic_Show.Margin = new System.Windows.Forms.Padding(4);
            this.Pic_Show.Name = "Pic_Show";
            this.tableLayoutPanel1.SetRowSpan(this.Pic_Show, 2);
            this.Pic_Show.Size = new System.Drawing.Size(162, 76);
            this.Pic_Show.TabIndex = 29;
            this.Pic_Show.TabStop = false;
            // 
            // MenuManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuManager";
            this.Size = new System.Drawing.Size(1081, 750);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TE_DISPLAYORDER.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_MENUNAME.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_ID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_CS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_TOOLTIP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_MenuType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_TOOLBAR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_ICON.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Show)).EndInit();
            this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.GroupControl groupControl1;
                private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
                private SinoSZTextEdit TE_DISPLAYORDER;
                private SinoSZTextEdit TE_MENUNAME;
                private System.Windows.Forms.Label label9;
                private System.Windows.Forms.Label label6;
                private System.Windows.Forms.Label label5;
                private System.Windows.Forms.Label label4;
                private SinoSZTextEdit TE_ID;
                private SinoSZTextEdit TE_TOOLTIP;
                private SinoSZComboEdit TE_TOOLBAR;
                private SinoSZMemoEdit TE_CS;
                private System.Windows.Forms.Label label2;
                private System.Windows.Forms.Label label3;
                private System.Windows.Forms.Label label1;
                private System.Windows.Forms.Label label7;
                private SinoSZComboEdit TE_MenuType;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private System.Windows.Forms.ImageList imageList1;
		private DevExpress.XtraEditors.ComboBoxEdit TE_ICON;
		private System.Windows.Forms.PictureBox Pic_Show;
        }
}
