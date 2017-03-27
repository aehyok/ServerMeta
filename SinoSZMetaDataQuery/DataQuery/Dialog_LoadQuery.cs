using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.Authorize;
using SinoSZClientBase.MetaDataQueryService;

namespace SinoSZMetaDataQuery.DataQuery
{
        public partial class Dialog_LoadQuery : DevExpress.XtraEditors.XtraForm
        {
                private string QueryModelName = "";
                public Dialog_LoadQuery()
                {
                        InitializeComponent();
                }

                public Dialog_LoadQuery(string queryModelName)
                {
                        InitializeComponent();
                        QueryModelName = queryModelName;
                        InitData();
                }

                public string SelectedID
                {
                        get
                        {
                                if (this.gridView1.FocusedRowHandle >= 0)
                                {
                                        DataRow _dr = this.gridView1.GetDataRow(this.gridView1.FocusedRowHandle);
                                        return _dr.IsNull("ID") ? "" : _dr["ID"].ToString();
                                }
                                else
                                {
                                        return "";
                                }
                        }
                }
                private void InitData()
                {
                    using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                    {
                        DataTable _dt = _msc.GetSaveQueryList(QueryModelName);
                        this.sinoCommonGrid1.DataSource = _dt;
                        ChangeDelButtonState();
                    }
                }

                private void simpleButton1_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                }

                private void simpleButton2_Click(object sender, EventArgs e)
                {
                        if (SelectedID != "")
                        {
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                        }
                        else
                        {
                                XtraMessageBox.Show("请选择要调用的查询!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                }

                private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
                {
                        ChangeDelButtonState();
                }

                private void ChangeDelButtonState()
                {
                        if (this.gridView1.RowCount < 1 || this.gridView1.FocusedRowHandle < 0)
                        {
                                this.bt_Del.Enabled = false;
                                return;
                        }
                        DataRow _dr = this.gridView1.GetDataRow(this.gridView1.FocusedRowHandle);
                        string _saveUser = _dr["YHID"].ToString();

                        this.bt_Del.Enabled = (_saveUser == SessionClass.CurrentSinoUser.UserID);


                }

                private void bt_Del_Click(object sender, EventArgs e)
                {
                        if (this.gridView1.RowCount < 1 || this.gridView1.FocusedRowHandle < 0)
                        {
                                return;
                        }

                        int _index = this.gridView1.FocusedRowHandle;
                        DataRow _dr = this.gridView1.GetDataRow(_index);
                        string _delid = _dr["ID"].ToString();
                        using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                        {
                            if (_msc.DelSavedQuery(_delid))
                            {
                                XtraMessageBox.Show("删除成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                this.gridView1.DeleteRow(_index);

                            }
                        }
                }
        }
}