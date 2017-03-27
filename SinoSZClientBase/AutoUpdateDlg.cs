using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;

namespace SinoSZClientBase
{
        public partial class AutoUpdateDlg : Form
        {
                private bool beforeUpdate = true;
                private string _updateDownloadUrl = null;
                private SinoSZClientBase.AutoUpdater.AutoUpdater autoUpdater1;
                public delegate void progressEventHandle(string str);

                public AutoUpdateDlg()
                {
                        InitializeComponent();
                }

                public AutoUpdateDlg(string _url)
                {
                        InitializeComponent();
                        _updateDownloadUrl = _url;
                }

                public AutoUpdateDlg(string _systemName, string _url)
                {
                        InitializeComponent();
                        this.Text = string.Format("{0}系统自动更新", _systemName);
                        _updateDownloadUrl = _url;
                }

                private void timer1_Tick(object sender, EventArgs e)
                {
                        if (autoUpdater1._finishedFlag)
                        {
                                timer1.Enabled = false;
                                this.DialogResult = DialogResult.Yes;
                                this.Close();
                        }
                        this.progressBar1.Increment(2);
                        if (this.progressBar1.Value >= 98)
                        {
                                this.progressBar1.Value = 0;
                        }
                }

                private void AutoUpdateDlg_Activated(object sender, EventArgs e)
                {
                        if (beforeUpdate)
                        {
                                timer1.Enabled = true;
                                beforeUpdate = false;
                                autoUpdater1 = new SinoSZClientBase.AutoUpdater.AutoUpdater();
                                autoUpdater1.ConfigURL = _updateDownloadUrl;
                                autoUpdater1.AutoRestart = true;
                                autoUpdater1.UpdateProgress += new EventHandler<SinoSZJS.Base.UpdateProgessEventArgs>(autoUpdater1_UpdateProgress);
                                autoUpdater1.UpdateError += new EventHandler<System.IO.ErrorEventArgs>(autoUpdater1_UpdateError);
                                autoUpdater1.TryUpdate();
                        }
                }

                void autoUpdater1_UpdateError(object sender, ErrorEventArgs e)
                {
                        XtraMessageBox.Show(e.GetException().Message, "系统提示!");
                }


                void autoUpdater1_UpdateProgress(object sender, SinoSZJS.Base.UpdateProgessEventArgs e)
                {
                        //MethodInvoker invoker = new MethodInvoker(UpdateProgress);
                        //synchronizer.Invoke(invoker, new object[] { e.Message});

                        System.ComponentModel.ISynchronizeInvoke synchronizer = this;
                        progressEventHandle invoker = new progressEventHandle(UpdateProgress);
                        synchronizer.BeginInvoke(invoker, new object[] { e.Message });

                }

                private void UpdateProgress(string _msg)
                {
                        this.label1.Text = _msg;
                        Application.DoEvents();
                }

        }
}