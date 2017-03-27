namespace SinoSZMetaDataQuery.GuideLineQuery
{
        partial class SinoSZUC_GLQD_InputItem
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
                        this.te_ColName = new System.Windows.Forms.Label();
                        this.te_Value = new DevExpress.XtraEditors.ButtonEdit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_Value.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // te_ColName
                        // 
                        this.te_ColName.AutoSize = true;
                        this.te_ColName.Dock = System.Windows.Forms.DockStyle.Left;
                        this.te_ColName.Location = new System.Drawing.Point(2, 1);
                        this.te_ColName.Name = "te_ColName";
                        this.te_ColName.Size = new System.Drawing.Size(0, 12);
                        this.te_ColName.TabIndex = 0;
                        this.te_ColName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // te_Value
                        // 
                        this.te_Value.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.te_Value.Location = new System.Drawing.Point(2, 1);
                        this.te_Value.Name = "te_Value";
                        this.te_Value.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
                        this.te_Value.Properties.Appearance.Options.UseForeColor = true;
                        this.te_Value.Properties.AutoHeight = false;
                        this.te_Value.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
                        this.te_Value.Size = new System.Drawing.Size(511, 22);
                        this.te_Value.TabIndex = 14;
                        this.te_Value.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.te_Value_ButtonClick);
                        this.te_Value.EditValueChanged += new System.EventHandler(this.te_Value_EditValueChanged);
                        // 
                        // SinoSZUC_GLQD_InputItem
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.BackColor = System.Drawing.Color.Transparent;
                        this.Controls.Add(this.te_Value);
                        this.Controls.Add(this.te_ColName);
                        this.Name = "SinoSZUC_GLQD_InputItem";
                        this.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
                        this.Size = new System.Drawing.Size(515, 24);
                        ((System.ComponentModel.ISupportInitialize)(this.te_Value.Properties)).EndInit();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private System.Windows.Forms.Label te_ColName;
                protected DevExpress.XtraEditors.ButtonEdit te_Value;
        }
}
