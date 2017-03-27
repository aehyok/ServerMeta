using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.Utils;
using System.Collections;
using DevExpress.Data;



using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors;
using SinoSZMetaDataQuery.PAnalize;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.Common;

namespace SinoSZMetaDataQuery.Common
{
    public partial class SinoSZUC_GridControlEx : UserControl
    {
        //设为只读状态
        protected bool _readOnly = false;
        //以分组排序方式显示
        protected bool _showAsGroupSorting = false;
        //查询请求
        protected MDQuery_Request QueryRequest = null;
        //查询模型
        //protected MDModel_QueryModel QueryModel = null;

        public SinoSZUC_GridControlEx()
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


        /// <summary>
        /// 自动宽度
        /// </summary>
        public bool AutoColumnWidth
        {
            get { return this.gridView1.OptionsView.ColumnAutoWidth; }
            set { this.gridView1.OptionsView.ColumnAutoWidth = value; }
        }

        /// <summary>
        /// 是否已经分组
        /// </summary>
        public bool Grouped
        {
            get { return this.gridView1.GroupCount > 0; }
        }

        /// <summary>
        /// 以分组排序的方式显示
        /// </summary>
        public bool ShowAsGroupSorting
        {
            get { return this._showAsGroupSorting; }
            set
            {
                this._showAsGroupSorting = value;
                ChangeToGroupSortMode(this._showAsGroupSorting);
            }
        }


        /// <summary>
        /// 是否显示分组栏
        /// </summary>
        public bool ShowGroupPanel
        {
            get { return this.gridView1.OptionsView.ShowGroupPanel; }
            set { this.gridView1.OptionsView.ShowGroupPanel = value; }
        }


        /// <summary>
        /// 是否显示底栏
        /// </summary>
        public bool ShowFooter
        {
            get { return this.gridView1.OptionsView.ShowFooter; }
            set { this.gridView1.OptionsView.ShowFooter = value; }
        }

        /// <summary>
        /// 返回当前显示的视图
        /// </summary>
        public BaseView CurrentView
        {
            get
            {
                if (this.gridControl1.Visible) return this.gridView1 as BaseView;
                if (this.gridControl2.Visible) return this.gridView2 as BaseView;
                return null;
            }
        }
        /// <summary>
        /// 数据源
        /// </summary>
        public object DataSource
        {
            get { return this.gridControl1.DataSource; }
            set
            {
                if (value != null)
                {
                    if (value.GetType() == typeof(DataTable))
                    {
                        DataTable _dt = (DataTable)value;
                        if (_dt.ChildRelations.Count > 1) ShowDetialPanel = true;
                    }
                }
                this.gridControl1.DataSource = value;
                this.gridView1.IndicatorWidth = this.gridView1.RowCount.ToString().Length * 10 + 15;
                this.labelControl1.Text = string.Format("共检索到 {0} 条记录!", this.gridView1.RowCount);
            }
        }


        /// <summary>
        /// 显示详情面板
        /// </summary>
        public bool ShowDetialPanel
        {
            set { this.gridView1.OptionsDetail.ShowDetailTabs = value; }
        }

        /// <summary>
        /// 显示筛选面板
        /// </summary>
        public bool ShowFilterPanel
        {
            get { return this.gridView1.OptionsView.ShowFilterPanel; }
            set { this.gridView1.OptionsView.ShowFilterPanel = value; }
        }

        /// <summary>
        /// 当前焦点所在的列(只读)
        /// </summary>
        public GridColumn FocusedColumn
        {
            get { return gridView1.FocusedColumn; }
        }

        /// <summary>
        /// 当前焦虑点所在的格中的值(只读)
        /// </summary>
        public object FocusedValue
        {
            get { return gridView1.FocusedValue; }
        }

        /// <summary>
        /// 当前焦点所在的数据行(只读)
        /// </summary>
        public DataRow FocusedDataRow
        {
            get
            {
                int _rowindex = gridView1.FocusedRowHandle;
                if (_rowindex < 0) return null;
                return gridView1.GetDataRow(_rowindex);
            }
        }

