using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraEditors;


using SinoSZMetaDataQuery.DataCompare;
using SinoSZJS.Base.Excel;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.DataCompare;

namespace SinoSZMetaDataQuery.Common
{
	public partial class SinoSZUC_CompareConditionItem : SinoSZMetaDataQuery.Common.SinoSZUC_ConditionItem
	{
		private ComboBoxEdit excelSelectBox = null;
		private List<ExcelColumnAlias> excelFieldList = new List<ExcelColumnAlias>();
		public SinoSZUC_CompareConditionItem()
			: base()
		{ }

		public SinoSZUC_CompareConditionItem(MDModel_Table_Column _column)
			: base(_column)
		{
		}

		public SinoSZUC_CompareConditionItem(MDModel_Table_Column _column, List<ExcelColumnAlias> _excelFields)
			: base(_column)
		{

			excelFieldList = _excelFields;
			ReSetSelectItems();
		}


		/// <summary>
		/// 初始化运算符
		/// </summary>
		protected override void initOperator()
		{
			this.teOption.Properties.Items.Clear();
			this.teOption.Properties.Items.Add(" 等于 ");
			this.teOption.Properties.Items.Add(" 近似 ");
			this.teOption.SelectedIndex = 0;
			this.te_Value.ToolTip = "日期的标准格式为:\"YYYY-MM-DD\",　也可以使用格式\"YYYYMMDD\" 或 \"YYYY/MM/DD\"";
		}

		protected override void InitControls()
		{
			base.InitControls();
			this.te_Value.Visible = false;
			excelSelectBox = new ComboBoxEdit();
			excelSelectBox.Properties.Items.Clear();
			excelSelectBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			ReSetSelectItems();
			excelSelectBox.Dock = DockStyle.Fill;
			this.Controls.Add(excelSelectBox);
			excelSelectBox.BringToFront();
		}

		private void ReSetSelectItems()
		{
			excelSelectBox.Properties.Items.Clear();
			foreach (ExcelColumnAlias _s in excelFieldList)
			{
				excelSelectBox.Properties.Items.Add(_s);
			}
		}

		protected override void SinoSZUC_ConditionItem_Enter(object sender, EventArgs e)
		{
			base.SinoSZUC_ConditionItem_Enter(sender, e);
			excelSelectBox.BackColor = this.te_xh.BackColor;
		}

		protected override void SinoSZUC_ConditionItem_Leave(object sender, EventArgs e)
		{
			base.SinoSZUC_ConditionItem_Leave(sender, e);
			excelSelectBox.BackColor = this.te_xh.BackColor;
		}

		protected override void ClearValue()
		{
			excelSelectBox.SelectedIndex = -1;
		}

		public override bool CheckInput(ref string _errorMsg)
		{
			string _selectOption = GetOperator();
			if (_selectOption == string.Empty)
			{
				_errorMsg = string.Format("用户未选择{0}字段的条件运算符！", this.ColumnDefine.ColumnTitle);
				return false;
			}
			else
			{

				if (this.excelSelectBox.SelectedIndex == -1)
				{
					_errorMsg = string.Format("用户未输入[{0}]字段的比对列！", this.ColumnDefine.ColumnTitle);
					return false;
				}

			}

			return true;
		}

		public override bool HaveInputData()
		{
			if (this.excelSelectBox.SelectedIndex != -1)
			{
				return true;
			}
			return false;
		}

		public void SetItems(List<ExcelColumnAlias> _excleFields)
		{
			this.excelFieldList = _excleFields;
			ReSetSelectItems();
		}





		public MDCompare_ConditionItem GetCompareConditionItem()
		{
			string _emsg = "";
			if (CheckInput(ref _emsg))
			{
				MDCompare_ConditionItem _ret = new MDCompare_ConditionItem();
				_ret.ColumnIndex = this.te_xh.Text;
				_ret.Column = new MDQuery_TableColumn(ColumnDefine);
				_ret.Operator = GetOperator();
				ExcelColumnAlias _selectItem = this.excelSelectBox.EditValue as ExcelColumnAlias;
				_ret.CompareTagetField = _selectItem.Alias;

				return _ret;
			}
			else
			{
				return null;
			}
		}
	}
}

