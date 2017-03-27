namespace SinoSZClientReport.DataCheck
{
        partial class Dialog_AddRule
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bt_Del = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.sinoSZUC_MD_Model_FieldList1 = new SinoSZMetaDataQuery.Common.SinoSZUC_MD_Model_FieldList();
            this.sinoSZUC_ConditionPanel1 = new SinoSZMetaDataQuery.Common.SinoSZUC_ConditionPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.simpleButton3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(6, 555);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(879, 51);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bt_Del);
            this.panel2.Controls.Add(this.simpleButton2);
            this.panel2.Controls.Add(this.simpleButton1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(495, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(384, 51);
            this.panel2.TabIndex = 0;
            // 
            // bt_Del
            // 
            this.bt_Del.Location = new System.Drawing.Point(148, 13);
            this.bt_Del.Name = "bt_Del";
            this.bt_Del.Size = new System.Drawing.Size(86, 27);
            this.bt_Del.TabIndex = 2;
            this.bt_Del.Text = "删除条件";
            this.bt_Del.Click += new System.EventHandler(this.bt_Del_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(241, 13);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(63, 27);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "确定";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(311, 13);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(63, 27);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "取消";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(6, 5);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.sinoSZUC_MD_Model_FieldList1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.sinoSZUC_ConditionPanel1);
            this.splitContainerControl1.Panel2.Controls.Add(this.panel3);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(879, 550);
            this.splitContainerControl1.SplitterPosition = 231;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // sinoSZUC_MD_Model_FieldList1
            // 
            this.sinoSZUC_MD_Model_FieldList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sinoSZUC_MD_Model_FieldList1.Location = new System.Drawing.Point(0, 0);
            this.sinoSZUC_MD_Model_FieldList1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sinoSZUC_MD_Model_FieldList1.Name = "sinoSZUC_MD_Model_FieldList1";
            this.sinoSZUC_MD_Model_FieldList1.QueryModel = null;
            this.sinoSZUC_MD_Model_FieldList1.QueryViewName = "";
            this.sinoSZUC_MD_Model_FieldList1.Size = new System.Drawing.Size(231, 550);
            this.sinoSZUC_MD_Model_FieldList1.TabIndex = 0;
            this.sinoSZUC_MD_Model_FieldList1.FieldSelected += new System.EventHandler<SinoSZMetaDataQuery.Common.FieldSelectEventArgs>(this.sinoSZUC_MD_Model_FieldList1_FieldSelected);
            // 
            // sinoSZUC_ConditionPanel1
            // 
            this.sinoSZUC_ConditionPanel1.BackColor = System.Drawing.Color.Transparent;
            this.sinoSZUC_ConditionPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sinoSZUC_ConditionPanel1.Location = new System.Drawing.Point(0, 33);
            this.sinoSZUC_ConditionPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sinoSZUC_ConditionPanel1.Name = "sinoSZUC_ConditionPanel1";
            this.sinoSZUC_ConditionPanel1.Size = new System.Drawing.Size(643, 517);
            this.sinoSZUC_ConditionPanel1.TabIndex = 1;
            this.sinoSZUC_ConditionPanel1.MenuChanged += new System.EventHandler<System.EventArgs>(this.sinoSZUC_ConditionPanel1_MenuChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.textEdit1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panel3.Size = new System.Drawing.Size(643, 33);
            this.panel3.TabIndex = 0;
            // 
            // textEdit1
            // 
            this.textEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEdit1.Location = new System.Drawing.Point(71, 3);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.AutoHeight = false;
            this.textEdit1.Size = new System.Drawing.Size(572, 27);
            this.textEdit1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "规则名称";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(3, 13);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(125, 27);
            this.simpleButton3.TabIndex = 3;
            this.simpleButton3.Text = "添加计算项字段";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // Dialog_AddRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 611);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panel1);
            this.Name = "Dialog_AddRule";
            this.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加规则";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.Panel panel1;
                private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
                private System.Windows.Forms.Panel panel2;
                private System.Windows.Forms.Panel panel3;
                private System.Windows.Forms.Label label1;
                protected DevExpress.XtraEditors.SimpleButton simpleButton2;
                protected DevExpress.XtraEditors.SimpleButton simpleButton1;
                protected DevExpress.XtraEditors.TextEdit textEdit1;
                protected SinoSZMetaDataQuery.Common.SinoSZUC_MD_Model_FieldList sinoSZUC_MD_Model_FieldList1;
                protected SinoSZMetaDataQuery.Common.SinoSZUC_ConditionPanel sinoSZUC_ConditionPanel1;
                protected DevExpress.XtraEditors.SimpleButton bt_Del;
                protected DevExpress.XtraEditors.SimpleButton simpleButton3;
        }
}