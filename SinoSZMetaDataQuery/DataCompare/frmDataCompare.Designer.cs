namespace SinoSZMetaDataQuery.DataCompare
{
        partial class frmDataCompare
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
			this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.sinoSZUC_MD_Model_FieldList1 = new SinoSZMetaDataQuery.Common.SinoSZUC_MD_Model_FieldList();
			this.sinoSZUC_CompareConditionPanel1 = new SinoSZMetaDataQuery.Common.SinoSZUC_CompareConditionPanel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
			this.panel1 = new System.Windows.Forms.Panel();
			this.buttonEdit1 = new DevExpress.XtraEditors.ButtonEdit();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
			this.splitContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
			this.groupControl2.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainerControl1
			// 
			this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
			this.splitContainerControl1.Name = "splitContainerControl1";
			this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
			this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(5);
			this.splitContainerControl1.Panel1.Text = "Panel1";
			this.splitContainerControl1.Panel2.Controls.Add(this.sinoSZUC_CompareConditionPanel1);
			this.splitContainerControl1.Panel2.Controls.Add(this.panel2);
			this.splitContainerControl1.Panel2.Controls.Add(this.groupControl2);
			this.splitContainerControl1.Panel2.Padding = new System.Windows.Forms.Padding(5);
			this.splitContainerControl1.Panel2.Text = "Panel2";
			this.splitContainerControl1.Size = new System.Drawing.Size(929, 532);
			this.splitContainerControl1.SplitterPosition = 312;
			this.splitContainerControl1.TabIndex = 0;
			this.splitContainerControl1.Text = "splitContainerControl1";
			// 
			// groupControl1
			// 
			this.groupControl1.Controls.Add(this.sinoSZUC_MD_Model_FieldList1);
			this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl1.Location = new System.Drawing.Point(5, 4);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Padding = new System.Windows.Forms.Padding(5);
			this.groupControl1.Size = new System.Drawing.Size(298, 519);
			this.groupControl1.TabIndex = 0;
			this.groupControl1.Text = "比对数据";
			// 
			// sinoSZUC_MD_Model_FieldList1
			// 
			this.sinoSZUC_MD_Model_FieldList1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sinoSZUC_MD_Model_FieldList1.Location = new System.Drawing.Point(5, 24);
			this.sinoSZUC_MD_Model_FieldList1.Name = "sinoSZUC_MD_Model_FieldList1";
			this.sinoSZUC_MD_Model_FieldList1.QueryModel = null;
			this.sinoSZUC_MD_Model_FieldList1.QueryViewName = "";
			this.sinoSZUC_MD_Model_FieldList1.Size = new System.Drawing.Size(288, 490);
			this.sinoSZUC_MD_Model_FieldList1.TabIndex = 1;
			// 
			// sinoSZUC_CompareConditionPanel1
			// 
			this.sinoSZUC_CompareConditionPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sinoSZUC_CompareConditionPanel1.Location = new System.Drawing.Point(5, 77);
			this.sinoSZUC_CompareConditionPanel1.Name = "sinoSZUC_CompareConditionPanel1";
			this.sinoSZUC_CompareConditionPanel1.Size = new System.Drawing.Size(597, 446);
			this.sinoSZUC_CompareConditionPanel1.TabIndex = 1;
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(5, 65);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(597, 12);
			this.panel2.TabIndex = 2;
			// 
			// groupControl2
			// 
			this.groupControl2.Controls.Add(this.panel1);
			this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl2.Location = new System.Drawing.Point(5, 4);
			this.groupControl2.Name = "groupControl2";
			this.groupControl2.Padding = new System.Windows.Forms.Padding(5);
			this.groupControl2.Size = new System.Drawing.Size(597, 61);
			this.groupControl2.TabIndex = 0;
			this.groupControl2.Text = "比对文件";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.buttonEdit1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(5, 24);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(3);
			this.panel1.Size = new System.Drawing.Size(587, 28);
			this.panel1.TabIndex = 0;
			// 
			// buttonEdit1
			// 
			this.buttonEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonEdit1.Location = new System.Drawing.Point(71, 3);
			this.buttonEdit1.Name = "buttonEdit1";
			this.buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.buttonEdit1.Size = new System.Drawing.Size(513, 21);
			this.buttonEdit1.TabIndex = 1;
			this.buttonEdit1.Click += new System.EventHandler(this.buttonEdit1_Click);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 22);
			this.label1.TabIndex = 0;
			this.label1.Text = "比对文件";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frmDataCompare
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(929, 532);
			this.Controls.Add(this.splitContainerControl1);
			this.Name = "frmDataCompare";
			this.Text = "数据比对";
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
			this.splitContainerControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
			this.groupControl2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).EndInit();
			this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
                private DevExpress.XtraEditors.GroupControl groupControl1;
                private SinoSZMetaDataQuery.Common.SinoSZUC_MD_Model_FieldList sinoSZUC_MD_Model_FieldList1;
                private DevExpress.XtraEditors.GroupControl groupControl2;
                private System.Windows.Forms.Panel panel1;
                private DevExpress.XtraEditors.ButtonEdit buttonEdit1;
                private System.Windows.Forms.Label label1;
                private SinoSZMetaDataQuery.Common.SinoSZUC_CompareConditionPanel sinoSZUC_CompareConditionPanel1;
                private System.Windows.Forms.Panel panel2;
        }
}