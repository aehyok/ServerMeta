﻿namespace SinoSZMetaDataQuery.Portal
{
        partial class frmPortal
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
                        this.SuspendLayout();
                        // 
                        // tableLayoutPanel1
                        // 
                        this.tableLayoutPanel1.ColumnCount = 3;
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                        this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
                        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
                        this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
                        this.tableLayoutPanel1.RowCount = 1;
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tableLayoutPanel1.Size = new System.Drawing.Size(770, 534);
                        this.tableLayoutPanel1.TabIndex = 1;
                        // 
                        // frmPortal
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(770, 534);
                        this.Controls.Add(this.tableLayoutPanel1);
                        this.Name = "frmPortal";
                        this.Text = "frmPortal";
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        }
}