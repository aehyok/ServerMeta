using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SinoSystemWatch.Base.Define;
using System.Runtime.Serialization.Json;
using System.IO;
using SinoSystemWatch.Base.Task;
using System.Web.Script.Serialization;
using SinoSystemWatch.Base.WatchNode;
using DevExpress.XtraTab;
using SinoSystemWatch.InfoShow;

namespace SinoSystemWatch
{
    public partial class C_DetailPanel : UserControl
    {
        public SystemStateItem CurrentItem = null;
        private bool _initFinished = false;
        public event EventHandler<TabPageChangedEventArgs> MenuChanged;
        virtual public void RaiseMenuChanged(TabPageChangedEventArgs e)
        {
            if (this._initFinished && MenuChanged != null)
            {
                MenuChanged(this, e);
            }
        }


        public C_DetailPanel()
        {
            InitializeComponent();
        }

        public void StartRefresh(SystemStateItem item)
        {
            CurrentItem = item;
            this.timer1.Enabled = false;
            this._initFinished = true;
            this.backgroundWorker1.RunWorkerAsync();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string _ret = SinoCommandExcute.Do(SessionCache.CurrentTokenString, "GetNodeCheckMsg", this.CurrentItem.SystemName, null);
            if (_ret.StartsWith("发生错误"))
            {
                //表示返回有错误，记日志
                e.Result = _ret;
            }
            else
            {
                var jser = new JavaScriptSerializer();
                List<TaskResultInfo> _obj = jser.Deserialize(_ret, typeof(List<TaskResultInfo>)) as List<TaskResultInfo>;
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
                List<TaskResultInfo> _result = e.Result as List<TaskResultInfo>;
                foreach (TaskResultInfo _info in _result)
                {
                    AddData2(_info);
                }
            }
            this.timer1.Enabled = true;
            TabPageChangedEventArgs _e = new TabPageChangedEventArgs(null, this.xtraTabControl1.SelectedTabPage);
            RaiseMenuChanged(_e);
        }

        private void AddData2(TaskResultInfo _info)
        {
            if (_info.TaskRunResult != null)
            {
                string _jsCheckData = _info.TaskRunResult.ResultMsg;
                var jser = new JavaScriptSerializer();
                List<CheckInfoResult> _results = jser.Deserialize(_jsCheckData, typeof(List<CheckInfoResult>)) as List<CheckInfoResult>;
                foreach (CheckInfoResult _r in _results)
                {
                    RefreshResultShow2(_r);
                }
            }
        }

        private void RefreshResultShow2(CheckInfoResult _r)
        {
            var _v = from _c in this.xtraTabControl1.TabPages
                     where ((C_CheckInfoPanel)_c.Tag).Projectname == _r.CheckProjectName
                     select _c;
            if (_v.Count() > 0)
            {
                XtraTabPage _page = _v.FirstOrDefault();
                var _p = from _ct in _page.Controls.OfType<C_CheckInfoPanel>()
                         where _ct is C_CheckInfoPanel
                         select _ct;

                if (_p.Count() > 0)
                {
                    C_CheckInfoPanel _new = _p.FirstOrDefault();
                    _new.RefreshData(_r);
                }
            }
            else
            {
                XtraTabPage _newPage = new XtraTabPage();
                _newPage.Text = InfoShowCommon.GetCNString(_r.CheckProjectName);

                this.xtraTabControl1.TabPages.Add(_newPage);
                C_CheckInfoPanel _new = new C_CheckInfoPanel();
                _new.Dock = DockStyle.Fill;

                _newPage.Tag = _new;
                _newPage.Controls.Add(_new);

                _new.RefreshData(_r);
                ShowPageIcon(_newPage, _r.StateFlag);
            }
        }

        private void ShowPageIcon(XtraTabPage _page, int state)
        {
            switch (state)
            {
                case 1:
                    _page.Image = SinoSystemWatch.Properties.Resources._20061208094736649;
                    break;
                case 2:
                    _page.Image = SinoSystemWatch.Properties.Resources._20061208094530743;
                    break;
                case 3:
                    _page.Image = SinoSystemWatch.Properties.Resources._20061208094345476;
                    break;
                default:
                    _page.Image = SinoSystemWatch.Properties.Resources._20061208094654784;
                    break;
            }


        }

        private void xtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            RaiseMenuChanged(e);
        }


    }
}
