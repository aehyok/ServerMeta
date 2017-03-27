namespace SinoSZMetaDataQuery.DataQuery
{
        partial class Dialog_QueryModelDescript
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
                        this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
                        ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // memoEdit1
                        // 
                        this.memoEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.memoEdit1.Location = new System.Drawing.Point(10, 10);
                        this.memoEdit1.Name = "memoEdit1";
                        this.memoEdit1.Properties.Appearance.BackColor = System.Drawing.Color.LightCyan;
                        this.memoEdit1.Properties.Appearance.Options.UseBackColor = true;
                        this.memoEdit1.Properties.ReadOnly = true;
                        this.memoEdit1.Size = new System.Drawing.Size(620, 365);
                        this.memoEdit1.TabIndex = 0;
                        // 
                        // Dialog_QueryModelDescript
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(640, 385);
                        this.Controls.Add(this.memoEdit1);
                        this.Name = "Dialog_QueryModelDescript";
                        this.Padding = new System.Windows.Forms.Padding(10);
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "查询内容及范围说明";
                        ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.MemoEdit memoEdit1;
        }
}