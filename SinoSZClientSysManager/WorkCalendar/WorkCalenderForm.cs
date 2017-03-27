using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZPluginFramework;
using SinoSZClientBase;
using SinoSZJS.Base.WorkCalendar;
using SinoSZClientBase.CommonService;
using System.Linq;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.Utils.Drawing;
using System.Drawing.Drawing2D;
using SinoSZClientBase.Export;

namespace SinoSZClientSysManager.WorkCalendar
{
    public partial class WorkCalenderForm : frmBase
    {
        private IApplication _application = null;
        private bool _initFinished = false;
        private List<WC_DataInfo> DateList = null;
        private WC_TJSB_Settings TJSB_Setting;
        private int Default_FXSBR = 0;
        public WorkCalenderForm()
        {
            InitializeComponent();
        }



        #region 实现IChildForm接口

        protected override IList<FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();

            FrmMenuGroup _thisGroup = new FrmMenuGroup("日历操作");
            _thisGroup.MenuItems = new List<FrmMenuItem>();
            FrmMenuItem _item = new FrmMenuItem("保存设置", "保存设置", global::SinoSZClientSysManager.Properties.Resources.xx, true);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("导出日历", "导出日历", global::SinoSZClientSysManager.Properties.Resources.x3, true);
            _thisGroup.MenuItems.Add(_item);

            _ret.Add(_thisGroup);

            _thisGroup = new FrmMenuGroup("设置参数值");
            _thisGroup.MenuItems = new List<FrmMenuItem>();
            _item = new FrmMenuItem("统计上报", "统计上报参数", global::SinoSZClientSysManager.Properties.Resources.e17, true);
            _thisGroup.MenuItems.Add(_item);
            _item = new FrmMenuItem("风险上报", "风险上报参数", global::SinoSZClientSysManager.Properties.Resources.e17, true);
            _thisGroup.MenuItems.Add(_item);
            _ret.Add(_thisGroup);
            return _ret;
        }


        protected override bool ExcuteCommand(string _cmdName)
        {
            switch (_cmdName)
            {
                case "统计上报参数":
                    SaveTJDefaultSetting();
                    break;
                case "风险上报参数":
                    SaveFXDefaultSetting();
                    break;
                case "保存设置":
                    SaveSetting();
                    break;
                case "导出日历":
                    ExportSetting();
                    break;
            }

            return true;
        }

        private void SaveFXDefaultSetting()
        {
            MessageBox.Show("风险上报设置暂时不使用！", "系统提示");
        }

        private void SaveTJDefaultSetting()
        {
            frmTJSBSettings _fm = new frmTJSBSettings(this.TJSB_Setting);
            if (_fm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.TJSB_Setting = _fm.CurrentSet();
                using (CommonServiceClient _csc = new CommonServiceClient())
                {
                    _csc.SaveTJSBSettings(this.TJSB_Setting);
                }
                LoadData();
            }
        }


        private void ExportSetting()
        {
            Dialog_ExportGridViewData _f = new Dialog_ExportGridViewData(this.gridView1);
            _f.ShowDialog();
        }

        private void SaveSetting()
        {
            if (this.te_RQ.EditValue == null) return;
            string _dt = this.te_RQ.EditValue.ToString();
            WC_DataInfo _info = new WC_DataInfo();
            _info.GZ_Date = new DateTime(int.Parse(_dt.Substring(0, 4)), int.Parse(_dt.Substring(5, 2)), int.Parse(_dt.Substring(8, 2)));
            _info.Year = _info.GZ_Date.Year;
            _info.Month = _info.GZ_Date.Month;
            _info.Day = _info.GZ_Date.Day;
            _info.IsWorkDay = this.te_IsWorkDay.Checked;
            _info.IsTJSBR = this.te_IsTJSBR.Checked;
            _info.IsFXSBR = this.te_IsFXSBR.Checked;
            _info.Meta = (this.te_Des.EditValue == null) ? "" : this.te_Des.EditValue.ToString();
            using (CommonServiceClient _csc = new CommonServiceClient())
            {
                if (_csc.SaveDataInfo(_info))
                {
                    var find = from _c in DateList
                               where _c.GZ_Date == _info.GZ_Date
                               select _c;
                    if (find == null || find.Count() < 1)
                    {
                        this.DateList.Add(_info);
                    }
                    else
                    {
                        WC_DataInfo _wc = find.First();
                        _wc.IsWorkDay = _info.IsWorkDay;
                        _wc.IsFXSBR = _info.IsFXSBR;
                        _wc.IsTJSBR = _info.IsTJSBR;
                        _wc.Meta = _info.Meta;
                    }
                    int _year = int.Parse(this.TE_YEAR.Text);
                    DrawDates(_year);
                }

            }

        }


