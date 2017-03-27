namespace SinoSZMetaDataManager
{
        partial class ViewGuideLineManager
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
                        this.uC_View2GLInfo1 = new SinoSZMetaDataManager.UC_View2GLInfo();
                        this.SuspendLayout();
                        // 
                        // uC_View2GLInfo1
                        // 
                        this.uC_View2GLInfo1.DisplayOrder = 0;
                        this.uC_View2GLInfo1.DisplayTitle = "";
                        this.uC_View2GLInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.uC_View2GLInfo1.GuideLineID = "";
                        this.uC_View2GLInfo1.Location = new System.Drawing.Point(0, 0);
                        this.uC_View2GLInfo1.Name = "uC_View2GLInfo1";
                        this.uC_View2GLInfo1.Size = new System.Drawing.Size(691, 524);
                        this.uC_View2GLInfo1.TabIndex = 10;
                        this.uC_View2GLInfo1.V2GID = "";
                        this.uC_View2GLInfo1.DataChanged += new System.EventHandler<System.EventArgs>(this.uC_View2GLInfo1_DataChanged);
                        // 
                        // ViewGuideLineManager
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.uC_View2GLInfo1);
                        this.Name = "ViewGuideLineManager";
                        this.Size = new System.Drawing.Size(691, 524);
                        this.ResumeLayout(false);

                }

                #endregion

                private UC_View2GLInfo uC_View2GLInfo1;
        }
}
