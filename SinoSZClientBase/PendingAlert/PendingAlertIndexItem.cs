using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SinoSZPluginFramework.ClientPlugin;

namespace SinoSZClientBase.PendingAlert
{
        public partial class PendingAlertIndexItem : UserControl
        {
                private IPendingAlert ICS_PendingAlert = null;
                public PendingAlertIndexItem()
                {
                        InitializeComponent();
                }

                public PendingAlertIndexItem(string _type, int _count, IPendingAlert ics)
                {
                        InitializeComponent();
                        this.lb_Type.Text = (_type.Length > 17) ? _type.Substring(0, 17) : _type;
                        this.lb_count.Text = _count.ToString();
                        ICS_PendingAlert = ics;
                }

                private void lb_Type_MouseClick(object sender, MouseEventArgs e)
                {
                        Showform();
                }

         

                private void lb_count_MouseClick(object sender, MouseEventArgs e)
                {
                        Showform();
                }

                private void label1_MouseClick(object sender, MouseEventArgs e)
                {
                        Showform();
                }

                private void Showform()
                {
                        ICS_PendingAlert.ShowDetail();
                }
        }
}
