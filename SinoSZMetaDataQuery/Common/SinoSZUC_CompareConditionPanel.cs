using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;


using SinoSZJS.Base.Expression;


using SinoSZMetaDataQuery.DataCompare;
using SinoSZJS.Base.Excel;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.DataCompare;
using SinoSZJS.Base.Controller;

namespace SinoSZMetaDataQuery.Common
{
	public partial class SinoSZUC_CompareConditionPanel : DevExpress.XtraEditors.XtraUserControl
	{
		private int focusedItem = 0;
		private Control focusedControl = null;
		private List<ExcelColumnAlias> ExcelColumns = new List<ExcelColumnAlias>();
		public int FocusedItem
		{
			get { return focusedItem; }
		}
		public event EventHandler<EventArgs> MenuChanged;
		virtual public void RaiseMenuChanged()
		{
			if (MenuChanged != null)
			{
				MenuChanged(this, new EventArgs());
			}
		}

		private bool CurrentFocused = false;

		public SinoSZUC_CompareConditionPanel()
		{
			InitializeComponent();
		}

		public void AddCondition(MDModel_Table_Column _tableColumn)
		{
			if (this.xtraTabControl1.SelectedTabPageIndex == 0)
			{
				//添加到比对条件
				AddCompareCondtion(_tableColumn);
			}

			if (this.xtraTabControl1.SelectedTabPageIndex == 1)
			{
				//添加到筛选条件
				AddFilterCondition(_tableColumn);

			}
		}

