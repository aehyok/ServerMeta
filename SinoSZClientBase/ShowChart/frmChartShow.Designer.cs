namespace SinoSZClientBase.ShowChart
{
        partial class frmChartShow
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
                        this.CB_SORTTYPE = new DevExpress.XtraEditors.ComboBoxEdit();
                        this.CB_ITEMCOUNT = new DevExpress.XtraEditors.ComboBoxEdit();
                        this.CB_SORTLIST = new DevExpress.XtraEditors.ComboBoxEdit();
                        this.CB_XLIST = new DevExpress.XtraEditors.ComboBoxEdit();
                        this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
                        this.CB_CHARTTYPE = new DevExpress.XtraEditors.ComboBoxEdit();
                        this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
                        this.CB_YLIST = new DevExpress.XtraEditors.CheckedListBoxControl();
                        this.panelShow = new DevExpress.XtraEditors.PanelControl();
                        this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
                        this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
                        this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
                        this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
                        this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
                        this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
                        this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
                        this.panel1 = new System.Windows.Forms.Panel();
                        this.label2 = new System.Windows.Forms.Label();
                        this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
                        this.label1 = new System.Windows.Forms.Label();
                        ((System.ComponentModel.ISupportInitialize)(this.CB_SORTTYPE.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.CB_ITEMCOUNT.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.CB_SORTLIST.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.CB_XLIST.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.CB_CHARTTYPE.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.CB_YLIST)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.panelShow)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
                        this.panelControl3.SuspendLayout();
                        this.tableLayoutPanel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
                        this.panel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // CB_SORTTYPE
                        // 
                        this.CB_SORTTYPE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.CB_SORTTYPE.EditValue = "降序";
                        this.CB_SORTTYPE.Location = new System.Drawing.Point(923, 7);
                        this.CB_SORTTYPE.Name = "CB_SORTTYPE";
                        this.CB_SORTTYPE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.CB_SORTTYPE.Properties.Items.AddRange(new object[] {
            "降序",
            "升序"});
                        this.CB_SORTTYPE.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                        this.CB_SORTTYPE.Size = new System.Drawing.Size(54, 21);
                        this.CB_SORTTYPE.TabIndex = 10;
                        this.CB_SORTTYPE.SelectedIndexChanged += new System.EventHandler(this.CB_SORTTYPE_SelectedIndexChanged);
                        // 
                        // CB_ITEMCOUNT
                        // 
                        this.CB_ITEMCOUNT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.CB_ITEMCOUNT.EditValue = "15";
                        this.CB_ITEMCOUNT.Location = new System.Drawing.Point(623, 7);
                        this.CB_ITEMCOUNT.Name = "CB_ITEMCOUNT";
                        this.CB_ITEMCOUNT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.CB_ITEMCOUNT.Properties.Items.AddRange(new object[] {
            "全部",
            "5",
            "10",
            "15",
            "20",
            "25",
            "50",
            "100"});
                        this.CB_ITEMCOUNT.Properties.Mask.EditMask = "n0";
                        this.CB_ITEMCOUNT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        this.CB_ITEMCOUNT.Size = new System.Drawing.Size(54, 21);
                        this.CB_ITEMCOUNT.TabIndex = 9;
                        this.CB_ITEMCOUNT.SelectedIndexChanged += new System.EventHandler(this.CB_ITEMCOUNT_SelectedIndexChanged);
                        // 
                        // CB_SORTLIST
                        // 
                        this.CB_SORTLIST.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.CB_SORTLIST.EditValue = "";
                        this.CB_SORTLIST.Location = new System.Drawing.Point(743, 7);
                        this.CB_SORTLIST.Name = "CB_SORTLIST";
                        this.CB_SORTLIST.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.CB_SORTLIST.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                        this.CB_SORTLIST.Size = new System.Drawing.Size(114, 21);
                        this.CB_SORTLIST.TabIndex = 6;
                        this.CB_SORTLIST.SelectedIndexChanged += new System.EventHandler(this.CB_SORTLIST_SelectedIndexChanged);
                        // 
                        // CB_XLIST
                        // 
                        this.CB_XLIST.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.CB_XLIST.EditValue = "";
                        this.CB_XLIST.Location = new System.Drawing.Point(423, 8);
                        this.CB_XLIST.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
                        this.CB_XLIST.Name = "CB_XLIST";
                        this.CB_XLIST.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.CB_XLIST.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                        this.CB_XLIST.Size = new System.Drawing.Size(114, 21);
                        this.CB_XLIST.TabIndex = 2;
                        this.CB_XLIST.SelectedIndexChanged += new System.EventHandler(this.CB_XLIST_SelectedIndexChanged);
                        // 
                        // labelControl1
                        // 
                        this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.labelControl1.Appearance.Options.UseTextOptions = true;
                        this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
                        this.labelControl1.Location = new System.Drawing.Point(183, 3);
                        this.labelControl1.Name = "labelControl1";
                        this.labelControl1.Size = new System.Drawing.Size(54, 30);
                        this.labelControl1.TabIndex = 1;
                        this.labelControl1.Text = "图表类型";
                        // 
                        // CB_CHARTTYPE
                        // 
                        this.CB_CHARTTYPE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.CB_CHARTTYPE.EditValue = "";
                        this.CB_CHARTTYPE.Location = new System.Drawing.Point(243, 8);
                        this.CB_CHARTTYPE.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
                        this.CB_CHARTTYPE.Name = "CB_CHARTTYPE";
                        this.CB_CHARTTYPE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.CB_CHARTTYPE.Properties.Items.AddRange(new object[] {
            "柱状图",
            "线型图",
            "饼状图"});
                        this.CB_CHARTTYPE.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                        this.CB_CHARTTYPE.Size = new System.Drawing.Size(94, 21);
                        this.CB_CHARTTYPE.TabIndex = 0;
                        this.CB_CHARTTYPE.SelectedIndexChanged += new System.EventHandler(this.CB_CHARTTYPE_SelectedIndexChanged);
                        // 
                        // labelControl3
                        // 
                        this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.labelControl3.Appearance.Options.UseTextOptions = true;
                        this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                        this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
                        this.labelControl3.Location = new System.Drawing.Point(3, 3);
                        this.labelControl3.Name = "labelControl3";
                        this.labelControl3.Size = new System.Drawing.Size(174, 30);
                        this.labelControl3.TabIndex = 5;
                        this.labelControl3.Text = "   纵坐标字段";
                        // 
                        // CB_YLIST
                        // 
                        this.CB_YLIST.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.CB_YLIST.CheckOnClick = true;
                        this.CB_YLIST.ItemHeight = 22;
                        this.CB_YLIST.Location = new System.Drawing.Point(3, 39);
                        this.CB_YLIST.Name = "CB_YLIST";
                        this.CB_YLIST.Size = new System.Drawing.Size(174, 426);
                        this.CB_YLIST.TabIndex = 8;
                        this.CB_YLIST.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.CB_YLIST_ItemCheck);
                        // 
                        // panelShow
                        // 
                        this.panelShow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.tableLayoutPanel1.SetColumnSpan(this.panelShow, 11);
                        this.panelShow.Location = new System.Drawing.Point(183, 39);
                        this.panelShow.Name = "panelShow";
                        this.tableLayoutPanel1.SetRowSpan(this.panelShow, 3);
                        this.panelShow.Size = new System.Drawing.Size(794, 486);
                        this.panelShow.TabIndex = 3;
                        // 
                        // panelControl3
                        // 
                        this.panelControl3.Controls.Add(this.tableLayoutPanel1);
                        this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.panelControl3.Location = new System.Drawing.Point(5, 5);
                        this.panelControl3.Name = "panelControl3";
                        this.panelControl3.Size = new System.Drawing.Size(984, 532);
                        this.panelControl3.TabIndex = 4;
                        // 
                        // tableLayoutPanel1
                        // 
                        this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
                        this.tableLayoutPanel1.ColumnCount = 12;
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tableLayoutPanel1.Controls.Add(this.CB_YLIST, 0, 1);
                        this.tableLayoutPanel1.Controls.Add(this.panelShow, 1, 1);
                        this.tableLayoutPanel1.Controls.Add(this.labelControl9, 9, 0);
                        this.tableLayoutPanel1.Controls.Add(this.CB_SORTTYPE, 10, 0);
                        this.tableLayoutPanel1.Controls.Add(this.labelControl8, 7, 0);
                        this.tableLayoutPanel1.Controls.Add(this.labelControl7, 5, 0);
                        this.tableLayoutPanel1.Controls.Add(this.labelControl3, 0, 0);
                        this.tableLayoutPanel1.Controls.Add(this.CB_ITEMCOUNT, 6, 0);
                        this.tableLayoutPanel1.Controls.Add(this.CB_SORTLIST, 8, 0);
                        this.tableLayoutPanel1.Controls.Add(this.labelControl1, 1, 0);
                        this.tableLayoutPanel1.Controls.Add(this.labelControl2, 3, 0);
                        this.tableLayoutPanel1.Controls.Add(this.CB_CHARTTYPE, 2, 0);
                        this.tableLayoutPanel1.Controls.Add(this.CB_XLIST, 4, 0);
                        this.tableLayoutPanel1.Controls.Add(this.checkEdit1, 0, 3);
                        this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
                        this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
                        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
                        this.tableLayoutPanel1.RowCount = 4;
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
                        this.tableLayoutPanel1.Size = new System.Drawing.Size(980, 528);
                        this.tableLayoutPanel1.TabIndex = 0;
                        // 
                        // labelControl9
                        // 
                        this.labelControl9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.labelControl9.Appearance.Options.UseTextOptions = true;
                        this.labelControl9.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        this.labelControl9.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
                        this.labelControl9.Location = new System.Drawing.Point(863, 3);
                        this.labelControl9.Name = "labelControl9";
                        this.labelControl9.Size = new System.Drawing.Size(54, 30);
                        this.labelControl9.TabIndex = 11;
                        this.labelControl9.Text = "排序方式";
                        // 
                        // labelControl8
                        // 
                        this.labelControl8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.labelControl8.Appearance.Options.UseTextOptions = true;
                        this.labelControl8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        this.labelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
                        this.labelControl8.Location = new System.Drawing.Point(683, 3);
                        this.labelControl8.Name = "labelControl8";
                        this.labelControl8.Size = new System.Drawing.Size(54, 30);
                        this.labelControl8.TabIndex = 10;
                        this.labelControl8.Text = "排序字段";
                        // 
                        // labelControl7
                        // 
                        this.labelControl7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.labelControl7.Appearance.Options.UseTextOptions = true;
                        this.labelControl7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
                        this.labelControl7.Location = new System.Drawing.Point(543, 3);
                        this.labelControl7.Name = "labelControl7";
                        this.labelControl7.Size = new System.Drawing.Size(74, 30);
                        this.labelControl7.TabIndex = 7;
                        this.labelControl7.Text = "显示记录数";
                        // 
                        // labelControl2
                        // 
                        this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.labelControl2.Appearance.Options.UseTextOptions = true;
                        this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
                        this.labelControl2.Location = new System.Drawing.Point(343, 3);
                        this.labelControl2.Name = "labelControl2";
                        this.labelControl2.Size = new System.Drawing.Size(74, 30);
                        this.labelControl2.TabIndex = 6;
                        this.labelControl2.Text = "横坐标字段";
                        // 
                        // checkEdit1
                        // 
                        this.checkEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.checkEdit1.Location = new System.Drawing.Point(10, 503);
                        this.checkEdit1.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
                        this.checkEdit1.Name = "checkEdit1";
                        this.checkEdit1.Properties.Caption = "允许使用鼠标选择";
                        this.checkEdit1.Size = new System.Drawing.Size(167, 19);
                        this.checkEdit1.TabIndex = 12;
                        this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
                        // 
                        // panel1
                        // 
                        this.panel1.Controls.Add(this.label2);
                        this.panel1.Controls.Add(this.spinEdit1);
                        this.panel1.Controls.Add(this.label1);
                        this.panel1.Location = new System.Drawing.Point(3, 471);
                        this.panel1.Name = "panel1";
                        this.panel1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
                        this.panel1.Size = new System.Drawing.Size(174, 24);
                        this.panel1.TabIndex = 13;
                        // 
                        // label2
                        // 
                        this.label2.Dock = System.Windows.Forms.DockStyle.Left;
                        this.label2.Location = new System.Drawing.Point(122, 2);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(49, 20);
                        this.label2.TabIndex = 5;
                        this.label2.Text = "位小数";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // spinEdit1
                        // 
                        this.spinEdit1.Dock = System.Windows.Forms.DockStyle.Left;
                        this.spinEdit1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
                        this.spinEdit1.Location = new System.Drawing.Point(74, 2);
                        this.spinEdit1.Name = "spinEdit1";
                        this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
                        this.spinEdit1.Properties.IsFloatValue = false;
                        this.spinEdit1.Properties.Mask.EditMask = "N00";
                        this.spinEdit1.Properties.MaxValue = new decimal(new int[] {
            6,
            0,
            0,
            0});
                        this.spinEdit1.Size = new System.Drawing.Size(48, 21);
                        this.spinEdit1.TabIndex = 4;
                        this.spinEdit1.EditValueChanged += new System.EventHandler(this.spinEdit1_EditValueChanged);
                        // 
                        // label1
                        // 
                        this.label1.Dock = System.Windows.Forms.DockStyle.Left;
                        this.label1.Location = new System.Drawing.Point(0, 2);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(74, 20);
                        this.label1.TabIndex = 3;
                        this.label1.Text = "显示精度：";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // frmChartShow
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(994, 542);
                        this.Controls.Add(this.panelControl3);
                        this.Name = "frmChartShow";
                        this.Padding = new System.Windows.Forms.Padding(5);
                        this.Text = "图表展示";
                        ((System.ComponentModel.ISupportInitialize)(this.CB_SORTTYPE.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.CB_ITEMCOUNT.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.CB_SORTLIST.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.CB_XLIST.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.CB_CHARTTYPE.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.CB_YLIST)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.panelShow)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
                        this.panelControl3.ResumeLayout(false);
                        this.tableLayoutPanel1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
                        this.panel1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.ComboBoxEdit CB_CHARTTYPE;
                private DevExpress.XtraEditors.LabelControl labelControl1;
                private DevExpress.XtraEditors.ComboBoxEdit CB_SORTLIST;
                private DevExpress.XtraEditors.LabelControl labelControl3;
                private DevExpress.XtraEditors.ComboBoxEdit CB_XLIST;
                private DevExpress.XtraEditors.CheckedListBoxControl CB_YLIST;
                private DevExpress.XtraEditors.ComboBoxEdit CB_ITEMCOUNT;
                private DevExpress.XtraEditors.PanelControl panelShow;
                private DevExpress.XtraEditors.ComboBoxEdit CB_SORTTYPE;
                private DevExpress.XtraEditors.PanelControl panelControl3;
                private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
                private DevExpress.XtraEditors.LabelControl labelControl2;
                private DevExpress.XtraEditors.LabelControl labelControl9;
                private DevExpress.XtraEditors.LabelControl labelControl8;
                private DevExpress.XtraEditors.LabelControl labelControl7;
                private DevExpress.XtraEditors.CheckEdit checkEdit1;
                private System.Windows.Forms.Panel panel1;
                private System.Windows.Forms.Label label2;
                private DevExpress.XtraEditors.SpinEdit spinEdit1;
                private System.Windows.Forms.Label label1;
        }
}