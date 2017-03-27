namespace SinoSZMetaDataManager
{
        partial class Dialog_AddNameSpace
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
                        this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
                        this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
                        this.nameSpaceManager1 = new SinoSZMetaDataManager.NameSpaceManager();
                        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
                        this.panelControl1.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // panelControl1
                        // 
                        this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                        this.panelControl1.Controls.Add(this.simpleButton2);
                        this.panelControl1.Controls.Add(this.simpleButton1);
                        this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.panelControl1.Location = new System.Drawing.Point(10, 452);
                        this.panelControl1.Name = "panelControl1";
                        this.panelControl1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
                        this.panelControl1.Size = new System.Drawing.Size(582, 45);
                        this.panelControl1.TabIndex = 1;
                        // 
                        // simpleButton1
                        // 
                        this.simpleButton1.Dock = System.Windows.Forms.DockStyle.Right;
                        this.simpleButton1.Location = new System.Drawing.Point(507, 10);
                        this.simpleButton1.Name = "simpleButton1";
                        this.simpleButton1.Size = new System.Drawing.Size(75, 25);
                        this.simpleButton1.TabIndex = 0;
                        this.simpleButton1.Text = "取消";
                        this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
                        // 
                        // simpleButton2
                        // 
                        this.simpleButton2.Dock = System.Windows.Forms.DockStyle.Right;
                        this.simpleButton2.Location = new System.Drawing.Point(432, 10);
                        this.simpleButton2.Name = "simpleButton2";
                        this.simpleButton2.Size = new System.Drawing.Size(75, 25);
                        this.simpleButton2.TabIndex = 1;
                        this.simpleButton2.Text = "确定";
                        this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
                        // 
                        // nameSpaceManager1
                        // 
                        this.nameSpaceManager1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.nameSpaceManager1.Location = new System.Drawing.Point(10, 10);
                        this.nameSpaceManager1.Name = "nameSpaceManager1";
                        this.nameSpaceManager1.Size = new System.Drawing.Size(582, 442);
                        this.nameSpaceManager1.TabIndex = 0;
                        // 
                        // Dialog_AddNameSpace
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(602, 507);
                        this.Controls.Add(this.nameSpaceManager1);
                        this.Controls.Add(this.panelControl1);
                        this.Name = "Dialog_AddNameSpace";
                        this.Padding = new System.Windows.Forms.Padding(10);
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "添加命名空间";
                        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
                        this.panelControl1.ResumeLayout(false);
                        this.ResumeLayout(false);

                }

                #endregion

                private NameSpaceManager nameSpaceManager1;
                private DevExpress.XtraEditors.PanelControl panelControl1;
                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private DevExpress.XtraEditors.SimpleButton simpleButton2;
        }
}