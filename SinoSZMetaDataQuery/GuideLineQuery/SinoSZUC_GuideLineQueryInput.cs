using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.Misc;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.Common;

namespace SinoSZMetaDataQuery.GuideLineQuery
{
        public partial class SinoSZUC_GuideLineQueryInput : DevExpress.XtraEditors.XtraUserControl
        {
                private MD_GuideLine guideLineDefine = null;
                private List<MD_GuideLineParameter> ParameterDefines = null;
                public SinoSZUC_GuideLineQueryInput()
                {
                        InitializeComponent();
                }
                public string DisplayTitle
                {
                        get
                        {
                                return this.xtraTabPage1.Text;
                        }
                        set { this.xtraTabPage1.Text = value; }
                }
                public bool InputFinised
                {
                        get
                        {
                                bool _ret = true;
                                foreach (Control _c in this.InputPanel.Controls)
                                {
                                        SinoSZUC_GLQ_InputItem _inputItem = _c as SinoSZUC_GLQ_InputItem;
                                        _ret = (_ret && _inputItem.HaveInputData);
                                }
                                return _ret;
                        }
                }
                public void InitForm(MD_GuideLine _guideLine)
                {
                        guideLineDefine = _guideLine;
                        ParameterDefines = MC_GuideLine.GetParametersFromMeta(_guideLine.GuideLineMeta);
                        this.InputPanel.Controls.Clear();
                        foreach (MD_GuideLineParameter _glp in ParameterDefines)
                        {
                                switch (_glp.ParameterType)
                                {
                                        case "逻辑型":
                                                break;
                                        case "代码表":
                                                SinoSZUC_GLQ_InputRefTable _refitem = new SinoSZUC_GLQ_InputRefTable(_glp);
                                                _refitem.InputChanged += new EventHandler(_dateitem_InputChanged);
                                                _refitem.Dock = DockStyle.Top;
                                                this.InputPanel.Controls.Add(_refitem);
                                                _refitem.BringToFront();
                                                break;
                                        case "日期型":
                                                SinoSZUC_GLQ_InputDate _dateitem = new SinoSZUC_GLQ_InputDate(_glp);
                                                _dateitem.InputChanged += new EventHandler(_dateitem_InputChanged);
                                                _dateitem.Dock = DockStyle.Top;
                                                this.InputPanel.Controls.Add(_dateitem);
                                                _dateitem.BringToFront();
                                                break;
                                        case "单位型(全部)":
                                        case "单位型(权限范围)":
                                        case "单位ID型(缉私局权限)":
                                        case "单位ID型(全部)":
                                        case "单位ID型(权限范围)":
                                        case "单位代码型(全部)":
                                        case "单位代码型(权限范围)":
                                                SinoSZUC_GLQ_InputOrg _orgItem = new SinoSZUC_GLQ_InputOrg(_glp, _glp.ParameterType);
                                                _orgItem.Dock = DockStyle.Top;
                                                _orgItem.InputChanged += new EventHandler(_dateitem_InputChanged);
                                                this.InputPanel.Controls.Add(_orgItem);
                                                _orgItem.BringToFront();
                                                break;
                                        default:
                                                SinoSZUC_GLQ_InputItem _item = new SinoSZUC_GLQ_InputItem(_glp);
                                                _item.Dock = DockStyle.Top;
                                                _item.InputChanged += new EventHandler(_dateitem_InputChanged);
                                                this.InputPanel.Controls.Add(_item);
                                                _item.BringToFront();
                                                break;
                                }
                        }
                }

                public void InitForm(MD_GuideLine _guideLine, string _paramValueSetting)
                {
                        guideLineDefine = _guideLine;
                        ParameterDefines = MC_GuideLine.GetParametersFromMeta(_guideLine.GuideLineMeta);
                        this.InputPanel.Controls.Clear();
                        foreach (MD_GuideLineParameter _glp in ParameterDefines)
                        {
                                string _paramValue = GetValueOfParam(_glp.ParameterName, _paramValueSetting);
                                switch (_glp.ParameterType)
                                {
                                        case "逻辑型":
                                                break;
                                        case "代码表":
                                                SinoSZUC_GLQ_InputRefTable _refitem = new SinoSZUC_GLQ_InputRefTable(_glp);
                                                _refitem.InputChanged += new EventHandler(_dateitem_InputChanged);
                                                _refitem.Dock = DockStyle.Top;
                                                _refitem.SetValueByXml(_paramValue);
                                                this.InputPanel.Controls.Add(_refitem);
                                                _refitem.BringToFront();
                                                break;
                                        case "日期型":
                                                SinoSZUC_GLQ_InputDate _dateitem = new SinoSZUC_GLQ_InputDate(_glp);
                                                _dateitem.SetValueByXml(_paramValue);
                                                _dateitem.InputChanged += new EventHandler(_dateitem_InputChanged);
                                                _dateitem.Dock = DockStyle.Top;
                                                this.InputPanel.Controls.Add(_dateitem);
                                                _dateitem.BringToFront();
                                                break;
                                        case "单位型(全部)":
                                        case "单位型(权限范围)":
                                        case "单位ID型(缉私局权限)":
                                        case "单位ID型(全部)":
                                        case "单位ID型(权限范围)":
                                        case "单位代码型(全部)":
                                        case "单位代码型(权限范围)":
                                                SinoSZUC_GLQ_InputOrg _orgItem = new SinoSZUC_GLQ_InputOrg(_glp, _glp.ParameterType);
                                                _orgItem.SetValueByXml(_paramValue);
                                                _orgItem.Dock = DockStyle.Top;
                                                _orgItem.InputChanged += new EventHandler(_dateitem_InputChanged);
                                                this.InputPanel.Controls.Add(_orgItem);
                                                _orgItem.BringToFront();
                                                break;
                                        default:
                                                SinoSZUC_GLQ_InputItem _item = new SinoSZUC_GLQ_InputItem(_glp);
                                                _item.SetValueByXml(_paramValue);
                                                _item.Dock = DockStyle.Top;
                                                _item.InputChanged += new EventHandler(_dateitem_InputChanged);
                                                this.InputPanel.Controls.Add(_item);
                                                _item.BringToFront();
                                                break;
                                }
                        }
                }

                private string GetValueOfParam(string _pName, string _paramValueSetting)
                {
                        string _valueStr = StrUtils.GetMetaByName(_pName, _paramValueSetting);
                        return _valueStr;
                }

                void _dateitem_InputChanged(object sender, EventArgs e)
                {
                        this.RaiseInputChanged();
                }


                [Category("WinFormEx")]
                public event EventHandler InputChanged;
                protected void RaiseInputChanged()
                {
                        EventArgs e = new EventArgs();
                        if (InputChanged != null)
                                InputChanged(this, e);
                }

                public List<MDQuery_GuideLineParameter> GetParamters()
                {
                        List<MDQuery_GuideLineParameter> _ret = new List<MDQuery_GuideLineParameter>();
                        foreach (Control _c in this.InputPanel.Controls)
                        {
                                SinoSZUC_GLQ_InputItem _inputItem = _c as SinoSZUC_GLQ_InputItem;
                                MDQuery_GuideLineParameter _cs = _inputItem.GetParameter();
                                _ret.Add(_cs);
                        }
                        return _ret;
                }



                public string ExportValueByXml()
                {
                        StringBuilder _sb =new StringBuilder();
                        foreach (SinoSZUC_GLQ_InputItem _inputItem in this.InputPanel.Controls)
                        {
                                _sb.Append(_inputItem.ExportValueByXml());
                        }
                        return _sb.ToString();
                }
        }
}
