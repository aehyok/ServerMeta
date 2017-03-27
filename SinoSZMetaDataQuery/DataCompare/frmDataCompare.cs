using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZPluginFramework;

using SinoSZMetaDataQuery.Common;
using System.Collections;
using SinoSZJS.Base.Misc;
using SinoSZPluginFramework.ClientPlugin;


using SinoSZJS.Base.Excel;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.DataCompare;
using SinoSZClientBase.Cache;
using SinoSZJS.Base.Controller;

namespace SinoSZMetaDataQuery.DataCompare
{
    public partial class frmDataCompare : DevExpress.XtraEditors.XtraForm, IChildForm
    {
        private IApplication _application = null;
        private string QueryModelName = "";
        private MDModel_QueryModel _queryModel = null;
        private bool _initFinished = false;
        private DataCompareExcelDataReader _excelReader = null;
        // private ExcelDataReader _excelReader = null;
        private List<ExcelColumnAlias> ExcelColumnNames = null;
        private string SourceFileName = "";

        public frmDataCompare()
        {
            InitializeComponent();
        }

        public frmDataCompare(string _param)
        {
            InitializeComponent();
            QueryModelName = StrUtils.GetMetaByName("查询模型", _param);
            string _title = StrUtils.GetMetaByName("标题", _param);
            if (_title != "") this.Text = _title;
            if (QueryModelName != "")
            {
                _queryModel = MetaDataCache.GetQueryModelDefine(QueryModelName);
                this.sinoSZUC_MD_Model_FieldList1.QueryModel = _queryModel;
                this.sinoSZUC_MD_Model_FieldList1.ShowFieldsList();
                this.sinoSZUC_MD_Model_FieldList1.FieldSelected += new EventHandler<FieldSelectEventArgs>(sinoSZUC_MD_Model_FieldList1_FieldSelected);

                this._initFinished = true;
            }
        }

        void sinoSZUC_MD_Model_FieldList1_FieldSelected(object sender, FieldSelectEventArgs e)
        {
            this.sinoSZUC_CompareConditionPanel1.AddCondition(e.FieldItem);
        }

        #region IChildForm Members

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


        public IList<FrmMenuPage> GetMenuPages()
        {
            IList<FrmMenuPage> _ret = new List<FrmMenuPage>();
            FrmMenuPage _page = new FrmMenuPage("数据比对");
            _page.MenuGroups = GetMenuGroups(_page.PageTitle);
            _ret.Add(_page);
            return _ret;
        }

        private IList<FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            FrmMenuItem _item;
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();

            //_ret.Add(this.sinoSZUC_MD_Model_FieldList1.GetMenuGroup());

            FrmMenuGroup _thisGroup = new FrmMenuGroup("数据比对功能");

            _thisGroup.MenuItems = new List<FrmMenuItem>();
            //FrmMenuItem _item = new FrmMenuItem("保存比对", "保存查询", global::SinoSZMetaDataQuery.Properties.Resources.b3, true);
            //_thisGroup.MenuItems.Add(_item);

            //_item = new FrmMenuItem("调用比对", "调用比对", global::SinoSZMetaDataQuery.Properties.Resources.b4, true);
            //_thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("开始比对", "开始比对", global::SinoSZMetaDataQuery.Properties.Resources.b2, true);
            _thisGroup.MenuItems.Add(_item);

            _ret.Add(_thisGroup);
            return _ret;
        }


        public bool DoCommand(string _cmdName)
        {
            switch (_cmdName)
            {
                case "开始比对":
                    DoCompare();
                    break;
            }



            return true;
        }


        #endregion

