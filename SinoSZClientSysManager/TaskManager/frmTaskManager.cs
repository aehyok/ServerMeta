using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZClientBase;
using SinoSZJS.Base.Misc;
using SinoSZPluginFramework;
using SinoSZJS.Base.TaskInfo;
using SinoSZClientBase.Export;

namespace SinoSZClientSysManager.TaskManager
{
    public partial class frmTaskManager : frmBase
    {
        protected string TaskID = "";
        protected SinoTaskInfo CurrentTaskInfo;
        protected List<TaskParameter> TaskParamters = null;
        protected Dictionary<string, string> DisplayDict = new Dictionary<string, string>();
        protected bool ParamterChanged = false;
        protected DateTime LastLogTime = new DateTime(1900, 1, 1);
        protected DataTable CurrentLog = null;
        public frmTaskManager()
        {
            InitializeComponent();
        }

        public override void Init(string _title, string _menuName, object _param)
        {
            this.Text = _title;
            this._menuPageName = _menuName;
            this._initFinished = true;
            string _pstr = _param.ToString();
            TaskID = StrUtils.GetMetaByName2("����ID", _pstr);
            GetParamTitleDict(StrUtils.GetMetaByName2("����˵��", _pstr));
            this.PB_FLAG.Image = this.imageList1.Images[0];
            RefreshState();

        }


        private void GetParamTitleDict(string str)
        {
            DisplayDict.Clear();
            foreach (string _s in str.Split(','))
            {
                string[] _v = _s.Split(':');
                if (_v.Length == 2)
                {
                    if (DisplayDict.ContainsKey(_v[0]))
                    {
                        DisplayDict[_v[0]] = _v[1];
                    }
                    else
                    {
                        DisplayDict.Add(_v[0], _v[1]);
                    }
                }
            }
        }


        #region ���ػ���ķ���

        protected override IList<FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();
            bool HaveSelected = true;
            FrmMenuGroup _thisGroup = new FrmMenuGroup("�����������");
            _thisGroup.MenuItems = new List<FrmMenuItem>();
            FrmMenuItem _item = new FrmMenuItem("ˢ��״̬", "ˢ��״̬", global::SinoSZClientSysManager.Properties.Resources.b28, HaveSelected);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("����ִ��", "����ִ��", global::SinoSZClientSysManager.Properties.Resources.e17, (this.CurrentTaskInfo != null && this.CurrentTaskInfo.RWZT == "0"));
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("��������", "��������", global::SinoSZClientSysManager.Properties.Resources.u2, (this.CurrentTaskInfo != null && this.CurrentTaskInfo.RWZT == "0"));
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("��������", "��������", global::SinoSZClientSysManager.Properties.Resources.u1, (this.CurrentTaskInfo != null && this.CurrentTaskInfo.RWZT == "9"));
            _thisGroup.MenuItems.Add(_item);
            _ret.Add(_thisGroup);

            _thisGroup = new FrmMenuGroup("������־");
            _thisGroup.MenuItems = new List<FrmMenuItem>();
            _item = new FrmMenuItem("������־", "������־", global::SinoSZClientSysManager.Properties.Resources.x3, (this.CurrentLog != null));
            _thisGroup.MenuItems.Add(_item);
            _ret.Add(_thisGroup);

            _thisGroup = new FrmMenuGroup("�����������");
            _thisGroup.MenuItems = new List<FrmMenuItem>();
            _item = new FrmMenuItem("�������", "�������", global::SinoSZClientSysManager.Properties.Resources.xx, ParamterChanged);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("ȡ������", "ȡ������", global::SinoSZClientSysManager.Properties.Resources.x1, ParamterChanged);
            _thisGroup.MenuItems.Add(_item);
            _ret.Add(_thisGroup);

            return _ret;
        }

