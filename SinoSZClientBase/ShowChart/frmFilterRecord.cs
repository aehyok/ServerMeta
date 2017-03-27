using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;

namespace SinoSZClientBase.ShowChart
{
        public partial class frmFilterRecord : DevExpress.XtraEditors.XtraForm
        {
                public DataTable SelectedData = null;
                private DataTable SourceData = null;
                private List<string> XFields = null;
                public frmFilterRecord()
                {
                        InitializeComponent();
                }

                public frmFilterRecord(DataTable _sourcedt,List<string> _xfields)
                {
                        InitializeComponent();
                        SourceData = _sourcedt;
                        XFields = _xfields;
                        InitSource();
                }

                private void InitSource()
                {
                        DataTable _newdt = SourceData.Copy();
                        _newdt.Columns.Add("IsDataSelected",typeof(bool));
                        foreach(DataRow  _dr in _newdt.Rows)
                        {
                                _dr["IsDataSelected"] = true;
                        }
                        _newdt.AcceptChanges();

                        foreach (string _fn in XFields)
                        {
                                DataColumn _dc = SourceData.Columns[_fn];
                                if (_dc != null)
                                {
                                        GridColumn _gc = this.gridView1.Columns.Add();
                                        _gc.Caption = _dc.Caption;
                                        _gc.FieldName = _dc.ColumnName;
                                        _gc.OptionsColumn.AllowFocus = true;
                                        _gc.OptionsColumn.AllowGroup = DefaultBoolean.True;
                                        _gc.OptionsColumn.AllowIncrementalSearch = true;
                                        _gc.OptionsColumn.AllowMerge = DefaultBoolean.True;
                                        _gc.OptionsColumn.AllowMove = true;
                                        _gc.OptionsColumn.AllowSize = true;
                                        _gc.OptionsColumn.AllowSort = DefaultBoolean.True;
                                        _gc.OptionsColumn.ReadOnly = true;
                                        _gc.OptionsColumn.ShowCaption = true;
                                        _gc.OptionsColumn.ShowInCustomizationForm = true;
                                        _gc.OptionsColumn.ReadOnly = true;
                                        _gc.Visible = true;
                                        _gc.Width = 200;
                                        _gc.VisibleIndex = gridView1.Columns.Count;
                                }
                        }

                        this.sinoCommonGrid1.DataSource = _newdt;
                }


                private void AddSelectedData()
                {
                        this.gridView1.PostEditor();
                        SelectedData = SourceData.Clone();
                        DataTable _dt = this.sinoCommonGrid1.DataSource as DataTable;
                        foreach (DataRow _dr in _dt.Rows)
                        {
                                bool _selected = (bool)_dr["IsDataSelected"];
                                if (_selected)
                                {
                                        DataRow _newrow = SelectedData.NewRow();
                                        foreach (DataColumn _dc in SourceData.Columns)
                                        {
                                                _newrow[_dc.ColumnName] = _dr[_dc.ColumnName];
                                        }
                                        SelectedData.Rows.Add(_newrow);
                                }
                        }
                }

                private void simpleButton2_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                }

                private void simpleButton1_Click(object sender, EventArgs e)
                {
                        AddSelectedData();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                }

                private void checkEdit1_CheckedChanged(object sender, EventArgs e)
                {
                        bool _check = this.checkEdit1.Checked;
                        this.gridView1.BeginUpdate();
                        DataTable _dt = this.sinoCommonGrid1.DataSource as DataTable;
                        foreach (DataRow _dr in _dt.Rows)
                        {
                                _dr["IsDataSelected"] = _check;
                        }
                        _dt.AcceptChanges();
                        this.gridView1.EndUpdate();
                }


        }
}