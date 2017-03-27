namespace SinoSZClientBase.ShowChart
{
        partial class frmFilterRecord
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
                        this.panel1 = new System.Windows.Forms.Panel();
                        this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
                        this.panel2 = new System.Windows.Forms.Panel();
                        this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
                        this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
                        this.sinoCommonGrid1 = new SinoSZClientBase.SinoCommonGrid();
                        this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
                        this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                        this.panel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
                        this.panel2.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.sinoCommonGrid1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // panel1
                        // 
                        this.panel1.Controls.Add(this.checkEdit1);
                        this.panel1.Controls.Add(this.panel2);
                        this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.panel1.Location = new System.Drawing.Point(5, 433);
                        this.panel1.Name = "panel1";
                        this.panel1.Size = new System.Drawing.Size(603, 38);
                        this.panel1.TabIndex = 2;
                        // 
                        // checkEdit1
                        // 
                        this.checkEdit1.Location = new System.Drawing.Point(4, 10);
                        this.checkEdit1.Name = "checkEdit1";
                        this.checkEdit1.Properties.Caption = " 全选";
                        this.checkEdit1.Size = new System.Drawing.Size(75, 19);
                        this.checkEdit1.TabIndex = 3;
                        this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
                        // 
                        // panel2
                        // 
                        this.panel2.Controls.Add(this.simpleButton2);
                        this.panel2.Controls.Add(this.simpleButton1);
                        this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
                        this.panel2.Location = new System.Drawing.Point(475, 0);
                        this.panel2.Name = "panel2";
                        this.panel2.Size = new System.Drawing.Size(128, 38);
                        this.panel2.TabIndex = 2;
                        // 
                        // simpleButton2
                        // 
                        this.simpleButton2.Location = new System.Drawing.Point(67, 10);
                        this.simpleButton2.Name = "simpleButton2";
                        this.simpleButton2.Size = new System.Drawing.Size(55, 23);
                        this.simpleButton2.TabIndex = 1;
                        this.simpleButton2.Text = "取消";
                        this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
                        // 
                        // simpleButton1
                        // 
                        this.simpleButton1.Location = new System.Drawing.Point(7, 10);
                        this.simpleButton1.Name = "simpleButton1";
                        this.simpleButton1.Size = new System.Drawing.Size(55, 23);
                        this.simpleButton1.TabIndex = 0;
                        this.simpleButton1.Text = "确定";
                        this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
                        // 
                        // sinoCommonGrid1
                        // 
                        this.sinoCommonGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.sinoCommonGrid1.EmbeddedNavigator.Name = "";
                        this.sinoCommonGrid1.Location = new System.Drawing.Point(5, 5);
                        this.sinoCommonGrid1.MainView = this.gridView1;
                        this.sinoCommonGrid1.Name = "sinoCommonGrid1";
                        this.sinoCommonGrid1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
                        this.sinoCommonGrid1.Size = new System.Drawing.Size(603, 428);
                        this.sinoCommonGrid1.TabIndex = 3;
                        this.sinoCommonGrid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
                        // 
                        // gridView1
                        // 
                        this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(255)))), ((int)(((byte)(229)))));
                        this.gridView1.Appearance.EvenRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(255)))), ((int)(((byte)(229)))));
                        this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
                        this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
                        this.gridView1.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
                        this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
                        this.gridView1.Appearance.FocusedCell.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
                        this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
                        this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
                        this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
                        this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
                        this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
                        this.gridView1.Appearance.FocusedRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
                        this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
                        this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
                        this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
                        this.gridView1.GridControl = this.sinoCommonGrid1;
                        this.gridView1.Name = "gridView1";
                        this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
                        this.gridView1.OptionsView.ShowGroupPanel = false;
                        // 
                        // gridColumn1
                        // 
                        this.gridColumn1.Caption = "选择";
                        this.gridColumn1.ColumnEdit = this.repositoryItemCheckEdit1;
                        this.gridColumn1.FieldName = "IsDataSelected";
                        this.gridColumn1.Name = "gridColumn1";
                        this.gridColumn1.OptionsColumn.FixedWidth = true;
                        this.gridColumn1.Visible = true;
                        this.gridColumn1.VisibleIndex = 0;
                        this.gridColumn1.Width = 60;
                        // 
                        // repositoryItemCheckEdit1
                        // 
                        this.repositoryItemCheckEdit1.AutoHeight = false;
                        this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
                        // 
                        // frmFilterRecord
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(613, 476);
                        this.Controls.Add(this.sinoCommonGrid1);
                        this.Controls.Add(this.panel1);
                        this.Name = "frmFilterRecord";
                        this.Padding = new System.Windows.Forms.Padding(5);
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "图表展示数据筛选";
                        this.panel1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
                        this.panel2.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.sinoCommonGrid1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.Panel panel1;
                private System.Windows.Forms.Panel panel2;
                private DevExpress.XtraEditors.SimpleButton simpleButton2;
                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private SinoCommonGrid sinoCommonGrid1;
                private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
                private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
                private DevExpress.XtraEditors.CheckEdit checkEdit1;

        }
}