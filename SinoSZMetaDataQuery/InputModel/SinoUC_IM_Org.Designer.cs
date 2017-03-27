namespace SinoSZMetaDataQuery.InputModel
{
        partial class SinoUC_IM_Org
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
                        this.sinoUC_OrgComboBox1 = new SinoSZClientBase.Organize.SinoUC_OrgComboBox();
                        ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.sinoUC_OrgComboBox1.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // textEdit1
                        // 
                        this.textEdit1.Dock = System.Windows.Forms.DockStyle.None;
                        this.textEdit1.Location = new System.Drawing.Point(61, 0);
                        // 
                        // sinoUC_OrgComboBox1
                        // 
                        this.sinoUC_OrgComboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.sinoUC_OrgComboBox1.DWDM = "";
                        this.sinoUC_OrgComboBox1.FullName = "";
                        this.sinoUC_OrgComboBox1.Location = new System.Drawing.Point(0, 0);
                        this.sinoUC_OrgComboBox1.Name = "sinoUC_OrgComboBox1";
                        this.sinoUC_OrgComboBox1.OrgItem = null;
                        this.sinoUC_OrgComboBox1.Properties.AllowFocused = false;
                        this.sinoUC_OrgComboBox1.Properties.Appearance.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.sinoUC_OrgComboBox1.Properties.Appearance.Options.UseFont = true;
                        this.sinoUC_OrgComboBox1.Properties.Appearance.Options.UseTextOptions = true;
                        this.sinoUC_OrgComboBox1.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
                        this.sinoUC_OrgComboBox1.Properties.AutoHeight = false;
                        this.sinoUC_OrgComboBox1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.sinoUC_OrgComboBox1.Properties.Name = "_properties";
                        this.sinoUC_OrgComboBox1.ReadOnly = false;
                        this.sinoUC_OrgComboBox1.Size = new System.Drawing.Size(279, 26);
                        this.sinoUC_OrgComboBox1.TabIndex = 1;
                        // 
                        // SinoUC_IM_Org
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.Controls.Add(this.sinoUC_OrgComboBox1);
                        this.Name = "SinoUC_IM_Org";
                        this.Controls.SetChildIndex(this.textEdit1, 0);
                        this.Controls.SetChildIndex(this.sinoUC_OrgComboBox1, 0);
                        ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.sinoUC_OrgComboBox1.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private SinoSZClientBase.Organize.SinoUC_OrgComboBox sinoUC_OrgComboBox1;
        }
}
