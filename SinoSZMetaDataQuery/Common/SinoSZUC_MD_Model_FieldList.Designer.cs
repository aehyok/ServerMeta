namespace SinoSZMetaDataQuery.Common
{
        partial class SinoSZUC_MD_Model_FieldList
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
                        DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition();
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SinoSZUC_MD_Model_FieldList));
                        this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
                        this.treeList1 = new DevExpress.XtraTreeList.TreeList();
                        this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
                        this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                        this.objectImageList = new System.Windows.Forms.ImageList(this.components);
                        this.stateImageList = new System.Windows.Forms.ImageList(this.components);
                        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // treeListColumn1
                        // 
                        this.treeListColumn1.Caption = "treeListColumn1";
                        this.treeListColumn1.FieldName = "CanShowAsCondition";
                        this.treeListColumn1.Name = "treeListColumn1";
                        // 
                        // treeList1
                        // 
                        this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn2,
            this.treeListColumn1});
                        this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
                        styleFormatCondition1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic);
                        styleFormatCondition1.Appearance.Options.UseFont = true;
                        styleFormatCondition1.ApplyToRow = true;
                        styleFormatCondition1.Column = this.treeListColumn1;
                        styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
                        styleFormatCondition1.Value1 = false;
                        this.treeList1.FormatConditions.AddRange(new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition[] {
            styleFormatCondition1});
                        this.treeList1.Location = new System.Drawing.Point(0, 0);
                        this.treeList1.Name = "treeList1";
                        this.treeList1.OptionsBehavior.AllowExpandOnDblClick = false;
                        this.treeList1.OptionsBehavior.AutoChangeParent = false;
                        this.treeList1.OptionsBehavior.DragNodes = true;
                        this.treeList1.OptionsSelection.EnableAppearanceFocusedCell = false;
                        this.treeList1.OptionsView.ShowHorzLines = false;
                        this.treeList1.OptionsView.ShowVertLines = false;
                        this.treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
                        this.treeList1.SelectImageList = this.objectImageList;
                        this.treeList1.Size = new System.Drawing.Size(292, 504);
                        this.treeList1.StateImageList = this.stateImageList;
                        this.treeList1.TabIndex = 0;
                        this.treeList1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseDoubleClick);
                        this.treeList1.StateImageClick += new DevExpress.XtraTreeList.NodeClickEventHandler(this.treeList1_StateImageClick);
                        this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
                        this.treeList1.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.treeList1_GetStateImage);
                        this.treeList1.GetSelectImage += new DevExpress.XtraTreeList.GetSelectImageEventHandler(this.treeList1_GetSelectImage);
                        this.treeList1.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeList1_DragEnter);
                        // 
                        // treeListColumn2
                        // 
                        this.treeListColumn2.Caption = "字段列表";
                        this.treeListColumn2.FieldName = "DisplayTitle";
                        this.treeListColumn2.MinWidth = 43;
                        this.treeListColumn2.Name = "treeListColumn2";
                        this.treeListColumn2.OptionsColumn.AllowEdit = false;
                        this.treeListColumn2.OptionsColumn.AllowSort = false;
                        this.treeListColumn2.OptionsColumn.ReadOnly = true;
                        this.treeListColumn2.Visible = true;
                        this.treeListColumn2.VisibleIndex = 0;
                        this.treeListColumn2.Width = 218;
                        // 
                        // repositoryItemCheckEdit1
                        // 
                        this.repositoryItemCheckEdit1.AutoHeight = false;
                        this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
                        // 
                        // objectImageList
                        // 
                        this.objectImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("objectImageList.ImageStream")));
                        this.objectImageList.TransparentColor = System.Drawing.Color.Transparent;
                        this.objectImageList.Images.SetKeyName(0, "mainPack2.ico");
                        this.objectImageList.Images.SetKeyName(1, "childPack.ico");
                        this.objectImageList.Images.SetKeyName(2, "title.ico");
                        this.objectImageList.Images.SetKeyName(3, "07582.ico");
                        this.objectImageList.Images.SetKeyName(4, "07684.ico");
                        // 
                        // stateImageList
                        // 
                        this.stateImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("stateImageList.ImageStream")));
                        this.stateImageList.TransparentColor = System.Drawing.Color.Magenta;
                        this.stateImageList.Images.SetKeyName(0, "check2.ico");
                        this.stateImageList.Images.SetKeyName(1, "check00.ico");
                        this.stateImageList.Images.SetKeyName(2, "check11.ico");
                        this.stateImageList.Images.SetKeyName(3, "check33.ico");
                        // 
                        // SinoSZUC_MD_Model_FieldList
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.treeList1);
                        this.Name = "SinoSZUC_MD_Model_FieldList";
                        this.Size = new System.Drawing.Size(292, 504);
                        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraTreeList.TreeList treeList1;
                private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
                private System.Windows.Forms.ImageList stateImageList;
                private System.Windows.Forms.ImageList objectImageList;
                private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
                private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        }
}