        private void DoCompare()
        {
            //开始数据比对
            string _errorMsg = "";
            if (_excelReader == null)
            {
                MessageBox.Show("未打开EXCEL文件!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //取结果集字段
            if (!this.sinoSZUC_MD_Model_FieldList1.CheckItems(ref _errorMsg))
            {
                XtraMessageBox.Show(string.Format("选择比对结果不正确:{0}", _errorMsg), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!this.sinoSZUC_CompareConditionPanel1.CheckInput(ref _errorMsg))
            {
                XtraMessageBox.Show(string.Format("筛选条件或比对条件不正确:{0}", _errorMsg), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            MC_CompareRequsetFactory _rf = new MC_CompareRequsetFactory();
            _rf.QueryModelName = this.QueryModelName;
            this.sinoSZUC_CompareConditionPanel1.InsertConditions2QueryRequest(_rf);
            this.sinoSZUC_MD_Model_FieldList1.InsertResultFields2QueryRequest(_rf);
            MDCompare_Request _compareRequest = _rf.GetCompareQueryRequest();

            //if (_queryResult._resultItems.Count < 1)
            //{
            //        MessageBox.Show("未选择结果字段！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //}
            //SinoProgressControler.BeginProgress();
            ////SinoProgressControler.ShowMessage = "正在加载比对目标数据....";
            ////1.将需要比对的目标文件的数据加载入DataTable
            //ArrayList _usedExcelRowList = GetUsedExcelRows();
            ////ArrayList _usedExcelRowList = this._ExcelColumnNames;

            ////2.设置别名
            //ReBuildAlias(ref _usedExcelRowList);

            ////2.将表达式进行处理
            //CompareConditionClass _CompareCon = new CompareConditionClass();
            //_CompareCon.Express = textEdit1.EditValue.ToString();
            //foreach (UC_CompareConditionItem _uc in this.panel14.Controls)
            //{
            //        if (!_uc.CheckInput())
            //        {
            //                MessageBox.Show("比对条件错误！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                return;
            //        }
            //        CompareConditionItemClass _item = _uc.GetCondition();
            //        _CompareCon.AddItem(_item);
            //}

            //_CompareCon.QueryView = (QueryView_Class)comboBoxEdit1.SelectedItem;
            //QueryCondition_Class _qcc = this.uC_RelationConditionPanel1.GetConditions();
            //foreach (Meta_ConditionItem_Class _mcc in _qcc.ConditionItems)
            //{
            //        _mcc.Column.Table_Meta.AliasName = _mcc.Column.Table_Meta.TableName;
            //}

            ////3.导入数据到DataTable
            //DataTable _importdt = SessionClass.IMetaData.GetImportTableTemp();
            //if (this._excelReader != null)
            //{
            //        _excelReader.OpenReportTempalte();
            //        _excelReader.InsertExcelData(_usedExcelRowList, ref _importdt);
            //        _excelReader.CloseReportTemplate();
            //}

            ////3.调用后台服务进行比对，并返回结果的DataSet
            //QueryResult_Class _mainRes = this.uC_CompareResultPanl1.GetMainTableResults();
            //ArrayList _childRes = this.uC_CompareResultPanl1.GetChildResults();

            //DataSet _CompareResult = SessionClass.IMetaData.CompareData2(_CompareCon, _importdt, _mainRes, _childRes, _qcc, _usedExcelRowList);
            ////4.将结果显示出来

            //SinoProgressControler.EndProgress();
            //CompareResultForm_D2E _f = new CompareResultForm_D2E(_CompareCon.QueryView, _mainRes, _childRes, _importdt, _CompareResult, _usedExcelRowList);
            //SessionClass.mainForm.AddPage("比对结果", 0, _f);

            _compareRequest.ExcelData = _excelReader.GetData();
            _compareRequest.ColumnDictionary = _excelReader.CreateColumnDictionary();
            frmDataCompareResult _frmResult = MenuFunctions.AddPage<frmDataCompareResult>(Guid.NewGuid().ToString(), Application);
            if (_frmResult != null)
            {
                _frmResult.Init("数据比对结果", "", _compareRequest, _excelReader.GetColumns());
            }
        }




        private void buttonEdit1_Click(object sender, EventArgs e)
        {
            //打开文件
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                buttonEdit1.EditValue = openFileDialog1.FileName;
                SourceFileName = openFileDialog1.FileName;
                _excelReader = new DataCompareExcelDataReader(SourceFileName);
                try
                {

                    ExcelColumnNames = _excelReader.GetColumns();

                    ResetAllCompareConditionItems();
                    //_excelReader.OpenReportTempalte();
                    //_ExcelColumnNames = _excelReader.GetFirstLineColumnName();                               
                    //_excelReader.CloseReportTemplate();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(string.Format("您选择的EXCEL表打开错误!{0}\n 可能解决方法：请用EXCEL打开此文档，并以 Microsoft Office Excel 格式另存为其它文档进行比对。", ex.Message), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ResetAllCompareConditionItems()
        {
            this.sinoSZUC_CompareConditionPanel1.ResetCompareItems(ExcelColumnNames);
        }

        private void sinoSZUC_MD_Model_FieldList1_FieldSelected_1(object sender, FieldSelectEventArgs e)
        {
            this.sinoSZUC_CompareConditionPanel1.AddCondition(e.FieldItem);
        }


    }
}