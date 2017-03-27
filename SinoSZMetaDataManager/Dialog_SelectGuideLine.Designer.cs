namespace SinoSZMetaDataManager
{
        partial class Dialog_SelectGuideLine
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
                        this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
                        this.treeList1 = new DevExpress.XtraTreeList.TreeList();
                        this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
                        this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
                        this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
                        this.tableLayoutPanel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // tableLayoutPanel1
                        // 
                        this.tableLayoutPanel1.ColumnCount = 4;
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
                        this.tableLayoutPanel1.Controls.Add(this.treeList1, 0, 0);
                        this.tableLayoutPanel1.Controls.Add(this.simpleButton1, 2, 2);
                        this.tableLayoutPanel1.Controls.Add(this.simpleButton2, 3, 2);
                        this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
                        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
                        this.tableLayoutPanel1.RowCount = 3;
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
                        this.tableLayoutPanel1.Size = new System.Drawing.Size(535, 495);
                        this.tableLayoutPanel1.TabIndex = 0;
                        // 
                        // treeList1
                        // 
                        this.treeList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.treeList1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                        this.treeList1.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
                        this.treeList1.Appearance.FocusedCell.BorderColor = System.Drawing.Color.Blue;
                        this.treeList1.Appearance.FocusedCell.Options.UseBackColor = true;
                        this.treeList1.Appearance.FocusedCell.Options.UseBorderColor = true;
                        this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
                        this.tableLayoutPanel1.SetColumnSpan(this.treeList1, 4);
                        this.treeList1.Location = new System.Drawing.Point(3, 3);
                        this.treeList1.Name = "treeList1";
                        this.treeList1.OptionsBehavior.Editable = false;
                        this.treeList1.OptionsView.ShowColumns = false;
                        this.treeList1.OptionsView.ShowHorzLines = false;
                        this.treeList1.OptionsView.ShowVertLines = false;
                        this.tableLayoutPanel1.SetRowSpan(this.treeList1, 2);
                        this.treeList1.Size = new System.Drawing.Size(529, 452);
                        this.treeList1.TabIndex = 11;
                        this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
                        this.treeList1.BeforeExpand += new DevExpress.XtraTreeList.BeforeExpandEventHandler(this.treeList1_BeforeExpand);
                        // 
                        // treeListColumn1
                        // 
                        this.treeListColumn1.Caption = "treeListColumn1";
                        this.treeListColumn1.FieldName = "DisplayTitle";
                        this.treeListColumn1.MinWidth = 95;
                        this.treeListColumn1.Name = "treeListColumn1";
                        this.treeListColumn1.Visible = true;
                        this.treeListColumn1.VisibleIndex = 0;
                        this.treeListColumn1.Width = 79;
                        // 
                        // simpleButton1
                        // 
                        this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.simpleButton1.Location = new System.Drawing.Point(417, 465);
                        this.simpleButton1.Name = "simpleButton1";
                        this.simpleButton1.Size = new System.Drawing.Size(54, 23);
                        this.simpleButton1.TabIndex = 9;
                        this.simpleButton1.Text = "确定";
                        this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
                        // 
                        // simpleButton2
                        // 
                        this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.simpleButton2.Location = new System.Drawing.Point(477, 465);
                        this.simpleButton2.Name = "simpleButton2";
                        this.simpleButton2.Size = new System.Drawing.Size(55, 23);
                        this.simpleButton2.TabIndex = 10;
                        this.simpleButton2.Text = "取消";
                        this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
                        // 
                        // Dialog_SelectGuideLine
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(555, 515);
                        this.Controls.Add(this.tableLayoutPanel1);
                        this.Name = "Dialog_SelectGuideLine";
                        this.Padding = new System.Windows.Forms.Padding(10);
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "选择指标";
                        this.tableLayoutPanel1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private DevExpress.XtraEditors.SimpleButton simpleButton2;
                private DevExpress.XtraTreeList.TreeList treeList1;
                private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        }
}