        #endregion


        public override void Init(string _title, string _menuName, object _param)
        {
            this.Text = _title;
            this._menuPageName = _menuName;
            DateTime _now = DateTime.Now;
            this.TE_YEAR.Text = _now.Year.ToString();
            LoadData();
            this._initFinished = true;

        }

        private void LoadData()
        {

            int _year = int.Parse(this.TE_YEAR.Text);
            this.schedulerControl1.LimitInterval.Start = new DateTime(_year, 1, 1);
            this.schedulerControl1.LimitInterval.End = new DateTime(_year, 12, 31);
            this.schedulerControl1.Start = new DateTime(_year, 1, 1);
            this.schedulerControl1.SelectedInterval.Start = new DateTime(_year, 1, 1);
            using (CommonServiceClient _csc = new CommonServiceClient())
            {
                DateList = _csc.GetDataInfo(_year).ToList<WC_DataInfo>();
                TJSB_Setting = _csc.GetTJSBSettings();
            }

            DrawDates(_year);


        }

        private void DrawDates(int _year)
        {
            DateTime _cdate;
            #region 处理记录
            if (DateList != null)
            {
                this.sinoCommonGrid1.BeginUpdate();
                var ShowList = from _c in DateList
                               where _c.Year == _year
                               select _c;
                this.sinoCommonGrid1.DataSource = ShowList;
                this.schedulerStorage1.Appointments.Clear();
                this.schedulerStorage1.Resources.Clear();

                foreach (WC_DataInfo _dc in DateList)
                {
                    string _des = "";
                    if (_dc.IsTJSBR)
                    {
                        Appointment _ap = new Appointment(AppointmentType.Normal, _dc.GZ_Date, new TimeSpan(24, 0, 0), "统计上报日");
                        _ap.LabelId = 1;
                        this.schedulerStorage1.Appointments.Add(_ap);
                    }
                    if (_dc.IsFXSBR)
                    {
                        Appointment _ap = new Appointment(AppointmentType.Normal, _dc.GZ_Date, new TimeSpan(24, 0, 0), "风险上报日");
                        _ap.LabelId = 2;
                        this.schedulerStorage1.Appointments.Add(_ap);
                    }
                    if (_dc.Meta != null && _dc.Meta.Trim() != "")
                    {
                        Appointment _ap = new Appointment(AppointmentType.Normal, _dc.GZ_Date, new TimeSpan(24, 0, 0), _dc.Meta);
                        _ap.LabelId = 3;
                        this.schedulerStorage1.Appointments.Add(_ap);
                    }


                }

                this.sinoCommonGrid1.EndUpdate();
            }
            #endregion

            #region 处理每月上报日
            for (int i = 1; i < 13; i++)
            {
                if (this.TJSB_Setting.SBDay > 28)
                {
                    _cdate = new DateTime(_year, i, 28);
                }
                else
                {
                    _cdate = new DateTime(_year, i, this.TJSB_Setting.SBDay);
                }
                var find = from _c in DateList
                           where _c.GZ_Date == _cdate
                           select _c;
                if (find == null || find.Count() < 1)
                {
                    Appointment _ap = new Appointment(AppointmentType.Normal, _cdate, new TimeSpan(24, 0, 0), "统计上报日");
                    _ap.LabelId = 1;
                    this.schedulerStorage1.Appointments.Add(_ap);
                }
            }
            #endregion
        }

        private void te_CurrentYear_EditValueChanged(object sender, EventArgs e)
        {
            if (this._initFinished)
            {
                LoadData();
            }
        }

