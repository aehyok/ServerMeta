namespace SinoSZMetaDataQuery.InputModel
{
        partial class SinoUC_IM_Date
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
                        this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
                        ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // textEdit1
                        // 
                        this.textEdit1.Dock = System.Windows.Forms.DockStyle.None;
                        this.textEdit1.Location = new System.Drawing.Point(81, 9);
                        this.textEdit1.Visible = false;
                        // 
                        // dateEdit1
                        // 
                        this.dateEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.dateEdit1.EditValue = null;
                        this.dateEdit1.Location = new System.Drawing.Point(0, 0);
                        this.dateEdit1.Margin = new System.Windows.Forms.Padding(0);
                        this.dateEdit1.Name = "dateEdit1";
                        this.dateEdit1.Properties.AutoHeight = false;
                        this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
                        this.dateEdit1.Size = new System.Drawing.Size(279, 26);
                        this.dateEdit1.TabIndex = 1;
                        // 
                        // SinoUC_IM_Date
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.Controls.Add(this.dateEdit1);
                        this.Name = "SinoUC_IM_Date";
                        this.Controls.SetChildIndex(this.textEdit1, 0);
                        this.Controls.SetChildIndex(this.dateEdit1, 0);
                        ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.DateEdit dateEdit1;
        }
}
