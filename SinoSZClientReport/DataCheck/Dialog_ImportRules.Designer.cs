namespace SinoSZClientReport.DataCheck
{
        partial class Dialog_ImportRules
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
                        this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
                        this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
                        this.gridControl1 = new DevExpress.XtraGrid.GridControl();
                        this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
                        this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                        this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.tableLayoutPanel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // tableLayoutPanel1
                        // 
                        this.tableLayoutPanel1.ColumnCount = 3;
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
                        this.tableLayoutPanel1.Controls.Add(this.simpleButton1, 1, 1);
                        this.tableLayoutPanel1.Controls.Add(this.simpleButton2, 2, 1);
                        this.tableLayoutPanel1.Controls.Add(this.gridControl1, 0, 0);
                        this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
                        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
                        this.tableLayoutPanel1.RowCount = 2;
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
                        this.tableLayoutPanel1.Size = new System.Drawing.Size(528, 421);
                        this.tableLayoutPanel1.TabIndex = 0;
                        // 
                        // simpleButton1
                        // 
                        this.simpleButton1.Location = new System.Drawing.Point(411, 396);
                        this.simpleButton1.Name = "simpleButton1";
                        this.simpleButton1.Size = new System.Drawing.Size(54, 22);
                        this.simpleButton1.TabIndex = 0;
                        this.simpleButton1.Text = "确定";
                        this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
                        // 
                        // simpleButton2
                        // 
                        this.simpleButton2.Location = new System.Drawing.Point(471, 396);
                        this.simpleButton2.Name = "simpleButton2";
                        this.simpleButton2.Size = new System.Drawing.Size(54, 22);
                        this.simpleButton2.TabIndex = 1;
                        this.simpleButton2.Text = "取消";
                        this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
                        // 
                        // gridControl1
                        // 
                        this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.tableLayoutPanel1.SetColumnSpan(this.gridControl1, 3);
                        this.gridControl1.EmbeddedNavigator.Name = "";
                        this.gridControl1.Location = new System.Drawing.Point(3, 3);
                        this.gridControl1.MainView = this.gridView1;
                        this.gridControl1.Name = "gridControl1";
                        this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
                        this.gridControl1.Size = new System.Drawing.Size(522, 387);
                        this.gridControl1.TabIndex = 2;
                        this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
                        // 
                        // gridView1
                        // 
                        this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
                        this.gridView1.GridControl = this.gridControl1;
                        this.gridView1.Name = "gridView1";
                        this.gridView1.OptionsView.ShowGroupPanel = false;
                        // 
                        // gridColumn1
                        // 
                        this.gridColumn1.Caption = "选择";
                        this.gridColumn1.ColumnEdit = this.repositoryItemCheckEdit1;
                        this.gridColumn1.FieldName = "STATE";
                        this.gridColumn1.Name = "gridColumn1";
                        this.gridColumn1.OptionsColumn.FixedWidth = true;
                        this.gridColumn1.Visible = true;
                        this.gridColumn1.VisibleIndex = 0;
                        this.gridColumn1.Width = 56;
                        // 
                        // repositoryItemCheckEdit1
                        // 
                        this.repositoryItemCheckEdit1.AutoHeight = false;
                        this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
                        // 
                        // gridColumn2
                        // 
                        this.gridColumn2.Caption = "规则名称";
                        this.gridColumn2.FieldName = "GZMC";
                        this.gridColumn2.Name = "gridColumn2";
                        this.gridColumn2.OptionsColumn.ReadOnly = true;
                        this.gridColumn2.Visible = true;
                        this.gridColumn2.VisibleIndex = 1;
                        this.gridColumn2.Width = 445;
                        // 
                        // Dialog_ImportRules
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(548, 441);
                        this.Controls.Add(this.tableLayoutPanel1);
                        this.Name = "Dialog_ImportRules";
                        this.Padding = new System.Windows.Forms.Padding(10);
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "导入规则";
                        this.tableLayoutPanel1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private DevExpress.XtraEditors.SimpleButton simpleButton2;
                private DevExpress.XtraGrid.GridControl gridControl1;
                private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
                private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        }
}