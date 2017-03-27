namespace SinoSZClientUser.UserManager
{
        partial class Dialog_RegisterUser
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
                        this.panel1 = new System.Windows.Forms.Panel();
                        this.panel3 = new System.Windows.Forms.Panel();
                        this.label1 = new System.Windows.Forms.Label();
                        this.progressBarControl2 = new DevExpress.XtraEditors.ProgressBarControl();
                        this.panel2 = new System.Windows.Forms.Panel();
                        this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
                        this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
                        this.sinoCommonGrid1 = new SinoSZClientBase.SinoCommonGrid();
                        this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
                        this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
                        this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
                        this.timer1 = new System.Windows.Forms.Timer(this.components);
                        this.panel1.SuspendLayout();
                        this.panel3.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.progressBarControl2.Properties)).BeginInit();
                        this.panel2.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.sinoCommonGrid1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // panel1
                        // 
                        this.panel1.Controls.Add(this.panel3);
                        this.panel1.Controls.Add(this.panel2);
                        this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.panel1.Location = new System.Drawing.Point(10, 478);
                        this.panel1.Name = "panel1";
                        this.panel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
                        this.panel1.Size = new System.Drawing.Size(802, 35);
                        this.panel1.TabIndex = 0;
                        // 
                        // panel3
                        // 
                        this.panel3.Controls.Add(this.label1);
                        this.panel3.Controls.Add(this.progressBarControl2);
                        this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.panel3.Location = new System.Drawing.Point(0, 5);
                        this.panel3.Name = "panel3";
                        this.panel3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
                        this.panel3.Size = new System.Drawing.Size(665, 30);
                        this.panel3.TabIndex = 1;
                        // 
                        // label1
                        // 
                        this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.label1.ForeColor = System.Drawing.Color.Brown;
                        this.label1.Location = new System.Drawing.Point(170, 5);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(495, 20);
                        this.label1.TabIndex = 2;
                        this.label1.Text = " 正在读取人员信息 ...";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // progressBarControl2
                        // 
                        this.progressBarControl2.Dock = System.Windows.Forms.DockStyle.Left;
                        this.progressBarControl2.Location = new System.Drawing.Point(0, 5);
                        this.progressBarControl2.Name = "progressBarControl2";
                        this.progressBarControl2.Properties.ShowTitle = true;
                        this.progressBarControl2.Size = new System.Drawing.Size(170, 20);
                        this.progressBarControl2.TabIndex = 3;
                        // 
                        // panel2
                        // 
                        this.panel2.Controls.Add(this.simpleButton2);
                        this.panel2.Controls.Add(this.simpleButton1);
                        this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
                        this.panel2.Location = new System.Drawing.Point(665, 5);
                        this.panel2.Name = "panel2";
                        this.panel2.Size = new System.Drawing.Size(137, 30);
                        this.panel2.TabIndex = 0;
                        // 
                        // simpleButton2
                        // 
                        this.simpleButton2.Enabled = false;
                        this.simpleButton2.Location = new System.Drawing.Point(75, 3);
                        this.simpleButton2.Name = "simpleButton2";
                        this.simpleButton2.Size = new System.Drawing.Size(58, 23);
                        this.simpleButton2.TabIndex = 1;
                        this.simpleButton2.Text = "返回";
                        this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
                        // 
                        // simpleButton1
                        // 
                        this.simpleButton1.Enabled = false;
                        this.simpleButton1.Location = new System.Drawing.Point(5, 3);
                        this.simpleButton1.Name = "simpleButton1";
                        this.simpleButton1.Size = new System.Drawing.Size(64, 23);
                        this.simpleButton1.TabIndex = 0;
                        this.simpleButton1.Text = "添加用户";
                        this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
                        // 
                        // sinoCommonGrid1
                        // 
                        this.sinoCommonGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.sinoCommonGrid1.EmbeddedNavigator.Name = "";
                        this.sinoCommonGrid1.Location = new System.Drawing.Point(10, 15);
                        this.sinoCommonGrid1.MainView = this.gridView1;
                        this.sinoCommonGrid1.Name = "sinoCommonGrid1";
                        this.sinoCommonGrid1.Size = new System.Drawing.Size(802, 463);
                        this.sinoCommonGrid1.TabIndex = 1;
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
            this.gridColumn6,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
                        this.gridView1.GridControl = this.sinoCommonGrid1;
                        this.gridView1.Name = "gridView1";
                        this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
                        // 
                        // gridColumn6
                        // 
                        this.gridColumn6.Caption = "选择";
                        this.gridColumn6.FieldName = "Selected";
                        this.gridColumn6.Name = "gridColumn6";
                        this.gridColumn6.Visible = true;
                        this.gridColumn6.VisibleIndex = 0;
                        this.gridColumn6.Width = 60;
                        // 
                        // gridColumn1
                        // 
                        this.gridColumn1.Caption = "编号";
                        this.gridColumn1.FieldName = "UserID";
                        this.gridColumn1.Name = "gridColumn1";
                        this.gridColumn1.OptionsColumn.FixedWidth = true;
                        this.gridColumn1.OptionsColumn.ReadOnly = true;
                        this.gridColumn1.Visible = true;
                        this.gridColumn1.VisibleIndex = 1;
                        this.gridColumn1.Width = 100;
                        // 
                        // gridColumn2
                        // 
                        this.gridColumn2.Caption = "登录名";
                        this.gridColumn2.FieldName = "LoginName";
                        this.gridColumn2.Name = "gridColumn2";
                        this.gridColumn2.OptionsColumn.FixedWidth = true;
                        this.gridColumn2.OptionsColumn.ReadOnly = true;
                        this.gridColumn2.Visible = true;
                        this.gridColumn2.VisibleIndex = 2;
                        this.gridColumn2.Width = 120;
                        // 
                        // gridColumn3
                        // 
                        this.gridColumn3.Caption = "用户姓名";
                        this.gridColumn3.FieldName = "Name";
                        this.gridColumn3.Name = "gridColumn3";
                        this.gridColumn3.OptionsColumn.FixedWidth = true;
                        this.gridColumn3.OptionsColumn.ReadOnly = true;
                        this.gridColumn3.Visible = true;
                        this.gridColumn3.VisibleIndex = 3;
                        this.gridColumn3.Width = 120;
                        // 
                        // gridColumn4
                        // 
                        this.gridColumn4.Caption = "所属组织机构";
                        this.gridColumn4.FieldName = "OrgShortName";
                        this.gridColumn4.Name = "gridColumn4";
                        this.gridColumn4.OptionsColumn.ReadOnly = true;
                        this.gridColumn4.Visible = true;
                        this.gridColumn4.VisibleIndex = 4;
                        this.gridColumn4.Width = 341;
                        // 
                        // gridColumn5
                        // 
                        this.gridColumn5.Caption = "职务";
                        this.gridColumn5.FieldName = "HeadShip";
                        this.gridColumn5.Name = "gridColumn5";
                        this.gridColumn5.OptionsColumn.FixedWidth = true;
                        this.gridColumn5.OptionsColumn.ReadOnly = true;
                        this.gridColumn5.Visible = true;
                        this.gridColumn5.VisibleIndex = 5;
                        this.gridColumn5.Width = 100;
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
                        // Dialog_RegisterUser
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(822, 518);
                        this.Controls.Add(this.sinoCommonGrid1);
                        this.Controls.Add(this.panel1);
                        this.Name = "Dialog_RegisterUser";
                        this.Padding = new System.Windows.Forms.Padding(10, 15, 10, 5);
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "用户注册";
                        this.Load += new System.EventHandler(this.Dialog_RegisterUser_Load);
                        this.panel1.ResumeLayout(false);
                        this.panel3.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.progressBarControl2.Properties)).EndInit();
                        this.panel2.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.sinoCommonGrid1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.Panel panel1;
                private System.Windows.Forms.Panel panel2;
                private DevExpress.XtraEditors.SimpleButton simpleButton2;
                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private SinoSZClientBase.SinoCommonGrid sinoCommonGrid1;
                private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
                private System.ComponentModel.BackgroundWorker backgroundWorker1;
                private System.Windows.Forms.Panel panel3;
                private System.Windows.Forms.Label label1;
                private DevExpress.XtraEditors.ProgressBarControl progressBarControl2;
                private System.Windows.Forms.Timer timer1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        }
}