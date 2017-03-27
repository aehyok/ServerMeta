using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SinoSZMetaDataQuery.DataQuery
{
        public partial class QueryWaitingPanel : UserControl
        {
                public QueryWaitingPanel()
                {
                        InitializeComponent();
                }

                public void ShowFinished(string _msg)
                {
                        this.pictureBox1.Visible = false;
                        this.label1.Text = _msg;
                        this.label1.ForeColor = Color.Blue;
                }

                internal void SetWait()
                {
                        this.pictureBox1.Visible = true;
                        this.label1.Text = "正在查询数据...";
                        this.label1.ForeColor = Color.Blue;
                }
                internal void SetWait(string _msg)
                {
                        this.pictureBox1.Visible = true;
                        this.label1.Text = _msg;
                        this.label1.ForeColor = Color.Blue;
                }
        }
}
