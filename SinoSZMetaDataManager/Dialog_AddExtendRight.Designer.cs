namespace SinoSZMetaDataManager
{
        partial class Dialog_AddExtendRight
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
                        this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
                        this.button1 = new System.Windows.Forms.Button();
                        this.button2 = new System.Windows.Forms.Button();
                        this.label1 = new System.Windows.Forms.Label();
                        this.label2 = new System.Windows.Forms.Label();
                        this.te_value = new DevExpress.XtraEditors.TextEdit();
                        this.te_title = new DevExpress.XtraEditors.TextEdit();
                        this.tableLayoutPanel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.te_value.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_title.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // tableLayoutPanel1
                        // 
                        this.tableLayoutPanel1.ColumnCount = 4;
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
                        this.tableLayoutPanel1.Controls.Add(this.te_title, 1, 1);
                        this.tableLayoutPanel1.Controls.Add(this.button1, 2, 3);
                        this.tableLayoutPanel1.Controls.Add(this.button2, 3, 3);
                        this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
                        this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
                        this.tableLayoutPanel1.Controls.Add(this.te_value, 1, 0);
                        this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
                        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
                        this.tableLayoutPanel1.RowCount = 4;
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                        this.tableLayoutPanel1.Size = new System.Drawing.Size(431, 104);
                        this.tableLayoutPanel1.TabIndex = 0;
                        // 
                        // button1
                        // 
                        this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.button1.Location = new System.Drawing.Point(314, 77);
                        this.button1.Name = "button1";
                        this.button1.Size = new System.Drawing.Size(54, 24);
                        this.button1.TabIndex = 0;
                        this.button1.Text = "确定";
                        this.button1.UseVisualStyleBackColor = true;
                        this.button1.Click += new System.EventHandler(this.button1_Click);
                        // 
                        // button2
                        // 
                        this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.button2.Location = new System.Drawing.Point(374, 77);
                        this.button2.Name = "button2";
                        this.button2.Size = new System.Drawing.Size(54, 24);
                        this.button2.TabIndex = 1;
                        this.button2.Text = "取消";
                        this.button2.UseVisualStyleBackColor = true;
                        this.button2.Click += new System.EventHandler(this.button2_Click);
                        // 
                        // label1
                        // 
                        this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.label1.AutoSize = true;
                        this.label1.Location = new System.Drawing.Point(3, 8);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(94, 14);
                        this.label1.TabIndex = 2;
                        this.label1.Text = "权限值";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // label2
                        // 
                        this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.label2.AutoSize = true;
                        this.label2.Location = new System.Drawing.Point(3, 38);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(94, 14);
                        this.label2.TabIndex = 3;
                        this.label2.Text = "权限显示名称";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // te_value
                        // 
                        this.te_value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.tableLayoutPanel1.SetColumnSpan(this.te_value, 3);
                        this.te_value.Location = new System.Drawing.Point(103, 4);
                        this.te_value.Name = "te_value";
                        this.te_value.Size = new System.Drawing.Size(325, 21);
                        this.te_value.TabIndex = 4;
                        // 
                        // te_title
                        // 
                        this.te_title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        this.tableLayoutPanel1.SetColumnSpan(this.te_title, 3);
                        this.te_title.Location = new System.Drawing.Point(103, 34);
                        this.te_title.Name = "te_title";
                        this.te_title.Size = new System.Drawing.Size(325, 21);
                        this.te_title.TabIndex = 5;
                        // 
                        // Dialog_AddExtendRight
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(441, 114);
                        this.Controls.Add(this.tableLayoutPanel1);
                        this.Name = "Dialog_AddExtendRight";
                        this.Padding = new System.Windows.Forms.Padding(5);
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "添加模型的扩展权限";
                        this.tableLayoutPanel1.ResumeLayout(false);
                        this.tableLayoutPanel1.PerformLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.te_value.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_title.Properties)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
                private System.Windows.Forms.Button button1;
                private System.Windows.Forms.Button button2;
                private System.Windows.Forms.Label label1;
                private System.Windows.Forms.Label label2;
                private DevExpress.XtraEditors.TextEdit te_value;
                private DevExpress.XtraEditors.TextEdit te_title;
        }
}