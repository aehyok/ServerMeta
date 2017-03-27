using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Linq;
using SinoSZPluginFramework;
using SinoSZClientBase.ShowChart;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Repository;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.Common;
using SinoSZClientBase.MetaDataQueryService;

namespace SinoSZMetaDataQuery.GuideLineQuery
{
    public partial class SinoSZUC_GuideLineQueryResult : DevExpress.XtraEditors.XtraUserControl
    {
        protected volatile bool _isQuerying = false;
        protected bool _haveResult = false;
        protected MD_GuideLine _guideLineDefine = null;
        protected DataTable _ResultTable = null;
        protected Dictionary<string, MD_GuideLineDetailDefine> _detailDict = new Dictionary<string, MD_GuideLineDetailDefine>();
        protected List<string> _LinkColumnList = new List<string>();
        protected List<MDQuery_GuideLineParameter> QueryParameter = null;
        protected Dictionary<string, string> FieldsDict = new Dictionary<string, string>();
        protected List<string> MergeColumns = new List<string>();
        public SinoSZUC_GuideLineQueryResult()
        {
            InitializeComponent();
        }
        #region 自定义属性
        /// <summary>
        /// 是否显示分组字段
        /// </summary>
        [Category("WinFormEx")]
        public bool CanGrouped
        {
            get
            {
                return this.gridView1.OptionsView.ShowGroupPanel;
            }
            set
            {
                if (this.gridView1.OptionsView.ShowGroupPanel == value) return;
                this.gridView1.OptionsView.ShowGroupPanel = value;
                this.bandedGridView1.OptionsView.ShowGroupPanel = value;
            }
        }

        public bool IsQuerying
        {
            get { return _isQuerying; }
        }

        public bool HaveResult
        {
            get { return _haveResult; }
        }

        public DataTable ResultData
        {
            get
            {
                return _ResultTable;
            }
        }
        public DataRow FocusedRowData
        {
            get
            {
                if (this.sinoCommonGrid1.Visible)
                {
                    int _index = this.gridView1.FocusedRowHandle;
                    if (_index >= 0)
                    {
                        DataRow _dr = this.gridView1.GetDataRow(_index);
                        return _dr;
                    }
                }
                if (this.sinoCommonGrid2.Visible)
                {
                    int _index = this.bandedGridView1.FocusedRowHandle;
                    if (_index >= 0)
                    {
                        DataRow _dr = this.bandedGridView1.GetDataRow(_index);
                        return _dr;
                    }
                }
                return null;
            }
        }

        public BaseView CurrentView
        {
            get
            {
                if (this.sinoCommonGrid1.Visible)
                {
                    return this.gridView1 as BaseView;
                }
                if (this.sinoCommonGrid2.Visible)
                {
                    return this.bandedGridView1 as BaseView;
                }
                return null;
            }
        }
        #endregion


        #region 自定义事件

        [Category("WinFormEx")]
        public event EventHandler ShowDetailData;
        protected void RaiseShowDetailDatal(ShowDetailDataArgs _args)
        {
            if (ShowDetailData != null)
                ShowDetailData(this, _args);
        }
        [Category("WinFormEx")]
        public event EventHandler QueryFinished;
        protected void RaiseQueryFinished()
        {
            if (QueryFinished != null) QueryFinished(this, new EventArgs());
        }

        [Category("WinFormEx")]
        public event EventHandler FocusRowChanged;
        protected void RaiseFocusRowChanged()
        {
            if (FocusRowChanged != null) FocusRowChanged(this, new EventArgs());
        }

        [Category("WinFormEx")]
        public event EventHandler DataChanged;
        protected void RaiseDataChanged()
        {
            if (DataChanged != null) DataChanged(this, new EventArgs());
        }


        #endregion




        #region 公共属性

