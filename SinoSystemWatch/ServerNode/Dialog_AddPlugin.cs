using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using SinoSystemWatch.Base.PluginFramework;

namespace SinoSystemWatch.ServerNode
{
    public partial class Dialog_AddPlugin : Form
    {
        private List<AppPluginInfo> CapList;
        private string FullFileName = "";
        public Dialog_AddPlugin()
        {
            InitializeComponent();
        }

        public Dialog_AddPlugin(List<AppPluginInfo> _capList)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.CapList = _capList;

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            AppPluginInfo _cap = FindCap(this.buttonEdit1.EditValue.ToString());
            if (_cap != null && (this.te_Version.EditValue.ToString() == _cap.AssemblyVersion))
            {
                MessageBox.Show("此插件与原来是同一个版本！无需更新!", "系统提示");
            }
            else
            {

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private AppPluginInfo FindCap(string FileName)
        {
            var _a = from _c in CapList
                     where _c.FileName == FileName
                     select _c;

            return _a.FirstOrDefault();
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog _f = new OpenFileDialog();
            _f.Filter = "插件文件(*.dll)|*.dll";
            if (_f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo myFile = new FileInfo(_f.FileName);
                this.FullFileName = _f.FileName;
                this.buttonEdit1.EditValue = myFile.Name;
                this.te_Path.EditValue = myFile.DirectoryName;

                AppPluginInfo _cap = FindCap(myFile.Name);
                if (_cap != null)
                {
                    this.te_Name.EditValue = _cap.Name;
                    this.te_Type.EditValue = _cap.PluginType;
                    this.te_Des.EditValue = _cap.Descript;
                }

                try
                {
                    Assembly assembly = Assembly.LoadFile(_f.FileName);
                    AssemblyName assemblyName = assembly.GetName();
                    this.te_Version.EditValue = assemblyName.Version.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("加载程序集失败！{0}\n\r请手工录入版本号", ex.Message), "系统提示");
                    this.te_Version.EditValue = "";
                    this.te_Version.Properties.ReadOnly = false;
                }

               

            }

        }

        private void Dialog_AddPlugin_Load(object sender, EventArgs e)
        {

        }

        public AppPluginInfo GetInputPluginInfo()
        {
            AppPluginInfo _ret = new AppPluginInfo();
            _ret.Name = this.te_Name.EditValue.ToString();
            _ret.FileName = this.buttonEdit1.EditValue.ToString();
            _ret.Descript = this.te_Des.EditValue.ToString();
            _ret.PluginType = this.te_Type.EditValue.ToString();
            _ret.AssemblyVersion = this.te_Version.EditValue.ToString();
            return _ret;
        }

        public byte[] GetFileBytes()
        {
            FileStream fs = new FileStream(this.FullFileName, FileMode.Open, FileAccess.Read);
            // 读取 
            byte[] _ret = new byte[fs.Length];
            fs.Seek(0, SeekOrigin.Begin);
            int _allByte = fs.Read(_ret, 0, _ret.Length);
            fs.Close();
            return _ret;
        }
    }
}
