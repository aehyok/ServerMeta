using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using System.Linq;
using SinoSZJS.Base.MetaData.Define;
using SinoSZClientBase.MetaDataService;

namespace SinoSZMetaDataManager
{
    public partial class Dialog_AddMainTable : DevExpress.XtraEditors.XtraForm
    {
        private MD_Table _selectedTable = null;
        private MD_QueryModel _queryModel = null;
        private MD_ViewTable _maintTable = null;
        public Dialog_AddMainTable()
        {
            InitializeComponent();
        }

        public Dialog_AddMainTable(MD_QueryModel _qm)
        {
            InitializeComponent();
            _queryModel = _qm;
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                List<MD_Table> _tlist = _mdc.GetTablesAtNamespace(_qm.NamespaceName).ToList<MD_Table>();
                this.gridControl1.DataSource = _tlist;
            }
        }

        public Dialog_AddMainTable(MD_ViewTable _vt)
        {
            InitializeComponent();
            _maintTable = _vt;
            using (MetaDataServiceClient _msc = new MetaDataServiceClient())
            {
                IList<MD_Table> _tlist = _msc.GetTablesAtNamespace(_vt.NamespaceName);
                this.gridControl1.DataSource = _tlist;
            }
        }


        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (this.gridView1.SelectedRowsCount < 0)
            {
                XtraMessageBox.Show("请选择数据表!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int[] _indexs = this.gridView1.GetSelectedRows();
            _selectedTable = this.gridView1.GetRow(_indexs[0]) as MD_Table;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public bool SaveNewData()
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                _mdc.AddMainTableToQueryModel(_queryModel.QueryModelID, _selectedTable);
                return true;
            }
        }

        public bool SaveNewChildTable()
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                _mdc.AddChildTableToQueryModel(_maintTable.QueryModelID, _maintTable.ViewTableID, _selectedTable);
                return true;
            }
        }
    }
}