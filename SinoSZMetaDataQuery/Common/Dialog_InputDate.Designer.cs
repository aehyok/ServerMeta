namespace SinoSZMetaDataQuery.Common
{
        partial class Dialog_InputDate
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
                        this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
                        this.dateNavigator1 = new DevExpress.XtraScheduler.DateNavigator();
                        this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
                        this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
                        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
                        this.panelControl1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // panelControl1
                        // 
                        this.panelControl1.Controls.Add(this.simpleButton3);
                        this.panelControl1.Controls.Add(this.dateNavigator1);
                        this.panelControl1.Controls.Add(this.simpleButton2);
                        this.panelControl1.Controls.Add(this.simpleButton1);
                        this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.panelControl1.Location = new System.Drawing.Point(0, 0);
                        this.panelControl1.Name = "panelControl1";
                        this.panelControl1.Padding = new System.Windows.Forms.Padding(7, 9, 7, 0);
                        this.panelControl1.Size = new System.Drawing.Size(241, 202);
                        this.panelControl1.TabIndex = 0;
                        // 
                        // simpleButton3
                        // 
                        this.simpleButton3.Location = new System.Drawing.Point(10, 173);
                        this.simpleButton3.Name = "simpleButton3";
                        this.simpleButton3.Size = new System.Drawing.Size(47, 24);
                        this.simpleButton3.TabIndex = 4;
                        this.simpleButton3.Text = "今日";
                        this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
                        // 
                        // dateNavigator1
                        // 
                        this.dateNavigator1.DateTime = new System.DateTime(((long)(0)));
                        this.dateNavigator1.Dock = System.Windows.Forms.DockStyle.Top;
                        this.dateNavigator1.Location = new System.Drawing.Point(7, 9);
                        this.dateNavigator1.Multiselect = false;
                        this.dateNavigator1.Name = "dateNavigator1";
                        this.dateNavigator1.ShowTodayButton = false;
                        this.dateNavigator1.ShowWeekNumbers = false;
                        this.dateNavigator1.Size = new System.Drawing.Size(227, 161);
                        this.dateNavigator1.TabIndex = 3;
                        this.dateNavigator1.View = DevExpress.XtraEditors.Controls.DateEditCalendarViewType.MonthInfo;
                        // 
                        // simpleButton2
                        // 
                        this.simpleButton2.Location = new System.Drawing.Point(184, 173);
                        this.simpleButton2.Name = "simpleButton2";
                        this.simpleButton2.Size = new System.Drawing.Size(47, 24);
                        this.simpleButton2.TabIndex = 2;
                        this.simpleButton2.Text = "取消";
                        this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
                        // 
                        // simpleButton1
                        // 
                        this.simpleButton1.Location = new System.Drawing.Point(135, 173);
                        this.simpleButton1.Name = "simpleButton1";
                        this.simpleButton1.Size = new System.Drawing.Size(47, 24);
                        this.simpleButton1.TabIndex = 1;
                        this.simpleButton1.Text = "确定";
                        this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
                        // 
                        // Dialog_InputDate
                        // 
                        this.Appearance.BackColor = System.Drawing.Color.Transparent;
                        this.Appearance.Options.UseBackColor = true;
                        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(241, 202);
                        this.Controls.Add(this.panelControl1);
                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                        this.Name = "Dialog_InputDate";
                        this.ShowInTaskbar = false;
                        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                        this.Text = "Dialog_InputDate";
                        this.TopMost = true;
                        this.Load += new System.EventHandler(this.Dialog_InputDate_Load);
                        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
                        this.panelControl1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.PanelControl panelControl1;
                private DevExpress.XtraEditors.SimpleButton simpleButton2;
                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private DevExpress.XtraScheduler.DateNavigator dateNavigator1;
                private DevExpress.XtraEditors.SimpleButton simpleButton3;
        }
}