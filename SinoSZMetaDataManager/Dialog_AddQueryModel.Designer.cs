namespace SinoSZMetaDataManager
{
        partial class Dialog_AddQueryModel
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
                        this.queryModelManager1 = new SinoSZMetaDataManager.QueryModelManager();
                        this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
                        this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
                        this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
                        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
                        this.panelControl1.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // queryModelManager1
                        // 
                        this.queryModelManager1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.queryModelManager1.Location = new System.Drawing.Point(8, 8);
                        this.queryModelManager1.Name = "queryModelManager1";
                        this.queryModelManager1.Size = new System.Drawing.Size(816, 316);
                        this.queryModelManager1.TabIndex = 0;
                        // 
                        // panelControl1
                        // 
                        this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                        this.panelControl1.Controls.Add(this.simpleButton2);
                        this.panelControl1.Controls.Add(this.simpleButton1);
                        this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.panelControl1.Location = new System.Drawing.Point(8, 324);
                        this.panelControl1.Name = "panelControl1";
                        this.panelControl1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
                        this.panelControl1.Size = new System.Drawing.Size(816, 45);
                        this.panelControl1.TabIndex = 3;
                        // 
                        // simpleButton2
                        // 
                        this.simpleButton2.Dock = System.Windows.Forms.DockStyle.Right;
                        this.simpleButton2.Location = new System.Drawing.Point(666, 10);
                        this.simpleButton2.Name = "simpleButton2";
                        this.simpleButton2.Size = new System.Drawing.Size(75, 25);
                        this.simpleButton2.TabIndex = 1;
                        this.simpleButton2.Text = "确定";
                        this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
                        // 
                        // simpleButton1
                        // 
                        this.simpleButton1.Dock = System.Windows.Forms.DockStyle.Right;
                        this.simpleButton1.Location = new System.Drawing.Point(741, 10);
                        this.simpleButton1.Name = "simpleButton1";
                        this.simpleButton1.Size = new System.Drawing.Size(75, 25);
                        this.simpleButton1.TabIndex = 0;
                        this.simpleButton1.Text = "取消";
                        this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
                        // 
                        // Dialog_AddQueryModel
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(832, 377);
                        this.Controls.Add(this.queryModelManager1);
                        this.Controls.Add(this.panelControl1);
                        this.Name = "Dialog_AddQueryModel";
                        this.Padding = new System.Windows.Forms.Padding(8);
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "添加查询模型";
                        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
                        this.panelControl1.ResumeLayout(false);
                        this.ResumeLayout(false);

                }

                #endregion

                private QueryModelManager queryModelManager1;
                private DevExpress.XtraEditors.PanelControl panelControl1;
                private DevExpress.XtraEditors.SimpleButton simpleButton2;
                private DevExpress.XtraEditors.SimpleButton simpleButton1;
        }
}