        public void ShowGuideLineResult(MD_GuideLine _glDefine, List<MDQuery_GuideLineParameter> _queryParameter)
        {
            this.te_des.Visible = false;
            if (this.backgroundWorker1.IsBusy) return;
            _guideLineDefine = _glDefine;
            QueryParameter = _queryParameter;
            if (_glDefine != null)
            {
                this._isQuerying = true;
                this.progressBarControl1.Visible = true;
                this.progressBarControl1.Position = 1;
                this.labelStatus.Text = " 正在查询数据...";
                this.timer1.Enabled = true;
                this.sinoCommonGrid1.Visible = true;
                this.sinoCommonGrid2.Visible = false;
                this.sinoCommonGrid1.DataSource = null;
                this.gridView1.Columns.Clear();
                if (_guideLineDefine.Description == "")
                {
                    this.te_des.Visible = false;
                }
                else
                {
                    this.te_des.Visible = true;
                    this.memo_des.EditValue = _guideLineDefine.Description;
                }
                this.backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                RaiseQueryFinished();
            }
        }


        public void ShowAsChart(IApplication _application)
        {
            frmChartShow _f = new frmChartShow(_ResultTable, FieldsDict);
            _application.AddForm(Guid.NewGuid().ToString(), _f);
        }

        #endregion

        #region 显示数据
        public void ShowData()
        {
            List<MD_GuideLineFieldGroup> _gList = MC_GuideLine.GetFieldGroupsFromMeta(_guideLineDefine.GuideLineMeta);
            _detailDict = MC_GuideLine.GetDetailDefineDict(_guideLineDefine.GuideLineMeta);
            if (_gList.Count < 2)
            {
                ShowASNormalGrid();
            }
            else
            {
                ShowASBandGrid(_gList);
            }

        }

        virtual protected void ShowASBandGrid(List<MD_GuideLineFieldGroup> _gList)
        {
            this.bandedGridView1.Bands.Clear();
            this.bandedGridView1.Columns.Clear();
            FieldsDict.Clear();
            foreach (MD_GuideLineFieldGroup _group in _gList)
            {
                CreateBandColumn(_group);
            }

            if (this.MergeColumns.Count > 0)
            {
                this.bandedGridView1.OptionsView.AllowCellMerge = true;
            }
            else
            {
                this.bandedGridView1.OptionsView.AllowCellMerge = false;
            }

            this.sinoCommonGrid1.Visible = false;
            this.sinoCommonGrid2.Visible = true;

            this.sinoCommonGrid2.DataSource = _ResultTable;

            this.bandedGridView1.IndicatorWidth = _ResultTable.Rows.Count.ToString().Length * 10 + 15;
        }

        /// <summary>
        /// 通过元数据添加Band
        /// </summary>
        /// <param name="_mtable"></param>
        virtual protected void CreateBandColumn(MD_GuideLineFieldGroup _group)
        {

            GridBand _band = this.bandedGridView1.Bands.Add();
            _band.ImageIndex = 0;
            //_band.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            switch (_group.TextAlign)
            {
                case "CENTER":
                    _band.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                    break;
                case "RIGHT":
                    _band.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Far;
                    break;
                default:
                    _band.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
            }

            _band.Caption = _group.DisplayTitle;
            _band.Tag = _group;

            int i = 1;
            foreach (MD_GuideLineFieldName _fn in _group.Fields)
            {
                BandedGridColumn _col = this.bandedGridView1.Columns.Add();
                SetColumnTextAlign(_col, _fn);
                SetColumnDisplayFormat(_col, _fn);
                _col.OptionsColumn.ReadOnly = true;
                _col.OptionsColumn.AllowSort = DefaultBoolean.True;
                _col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;

                _col.Caption = _fn.DisplayTitle;
                _col.FieldName = _fn.FieldName.ToUpper();
                _col.Visible = true;
                _col.VisibleIndex = i++;
                _col.Width = _fn.DisplayWidth;
                _col.Tag = _fn;
                this.bandedGridView1.Columns.Add(_col);
                _band.Columns.Add(_col);
                if (!FieldsDict.ContainsKey(_fn.FieldName))
                {
                    if (_group.DisplayTitle == "")
                    {
                        FieldsDict.Add(_fn.FieldName, _fn.DisplayTitle);
                    }
                    else
                    {
                        FieldsDict.Add(_fn.FieldName, string.Format("{0}_{1}", _group.DisplayTitle, _fn.DisplayTitle));
                    }
                }

                if (MergeColumns.Contains(_fn.FieldName))
                {
                    _col.OptionsColumn.AllowMerge = DefaultBoolean.True;
                }
                else
                {
                    _col.OptionsColumn.AllowMerge = DefaultBoolean.False;
                }

            }

            if (_group.CanHide)
            {
                _band.ImageIndex = 0;
                _band.ImageAlignment = StringAlignment.Far;

                bool _needblank = true;
                foreach (MD_GuideLineFieldName _fn in _group.Fields)
                {
                    if (!_fn.CanHide) _needblank = false;
                }

                if (_needblank)
                {
                    //添加一个空列
                    BandedGridColumn _blankCol = this.bandedGridView1.Columns.Add();
                    _blankCol.OptionsColumn.ReadOnly = true;
                    _blankCol.OptionsColumn.AllowSort = DefaultBoolean.False;
                    _blankCol.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;

                    _blankCol.Caption = "...";
                    _blankCol.FieldName = "_BlankData";
                    _blankCol.Visible = false;
                    _blankCol.Width = 30;
                    this.bandedGridView1.Columns.Add(_blankCol);
                    _band.Columns.Add(_blankCol);
                }

                if (_group.DefaultStatus == "HIDE")
                {
                    ChangeBandStatus(_band);
                }
            }
            else
            {
                _band.ImageIndex = -1;
            }

        }


