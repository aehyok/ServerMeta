using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using SinoSZJS.Base;

using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZMetaDataQuery.Common
{
        public partial class SinoSZUC_ConditionItem_Number : SinoSZUC_ConditionItem
        {
                public SinoSZUC_ConditionItem_Number()
                        : base()
                { }

                public SinoSZUC_ConditionItem_Number(MDModel_Table_Column _column)
                        : base(_column)
                { }

                protected override void InitControls()
                {
                        base.InitControls();
                        this.te_Value.Properties.Buttons[0].Visible = false;
                }

                protected override void initOperator()
                {
                        this.teOption.Properties.Items.Clear();
                        this.teOption.Properties.Items.Add(" 等于 ");
                        this.teOption.Properties.Items.Add(" 不等于 ");
                        this.teOption.Properties.Items.Add(" 大于 ");
                        this.teOption.Properties.Items.Add(" 大于等于 ");
                        this.teOption.Properties.Items.Add(" 小于 ");
                        this.teOption.Properties.Items.Add(" 小于等于 ");
                        this.teOption.Properties.Items.Add(" 集合 ");
                        this.teOption.Properties.Items.Add(" 范围 ");
                        this.teOption.Properties.Items.Add(" 为空值");
                        this.teOption.Properties.Items.Add(" 为非空值");
                        this.teOption.SelectedIndex = 0;
                }

                /// <summary>
                /// 当用户选择操作符变化时的处理
                /// </summary>
                /// <param name="_selectOption"></param>
                override protected void OptionChanged(string _selectOption)
                {
                        switch (_selectOption)
                        {
                                case "范围":
                                        this.te_Value.ToolTip = "数据范围的格式为:\"数值1,数值2\",　表示的范围是:大于等于数值1,小于等于数值2";
                                        this.te_Value.Enabled = true;
                                        this.CanSelectMultiValue = true;
                                        break;
                                case "集合":
                                        this.te_Value.ToolTip = "数据集合的格式为:\"数值1,数值2,...,数值N\",　表示的范围是:大于等于数值1,小于等于数值2";
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

                public override bool CheckInput(ref string _errorMsg)
                {
                        string _selectOption = GetOperator();
                        string[] _numStrs;
                        switch (_selectOption)
                        {
                                case "范围":
                                        if (this.te_Value.EditValue == null || this.te_Value.EditValue.ToString() == "")
                                        {
                                                _errorMsg = string.Format("用户未输入[{0}]字段的值！", this.ColumnDefine.ColumnTitle);
                                                return false;
                                        }
                                        _numStrs = this.te_Value.EditValue.ToString().Trim().Split(',');
                                        if (_numStrs.Length != 2)
                                        {
                                                _errorMsg = string.Format("用户未输入[{0}]的范围数值不正确！", this.ColumnDefine.ColumnTitle);
                                                return false;
                                        }
                                        else
                                        {
                                                if (!SinoSZNumberFunction.CheckNumberStringFormat(_numStrs[0]))
                                                {
                                                        _errorMsg = string.Format("用户输入[{0}]的数据范围开始值不正确！", this.ColumnDefine.ColumnTitle);
                                                        return false;
                                                }
                                                if (!SinoSZNumberFunction.CheckNumberStringFormat(_numStrs[1]))
                                                {
                                                        _errorMsg = string.Format("用户输入[{0}]的数据范围结束值不正确！", this.ColumnDefine.ColumnTitle);
                                                        return false;
                                                }

                                                decimal _d1 = decimal.Parse(_numStrs[0]);
                                                decimal _d2 = decimal.Parse(_numStrs[1]);
                                                if (_d1 > _d2)
                                                {
                                                        _errorMsg = string.Format("用户输入[{0}]的数值范围不正确:结束值不可小于开始值！", this.ColumnDefine.ColumnTitle);
                                                        return false;
                                                }
                                        }
                                        return true;

                                case "集合":
                                        if (this.te_Value.EditValue == null || this.te_Value.EditValue.ToString() == "")
                                        {
                                                _errorMsg = string.Format("用户未输入[{0}]字段的值！", this.ColumnDefine.ColumnTitle);
                                                return false;
                                        }
                                        _numStrs = this.te_Value.EditValue.ToString().Trim().Split(',');
                                        int i = 1;
                                        foreach (string _s in _numStrs)
                                        {
                                                if (!SinoSZNumberFunction.CheckNumberStringFormat(_s))
                                                {
                                                        _errorMsg = string.Format("用户输入[{0}]的第{1}个数值格式不正确！", this.ColumnDefine.ColumnTitle,
                                                                i);
                                                        return false;
                                                }
                                                i++;
                                        }
                                        return true;

                                case "为空值":
                                case "为非空值":
                                        _errorMsg = "";
                                        return true;
                                default:
                                        if (this.te_Value.EditValue == null || this.te_Value.EditValue.ToString() == "")
                                        {
                                                _errorMsg = string.Format("用户未输入[{0}]字段的值！", this.ColumnDefine.ColumnTitle);
                                                return false;
                                        }
                                        string _dateStr = this.te_Value.EditValue.ToString();
                                        if (!SinoSZNumberFunction.CheckNumberStringFormat(_dateStr))
                                        {
                                                _errorMsg = string.Format("用户输入[{0}]的数值不正确！", this.ColumnDefine.ColumnTitle);
                                                return false;
                                        }
                                        else
                                        {
                                                return true;
                                        }
                                        
                        }
                }
               
        }
}