        protected override bool ExcuteCommand(string _cmdName)
        {
            switch (_cmdName)
            {
                case "ˢ��״̬":
                    RefreshState();
                    break;
                case "����ִ��":
                    ResetParam(DateTime.Now.AddDays(-1), this.CurrentTaskInfo.RWML);
                    XtraMessageBox.Show("�������ڼ����Ӻ��ں�̨��ʼִ��!", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "��������":
                    SetTaskState(9, 0);
                    break;
                case "��������":
                    SetTaskState(0, 9);
                    break;
                case "�������":
                    string NewParam = GetCurrentParamSet();
                    ResetParam(this.CurrentTaskInfo.NextTime, NewParam);
                    break;
                case "ȡ������":
                    CreateParamPanel();
                    RaiseMenuChanged();
                    break;
                case "������־":
                    SinoSZExport_GridViewData.Export(this.gridView1);
                    break;
            }
            return true;
        }

        private void ResetParam(DateTime NextTime, string NewParam)
        {
            string _msg;
            using (SinoSZClientBase.CommonService.CommonServiceClient _csc = new SinoSZClientBase.CommonService.CommonServiceClient())
            {
                _msg = _csc.ResetTaskParam(this.TaskID, NextTime, NewParam);
            }
            if (_msg != "")
            {
                XtraMessageBox.Show("����ʧ�ܣ�" + _msg, "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            RefreshState();
        }



        #endregion

        private void RefreshState()
        {
            this.timer1.Enabled = false;
            if (!this.backgroundWorker1.IsBusy)
            {
                this.backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                this.timer1.Enabled = true;
            }
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            using (SinoSZClientBase.CommonService.CommonServiceClient _csc = new SinoSZClientBase.CommonService.CommonServiceClient())
            {
                CurrentTaskInfo = _csc.GetTaskInfo(this.TaskID);
                DataTable _dt = _csc.GetTaskLog(this.TaskID, this.LastLogTime, this.CB_LOG_ALL.Checked, this.CK_LOG_ERROR.Checked);
                e.Result = _dt;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (CurrentTaskInfo != null)
            {
                this.TE_LASTRESULT.EditValue = this.CurrentTaskInfo.LastResult;
                switch (CurrentTaskInfo.RunFlag)
                {
                    case "0":
                        this.TE_LASTFLAG.EditValue = "�ɹ�";
                        this.TE_LASTFLAG.ForeColor = Color.Black;
                        this.TE_LASTRESULT.ForeColor = Color.Black;
                        break;
                    case "1":
                        this.TE_LASTFLAG.EditValue = "����";
                        this.TE_LASTFLAG.ForeColor = Color.Yellow;
                        this.TE_LASTRESULT.ForeColor = Color.Black;
                        break;
                    case "9":
                        this.TE_LASTFLAG.EditValue = "����";
                        this.TE_LASTFLAG.ForeColor = Color.Red;
                        this.TE_LASTRESULT.ForeColor = Color.Red;
                        break;
                }

                this.TE_LASTTIME.EditValue = CurrentTaskInfo.LastTime;
                this.TE_NEXTTIME.EditValue = CurrentTaskInfo.NextTime;
                this.TE_RWID.EditValue = CurrentTaskInfo.RWID;
                this.TE_RWMC.EditValue = CurrentTaskInfo.RWMC;
                this.TE_RWMS.EditValue = CurrentTaskInfo.RWMS;
                switch (this.CurrentTaskInfo.RWZT)
                {
                    case "0":
                        this.TE_RWZT.EditValue = "����";
                        this.TE_RWZT.ForeColor = Color.Black;
                        break;
                    case "1":
                        this.TE_RWZT.EditValue = "����ִ��";
                        this.TE_RWZT.ForeColor = Color.Blue;
                        break;
                    case "9":
                        this.TE_RWZT.EditValue = "����";
                        this.TE_RWZT.ForeColor = Color.Red;
                        break;
                }

                this.PB_FLAG.Image = SelectFlagImage(CurrentTaskInfo.RunFlag);
                TaskParamters = TaskParameter.GetParamList(CurrentTaskInfo.RWML);
                CreateParamPanel();
                if (e.Result != null)
                {
                    this.gridView1.BeginDataUpdate();
                    DataTable _dt = e.Result as DataTable;

                    if (CurrentLog == null)
                    {
                        CurrentLog = _dt;
                        foreach (DataRow _row in _dt.Rows)
                        {
                            DateTime _runtime = (_row.IsNull("RUNTIME") ? new DateTime(1900, 1, 1) : (DateTime)_row["RUNTIME"]);
                            if (this.LastLogTime < _runtime) this.LastLogTime = _runtime;
                        }
                    }
                    else
                    {
                        foreach (DataRow _row in _dt.Rows)
                        {
                            DateTime _runtime = (_row.IsNull("RUNTIME") ? new DateTime(1900, 1, 1) : (DateTime)_row["RUNTIME"]);
                            if (this.LastLogTime < _runtime) this.LastLogTime = _runtime;
                            CurrentLog.ImportRow(_row);
                        }
                    }
                    this.sinoCommonGrid1.DataSource = null;
                    this.sinoCommonGrid1.DataSource = CurrentLog;
                    this.gridView1.EndDataUpdate();
                }
                RaiseMenuChanged();
                this.timer1.Enabled = true;
            }

        }

        private void CreateParamPanel()
        {
            this.ParamPanel.Controls.Clear();
            this.ParamPanel.Visible = false;
            foreach (TaskParameter _p in this.TaskParamters)
            {
                if (DisplayDict.ContainsKey(_p.ParamName))
                {
                    _p.DisplayTitle = DisplayDict[_p.ParamName];
                }
                TaskParameterInput _pi = new TaskParameterInput(_p);
                _pi.Dock = DockStyle.Top;
                _pi.ParamValueChanged += new EventHandler<EventArgs>(_pi_ParamValueChanged);
                this.ParamPanel.Controls.Add(_pi);
                _pi.BringToFront();
            }
            ParamterChanged = false;
            this.ParamPanel.Visible = true;
        }

        private string GetCurrentParamSet()
        {
            string _ret = "";
            foreach (TaskParameterInput _pi in this.ParamPanel.Controls)
            {
                if (_pi != null)
                {
                    TaskParameter v = _pi.GetParamValue();
                    _ret += string.Format("<{0}>{1}</{2}>", v.ParamName, v.ParamValue, v.ParamName);
                }
            }
            return _ret;
        }

        private void SetTaskState(int NewState, int LimitState)
        {
            string _msg;
            using (SinoSZClientBase.CommonService.CommonServiceClient _csc = new SinoSZClientBase.CommonService.CommonServiceClient())
            {
                _msg = _csc.SetTaskState(this.TaskID, NewState, LimitState);
            }
            if (_msg != "")
            {
                XtraMessageBox.Show("����ʧ�ܣ�" + _msg, "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            RefreshState();
        }

        void _pi_ParamValueChanged(object sender, EventArgs e)
        {
            this.ParamterChanged = true;
            RaiseMenuChanged();
        }

        private Image SelectFlagImage(string flag)
        {
            switch (flag)
            {
                case "0":
                    return this.imageList1.Images[0];
                case "1":
                    return this.imageList1.Images[1];
                default:
                    return this.imageList1.Images[2];

            }
            return null;
        }

        private void CB_LOG_ALL_CheckedChanged(object sender, EventArgs e)
        {
            this.LastLogTime = new DateTime(1900, 1, 1);
            CurrentLog = null;
            RefreshState();
        }

        private void CK_LOG_ERROR_CheckedChanged(object sender, EventArgs e)
        {
            this.LastLogTime = new DateTime(1900, 1, 1);
            CurrentLog = null;
            RefreshState();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshState();
        }


    }
}