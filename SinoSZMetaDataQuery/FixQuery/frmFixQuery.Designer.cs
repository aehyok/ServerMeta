namespace SinoSZMetaDataQuery.FixQuery
{
        partial class frmFixQuery
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
                        this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
                        this.checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
                        this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
                        this.sinoSZUC_FixConditionPanel1 = new SinoSZMetaDataQuery.Common.SinoSZUC_FixConditionPanel();
                        this.tableLayoutPanel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
                        this.groupControl2.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
                        this.groupControl1.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // tableLayoutPanel1
                        // 
                        this.tableLayoutPanel1.ColumnCount = 1;
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tableLayoutPanel1.Controls.Add(this.groupControl2, 0, 1);
                        this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
                        this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.tableLayoutPanel1.Location = new System.Drawing.Point(100, 60);
                        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
                        this.tableLayoutPanel1.RowCount = 2;
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
                        this.tableLayoutPanel1.Size = new System.Drawing.Size(647, 355);
                        this.tableLayoutPanel1.TabIndex = 0;
                        // 
                        // groupControl2
                        // 
                        this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.groupControl2.Controls.Add(this.checkedListBoxControl1);
                        this.groupControl2.Location = new System.Drawing.Point(10, 240);
                        this.groupControl2.Margin = new System.Windows.Forms.Padding(10, 5, 10, 10);
                        this.groupControl2.Name = "groupControl2";
                        this.groupControl2.Size = new System.Drawing.Size(627, 105);
                        this.groupControl2.TabIndex = 1;
                        this.groupControl2.Text = "关联信息设置";
                        // 
                        // checkedListBoxControl1
                        // 
                        this.checkedListBoxControl1.CheckOnClick = true;
                        this.checkedListBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.checkedListBoxControl1.Location = new System.Drawing.Point(2, 21);
                        this.checkedListBoxControl1.MultiColumn = true;
                        this.checkedListBoxControl1.Name = "checkedListBoxControl1";
                        this.checkedListBoxControl1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
                        this.checkedListBoxControl1.Size = new System.Drawing.Size(623, 82);
                        this.checkedListBoxControl1.TabIndex = 0;
                        // 
                        // groupControl1
                        // 
                        this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.groupControl1.Controls.Add(this.sinoSZUC_FixConditionPanel1);
                        this.groupControl1.Location = new System.Drawing.Point(10, 10);
                        this.groupControl1.Margin = new System.Windows.Forms.Padding(10, 10, 10, 5);
                        this.groupControl1.Name = "groupControl1";
                        this.groupControl1.Size = new System.Drawing.Size(627, 220);
                        this.groupControl1.TabIndex = 0;
                        this.groupControl1.Text = "查询条件设置";
                        // 
                        // sinoSZUC_FixConditionPanel1
                        // 
                        this.sinoSZUC_FixConditionPanel1.BackColor = System.Drawing.Color.Transparent;
                        this.sinoSZUC_FixConditionPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.sinoSZUC_FixConditionPanel1.Location = new System.Drawing.Point(2, 21);
                        this.sinoSZUC_FixConditionPanel1.Name = "sinoSZUC_FixConditionPanel1";
                        this.sinoSZUC_FixConditionPanel1.Size = new System.Drawing.Size(623, 197);
                        this.sinoSZUC_FixConditionPanel1.TabIndex = 0;
                        // 
                        // frmFixQuery
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(847, 475);
                        this.Controls.Add(this.tableLayoutPanel1);
                        this.Name = "frmFixQuery";
                        this.Padding = new System.Windows.Forms.Padding(100, 60, 100, 60);
                        this.Text = "frmFixQuery";
                        this.tableLayoutPanel1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
                        this.groupControl2.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
                        this.groupControl1.ResumeLayout(false);
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
                private DevExpress.XtraEditors.GroupControl groupControl2;
                private DevExpress.XtraEditors.GroupControl groupControl1;
                private SinoSZMetaDataQuery.Common.SinoSZUC_FixConditionPanel sinoSZUC_FixConditionPanel1;
                private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl1;
        }
}