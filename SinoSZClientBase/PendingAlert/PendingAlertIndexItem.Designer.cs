namespace SinoSZClientBase.PendingAlert
{
        partial class PendingAlertIndexItem
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
                        this.label1 = new System.Windows.Forms.Label();
                        this.lb_count = new System.Windows.Forms.Label();
                        this.lb_Type = new System.Windows.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // label1
                        // 
                        this.label1.Dock = System.Windows.Forms.DockStyle.Right;
                        this.label1.Location = new System.Drawing.Point(240, 0);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(20, 24);
                        this.label1.TabIndex = 0;
                        this.label1.Text = "Ìõ";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.label1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label1_MouseClick);
                        // 
                        // lb_count
                        // 
                        this.lb_count.Dock = System.Windows.Forms.DockStyle.Right;
                        this.lb_count.ForeColor = System.Drawing.Color.Blue;
                        this.lb_count.Location = new System.Drawing.Point(210, 0);
                        this.lb_count.Name = "lb_count";
                        this.lb_count.Size = new System.Drawing.Size(30, 24);
                        this.lb_count.TabIndex = 1;
                        this.lb_count.Text = "12";
                        this.lb_count.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        this.lb_count.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lb_count_MouseClick);
                        // 
                        // lb_Type
                        // 
                        this.lb_Type.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.lb_Type.Location = new System.Drawing.Point(0, 0);
                        this.lb_Type.Name = "lb_Type";
                        this.lb_Type.Size = new System.Drawing.Size(210, 24);
                        this.lb_Type.TabIndex = 3;
                        this.lb_Type.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.lb_Type.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lb_Type_MouseClick);
                        // 
                        // PendingAlertIndexItem
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.BackColor = System.Drawing.Color.Transparent;
                        this.Controls.Add(this.lb_Type);
                        this.Controls.Add(this.lb_count);
                        this.Controls.Add(this.label1);
                        this.Name = "PendingAlertIndexItem";
                        this.Size = new System.Drawing.Size(260, 24);
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.Label label1;
                private System.Windows.Forms.Label lb_count;
                private System.Windows.Forms.Label lb_Type;
        }
}
