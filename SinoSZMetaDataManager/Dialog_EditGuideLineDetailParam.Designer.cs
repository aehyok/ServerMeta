namespace SinoSZMetaDataManager
{
        partial class Dialog_EditGuideLineDetailParam
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
			this.sinoCommonGrid1 = new SinoSZClientBase.SinoCommonGrid();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
			this.panel2 = new System.Windows.Forms.Panel();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.panelGuideLine = new System.Windows.Forms.Panel();
			this.panelQueryModel = new System.Windows.Forms.Panel();
			this.te_Value = new DevExpress.XtraEditors.ComboBoxEdit();
			this.label4 = new System.Windows.Forms.Label();
			this.te_Type = new DevExpress.XtraEditors.TextEdit();
			this.label3 = new System.Windows.Forms.Label();
			this.te_Title = new DevExpress.XtraEditors.TextEdit();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.panelOther = new DevExpress.XtraEditors.PanelControl();
			this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
			((System.ComponentModel.ISupportInitialize)(this.sinoCommonGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panelGuideLine.SuspendLayout();
			this.panelQueryModel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.te_Value.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_Type.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_Title.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelOther)).BeginInit();
			this.panelOther.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// sinoCommonGrid1
			// 
			this.sinoCommonGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sinoCommonGrid1.EmbeddedNavigator.Name = "";
			this.sinoCommonGrid1.Location = new System.Drawing.Point(0, 0);
			this.sinoCommonGrid1.MainView = this.gridView1;
			this.sinoCommonGrid1.Name = "sinoCommonGrid1";
			this.sinoCommonGrid1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
			this.sinoCommonGrid1.Size = new System.Drawing.Size(701, 276);
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
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
			this.gridView1.GridControl = this.sinoCommonGrid1;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
			this.gridView1.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEdit);
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "参数名";
			this.gridColumn1.FieldName = "Name";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.OptionsColumn.ReadOnly = true;
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			this.gridColumn1.Width = 101;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "参数值";
			this.gridColumn2.FieldName = "DataValue";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 3;
			this.gridColumn2.Width = 264;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "显示名称";
			this.gridColumn3.FieldName = "Title";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.OptionsColumn.ReadOnly = true;
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 1;
			this.gridColumn3.Width = 140;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "类型";
			this.gridColumn4.FieldName = "Type";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.OptionsColumn.ReadOnly = true;
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 2;
			this.gridColumn4.Width = 136;
			// 
			// repositoryItemComboBox1
			// 
			this.repositoryItemComboBox1.AutoHeight = false;
			this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "#当年#",
            "#当月#",
            "#当日#",
            "#当年##当月##当日#",
            "#当年#0101",
            "#当年#1231",
            "#当年##当月#01"});
			this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.simpleButton3);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(10, 286);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(701, 38);
			this.panel1.TabIndex = 1;
			// 
			// simpleButton3
			// 
			this.simpleButton3.Location = new System.Drawing.Point(0, 10);
			this.simpleButton3.Name = "simpleButton3";
			this.simpleButton3.Size = new System.Drawing.Size(81, 23);
			this.simpleButton3.TabIndex = 3;
			this.simpleButton3.Text = "刷新参数表";
			this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.simpleButton2);
			this.panel2.Controls.Add(this.simpleButton1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new System.Drawing.Point(501, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(200, 38);
			this.panel2.TabIndex = 2;
			// 
			// simpleButton2
			// 
			this.simpleButton2.Location = new System.Drawing.Point(144, 10);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.Size = new System.Drawing.Size(55, 23);
			this.simpleButton2.TabIndex = 1;
			this.simpleButton2.Text = "取消";
			this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
			// 
			// simpleButton1
			// 
			this.simpleButton1.Location = new System.Drawing.Point(84, 10);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new System.Drawing.Size(55, 23);
			this.simpleButton1.TabIndex = 0;
			this.simpleButton1.Text = "确定";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// panelGuideLine
			// 
			this.panelGuideLine.Controls.Add(this.sinoCommonGrid1);
			this.panelGuideLine.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelGuideLine.Location = new System.Drawing.Point(10, 10);
			this.panelGuideLine.Name = "panelGuideLine";
			this.panelGuideLine.Size = new System.Drawing.Size(701, 276);
			this.panelGuideLine.TabIndex = 2;
			// 
			// panelQueryModel
			// 
			this.panelQueryModel.Controls.Add(this.te_Value);
			this.panelQueryModel.Controls.Add(this.label4);
			this.panelQueryModel.Controls.Add(this.te_Type);
			this.panelQueryModel.Controls.Add(this.label3);
			this.panelQueryModel.Controls.Add(this.te_Title);
			this.panelQueryModel.Controls.Add(this.label2);
			this.panelQueryModel.Controls.Add(this.comboBoxEdit1);
			this.panelQueryModel.Controls.Add(this.label1);
			this.panelQueryModel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelQueryModel.Location = new System.Drawing.Point(10, 10);
			this.panelQueryModel.Name = "panelQueryModel";
			this.panelQueryModel.Size = new System.Drawing.Size(701, 276);
			this.panelQueryModel.TabIndex = 3;
			// 
			// te_Value
			// 
			this.te_Value.Location = new System.Drawing.Point(110, 116);
			this.te_Value.Name = "te_Value";
			this.te_Value.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.te_Value.Properties.Items.AddRange(new object[] {
            "#当年#",
            "#当月#",
            "#当日#",
            "#当年##当月##当日#",
            "#当年#0101",
            "#当年#1231",
            "#当年##当月#01"});
			this.te_Value.Size = new System.Drawing.Size(549, 21);
			this.te_Value.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(14, 115);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(98, 20);
			this.label4.TabIndex = 7;
			this.label4.Text = "参数值";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// te_Type
			// 
			this.te_Type.Location = new System.Drawing.Point(110, 89);
			this.te_Type.Name = "te_Type";
			this.te_Type.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
			this.te_Type.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.White;
			this.te_Type.Properties.AppearanceReadOnly.Options.UseBackColor = true;
			this.te_Type.Properties.ReadOnly = true;
			this.te_Type.Size = new System.Drawing.Size(549, 21);
			this.te_Type.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(14, 89);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(98, 20);
			this.label3.TabIndex = 4;
			this.label3.Text = "类型";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// te_Title
			// 
			this.te_Title.Location = new System.Drawing.Point(110, 63);
			this.te_Title.Name = "te_Title";
			this.te_Title.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
			this.te_Title.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.White;
			this.te_Title.Properties.AppearanceReadOnly.Options.UseBackColor = true;
			this.te_Title.Properties.ReadOnly = true;
			this.te_Title.Size = new System.Drawing.Size(549, 21);
			this.te_Title.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(14, 63);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(98, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "字段名称";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// comboBoxEdit1
			// 
			this.comboBoxEdit1.Location = new System.Drawing.Point(110, 37);
			this.comboBoxEdit1.Name = "comboBoxEdit1";
			this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit1.Size = new System.Drawing.Size(549, 21);
			this.comboBoxEdit1.TabIndex = 1;
			this.comboBoxEdit1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit1_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(14, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(98, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "显示名称";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panelOther
			// 
			this.panelOther.Controls.Add(this.memoEdit1);
			this.panelOther.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelOther.Location = new System.Drawing.Point(10, 10);
			this.panelOther.Name = "panelOther";
			this.panelOther.Size = new System.Drawing.Size(701, 276);
			this.panelOther.TabIndex = 4;
			// 
			// memoEdit1
			// 
			this.memoEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.memoEdit1.Location = new System.Drawing.Point(2, 2);
			this.memoEdit1.Name = "memoEdit1";
			this.memoEdit1.Size = new System.Drawing.Size(697, 272);
			this.memoEdit1.TabIndex = 0;
			// 
			// Dialog_EditGuideLineDetailParam
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(721, 334);
			this.Controls.Add(this.panelOther);
			this.Controls.Add(this.panelQueryModel);
			this.Controls.Add(this.panelGuideLine);
			this.Controls.Add(this.panel1);
			this.Name = "Dialog_EditGuideLineDetailParam";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "关联详细信息参数";
			((System.ComponentModel.ISupportInitialize)(this.sinoCommonGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panelGuideLine.ResumeLayout(false);
			this.panelQueryModel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.te_Value.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_Type.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_Title.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelOther)).EndInit();
			this.panelOther.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
			this.ResumeLayout(false);

                }

                #endregion

                private SinoSZClientBase.SinoCommonGrid sinoCommonGrid1;
                private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
                private System.Windows.Forms.Panel panel1;
                private System.Windows.Forms.Panel panel2;
                private DevExpress.XtraEditors.SimpleButton simpleButton2;
                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
                private DevExpress.XtraEditors.SimpleButton simpleButton3;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
                private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
                private System.Windows.Forms.Panel panelGuideLine;
                private System.Windows.Forms.Panel panelQueryModel;
                private System.Windows.Forms.Label label1;
                private System.Windows.Forms.Label label2;
                private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
                private System.Windows.Forms.Label label4;
                private DevExpress.XtraEditors.TextEdit te_Type;
                private System.Windows.Forms.Label label3;
                private DevExpress.XtraEditors.TextEdit te_Title;
                private DevExpress.XtraEditors.ComboBoxEdit te_Value;
		private DevExpress.XtraEditors.PanelControl panelOther;
		private DevExpress.XtraEditors.MemoEdit memoEdit1;
        }
}