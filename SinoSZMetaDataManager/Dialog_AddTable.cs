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
        public partial class Dialog_AddTable : DevExpress.XtraEditors.XtraForm
        {
                private MD_Namespace _namespace;

                public Dialog_AddTable()
                {
                        InitializeComponent();
                }

                public Dialog_AddTable(MD_Namespace _ns)
                {
                        InitializeComponent();
                        _namespace = _ns;
                        InitTableList();
                }

                private void InitTableList()
                {
                    using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
                    {
                        IList<DB_TableMeta> _tlist = _mdc.GetDBTableList();
                        this.gridControl1.DataSource = _tlist;
                    }
                }

                private void simpleButton1_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();

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

                public bool SaveData()
                {
                        //保存新加表
                        int _index = this.gridView1.FocusedRowHandle;
                        if (_index >= 0)
                        {
                            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
                            {
                                DB_TableMeta _tm = (DB_TableMeta)this.gridView1.GetRow(_index);
                                return _mdc.SaveNewTable(_tm, _namespace);
                            }
                                
                        }
                        return false;


                }
        }
}