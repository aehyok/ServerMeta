namespace SinoSZClientSysManager.TaskManager
{
        partial class TaskParameterInput
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
                        this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
                        this.LB_TITLE = new System.Windows.Forms.Label();
                        this.TE_VALUE = new DevExpress.XtraEditors.TextEdit();
                        this.tableLayoutPanel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.TE_VALUE.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // tableLayoutPanel1
                        // 
                        this.tableLayoutPanel1.ColumnCount = 2;
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tableLayoutPanel1.Controls.Add(this.LB_TITLE, 0, 0);
                        this.tableLayoutPanel1.Controls.Add(this.TE_VALUE, 1, 0);
                        this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
                        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
                        this.tableLayoutPanel1.RowCount = 1;
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                        this.tableLayoutPanel1.Size = new System.Drawing.Size(708, 26);
                        this.tableLayoutPanel1.TabIndex = 0;
                        // 
                        // LB_TITLE
                        // 
                        this.LB_TITLE.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.LB_TITLE.Location = new System.Drawing.Point(3, 0);
                        this.LB_TITLE.Name = "LB_TITLE";
                        this.LB_TITLE.Size = new System.Drawing.Size(194, 26);
                        this.LB_TITLE.TabIndex = 0;
                        this.LB_TITLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // TE_VALUE
                        // 
                        this.TE_VALUE.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.TE_VALUE.Location = new System.Drawing.Point(203, 3);
                        this.TE_VALUE.Name = "TE_VALUE";
                        this.TE_VALUE.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
                        this.TE_VALUE.Properties.Appearance.Options.UseForeColor = true;
                        this.TE_VALUE.Size = new System.Drawing.Size(502, 21);
                        this.TE_VALUE.TabIndex = 1;
                        this.TE_VALUE.EditValueChanged += new System.EventHandler(this.TE_VALUE_EditValueChanged);
                        // 
                        // TaskParameterInput
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.tableLayoutPanel1);
                        this.Name = "TaskParameterInput";
                        this.Padding = new System.Windows.Forms.Padding(2);
                        this.Size = new System.Drawing.Size(712, 30);
                        this.tableLayoutPanel1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.TE_VALUE.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
                private System.Windows.Forms.Label LB_TITLE;
                private DevExpress.XtraEditors.TextEdit TE_VALUE;
        }
}