        #endregion



        #region 公共方法


        /// <summary>
        /// 重置序号栏宽度
        /// </summary>
        public void ResetIndicatorColumnWidth()
        {
            this.gridView1.IndicatorWidth = this.gridView1.RowCount.ToString().Length * 10 + 15;
        }


        /// <summary>
        /// 重命名所有字段
        /// </summary>
        public void ReNameColumn()
        {
            DataTable _dt = (DataTable)gridControl1.DataSource;
            if (_dt == null) return;
            foreach (GridColumn _gc in gridView1.Columns)
            {
                _dt.Columns[_gc.FieldName].Caption = _gc.Caption;
            }
            Application.DoEvents();
            ResetDouleClick(gridView1);
        }



        /// <summary>
        /// 自动调整列宽
        /// </summary>
        public void FitColumnWidth()
        {
            this.gridView1.BestFitColumns();
        }

        /// <summary>
        /// 重置双击事件
        /// </summary>
        public void ResetDouleClick()
        {
            ResetDouleClick(this.gridView1);
        }

        /// <summary>
        /// 重置指定GridView的双击事件
        /// </summary>
        /// <param name="_gv"></param>
        public void ResetDouleClick(GridView _gv)
        {
            foreach (GridColumn _gc in _gv.Columns)
            {
                _gc.RealColumnEdit.ResetEvents();
                _gc.RealColumnEdit.DoubleClick += new EventHandler(Cell_DoubleClick);
            }
        }

        /// <summary>
        /// 开始更新
        /// </summary>
        public void BeginUpdate()
        {
            gridControl1.BeginUpdate();
        }

        /// <summary>
        /// 结束更新
        /// </summary>
        public void EndUpdate()
        {
            gridControl1.EndUpdate();
        }

        /// <summary>
        /// 清除所有字段
        /// </summary>
        public void ClearColumns()
        {
            gridView1.Columns.Clear();
            gridView2.Columns.Clear();
            ShowAsGroupSorting = false;
        }

        /// <summary>
        /// 通过查询模型及查询请求建立字段
        /// </summary>
        /// <param name="_request"></param>
        /// <param name="_qv"></param>
        public void ShowQueryResult(MDQuery_Request _request, MDModel_QueryModel _qv)
        {
            QueryRequest = _request;
            //QueryModel = _qv;

            MDQuery_ResultTable _mtable = QueryRequest.MainResultTable;
            foreach (MDQuery_TableColumn _rc in _mtable.Columns)
            {
                GridColumn _gc = AddColumn(_rc.ColumnTitle, _rc.ColumnAlias, _rc.ColumnDataType, _rc.DisplayFormat, _rc.DisplayLength);
                _gc.Tag = _rc;
            }

        }

        public void ShowBlankQueryResult(MDQuery_Request _request)
        {
            QueryRequest = _request;
            MDQuery_ResultTable _mtable = QueryRequest.MainResultTable;
            foreach (MDQuery_TableColumn _rc in _mtable.Columns)
            {
                GridColumn _gc = AddColumn(_rc.ColumnTitle, _rc.ColumnAlias, _rc.ColumnDataType, _rc.DisplayFormat, _rc.DisplayLength);
                _gc.Tag = _rc;
            }
            DataSet _tempDataSet = new DataSet();
            //加主表
            DataTable _mtb = new DataTable();
            _tempDataSet.Tables.Add(_mtb);

            _mtb.Columns.Add("TEMP_MAINID", typeof(string));

            DataRow _newrow = _mtb.NewRow();
            _newrow["TEMP_MAINID"] = "1";
            _mtb.Rows.Add(_newrow);

            //加子表

            foreach (MDQuery_ResultTable _childTD in QueryRequest.ChildResultTables)
            {
                DataTable _ctb = new DataTable();
                _ctb.Columns.Add("MAINID", typeof(string));
                foreach (MDQuery_TableColumn _rc in _childTD.Columns)
                {
                    _ctb.Columns.Add(_rc.ColumnTitle);
                }
                DataRow _cnrow = _ctb.NewRow();
                _cnrow["MAINID"] = "1";
                _ctb.Rows.Add(_cnrow);
                _tempDataSet.Tables.Add(_ctb);
                _tempDataSet.Relations.Add(_childTD.DisplayTitle, _mtb.Columns["TEMP_MAINID"], _ctb.Columns["MAINID"]);
            }
            this.gridControl1.DataSource = _mtb;
            this.gridView1.ExpandMasterRow(0);
        }

