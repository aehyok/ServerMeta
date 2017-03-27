using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZPluginFramework;
using SinoSZJS.Base.UserLog;
using SinoSZClientBase.Export;
using System.Linq;

namespace SinoSZClientSysManager.UserLog
{
    public partial class frmUserLog : DevExpress.XtraEditors.XtraForm, IChildForm
    {
        private IApplication _application = null;
        private bool _initFinished = false;

        public frmUserLog()
        {
            InitializeComponent();
        }


        #region 实现IChildForm接口

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
            FrmMenuPage _page = new FrmMenuPage("用户日志");
            _page.MenuGroups = GetMenuGroups(_page.PageTitle);
            _ret.Add(_page);
            return _ret;
        }

        private IList<FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();

            FrmMenuGroup _thisGroup = new FrmMenuGroup("用户操作功能");

            _thisGroup.MenuItems = new List<FrmMenuItem>();
            FrmMenuItem _item = new FrmMenuItem("查询日志", "查询日志", global::SinoSZClientSysManager.Properties.Resources.b28, true);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("导出日志", "导出日志", global::SinoSZClientSysManager.Properties.Resources.x3, true);
            _thisGroup.MenuItems.Add(_item);

            //_item = new FrmMenuItem("清除日志", "清除日志", global::SinoSZClientSysManager.Properties.Resources.e17, true);
            //_thisGroup.MenuItems.Add(_item);

            _ret.Add(_thisGroup);
            return _ret;
        }


        public bool DoCommand(string _cmdName)
        {
            switch (_cmdName)
            {
                case "查询日志":
                    QueryUserLog();
                    break;
                case "导出日志":
                    ExportLog();
                    break;
                case "清除日志":

                    break;

            }

            return true;
        }

        private void ExportLog()
        {
            SinoSZExport_GridViewData.Export(this.gridView1);
        }

        private void QueryUserLog()
        {
            List<UserLogRecord> _logList;
            DateTime _startDate = (DateTime)this.dateEdit1.EditValue;
            DateTime _endDate = (DateTime)this.dateEdit2.EditValue;
            string _userName = (this.textEdit1.EditValue == null) ? "" : this.textEdit1.EditValue.ToString().Trim();
            string _context = (this.textEdit2.EditValue == null) ? "" : this.textEdit2.EditValue.ToString().Trim();
            using (SinoSZClientBase.CommonService.CommonServiceClient _csc = new SinoSZClientBase.CommonService.CommonServiceClient())
            {
                _logList = _csc.GetUserLog(_startDate, _endDate, _userName, _context).ToList<UserLogRecord>();
            }
            this.sinoCommonGrid1.DataSource = _logList;
            this.gridView1.IndicatorWidth = this.gridView1.RowCount.ToString().Length * 8 + 15;
            RaiseMenuChanged();
        }







        #endregion

        private void frmUserLog_Load(object sender, EventArgs e)
        {
            DateTime _dt = DateTime.Now;
            this.dateEdit1.EditValue = new DateTime(_dt.Year, _dt.Month, 1);
            this.dateEdit2.EditValue = (new DateTime(_dt.Year, _dt.Month, 1)).AddMonths(1);
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                e.Info.DisplayText = e.RowHandle >= 0 ? (e.RowHandle + 1).ToString() : "";
            }
        }

    }
}