using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;

namespace SinoSZJS.CS.AutoUpdater
{
    public class AutoUpdateStarter
    {
        private string executablePath;
        private string updatePath;
        private bool isDeleteTemp = true;
        private frmWait WaitForm = null;
        public AutoUpdateStarter(frmWait _frmWait)
        {
            WaitForm = _frmWait;
            string stConfigFileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            stConfigFileName = Path.Combine(stConfigFileName, Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location));
            stConfigFileName += @".exe.config";

            AutoUpdateStarterConfig config = AutoUpdateStarterConfig.Load(stConfigFileName);
            this.executablePath = config.ApplicationExePath;
            this.isDeleteTemp = config.DeleteTemp;
            this.updatePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar + "update" + Path.DirectorySeparatorChar;
            StartProcessAndWait();
        }


        /// <summary>
        /// StartProcessAndWait: This will start the appropriate process and wait for it to complete
        /// </summary>
        private void StartProcessAndWait()
        {
            bool restart = true;

            string commandLineArgs = "";
            //foreach (string arg in Environment.GetCommandLineArgs())
            //{
            //        commandLineArgs += '"' + arg + '"' + " ";
            //}
            //commandLineArgs = commandLineArgs.Trim();

            int TryTimes = 0;
            while (restart && TryTimes++ < 5)
            {

                Process mainProcess = null;
                //Start the app
                try
                {
                    ProcessStartInfo p = new ProcessStartInfo(this.executablePath);
                    p.WorkingDirectory = Path.GetDirectoryName(this.executablePath);
                    p.Arguments = commandLineArgs;
                    p.CreateNoWindow = false;
                    p.RedirectStandardInput = false;　 //不重定向輸入
                    p.RedirectStandardOutput = false; //不重定向输出
                    p.UseShellExecute = false;
                    p.WindowStyle = ProcessWindowStyle.Normal;
                    mainProcess = Process.Start(p);

                    Thread.Sleep(1000);

                    //Debug.WriteLine("AutoUpdateStarter:  Started app:  " + this.executablePath);

                    //mainProcess.OutputDataReceived += new DataReceivedEventHandler(mainProcess_OutputDataReceived);
                }
                catch (Exception e)
                {
                    MessageBox.Show("无法启动程序:{0} \n错误信息:{1}" + this.executablePath, e.Message);
                    restart = false;
                }

                if (mainProcess != null)
                {
                    try
                    {
                        Thread.Sleep(1000);
                        WaitForm.Hide();
                        mainProcess.WaitForExit();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("自动更新进程序失败,应用程序未能被执行！");
                        MessageBox.Show("重新启动自动更新:  " + e.ToString());
                        return;
                    }

                    if (mainProcess.ExitCode == 2)
                        restart = true;
                    else
                        restart = false;

                    if (restart)
                    {
                        Application.DoEvents();
                        if (Directory.Exists(Path.GetDirectoryName(this.executablePath)) && Directory.Exists(Path.GetDirectoryName(this.updatePath)))
                        {
                            WaitForm.Show();
                            string _exepath = Path.GetDirectoryName(this.executablePath);

                            foreach (string _fname in Directory.GetFiles(this.updatePath, "*.*"))
                            {
                                try
                                {
                                    string _filename = _exepath + Path.DirectorySeparatorChar + Path.GetFileName(_fname);
                                    File.Copy(_fname, _filename, true);
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show(e.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            if (isDeleteTemp)
                            {
                                Directory.Delete(this.updatePath, true);
                            }
                        }
                    }
                }
            }//while(restart)
            if (TryTimes >= 5)
            {
                MessageBox.Show("服务器上存在新版本，但无法完成更新！请与管理员联系处理！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void mainProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            this.WaitForm.ShowMessage(e.Data);
        }//StartProcessAndWait()

    }//class AutoUpdateStarter
}//namespace Conversive.AutoUpdateStarter