        private void schedulerControl1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime _dt = this.schedulerControl1.SelectedInterval.Start;
            this.te_RQ.EditValue = _dt.ToString("yyyy年MM月dd日");
            if (DateList != null)
            {
                var _find = from _c in DateList
                            where _c.GZ_Date == _dt
                            select _c;
                if (_find != null && _find.Count() > 0)
                {
                    WC_DataInfo _dc = _find.First();
                    this.te_IsWorkDay.Checked = _dc.IsWorkDay;
                    this.te_IsFXSBR.Checked = _dc.IsFXSBR;
                    this.te_IsTJSBR.Checked = _dc.IsTJSBR;
                    this.te_Des.EditValue = _dc.Meta;
                }
                else
                {
                    this.te_IsWorkDay.Checked = CheckDateIsWorkDay(_dt);
                    this.te_IsFXSBR.Checked = false;
                    this.te_IsTJSBR.Checked = (_dt.Day == TJSB_Setting.SBDay);
                    this.te_Des.EditValue = "";
                }
            }
            else
            {
                this.te_IsWorkDay.Checked = CheckDateIsWorkDay(_dt);
                this.te_IsFXSBR.Checked = false;
                this.te_IsTJSBR.Checked = false;
                this.te_Des.EditValue = "";
            }
        }

        private bool CheckDateIsWorkDay(DateTime _dt)
        {
            if (DateList != null)
            {
                var _find = from _c in DateList
                            where _c.GZ_Date == _dt
                            select _c;
                if (_find != null && _find.Count() > 0)
                {
                    WC_DataInfo _dc = _find.First();
                    return _dc.IsWorkDay;
                }
                else
                {
                    return (_dt.DayOfWeek != DayOfWeek.Sunday && _dt.DayOfWeek != DayOfWeek.Saturday);
                }
            }
            else
            {
                return (_dt.DayOfWeek != DayOfWeek.Sunday && _dt.DayOfWeek != DayOfWeek.Saturday);
            }

        }

        private void schedulerControl1_CustomDrawTimeCell(object sender, CustomDrawObjectEventArgs e)
        {
            SelectableIntervalViewInfo viewInfo = e.ObjectInfo as SelectableIntervalViewInfo;
            SchedulerViewCellBase cell = e.ObjectInfo as SchedulerViewCellBase;
            DateTime CurrentDt = viewInfo.Interval.Start;
            if (viewInfo.Selected)
            {
                //e.Cache.FillRectangle(SystemBrushes.Highlight, cell.Bounds);
                e.Handled = false;
            }
            else
            {
                if (CheckDateIsWorkDay(CurrentDt))
                {
                    Color _ShowColor = Color.LightCyan;
                    if (Convert.ToBoolean(CurrentDt.Month % 2))
                    {
                        _ShowColor = Color.LightBlue;
                    }
                    FillGradient(e.Cache, cell.Bounds, _ShowColor, _ShowColor, 45);
                    FillGradient(e.Cache, cell.ContentBounds, _ShowColor, _ShowColor, 45);
                    FillGradient(e.Cache, cell.TopBorderBounds, Color.Gray, Color.Gray, 45);
                    FillGradient(e.Cache, cell.RightBorderBounds, Color.Gray, Color.Gray, 45);
                    FillGradient(e.Cache, cell.LeftBorderBounds, Color.Gray, Color.Gray, 45);
                    FillGradient(e.Cache, cell.BottomBorderBounds, Color.Gray, Color.Gray, 45);
                    e.Handled = true;
                }
                else
                {
                    Color _ShowColor = Color.MistyRose;
                    if (Convert.ToBoolean(CurrentDt.Month % 2))
                    {
                        _ShowColor = Color.PeachPuff;
                    }
                    FillGradient(e.Cache, cell.Bounds, _ShowColor, _ShowColor, 45);
                    FillGradient(e.Cache, cell.ContentBounds, _ShowColor, _ShowColor, 45);
                    FillGradient(e.Cache, cell.TopBorderBounds, Color.Gray, Color.Gray, 45);
                    FillGradient(e.Cache, cell.RightBorderBounds, Color.Gray, Color.Gray, 45);
                    FillGradient(e.Cache, cell.LeftBorderBounds, Color.Gray, Color.Gray, 45);
                    FillGradient(e.Cache, cell.BottomBorderBounds, Color.Gray, Color.Gray, 45);
                    e.Handled = true;
                }
            }

        }

        void FillGradient(GraphicsCache cache, Rectangle r, Color c1, Color c2, int angle)
        {
            if (r.Width <= 0 || r.Height <= 0)
                return;

            using (LinearGradientBrush br = new LinearGradientBrush(r, c1, c2, angle))
            {
                cache.FillRectangle(br, r);
            }
        }



    }
}