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
        public partial class SinoSZUC_ConditionItem_Date : SinoSZUC_ConditionItem
        {
                public SinoSZUC_ConditionItem_Date()
                        : base()
                { }

                public SinoSZUC_ConditionItem_Date(MDModel_Table_Column _column)
                        : base(_column)
                { }


                /// <summary>
                /// 初始化运算符
                /// </summary>
                protected override void initOperator()
                {
                        this.teOption.Properties.Items.Clear();
                        this.teOption.Properties.Items.Add(" 等于 ");
                        this.teOption.Properties.Items.Add(" 时间段 ");
                        this.teOption.Properties.Items.Add(" 集合 ");
                        this.teOption.Properties.Items.Add(" 不等于 ");
                        this.teOption.Properties.Items.Add(" 大于 ");
                        this.teOption.Properties.Items.Add(" 大于等于 ");
                        this.teOption.Properties.Items.Add(" 小于 ");
                        this.teOption.Properties.Items.Add(" 小于等于 ");

                        this.teOption.Properties.Items.Add(" 为空值");
                        this.teOption.Properties.Items.Add(" 为非空值");

                        this.teOption.SelectedIndex = 0;
                        this.te_Value.ToolTip = "日期的标准格式为:\"YYYY-MM-DD\",　也可以使用格式\"YYYYMMDD\" 或 \"YYYY/MM/DD\"";
                }

                /// <summary>
                /// 当用户选择操作符变化时的处理
                /// </summary>
                /// <param name="_selectOption"></param>
                override protected void OptionChanged(string _selectOption)
                {
                        switch (_selectOption)
                        {
                                case "时间段":
                                        this.te_Value.ToolTip = "时间段的格式为:\"YYYY-MM-DD,YYYY-MM-DD\",其中的日期可以使用格式\"YYYYMMDD\" 或 \"YYYY/MM/DD\"";
                                        this.te_Value.Enabled = true;
                                        this.CanSelectMultiValue = true;
                                        break;
                                case "集合":
                                        this.te_Value.Enabled = true;
                                        this.CanSelectMultiValue = true;
                                        this.te_Value.ToolTip = "集合的格式为:\"YYYY-MM-DD,YYYY-MM-DD,....,YYYY-MM-DD\",其中的日期可以使用格式\"YYYYMMDD\" 或 \"YYYY/MM/DD\"";
                                        break;
                                case "为空值":
                                case "为非空值":
                                        ClearValue();
                                        this.te_Value.ToolTip = "";
                                        this.te_Value.Enabled = false;
                                        this.CanSelectMultiValue = false;
                                        break;
                                default:
                                        this.te_Value.ToolTip = "日期的标准格式为:\"YYYY-MM-DD\",　也可以使用格式\"YYYYMMDD\" 或 \"YYYY/MM/DD\"";
                                        this.te_Value.Enabled = true;
                                        this.CanSelectMultiValue = false;
                                        break;
                        }
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
                                string[] _dateStrs = (this.te_Value.EditValue == null) ? "".Split(',') : this.te_Value.EditValue.ToString().Trim().Split(',');
                                switch (_selectOption)
                                {
                                        case "为空值":
                                        case "为非空值":
                                                _errorMsg = "";
                                                return true;

                                        case "时间段":
                                                if (_dateStrs.Length != 2)
                                                {
                                                        _errorMsg = string.Format("用户未输入[{0}]的时间段值不正确！", this.ColumnDefine.ColumnTitle);
                                                        return false;
                                                }
                                                else
                                                {
                                                        if (!SinoSZDateFunction.CheckDateStringFormat(_dateStrs[0]))
                                                        {
                                                                _errorMsg = string.Format("用户输入[{0}]的时间段开始值不正确！", this.ColumnDefine.ColumnTitle);
                                                                return false;
                                                        }
                                                        if (!SinoSZDateFunction.CheckDateStringFormat(_dateStrs[1]))
                                                        {
                                                                _errorMsg = string.Format("用户输入[{0}]的时间段结束值不正确！", this.ColumnDefine.ColumnTitle);
                                                                return false;
                                                        }

                                                        DateTime _sDate = SinoSZDateFunction.ConvertDateTimeType(_dateStrs[0]);
                                                        DateTime _eDate = SinoSZDateFunction.ConvertDateTimeType(_dateStrs[1]);
                                                        if (_sDate > _eDate)
                                                        {
                                                                _errorMsg = string.Format("用户输入[{0}]的时间段值不正确:结束值不可小于开始值！", this.ColumnDefine.ColumnTitle);
                                                                return false;
                                                        }
                                                }
                                                return true;

                                        case "集合":
                                                int i = 1;
                                                foreach (string _s in _dateStrs)
                                                {
                                                        if (!SinoSZDateFunction.CheckDateStringFormat(_s))
                                                        {
                                                                _errorMsg = string.Format("用户输入[{0}]的第{1}个日期值不正确！", this.ColumnDefine.ColumnTitle,
                                                                        i);
                                                                return false;
                                                        }
                                                        i++;
                                                }
                                                return true;


                                        default:
                                                string _dateStr = (this.te_Value.EditValue == null) ? "" : this.te_Value.EditValue.ToString();
                                                if (!SinoSZDateFunction.CheckDateStringFormat(_dateStr))
                                                {
                                                        _errorMsg = string.Format("用户输入[{0}]的日期值不正确！", this.ColumnDefine.ColumnTitle);
                                                        return false;
                                                }
                                                else
                                                {
                                                        return true;
                                                }
                                }
                        }
                }


                protected override void InitControls()
                {
                        base.InitControls();
                        this.te_Value.Properties.Buttons[0].Image = global::SinoSZMetaDataQuery.Properties.Resources.y5;
                        this.te_Value.Properties.Buttons[0].ToolTip = "";
                }

                protected override void te_Value_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
                {
                        Dialog_InputDate _f = new Dialog_InputDate();
                        Point _p = this.te_Value.PointToScreen(new Point(0, this.Height));
                        _f.Left = _p.X;
                        _f.Top = _p.Y;

                        if (_f.ShowDialog() == DialogResult.OK)
                        {

                                AddValue(_f.GetSelectedData());
                        }
                }

                /// <summary>
                /// 添加一个值
                /// </summary>
                /// <param name="_obj"></param>
                protected override void AddValue(object _obj)
                {
                        DateTime _cDate;
                        if (!SinoSZDateFunction.CheckDateStringFormat(_obj.ToString())) return;
                        string _cDateStr = SinoSZDateFunction.ConvertStandardDateString(_obj.ToString());
                        string _operator = GetOperator();
                        if (_operator == "时间段")
                        {
                                if (this.te_Value.EditValue == null)
                                {
                                        this.te_Value.EditValue = _cDateStr;
                                }
                                else
                                {
                                        string[] _dateStrs = this.te_Value.EditValue.ToString().Trim().Split(',');
                                        switch (_dateStrs.Length)
                                        {

                                                case 1:
                                                        if (!SinoSZDateFunction.CheckDateStringFormat(_dateStrs[0]))
                                                        {
                                                                this.te_Value.EditValue = _cDateStr;
                                                        }
                                                        else
                                                        {
                                                                string _oldDateStr = SinoSZDateFunction.ConvertStandardDateString(_dateStrs[0]);
                                                                DateTime _oldDate = SinoSZDateFunction.ConvertDateTimeType(_oldDateStr);
                                                                _cDate = SinoSZDateFunction.ConvertDateTimeType(_cDateStr);
                                                                if (_oldDate > _cDate)
                                                                {
                                                                        this.te_Value.EditValue = string.Format("{0},{1}", _cDateStr, _oldDateStr);
                                                                }
                                                                else
                                                                {
                                                                        this.te_Value.EditValue = string.Format("{1},{0}", _cDateStr, _oldDateStr);
                                                                }
                                                        }
                                                        break;
                                                case 2:
                                                        DateTime _fDate = DateTime.MinValue;
                                                        if (SinoSZDateFunction.CheckDateStringFormat(_dateStrs[0]))
                                                        {
                                                                _fDate = SinoSZDateFunction.ConvertDateTimeType(_dateStrs[0]);
                                                        }
                                                        DateTime _sDate = DateTime.MinValue;
                                                        if (SinoSZDateFunction.CheckDateStringFormat(_dateStrs[1]))
                                                        {
                                                                _sDate = SinoSZDateFunction.ConvertDateTimeType(_dateStrs[1]);
                                                        }
                                                        _cDate = SinoSZDateFunction.ConvertDateTimeType(_cDateStr);

                                                        if (_cDate < _fDate)
                                                        {
                                                                _fDate = _cDate;
                                                        }
                                                        else if (_cDate > _fDate && _cDate < _sDate)
                                                        {
                                                                _fDate = _cDate;
                                                        }
                                                        else if (_cDate > _sDate)
                                                        {
                                                                _sDate = _cDate;
                                                        }

                                                        this.te_Value.EditValue = string.Format("{0},{1}", SinoSZDateFunction.ConvertStandardDateString(_fDate),
                                                                SinoSZDateFunction.ConvertStandardDateString(_sDate));
                                                        break;

                                        }
                                }

                        }
                        else
                        {
                                base.AddValue(_cDateStr);
                        }
                }

                public override List<string> GetConditionValues()
                {
                        string _msg = "";
                        if (!CheckInput(ref _msg)) return null;

                        List<string> _ret = new List<string>();
                        string _s = this.te_Value.EditValue.ToString().Trim();
                        foreach (string _value in _s.Split(','))
                        {
                                _ret.Add(SinoSZDateFunction.ConvertStandardDateString(_value));
                        }

                        return _ret;
                }


        }
}
