namespace SinoSZClientSysManager.Organize
{
        partial class frmOrganizeExtInfo
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
                        this.treeList1 = new DevExpress.XtraTreeList.TreeList();
                        this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
                        this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
                        this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
                        this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                        this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
                        this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
                        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // treeList1
                        // 
                        this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn4});
                        this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.treeList1.Location = new System.Drawing.Point(10, 10);
                        this.treeList1.Name = "treeList1";
                        this.treeList1.OptionsView.AutoWidth = false;
                        this.treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemSpinEdit1});
                        this.treeList1.Size = new System.Drawing.Size(898, 544);
                        this.treeList1.TabIndex = 0;
                        this.treeList1.BeforeExpand += new DevExpress.XtraTreeList.BeforeExpandEventHandler(this.treeList1_BeforeExpand);
                        // 
                        // treeListColumn1
                        // 
                        this.treeListColumn1.Caption = "机构全称";
                        this.treeListColumn1.FieldName = "ZZJGQC";
                        this.treeListColumn1.Fixed = DevExpress.XtraTreeList.Columns.FixedStyle.Left;
                        this.treeListColumn1.Name = "treeListColumn1";
                        this.treeListColumn1.OptionsColumn.AllowEdit = false;
                        this.treeListColumn1.OptionsColumn.ReadOnly = true;
                        this.treeListColumn1.Visible = true;
                        this.treeListColumn1.VisibleIndex = 0;
                        this.treeListColumn1.Width = 310;
                        // 
                        // treeListColumn2
                        // 
                        this.treeListColumn2.Caption = "显示名称";
                        this.treeListColumn2.FieldName = "JGXSMC";
                        this.treeListColumn2.Name = "treeListColumn2";
                        this.treeListColumn2.Visible = true;
                        this.treeListColumn2.VisibleIndex = 1;
                        this.treeListColumn2.Width = 142;
                        // 
                        // treeListColumn3
                        // 
                        this.treeListColumn3.Caption = "是否显示";
                        this.treeListColumn3.ColumnEdit = this.repositoryItemCheckEdit1;
                        this.treeListColumn3.FieldName = "ISDISPLAY";
                        this.treeListColumn3.Name = "treeListColumn3";
                        this.treeListColumn3.OptionsColumn.FixedWidth = true;
                        this.treeListColumn3.Visible = true;
                        this.treeListColumn3.VisibleIndex = 2;
                        this.treeListColumn3.Width = 80;
                        // 
                        // repositoryItemCheckEdit1
                        // 
                        this.repositoryItemCheckEdit1.AutoHeight = false;
                        this.repositoryItemCheckEdit1.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
                        this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
                        this.repositoryItemCheckEdit1.PictureChecked = global::SinoSZClientSysManager.Properties.Resources.check11;
                        this.repositoryItemCheckEdit1.PictureUnchecked = global::SinoSZClientSysManager.Properties.Resources.check2;
                        // 
                        // treeListColumn4
                        // 
                        this.treeListColumn4.Caption = "显示顺序";
                        this.treeListColumn4.ColumnEdit = this.repositoryItemSpinEdit1;
                        this.treeListColumn4.FieldName = "DISPLAYORDER";
                        this.treeListColumn4.Name = "treeListColumn4";
                        this.treeListColumn4.OptionsColumn.FixedWidth = true;
                        this.treeListColumn4.Visible = true;
                        this.treeListColumn4.VisibleIndex = 3;
                        this.treeListColumn4.Width = 80;
                        // 
                        // repositoryItemSpinEdit1
                        // 
                        this.repositoryItemSpinEdit1.AutoHeight = false;
                        this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
                        this.repositoryItemSpinEdit1.IsFloatValue = false;
                        this.repositoryItemSpinEdit1.Mask.EditMask = "N00";
                        this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
                        // 
                        // frmOrganizeExtInfo
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(918, 564);
                        this.Controls.Add(this.treeList1);
                        this.Name = "frmOrganizeExtInfo";
                        this.Padding = new System.Windows.Forms.Padding(10);
                        this.Text = "frmOrganizeExtInfo";
                        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraTreeList.TreeList treeList1;
                private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
                private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
                private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
                private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
                private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
                private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        }
}