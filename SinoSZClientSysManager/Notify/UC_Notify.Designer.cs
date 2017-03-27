namespace SinoSZClientSysManager.Notify
{
        partial class UC_Notify
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
                        this.gridControl1 = new DevExpress.XtraGrid.GridControl();
                        this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
                        this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
                        this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
                        ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
                        this.groupControl1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // groupControl1
                        // 
                        this.groupControl1.Controls.Add(this.gridControl1);
                        this.groupControl1.LookAndFeel.SkinName = "Blue";
                        this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
                        this.groupControl1.Controls.SetChildIndex(this.gridControl1, 0);
                        // 
                        // gridControl1
                        // 
                        this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.gridControl1.EmbeddedNavigator.Name = "";
                        this.gridControl1.Location = new System.Drawing.Point(2, 21);
                        this.gridControl1.MainView = this.gridView1;
                        this.gridControl1.Name = "gridControl1";
                        this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1});
                        this.gridControl1.Size = new System.Drawing.Size(252, 286);
                        this.gridControl1.TabIndex = 2;
                        this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
                        // 
                        // gridView1
                        // 
                        this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
                        this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
                        this.gridView1.GridControl = this.gridControl1;
                        this.gridView1.Name = "gridView1";
                        this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
                        this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
                        this.gridView1.OptionsView.ShowColumnHeaders = false;
                        this.gridView1.OptionsView.ShowGroupPanel = false;
                        this.gridView1.OptionsView.ShowHorzLines = false;
                        this.gridView1.OptionsView.ShowIndicator = false;
                        this.gridView1.OptionsView.ShowVertLines = false;
                        // 
                        // gridColumn1
                        // 
                        this.gridColumn1.Caption = "gridColumn1";
                        this.gridColumn1.ColumnEdit = this.repositoryItemHyperLinkEdit1;
                        this.gridColumn1.FieldName = "XXBT";
                        this.gridColumn1.Name = "gridColumn1";
                        this.gridColumn1.OptionsColumn.ReadOnly = true;
                        this.gridColumn1.Visible = true;
                        this.gridColumn1.VisibleIndex = 0;
                        this.gridColumn1.Width = 173;
                        // 
                        // repositoryItemHyperLinkEdit1
                        // 
                        this.repositoryItemHyperLinkEdit1.AutoHeight = false;
                        this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
                        this.repositoryItemHyperLinkEdit1.SingleClick = true;
                        this.repositoryItemHyperLinkEdit1.StartKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
                        this.repositoryItemHyperLinkEdit1.Click += new System.EventHandler(this.repositoryItemHyperLinkEdit1_Click);
                        // 
                        // gridColumn2
                        // 
                        this.gridColumn2.Caption = "gridColumn2";
                        this.gridColumn2.DisplayFormat.FormatString = "yyyy-MM-dd";
                        this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        this.gridColumn2.FieldName = "FBSJ";
                        this.gridColumn2.Name = "gridColumn2";
                        this.gridColumn2.OptionsColumn.AllowEdit = false;
                        this.gridColumn2.OptionsColumn.AllowFocus = false;
                        this.gridColumn2.OptionsColumn.FixedWidth = true;
                        this.gridColumn2.OptionsColumn.ReadOnly = true;
                        this.gridColumn2.Visible = true;
                        this.gridColumn2.VisibleIndex = 1;
                        this.gridColumn2.Width = 80;
                        // 
                        // UC_Notify
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.Name = "UC_Notify";
                        ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
                        this.groupControl1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraGrid.GridControl gridControl1;
                private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
                private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        }
}