        /// <summary>
        /// 设置显示格式
        /// </summary>
        /// <param name="_col"></param>
        /// <param name="_fn"></param>
        protected void SetColumnDisplayFormat(GridColumn _col, MD_GuideLineFieldName _fn)
        {
            _col.OptionsColumn.AllowFocus = true;
            _col.OptionsColumn.AllowGroup = DefaultBoolean.True;
            _col.OptionsColumn.AllowIncrementalSearch = true;
            _col.OptionsColumn.AllowMerge = DefaultBoolean.True;
            _col.OptionsColumn.AllowMove = true;
            _col.OptionsColumn.AllowSize = true;
            _col.OptionsColumn.AllowSort = DefaultBoolean.True;
            _col.OptionsColumn.ReadOnly = true;
            _col.OptionsColumn.ShowCaption = true;
            _col.OptionsColumn.ShowInCustomizationForm = true;
            _col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;


            if (_fn.DisplayFormat.Trim().Length > 0)
            {
                string[] _fs = _fn.DisplayFormat.Split(',');
                switch (_fs[0])
                {
                    case "D":
                        _col.DisplayFormat.FormatType = FormatType.DateTime;
                        _col.DisplayFormat.FormatString = _fs[1];
                        break;
                    case "N":
                        _col.DisplayFormat.FormatType = FormatType.Numeric;
                        _col.DisplayFormat.FormatString = _fs[1];
                        break;
                }
            }

            if (_detailDict.ContainsKey(_fn.FieldName))
            {
                //_col.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                _col.AppearanceCell.ForeColor = Color.Blue;
                _col.AppearanceCell.Options.UseFont = true;
                _col.OptionsColumn.AllowEdit = false;
                _LinkColumnList.Add(_fn.FieldName);
            }

        }


        /// <summary>
        /// 设置对齐格式
        /// </summary>
        /// <param name="_col"></param>
        /// <param name="_fn"></param>
        protected void SetColumnTextAlign(GridColumn _col, MD_GuideLineFieldName _fn)
        {
            switch (_fn.TextAlign)
            {
                case "CENTER":
                    _col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                    break;
                case "RIGHT":
                    _col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                    break;
                default:
                    _col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
            }

        }


