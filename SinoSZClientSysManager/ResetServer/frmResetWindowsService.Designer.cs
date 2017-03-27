namespace SinoSZClientSysManager.ResetServer
{
    partial class frmResetWindowsService
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ServiceName = new System.Windows.Forms.TextBox();
            this.txt_ServiceState = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前服务名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "当前服务状态";
            // 
            // txt_ServiceName
            // 
            this.txt_ServiceName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_ServiceName.Location = new System.Drawing.Point(158, 45);
            this.txt_ServiceName.Name = "txt_ServiceName";
            this.txt_ServiceName.ReadOnly = true;
            this.txt_ServiceName.Size = new System.Drawing.Size(407, 26);
            this.txt_ServiceName.TabIndex = 2;
            // 
            // txt_ServiceState
            // 
            this.txt_ServiceState.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_ServiceState.Location = new System.Drawing.Point(158, 82);
            this.txt_ServiceState.Name = "txt_ServiceState";
            this.txt_ServiceState.ReadOnly = true;
            this.txt_ServiceState.Size = new System.Drawing.Size(407, 26);
            this.txt_ServiceState.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(474, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 26);
            this.button1.TabIndex = 4;
            this.button1.Text = "重新启动";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // frmResetWindowsService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 474);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_ServiceState);
            this.Controls.Add(this.txt_ServiceName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmResetWindowsService";
            this.Text = "frmResetWindowsService";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ServiceName;
        private System.Windows.Forms.TextBox txt_ServiceState;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}