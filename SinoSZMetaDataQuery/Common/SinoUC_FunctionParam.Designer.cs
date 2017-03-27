namespace SinoSZMetaDataQuery.Common
{
        partial class SinoUC_FunctionParam
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
                        this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
                        ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // label1
                        // 
                        this.label1.Dock = System.Windows.Forms.DockStyle.Left;
                        this.label1.Location = new System.Drawing.Point(0, 2);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(68, 24);
                        this.label1.TabIndex = 0;
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // comboBoxEdit1
                        // 
                        this.comboBoxEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.comboBoxEdit1.Location = new System.Drawing.Point(68, 2);
                        this.comboBoxEdit1.Name = "comboBoxEdit1";
                        this.comboBoxEdit1.Properties.AutoHeight = false;
                        this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.comboBoxEdit1.Size = new System.Drawing.Size(164, 24);
                        this.comboBoxEdit1.TabIndex = 1;
                        // 
                        // SinoUC_FunctionParam
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.comboBoxEdit1);
                        this.Controls.Add(this.label1);
                        this.Name = "SinoUC_FunctionParam";
                        this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
                        this.Size = new System.Drawing.Size(232, 28);
                        ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.Label label1;
                private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        }
}
