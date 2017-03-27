using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using System.IO;
using System.Reflection;
using System.IO.Compression;
using System.Xml;
using SinoSZJS.Base.AutoUpdater;
using SinoSZJS.Base.Misc;


namespace SinoSZToolUpdatePacker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void be_TargetDir_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            FolderBrowserDialog _f = new FolderBrowserDialog();
            _f.ShowDialog();
            this.be_TargetDir.EditValue = _f.SelectedPath;
        }

        private void be_SourceDir_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            FolderBrowserDialog _f = new FolderBrowserDialog();
            _f.ShowDialog();
            this.be_SourceDir.EditValue = _f.SelectedPath;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //取源目录文件列表
            string SourcePath = this.be_SourceDir.EditValue.ToString();
            string DownloadUrl = this.te_URL.EditValue.ToString();
            string TargetPath = this.be_TargetDir.EditValue.ToString() + "\\";
            string SourceConfigFile = this.buttonEdit1.EditValue.ToString();


            if (SourcePath == "" || DownloadUrl == "" || TargetPath == "" || SourceConfigFile == "")
            {
                MessageBox.Show("请录入生成目录、源升级文件目录、源配置文件、下级网站地址等内容！");
                return;
            }

            AssemblyName myAssemblyName = null;

            #region 生成DLL配置文件列表
            //配置文件
            AutoUpdateConfig _configFile = new AutoUpdateConfig();
            _configFile.CurrentVersionfiles = new List<UpdateFileInfo>();


            DirectoryInfo dirInfo = new DirectoryInfo(SourcePath);
            foreach (FileSystemInfo _fs in dirInfo.GetFileSystemInfos())
            {
                string FileName = "";
                string FileExt = "";
                //如果是文件
                if (_fs is FileInfo)
                {
                    FileInfo fi = (FileInfo)_fs;
                    FileName = fi.Name;
                    //取得文件的扩展名
                    FileExt = fi.Extension.ToUpper();

                    if (FileExt == ".DLL" || FileExt == ".EXE")
                    {
                        string _packFileName = FileName + ".zip";
                        myAssemblyName = AssemblyName.GetAssemblyName(_fs.FullName);
                        //比较版本号,如果有新版本，加入下载更新列表                                       
                        string _downloadFileName = DownloadUrl + _packFileName;
                        string TargetFileName = TargetPath + _packFileName;
                        ZipFile(_fs.FullName, TargetFileName);

                        UpdateFileInfo _ufi = new UpdateFileInfo(fi.Name, myAssemblyName.Version.ToString(), _downloadFileName);
                        _configFile.CurrentVersionfiles.Add(_ufi);

                        this.te_Out.EditValue = (string)this.te_Out.EditValue + "\r\n" +
                                string.Format(" {0},{1},{2} ", _ufi.FileName, _ufi.AvailableVersion, _ufi.AppFileURL);
                        Application.DoEvents();
                    }
                }
            }

            //生成配置文件
            string _ConfigFileName = TargetPath + "UpdateVersion.xml";

            if (File.Exists(_ConfigFileName))
            {
                File.Delete(_ConfigFileName);
            }
            StreamWriter _fw = File.CreateText(_ConfigFileName);
            _fw.WriteLine(@"<VersionConfig>");
            foreach (UpdateFileInfo _ufi in _configFile.CurrentVersionfiles)
            {
                _fw.WriteLine(string.Format("<FileName Name=\"{0}\" Version=\"{1}\" AppFileURL=\"{2}\"/>",
                        _ufi.FileName, _ufi.AvailableVersion, _ufi.AppFileURL));
            }
            _fw.WriteLine(@"</VersionConfig>");

            _fw.Close();

            #endregion

            #region 生成客户端配置更新文件
            string _pluginFileName = TargetPath + "UpdateApp.xml";
            File.Copy(SourceConfigFile, _pluginFileName, true);


            #endregion

            MessageBox.Show("自动更新升级包制作完成!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 压缩文个把
        /// </summary>
        /// <param name="p"></param>
        /// <param name="TargetFileName"></param>
        private void ZipFile(string _sourceFile, string TargetFileName)
        {
            if (!File.Exists(_sourceFile))
            {
                MessageBox.Show(string.Format("文件{0}没有找到!", _sourceFile), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (File.Exists(TargetFileName)) File.Delete(TargetFileName);

            using (FileStream sourceStream = new FileStream(_sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                byte[] buffer = new byte[sourceStream.Length];
                int checkCounter = sourceStream.Read(buffer, 0, buffer.Length);
                if (checkCounter != buffer.Length) throw new ApplicationException();
                using (FileStream destinationStream = new FileStream(TargetFileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (GZipStream compressedStream = new GZipStream(destinationStream, CompressionMode.Compress, true))
                    {
                        compressedStream.Write(buffer, 0, buffer.Length);
                    }
                }
            }


        }

        private void buttonEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            OpenFileDialog _f = new OpenFileDialog();
            if (_f.ShowDialog() == DialogResult.OK)
            {
                this.buttonEdit1.EditValue = _f.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string _saveData = GetSaveData();
            if (_saveData != "")
            {
                this.be_SourceDir.EditValue = StrUtils.GetMetaByName2("srcPath", _saveData).Replace("\r", "").Replace("\n", "");
                this.te_URL.EditValue = StrUtils.GetMetaByName2("dlURL", _saveData).Replace("\r", "").Replace("\n", "");
                this.be_TargetDir.EditValue = StrUtils.GetMetaByName2("desPath", _saveData).Replace("\r", "").Replace("\n", "");
                this.buttonEdit1.EditValue = StrUtils.GetMetaByName2("srcConfig", _saveData).Replace("\r", "").Replace("\n", "");
            }
        }

        private string GetSaveData()
        {
            string _fileName = Utils.ExeDir + "SaveData.xml";
            if (File.Exists(_fileName))
            {
                StreamReader sr = File.OpenText(_fileName);
                string _ret = sr.ReadToEnd();
                sr.Close();
                return _ret;
            }
            else
            {
                return "";
            }

        }

        private void SaveData()
        {
            //取源目录文件列表
            string SourcePath = this.be_SourceDir.EditValue.ToString();
            string DownloadUrl = this.te_URL.EditValue.ToString();
            string TargetPath = this.be_TargetDir.EditValue.ToString();
            string SourceConfigFile = this.buttonEdit1.EditValue.ToString();

            string _fileName = Utils.ExeDir + "SaveData.xml";


            StreamWriter sw = File.CreateText(_fileName);
            sw.WriteLine("<XML>");
            sw.Write("<srcPath>");
            sw.Write(SourcePath);
            sw.WriteLine("</srcPath>");
            sw.Write("<dlURL>");
            sw.Write(DownloadUrl);
            sw.WriteLine("</dlURL>");
            sw.Write("<desPath>");
            sw.Write(TargetPath);
            sw.WriteLine("</desPath>");
            sw.Write("<srcConfig>");
            sw.Write(SourceConfigFile);
            sw.WriteLine("</srcConfig>");
            sw.WriteLine("</XML>");
            sw.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveData();
        }
    }
}