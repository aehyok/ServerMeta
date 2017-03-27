using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;

using System.Drawing.Drawing2D;
using DevExpress.Data;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;

using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.DataCompare;
using SinoSZJS.Base.MetaData.Common;

namespace SinoSZMetaDataQuery.Common
{
    public partial class SinoSZUC_GridControlEx_FullRelation : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// 查询请求
        /// </summary>
        protected MDQuery_Request QueryRequest = null;
        /// <summary>
        /// 查询结果字段
        /// </summary>
        protected DataSet QueryResultData = null;
        //查询模型
        protected MDModel_QueryModel QueryModel = null;
        protected Dictionary<string, string> CurrentValues = new Dictionary<string, string>();
        protected Dictionary<string, string> SumSummaryValues = new Dictionary<string, string>();
        protected Dictionary<string, string> CountSummaryValues = new Dictionary<string, string>();
        protected Dictionary<string, string> AvgSummaryValues = new Dictionary<string, string>();
        protected Dictionary<string, string> MaxSummaryValues = new Dictionary<string, string>();
        protected Dictionary<string, string> MinsummaryValues = new Dictionary<string, string>();
        protected Dictionary<string, RealColumnDefine> FieldsDictionary = new Dictionary<string, RealColumnDefine>();

        private string RunErrorMsg = "";
        public SinoSZUC_GridControlEx_FullRelation()
        {
            InitializeComponent();
        }

        #region 属性


        /// <summary>
        /// 设置为只读
        /// </summary>
        public bool ReadOnly
        {
            get { return this._readOnly; }
            set
            {
                this._readOnly = value;
                ChangeColumnReadOnly();
            }
        }
        private bool _readOnly = true;

        /// <summary>
        /// 数据源
        /// </summary>
        public object DataSource
        {
            get { return this.gridControl1.DataSource; }
            set
            {
                this.gridControl1.BeginUpdate();
                this.gridControl1.DataSource = value;
                this.bandedGridView1.IndicatorWidth = this.bandedGridView1.RowCount.ToString().Length * 10 + 15;
                this.gridControl1.EndUpdate();
                ResetSummaryCache();
            }
        }

        /// <summary>
        /// 返回当前显示的视图
        /// </summary>
        public BaseView CurrentView
        {
            get
            {
                if (this.gridControl1.Visible) return this.bandedGridView1 as BaseView;
                return null;
            }
        }

        #endregion


        #region 公有方法
        /// <summary>
        /// 通过查询模型及查询请求建立字段
        /// </summary>
        /// <param name="_request"></param>
        /// <param name="_qv"></param>
        public void ShowQueryResult(MDQuery_Request _request, MDModel_QueryModel _qv, DataSet _data)
        {
            QueryResultData = _data;
            QueryRequest = _request;
            QueryModel = _qv;


            this.bandedGridView1.Columns.Clear();
            this.bandedGridView1.Bands.Clear();

            FieldsDictionary.Clear();

            MDQuery_ResultTable _mtable = QueryRequest.MainResultTable;
            CreateBandColumn(_mtable, DefaultBoolean.True);

            foreach (MDQuery_ResultTable _ctable in QueryRequest.ChildResultTables)
            {
                CreateBandColumn(_ctable, DefaultBoolean.False);
            }


        }


        public void ShowQueryResult(MDCompare_Request _request, MDModel_QueryModel _qv, DataTable _excelResultData)
        {
            //QueryResultData = new DataSet();

            QueryRequest = _request;
            QueryModel = _qv;


            this.bandedGridView1.Columns.Clear();
            this.bandedGridView1.Bands.Clear();

            FieldsDictionary.Clear();

            MDQuery_ResultTable _mtable = QueryRequest.MainResultTable;
            CreateBandColumn(_mtable, DefaultBoolean.True);

            foreach (MDQuery_ResultTable _ctable in QueryRequest.ChildResultTables)
            {
                if (_ctable.TableName != "")
                {
                    CreateBandColumn(_ctable, DefaultBoolean.False);
                }

            }
            CreateExcelBandColumn(_excelResultData);


        }


        #endregion

        #region 私有方法

        /// <summary>
        /// 重置统计数据缓存区
        /// </summary>
        private void ResetSummaryCache()
        {
            this.CurrentValues.Clear();
            this.SumSummaryValues.Clear();
            this.CountSummaryValues.Clear();
            this.AvgSummaryValues.Clear();
            this.MaxSummaryValues.Clear();
            this.MinsummaryValues.Clear();
        }


        /// <summary>
        /// 改变字段的只读属性
        /// </summary>
        private void ChangeColumnReadOnly()
        {
            bool value = this.ReadOnly;
            foreach (BandedGridColumn _gc in this.bandedGridView1.Columns)
            {
                _gc.OptionsColumn.ReadOnly = value;
            }
        }