        virtual protected void ShowASNormalGrid()
        {
            this.gridView1.Columns.Clear();
            FieldsDict.Clear();
            List<MD_GuideLineFieldName> _fList = MC_GuideLine.GetFieldNamesFromMeta(_guideLineDefine.GuideLineMeta);
            _fList.Sort((g1, g2) => { return g1.DisplayOrder.CompareTo(g2.DisplayOrder); });

            foreach (MD_GuideLineFieldName _fn in _fList)
            {
                GridColumn _gc = this.gridView1.Columns.Add();
                _gc.Caption = _fn.DisplayTitle;
                _gc.FieldName = _fn.FieldName;

                _gc.Width = _fn.DisplayWidth;
                _gc.OptionsColumn.ReadOnly = true;
                _gc.Visible = true;
                _gc.VisibleIndex = gridView1.Columns.Count;

                SetColumnTextAlign(_gc, _fn);
                SetColumnDisplayFormat(_gc, _fn);
                if (!FieldsDict.ContainsKey(_fn.FieldName))
                {
                    FieldsDict.Add(_fn.FieldName, _fn.DisplayTitle);
                }
                if (MergeColumns.Contains(_fn.FieldName))
                {
                    _gc.OptionsColumn.AllowMerge = DefaultBoolean.True;
                }
                else
                {
                    _gc.OptionsColumn.AllowMerge = DefaultBoolean.False;
                }

            }
            this.sinoCommonGrid1.Visible = true;
            this.sinoCommonGrid2.Visible = false;
            if (this.MergeColumns.Count > 0)
            {
                this.gridView1.OptionsView.AllowCellMerge = true;
            }
            else
            {
                this.gridView1.OptionsView.AllowCellMerge = false;
            }
            this.sinoCommonGrid1.DataSource = _ResultTable;
            if (_fList.Count == 0)
            {
                foreach (DataColumn _dc in _ResultTable.Columns)
                {
                    FieldsDict.Add(_dc.ColumnName, _dc.Caption);
                }
            }
            this.gridView1.IndicatorWidth = _ResultTable.Rows.Count.ToString().Length * 10 + 15;
        }

        private void bandedGridView1_Click(object sender, EventArgs e)
        {
            if (e is DXMouseEventArgs)
            {
                DXMouseEventArgs _mArgs = e as DXMouseEventArgs;
                BandedGridHitInfo _cInfo = this.bandedGridView1.CalcHitInfo(_mArgs.X, _mArgs.Y);
                if (_cInfo.InBandPanel)
                {
                    GridBand _band = _cInfo.Band;
                    if (_band == null) return;
                    ChangeBandStatus(_band);
                }
            }

        }

        private void ChangeBandStatus(GridBand _band)
        {
            if (_band.ImageIndex == -1) return;
            MD_GuideLineFieldGroup _group = _band.Tag as MD_GuideLineFieldGroup;
            int _fullWidth = 0;
            int _hideWidth = 0;
            foreach (MD_GuideLineFieldName _fn in _group.Fields)
            {
                _fullWidth += _fn.DisplayWidth;
                if (!_fn.CanHide)
                {
                    _hideWidth += _fn.DisplayWidth;
                }
            }
            if (_hideWidth < 30) _hideWidth = 30;
            if (_band.ImageIndex == 1)
            {
                //展开                           
                _band.Caption = _group.DisplayTitle;

                _band.ImageIndex = 0;
                _band.ImageAlignment = StringAlignment.Far;
                foreach (BandedGridColumn _bgc in _band.Columns)
                {
                    if (_bgc.FieldName == "_BlankData")
                    {
                        _bgc.Visible = false;
                    }
                    else
                    {
                        _bgc.Visible = true;
                    }
                }
                _band.Width = _fullWidth;
            }
            else
            {
                foreach (BandedGridColumn _bgc in _band.Columns)
                {
                    if (_bgc.FieldName == "_BlankData")
                    {
                        _bgc.Visible = true;
                    }
                    else
                    {
                        MD_GuideLineFieldName _fn = _bgc.Tag as MD_GuideLineFieldName;
                        if (_fn.CanHide)
                        {
                            _bgc.Visible = false;
                        }
                        else
                        {
                            _bgc.Visible = true;
                        }
                    }
                }
                if (_hideWidth > 30)
                {
                    _band.Caption = _group.DisplayTitle;
                    _band.ImageAlignment = StringAlignment.Far;
                }
                else
                {
                    _band.Caption = "";
                    _band.ImageAlignment = StringAlignment.Center;
                }
                _band.Width = _hideWidth;
                _band.ImageIndex = 1;
            }
        }


        private void repositoryItemHyperLinkEdit1_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            int i = 0;
        }

