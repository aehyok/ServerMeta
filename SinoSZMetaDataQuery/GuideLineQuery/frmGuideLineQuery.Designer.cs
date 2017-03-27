namespace SinoSZMetaDataQuery.GuideLineQuery
{
        partial class frmGuideLineQuery
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
                        this.treeList1 = new DevExpress.XtraTreeList.TreeList();
                        this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
                        this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
                        ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
                        this.splitContainerControl1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // splitContainerControl1
                        // 
                        this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.splitContainerControl1.Location = new System.Drawing.Point(12, 12);
                        this.splitContainerControl1.Name = "splitContainerControl1";
                        this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                        this.splitContainerControl1.Panel1.Controls.Add(this.treeList1);
                        this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
                        this.splitContainerControl1.Panel1.Text = "Panel1";
                        this.splitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                        this.splitContainerControl1.Panel2.Text = "Panel2";
                        this.splitContainerControl1.Size = new System.Drawing.Size(1040, 558);
                        this.splitContainerControl1.SplitterPosition = 389;
                        this.splitContainerControl1.TabIndex = 0;
                        this.splitContainerControl1.Text = "splitContainerControl1";
                        // 
                        // treeList1
                        // 
                        this.treeList1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
                        this.treeList1.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
                        this.treeList1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
                        this.treeList1.Appearance.FocusedCell.Options.UseBackColor = true;
                        this.treeList1.Appearance.FocusedCell.Options.UseForeColor = true;
                        this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn3});
                        this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.treeList1.Location = new System.Drawing.Point(7, 4);
                        this.treeList1.Name = "treeList1";
                        this.treeList1.Size = new System.Drawing.Size(375, 549);
                        this.treeList1.TabIndex = 2;
                        this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
                        this.treeList1.BeforeExpand += new DevExpress.XtraTreeList.BeforeExpandEventHandler(this.treeList1_BeforeExpand);
                        // 
                        // treeListColumn1
                        // 
                        this.treeListColumn1.AppearanceHeader.Image = global::SinoSZMetaDataQuery.Properties.Resources.x3;
                        this.treeListColumn1.AppearanceHeader.Options.UseImage = true;
                        this.treeListColumn1.Caption = "指标列表";
                        this.treeListColumn1.FieldName = "COLUMN1";
                        this.treeListColumn1.MinWidth = 43;
                        this.treeListColumn1.Name = "treeListColumn1";
                        this.treeListColumn1.OptionsColumn.AllowEdit = false;
                        this.treeListColumn1.OptionsColumn.ReadOnly = true;
                        this.treeListColumn1.Visible = true;
                        this.treeListColumn1.VisibleIndex = 0;
                        // 
                        // treeListColumn3
                        // 
                        this.treeListColumn3.Caption = "treeListColumn3";
                        this.treeListColumn3.FieldName = "State";
                        this.treeListColumn3.Name = "treeListColumn3";
                        this.treeListColumn3.OptionsColumn.FixedWidth = true;
                        this.treeListColumn3.OptionsColumn.ReadOnly = true;
                        // 
                        // frmGuideLineQuery
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(1064, 582);
                        this.Controls.Add(this.splitContainerControl1);
                        this.Name = "frmGuideLineQuery";
                        this.Padding = new System.Windows.Forms.Padding(12);
                        this.Text = "指标查询";
                        this.Load += new System.EventHandler(this.frmGuideLineQuery_Load);
                        ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
                        this.splitContainerControl1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
                private DevExpress.XtraTreeList.TreeList treeList1;
                private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
                private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        }
}