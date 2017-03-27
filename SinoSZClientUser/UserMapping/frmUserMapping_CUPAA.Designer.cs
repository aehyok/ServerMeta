namespace SinoSZClientUser.UserMapping
{
    partial class frmUserMapping_CUPAA
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.sinoUC_OrgTree1 = new SinoSZClientBase.Organize.SinoUC_OrgTree();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.userMappingList1 = new SinoSZClientUser.Controls.UserMappingList();
            this.pWaitUserList = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.pBarUserList = new DevExpress.XtraEditors.ProgressBarControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TE_TRD_USERID = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.TE_TRD_XM = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TE_TRD_NAME = new DevExpress.XtraEditors.TextEdit();
            this.te_search = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TE_CUPAA_USERNAME = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.te_CUPAA_USERID = new DevExpress.XtraEditors.TextEdit();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pWaitUserList)).BeginInit();
            this.pWaitUserList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBarUserList.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TE_TRD_USERID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_TRD_XM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_TRD_NAME.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_search.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TE_CUPAA_USERNAME.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_CUPAA_USERID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.sinoUC_OrgTree1);
            this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(9, 12, 9, 12);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1281, 818);
            this.splitContainerControl1.SplitterPosition = 296;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // sinoUC_OrgTree1
            // 
            this.sinoUC_OrgTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sinoUC_OrgTree1.Location = new System.Drawing.Point(9, 12);
            this.sinoUC_OrgTree1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.sinoUC_OrgTree1.Name = "sinoUC_OrgTree1";
            this.sinoUC_OrgTree1.Size = new System.Drawing.Size(278, 794);
            this.sinoUC_OrgTree1.TabIndex = 0;
            this.sinoUC_OrgTree1.FocusChanged += new System.EventHandler<SinoSZClientBase.Organize.OrgEventArgs>(this.sinoUC_OrgTree1_FocusChanged);
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.userMappingList1);
            this.splitContainerControl2.Panel1.Controls.Add(this.pWaitUserList);
            this.splitContainerControl2.Panel1.Padding = new System.Windows.Forms.Padding(9, 12, 9, 12);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainerControl2.Panel2.Padding = new System.Windows.Forms.Padding(9, 12, 9, 12);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(980, 818);
            this.splitContainerControl2.SplitterPosition = 313;
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // userMappingList1
            // 
            this.userMappingList1.DataSource = null;
            this.userMappingList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userMappingList1.Location = new System.Drawing.Point(9, 12);
            this.userMappingList1.Name = "userMappingList1";
            this.userMappingList1.Size = new System.Drawing.Size(962, 256);
            this.userMappingList1.TabIndex = 5;
            this.userMappingList1.UserFocusChanged += new System.EventHandler<System.EventArgs>(this.userMappingList1_UserFocusChanged);
            // 
            // pWaitUserList
            // 
            this.pWaitUserList.Controls.Add(this.label1);
            this.pWaitUserList.Controls.Add(this.pBarUserList);
            this.pWaitUserList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pWaitUserList.Location = new System.Drawing.Point(9, 268);
            this.pWaitUserList.Margin = new System.Windows.Forms.Padding(4);
            this.pWaitUserList.Name = "pWaitUserList";
            this.pWaitUserList.Size = new System.Drawing.Size(962, 33);
            this.pWaitUserList.TabIndex = 4;
            this.pWaitUserList.Visible = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(229, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(731, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = " 正在查询详细信息 ...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pBarUserList
            // 
            this.pBarUserList.Dock = System.Windows.Forms.DockStyle.Left;
            this.pBarUserList.Location = new System.Drawing.Point(2, 2);
            this.pBarUserList.Margin = new System.Windows.Forms.Padding(4);
            this.pBarUserList.Name = "pBarUserList";
            this.pBarUserList.Properties.ShowTitle = true;
            this.pBarUserList.Size = new System.Drawing.Size(227, 29);
            this.pBarUserList.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(962, 476);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.groupControl2, 4);
            this.groupControl2.Controls.Add(this.tableLayoutPanel3);
            this.groupControl2.Location = new System.Drawing.Point(3, 73);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(956, 174);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "线索系统的用户信息";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.button1, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.TE_TRD_USERID, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label5, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.TE_TRD_XM, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.TE_TRD_NAME, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.te_search, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 26);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(952, 146);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(479, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "搜索";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "用户ID";
            // 
            // TE_TRD_USERID
            // 
            this.TE_TRD_USERID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TE_TRD_USERID.Location = new System.Drawing.Point(123, 78);
            this.TE_TRD_USERID.Name = "TE_TRD_USERID";
            this.TE_TRD_USERID.Properties.ReadOnly = true;
            this.TE_TRD_USERID.Size = new System.Drawing.Size(350, 24);
            this.TE_TRD_USERID.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(479, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "姓名";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TE_TRD_XM
            // 
            this.TE_TRD_XM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TE_TRD_XM.Location = new System.Drawing.Point(599, 78);
            this.TE_TRD_XM.Name = "TE_TRD_XM";
            this.TE_TRD_XM.Properties.ReadOnly = true;
            this.TE_TRD_XM.Size = new System.Drawing.Size(350, 24);
            this.TE_TRD_XM.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "查找登录名";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 18);
            this.label7.TabIndex = 10;
            this.label7.Text = "登录名";
            // 
            // TE_TRD_NAME
            // 
            this.TE_TRD_NAME.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TE_TRD_NAME.Location = new System.Drawing.Point(123, 42);
            this.TE_TRD_NAME.Name = "TE_TRD_NAME";
            this.TE_TRD_NAME.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.TE_TRD_NAME.Properties.Appearance.Options.UseForeColor = true;
            this.TE_TRD_NAME.Properties.ReadOnly = true;
            this.TE_TRD_NAME.Size = new System.Drawing.Size(350, 24);
            this.TE_TRD_NAME.TabIndex = 7;
            // 
            // te_search
            // 
            this.te_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.te_search.Location = new System.Drawing.Point(123, 6);
            this.te_search.Name = "te_search";
            this.te_search.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.te_search.Properties.Appearance.Options.UseForeColor = true;
            this.te_search.Size = new System.Drawing.Size(350, 24);
            this.te_search.TabIndex = 11;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.groupControl1, 4);
            this.groupControl1.Controls.Add(this.tableLayoutPanel2);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(956, 64);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "三统一中的用户信息";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.TE_CUPAA_USERNAME, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.te_CUPAA_USERID, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 26);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(952, 36);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // TE_CUPAA_USERNAME
            // 
            this.TE_CUPAA_USERNAME.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TE_CUPAA_USERNAME.Location = new System.Drawing.Point(599, 6);
            this.TE_CUPAA_USERNAME.Name = "TE_CUPAA_USERNAME";
            this.TE_CUPAA_USERNAME.Properties.ReadOnly = true;
            this.TE_CUPAA_USERNAME.Size = new System.Drawing.Size(350, 24);
            this.TE_CUPAA_USERNAME.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "用户ID";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(479, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "用户名";
            // 
            // te_CUPAA_USERID
            // 
            this.te_CUPAA_USERID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.te_CUPAA_USERID.Location = new System.Drawing.Point(123, 6);
            this.te_CUPAA_USERID.Name = "te_CUPAA_USERID";
            this.te_CUPAA_USERID.Properties.ReadOnly = true;
            this.te_CUPAA_USERID.Size = new System.Drawing.Size(350, 24);
            this.te_CUPAA_USERID.TabIndex = 4;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            // 
            // frmUserMapping_CUPAA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 818);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmUserMapping_CUPAA";
            this.Text = "三统一用户映射";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pWaitUserList)).EndInit();
            this.pWaitUserList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBarUserList.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TE_TRD_USERID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_TRD_XM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_TRD_NAME.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_search.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TE_CUPAA_USERNAME.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_CUPAA_USERID.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private SinoSZClientBase.Organize.SinoUC_OrgTree sinoUC_OrgTree1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.PanelControl pWaitUserList;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ProgressBarControl pBarUserList;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private Controls.UserMappingList userMappingList1;
        private DevExpress.XtraEditors.TextEdit TE_TRD_NAME;
        private DevExpress.XtraEditors.TextEdit TE_TRD_USERID;
        private DevExpress.XtraEditors.TextEdit TE_TRD_XM;
        private DevExpress.XtraEditors.TextEdit TE_CUPAA_USERNAME;
        private DevExpress.XtraEditors.TextEdit te_CUPAA_USERID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit te_search;
    }
}