        /// <summary>
        /// 添加一个字段
        /// </summary>
        /// <param name="_caption"></param>
        /// <param name="_fieldName"></param>
        /// <param name="_type"></param>
        /// <param name="_format"></param>
        public GridColumn AddColumn(string _caption, string _fieldName, string _type, string _format)
        {
            return AddColumn(_caption, _fieldName, _type, _format, 120);
        }

        /// <summary>
        /// 添加一个字段
        /// </summary>
        /// <param name="_caption"></param>
        /// <param name="_fieldName"></param>
        /// <param name="_type"></param>
        /// <param name="_format"></param>
        /// <param name="_width"></param>
        public GridColumn AddColumn(string _caption, string _fieldName, string _type, string _format, int _width)
        {
            GridColumn _gc;
            _gc = gridView1.Columns.Add();
            _gc.Caption = _caption;
            _gc.FieldName = _fieldName;
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


            if (_format == "")
            {
                if (_type == "DATE")
                {
                    _gc.DisplayFormat.FormatType = FormatType.DateTime;
                    _gc.DisplayFormat.FormatString = "yyyy-MM-dd";
                }

            }
            else
            {
                if (_type == "DATE") _gc.DisplayFormat.FormatType = FormatType.DateTime;
                _gc.DisplayFormat.FormatString = _format;
            }
            _gc.Width = (_width < 80) ? 80 : _width;
            //_gc.Style.WordWrap = true;
            _gc.VisibleIndex = gridView1.Columns.Count;
            return _gc;
        }


        /// <summary>
        /// 是否以分组排序模式
        /// </summary>
        /// <param name="_state"></param>
        public virtual void ChangeToGroupSortMode(bool _state)
        {
            if (_state)
            {
                ChangeToGSMode();
            }
            else
            {
                ChangeToNormal();
            }
        }

        /// <summary>
        /// 以正常方式显示
        /// </summary>
        public virtual void ChangeToNormal()
        {
            gridControl1.Visible = true;
            gridControl2.Visible = false;
        }

        /// <summary>
        /// 隐藏字段(通过字段名)
        /// </summary>
        /// <param name="_fname"></param>
        public void HideColumnByFieldName(string _fname)
        {
            foreach (GridColumn _dc in this.gridView1.Columns)
            {
                if (_dc.FieldName == _fname)
                {
                    _dc.VisibleIndex = -1;
                }
            }
        }

        /// <summary>
        /// 修改字段的属性(通过字段名)
        /// </summary>
        /// <param name="_fname"></param>
        /// <param name="_title"></param>
        /// <param name="_width"></param>
        /// <param name="_index"></param>
        /// <param name="_isCenter"></param>
        public void ChangeColumnAttriteByFieldName(string _fname, string _title, int _width, int _index, bool _isCenter)
        {
            foreach (GridColumn _dc in this.gridView1.Columns)
            {
                if (_dc.FieldName == _fname)
                {
                    _dc.AbsoluteIndex = _index;
                    _dc.VisibleIndex = _index;
                    _dc.Caption = _title;
                    _dc.Width = _width;
                    if (_isCenter)
                    {
                        _dc.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                    }
                    return;
                }
            }
        }

