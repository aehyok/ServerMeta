﻿namespace SinoSZClientSysManager.SystemLog
{
        partial class frmSystemLog
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
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
			this.sinoCommonGrid1 = new SinoSZClientBase.SinoCommonGrid();
			this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
			this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.imageComboBoxEdit1 = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sinoCommonGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "记录时间";
			this.gridColumn2.DisplayFormat.FormatString = "yyyy年MM月dd日 HH:mm:ss";
			this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.gridColumn2.FieldName = "CZSJ";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.OptionsColumn.AllowEdit = false;
			this.gridColumn2.OptionsColumn.FixedWidth = true;
			this.gridColumn2.OptionsColumn.ReadOnly = true;
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 0;
			this.gridColumn2.Width = 183;
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
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
			this.gridView1.GridControl = this.sinoCommonGrid1;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsBehavior.KeepFocusedRowOnUpdate = false;
			this.gridView1.OptionsView.ColumnAutoWidth = false;
			this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
			this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "日志类型";
			this.gridColumn3.FieldName = "LogType";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.OptionsColumn.FixedWidth = true;
			this.gridColumn3.OptionsColumn.ReadOnly = true;
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 1;
			this.gridColumn3.Width = 90;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "内容";
			this.gridColumn4.ColumnEdit = this.repositoryItemMemoExEdit1;
			this.gridColumn4.FieldName = "LogText";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.OptionsColumn.ReadOnly = true;
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 2;
			this.gridColumn4.Width = 593;
			// 
			// repositoryItemMemoExEdit1
			// 
			this.repositoryItemMemoExEdit1.AppearanceDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.repositoryItemMemoExEdit1.AppearanceDropDown.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.repositoryItemMemoExEdit1.AppearanceDropDown.Options.UseBackColor = true;
			this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
			this.repositoryItemMemoExEdit1.PopupFormMinSize = new System.Drawing.Size(200, 150);
			this.repositoryItemMemoExEdit1.PopupStartSize = new System.Drawing.Size(600, 250);
			this.repositoryItemMemoExEdit1.ShowIcon = false;
			// 
			// sinoCommonGrid1
			// 
			this.sinoCommonGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sinoCommonGrid1.EmbeddedNavigator.Name = "";
			this.sinoCommonGrid1.Location = new System.Drawing.Point(10, 46);
			this.sinoCommonGrid1.MainView = this.gridView1;
			this.sinoCommonGrid1.Name = "sinoCommonGrid1";
			this.sinoCommonGrid1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemMemoExEdit1});
			this.sinoCommonGrid1.Size = new System.Drawing.Size(887, 445);
			this.sinoCommonGrid1.TabIndex = 3;
			this.sinoCommonGrid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			// 
			// repositoryItemMemoEdit1
			// 
			this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
			// 
			// textEdit2
			// 
			this.textEdit2.Location = new System.Drawing.Point(545, 6);
			this.textEdit2.Name = "textEdit2";
			this.textEdit2.Size = new System.Drawing.Size(229, 21);
			this.textEdit2.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(472, 9);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(67, 14);
			this.label4.TabIndex = 6;
			this.label4.Text = "内容关键字";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(302, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 14);
			this.label3.TabIndex = 4;
			this.label3.Text = "日志类型";
			// 
			// dateEdit2
			// 
			this.dateEdit2.EditValue = null;
			this.dateEdit2.Location = new System.Drawing.Point(196, 6);
			this.dateEdit2.Name = "dateEdit2";
			this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.dateEdit2.Size = new System.Drawing.Size(100, 21);
			this.dateEdit2.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(171, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(19, 14);
			this.label2.TabIndex = 2;
			this.label2.Text = "到";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.imageComboBoxEdit1);
			this.panel1.Controls.Add(this.textEdit2);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.dateEdit2);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.dateEdit1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(10, 10);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(887, 36);
			this.panel1.TabIndex = 2;
			// 
			// imageComboBoxEdit1
			// 
			this.imageComboBoxEdit1.EditValue = "全部";
			this.imageComboBoxEdit1.Location = new System.Drawing.Point(364, 6);
			this.imageComboBoxEdit1.Name = "imageComboBoxEdit1";
			this.imageComboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.imageComboBoxEdit1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("全部", "全部", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("信息", "INFO", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("错误", "ERROR", -1)});
			this.imageComboBoxEdit1.Size = new System.Drawing.Size(100, 21);
			this.imageComboBoxEdit1.TabIndex = 8;
			// 
			// dateEdit1
			// 
			this.dateEdit1.EditValue = null;
			this.dateEdit1.Location = new System.Drawing.Point(65, 6);
			this.dateEdit1.Name = "dateEdit1";
			this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.dateEdit1.Size = new System.Drawing.Size(100, 21);
			this.dateEdit1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 14);
			this.label1.TabIndex = 0;
			this.label1.Text = "日期范围";
			// 
			// frmSystemLog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(907, 501);
			this.Controls.Add(this.sinoCommonGrid1);
			this.Controls.Add(this.panel1);
			this.Name = "frmSystemLog";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.Text = "系统操作日志";
			this.Load += new System.EventHandler(this.frmSystemLog_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sinoCommonGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
			this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
                private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
                private SinoSZClientBase.SinoCommonGrid sinoCommonGrid1;
                private DevExpress.XtraEditors.TextEdit textEdit2;
                private System.Windows.Forms.Label label4;
                private System.Windows.Forms.Label label3;
                private DevExpress.XtraEditors.DateEdit dateEdit2;
                private System.Windows.Forms.Label label2;
                private System.Windows.Forms.Panel panel1;
                private DevExpress.XtraEditors.DateEdit dateEdit1;
                private System.Windows.Forms.Label label1;
                private DevExpress.XtraEditors.ImageComboBoxEdit imageComboBoxEdit1;
                private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
                private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        }
}