        /// <summary>
        /// 通过元数据添加Band
        /// </summary>
        /// <param name="_mtable"></param>
        private void CreateBandColumn(MDQuery_ResultTable _resultTable, DefaultBoolean _canSort)
        {
            Font UseFont = null;
            GridBand _band = null;
            try
            {
                _band = this.bandedGridView1.Bands.Add();
                UseFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
                _band.AppearanceHeader.Font = UseFont;
                MDModel_Table _tableDefine = MC_QueryModel.GetTableDefine(QueryModel, _resultTable.TableName);
                _band.Caption = _tableDefine.TableDefine.DisplayTitle;
                int i = 1;
                foreach (MDQuery_TableColumn _rc in _resultTable.Columns)
                {
                    BandedGridColumn _col = this.bandedGridView1.Columns.Add();
                    _col.OptionsColumn.ReadOnly = this.ReadOnly;
                    _col.OptionsColumn.AllowSort = _canSort;
                    _col.Caption = _rc.ColumnTitle;
                    _col.FieldName = _rc.TableName + "_" + _rc.ColumnName;
                    _col.Visible = true;
                    _col.VisibleIndex = i++;
                    _col.Width = 150;
                    FieldsDictionary.Add(_col.FieldName, new RealColumnDefine(_rc.TableName, _rc.ColumnAlias));
                    this.bandedGridView1.Columns.Add(_col);
                    _band.Columns.Add(_col);
                }
                _band = null;
                UseFont = null;
            }
            finally
            {
                if (_band != null)
                {
                    _band.Dispose();
                }
                if (UseFont != null)
                {
                    UseFont.Dispose();
                }
            }

        }

