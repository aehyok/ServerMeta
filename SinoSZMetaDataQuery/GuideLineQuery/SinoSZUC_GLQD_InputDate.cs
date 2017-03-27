using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SinoSZMetaDataQuery.Common;

using SinoSZJS.Base;
using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZMetaDataQuery.GuideLineQuery
{
        public partial class SinoSZUC_GLQD_InputDate : SinoSZUC_GLQD_InputItem
        {
                public SinoSZUC_GLQD_InputDate()
                        : base()
                { }

                public SinoSZUC_GLQD_InputDate(MD_GuideLineParameter _mdParameter)
                        : base(_mdParameter)
                { }

                protected override void InitControls()
                {
                        base.InitControls();
                        this.te_Value.Properties.Buttons[0].Image = global::SinoSZMetaDataQuery.Properties.Resources.y5;
                        this.te_Value.Properties.Buttons[0].ToolTip = "";
                        this.te_Value.Properties.Buttons[0].Visible = true;
                }

                protected override void ButtonClicked()
                {
                        Dialog_InputDate _f = new Dialog_InputDate();
                        Point _p = this.te_Value.PointToScreen(new Point(0, this.Height));
                        if ((_p.X + _f.Width) > Screen.PrimaryScreen.Bounds.Width)
                        {
                                _p.X = Screen.PrimaryScreen.Bounds.Width - _f.Width;
                        }

                        if ((_p.Y + _f.Height) > Screen.PrimaryScreen.Bounds.Height)
                        {
                                _p.Y = Screen.PrimaryScreen.Bounds.Height - _f.Height;
                        }
                        _f.Left = _p.X;
                        _f.Top = _p.Y;

                        if (_f.ShowDialog() == DialogResult.OK)
                        {
                                AddValue(_f.GetSelectedChineseData());
                        }
                }

                private void AddValue(string _dateStr)
                {
                        this.te_Value.EditValue = ReplaceDefaultDataStr(_dateStr);
                }

                private string ReplaceDefaultDataStr(string _dateStr)
                {
                        string _ret = _dateStr;
                        DateTime _dt = DateTime.Now;
                        _ret = _ret.Replace("#当年#", _dt.Year.ToString());
                        _ret = _ret.Replace("#当月#", _dt.Month.ToString("D2"));
                        _ret = _ret.Replace("#当日#", _dt.Day.ToString("D2"));
                        return _ret;
                }

                public override MDQuery_GuideLineParameter GetParameter()
                {
                        string _dt = this.te_Value.EditValue.ToString();
                        _dt = SinoSZDateFunction.ConvertStandardDateString(_dt);
                        MDQuery_GuideLineParameter _ret = new MDQuery_GuideLineParameter(paramDefine, _dt);
                        return _ret;
                }

                public override void SetValue(object _data)
                {
                        AddValue(_data.ToString());
                }

        }
}

