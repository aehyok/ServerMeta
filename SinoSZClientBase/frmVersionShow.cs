using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Reflection;
using SinoSZJS.Base.Authorize;
using SinoSZJS.Base.Misc;

namespace SinoSZClientBase
{
    public partial class frmVersionShow : DevExpress.XtraEditors.XtraForm
    {
        public frmVersionShow()
        {
            InitializeComponent();
        }

        private void frmVersionShow_Load(object sender, EventArgs e)
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            Stream pStream = asm.GetManifestResourceStream("SinoSZClientBase.VersionInfo.txt");

            string str = "";

            StreamReader m_streamReader = new StreamReader(pStream, System.Text.Encoding.Unicode);

            //使用StreamReader类来读取文件

            m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);

            // 从数据流中读取每一行，直到文件的最后一行，并在richTextBox1中显示出内容
            string strLine = m_streamReader.ReadLine();
            while (strLine != null)
            {
                str += strLine + Environment.NewLine;
                strLine = m_streamReader.ReadLine();
            }
            //关闭此StreamReader对象
            m_streamReader.Close();

            this.textBox1.Text = str;



            //显示各版本号

            StringBuilder _sb = new StringBuilder();
            //提取客户端版本号
            _sb.AppendLine("客户端版本清单：");
            _sb.AppendLine("主程序版本号：" + SessionClass.SysAssemblyName.Version.ToString());
            //客户端插件版本
            AddDLLList(_sb);


            //提取服务端版本号
            _sb.AppendLine("");
            _sb.AppendLine("");
            _sb.AppendLine("服务器端版本清单：");
            using (CommonService.CommonServiceClient _cs = new CommonService.CommonServiceClient())
            {
                string _serverInfo = _cs.GetServerVersionList();
                _sb.Append(_serverInfo);
            }

            this.tb_version.Text = _sb.ToString();
        }

        private void AddDLLList(StringBuilder _sb)
        {
            AssemblyName myAssemblyName = null;
            DirectoryInfo dirInfo = new DirectoryInfo(Utils.ExeDir);
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
                        myAssemblyName = AssemblyName.GetAssemblyName(_fs.FullName);
                        _sb.AppendLine(string.Format("{0} : {1}", FileName, myAssemblyName.Version.ToString()));
                    }
                }
            }
        }
    }
}