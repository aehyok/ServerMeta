using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SinoSZJS.CS.AutoUpdater
{
        public partial class frmWait : Form
        {
                public frmWait()
                {

                        InitializeComponent();
                }



                internal void ShowMessage(string p)
                {
                        this.label1.Text = p;
                }
        }
}