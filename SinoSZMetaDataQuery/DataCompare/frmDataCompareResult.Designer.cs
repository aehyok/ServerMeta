namespace SinoSZMetaDataQuery.DataCompare
{
	partial class frmDataCompareResult
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
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.label1 = new System.Windows.Forms.Label();
			this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
			this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
			this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.sinoSZUC_GridControlEx1 = new SinoSZMetaDataQuery.Common.SinoSZUC_GridControlEx();
			this.sinoSZUC_GridControlEx_FullRelation1 = new SinoSZMetaDataQuery.Common.SinoSZUC_GridControlEx_FullRelation();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
			this.panelControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.panelControl1, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.panelControl2, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.sinoSZUC_GridControlEx1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.sinoSZUC_GridControlEx_FullRelation1, 0, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1029, 572);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// panelControl1
			// 
			this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.panelControl1, 2);
			this.panelControl1.Controls.Add(this.label1);
			this.panelControl1.Controls.Add(this.marqueeProgressBarControl1);
			this.panelControl1.Location = new System.Drawing.Point(3, 545);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(1023, 24);
			this.panelControl1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(260, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(761, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "正在执行数据比对...";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// marqueeProgressBarControl1
			// 
			this.marqueeProgressBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
			this.marqueeProgressBarControl1.EditValue = 0;
			this.marqueeProgressBarControl1.Location = new System.Drawing.Point(2, 2);
			this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
			this.marqueeProgressBarControl1.Size = new System.Drawing.Size(258, 20);
			this.marqueeProgressBarControl1.TabIndex = 0;
			// 
			// panelControl2
			// 
			this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.panelControl2, 2);
			this.panelControl2.Controls.Add(this.radioGroup1);
			this.panelControl2.Location = new System.Drawing.Point(5, 5);
			this.panelControl2.Margin = new System.Windows.Forms.Padding(5);
			this.panelControl2.Name = "panelControl2";
			this.panelControl2.Size = new System.Drawing.Size(1019, 50);
			this.panelControl2.TabIndex = 1;
			// 
			// radioGroup1
			// 
			this.radioGroup1.EditValue = 1;
			this.radioGroup1.Location = new System.Drawing.Point(20, 6);
			this.radioGroup1.Name = "radioGroup1";
			this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
			this.radioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.radioGroup1.Properties.Columns = 2;
			this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "比对匹配的记录"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "未匹配的记录")});
			this.radioGroup1.Size = new System.Drawing.Size(290, 39);
			this.radioGroup1.TabIndex = 0;
			this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			// 
			// sinoSZUC_GridControlEx1
			// 
			this.sinoSZUC_GridControlEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.sinoSZUC_GridControlEx1.AutoColumnWidth = false;
			this.sinoSZUC_GridControlEx1.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel1.SetColumnSpan(this.sinoSZUC_GridControlEx1, 2);
			this.sinoSZUC_GridControlEx1.DataSource = null;
			this.sinoSZUC_GridControlEx1.Location = new System.Drawing.Point(3, 63);
			this.sinoSZUC_GridControlEx1.Name = "sinoSZUC_GridControlEx1";
			this.sinoSZUC_GridControlEx1.ReadOnly = false;
			this.sinoSZUC_GridControlEx1.ShowAsGroupSorting = false;
			this.sinoSZUC_GridControlEx1.ShowFilterPanel = true;
			this.sinoSZUC_GridControlEx1.ShowFooter = true;
			this.sinoSZUC_GridControlEx1.ShowGroupPanel = true;
			this.sinoSZUC_GridControlEx1.Size = new System.Drawing.Size(1023, 235);
			this.sinoSZUC_GridControlEx1.TabIndex = 2;
			// 
			// sinoSZUC_GridControlEx_FullRelation1
			// 
			this.sinoSZUC_GridControlEx_FullRelation1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.sinoSZUC_GridControlEx_FullRelation1, 2);
			this.sinoSZUC_GridControlEx_FullRelation1.DataSource = null;
			this.sinoSZUC_GridControlEx_FullRelation1.Location = new System.Drawing.Point(3, 304);
			this.sinoSZUC_GridControlEx_FullRelation1.Name = "sinoSZUC_GridControlEx_FullRelation1";
			this.sinoSZUC_GridControlEx_FullRelation1.ReadOnly = true;
			this.sinoSZUC_GridControlEx_FullRelation1.Size = new System.Drawing.Size(1023, 235);
			this.sinoSZUC_GridControlEx_FullRelation1.TabIndex = 3;
			// 
			// frmDataCompareResult
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1039, 582);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "frmDataCompareResult";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.Text = "frmDataCompareResult";
			this.Load += new System.EventHandler(this.frmDataCompareResult_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
			this.panelControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
		private DevExpress.XtraEditors.PanelControl panelControl2;
		private DevExpress.XtraEditors.RadioGroup radioGroup1;
		private SinoSZMetaDataQuery.Common.SinoSZUC_GridControlEx sinoSZUC_GridControlEx1;
		private SinoSZMetaDataQuery.Common.SinoSZUC_GridControlEx_FullRelation sinoSZUC_GridControlEx_FullRelation1;
	}
}