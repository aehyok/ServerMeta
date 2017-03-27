namespace SinoSZMetaDataQuery.Common
{
        partial class Dialog_AddFunction
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
                        this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
                        this.groupBox1 = new System.Windows.Forms.GroupBox();
                        this.gridControl1 = new DevExpress.XtraGrid.GridControl();
                        this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
                        this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
                        this.label1 = new System.Windows.Forms.Label();
                        this.label2 = new System.Windows.Forms.Label();
                        this.label3 = new System.Windows.Forms.Label();
                        this.te_Name = new DevExpress.XtraEditors.TextEdit();
                        this.te_Result = new DevExpress.XtraEditors.TextEdit();
                        this.te_Des = new DevExpress.XtraEditors.MemoEdit();
                        this.groupBox2 = new System.Windows.Forms.GroupBox();
                        this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
                        this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
                        this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
                        this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
                        ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
                        this.splitContainerControl1.SuspendLayout();
                        this.groupBox1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
                        this.tableLayoutPanel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.te_Name.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_Result.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_Des.Properties)).BeginInit();
                        this.groupBox2.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
                        this.panelControl1.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // splitContainerControl1
                        // 
                        this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
                        this.splitContainerControl1.Name = "splitContainerControl1";
                        this.splitContainerControl1.Panel1.Controls.Add(this.groupBox1);
                        this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(5);
                        this.splitContainerControl1.Panel1.Text = "Panel1";
                        this.splitContainerControl1.Panel2.Controls.Add(this.tableLayoutPanel1);
                        this.splitContainerControl1.Panel2.Padding = new System.Windows.Forms.Padding(5, 15, 5, 5);
                        this.splitContainerControl1.Panel2.Text = "Panel2";
                        this.splitContainerControl1.Size = new System.Drawing.Size(844, 468);
                        this.splitContainerControl1.SplitterPosition = 456;
                        this.splitContainerControl1.TabIndex = 0;
                        this.splitContainerControl1.Text = "splitContainerControl1";
                        // 
                        // groupBox1
                        // 
                        this.groupBox1.Controls.Add(this.gridControl1);
                        this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.groupBox1.Location = new System.Drawing.Point(5, 4);
                        this.groupBox1.Name = "groupBox1";
                        this.groupBox1.Size = new System.Drawing.Size(442, 455);
                        this.groupBox1.TabIndex = 0;
                        this.groupBox1.TabStop = false;
                        this.groupBox1.Text = " 函数列表";
                        // 
                        // gridControl1
                        // 
                        this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.gridControl1.EmbeddedNavigator.Name = "";
                        this.gridControl1.Location = new System.Drawing.Point(3, 18);
                        this.gridControl1.MainView = this.gridView1;
                        this.gridControl1.Name = "gridControl1";
                        this.gridControl1.Size = new System.Drawing.Size(436, 434);
                        this.gridControl1.TabIndex = 0;
                        this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
                        // 
                        // gridView1
                        // 
                        this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
                        this.gridView1.GridControl = this.gridControl1;
                        this.gridView1.Name = "gridView1";
                        this.gridView1.OptionsView.ShowDetailButtons = false;
                        this.gridView1.OptionsView.ShowGroupPanel = false;
                        this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
                        // 
                        // gridColumn1
                        // 
                        this.gridColumn1.Caption = "函数";
                        this.gridColumn1.FieldName = "Name";
                        this.gridColumn1.Name = "gridColumn1";
                        this.gridColumn1.OptionsColumn.FixedWidth = true;
                        this.gridColumn1.OptionsColumn.ReadOnly = true;
                        this.gridColumn1.Visible = true;
                        this.gridColumn1.VisibleIndex = 0;
                        this.gridColumn1.Width = 120;
                        // 
                        // gridColumn2
                        // 
                        this.gridColumn2.Caption = "函数名称";
                        this.gridColumn2.FieldName = "DisplayTitle";
                        this.gridColumn2.Name = "gridColumn2";
                        this.gridColumn2.OptionsColumn.ReadOnly = true;
                        this.gridColumn2.Visible = true;
                        this.gridColumn2.VisibleIndex = 1;
                        this.gridColumn2.Width = 220;
                        // 
                        // gridColumn3
                        // 
                        this.gridColumn3.Caption = "返回类型";
                        this.gridColumn3.FieldName = "ResultType";
                        this.gridColumn3.Name = "gridColumn3";
                        this.gridColumn3.OptionsColumn.FixedWidth = true;
                        this.gridColumn3.OptionsColumn.ReadOnly = true;
                        this.gridColumn3.Visible = true;
                        this.gridColumn3.VisibleIndex = 2;
                        this.gridColumn3.Width = 85;
                        // 
                        // tableLayoutPanel1
                        // 
                        this.tableLayoutPanel1.ColumnCount = 4;
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
                        this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
                        this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
                        this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
                        this.tableLayoutPanel1.Controls.Add(this.te_Name, 1, 0);
                        this.tableLayoutPanel1.Controls.Add(this.te_Result, 1, 4);
                        this.tableLayoutPanel1.Controls.Add(this.te_Des, 1, 1);
                        this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 5);
                        this.tableLayoutPanel1.Controls.Add(this.simpleButton1, 2, 6);
                        this.tableLayoutPanel1.Controls.Add(this.simpleButton2, 3, 6);
                        this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 14);
                        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
                        this.tableLayoutPanel1.RowCount = 7;
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
                        this.tableLayoutPanel1.Size = new System.Drawing.Size(368, 445);
                        this.tableLayoutPanel1.TabIndex = 0;
                        // 
                        // label1
                        // 
                        this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.label1.AutoSize = true;
                        this.label1.Location = new System.Drawing.Point(3, 6);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(74, 14);
                        this.label1.TabIndex = 0;
                        this.label1.Text = "函数名称";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // label2
                        // 
                        this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.label2.AutoSize = true;
                        this.label2.Location = new System.Drawing.Point(3, 32);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(74, 14);
                        this.label2.TabIndex = 1;
                        this.label2.Text = "函数说明";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // label3
                        // 
                        this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.label3.AutoSize = true;
                        this.label3.Location = new System.Drawing.Point(3, 110);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(74, 14);
                        this.label3.TabIndex = 2;
                        this.label3.Text = "返回值类型";
                        this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // te_Name
                        // 
                        this.te_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.tableLayoutPanel1.SetColumnSpan(this.te_Name, 3);
                        this.te_Name.Location = new System.Drawing.Point(83, 3);
                        this.te_Name.Name = "te_Name";
                        this.te_Name.Properties.Appearance.BackColor = System.Drawing.Color.White;
                        this.te_Name.Properties.Appearance.Options.UseBackColor = true;
                        this.te_Name.Properties.ReadOnly = true;
                        this.te_Name.Size = new System.Drawing.Size(282, 21);
                        this.te_Name.TabIndex = 3;
                        // 
                        // te_Result
                        // 
                        this.te_Result.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.tableLayoutPanel1.SetColumnSpan(this.te_Result, 3);
                        this.te_Result.Location = new System.Drawing.Point(83, 107);
                        this.te_Result.Name = "te_Result";
                        this.te_Result.Properties.Appearance.BackColor = System.Drawing.Color.White;
                        this.te_Result.Properties.Appearance.Options.UseBackColor = true;
                        this.te_Result.Properties.ReadOnly = true;
                        this.te_Result.Size = new System.Drawing.Size(282, 21);
                        this.te_Result.TabIndex = 4;
                        // 
                        // te_Des
                        // 
                        this.te_Des.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.tableLayoutPanel1.SetColumnSpan(this.te_Des, 3);
                        this.te_Des.Location = new System.Drawing.Point(83, 29);
                        this.te_Des.Name = "te_Des";
                        this.te_Des.Properties.AcceptsReturn = false;
                        this.te_Des.Properties.Appearance.BackColor = System.Drawing.Color.White;
                        this.te_Des.Properties.Appearance.Options.UseBackColor = true;
                        this.te_Des.Properties.ReadOnly = true;
                        this.tableLayoutPanel1.SetRowSpan(this.te_Des, 3);
                        this.te_Des.Size = new System.Drawing.Size(282, 72);
                        this.te_Des.TabIndex = 5;
                        // 
                        // groupBox2
                        // 
                        this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.tableLayoutPanel1.SetColumnSpan(this.groupBox2, 4);
                        this.groupBox2.Controls.Add(this.panelControl1);
                        this.groupBox2.Location = new System.Drawing.Point(3, 138);
                        this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
                        this.groupBox2.Name = "groupBox2";
                        this.groupBox2.Padding = new System.Windows.Forms.Padding(8);
                        this.groupBox2.Size = new System.Drawing.Size(362, 274);
                        this.groupBox2.TabIndex = 6;
                        this.groupBox2.TabStop = false;
                        this.groupBox2.Text = "调用参数值";
                        // 
                        // panelControl1
                        // 
                        this.panelControl1.Controls.Add(this.xtraScrollableControl1);
                        this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.panelControl1.Location = new System.Drawing.Point(8, 23);
                        this.panelControl1.Name = "panelControl1";
                        this.panelControl1.Size = new System.Drawing.Size(346, 243);
                        this.panelControl1.TabIndex = 0;
                        // 
                        // xtraScrollableControl1
                        // 
                        this.xtraScrollableControl1.Appearance.BackColor = System.Drawing.Color.White;
                        this.xtraScrollableControl1.Appearance.Options.UseBackColor = true;
                        this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.xtraScrollableControl1.Location = new System.Drawing.Point(2, 2);
                        this.xtraScrollableControl1.Name = "xtraScrollableControl1";
                        this.xtraScrollableControl1.Size = new System.Drawing.Size(342, 239);
                        this.xtraScrollableControl1.TabIndex = 0;
                        // 
                        // simpleButton1
                        // 
                        this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.simpleButton1.Location = new System.Drawing.Point(251, 418);
                        this.simpleButton1.Name = "simpleButton1";
                        this.simpleButton1.Size = new System.Drawing.Size(54, 24);
                        this.simpleButton1.TabIndex = 7;
                        this.simpleButton1.Text = "确定";
                        this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
                        // 
                        // simpleButton2
                        // 
                        this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.simpleButton2.Location = new System.Drawing.Point(311, 418);
                        this.simpleButton2.Name = "simpleButton2";
                        this.simpleButton2.Size = new System.Drawing.Size(54, 24);
                        this.simpleButton2.TabIndex = 8;
                        this.simpleButton2.Text = "取消";
                        this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
                        // 
                        // Dialog_AddFunction
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(844, 468);
                        this.Controls.Add(this.splitContainerControl1);
                        this.Name = "Dialog_AddFunction";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "添加函数";
                        ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
                        this.splitContainerControl1.ResumeLayout(false);
                        this.groupBox1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
                        this.tableLayoutPanel1.ResumeLayout(false);
                        this.tableLayoutPanel1.PerformLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.te_Name.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_Result.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_Des.Properties)).EndInit();
                        this.groupBox2.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
                        this.panelControl1.ResumeLayout(false);
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
                private System.Windows.Forms.GroupBox groupBox1;
                private DevExpress.XtraGrid.GridControl gridControl1;
                private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
                private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
                private System.Windows.Forms.Label label1;
                private System.Windows.Forms.Label label2;
                private System.Windows.Forms.Label label3;
                private DevExpress.XtraEditors.TextEdit te_Name;
                private DevExpress.XtraEditors.TextEdit te_Result;
                private DevExpress.XtraEditors.MemoEdit te_Des;
                private System.Windows.Forms.GroupBox groupBox2;
                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private DevExpress.XtraEditors.SimpleButton simpleButton2;
                private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
                private DevExpress.XtraEditors.PanelControl panelControl1;
        }
}