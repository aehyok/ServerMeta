using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;


using DevExpress.XtraTreeList.Nodes;
using System.Text.RegularExpressions;
using SinoSZMetaDataQuery.SyntaxAnalyse.ComputeFieldExpression;
using System.Linq;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.EnumDefine;
using SinoSZClientBase.MetaDataQueryService;

namespace SinoSZMetaDataQuery.Common
{
    public partial class Dialog_CreateComputeField : DevExpress.XtraEditors.XtraForm
    {
        protected MDModel_Table TableDefine = null;
        protected string queryString = "";
        protected string resultDataType = "";
        protected string displayName = "";
        protected string description = "";
        protected string expression = "";
        public Dialog_CreateComputeField()
        {
            InitializeComponent();
        }

        public Dialog_CreateComputeField(MDModel_Table _table)
        {
            InitializeComponent();
            TableDefine = _table;
            CreateList();
        }

        public string QueryString
        {
            get { return queryString; }
            set { queryString = value; }
        }

        public string ResultDataType
        {
            get { return resultDataType; }
            set { ResultDataType = value; }
        }

        public string DisplayName
        {
            get
            {
                return displayName;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
        }


        public string Expression
        {
            get
            {
                return expression;
            }
        }


        private void CreateList()
        {
            List<SinoSZUC_FieldTreeItem> _ret = new List<SinoSZUC_FieldTreeItem>();
            SinoSZUC_FieldTreeItem _TableItem = new SinoSZUC_FieldTreeItem(TableDefine);
            _ret.Add(_TableItem);
            foreach (MDModel_Table_Column _tc in TableDefine.Columns)
            {
                if (_tc.ColumnDefine.CanShowAsResult)
                {
                    SinoSZUC_FieldTreeItem _tcItem = new SinoSZUC_FieldTreeItem(_tc);
                    _ret.Add(_tcItem);
                }
            }
            this.treeList1.BeginUpdate();
            this.treeList1.DataSource = _ret;
            this.treeList1.ExpandAll();
            this.treeList1.EndUpdate();
            using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
            {
                List<MDQuery_ComputeColumnDefine> _personList = _msc.GetPersonSavedComputField(TableDefine.QueryModelName, TableDefine.TableName).ToList<MDQuery_ComputeColumnDefine>();
                this.gridView1.BeginUpdate();
                this.sinoCommonGrid1.DataSource = _personList;
                this.gridView1.EndUpdate();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string _msg = "";
            switch (this.xtraTabControl1.SelectedTabPageIndex)
            {
                case 0:
                    InsertInput();
                    break;
                case 2:
                    InsertSelectedUserSaved();
                    break;
            }



        }


        private void InsertSelectedUserSaved()
        {
            if (this.gridView1.RowCount > 0 && this.gridView1.FocusedRowHandle >= 0)
            {
                MDQuery_ComputeColumnDefine _selectedItem = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as MDQuery_ComputeColumnDefine;
                this.displayName = _selectedItem.DisplayName;
                this.description = _selectedItem.ColumnDescription;
                this.expression = _selectedItem.DisplayMethod;
                this.resultDataType = _selectedItem.ResultDataType;
                this.queryString = _selectedItem.ColumnMethod;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("请选择保存的记录", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void InsertInput()
        {
            string _msg = "";
            if (CheckInput(ref _msg))
            {
                this.displayName = (this.te_DisplayName.EditValue == null) ? "" : this.te_DisplayName.EditValue.ToString();
                this.description = (this.te_Des.EditValue == null) ? "" : this.te_Des.EditValue.ToString();
                this.expression = (this.te_exp.EditValue == null) ? "" : this.te_exp.EditValue.ToString();
                if (this.checkEdit1.Checked)
                {
                    using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                    {
                        _msc.SaveComputeFieldDefine(this.DisplayName, this.Description, this.Expression, this.queryString, this.ResultDataType, this.TableDefine.TableName, this.TableDefine.QueryModelName);
                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show(_msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private bool CheckInput(ref string _msg)
        {
            _msg = "";
            if (this.te_DisplayName.EditValue == null || this.te_DisplayName.EditValue.ToString().Trim() == "")
            {
                _msg = "请输入字段名称!";
                return false;
            }

            if (this.te_Des.EditValue == null || this.te_Des.EditValue.ToString().Trim() == "")
            {
                _msg = "请输入字段说明!";
                return false;
            }

            if (this.te_exp.EditValue == null || this.te_exp.EditValue.ToString().Trim() == "")
            {
                _msg = "请输入计算字段表达式!";
                return false;
            }

            return ExpressCheck(ref _msg);
        }

        private bool ExpressCheck(ref string _msg)
        {
            _msg = "";
            string ExpressionString = this.te_exp.EditValue.ToString();
            if (CheckItem(ExpressionString))
            {
                return true;
            }
            else
            {
                _msg = "表达式不正确！";
                return false;
            }

            return true;
        }

        private bool CheckItem(string ExpressionString)
        {
            try
            {
                using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                {
                    _msc.TestComputeExpress(ExpressionString, TableDefine, ref queryString, ref resultDataType);
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;

        }



        private void treeList1_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {
            if ((string)e.Node.GetValue("ItemType") == "TABLE")
            {
                MDModel_Table _tb = e.Node.GetValue("Data") as MDModel_Table;
                if (_tb.TableDefine.ViewTableRelationType == MDType_ViewTableRelation.SingleChildRecord)
                {
                    e.NodeImageIndex = 0;
                }
                else
                {
                    e.NodeImageIndex = 1;
                }
            }
            else if ((string)e.Node.GetValue("ItemType") == "COLUMN")
            {
                MDModel_Table_Column _tc = e.Node.GetValue("Data") as MDModel_Table_Column;
                if (_tc.ColumnType == QueryColumnType.TableColumn)
                {
                    e.NodeImageIndex = 2;
                }
                else if (_tc.ColumnType == QueryColumnType.StatisticsColumn)
                {
                    e.NodeImageIndex = 3;
                }
                else if (_tc.ColumnType == QueryColumnType.CalculationColumn)
                {
                    e.NodeImageIndex = 4;
                }
            }
        }

        private void OptionButton_Click(object sender, EventArgs e)
        {
            SimpleButton _bt = (SimpleButton)sender;
            Clipboard.SetDataObject(_bt.Text);
            this.te_exp.Paste();
        }

        private void treeList1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeListNode _node = this.treeList1.FocusedNode;
            if (_node != null)
            {
                string _itemType = (string)_node.GetValue("ItemType");
                if (_itemType == "COLUMN")
                {
                    MDModel_Table_Column _item = _node.GetValue("Data") as MDModel_Table_Column;
                    #region 设为选择此字段

                    if (_item.ColumnDefine.CanShowAsResult)
                    {
                        Clipboard.SetDataObject(_item.ColumnAlias);
                        this.te_exp.Paste();
                    }

                    #endregion

                }
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == this.xtraTabPage3)
            {
                this.bt_Del.Visible = true;
            }
            else
            {
                this.bt_Del.Visible = false;
            }
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            Dialog_AddFunction _f = new Dialog_AddFunction();
            _f.InitForm(this.TableDefine);
            if (_f.ShowDialog() == DialogResult.OK)
            {
                Clipboard.SetDataObject(_f.InsertString);
                this.te_exp.Paste();
            }
        }

        private void bt_Del_Click(object sender, EventArgs e)
        {
            string _msg = "";
            switch (this.xtraTabControl1.SelectedTabPageIndex)
            {
                case 0:

                    break;
                case 2:
                    DelSelectedUserSaved();
                    break;
            }
        }

        private void DelSelectedUserSaved()
        {
            if (this.gridView1.RowCount > 0 && this.gridView1.FocusedRowHandle >= 0)
            {
                MDQuery_ComputeColumnDefine _selectedItem = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as MDQuery_ComputeColumnDefine;
                using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                {
                    if (_msc.DelComputeFieldDefine(_selectedItem.ColumnName))
                    {
                        this.gridView1.DeleteRow(this.gridView1.FocusedRowHandle);
                    }
                    else
                    {
                        XtraMessageBox.Show("删除收藏的计算项字段失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("请选择保存的记录", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }



    }
}