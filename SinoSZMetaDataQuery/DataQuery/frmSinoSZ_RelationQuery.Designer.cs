namespace SinoSZMetaDataQuery.DataQuery
{
        partial class frmSinoSZ_RelationQuery
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
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.sinoSZUC_ConditionPanel1 = new SinoSZMetaDataQuery.Common.SinoSZUC_ConditionPanel();
            this.sinoSZUC_MD_Model_FieldList1 = new SinoSZMetaDataQuery.Common.SinoSZUC_MD_Model_FieldList();
            this.SuspendLayout();
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(506, 9);
            this.splitterControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 748);
            this.splitterControl1.TabIndex = 2;
            this.splitterControl1.TabStop = false;
            // 
            // sinoSZUC_ConditionPanel1
            // 
            this.sinoSZUC_ConditionPanel1.BackColor = System.Drawing.Color.Transparent;
            this.sinoSZUC_ConditionPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sinoSZUC_ConditionPanel1.Location = new System.Drawing.Point(511, 9);
            this.sinoSZUC_ConditionPanel1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.sinoSZUC_ConditionPanel1.Name = "sinoSZUC_ConditionPanel1";
            this.sinoSZUC_ConditionPanel1.Size = new System.Drawing.Size(565, 748);
            this.sinoSZUC_ConditionPanel1.TabIndex = 1;
            // 
            // sinoSZUC_MD_Model_FieldList1
            // 
            this.sinoSZUC_MD_Model_FieldList1.Dock = System.Windows.Forms.DockStyle.Left;
            this.sinoSZUC_MD_Model_FieldList1.Location = new System.Drawing.Point(7, 9);
            this.sinoSZUC_MD_Model_FieldList1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.sinoSZUC_MD_Model_FieldList1.Name = "sinoSZUC_MD_Model_FieldList1";
            this.sinoSZUC_MD_Model_FieldList1.QueryModel = null;
            this.sinoSZUC_MD_Model_FieldList1.QueryViewName = "";
            this.sinoSZUC_MD_Model_FieldList1.Size = new System.Drawing.Size(499, 748);
            this.sinoSZUC_MD_Model_FieldList1.TabIndex = 0;
            this.sinoSZUC_MD_Model_FieldList1.MenuChanged += new System.EventHandler<System.EventArgs>(this.sinoSZUC_MD_Model_FieldList1_MenuChanged);
            // 
            // frmSinoSZ_RelationQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 766);
            this.Controls.Add(this.sinoSZUC_ConditionPanel1);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.sinoSZUC_MD_Model_FieldList1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmSinoSZ_RelationQuery";
            this.Padding = new System.Windows.Forms.Padding(7, 9, 7, 9);
            this.Text = "综合查询";
            this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.SplitterControl splitterControl1;
                protected SinoSZMetaDataQuery.Common.SinoSZUC_MD_Model_FieldList sinoSZUC_MD_Model_FieldList1;
                protected SinoSZMetaDataQuery.Common.SinoSZUC_ConditionPanel sinoSZUC_ConditionPanel1;
        }
}