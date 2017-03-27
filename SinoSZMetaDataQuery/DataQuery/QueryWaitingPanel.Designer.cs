namespace SinoSZMetaDataQuery.DataQuery
{
        partial class QueryWaitingPanel
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
                        this.pictureBox1 = new System.Windows.Forms.PictureBox();
                        this.label1 = new System.Windows.Forms.Label();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // pictureBox1
                        // 
                        this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
                        this.pictureBox1.Image = global::SinoSZMetaDataQuery.Properties.Resources.Waiting5;
                        this.pictureBox1.Location = new System.Drawing.Point(0, 0);
                        this.pictureBox1.Name = "pictureBox1";
                        this.pictureBox1.Size = new System.Drawing.Size(20, 29);
                        this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        this.pictureBox1.TabIndex = 0;
                        this.pictureBox1.TabStop = false;
                        // 
                        // label1
                        // 
                        this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.label1.ForeColor = System.Drawing.Color.Blue;
                        this.label1.Location = new System.Drawing.Point(20, 0);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(130, 29);
                        this.label1.TabIndex = 1;
                        this.label1.Text = "正在查询数据...";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // QueryWaitingPanel
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.BackColor = System.Drawing.Color.Transparent;
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.pictureBox1);
                        this.Margin = new System.Windows.Forms.Padding(0);
                        this.Name = "QueryWaitingPanel";
                        this.Size = new System.Drawing.Size(150, 29);
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.PictureBox pictureBox1;
                private System.Windows.Forms.Label label1;
        }
}
