namespace SinoSZMetaDataQuery.InputModel
{
        partial class SinoUC_IM_RefTable
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
                        this.refCodeBox1 = new SinoSZClientBase.RefCode.RefCodeBox();
                        ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.refCodeBox1.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // textEdit1
                        // 
                        this.textEdit1.Dock = System.Windows.Forms.DockStyle.None;
                        this.textEdit1.Location = new System.Drawing.Point(109, 0);
                        // 
                        // refCodeBox1
                        // 
                        this.refCodeBox1.CanEdit = false;
                        this.refCodeBox1.CanMultiSelect = false;
                        this.refCodeBox1.Code = "";
                        this.refCodeBox1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.refCodeBox1.Location = new System.Drawing.Point(0, 0);
                        this.refCodeBox1.Name = "refCodeBox1";
                        this.refCodeBox1.Properties.AllowFocused = false;
                        this.refCodeBox1.Properties.Appearance.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.refCodeBox1.Properties.Appearance.Options.UseFont = true;
                        this.refCodeBox1.Properties.Appearance.Options.UseTextOptions = true;
                        this.refCodeBox1.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
                        this.refCodeBox1.Properties.AutoHeight = false;
                        this.refCodeBox1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.refCodeBox1.Properties.Name = "_properties";
                        this.refCodeBox1.ReadOnly = false;
                        this.refCodeBox1.RefTableName = "";
                        this.refCodeBox1.Size = new System.Drawing.Size(279, 26);
                        this.refCodeBox1.TabIndex = 1;
                        // 
                        // SinoUC_IM_RefTable
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.Controls.Add(this.refCodeBox1);
                        this.Name = "SinoUC_IM_RefTable";
                        this.Controls.SetChildIndex(this.textEdit1, 0);
                        this.Controls.SetChildIndex(this.refCodeBox1, 0);
                        ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.refCodeBox1.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private SinoSZClientBase.RefCode.RefCodeBox refCodeBox1;
        }
}
