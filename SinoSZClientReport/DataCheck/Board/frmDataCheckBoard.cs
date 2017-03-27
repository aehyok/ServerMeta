using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZClientBase;
using SinoSZPluginFramework;
using SinoSZClientBase.Export;

namespace SinoSZClientReport.DataCheck.Board
{
    public partial class frmDataCheckBoard : frmBase
    {
        protected DataTable MessageList = new DataTable();
        public frmDataCheckBoard()
        {
            InitializeComponent();
        }

        public override void Init(string _title, string _menuName, object _param)
        {
            this._initFinished = true;
            this.Text = _title;
            QueryList();
            this.RaiseMenuChanged();
            this.timer1.Enabled = true;
        }

        private void QueryList()
        {
            this.panelWait.Visible = true;
            this.backgroundWorker1.RunWorkerAsync();
        }

        public DataRow CurrentRow
        {
            get
            {
                if (this.gridView1.RowCount > 0 && this.gridView1.FocusedRowHandle >= 0)
                {
                    return this.gridView1.GetDataRow(this.gridView1.FocusedRowHandle);
                }
                else
                {
                    return null;
                }
            }
        }



        #region 重载基类的方法

        protected override IList<FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            FrmMenuItem _item;
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();

            FrmMenuGroup _thisGroup = new FrmMenuGroup("审核公告");
            _thisGroup.MenuItems = new List<FrmMenuItem>();

            _item = new FrmMenuItem("查看详细", "查看详细", global::SinoSZClientReport.Properties.Resources.x2, (CurrentRow != null));
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("导出", "导出", global::SinoSZClientReport.Properties.Resources.x3, true);
            _thisGroup.MenuItems.Add(_item);
            _ret.Add(_thisGroup);

            return _ret;
        }

        protected override bool ExcuteCommand(string _cmdName)
        {
            switch (_cmdName)
            {
                case "查看详细":
                    ShowSelected();
                    break;
                case "导出":
                    ExportData();
                    break;
            }
            return true;
        }

        private void ShowSelected()
        {
            if (CurrentRow != null)
            {
                string _ggjlid = CurrentRow["ID"].ToString();
                Dialog_SHMsgInfo _f = new Dialog_SHMsgInfo();
                _f.InitData(_ggjlid);
                if (_f.ShowDialog() == DialogResult.OK && !this.backgroundWorker1.IsBusy)
                {
                    this.backgroundWorker1.RunWorkerAsync();
                }
            }
        }




        private void ExportData()
        {
            SinoSZExport_GridViewData.Export(this.gridView1);
        }



        #endregion

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            using (SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient _rsc = new SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient())
            {
                DataSet _ds = _rsc.GetDataCheckBoardList();
                MessageList = _ds.Tables[0];
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.gridView1.BeginUpdate();
            this.sinoCommonGrid1.DataSource = MessageList;
            this.gridView1.EndUpdate();
            if (this.gridView1.RowCount > 0) this.gridView1.SelectRow(0);
            this.panelWait.Visible = false;
            this.RaiseMenuChanged();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!this.backgroundWorker1.IsBusy)
            {
                this.backgroundWorker1.RunWorkerAsync();
            }

        }

        private void sinoCommonGrid1_DoubleClick(object sender, EventArgs e)
        {
            ShowSelected();
        }


    }
}