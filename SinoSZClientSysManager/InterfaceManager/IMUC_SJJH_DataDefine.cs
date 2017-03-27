using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.SystemInterface;

namespace SinoSZClientSysManager.InterfaceManager
{
    public partial class IMUC_SJJH_DataDefine : DevExpress.XtraEditors.XtraUserControl
    {
        private string _yhm = "";
        private List<SystemICS_SJJH_DataTable> TableList = null;

        private SystemICS_SJJH_Node _toBeQuery = null;
        public IMUC_SJJH_DataDefine()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            this.gridView1.BeginUpdate();
            this.gridView2.BeginUpdate();
            this.sinoCommonGrid1.DataSource = null;
            this.sinoCommonGrid2.DataSource = null;
            this.gridView1.EndUpdate();
            this.gridView2.EndUpdate();
        }

        public void ShowInfo(SystemICS_SJJH_Node _selectedItem)
        {
            _toBeQuery = _selectedItem;
            if (!this.backgroundWorker1.IsBusy)
            {
                QueryData();
            }
        }

        private void QueryData()
        {
            if (_toBeQuery != null)
            {
                lock (_toBeQuery)
                {
                    _yhm = _toBeQuery.UserName;
                    _toBeQuery = null;
                }
                if (!this.backgroundWorker1.IsBusy)
                {
                    this.panelWait.Visible = true;
                    this.backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //SinoSZClientBase.CommonService.CommonServiceClient _csc = new SinoSZClientBase.CommonService.CommonServiceClient();
            //    TableList = _csc.GetSJJHTableList(_yhm);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_toBeQuery != null)
            {
                QueryData();
            }
            else
            {
                this.gridView1.BeginUpdate();
                this.sinoCommonGrid1.DataSource = TableList;
                this.gridView1.EndUpdate();
                ShowColumns();
                this.panelWait.Visible = false;
            }
        }

        private void ShowColumns()
        {
            if (TableList.Count < 0 || this.gridView1.FocusedRowHandle < 0)
            {
                this.gridView2.BeginUpdate();
                this.sinoCommonGrid2.DataSource = null;
                this.gridView2.EndUpdate();
                return;
            }
            int _index = this.gridView1.FocusedRowHandle;
            SystemICS_SJJH_DataTable _selectedTable = this.gridView1.GetRow(_index) as SystemICS_SJJH_DataTable;
            this.gridView2.BeginUpdate();
            this.sinoCommonGrid2.DataSource = _selectedTable.Columns;
            this.gridView2.EndUpdate();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ShowColumns();
        }


    }
}
