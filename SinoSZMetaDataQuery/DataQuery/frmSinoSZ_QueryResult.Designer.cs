namespace SinoSZMetaDataQuery.DataQuery
{
        partial class frmSinoSZ_QueryResult
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
                        this.panelData = new System.Windows.Forms.Panel();
                        this.panelProgress = new System.Windows.Forms.Panel();
                        this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
                        this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
                        this.panel1 = new System.Windows.Forms.Panel();
                        this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
                        this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
                        this.timer1 = new System.Windows.Forms.Timer(this.components);
                        this.pictureBox1 = new System.Windows.Forms.PictureBox();
                        this.panel2 = new System.Windows.Forms.Panel();
                        this.label1 = new System.Windows.Forms.Label();
                        this.sinoSZUC_GridControlEx1 = new SinoSZMetaDataQuery.Common.SinoSZUC_GridControlEx();
                        this.sinoSZUC_GridControlEx2 = new SinoSZMetaDataQuery.Common.SinoSZUC_GridControlEx();
                        this.sinoSZUC_GridControlEx3 = new SinoSZMetaDataQuery.Common.SinoSZUC_GridControlEx_FullRelation();
                        this.panelData.SuspendLayout();
                        this.panelProgress.SuspendLayout();
                        this.tableLayoutPanel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
                        this.panelControl1.SuspendLayout();
                        this.panel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                        this.panel2.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // panelData
                        // 
                        this.panelData.Controls.Add(this.sinoSZUC_GridControlEx1);
                        this.panelData.Controls.Add(this.sinoSZUC_GridControlEx2);
                        this.panelData.Controls.Add(this.sinoSZUC_GridControlEx3);
                        this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.panelData.Location = new System.Drawing.Point(10, 10);
                        this.panelData.Name = "panelData";
                        this.panelData.Size = new System.Drawing.Size(825, 496);
                        this.panelData.TabIndex = 0;
                        // 
                        // panelProgress
                        // 
                        this.panelProgress.Controls.Add(this.tableLayoutPanel1);
                        this.panelProgress.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.panelProgress.Location = new System.Drawing.Point(10, 10);
                        this.panelProgress.Name = "panelProgress";
                        this.panelProgress.Size = new System.Drawing.Size(825, 496);
                        this.panelProgress.TabIndex = 1;
                        // 
                        // tableLayoutPanel1
                        // 
                        this.tableLayoutPanel1.ColumnCount = 3;
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 298F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                        this.tableLayoutPanel1.Controls.Add(this.panelControl1, 1, 1);
                        this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
                        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
                        this.tableLayoutPanel1.RowCount = 3;
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 142F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
                        this.tableLayoutPanel1.Size = new System.Drawing.Size(825, 496);
                        this.tableLayoutPanel1.TabIndex = 0;
                        // 
                        // panelControl1
                        // 
                        this.panelControl1.Appearance.BorderColor = System.Drawing.Color.Lime;
                        this.panelControl1.Appearance.Options.UseBorderColor = true;
                        this.panelControl1.Controls.Add(this.panel1);
                        this.panelControl1.Controls.Add(this.panel2);
                        this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.panelControl1.Location = new System.Drawing.Point(266, 73);
                        this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
                        this.panelControl1.Name = "panelControl1";
                        this.panelControl1.Size = new System.Drawing.Size(292, 136);
                        this.panelControl1.TabIndex = 3;
                        // 
                        // panel1
                        // 
                        this.panel1.BackColor = System.Drawing.Color.White;
                        this.panel1.Controls.Add(this.labelControl1);
                        this.panel1.Controls.Add(this.pictureBox1);
                        this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.panel1.Location = new System.Drawing.Point(2, 23);
                        this.panel1.Name = "panel1";
                        this.panel1.Size = new System.Drawing.Size(288, 111);
                        this.panel1.TabIndex = 2;
                        // 
                        // labelControl1
                        // 
                        this.labelControl1.Location = new System.Drawing.Point(94, 46);
                        this.labelControl1.Name = "labelControl1";
                        this.labelControl1.Size = new System.Drawing.Size(124, 14);
                        this.labelControl1.TabIndex = 1;
                        this.labelControl1.Text = "正在处理数据,请稍候...";
                        // 
                        // backgroundWorker1
                        // 
                        this.backgroundWorker1.WorkerSupportsCancellation = true;
                        this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
                        this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
                        this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
                        // 
                        // timer1
                        // 
                        this.timer1.Interval = 500;
                        this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
                        // 
                        // pictureBox1
                        // 
                        this.pictureBox1.Image = global::SinoSZMetaDataQuery.Properties.Resources.Waiting7;
                        this.pictureBox1.Location = new System.Drawing.Point(47, 33);
                        this.pictureBox1.Name = "pictureBox1";
                        this.pictureBox1.Size = new System.Drawing.Size(32, 32);
                        this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        this.pictureBox1.TabIndex = 2;
                        this.pictureBox1.TabStop = false;
                        // 
                        // panel2
                        // 
                        this.panel2.BackgroundImage = global::SinoSZMetaDataQuery.Properties.Resources.line;
                        this.panel2.Controls.Add(this.label1);
                        this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
                        this.panel2.Location = new System.Drawing.Point(2, 2);
                        this.panel2.Name = "panel2";
                        this.panel2.Padding = new System.Windows.Forms.Padding(2);
                        this.panel2.Size = new System.Drawing.Size(288, 21);
                        this.panel2.TabIndex = 3;
                        // 
                        // label1
                        // 
                        this.label1.BackColor = System.Drawing.Color.Transparent;
                        this.label1.Dock = System.Windows.Forms.DockStyle.Left;
                        this.label1.Font = new System.Drawing.Font("Tahoma", 9F);
                        this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.label1.Location = new System.Drawing.Point(2, 2);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(174, 17);
                        this.label1.TabIndex = 0;
                        this.label1.Text = "系统提示";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // sinoSZUC_GridControlEx1
                        // 
                        this.sinoSZUC_GridControlEx1.AutoColumnWidth = false;
                        this.sinoSZUC_GridControlEx1.BackColor = System.Drawing.Color.Transparent;
                        this.sinoSZUC_GridControlEx1.DataSource = null;
                        this.sinoSZUC_GridControlEx1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.sinoSZUC_GridControlEx1.Location = new System.Drawing.Point(0, 0);
                        this.sinoSZUC_GridControlEx1.Name = "sinoSZUC_GridControlEx1";
                        this.sinoSZUC_GridControlEx1.ReadOnly = true;
                        this.sinoSZUC_GridControlEx1.ShowAsGroupSorting = false;
                        this.sinoSZUC_GridControlEx1.ShowFilterPanel = true;
                        this.sinoSZUC_GridControlEx1.ShowFooter = true;
                        this.sinoSZUC_GridControlEx1.ShowGroupPanel = true;
                        this.sinoSZUC_GridControlEx1.Size = new System.Drawing.Size(825, 496);
                        this.sinoSZUC_GridControlEx1.TabIndex = 0;
                        this.sinoSZUC_GridControlEx1.ColumnGrouped += new System.EventHandler(this.sinoSZUC_GridControlEx1_ColumnGrouped);
                        this.sinoSZUC_GridControlEx1.GroupColumnCleared += new System.EventHandler(this.sinoSZUC_GridControlEx1_GroupColumnCleared);
                        // 
                        // sinoSZUC_GridControlEx2
                        // 
                        this.sinoSZUC_GridControlEx2.AutoColumnWidth = false;
                        this.sinoSZUC_GridControlEx2.BackColor = System.Drawing.Color.Transparent;
                        this.sinoSZUC_GridControlEx2.DataSource = null;
                        this.sinoSZUC_GridControlEx2.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.sinoSZUC_GridControlEx2.Location = new System.Drawing.Point(0, 0);
                        this.sinoSZUC_GridControlEx2.Name = "sinoSZUC_GridControlEx2";
                        this.sinoSZUC_GridControlEx2.ReadOnly = true;
                        this.sinoSZUC_GridControlEx2.ShowAsGroupSorting = false;
                        this.sinoSZUC_GridControlEx2.ShowFilterPanel = true;
                        this.sinoSZUC_GridControlEx2.ShowFooter = true;
                        this.sinoSZUC_GridControlEx2.ShowGroupPanel = true;
                        this.sinoSZUC_GridControlEx2.Size = new System.Drawing.Size(825, 496);
                        this.sinoSZUC_GridControlEx2.TabIndex = 1;
                        this.sinoSZUC_GridControlEx2.ColumnGrouped += new System.EventHandler(this.sinoSZUC_GridControlEx1_ColumnGrouped);
                        this.sinoSZUC_GridControlEx2.GroupColumnCleared += new System.EventHandler(this.sinoSZUC_GridControlEx1_GroupColumnCleared);
                        // 
                        // sinoSZUC_GridControlEx3
                        // 
                        this.sinoSZUC_GridControlEx3.DataSource = null;
                        this.sinoSZUC_GridControlEx3.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.sinoSZUC_GridControlEx3.Location = new System.Drawing.Point(0, 0);
                        this.sinoSZUC_GridControlEx3.Name = "sinoSZUC_GridControlEx3";
                        this.sinoSZUC_GridControlEx3.ReadOnly = true;
                        this.sinoSZUC_GridControlEx3.Size = new System.Drawing.Size(825, 496);
                        this.sinoSZUC_GridControlEx3.TabIndex = 2;
                        // 
                        // frmSinoSZ_QueryResult
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(845, 516);
                        this.Controls.Add(this.panelProgress);
                        this.Controls.Add(this.panelData);
                        this.Name = "frmSinoSZ_QueryResult";
                        this.Padding = new System.Windows.Forms.Padding(10);
                        this.Text = "frmSinoSZ_QueryResult";
                        this.Load += new System.EventHandler(this.frmSinoSZ_QueryResult_Load);
                        this.panelData.ResumeLayout(false);
                        this.panelProgress.ResumeLayout(false);
                        this.tableLayoutPanel1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
                        this.panelControl1.ResumeLayout(false);
                        this.panel1.ResumeLayout(false);
                        this.panel1.PerformLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                        this.panel2.ResumeLayout(false);
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.Panel panelData;
                private System.Windows.Forms.Panel panelProgress;
                private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
                private DevExpress.XtraEditors.LabelControl labelControl1;
                private System.Windows.Forms.PictureBox pictureBox1;
                private System.ComponentModel.BackgroundWorker backgroundWorker1;
                private System.Windows.Forms.Timer timer1;
                private SinoSZMetaDataQuery.Common.SinoSZUC_GridControlEx_FullRelation sinoSZUC_GridControlEx3;
                private DevExpress.XtraEditors.PanelControl panelControl1;
                private System.Windows.Forms.Panel panel1;
                private System.Windows.Forms.Panel panel2;
                private System.Windows.Forms.Label label1;
                private SinoSZMetaDataQuery.Common.SinoSZUC_GridControlEx sinoSZUC_GridControlEx1;
                private SinoSZMetaDataQuery.Common.SinoSZUC_GridControlEx sinoSZUC_GridControlEx2;
        }
}