		private void AddFilterCondition(MDModel_Table_Column _tc)
		{
			SinoSZUC_ConditionItem _item = null;
			if (!_tc.ColumnDefine.CanShowAsCondition)
			{
				XtraMessageBox.Show("此字段不可做条件项", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			switch (_tc.ColumnDataType.ToUpper())
			{
				case "DATE":
					_item = new SinoSZUC_ConditionItem_Date(_tc);
					break;
				case "NUMBER":
					_item = new SinoSZUC_ConditionItem_Number(_tc);
					break;

				default:
					if (_tc.ColumnDefine.TableColumn.RefDMB != "")
					{
						_item = new SinoSZUC_ConditionItem_RefCode(_tc);
					}
					else
					{
						_item = new SinoSZUC_ConditionItem(_tc);
					}
					break;
			}

			if (_item != null)
			{

				_item.Dock = DockStyle.Top;
				this.xtraScrollableControl1.Controls.Add(_item);
				_item.GetFocused += new EventHandler<EventArgs>(_item_GetFocused);
				_item.LoseFocused += new EventHandler<EventArgs>(_item_LoseFocused);
				_item.RemoveCondition += new EventHandler<EventArgs>(_item_RemoveCondition);
				_item.BringToFront();
				ResetOrderNumber(this.xtraScrollableControl1);
				this.xtraScrollableControl1.Refresh();
				this.xtraScrollableControl1.ScrollControlIntoView(_item);
				if (this.textEdit1.EditValue == null)
				{
					this.textEdit1.EditValue = this.xtraScrollableControl1.Controls.Count.ToString();
				}
				else
				{
					string _expression = this.textEdit1.EditValue.ToString();
					if (_expression == "")
					{
						_expression = "1";
					}
					else
					{
						_expression += string.Format("*{0}", this.xtraScrollableControl1.Controls.Count);
					}
					this.textEdit1.EditValue = _expression;
				}
			}
		}

		private void AddCompareCondtion(MDModel_Table_Column _tc)
		{
			SinoSZUC_ConditionItem _item = null;
			if (!_tc.ColumnDefine.CanShowAsCondition)
			{
				XtraMessageBox.Show("此字段不可做条件项", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			switch (_tc.ColumnDataType.ToUpper())
			{
				case "DATE":

				case "NUMBER":

				default:

					_item = new SinoSZUC_CompareConditionItem(_tc, this.ExcelColumns);

					break;
			}

			if (_item != null)
			{

				_item.Dock = DockStyle.Top;
				this.xtraScrollableControl2.Controls.Add(_item);
				_item.GetFocused += new EventHandler<EventArgs>(_item_GetFocused);
				_item.LoseFocused += new EventHandler<EventArgs>(_item_LoseFocused);
				_item.RemoveCondition += new EventHandler<EventArgs>(_item_RemoveCondition);
				_item.BringToFront();
				ResetOrderNumber(this.xtraScrollableControl2);
				this.xtraScrollableControl2.Refresh();
				this.xtraScrollableControl2.ScrollControlIntoView(_item);

				if (this.textEdit2.EditValue == null)
				{
					this.textEdit2.EditValue = this.xtraScrollableControl2.Controls.Count.ToString();
				}
				else
				{
					string _expression = this.textEdit2.EditValue.ToString();
					if (_expression == "")
					{
						_expression = "1";
					}
					else
					{
						_expression += string.Format("*{0}", this.xtraScrollableControl2.Controls.Count);
					}
					this.textEdit2.EditValue = _expression;
				}
			}
		}

		void _item_RemoveCondition(object sender, EventArgs e)
		{
			RemoveConditionItem();
		}

		void _item_LoseFocused(object sender, EventArgs e)
		{
			CurrentFocused = false;
			RaiseMenuChanged();
		}

		void _item_GetFocused(object sender, EventArgs e)
		{
			CurrentFocused = true;
			SinoSZUC_ConditionItem _uc = sender as SinoSZUC_ConditionItem;
			this.focusedItem = _uc.Index;
			this.focusedControl = _uc;
			RaiseMenuChanged();
		}



		private void xtraScrollableControl2_DragDrop(object sender, DragEventArgs e)
		{
			TreeListNode _node = GetDragNode(e.Data);
			if (_node == null) return;

			string _itemType = (string)_node.GetValue("ItemType");
			if (_itemType == "TABLE") return;
			if (_itemType == "COLUMN")
			{
				MDModel_Table_Column _tc = _node.GetValue("Data") as MDModel_Table_Column;
				AddCompareCondtion(_tc);
			}
		}

		private TreeListNode GetDragNode(IDataObject data)
		{
			return data.GetData(typeof(TreeListNode)) as TreeListNode;
		}

		private void xtraScrollableControl2_DragEnter(object sender, DragEventArgs e)
		{
			TreeListNode _node = GetDragNode(e.Data);

			if (_node != null)
			{
				e.Effect = DragDropEffects.Copy;
			}
		}

		private void xtraScrollableControl2_DragLeave(object sender, EventArgs e)
		{

		}

		private void xtraScrollableControl1_DragDrop(object sender, DragEventArgs e)
		{
			TreeListNode _node = GetDragNode(e.Data);
			if (_node == null) return;

			string _itemType = (string)_node.GetValue("ItemType");
			if (_itemType == "TABLE") return;
			if (_itemType == "COLUMN")
			{
				MDModel_Table_Column _tc = _node.GetValue("Data") as MDModel_Table_Column;
				AddFilterCondition(_tc);
			}
		}

		private void xtraScrollableControl1_DragEnter(object sender, DragEventArgs e)
		{
			TreeListNode _node = GetDragNode(e.Data);

			if (_node != null)
			{
				e.Effect = DragDropEffects.Copy;
			}
		}

		private void textEdit1_SizeChanged(object sender, EventArgs e)
		{
			this.popupContainerControl1.Width = this.textEdit1.Width - 10;
		}

		public bool DoCommand(string _cmdName)
		{
			switch (_cmdName)
			{
				case "移除条件":
					RemoveConditionItem();
					break;
			}
			return true;
		}

		private void RemoveConditionItem()
		{
			if (this.xtraTabControl1.SelectedTabPageIndex == 0)
			{
				//添加到比对条件
				RemoveCompareCondtion();
			}

			if (this.xtraTabControl1.SelectedTabPageIndex == 1)
			{
				//添加到筛选条件
				RemoveFilterCondition();

			}
		}

		private void RemoveFilterCondition()
		{
			if (focusedControl != null)
			{
				this.xtraScrollableControl1.Controls.Remove(focusedControl);
				ResetOrderNumber(this.xtraScrollableControl1);
				this.textEdit1.EditValue = ResetExpression(this.xtraScrollableControl1);
			}
		}

		private void RemoveCompareCondtion()
		{
			if (focusedControl != null)
			{
				this.xtraScrollableControl2.Controls.Remove(focusedControl);
				ResetOrderNumber(this.xtraScrollableControl2);
				this.textEdit2.EditValue = ResetExpression(this.xtraScrollableControl2);
			}
		}

		private void ResetOrderNumber(XtraScrollableControl xtraScrollableControl)
		{
			int i = 0;
			int all = xtraScrollableControl.Controls.Count;
			foreach (SinoSZUC_ConditionItem _c in xtraScrollableControl.Controls)
			{
				_c.SetOrderNumber(all - i++);
			}
		}

		private string ResetExpression(XtraScrollableControl xtraScrollableControl)
		{
			StringBuilder _sb = new StringBuilder();
			if (xtraScrollableControl.Controls.Count < 1)
			{

			}
			else
			{
				_sb.Append("1");
				for (int i = 1; i < xtraScrollableControl.Controls.Count; i++)
				{
					_sb.Append(string.Format("*{0}", i + 1));
				}
			}
			return _sb.ToString();

		}





		public void ResetCompareItems(List<ExcelColumnAlias> ExcelColumnNames)
		{
			ExcelColumns = ExcelColumnNames;

			if (this.xtraScrollableControl2.Controls.Count > 0)
			{
				foreach (SinoSZUC_CompareConditionItem _c in xtraScrollableControl2.Controls)
				{
					if (_c != null)
					{
						_c.SetItems(ExcelColumns);
					}
				}
			}
		}

		public bool CheckInput(ref string _errorMsg)
		{
			StringBuilder _sb = new StringBuilder();
			bool _ret = true;


			foreach (SinoSZUC_ConditionItem _c in this.xtraScrollableControl1.Controls)
			{
				string _msg = "";
				if (!_c.CheckInput(ref _msg))
				{
					_sb.Append("\r\n");
					_sb.Append(_msg);
					_ret = false;
				}
			}

			//处理比对条件
			if (this.xtraScrollableControl2.Controls.Count == 0)
			{
				_ret = false;
				_sb.Append("用户未输入比对条件！");
			}
			foreach (SinoSZUC_CompareConditionItem _c in this.xtraScrollableControl2.Controls)
			{
				string _msg = "";
				if (!_c.CheckInput(ref _msg))
				{
					_sb.Append("\r\n");
					_sb.Append(_msg);
					_ret = false;
				}
			}

			string _emsg = "";
			string _expStr = (this.textEdit1.EditValue == null) ? "" : this.textEdit1.EditValue.ToString().Trim();
			_ret = (!CheckExpression(ref _emsg)) ? false : _ret;
			_sb.Append(_emsg);



			_errorMsg = _sb.ToString();
			return _ret;
		}

		private bool CheckExpression(ref string _msg)
		{
			string _filterExp = (this.textEdit1.EditValue == null) ? "" : this.textEdit1.EditValue.ToString();
			bool _ret = QueryExpression.ExpressCheck(_filterExp, this.xtraScrollableControl1.Controls.Count);
			if (!_ret)
			{
				_msg = "用户输入的筛选表达式不正确!";
				return false;
			}
			string _compareExp = (this.textEdit2.EditValue == null) ? "" : this.textEdit2.EditValue.ToString();
			_ret = QueryExpression.ExpressCheck(this.textEdit2.EditValue.ToString(), this.xtraScrollableControl2.Controls.Count);
			if (!_ret)
			{
				_msg = "用户输入的比对表达式不正确!";
				return false;
			}
			_msg = "";
			return true;
		}



		public void InsertConditions2QueryRequest(MC_CompareRequsetFactory _compareRequestFactory)
		{
			string _filterExp = (this.textEdit1.EditValue == null) ? "" : this.textEdit1.EditValue.ToString();
			_compareRequestFactory.AddExpression(_filterExp);
			foreach (SinoSZUC_ConditionItem _c in this.xtraScrollableControl1.Controls)
			{
				MDQuery_ConditionItem _cItem = _c.GetConditionItem();
				_compareRequestFactory.AddConditonItem(_cItem);
			}

			string _compareExp = (this.textEdit2.EditValue == null) ? "" : this.textEdit2.EditValue.ToString();
			_compareRequestFactory.AddCompareExpression(_compareExp);
			foreach (SinoSZUC_CompareConditionItem _c in this.xtraScrollableControl2.Controls)
			{
				MDCompare_ConditionItem _cItem = _c.GetCompareConditionItem();
				_compareRequestFactory.AddCompareConditonItem(_cItem);
			}
		}
	}
}