        /// <summary>
        /// 取当前显示的数据
        /// </summary>
        /// <returns></returns>
        public DataTable CurrentData()
        {
            if (_showAsGroupSorting)
            {
                //取分组显示的数据
                DataView _dv = (DataView)gridControl2.DataSource;
                return _dv.Table;
            }
            else
            {
                //取基本数据
                return (DataTable)gridControl1.DataSource;
            }
        }
        /// <summary>
        /// 取当前数据的字段名字典
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> CurrentFieldsDict()
        {
            Dictionary<string, string> _ret = new Dictionary<string, string>();
            if (_showAsGroupSorting)
            {
                //取分组显示的数据
                foreach (GridColumn _dc in gridView2.Columns)
                {
                    _ret.Add(_dc.FieldName, _dc.Caption);
                }

            }
            else
            {
                //取基本数据
                foreach (GridColumn _dc in gridView1.Columns)
                {
                    _ret.Add(_dc.FieldName, _dc.Caption);
                }
            }
            return _ret;
        }

        /// <summary>
        /// 数据导出
        /// </summary>
        public void DataExport()
        {
            //GridExportForm _f;

            //if (gridControl2.Visible)
            //{
            //        _f = new GridExportForm(gridView2);
            //}
            //else
            //{
            //        _f = new GridExportForm(gridView1);
            //}
            //_f.ShowDialog();
        }

        #endregion


        #region 事件定义


        /// <summary>
        /// 双击一行
        /// </summary>
        [Category("WinFormEx")]
        public event EventHandler DataDoubleClicked;

        public void RaiseDataDoubleClicked(EventArgs e)
        {
            if (DataDoubleClicked != null)
                DataDoubleClicked(this, e);
        }


        /// <summary>
        /// 当建立分组后
        /// </summary>
        [Category("WinFormEx")]
        public event EventHandler ColumnGrouped;

        public void RaiseColumnGrouped(EventArgs e)
        {
            if (ColumnGrouped != null)
                ColumnGrouped(this, e);
        }


        /// <summary>
        /// 当清空所有分组字段后
        /// </summary>
        [Category("WinFormEx")]
        public event EventHandler GroupColumnCleared;

        public void RaiseGroupColumnCleared(EventArgs e)
        {
            if (GroupColumnCleared != null)
                GroupColumnCleared(this, e);
        }


        /// <summary>
        /// 当有新视图注册后
        /// </summary>
        [Category("WinFormEx")]
        public event ViewOperationEventHandler ViewRegistered;

        public void RaiseViewRegistered(ViewOperationEventArgs e)
        {
            if (ViewRegistered != null)
                ViewRegistered(this, e);
        }


        #endregion


        #region 私有事件处理


        /// <summary>
        /// 激活双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cell_DoubleClick(object sender, System.EventArgs e)
        {
            GridControlExClickArg _arg = new GridControlExClickArg();
            if (gridView1.SelectedRowsCount > 0)
            {
                DataRow _dr = gridView1.GetDataRow(gridView1.GetSelectedRows()[0]);
                if (_dr != null)
                {
                    _arg.TableName = _dr.Table.TableName;
                    _arg.RowData = _dr;
                }
            }
            _arg.Value = gridView1.FocusedValue;
            if (gridView1.FocusedColumn != null) _arg.Column = gridView1.FocusedColumn.FieldName;
            RaiseDataDoubleClicked(_arg);
        }

        private void gridControl1_ViewRegistered(object sender, DevExpress.XtraGrid.ViewOperationEventArgs e)
        {
            GridView _gv = (GridView)e.View;

            _gv.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(_gv_CustomDrawRowIndicator);
            GridColumn _gcm = _gv.Columns.ColumnByFieldName("MAINID");
            if (_gcm != null)
                _gv.Columns.Remove(_gcm);
            DataView _source = _gv.DataSource as DataView;
            string _tName = _source.Table.TableName;
            foreach (GridColumn _gc in _gv.Columns)
            {
                //待改进                                
                MDQuery_TableColumn _tc = MC_QueryModel.GetColumnDefineByAlias(this.QueryRequest, _tName, _gc.FieldName);
                if (_tc != null)
                {
                    _gc.Caption = _tc.ColumnTitle;
                    _gc.Width = _tc.DisplayLength;
                }
            }
            this.RaiseViewRegistered(e);
        }

