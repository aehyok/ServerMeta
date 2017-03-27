using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;

namespace SinoSZMetaDataQuery.AlertMonitor
{
        public partial class SinoSZUC_AlertResult : SinoSZMetaDataQuery.GuideLineQuery.SinoSZUC_GuideLineQueryResult
        {
                public SinoSZUC_AlertResult()
                {
                        InitializeComponent();
                }

                public bool HaveSelected
                {
                        get
                        {
                                int i = 1;
                                DataTable _dt = this.sinoCommonGrid1.DataSource as DataTable;
                                if (_dt == null) return false;

                                object _retObj = _dt.Compute("COUNT(_selected)", "_selected");
                                int _count = (int)_retObj;
                                return (_count > 0);

                        }
                }
                protected override void ShowASNormalGrid()
                {
                        base.ShowASNormalGrid();
                        DataTable _dt = this.sinoCommonGrid1.DataSource as DataTable;
                        _dt.Columns.Add("_selected", typeof(Boolean));
                        foreach (DataRow _dr in _dt.Rows)
                        {
                                _dr["_selected"] = false;
                        }
                        GridColumn _gc = this.gridView1.Columns.Add();
                        _gc.Caption = "Ñ¡Ôñ";
                        _gc.FieldName = "_selected";

                        _gc.Width = 70;
                        _gc.OptionsColumn.ReadOnly = false;
                        _gc.Visible = true;
                        _gc.VisibleIndex = 0;
                        _gc.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;

                        _gc.ColumnEdit = this.repositoryItemCheckEdit1;
                        _gc.Fixed = FixedStyle.Left;

                }
        }
}

