namespace SinoSZMetaDataQuery.InputModel
{
        partial class SinoUC_IM_Text
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
                        this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
                        ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // textEdit1
                        // 
                        this.textEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.textEdit1.Location = new System.Drawing.Point(0, 0);
                        this.textEdit1.Margin = new System.Windows.Forms.Padding(0);
                        this.textEdit1.Name = "textEdit1";
                        this.textEdit1.Properties.AutoHeight = false;
                        this.textEdit1.Size = new System.Drawing.Size(279, 26);
                        this.textEdit1.TabIndex = 0;
                        // 
                        // SinoUC_IM_Text
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.textEdit1);
                        this.Name = "SinoUC_IM_Text";
                        this.Size = new System.Drawing.Size(279, 26);
                        ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                protected DevExpress.XtraEditors.TextEdit textEdit1;

        }
}
