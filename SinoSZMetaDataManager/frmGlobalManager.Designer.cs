namespace SinoSZMetaDataManager
{
        partial class frmGlobalManager
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
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGlobalManager));
                        this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
                        this.imageListBoxControl1 = new DevExpress.XtraEditors.ImageListBoxControl();
                        this.imageList1 = new System.Windows.Forms.ImageList(this.components);
                        this.sinoCommonGrid1 = new SinoSZClientBase.SinoCommonGrid();
                        this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
                        this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
                        this.imageList2 = new System.Windows.Forms.ImageList(this.components);
                        ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
                        this.splitContainerControl1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.imageListBoxControl1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.sinoCommonGrid1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // splitContainerControl1
                        // 
                        this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
                        this.splitContainerControl1.Name = "splitContainerControl1";
                        this.splitContainerControl1.Panel1.Controls.Add(this.imageListBoxControl1);
                        this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(5);
                        this.splitContainerControl1.Panel1.Text = "Panel1";
                        this.splitContainerControl1.Panel2.Controls.Add(this.sinoCommonGrid1);
                        this.splitContainerControl1.Panel2.Padding = new System.Windows.Forms.Padding(5);
                        this.splitContainerControl1.Panel2.Text = "Panel2";
                        this.splitContainerControl1.Size = new System.Drawing.Size(826, 526);
                        this.splitContainerControl1.SplitterPosition = 310;
                        this.splitContainerControl1.TabIndex = 0;
                        this.splitContainerControl1.Text = "splitContainerControl1";
                        // 
                        // imageListBoxControl1
                        // 
                        this.imageListBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.imageListBoxControl1.ImageList = this.imageList1;
                        this.imageListBoxControl1.ItemHeight = 26;
                        this.imageListBoxControl1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageListBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("海关总署缉私综合应用系统", 0),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("治理走私源头综合系统系统", 0),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("深圳海关线索移交反馈及综合应用系统", 0),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("青岛海关线索移交及综合应用系统", 0)});
                        this.imageListBoxControl1.Location = new System.Drawing.Point(5, 4);
                        this.imageListBoxControl1.Name = "imageListBoxControl1";
                        this.imageListBoxControl1.Size = new System.Drawing.Size(296, 513);
                        this.imageListBoxControl1.TabIndex = 0;
                        this.imageListBoxControl1.SelectedIndexChanged += new System.EventHandler(this.imageListBoxControl1_SelectedIndexChanged);
                        // 
                        // imageList1
                        // 
                        this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
                        this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
                        this.imageList1.Images.SetKeyName(0, "project1.ico");
                        // 
                        // sinoCommonGrid1
                        // 
                        this.sinoCommonGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.sinoCommonGrid1.EmbeddedNavigator.Name = "";
                        this.sinoCommonGrid1.Location = new System.Drawing.Point(5, 4);
                        this.sinoCommonGrid1.MainView = this.gridView1;
                        this.sinoCommonGrid1.Name = "sinoCommonGrid1";
                        this.sinoCommonGrid1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
                        this.sinoCommonGrid1.Size = new System.Drawing.Size(496, 513);
                        this.sinoCommonGrid1.TabIndex = 0;
                        this.sinoCommonGrid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
                        // 
                        // gridView1
                        // 
                        this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(255)))), ((int)(((byte)(229)))));
                        this.gridView1.Appearance.EvenRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(255)))), ((int)(((byte)(229)))));
                        this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
                        this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(205)))));
                        this.gridView1.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(191)))), ((int)(((byte)(18)))));
                        this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
                        this.gridView1.Appearance.FocusedCell.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
                        this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
                        this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
                        this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(205)))));
                        this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(191)))), ((int)(((byte)(18)))));
                        this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
                        this.gridView1.Appearance.FocusedRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
                        this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
                        this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
                        this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn2});
                        this.gridView1.GridControl = this.sinoCommonGrid1;
                        this.gridView1.Name = "gridView1";
                        this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
                        // 
                        // gridColumn1
                        // 
                        this.gridColumn1.Caption = "命名空间";
                        this.gridColumn1.FieldName = "NameSpace";
                        this.gridColumn1.Name = "gridColumn1";
                        this.gridColumn1.OptionsColumn.FixedWidth = true;
                        this.gridColumn1.OptionsColumn.ReadOnly = true;
                        this.gridColumn1.Visible = true;
                        this.gridColumn1.VisibleIndex = 0;
                        this.gridColumn1.Width = 150;
                        // 
                        // gridColumn3
                        // 
                        this.gridColumn3.Caption = "说明";
                        this.gridColumn3.FieldName = "Description";
                        this.gridColumn3.Name = "gridColumn3";
                        this.gridColumn3.OptionsColumn.ReadOnly = true;
                        this.gridColumn3.Visible = true;
                        this.gridColumn3.VisibleIndex = 1;
                        this.gridColumn3.Width = 250;
                        // 
                        // gridColumn2
                        // 
                        this.gridColumn2.Caption = "状态";
                        this.gridColumn2.ColumnEdit = this.repositoryItemImageComboBox1;
                        this.gridColumn2.FieldName = "State";
                        this.gridColumn2.Name = "gridColumn2";
                        this.gridColumn2.OptionsColumn.FixedWidth = true;
                        this.gridColumn2.Visible = true;
                        this.gridColumn2.VisibleIndex = 2;
                        // 
                        // repositoryItemImageComboBox1
                        // 
                        this.repositoryItemImageComboBox1.AutoHeight = false;
                        this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("开放", "开放", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("保密", "保密", 1)});
                        this.repositoryItemImageComboBox1.LargeImages = this.imageList2;
                        this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
                        this.repositoryItemImageComboBox1.SmallImages = this.imageList2;
                        // 
                        // imageList2
                        // 
                        this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
                        this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
                        this.imageList2.Images.SetKeyName(0, "remotecontrol3.ico");
                        this.imageList2.Images.SetKeyName(1, "padlocke.ico");
                        // 
                        // frmGlobalManager
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(826, 526);
                        this.Controls.Add(this.splitContainerControl1);
                        this.Name = "frmGlobalManager";
                        this.Text = "全局定义";
                        ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
                        this.splitContainerControl1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.imageListBoxControl1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.sinoCommonGrid1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
                private DevExpress.XtraEditors.ImageListBoxControl imageListBoxControl1;
                private System.Windows.Forms.ImageList imageList1;
                private SinoSZClientBase.SinoCommonGrid sinoCommonGrid1;
                private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
                private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
                private System.Windows.Forms.ImageList imageList2;
        }
}