using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSystemWatch.Base.Define;
using System.Web.Script.Serialization;
using SinoSystemWatch.Base.PluginFramework;

namespace SinoSystemWatch
{
    public partial class C_SystemInfo : DevExpress.XtraEditors.XtraUserControl
    {
        public SystemStateItem CurrentItem = null;
        private List<AppPluginInfo> CurrentAppPlugin = new List<AppPluginInfo>();
        public C_SystemInfo()
        {
            InitializeComponent();
        }

        public C_SystemInfo(SystemStateItem item)
        {
            InitializeComponent();
            CurrentItem = item;
            LoadData();
        }

        private void LoadData()
        {
            this.te_Name.EditValue = CurrentItem.SystemName;
            this.te_IP.EditValue = CurrentItem.SystemURL;
            this.te_Des.EditValue = CurrentItem.SystemDescription;
            this.te_Connect.EditValue = CurrentItem.Connected;
            this.te_System.EditValue = CurrentItem.SystemFlag;
            this.te_Application.EditValue = CurrentItem.ApplicationFlag;
            this.te_Database.EditValue = CurrentItem.DataBaseFlag;
            this.te_Task.EditValue = CurrentItem.TaskFlag;
            this.te_Interface.EditValue = CurrentItem.InterfaceFlag;

            if (!this.backgroundWorker1.IsBusy)
            {
                this.backgroundWorker1.RunWorkerAsync();
            }

        }


        public void RefreshData()
        {
            LoadData();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void C_SystemInfo_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string _ret = SinoCommandExcute.Do(SessionCache.CurrentTokenString, "GetNodePluginVersion", this.CurrentItem.SystemName, null);
            if (_ret.StartsWith("发生错误") || _ret.StartsWith("False"))
            {
                //表示返回有错误，记日志
                e.Result = _ret;
            }
            else
            {
                var jser = new JavaScriptSerializer();
                List<AppPluginInfo> _obj = jser.Deserialize(_ret, typeof(List<AppPluginInfo>)) as List<AppPluginInfo>;
                e.Result = _obj;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is string)
            {

            }
            else
            {
                CurrentAppPlugin = e.Result as List<AppPluginInfo>;
                this.gridView1.BeginDataUpdate();
                this.gridControl1.DataSource = CurrentAppPlugin;
                this.gridView1.EndDataUpdate();
            }
        }

        public AppPluginInfo CurrentPlugin()
        {
            if (this.gridView1.FocusedRowHandle >= 0)
            {
                AppPluginInfo _ret = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as AppPluginInfo;
                return _ret;
            }
            else
            {
                return null;
            }
        }

        public List<AppPluginInfo> CurrentPluginList()
        {
            return CurrentAppPlugin;
        }
    }
}
