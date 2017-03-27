using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using SinoSZJS.Base.MetaData.Define;
using SinoSZClientBase.MetaDataService;

namespace SinoSZMetaDataManager
{
    public partial class Dialog_AddRefTable : DevExpress.XtraEditors.XtraForm
    {
        private MD_Namespace _namespace;

        public Dialog_AddRefTable()
        {
            InitializeComponent();
        }

        public Dialog_AddRefTable(MD_Namespace _ns)
        {
            InitializeComponent();
            _namespace = _ns;
            InitRefTableList();
        }

        private void InitRefTableList()
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                IList<DB_TableMeta> _tlist = _mdc.GetDBTableListOfDMB();
                this.gridControl1.DataSource = _tlist;
            }
        }

        public bool SaveData()
        {
            //保存新加表
            int _index = this.gridView1.FocusedRowHandle;
            if (_index >= 0)
            {
                DB_TableMeta _tm = (DB_TableMeta)this.gridView1.GetRow(_index);
                using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
                {
                    return _mdc.SaveNewRefTable(_tm, _namespace);
                }

            }
            return false;

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (this.gridView1.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("请选择一个表!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}