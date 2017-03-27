namespace SinoSZMetaDataQuery.DataQuery
{
        partial class Dialog_TaskInfo
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
                        this.label1 = new System.Windows.Forms.Label();
                        this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
                        this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
                        this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
                        ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // label1
                        // 
                        this.label1.AutoSize = true;
                        this.label1.Location = new System.Drawing.Point(24, 26);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(55, 14);
                        this.label1.TabIndex = 0;
                        this.label1.Text = "任务说明";
                        // 
                        // memoEdit1
                        // 
                        this.memoEdit1.Location = new System.Drawing.Point(85, 23);
                        this.memoEdit1.Name = "memoEdit1";
                        this.memoEdit1.Size = new System.Drawing.Size(330, 108);
                        this.memoEdit1.TabIndex = 1;
                        // 
                        // simpleButton1
                        // 
                        this.simpleButton1.Location = new System.Drawing.Point(355, 145);
                        this.simpleButton1.Name = "simpleButton1";
                        this.simpleButton1.Size = new System.Drawing.Size(60, 23);
                        this.simpleButton1.TabIndex = 2;
                        this.simpleButton1.Text = "取消";
                        this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
                        // 
                        // simpleButton2
                        // 
                        this.simpleButton2.Location = new System.Drawing.Point(285, 145);
                        this.simpleButton2.Name = "simpleButton2";
                        this.simpleButton2.Size = new System.Drawing.Size(64, 23);
                        this.simpleButton2.TabIndex = 3;
                        this.simpleButton2.Text = "加入任务";
                        this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
                        // 
                        // Dialog_TaskInfo
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(438, 184);
                        this.Controls.Add(this.simpleButton2);
                        this.Controls.Add(this.simpleButton1);
                        this.Controls.Add(this.memoEdit1);
                        this.Controls.Add(this.label1);
                        this.Name = "Dialog_TaskInfo";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "添加查询任务";
                        ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private System.Windows.Forms.Label label1;
                private DevExpress.XtraEditors.MemoEdit memoEdit1;
                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private DevExpress.XtraEditors.SimpleButton simpleButton2;
        }
}