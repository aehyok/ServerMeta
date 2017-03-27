using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;


using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.Define;
using System.Linq;
using SinoSZClientBase.MetaDataQueryService;
namespace SinoSZMetaDataQuery.Common
{

    public partial class Dialog_CreateStatisticsField : DevExpress.XtraEditors.XtraForm
    {
        protected MDModel_Table currentTable = null;
        protected MD_FUNCTION currentFun = null;
        static protected List<MD_FUNCTION> functionList = null;
        static public List<MD_FUNCTION> FunctionList
        {
            get
            {
                if (functionList == null)
                {
                    using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                    {
                        functionList = _msc.GetFunctionList(1).ToList<MD_FUNCTION>();
                    }
                }
                return functionList;
            }
        }

        protected string resultDataType = "";
        public string ResultDataType
        {
            get { return resultDataType; }
        }

        protected string queryString = "";
        public string QueryString
        {
            get { return queryString; }
        }

        public string FieldName
        {
            get
            {
                if (this.te_Name.EditValue == null) return "";
                return this.te_Name.EditValue.ToString();
            }
        }



        protected MDModel_QueryModel CurrentModel = null;
        protected bool _initFinished = false;
        public Dialog_CreateStatisticsField()
        {
            InitializeComponent();
        }

        public Dialog_CreateStatisticsField(MDModel_QueryModel _qv)
        {
            InitializeComponent();
            CurrentModel = _qv;
            InitForm();
        }

        private void InitForm()
        {
            this.cb_Table.Properties.Items.Clear();
            foreach (MDModel_Table _tb in CurrentModel.ChildTableDict.Values)
            {
                TableListItem _item = new TableListItem(_tb);
                this.cb_Table.Properties.Items.Add(_item);
            }
            foreach (MD_FUNCTION _fun in FunctionList)
            {
                FunListItem _fitem = new FunListItem(_fun);
                this.cb_Function.Properties.Items.Add(_fitem);
            }
            _initFinished = true;
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (this.te_Name.EditValue == null || this.te_Name.EditValue.ToString().Trim() == "")
            {
                XtraMessageBox.Show("请输入字段名称！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.cb_Field.SelectedItem == null)
            {
                XtraMessageBox.Show("请选择被统计字段！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ColumnListItem _item = this.cb_Field.SelectedItem as ColumnListItem;

            string _msg = "";
            if (CreateQueryString(_item, ref _msg))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("统计函数错误！" + _msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private bool CreateQueryString(ColumnListItem _item, ref string _msg)
        {
            _msg = "";
            try
            {
                string _mainSql = "";
                using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                {
                    _msc.TestStatisticsExpress(this.currentTable.TableName, _item.Column, this.currentFun, ref _mainSql, ref resultDataType);
                }
                this.queryString = string.Format("{0} where {1}", _mainSql, this.currentTable.TableDefine.RelationString);

                return true;
            }
            catch (Exception e)
            {
                _msg = e.Message;
                return false;
            }
        }

        private void cb_Table_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFieldList();
        }


        private void cb_Function_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFieldList();
        }



        private void ChangeFieldList()
        {
            this.cb_Field.Properties.Items.Clear();
            this.te_Des.EditValue = "";
            if (this.cb_Table.SelectedItem == null) return;
            if (this.cb_Function.SelectedItem == null) return;

            TableListItem _tItem = this.cb_Table.SelectedItem as TableListItem;
            FunListItem _fItem = this.cb_Function.SelectedItem as FunListItem;
            this.currentTable = _tItem.Table;
            this.currentFun = _fItem.Function;
            this.te_Des.EditValue = this.currentFun.Description;
            string _pname = this.currentFun.ParamList[0];
            string _ptype = this.currentFun.ParamTypeDict[_pname];
            switch (_ptype)
            {
                case "VARCHAR":
                case "CHAR":
                case "VARCHAR2":
                case "NVARCHAR":
                case "NVARCHAR2":
                    AddCharField(currentTable);
                    break;
                case "NUMBER":
                    AddNumField(currentTable);
                    break;
                case "DATE":
                    AddDateField(currentTable);
                    break;
                case "ALL":
                    AddALLField(currentTable);
                    break;
            }

        }

        private void AddALLField(MDModel_Table _table)
        {
            foreach (MDModel_Table_Column _tc in _table.Columns)
            {
                ColumnListItem _item = new ColumnListItem(_tc);
                this.cb_Field.Properties.Items.Add(_item);
            }
        }

        private void AddDateField(MDModel_Table _table)
        {
            foreach (MDModel_Table_Column _tc in _table.Columns)
            {
                ColumnListItem _item = new ColumnListItem(_tc);
                switch (_tc.ColumnDataType.ToUpper())
                {
                    case "DATE":
                        this.cb_Field.Properties.Items.Add(_item);
                        break;
                }
            }
        }

        private void AddNumField(MDModel_Table _table)
        {
            foreach (MDModel_Table_Column _tc in _table.Columns)
            {
                ColumnListItem _item = new ColumnListItem(_tc);
                switch (_tc.ColumnDataType.ToUpper())
                {
                    case "NUMBER":
                        this.cb_Field.Properties.Items.Add(_item);
                        break;
                }
            }
        }

        private void AddCharField(MDModel_Table _table)
        {
            foreach (MDModel_Table_Column _tc in _table.Columns)
            {
                ColumnListItem _item = new ColumnListItem(_tc);
                switch (_tc.ColumnDataType.ToUpper())
                {
                    case "VARCHAR":
                    case "CHAR":
                    case "VARCHAR2":
                    case "NVARCHAR":
                    case "NVARCHAR2":
                        this.cb_Field.Properties.Items.Add(_item);
                        break;
                }
            }
        }

        private void cb_Field_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Field.SelectedItem == null) return;
            ColumnListItem _selectedItem = this.cb_Field.SelectedItem as ColumnListItem;
            this.te_Des.EditValue = string.Format("求{0}的{1}", _selectedItem.FieldDisplayName, this.currentFun.DisplayTitle);
        }

    }
}