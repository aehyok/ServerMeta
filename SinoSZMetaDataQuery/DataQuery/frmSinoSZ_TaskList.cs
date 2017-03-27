using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZPluginFramework;
using SinoSZJS.Base.MetaData.QueryModel;
using System.Linq;
using SinoSZClientBase.MetaDataQueryService;

namespace SinoSZMetaDataQuery.DataQuery
{
    public partial class frmSinoSZ_TaskList : DevExpress.XtraEditors.XtraForm, IChildForm
    {
        protected IApplication _application = null;
        protected bool _initFinished = false;
        private List<MDQuery_Task> _taskList = null;
        public frmSinoSZ_TaskList()
        {
            InitializeComponent();

            InitForm();
        }

        private MDQuery_Task CurrentTask
        {
            get
            {
                if (this.gridView1.FocusedRowHandle < 0) return null;
                return this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as MDQuery_Task;
            }
        }

        private void InitForm()
        {
            using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
            {
                _taskList = _msc.GetQueryTaskList().ToList<MDQuery_Task>();
            }
            this.sinoCommonGrid1.DataSource = _taskList;
            _initFinished = true;
            this.timer1.Enabled = true;
        }


        #region IChildForm Members

        public IApplication Application
        {
            get { return _application; }
            set { _application = value; }
        }
        public event EventHandler<EventArgs> MenuChanged;
        virtual public void RaiseMenuChanged()
        {
            if (this._initFinished && MenuChanged != null)
            {
                MenuChanged(this, new EventArgs());
            }
        }


        public IList<FrmMenuPage> GetMenuPages()
        {
            IList<FrmMenuPage> _ret = new List<FrmMenuPage>();
            FrmMenuPage _page = new FrmMenuPage("查询任务");
            _page.MenuGroups = GetMenuGroups(_page.PageTitle);
            _ret.Add(_page);
            return _ret;
        }

        private IList<FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();

            FrmMenuGroup _thisGroup = new FrmMenuGroup("查询任务");

            bool _haveItem = (this.CurrentTask != null);

            _thisGroup.MenuItems = new List<FrmMenuItem>();
            FrmMenuItem _item = new FrmMenuItem("任务条件", "任务条件", global::SinoSZMetaDataQuery.Properties.Resources.r1, (this.CurrentTask != null));
            _thisGroup.MenuItems.Add(_item);


            _item = new FrmMenuItem("取消任务", "取消任务", global::SinoSZMetaDataQuery.Properties.Resources.r2,
                   (this.CurrentTask == null) ? false : (this.CurrentTask.TaskState < 3));
            _thisGroup.MenuItems.Add(_item);


            _item = new FrmMenuItem("查看结果", "查看结果", global::SinoSZMetaDataQuery.Properties.Resources.r3,
                 (this.CurrentTask == null) ? false : ((this.CurrentTask.TaskState == 3) || (this.CurrentTask.TaskState == 10)));
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("锁定结果", "锁定结果", global::SinoSZMetaDataQuery.Properties.Resources.r4,
                (this.CurrentTask == null) ? false : ((this.CurrentTask.TaskState == 3) && !this.CurrentTask.ResultLocked));
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("清除任务", "清除任务", global::SinoSZMetaDataQuery.Properties.Resources.r5,
                (this.CurrentTask == null) ? false : (this.CurrentTask.TaskState > 2));
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("修改计划时间", "修改计划时间", global::SinoSZMetaDataQuery.Properties.Resources.g30, 80,
            (this.CurrentTask == null) ? false : (this.CurrentTask.TaskState == 0));
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("处理日志", "处理日志", global::SinoSZMetaDataQuery.Properties.Resources.b24,
                true);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("刷新列表", "刷新列表", global::SinoSZMetaDataQuery.Properties.Resources.b25,
                 true);
            _thisGroup.MenuItems.Add(_item);


            _ret.Add(_thisGroup);

            return _ret;
        }


        public bool DoCommand(string _cmdName)
        {
            switch (_cmdName)
            {
                case "任务条件":
                    return ShowQueryRequest();

                case "取消任务":
                    return CancelTask();

                case "查看结果":
                    return ShowResult();

                case "修改计划时间":
                    return ChangeRequestTime();

                case "处理日志":
                    ShowLog();
                    return true;

                case "锁定结果":
                    return LockResult();

                case "清除任务":
                    return ClearTask();

                case "刷新列表":
                    return RefreshList();

            }

            return true;
        }

