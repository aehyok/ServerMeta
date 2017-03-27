namespace SinoSZClientBase.PortalItem
{
        partial class SinoSZUC_PortalItemBase
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

                #region Component Designer generated code

                /// <summary> 
                /// Required method for Designer support - do not modify 
                /// the contents of this method with the code editor.
                /// </summary>
                private void InitializeComponent()
                {
                        this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
                        this.panel1 = new System.Windows.Forms.Panel();
                        this.linkLabel1 = new System.Windows.Forms.LinkLabel();
                        ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
                        this.groupControl1.SuspendLayout();
                        this.panel1.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // groupControl1
                        // 
                        this.groupControl1.Controls.Add(this.panel1);
                        this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.groupControl1.Location = new System.Drawing.Point(0, 0);
                        this.groupControl1.LookAndFeel.SkinName = "Blue";
                        this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
                        this.groupControl1.Margin = new System.Windows.Forms.Padding(20);
                        this.groupControl1.Name = "groupControl1";
                        this.groupControl1.Size = new System.Drawing.Size(256, 327);
                        this.groupControl1.TabIndex = 2;
                        this.groupControl1.Text = "正在加载数据...";
                        // 
                        // panel1
                        // 
                        this.panel1.Controls.Add(this.linkLabel1);
                        this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.panel1.Location = new System.Drawing.Point(2, 307);
                        this.panel1.Name = "panel1";
                        this.panel1.Size = new System.Drawing.Size(252, 18);
                        this.panel1.TabIndex = 1;
                        // 
                        // linkLabel1
                        // 
                        this.linkLabel1.Dock = System.Windows.Forms.DockStyle.Right;
                        this.linkLabel1.Location = new System.Drawing.Point(212, 0);
                        this.linkLabel1.Name = "linkLabel1";
                        this.linkLabel1.Size = new System.Drawing.Size(40, 18);
                        this.linkLabel1.TabIndex = 0;
                        this.linkLabel1.TabStop = true;
                        this.linkLabel1.Text = "更多...";
                        this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
                        // 
                        // SinoSZUC_PortalItemBase
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.BackColor = System.Drawing.Color.Transparent;
                        this.Controls.Add(this.groupControl1);
                        this.Name = "SinoSZUC_PortalItemBase";
                        this.Size = new System.Drawing.Size(256, 327);
                        ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
                        this.groupControl1.ResumeLayout(false);
                        this.panel1.ResumeLayout(false);
                        this.ResumeLayout(false);

                }

                #endregion

                protected System.Windows.Forms.LinkLabel linkLabel1;
                protected DevExpress.XtraEditors.GroupControl groupControl1;
                protected System.Windows.Forms.Panel panel1;
        }
}