        private void CreateExcelBandColumn(DataTable _excelResultData)
        {
            GridBand _band = this.bandedGridView1.Bands.Add();
            try
            {
                _band.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
                _band.Caption = "EXCEL文件";
                int i = 1;
                foreach (DataColumn _dc in _excelResultData.Columns)
                {
                    if (_dc.ColumnName != "MAINID")
                    {
                        BandedGridColumn _col = this.bandedGridView1.Columns.Add();
                        _col.OptionsColumn.ReadOnly = this.ReadOnly;
                        _col.OptionsColumn.AllowSort = DefaultBoolean.False;
                        _col.Caption = _dc.Caption;
                        _col.FieldName = "EXCEL_" + _dc.ColumnName;
                        _col.Visible = true;
                        _col.VisibleIndex = i++;
                        _col.Width = 150;
                        FieldsDictionary.Add(_col.FieldName, new RealColumnDefine("EXCEL", _dc.ColumnName));
                        this.bandedGridView1.Columns.Add(_col);
                        _band.Columns.Add(_col);
                    }
                }
                _band = null;
            }
            finally
            {
                if (_band != null)
                {
                    _band.Dispose();
                }
            }
        }
        #endregion
        #region 单双行变色
        private void bandedGridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                DataRow _row = this.bandedGridView1.GetDataRow(e.RowHandle);
                try
                {
                    bool isOddRow = (bool)_row["IS_ODD_ROW"];
                    if (isOddRow)
                    {
                        e.Appearance.BackColor = Color.LightCyan;
                        e.Appearance.BackColor2 = Color.LightCyan;
                        e.Appearance.GradientMode = LinearGradientMode.Horizontal;
                    }
                }
                catch (Exception ex)
                {
                    RunErrorMsg = ex.Message;
                }
            }

        }
        #endregion

        #region 行合并处理
        private void bandedGridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            if (e.RowHandle1 == e.RowHandle2)
            {
                e.Merge = false;
                e.Handled = true;
            }
            else
            {
                DataRow _firstRow = this.bandedGridView1.GetDataRow(e.RowHandle1);
                DataRow _secondRow = this.bandedGridView1.GetDataRow(e.RowHandle2);
                try
                {
                    if (_firstRow["ROW_MAINID"].ToString() != _secondRow["ROW_MAINID"].ToString())
                    {
                        e.Merge = false;
                        e.Handled = true;
                    }

                }
                catch (Exception ex)
                {
                    RunErrorMsg = ex.Message;
                }
            }
        }
        #endregion

        #region 底行菜单处理
        private void bandedGridView1_GridMenuItemClick(object sender, DevExpress.XtraGrid.Views.Grid.GridMenuItemClickEventArgs e)
        {
            if (e.SummaryItem == null) return;
            string _fname = e.SummaryItem.FieldName;
            switch (e.SummaryType)
            {
                case DevExpress.Data.SummaryItemType.Count:
                    #region 处理求记录数

                    if (!this.CountSummaryValues.ContainsKey(_fname))
                    {
                        this.CountSummaryValues.Add(_fname, GetCountData(_fname));
                    }
                    if (this.CurrentValues.ContainsKey(_fname))
                    {
                        this.CurrentValues[_fname] = this.CountSummaryValues[_fname];
                    }
                    else
                    {
                        this.CurrentValues.Add(_fname, this.CountSummaryValues[_fname]);
                    }
                    e.SummaryItem.SummaryType = SummaryItemType.None;
                    e.SummaryItem.SummaryType = SummaryItemType.Custom;
                    e.SummaryItem.DisplayFormat = "记录数={0}";
                    e.Handled = true;
                    #endregion
                    break;

                case DevExpress.Data.SummaryItemType.Sum:
                    #region 处理求总数

                    if (!this.SumSummaryValues.ContainsKey(_fname))
                    {
                        this.SumSummaryValues.Add(_fname, GetSumData(_fname));
                    }
                    if (this.CurrentValues.ContainsKey(_fname))
                    {
                        this.CurrentValues[_fname] = this.SumSummaryValues[_fname];
                    }
                    else
                    {
                        this.CurrentValues.Add(_fname, this.SumSummaryValues[_fname]);
                    }

                    e.SummaryItem.SummaryType = SummaryItemType.None;
                    e.SummaryItem.SummaryType = SummaryItemType.Custom;
                    e.SummaryItem.DisplayFormat = "总和={0}";

                    e.Handled = true;
                    #endregion
                    break;
                case DevExpress.Data.SummaryItemType.Average:
                    #region 处理求平均数


                    if (!this.AvgSummaryValues.ContainsKey(_fname))
                    {
                        this.AvgSummaryValues.Add(_fname, GetAvgData(_fname));
                    }
                    if (this.CurrentValues.ContainsKey(_fname))
                    {
                        this.CurrentValues[_fname] = this.AvgSummaryValues[_fname];
                    }
                    else
                    {
                        this.CurrentValues.Add(_fname, this.AvgSummaryValues[_fname]);
                    }
                    e.SummaryItem.SummaryType = SummaryItemType.None;
                    e.SummaryItem.SummaryType = SummaryItemType.Custom;
                    e.SummaryItem.DisplayFormat = "平均数={0}";
                    e.Handled = true;
                    #endregion
                    break;
            }

        }

        #endregion

        #region 对字段进行汇总统计
        /// <summary>
        /// 求平均数
        /// </summary>
        /// <param name="_fname"></param>
        /// <returns></returns>
        private string GetAvgData(string _fname)
        {
            if (this.FieldsDictionary.ContainsKey(_fname))
            {
                RealColumnDefine _col = this.FieldsDictionary[_fname];
                DataTable _dt = this.QueryResultData.Tables[_col.TableName];
                if (_dt.Columns[_col.ColumnName].DataType == typeof(decimal))
                {
                    return _dt.Compute(string.Format("avg({0})", _col.ColumnName), "").ToString();
                }
                return "";
            }
            else
            {
                return "";
            }
        }


        /// <summary>
        /// 求总和
        /// </summary>
        /// <param name="_fname"></param>
        /// <returns></returns>
        private string GetSumData(string _fname)
        {
            if (this.FieldsDictionary.ContainsKey(_fname))
            {
                RealColumnDefine _col = this.FieldsDictionary[_fname];
                DataTable _dt = this.QueryResultData.Tables[_col.TableName];
                if (_dt.Columns[_col.ColumnName].DataType == typeof(decimal))
                {
                    return _dt.Compute(string.Format("sum({0})", _col.ColumnName), "").ToString();
                }
                return "";
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 求总记录数
        /// </summary>
        /// <param name="_fname"></param>
        /// <returns></returns>
        private string GetCountData(string _fname)
        {
            if (this.FieldsDictionary.ContainsKey(_fname))
            {
                RealColumnDefine _col = this.FieldsDictionary[_fname];
                DataTable _dt = this.QueryResultData.Tables[_col.TableName];
                return _dt.Compute(string.Format("count({0})", _col.ColumnName), "").ToString();
            }
            else
            {
                return "";
            }
        }

        #endregion

        #region 显示计算数据
        private void bandedGridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (e.SummaryProcess == CustomSummaryProcess.Start)
            {
                //InitStartValue();
            }
            if (e.SummaryProcess == CustomSummaryProcess.Calculate)
            {
                try
                {
                    GridColumnSummaryItem _obj = e.Item as GridColumnSummaryItem;
                    string _fName = _obj.FieldName;
                    e.TotalValue = CurrentValues[_fName];
                }
                catch
                {
                    e.TotalValue = "";
                }
            }
        }
        #endregion

        #region 显示菜单
        private void bandedGridView1_ShowGridMenu(object sender, DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs e)
        {
            if (e.Menu != null)
            {
                if (e.Menu.Items != null)
                {
                    foreach (DXMenuItem _menu in e.Menu.Items)
                    {
                        _menu.Enabled = true;
                    }
                }
            }
        }
        #endregion

    }

    public struct RealColumnDefine
    {
        public string TableName;
        public string ColumnName;
        public RealColumnDefine(string _tname, string _cname)
        {
            TableName = _tname;
            ColumnName = _cname;
        }
    }
}
