namespace SinoSZMetaDataQuery.GuideLineQuery
{
        partial class SinoSZUC_GLQ_InputItem
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
                        this.te_Value = new DevExpress.XtraEditors.ButtonEdit();
                        this.panel2 = new System.Windows.Forms.Panel();
                        this.teColName = new DevExpress.XtraEditors.TextEdit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_Value.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.teColName.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // te_Value
                        // 
                        this.te_Value.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.te_Value.Location = new System.Drawing.Point(207, 1);
                        this.te_Value.Name = "te_Value";
                        this.te_Value.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
                        this.te_Value.Properties.Appearance.Options.UseForeColor = true;
                        this.te_Value.Properties.AutoHeight = false;
                        this.te_Value.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
                        this.te_Value.Size = new System.Drawing.Size(243, 22);
                        this.te_Value.TabIndex = 13;
                        this.te_Value.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.te_Value_ButtonClick);
                        this.te_Value.EditValueChanged += new System.EventHandler(this.te_Value_EditValueChanged);
                        this.te_Value.Leave += new System.EventHandler(this.te_Value_Leave);
                        this.te_Value.Enter += new System.EventHandler(this.te_Value_Enter);
                        // 
                        // panel2
                        // 
                        this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
                        this.panel2.Location = new System.Drawing.Point(205, 1);
                        this.panel2.Name = "panel2";
                        this.panel2.Size = new System.Drawing.Size(2, 22);
                        this.panel2.TabIndex = 12;
                        // 
                        // teColName
                        // 
                        this.teColName.Dock = System.Windows.Forms.DockStyle.Left;
                        this.teColName.Location = new System.Drawing.Point(0, 1);
                        this.teColName.Name = "teColName";
                        this.teColName.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
                        this.teColName.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
                        this.teColName.Properties.Appearance.Options.UseBackColor = true;
                        this.teColName.Properties.Appearance.Options.UseForeColor = true;
                        this.teColName.Properties.AutoHeight = false;
                        this.teColName.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
                        this.teColName.Properties.ReadOnly = true;
                        this.teColName.Size = new System.Drawing.Size(205, 22);
                        this.teColName.TabIndex = 11;
                        // 
                        // SinoSZUC_GLQ_InputItem
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.BackColor = System.Drawing.Color.Transparent;
                        this.Controls.Add(this.te_Value);
                        this.Controls.Add(this.panel2);
                        this.Controls.Add(this.teColName);
                        this.Name = "SinoSZUC_GLQ_InputItem";
                        this.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
                        this.Size = new System.Drawing.Size(450, 24);
                        ((System.ComponentModel.ISupportInitialize)(this.te_Value.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.teColName.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                protected DevExpress.XtraEditors.ButtonEdit te_Value;
                private System.Windows.Forms.Panel panel2;
                protected DevExpress.XtraEditors.TextEdit teColName;
        }
}