        private bool ChangeRequestTime()
        {
            if (this.CurrentTask != null)
            {
                Dialog_ChangeTaskRequestTime _f = new Dialog_ChangeTaskRequestTime(this.CurrentTask.RequestTime);
                if (_f.ShowDialog() == DialogResult.OK)
                {
                    using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                    {
                        if (_msc.ChangeQueryTaskRequestTime(this.CurrentTask.TaskID, _f.RequestTime))
                        {
                            XtraMessageBox.Show("任务计划执行时间修改成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshList();
                            return true;
                        }
                        else
                        {
                            XtraMessageBox.Show("任务计划执行时间修改失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return true;
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }



            return true;
        }

        #endregion

        /// <summary>
        /// 刷新任务列表
        /// </summary>
        /// <returns></returns>
        private bool RefreshList()
        {
            if (!this.backgroundWorker1.IsBusy)
            {
                this.backgroundWorker1.RunWorkerAsync();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 清除任务
        /// </summary>
        private bool ClearTask()
        {
            if (this.CurrentTask != null)
            {
                using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                {
                    if (_msc.ClearQueryTask(this.CurrentTask.TaskID))
                    {
                        XtraMessageBox.Show(string.Format("查询任务\"{0}\"记录已经被清除!", this.CurrentTask.TaskName), "系统提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.gridView1.BeginUpdate();
                        this._taskList.Remove(this.CurrentTask);
                        this.gridView1.EndDataUpdate();
                        RaiseMenuChanged();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 锁定任务
        /// </summary>
        private bool LockResult()
        {
            if (this.CurrentTask != null)
            {
                using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                {
                    if (_msc.LockQueryTaskResult(this.CurrentTask.TaskID))
                    {
                        this.gridView1.BeginUpdate();
                        this.CurrentTask.ResultLocked = true;
                        this.gridView1.EndDataUpdate();
                        RaiseMenuChanged();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 显示查询结果
        /// </summary>
        private bool ShowResult()
        {
            if (this.CurrentTask != null)
            {
                frmSinoSZ_QueryResult _qr = new frmSinoSZ_QueryResult(this.CurrentTask);
                _application.AddForm(Guid.NewGuid().ToString(), _qr);
                return true;
            }
            else
            {
                return false;
            }
        }




        /// <summary>
        /// 取消查询任务
        /// </summary>
        private bool CancelTask()
        {
            if (this.CurrentTask != null)
            {
                using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                {
                    if (_msc.CancleQueryTask(this.CurrentTask.TaskID))
                    {
                        XtraMessageBox.Show(string.Format("查询任务\"{0}\"记录已经被取消!", this.CurrentTask.TaskName), "系统提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.gridView1.BeginUpdate();
                        this.CurrentTask.TaskState = 4;
                        this.gridView1.EndDataUpdate();
                        RaiseMenuChanged();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 显示任务请求条件
        /// </summary>
        private bool ShowQueryRequest()
        {
            if (this.CurrentTask != null)
            {
                Dialog_TaskRequest _f = new Dialog_TaskRequest(this.CurrentTask);
                _f.ShowDialog();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            RaiseMenuChanged();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
            {
                List<MDQuery_Task> _ret = _msc.GetQueryTaskList().ToList<MDQuery_Task>();
                e.Result = _ret;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.gridView1.BeginUpdate();
            this.sinoCommonGrid1.DataSource = null;
            _taskList = e.Result as List<MDQuery_Task>;
            this.sinoCommonGrid1.DataSource = _taskList;
            this.gridView1.EndDataUpdate();
            RaiseMenuChanged();
            this.timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.CurrentTask != null)
            {
                if (this.CurrentTask.TaskState == 3)
                {
                    ShowResult();
                }
                else
                {

                    ShowLog();
                }
            }

        }

        private void ShowLog()
        {
            if (this.CurrentTask != null)
            {
                Dialog_TaskQuery_Log _log = new Dialog_TaskQuery_Log(this.CurrentTask);
                _log.ShowDialog();
            }
        }

    }
}