        private void gridView1_MouseMove(object sender, MouseEventArgs e)
        {
            GridHitInfo _cInfo = this.gridView1.CalcHitInfo(e.X, e.Y);
            if (_cInfo.InRowCell && _cInfo.RowHandle >= 0)
            {
                GridColumn _column = _cInfo.Column as GridColumn;
                ChangeCusor(_column);
            }
            else
            {
                this.sinoCommonGrid1.Cursor = Cursors.Default;
            }
        }

        private void bandedGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            BandedGridHitInfo _cInfo = this.bandedGridView1.CalcHitInfo(e.X, e.Y);
            if (_cInfo.InRowCell && _cInfo.RowHandle >= 0)
            {
                GridColumn _column = _cInfo.Column as GridColumn;
                ChangeCusor(_column);
            }
            else
            {
                this.sinoCommonGrid2.Cursor = Cursors.Default;
            }
        }

        private void ChangeCusor(GridColumn _column)
        {
            if (_LinkColumnList.Contains(_column.FieldName))
            {
                // _column.View.GridControl.Cursor = Cursors.Hand;
                _column.View.GridControl.Cursor = Cursors.Default;
            }
            else
            {
                _column.View.GridControl.Cursor = Cursors.Default;
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs _eArgs = e as DXMouseEventArgs;
            GridHitInfo _cInfo = this.gridView1.CalcHitInfo(_eArgs.X, _eArgs.Y);
            if (_cInfo.InRowCell)
            {
                if (this.gridView1.FocusedRowHandle >= 0 && this.gridView1.FocusedColumn != null)
                {
                    GridColumn _gc = this.gridView1.FocusedColumn;
                    DataRow _dr = this.gridView1.GetDataRow(this.gridView1.FocusedRowHandle);
                    ShowDetailByGridColumn(_gc, _dr);
                }
            }
        }

        private void bandedGridView1_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs _eArgs = e as DXMouseEventArgs;
            BandedGridHitInfo _cInfo = this.bandedGridView1.CalcHitInfo(_eArgs.X, _eArgs.Y);
            if (_cInfo.InRowCell)
            {
                if (this.bandedGridView1.FocusedRowHandle >= 0 && this.bandedGridView1.FocusedColumn != null)
                {
                    GridColumn _gc = this.bandedGridView1.FocusedColumn;
                    DataRow _dr = this.bandedGridView1.GetDataRow(this.bandedGridView1.FocusedRowHandle);
                    ShowDetailByGridColumn(_gc, _dr);

                }
            }
        }

        private void ShowDetailByGridColumn(GridColumn _gc, DataRow _dr)
        {
            if (_detailDict.ContainsKey(_gc.FieldName))
            {
                MD_GuideLineDetailDefine _df = this._detailDict[_gc.FieldName];
                switch (_df.QueryDetailType)
                {
                    case "查询模型":
                        ShowDetailByQueryModel(_df, _dr);
                        break;
                    case "指标定义":
                        ShowDetailByGuideLine(_df, _dr);
                        break;
                }


            }
        }

        /// <summary>
        /// 显示查询模型方式的详细信息
        /// </summary>
        /// <param name="_df"></param>
        /// <param name="_dr"></param>
        private void ShowDetailByQueryModel(MD_GuideLineDetailDefine _df, DataRow _dr)
        {
            //取链接明细参数定义
            List<MD_GuideLineDetailParameter> _detailParamList = MC_GuideLine.GetGuideLineDetailParam(_df.DetailParameterMeta);
            MD_GuideLineDetailParameter _param = _detailParamList[0];
            string _data = ReplaceVerByRowData(_dr, _param.DataValue);
            ShowDetailDataArgs _args = new ShowDetailDataArgs(_df.DetailMethodID, _param.Name, _data);
            RaiseShowDetailDatal(_args);
        }



        /// <summary>
        /// 以指标方式显示详细信息
        /// </summary>
        /// <param name="_df"></param>
        /// <param name="_dr"></param>
        private void ShowDetailByGuideLine(MD_GuideLineDetailDefine _df, DataRow _dr)
        {
            MDQuery_GuideLineParameter _param;
            List<MD_GuideLine> _gls;
            string _guideLineID = _df.DetailMethodID;
            using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
            {
                _gls = _msc.GetRootGuideLineList(_guideLineID).ToList<MD_GuideLine>();
            }

            //取链接明细参数定义
            List<MD_GuideLineDetailParameter> _detailParamList = MC_GuideLine.GetGuideLineDetailParam(_df.DetailParameterMeta);
            Dictionary<string, string> _detailParamDict = new Dictionary<string, string>();
            foreach (MD_GuideLineDetailParameter _dparam in _detailParamList)
            {
                _detailParamDict.Add(_dparam.Name, _dparam.DataValue);
            }

            if (_gls.Count > 0)
            {
                //取指标
                MD_GuideLine _guideLine = _gls[0];

                //建立查询参数
                List<MDQuery_GuideLineParameter> _queryParams = new List<MDQuery_GuideLineParameter>();

                //建立指标参数字典
                List<MD_GuideLineParameter> _gParam = MC_GuideLine.GetParametersFromMeta(_guideLine.GuideLineMeta);
                foreach (MD_GuideLineParameter _p in _gParam)
                {
                    if (_detailParamDict.ContainsKey(_p.ParameterName))
                    {
                        string _dataDefine = _detailParamDict[_p.ParameterName];
                        string _data = ReplaceVerByRowData(_dr, _dataDefine);
                        _param = new MDQuery_GuideLineParameter(_p, _data);
                        _queryParams.Add(_param);
                    }
                    else
                    {
                        XtraMessageBox.Show("缺少参数定义！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                RaiseShowDetailDatal(new ShowDetailDataArgs(_guideLine, _queryParams));
            }

        }

        private string ReplaceVerByRowData(DataRow _dr, string _dataDefine)
        {
            if (_dataDefine.Length > 3)
            {
                if (_dataDefine[0] == '$' && _dataDefine[_dataDefine.Length - 1] == '$')
                {
                    string _verName = _dataDefine.Substring(1, _dataDefine.Length - 2);
                    if (_dr.IsNull(_verName.ToUpper()))
                    {
                        return "";
                    }
                    else
                    {
                        if (_dr.Table.Columns[_verName].DataType == typeof(DateTime))
                        {
                            DateTime _dtime = (DateTime)_dr[_verName];
                            return _dtime.ToString("yyyyMMdd");
                        }
                        else
                        {
                            string _datastr = _dr[_verName].ToString();
                            return _datastr;
                        }
                    }
                }
            }
            return _dataDefine;
        }

        #endregion


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
            {
                _ResultTable = _msc.QueryGuideLineByDefault(this._guideLineDefine.ID, this.QueryParameter.ToArray());
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this._isQuerying = false;
            _haveResult = (_ResultTable == null) ? false : (_ResultTable.Rows.Count > 0);
            this.labelStatus.Text = string.Format(" 共查询到{0}条记录", _ResultTable.Rows.Count);
            ShowData();
            this.timer1.Enabled = false;
            this.progressBarControl1.Visible = false;
            RaiseQueryFinished();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.progressBarControl1.Position < 95)
            {
                this.progressBarControl1.Increment(5);
            }
            else
            {
                this.progressBarControl1.Position = 0;
            }
        }

        private void bandedGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            RaiseFocusRowChanged();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            RaiseFocusRowChanged();
        }

        private void bandedGridView1_EndSorting(object sender, EventArgs e)
        {
            RaiseFocusRowChanged();
        }

        private void gridView1_EndSorting(object sender, EventArgs e)
        {
            RaiseFocusRowChanged();
        }



        public void CancelQuery()
        {
            this.backgroundWorker1.CancelAsync();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                e.Info.DisplayText = e.RowHandle >= 0 ? (e.RowHandle + 1).ToString() : "";
            }
        }




        public void SetMergeColumn(string _mergeColumns)
        {
            MergeColumns = new List<string>();
            if (_mergeColumns != "")
            {
                foreach (string _s in _mergeColumns.Split(','))
                {
                    string _colName = _s.Trim();
                    if (!MergeColumns.Contains(_colName))
                    {
                        MergeColumns.Add(_colName);
                    }
                }
            }
        }
    }
}
