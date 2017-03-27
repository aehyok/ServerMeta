namespace SinoSZMetaDataQuery.Common
{
        partial class SinoSZUC_ChildRecordIndex
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
                        this.components = new System.ComponentModel.Container();
                        DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
                        this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
                        this.linkLabel1 = new System.Windows.Forms.LinkLabel();
                        this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
                        ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // checkEdit1
                        // 
                        this.checkEdit1.Dock = System.Windows.Forms.DockStyle.Left;
                        this.checkEdit1.Location = new System.Drawing.Point(0, 3);
                        this.checkEdit1.Name = "checkEdit1";
                        this.checkEdit1.Properties.Caption = "";
                        this.checkEdit1.Size = new System.Drawing.Size(16, 19);
                        this.checkEdit1.TabIndex = 0;
                        this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
                        // 
                        // linkLabel1
                        // 
                        this.linkLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.linkLabel1.Location = new System.Drawing.Point(16, 3);
                        this.linkLabel1.Name = "linkLabel1";
                        this.linkLabel1.Size = new System.Drawing.Size(192, 22);
                        this.toolTipController1.SetSuperTip(this.linkLabel1, superToolTip1);
                        this.linkLabel1.TabIndex = 1;
                        this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
                        // 
                        // toolTipController1
                        // 
                        this.toolTipController1.AutoPopDelay = 1000;
                        // 
                        // SinoSZUC_ChildRecordIndex
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.BackColor = System.Drawing.Color.Transparent;
                        this.Controls.Add(this.linkLabel1);
                        this.Controls.Add(this.checkEdit1);
                        this.Name = "SinoSZUC_ChildRecordIndex";
                        this.Padding = new System.Windows.Forms.Padding(0, 3, 3, 3);
                        this.Size = new System.Drawing.Size(211, 28);
                        this.toolTipController1.SetSuperTip(this, null);
                        ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.CheckEdit checkEdit1;
                private System.Windows.Forms.LinkLabel linkLabel1;
                private DevExpress.Utils.ToolTipController toolTipController1;
        }
}
