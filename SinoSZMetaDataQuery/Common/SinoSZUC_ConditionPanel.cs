using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;

using SinoSZPluginFramework;

using SinoSZJS.Base;
using SinoSZJS.Base.Expression;

using DevExpress.XtraEditors;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.Common;
using SinoSZJS.Base.Controller;

namespace SinoSZMetaDataQuery.Common
{
    public partial class SinoSZUC_ConditionPanel : UserControl
    {
        private int focusedItem = 0;
        private Control focusedControl = null;

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

        public bool CurrentFocused = false;

        public SinoSZUC_ConditionPanel()
        {
            InitializeComponent();
        }

        public void AddCondition(MDModel_Table_Column _tc)
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
                    if (_tc.ColumnDefine.TableColumn.RefDMB != "")
                    {
                        _item = new SinoSZUC_ConditionItem_RefCode(_tc);
                    }
                    else
                    {
                        _item = new SinoSZUC_ConditionItem_Number(_tc);
                    }

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
                _item.BringToFront();
                ResetOrderNumber();
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
                _item.RemoveCondition += new EventHandler<EventArgs>(_item_RemoveCondition);
            }
        }

        void _item_RemoveCondition(object sender, EventArgs e)
        {
            Control _c = sender as Control;
            this.xtraScrollableControl1.Controls.Remove(_c);
            ResetOrderNumber();
            ResetExpression();
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

        private void ResetExpression()
        {
            StringBuilder _sb = new StringBuilder();
            if (this.xtraScrollableControl1.Controls.Count < 1)
            {

            }
            else
            {
                _sb.Append("1");
                for (int i = 1; i < this.xtraScrollableControl1.Controls.Count; i++)
                {
                    _sb.Append(string.Format("*{0}", i + 1));
                }
            }
            this.textEdit1.EditValue = _sb.ToString();
        }

        private void ResetOrderNumber()
        {
            int i = 0;
            int all = this.xtraScrollableControl1.Controls.Count;
            foreach (SinoSZUC_ConditionItem _c in this.xtraScrollableControl1.Controls)
            {
                _c.SetOrderNumber(all - i++);
            }

        }

        private TreeListNode GetDragNode(IDataObject data)
        {
            return data.GetData(typeof(TreeListNode)) as TreeListNode;
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
                AddCondition(_tc);
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

        private void xtraScrollableControl1_DragLeave(object sender, EventArgs e)
        {

        }

        public FrmMenuGroup GetMenuGroup()
        {
            if (!CurrentFocused)
            {
                return null;
            }

            FrmMenuGroup _thisGroup = new FrmMenuGroup("查询条件");

            _thisGroup.MenuItems = new List<FrmMenuItem>();

            FrmMenuItem _item = new FrmMenuItem("移除条件", "移除条件", global::SinoSZMetaDataQuery.Properties.Resources.b7, true);
            _thisGroup.MenuItems.Add(_item);
            return _thisGroup;
        }

        private void textEdit1_Enter(object sender, EventArgs e)
        {

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

        public void InsertConditions2QueryRequest(MC_QueryRequsetFactory _queryRequestFactory)
        {
            _queryRequestFactory.AddExpression(this.textEdit1.EditValue.ToString());
            foreach (SinoSZUC_ConditionItem _c in this.xtraScrollableControl1.Controls)
            {

                MDQuery_ConditionItem _cItem = _c.GetConditionItem();
                _queryRequestFactory.AddConditonItem(_cItem);

            }
        }

        private void RemoveConditionItem()
        {
            this.xtraScrollableControl1.Controls.Remove(focusedControl);
            ResetOrderNumber();
            ResetExpression();
        }

        /// <summary>
        /// 检查输入的条件是否正确
        /// </summary>
        /// <param name="_errorMsg"></param>
        /// <returns></returns>
        public bool CheckInput(ref string _errorMsg)
        {
            StringBuilder _sb = new StringBuilder();
            bool _ret = true;
            if (this.xtraScrollableControl1.Controls.Count == 0)
            {
                _ret = false;
                _sb.Append("用户未输入查询条件！");
            }

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
            string _emsg = "";
            string _expStr = (this.textEdit1.EditValue == null) ? "" : this.textEdit1.EditValue.ToString().Trim();
            _ret = (!CheckExpression(_expStr, this.xtraScrollableControl1.Controls.Count, ref _emsg)) ? false : _ret;
            _sb.Append(_emsg);
            _errorMsg = _sb.ToString();
            return _ret;
        }

        /// <summary>
        /// 判断表达式是否正确
        /// </summary>
        /// <param name="_msg"></param>
        /// <returns></returns>
        private bool CheckExpression(string _expStr, int _maxNum, ref string _msg)
        {

            bool _ret = QueryExpression.ExpressCheck(_expStr, _maxNum);
            if (_ret)
            {
                _msg = "";
                return true;
            }
            else
            {
                _msg = "用户输入的条件表达式不正确!";
                return false;
            }

        }



        public void RefreshBySaveRequest(MDModel_QueryModel _qv, MDQuery_Request _request)
        {
            this.xtraScrollableControl1.Controls.Clear();
            foreach (MDQuery_ConditionItem _item in _request.ConditionItems)
            {
                switch (_item.Column.ColumnType)
                {
                    case QueryColumnType.TableColumn:
                        MDModel_Table_Column _cdefine = MC_QueryModel.GetColumnDefineByAlias(_qv, _item.Column.TableName, _item.Column.ColumnAlias);
                        AddSavedCondition(_cdefine, _item);
                        break;
                    case QueryColumnType.CalculationColumn:
                    case QueryColumnType.StatisticsColumn:
                        MDModel_Table_Column _ccdefine = new MDModel_Table_Column();
                        _ccdefine.ColumnDataType = _item.Column.ColumnDataType;
                        _ccdefine.ColumnTitle = _item.Column.ColumnTitle;
                        _ccdefine.ColumnAlgorithm = _item.Column.ColumnAlgorithm;
                        _ccdefine.ColumnName = "";
                        _ccdefine.ColumnType = _item.Column.ColumnType;
                        _ccdefine.TableName = _item.Column.TableName;
                        _ccdefine.DisplayLength = _item.Column.DisplayLength;
                        _ccdefine.DisplayFormat = _item.Column.DisplayFormat;
                        AddSavedCondition(_ccdefine, _item);
                        break;
                }

            }
            this.textEdit1.EditValue = _request.ConditionExpressions;
        }

        private void AddSavedCondition(MDModel_Table_Column _tc, MDQuery_ConditionItem _columnCodition)
        {

            SinoSZUC_ConditionItem _item = null;

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
                _item.SendToBack();
                this.xtraScrollableControl1.ScrollControlIntoView(_item);

                _item.SetInputValue(_columnCodition);
            }
        }

        private void textEdit1_SizeChanged(object sender, EventArgs e)
        {
            this.popupContainerControl1.Width = this.textEdit1.Width - 10;
        }



    }
}