        /// <summary>
        /// 绘制行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _gv_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                e.Info.DisplayText = e.RowHandle >= 0 ? (e.RowHandle + 1).ToString() : "";
            }
        }

        private void gridView1_DragObjectDrop(object sender, DevExpress.XtraGrid.Views.Base.DragObjectDropEventArgs e)
        {
            if (gridView1.GroupedColumns.Count > 0)
            {
                RaiseColumnGrouped(new EventArgs());
            }
            else
            {
                RaiseGroupColumnCleared(new EventArgs());
            }
        }


        #endregion


        #region 私有方法

        /// <summary>
        /// 改变字段的只读属性
        /// </summary>
        private void ChangeColumnReadOnly()
        {
            bool value = this.ReadOnly;
            foreach (GridColumn _gc in gridView1.Columns)
            {
                _gc.RealColumnEdit.ReadOnly = value;
            }
            foreach (GridColumn _gc in gridView2.Columns)
            {
                _gc.RealColumnEdit.ReadOnly = value;
            }
        }


        /// <summary>
        /// 以分组排度方式显示
        /// </summary>
        private void ChangeToGSMode()
        {
            if (gridControl1.DataSource == null) return;
            if (gridView1.GroupedColumns.Count < 1) return;

            gridControl1.Visible = false;
            //表名字典
            Hashtable _Gtable = new Hashtable();
            //字段名字典
            Hashtable _GTitle = new Hashtable();
            //分组排序数据集
            DataSet _GSDs = new DataSet();

            #region 复制原数据记录表,以供关联数据使用
            DataTable _sourcedt = ((DataTable)gridControl1.DataSource).Copy();
            _sourcedt.CaseSensitive = true;
            foreach (DataColumn _dc in _sourcedt.Columns)
            {
                if (_dc.ReadOnly) _dc.ReadOnly = false;
            }
            _GSDs.Merge(_sourcedt);
            #endregion


            #region 建分组排序表结构
            int TableCount = 0;
            foreach (GridColumn _gc in gridView1.GroupedColumns)
            {

                DataTable _dt = new DataTable();
                _dt.CaseSensitive = true;
                DataColumn[] keys = new DataColumn[TableCount + 1];
                for (int i = 0; i < TableCount; i++)
                {
                    DataColumn _sdc = (DataColumn)_Gtable[i];
                    DataColumn _dc = _dt.Columns.Add(_sdc.ColumnName, _sdc.DataType);
                    _dc.AllowDBNull = true;
                    _dc.Caption = _sdc.Caption;
                    keys[i] = _dc;
                }
                DataColumn _newColumn = _dt.Columns.Add(_gc.FieldName, _gc.ColumnType);
                _newColumn.AllowDBNull = true;
                _newColumn.ReadOnly = false;
                _newColumn.Caption = _gc.Caption;
                keys[TableCount] = _newColumn;
                _Gtable.Add(TableCount++, _newColumn);
                _GTitle.Add(_gc.FieldName, _gc.Caption);
                _dt.PrimaryKey = keys;
                string _tname = string.Format("Table_{0}", _gc.FieldName);
                _dt.TableName = _tname;
                _GSDs.Merge(_dt);
            }
            #endregion

            #region 加数据
            string _sortstr = "";
            object[] _oldValues = new object[TableCount];
            for (int i = 0; i < TableCount; i++)
            {
                _sortstr += string.Format(",{0}", ((DataColumn)_Gtable[i]).ColumnName);
                _oldValues[i] = null;
            }
            if (_sortstr.Length > 1) _sortstr = _sortstr.Substring(1);

            DataView _rowview = _GSDs.Tables[0].DefaultView;
            _rowview.Sort = _sortstr;

            foreach (DataRowView myDRV in _rowview)
            {
                DataRow _drs = myDRV.Row;

                bool _isold = true;

                try
                {
                    for (int i = 0; i < TableCount; i++)
                    {
                        DataColumn _gCol = (DataColumn)_Gtable[i];
                        string _colname = _gCol.ColumnName;
                        if (_drs.IsNull(_colname))
                        {
                            if (_gCol.DataType == typeof(decimal)) _drs[_colname] = decimal.Zero;
                            if (_gCol.DataType == typeof(string)) _drs[_colname] = "<空值>";
                            if (_gCol.DataType == typeof(DateTime)) _drs[_colname] = DateTime.MinValue;

                        }
                        if (_oldValues[i] == null)
                        {
                            _oldValues[i] = _drs[_colname];
                            _isold = false;
                        }
                        else
                        {
                            if (!_oldValues[i].Equals(_drs[_colname]))
                            {
                                _oldValues[i] = _drs[_colname];
                                _isold = false;
                            }
                        }

                        if (!_isold)
                        {
                            string _tname = string.Format("Table_{0}", _colname);
                            DataTable _dtable = _GSDs.Tables[_tname];
                            DataRow foundRow = _dtable.NewRow();
                            for (int j = 0; j <= i; j++)
                            {
                                string _cn = ((DataColumn)_Gtable[j]).ColumnName;
                                foundRow[_cn] = _drs[_cn];
                            }
                            _dtable.Rows.Add(foundRow);

                        }
                    }

                }
                catch (Exception e)
                {
                    XtraMessageBox.Show(string.Format("分组项目格式非法，无法分组排序。\n描述：{0}", e.Message), "系统提示");
                }
            }
            #endregion

            #region 加关系
            for (int i = 0; i < TableCount; i++)
            {
                DataTable _ctable = null;
                string _rName = string.Format("详细信息{0}", "".PadLeft(i + 1));
                DataTable _ftable = _GSDs.Tables[string.Format("Table_{0}", ((DataColumn)_Gtable[i]).ColumnName)];
                if (i == (TableCount - 1)) _ctable = _GSDs.Tables[0];
                else
                    _ctable = _GSDs.Tables[string.Format("Table_{0}", ((DataColumn)_Gtable[i + 1]).ColumnName)];
                DataColumn[] _CFather = new DataColumn[i + 1];
                DataColumn[] _CChild = new DataColumn[i + 1];
                for (int j = 0; j <= i; j++)
                {
                    DataColumn _gCol = (DataColumn)_Gtable[j];
                    _CFather[j] = _ftable.Columns[_gCol.ColumnName];
                    _CChild[j] = _ctable.Columns[_gCol.ColumnName];
                }
                //DataTableSpyForm _ds = new DataTableSpyForm(_ftable);
                //_ds.ShowDialog();
                _GSDs.Relations.Add(_rName, _CFather, _CChild);
            }
            #endregion

            #region 加计算段

            GridGroupSummaryItemCollection _gsItem = gridView1.GroupSummary;
            foreach (GridSummaryItem _gi in _gsItem)
            {
                if (_gi.SummaryType != SummaryItemType.None)
                {
                    Type _cType = _sourcedt.Columns[_gi.FieldName].DataType;
                    string _normalExp = "", _endExp = "";
                    string _Cfieldname = string.Format("C_{0}", _gi.FieldName);
                    GridColumn _gridCol = gridView1.Columns.ColumnByFieldName(_gi.FieldName);
                    string _CfieldCaption = _gridCol.Caption + "_";

                    switch (_gi.SummaryType)
                    {
                        case SummaryItemType.Average:
                            _CfieldCaption += "平均值";
                            _normalExp = string.Format("Avg(Child.{0})", _Cfieldname);
                            _endExp = string.Format("Avg(Child.{0})", _gi.FieldName);
                            _cType = typeof(Decimal);
                            break;
                        case SummaryItemType.Count:
                            _CfieldCaption += "个数";
                            _normalExp = string.Format("Sum(Child.{0})", _Cfieldname);
                            _endExp = string.Format("Count(Child.MAINID)", _gi.FieldName);
                            _cType = typeof(Decimal);
                            break;
                        case SummaryItemType.Max:
                            _CfieldCaption += "最大值";
                            _normalExp = string.Format("Max(Child.{0})", _Cfieldname);
                            _endExp = string.Format("Max(Child.{0})", _gi.FieldName);
                            _cType = _sourcedt.Columns[_gi.FieldName].DataType;
                            break;
                        case SummaryItemType.Min:
                            _CfieldCaption += "最小值";
                            _normalExp = string.Format("Min(Child.{0})", _Cfieldname);
                            _endExp = string.Format("Min(Child.{0})", _gi.FieldName);
                            _cType = _sourcedt.Columns[_gi.FieldName].DataType;
                            break;
                        case SummaryItemType.Sum:
                            _CfieldCaption += "总和";
                            _normalExp = string.Format("Sum(Child.{0})", _Cfieldname);
                            _endExp = string.Format("Sum(Child.{0})", _gi.FieldName);
                            _cType = typeof(Decimal);
                            break;
                        case SummaryItemType.None:
                            _CfieldCaption += "";
                            _normalExp = "";
                            _endExp = "";
                            break;
                    }
                    if (_GTitle[_Cfieldname] == null) _GTitle.Add(_Cfieldname, _CfieldCaption);
                    for (int i = (TableCount - 1); i >= 0; i--)
                    {
                        DataColumn _ncol = null;
                        DataTable _dt2 = _GSDs.Tables[string.Format("Table_{0}", ((DataColumn)_Gtable[i]).ColumnName)];
                        if (i < (TableCount - 1))
                            _ncol = _dt2.Columns.Add(_Cfieldname, _cType, _normalExp);
                        else
                            _ncol = _dt2.Columns.Add(_Cfieldname, _cType, _endExp);
                        _ncol.Caption = _GTitle[_Cfieldname].ToString();

                    }
                }

            }

            #endregion

            DataViewManager dvManager = new DataViewManager(_GSDs);
            string _tname1 = string.Format("Table_{0}", ((DataColumn)_Gtable[0]).ColumnName);
            DataView dv = dvManager.CreateDataView(_GSDs.Tables[_tname1]);
            gridView2.Columns.Clear();
            gridControl2.DataSource = dv;
            this.gridView2.IndicatorWidth = this.gridView2.RowCount.ToString().Length * 10 + 20;
            foreach (GridColumn _dcc in gridView2.Columns)
            {
                if (_GTitle[_dcc.FieldName] != null) _dcc.Caption = _GTitle[_dcc.FieldName].ToString();
                _dcc.BestFit();
                _dcc.OptionsColumn.ReadOnly = true;
            }
            gridControl2.Visible = true;
        }

        //子记录表注册显示
        private void gridControl2_ViewRegistered(object sender, ViewOperationEventArgs e)
        {
            GridView _gv = e.View as GridView;
            _gv.ViewCaption = "详细信息";
            _gv.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(_gv_CustomDrawRowIndicator);
            GridColumn _gcm = _gv.Columns.ColumnByFieldName("MAINID");
            if (_gcm != null) _gv.Columns.Remove(_gcm);
            DataView _source = _gv.DataSource as DataView;
            string _tName = _source.Table.TableName;
            foreach (GridColumn _gc in _gv.Columns)
            {
                //待改进                                
                MDQuery_TableColumn _tc = MC_QueryModel.GetColumnDefineByAlias(this.QueryRequest, _tName, _gc.FieldName);
                if (_tc != null)
                {
                    _gc.Caption = _tc.ColumnTitle;
                    _gc.Width = _tc.DisplayLength;
                }
                else
                {
                    _gc.Caption = _source.Table.Columns[_gc.FieldName].Caption;
                }
                _gc.BestFit();
                _gc.OptionsColumn.ReadOnly = true;
            }
            _gv.IndicatorWidth = _gv.RowCount.ToString().Length * 10 + 20;
            this.RaiseViewRegistered(e);
        }

        #endregion










    }
}
