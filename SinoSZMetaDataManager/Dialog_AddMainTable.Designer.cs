namespace SinoSZMetaDataManager
{
        partial class Dialog_AddMainTable
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
                        this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
                        this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
                        this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
                        this.gridControl1 = new DevExpress.XtraGrid.GridControl();
                        this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
                        this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
                        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
                        this.panelControl1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // panelControl1
                        // 
                        this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                        this.panelControl1.Controls.Add(this.simpleButton2);
                        this.panelControl1.Controls.Add(this.simpleButton1);
                        this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.panelControl1.Location = new System.Drawing.Point(8, 397);
                        this.panelControl1.Name = "panelControl1";
                        this.panelControl1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
                        this.panelControl1.Size = new System.Drawing.Size(698, 45);
                        this.panelControl1.TabIndex = 2;
                        // 
                        // simpleButton2
                        // 
                        this.simpleButton2.Dock = System.Windows.Forms.DockStyle.Right;
                        this.simpleButton2.Location = new System.Drawing.Point(548, 10);
                        this.simpleButton2.Name = "simpleButton2";
                        this.simpleButton2.Size = new System.Drawing.Size(75, 25);
                        this.simpleButton2.TabIndex = 1;
                        this.simpleButton2.Text = "确定";
                        this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
                        // 
                        // simpleButton1
                        // 
                        this.simpleButton1.Dock = System.Windows.Forms.DockStyle.Right;
                        this.simpleButton1.Location = new System.Drawing.Point(623, 10);
                        this.simpleButton1.Name = "simpleButton1";
                        this.simpleButton1.Size = new System.Drawing.Size(75, 25);
                        this.simpleButton1.TabIndex = 0;
                        this.simpleButton1.Text = "取消";
                        this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
                        // 
                        // gridControl1
                        // 
                        this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.gridControl1.EmbeddedNavigator.Name = "";
                        this.gridControl1.Location = new System.Drawing.Point(8, 8);
                        this.gridControl1.MainView = this.gridView1;
                        this.gridControl1.Name = "gridControl1";
                        this.gridControl1.Size = new System.Drawing.Size(698, 389);
                        this.gridControl1.TabIndex = 3;
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
                        // 
                        // gridColumn1
                        // 
                        this.gridColumn1.Caption = "表名";
                        this.gridColumn1.FieldName = "TableName";
                        this.gridColumn1.Name = "gridColumn1";
                        this.gridColumn1.OptionsColumn.AllowSize = false;
                        this.gridColumn1.Visible = true;
                        this.gridColumn1.VisibleIndex = 0;
                        this.gridColumn1.Width = 199;
                        // 
                        // gridColumn2
                        // 
                        this.gridColumn2.Caption = "显示名称";
                        this.gridColumn2.FieldName = "DisplayTitle";
                        this.gridColumn2.Name = "gridColumn2";
                        this.gridColumn2.Visible = true;
                        this.gridColumn2.VisibleIndex = 1;
                        this.gridColumn2.Width = 478;
                        // 
                        // Dialog_AddMainTable
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(714, 450);
                        this.Controls.Add(this.gridControl1);
                        this.Controls.Add(this.panelControl1);
                        this.Name = "Dialog_AddMainTable";
                        this.Padding = new System.Windows.Forms.Padding(8);
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "添加主表";
                        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
                        this.panelControl1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.PanelControl panelControl1;
                private DevExpress.XtraEditors.SimpleButton simpleButton2;
                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private DevExpress.XtraGrid.GridControl gridControl1;
                private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;

        }
}