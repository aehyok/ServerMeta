using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SinoSZMetaDataQuery.Common
{
        public partial class Dialog_InputDate : DevExpress.XtraEditors.XtraForm
        {
                public string GetSelectedData()
                {
                        return this.dateNavigator1.DateTime.ToString("yyyyMMdd");                      
                }

                public string GetSelectedChineseData()
                {
                        return this.dateNavigator1.DateTime.ToString("yyyy年MM月dd日");
                }
                

                public Dialog_InputDate()
                {
                        InitializeComponent();                        
                }

                private void simpleButton2_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                }

                private void simpleButton1_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                }

                private void simpleButton3_Click(object sender, EventArgs e)
                {
                        this.dateNavigator1.DateTime = DateTime.Now;
                }

                private void Dialog_InputDate_Load(object sender, EventArgs e)
                {
                        this.dateNavigator1.DateTime = DateTime.Now;
                }

                private void dateNavigator1_MouseDoubleClick(object sender, MouseEventArgs e)
                {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                }
        }
}