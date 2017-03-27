using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SinoSystemWatch.Base.PluginFramework;

namespace SinoSystemWatch.ServerNode
{
    public partial class Dialog_SelectPlugin : Form
    {
        public List<AppPluginInfo> PluginList = null;
        public AppPluginInfo CurrentPlugin = null;
        public Dialog_SelectPlugin()
        {
            InitializeComponent();
        }

        public Dialog_SelectPlugin(List<AppPluginInfo> list)
        {
            InitializeComponent();
            PluginList = list;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.gridView1.FocusedRowHandle >= 0)
            {
                CurrentPlugin = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as AppPluginInfo;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("请选择要加载的插件！", "系统提示");
            }
        }

        private void Dialog_SelectPlugin_Load(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = PluginList;
        }

        public AppPluginInfo SelectedPlugin
        {
            get
            {
                return CurrentPlugin;
            }
        }
    }
}
