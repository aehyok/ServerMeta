using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZPluginFramework;
using SinoSZPluginFramework.ClientPlugin;

namespace SinoSZClientBase.PendingAlert
{
        public partial class Dialog_PendingAlert : DevExpress.XtraEditors.XtraForm
        {
                private IApplication Application = null;
                private Rectangle WorkAreaRectangle;
                private int CurrentState = 0;
                public Dialog_PendingAlert()
                {
                        InitializeComponent();

                }

                public Dialog_PendingAlert(IApplication app)
                {
                        InitializeComponent();
                        Application = app;
                }

                public bool ShowForm()
                {
                        WorkAreaRectangle = Screen.GetWorkingArea(this);
                        this.Top = WorkAreaRectangle.Height;
                        this.Left = WorkAreaRectangle.Width - this.Width;
                        this.Show();
                        timer1.Enabled = true;
                        return true;
                }
                private void timer1_Tick(object sender, EventArgs e)
                {
                        this.Top = this.Top - 2;

                        if (this.Top <= WorkAreaRectangle.Height - this.Height)
                        {
                                timer1.Enabled = false;
                                CurrentState = 2;
                                this.timer2.Enabled = true;
                        }
                }

                private void Dialog_PendingAlert_FormClosing(object sender, FormClosingEventArgs e)
                {
                        this.Hide();
                        e.Cancel = true;
                }

                private void simpleButton1_Click(object sender, EventArgs e)
                {
                        this.Hide();
                }

                private void timer2_Tick(object sender, EventArgs e)
                {
                        this.Hide();
                        this.timer2.Enabled = false;
                }

                public void SetData(List<PendingAlertIndex> paIndex)
                {
                        this.panel1.Controls.Clear();
                        int i = 0;
                        foreach (PendingAlertIndex _item in paIndex)
                        {
                                PendingAlertIndexItem _p = new PendingAlertIndexItem(_item.GroupName, _item.Count, _item.ICS_Alert);
                                _p.MouseClick += new MouseEventHandler(panel1_MouseClick);
                                i++;
                                _p.Dock = DockStyle.Top;
                                this.panel1.Controls.Add(_p);
                                _p.BringToFront();
                        }
                        this.Height = i * 24 + 60;
                }


                private void panel1_MouseClick(object sender, MouseEventArgs e)
                {
                        if (Application != null)
                        {
                                //string _alertFormName = "Client_PendingAlert";
                                //if (Application.IsExistForm(_alertFormName))
                                //{
                                //        Application.SetFormActive(_alertFormName);
                                //}
                                //else
                                //{
                                //        frmPendingAlert _f = new frmPendingAlert();
                                //        Application.AddForm(_alertFormName, _f);
                                //}
                                this.Hide();
                                this.timer2.Enabled = false;
                        }
                }

                public void ClearForm()
                {
                        this.Hide();
                        this.panel1.Controls.Clear();
                        this.timer2.Enabled = false;
                }
        }
}