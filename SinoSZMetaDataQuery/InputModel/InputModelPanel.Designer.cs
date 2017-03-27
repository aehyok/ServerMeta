namespace SinoSZMetaDataQuery.InputModel
{
        partial class InputModelPanel
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
                        this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
                        this.LayoutPanel = new System.Windows.Forms.TableLayoutPanel();
                        this.xtraScrollableControl1.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // xtraScrollableControl1
                        // 
                        this.xtraScrollableControl1.Controls.Add(this.LayoutPanel);
                        this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 0);
                        this.xtraScrollableControl1.Name = "xtraScrollableControl1";
                        this.xtraScrollableControl1.Size = new System.Drawing.Size(938, 670);
                        this.xtraScrollableControl1.TabIndex = 0;
                        // 
                        // LayoutPanel
                        // 
                        this.LayoutPanel.ColumnCount = 4;
                        this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
                        this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                        this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
                        this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                        this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
                        this.LayoutPanel.Location = new System.Drawing.Point(0, 0);
                        this.LayoutPanel.Name = "LayoutPanel";
                        this.LayoutPanel.RowCount = 2;
                        this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
                        this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
                        this.LayoutPanel.Size = new System.Drawing.Size(938, 50);
                        this.LayoutPanel.TabIndex = 0;
                        // 
                        // InputModelPanel
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.xtraScrollableControl1);
                        this.Name = "InputModelPanel";
                        this.Size = new System.Drawing.Size(938, 670);
                        this.xtraScrollableControl1.ResumeLayout(false);
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
                private System.Windows.Forms.TableLayoutPanel LayoutPanel;
        }
}
