namespace SinoSZClientBase.PendingAlert
{
        partial class Dialog_PendingAlert
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
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dialog_PendingAlert));
                        this.timer1 = new System.Windows.Forms.Timer(this.components);
                        this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
                        this.timer2 = new System.Windows.Forms.Timer(this.components);
                        this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
                        this.pictureBox1 = new System.Windows.Forms.PictureBox();
                        this.panel1 = new System.Windows.Forms.Panel();
                        this.panel2 = new System.Windows.Forms.Panel();
                        this.panel3 = new System.Windows.Forms.Panel();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                        this.panel2.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // timer1
                        // 
                        this.timer1.Interval = 1;
                        this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
                        // 
                        // simpleButton1
                        // 
                        this.simpleButton1.Appearance.BackColor = System.Drawing.Color.White;
                        this.simpleButton1.Appearance.Options.UseBackColor = true;
                        this.simpleButton1.Location = new System.Drawing.Point(279, 2);
                        this.simpleButton1.LookAndFeel.SkinName = "Lilian";
                        this.simpleButton1.LookAndFeel.UseDefaultLookAndFeel = false;
                        this.simpleButton1.Name = "simpleButton1";
                        this.simpleButton1.Size = new System.Drawing.Size(25, 21);
                        this.simpleButton1.TabIndex = 0;
                        this.simpleButton1.Text = "X";
                        this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
                        // 
                        // timer2
                        // 
                        this.timer2.Interval = 60000;
                        this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
                        // 
                        // labelControl1
                        // 
                        this.labelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
                        this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
                        this.labelControl1.Appearance.Options.UseBackColor = true;
                        this.labelControl1.Appearance.Options.UseFont = true;
                        this.labelControl1.Appearance.Options.UseForeColor = true;
                        this.labelControl1.Location = new System.Drawing.Point(26, 5);
                        this.labelControl1.Name = "labelControl1";
                        this.labelControl1.Size = new System.Drawing.Size(72, 17);
                        this.labelControl1.TabIndex = 1;
                        this.labelControl1.Text = "待办事项提醒";
                        // 
                        // pictureBox1
                        // 
                        this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
                        this.pictureBox1.Image = global::SinoSZClientBase.Properties.Resources.attention1_16x16;
                        this.pictureBox1.Location = new System.Drawing.Point(6, 5);
                        this.pictureBox1.Name = "pictureBox1";
                        this.pictureBox1.Size = new System.Drawing.Size(16, 16);
                        this.pictureBox1.TabIndex = 2;
                        this.pictureBox1.TabStop = false;
                        // 
                        // panel1
                        // 
                        this.panel1.BackColor = System.Drawing.Color.Transparent;
                        this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.panel1.Location = new System.Drawing.Point(0, 26);
                        this.panel1.Name = "panel1";
                        this.panel1.Padding = new System.Windows.Forms.Padding(10);
                        this.panel1.Size = new System.Drawing.Size(309, 245);
                        this.panel1.TabIndex = 0;
                        this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
                        // 
                        // panel2
                        // 
                        this.panel2.BackgroundImage = global::SinoSZClientBase.Properties.Resources.db;
                        this.panel2.Controls.Add(this.labelControl1);
                        this.panel2.Controls.Add(this.simpleButton1);
                        this.panel2.Controls.Add(this.pictureBox1);
                        this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
                        this.panel2.Location = new System.Drawing.Point(0, 0);
                        this.panel2.Name = "panel2";
                        this.panel2.Size = new System.Drawing.Size(309, 26);
                        this.panel2.TabIndex = 4;
                        // 
                        // panel3
                        // 
                        this.panel3.BackgroundImage = global::SinoSZClientBase.Properties.Resources.dbend;
                        this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.panel3.Location = new System.Drawing.Point(0, 271);
                        this.panel3.Name = "panel3";
                        this.panel3.Size = new System.Drawing.Size(309, 8);
                        this.panel3.TabIndex = 5;
                        // 
                        // Dialog_PendingAlert
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.BackgroundImage = global::SinoSZClientBase.Properties.Resources.dbborder;
                        this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile;
                        this.ClientSize = new System.Drawing.Size(309, 279);
                        this.Controls.Add(this.panel1);
                        this.Controls.Add(this.panel2);
                        this.Controls.Add(this.panel3);
                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                        this.MaximizeBox = false;
                        this.MinimizeBox = false;
                        this.Name = "Dialog_PendingAlert";
                        this.ShowInTaskbar = false;
                        this.Text = "待办事项提醒";
                        this.TopMost = true;
                        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dialog_PendingAlert_FormClosing);
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                        this.panel2.ResumeLayout(false);
                        this.panel2.PerformLayout();
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.Timer timer1;
                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private System.Windows.Forms.Timer timer2;
                private DevExpress.XtraEditors.LabelControl labelControl1;
                private System.Windows.Forms.PictureBox pictureBox1;
                private System.Windows.Forms.Panel panel1;
                private System.Windows.Forms.Panel panel2;
                private System.Windows.Forms.Panel panel3;
        }
}