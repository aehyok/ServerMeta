using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;



using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZMetaDataQuery.Common
{
    public partial class SinoSZUC_ConditionItem : UserControl
    {
        public event EventHandler<EventArgs> GetFocused;
        protected bool InitFinished = false;
        protected bool CaseSensitive = true;
        protected bool CanSelectMultiValue = false;
        protected MDModel_Table_Column ColumnDefine = null;
        virtual public void RaiseGetFocused()
        {
            if (GetFocused != null)
            {
                GetFocused(this, new EventArgs());
            }
        }


        public event EventHandler<EventArgs> LoseFocused;
        virtual public void RaiseLoseFocused()
        {
            if (LoseFocused != null)
            {
                LoseFocused(this, new EventArgs());
            }
        }

        protected Color _oldBackColor = Color.Transparent;

        public event EventHandler<EventArgs> RemoveCondition;
        virtual public void RaiseRemoveCondition()
        {
            if (RemoveCondition != null)
            {
                RemoveCondition(this, new EventArgs());
            }
        }


        public SinoSZUC_ConditionItem()
        {
            InitializeComponent();
            InitFinished = true;
        }

        public SinoSZUC_ConditionItem(MDModel_Table_Column _column)
        {
            InitializeComponent();
            ColumnDefine = _column;
            InitControls();
            initOperator();
            InitFinished = true;
        }

        public SinoSZUC_ConditionItem(MDQuery_ConditionItem _citem)
        {
            InitializeComponent();
            ColumnDefine = null;
            ShowValue(_citem);
            InitFinished = true;
        }

        private void ShowValue(MDQuery_ConditionItem _citem)
        {
            this.teColName.EditValue = _citem.Column.ColumnTitle;
            this.teOption.EditValue = _citem.Operator;
            string _valueStr = "";
            string _fg = "";
            foreach (string _s in _citem.Values)
            {
                _valueStr += string.Format("{0}{1}", _fg, _s);
                _fg = ",";
            }
            this.te_Value.EditValue = _valueStr;
            this.te_Value.Properties.ReadOnly = true;
            this.te_xh.EditValue = _citem.ColumnIndex;
        }

        virtual protected void InitControls()
        {
            switch (this.ColumnDefine.ColumnType)
            {
                case QueryColumnType.TableColumn:
                    this.teColName.Text = this.ColumnDefine.ColumnTitle;
                    break;
                case QueryColumnType.CalculationColumn:
                case QueryColumnType.StatisticsColumn:
                    this.teColName.Text = this.ColumnDefine.ColumnAlgorithm;
                    break;
            }
        }


        public void SetOrderNumber(int _number)
        {
            this.te_xh.Text = _number.ToString();
        }

        public int Index
        {
            get
            {
                return int.Parse(this.te_xh.Text);
            }
        }
        virtual protected void SinoSZUC_ConditionItem_Enter(object sender, EventArgs e)
        {
            _oldBackColor = this.teColName.BackColor;
            Color _newColor = Color.FromArgb(229, 255, 229);
            this.teColName.BackColor = _newColor;
            this.te_Value.BackColor = _newColor;
            this.teOption.BackColor = _newColor;
            this.te_xh.BackColor = _newColor;
            RaiseGetFocused();
        }

        virtual protected void SinoSZUC_ConditionItem_Leave(object sender, EventArgs e)
        {
            this.teColName.BackColor = _oldBackColor;
            this.te_Value.BackColor = _oldBackColor;
            this.teOption.BackColor = _oldBackColor;
            this.te_xh.BackColor = _oldBackColor;
            RaiseLoseFocused();
        }

        virtual protected void te_Value_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CaseSensitive = !CaseSensitive;
            if (CaseSensitive)
            {
                e.Button.Image = global::SinoSZMetaDataQuery.Properties.Resources.y7;
                e.Button.ToolTip = "当前状态为:区分大小写";
            }
            else
            {
                e.Button.Image = global::SinoSZMetaDataQuery.Properties.Resources.y8;
                e.Button.ToolTip = "当前状态为:不区分大小写";
            }

        }

        virtual protected void initOperator()
        {
            this.teOption.Properties.Items.Add(" 等于 ");
            this.teOption.Properties.Items.Add(" 不等于 ");
            this.teOption.Properties.Items.Add(" 包含 ");
            this.teOption.Properties.Items.Add(" 匹配 ");
            this.teOption.Properties.Items.Add(" 集合 ");
            this.teOption.Properties.Items.Add(" 为空值");
            this.teOption.Properties.Items.Add(" 为非空值");
            this.teOption.SelectedIndex = 0;
        }

        private void teOption_SelectedIndexChanged(object sender, EventArgs e)
        {

            string _selectOption = GetOperator();
            if (_selectOption == string.Empty)
            {
                return;
            }
            else
            {
                OptionChanged(_selectOption);
            }
        }

        /// <summary>
        /// 取用户选择的操作符
        /// </summary>
        /// <returns></returns>
        virtual public string GetOperator()
        {
            if (this.teOption.SelectedItem == null || !InitFinished) return string.Empty;
            string _selectOption = this.teOption.SelectedItem.ToString().Trim();
            return _selectOption;
        }

        /// <summary>
        /// 当用户选择操作符变化时的处理
        /// </summary>
        /// <param name="_selectOption"></param>
        virtual protected void OptionChanged(string _selectOption)
        {
            switch (_selectOption)
            {
                case "集合":
                    this.te_Value.ToolTip = "集合的格式为:\"字符串1,字符串2,....,字符串N\"";
                    this.te_Value.Enabled = true;
                    this.CanSelectMultiValue = true;
                    break;
                case "匹配":
                    this.te_Value.ToolTip = "匹配符为:\"%\",示例:\"N1%\"表示以N1开始的字符串,\"%N1\"表示以N1结束的字符串";
                    this.te_Value.Enabled = true;
                    this.CanSelectMultiValue = true;
                    break;
                case "为空值":
                case "为非空值":
                    ClearValue();
                    this.te_Value.ToolTip = "";
                    this.te_Value.Enabled = false;
                    this.CanSelectMultiValue = false;
                    break;
                default:
                    this.te_Value.ToolTip = "";
                    this.te_Value.Enabled = true;
                    this.CanSelectMultiValue = false;
                    break;
            }
        }

        virtual protected void AddValue(object _obj)
        {
            StringBuilder _sb = new StringBuilder();
            string _s = _obj.ToString();
            if (this.CanSelectMultiValue)
            {

                string _ctext = this.te_Value.EditValue.ToString();

                if (_ctext.Length > 0)
                {
                    _sb.Append(_ctext);
                    _sb.Append(",");
                    _sb.Append(_s);
                }
                else
                {
                    _sb.Append(_s);
                }
            }
            else
            {
                _sb.Append(_s);
            }
            this.te_Value.EditValue = _sb.ToString();
        }

        /// <summary>
        /// 清空值输入框
        /// </summary>
        virtual protected void ClearValue()
        {
            this.te_Value.Text = "";
        }



        /// <summary>
        /// 校验输入是否正确
        /// </summary>
        /// <param name="_errorMsg"></param>
        /// <returns></returns>
        virtual public bool CheckInput(ref string _errorMsg)
        {
            bool _ret = false;
            _errorMsg = "";
            string _selectOption = GetOperator();
            if (_selectOption == string.Empty)
            {
                _errorMsg = string.Format("用户未选择{0}字段的条件运算符！", this.ColumnDefine.ColumnTitle);
            }
            else
            {
                switch (_selectOption)
                {
                    case "为空值":
                    case "为非空值":
                        _ret = true;
                        break;
                    case "不等于":
                    case "等于":
                    case "包含":
                    case "匹配":
                    case "集合":
                        string _valuestr = this.te_Value.Text.Trim();
                        if (_valuestr == string.Empty)
                        {
                            _ret = false;
                            _errorMsg = string.Format("用户未输入{0}字段的条件值！", this.ColumnDefine.ColumnTitle);
                        }
                        else
                        {
                            _ret = true;
                        }
                        break;
                }
            }

            return _ret;
        }

        /// <summary>
        /// 取用户输入的查询条件项
        /// </summary>
        /// <returns></returns>
        virtual public MDQuery_ConditionItem GetConditionItem()
        {
            string _emsg = "";
            if (CheckInput(ref _emsg))
            {
                MDQuery_ConditionItem _ret = new MDQuery_ConditionItem();
                _ret.ColumnIndex = this.te_xh.Text;
                _ret.Column = new MDQuery_TableColumn(ColumnDefine);
                _ret.Operator = GetOperator();
                _ret.Values = GetConditionValues();
                _ret.CaseSensitive = this.CaseSensitive;
                return _ret;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 取当前输入的条件值集合
        /// </summary>
        /// <returns></returns>
        virtual public List<string> GetConditionValues()
        {
            List<string> _ret = new List<string>();
            if (this.CanSelectMultiValue)
            {
                string _s = this.te_Value.Text.Trim();
                foreach (string _value in _s.Split(','))
                {
                    _ret.Add(_value);
                }
            }
            else
            {
                _ret.Add(this.te_Value.Text.Trim());
            }
            return _ret;
        }


        /// <summary>
        /// 是否输入了内容
        /// </summary>
        /// <returns></returns>
        virtual public bool HaveInputData()
        {
            if (this.te_Value.Text.Trim() != "")
            {
                return true;
            }
            else
            {
                string _selectOption = GetOperator();
                switch (_selectOption)
                {
                    case "为空值":
                    case "为非空值":
                        return true;
                    default:
                        return false;
                }
            }

        }

        virtual public void SetInputValue(MDQuery_ConditionItem _columnCodition)
        {
            this.teOption.EditValue = _columnCodition.Operator;
            this.CaseSensitive = _columnCodition.CaseSensitive;
            this.te_xh.Text = _columnCodition.ColumnIndex;
            if (_columnCodition.Values.Count > 1)
            {
                string _valuestr = "";
                string _fg = "";
                foreach (string _v in _columnCodition.Values)
                {
                    _valuestr += string.Format("{0}{1}", _fg, _v);
                    _fg = ",";
                }
                this.te_Value.EditValue = _valuestr;
            }
            else
            {
                this.te_Value.EditValue = _columnCodition.Values[0];
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem _item = e.ClickedItem;
            switch (_item.Text)
            {
                case "移除条件":
                    RaiseRemoveCondition();
                    break;
            }
        }
    }
}
