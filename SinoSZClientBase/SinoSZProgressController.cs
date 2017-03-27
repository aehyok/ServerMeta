using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SinoSZClientBase
{
        public class SinoSZProgressController
        {
                public static bool Stop = false;
                public static string ShowMessage = "";
                public SinoSZProgressController()
                {
                        //
                        // TODO: 在此处添加构造函数逻辑
                        //
                }

                public static void BeginProgress()
                {
                        Application.DoEvents();
                        Stop = false;
                        ShowMessage = string.Empty;
                        Thread backgroundThread = new Thread(new ThreadStart(SinoSZProgressController.StartShowProgress));
                        backgroundThread.Start();
                }

                public static void BeginProgress(string _msg)
                {
                        Application.DoEvents();
                        Stop = false;
                        ShowMessage = _msg ;
                        Thread backgroundThread = new Thread(new ThreadStart(SinoSZProgressController.StartShowProgress));
                        backgroundThread.Start();
                }

                public static void EndProgress()
                {
                        Stop = true;
                }
                public static void StartShowProgress()
                {
                        frmProgress _f = new frmProgress(ShowMessage);
                        _f.Show();
                        while (!Stop)
                        {
                                Thread.Sleep(100);
                                Application.DoEvents();
                        }
                        _f.Hide();
                }

          
        }
}
