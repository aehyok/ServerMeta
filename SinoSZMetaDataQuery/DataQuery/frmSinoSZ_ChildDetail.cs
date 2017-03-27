using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZPluginFramework;

using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;
using SinoSZMetaDataQuery.Common;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZClientBase.MetaDataQueryService;

namespace SinoSZMetaDataQuery.DataQuery
{
    public partial class frmSinoSZ_ChildDetail : DevExpress.XtraEditors.XtraForm, IChildForm
    {
        private IApplication _application = null;
        private bool _initFinished = false;
        private MDModel_QueryModel QueryModel = null;
        private MDModel_Table TabelDefine = null;
        private string MainKeyID = "";

        public frmSinoSZ_ChildDetail()
        {
            InitializeComponent();
        }

        public frmSinoSZ_ChildDetail(MDModel_QueryModel _model, MDModel_Table _ctable, string _keyid)
        {
            InitializeComponent();
            QueryModel = _model;
            TabelDefine = _ctable;
            MainKeyID = _keyid;
            this.Text = string.Format("{0}的详细信息", _ctable.TableDefine.DisplayTitle);
            ShowData();
        }

        private void ShowData()
        {
            DataTable _cdt;
            using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
            {
                _cdt = _msc.GetChildTableDataByKey(this.QueryModel.FullQueryModelName,
                                                      TabelDefine.TableName, this.MainKeyID);
            }
            foreach (MDModel_Table_Column _tc in TabelDefine.Columns)
            {
                if (_tc.CanDisplay && _tc.CanResultShow)
                {
                    GridColumn _gc = this.gridView1.Columns.Add();
                    _gc.Caption = _tc.ColumnTitle;
                    _gc.FieldName = _tc.ColumnAlias;
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



                    if (_tc.ColumnDefine.TableColumn.DisplayFormat == "")
                    {
                        if (_tc.ColumnDataType == "DATE")
                        {
                            _gc.DisplayFormat.FormatType = FormatType.DateTime;
                            _gc.DisplayFormat.FormatString = "yyyy-MM-dd";
                        }

                    }
                    else
                    {
                        if (_tc.ColumnDataType == "DATE") _gc.DisplayFormat.FormatType = FormatType.DateTime;
                        _gc.DisplayFormat.FormatString = _tc.ColumnDefine.TableColumn.DisplayFormat;
                    }
                    _gc.Width = (_tc.ColumnDefine.TableColumn.DisplayLength + _tc.ColumnDefine.TableColumn.DisplayHeight) * 80;
                    _gc.VisibleIndex = gridView1.Columns.Count;
                }

            }

            this.sinoCommonGrid1.DataSource = _cdt;
            //this.gridView1.BestFitColumns();
            ShowDetailData();
            this._initFinished = true;
        }

        private void ShowDetailData()
        {
            int _index = this.gridView1.FocusedRowHandle;
            if (_index >= 0)
            {
                PanelDetail.Visible = false;
                DataRow _dr = this.gridView1.GetDataRow(_index);
                SinoSZUC_RecordData _crd = new SinoSZUC_RecordData(this.TabelDefine, _dr);
                _crd.Dock = DockStyle.Top;
                PanelDetail.Controls.Clear();
                PanelDetail.Controls.Add(_crd);
                _crd.BringToFront();
                PanelDetail.Visible = true;
            }
        }

        #region 实现IChildFrom接口

        public IApplication Application
        {
            get { return _application; }
            set { _application = value; }
        }

        public event EventHandler<EventArgs> MenuChanged;
        virtual public void RaiseMenuChanged()
        {
            if (this._initFinished && MenuChanged != null)
            {
                MenuChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// 取辅助菜单页
        /// </summary>
        /// <returns></returns>
        public IList<FrmMenuPage> GetMenuPages()
        {
            IList<FrmMenuPage> _ret = new List<FrmMenuPage>();
            FrmMenuPage _page = new FrmMenuPage("详细信息");
            _page.MenuGroups = GetMenuGroups(_page.PageTitle);
            _ret.Add(_page);
            return _ret;
        }

        /// <summary>
        /// 取菜单组
        /// </summary>
        /// <param name="_pagename"></param>
        /// <returns></returns>
        private IList<FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();
            FrmMenuGroup _thisGroup = new FrmMenuGroup("详细信息");

            _thisGroup.MenuItems = new List<FrmMenuItem>();
            FrmMenuItem _item = new FrmMenuItem("数据导出", "数据导出", global::SinoSZMetaDataQuery.Properties.Resources.x3, true);
            _thisGroup.MenuItems.Add(_item);
            _item = new FrmMenuItem("打印", "打印", global::SinoSZMetaDataQuery.Properties.Resources.x4, true);
            _thisGroup.MenuItems.Add(_item);
            _ret.Add(_thisGroup);
            return _ret;
        }


        /// <summary>
        /// 执行菜单命令
        /// </summary>
        /// <param name="_cmdName"></param>
        /// <returns></returns>
        public bool DoCommand(string _cmdName)
        {

            return true;
        }


        #endregion

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (this._initFinished)
            {
                ShowDetailData();
            }
        }

    }
}