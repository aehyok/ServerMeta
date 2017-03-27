namespace SinoSZClientUser.MobileNumber
{
	partial class frmUserMobile
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
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
			this.sinoUC_OrgTree1 = new SinoSZClientBase.Organize.SinoUC_OrgTree();
			this.sinoCommonGrid1 = new SinoSZClientBase.SinoCommonGrid();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.pWaitUserList = new DevExpress.XtraEditors.PanelControl();
			this.label1 = new System.Windows.Forms.Label();
			this.pBarUserList = new DevExpress.XtraEditors.ProgressBarControl();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
			this.splitContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sinoCommonGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pWaitUserList)).BeginInit();
			this.pWaitUserList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pBarUserList.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			// 
			// timer1
			// 
			this.timer1.Interval = 500;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// splitContainerControl1
			// 
			this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
			this.splitContainerControl1.Name = "splitContainerControl1";
			this.splitContainerControl1.Panel1.Controls.Add(this.sinoUC_OrgTree1);
			this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(5);
			this.splitContainerControl1.Panel1.Text = "Panel1";
			this.splitContainerControl1.Panel2.Controls.Add(this.sinoCommonGrid1);
			this.splitContainerControl1.Panel2.Controls.Add(this.pWaitUserList);
			this.splitContainerControl1.Panel2.Text = "Panel2";
			this.splitContainerControl1.Size = new System.Drawing.Size(965, 600);
			this.splitContainerControl1.SplitterPosition = 296;
			this.splitContainerControl1.TabIndex = 1;
			this.splitContainerControl1.Text = "splitContainerControl1";
			// 
			// sinoUC_OrgTree1
			// 
			this.sinoUC_OrgTree1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sinoUC_OrgTree1.Location = new System.Drawing.Point(5, 4);
			this.sinoUC_OrgTree1.Name = "sinoUC_OrgTree1";
			this.sinoUC_OrgTree1.Size = new System.Drawing.Size(282, 587);
			this.sinoUC_OrgTree1.TabIndex = 0;
			this.sinoUC_OrgTree1.FocusChanged += new System.EventHandler<SinoSZClientBase.Organize.OrgEventArgs>(this.sinoUC_OrgTree1_FocusChanged);
			// 
			// sinoCommonGrid1
			// 
			this.sinoCommonGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sinoCommonGrid1.EmbeddedNavigator.Name = "";
			this.sinoCommonGrid1.Location = new System.Drawing.Point(0, 0);
			this.sinoCommonGrid1.MainView = this.gridView1;
			this.sinoCommonGrid1.Name = "sinoCommonGrid1";
			this.sinoCommonGrid1.Size = new System.Drawing.Size(659, 574);
			this.sinoCommonGrid1.TabIndex = 6;
			this.sinoCommonGrid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(255)))), ((int)(((byte)(229)))));
			this.gridView1.Appearance.EvenRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(255)))), ((int)(((byte)(229)))));
			this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
			this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.DarkOrange;
			this.gridView1.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.DarkOrange;
			this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
			this.gridView1.Appearance.FocusedCell.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
			this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
			this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkOrange;
			this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkOrange;
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
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "登录名";
			this.gridColumn1.FieldName = "LogonName";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.OptionsColumn.AllowEdit = false;
			this.gridColumn1.OptionsColumn.FixedWidth = true;
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			this.gridColumn1.Width = 148;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "姓名";
			this.gridColumn2.FieldName = "UserName";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.OptionsColumn.AllowEdit = false;
			this.gridColumn2.OptionsColumn.FixedWidth = true;
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			this.gridColumn2.Width = 166;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "手机号码";
			this.gridColumn3.FieldName = "Mobile";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.OptionsColumn.AllowEdit = false;
			this.gridColumn3.OptionsColumn.FixedWidth = true;
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 2;
			this.gridColumn3.Width = 160;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "电子邮件";
			this.gridColumn4.FieldName = "EMAIL";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.OptionsColumn.AllowEdit = false;
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 3;
			this.gridColumn4.Width = 164;
			// 
			// pWaitUserList
			// 
			this.pWaitUserList.Controls.Add(this.label1);
			this.pWaitUserList.Controls.Add(this.pBarUserList);
			this.pWaitUserList.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pWaitUserList.Location = new System.Drawing.Point(0, 574);
			this.pWaitUserList.Name = "pWaitUserList";
			this.pWaitUserList.Size = new System.Drawing.Size(659, 22);
			this.pWaitUserList.TabIndex = 5;
			this.pWaitUserList.Visible = false;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.ForeColor = System.Drawing.Color.Brown;
			this.label1.Location = new System.Drawing.Point(172, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(485, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = " 正在查询详细信息 ...";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pBarUserList
			// 
			this.pBarUserList.Dock = System.Windows.Forms.DockStyle.Left;
			this.pBarUserList.Location = new System.Drawing.Point(2, 2);
			this.pBarUserList.Name = "pBarUserList";
			this.pBarUserList.Properties.ShowTitle = true;
			this.pBarUserList.Size = new System.Drawing.Size(170, 18);
			this.pBarUserList.TabIndex = 1;
			// 
			// frmUserMobile
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(965, 600);
			this.Controls.Add(this.splitContainerControl1);
			this.Name = "frmUserMobile";
			this.Text = "frmUserMobile";
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
			this.splitContainerControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sinoCommonGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pWaitUserList)).EndInit();
			this.pWaitUserList.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pBarUserList.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
		private SinoSZClientBase.Organize.SinoUC_OrgTree sinoUC_OrgTree1;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.Timer timer1;
		private DevExpress.XtraEditors.PanelControl pWaitUserList;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.ProgressBarControl pBarUserList;
		private SinoSZClientBase.SinoCommonGrid sinoCommonGrid1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
	}
}