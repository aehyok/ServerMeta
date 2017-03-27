using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZMetaDataQuery.GuideLineQuery
{
        public partial class SinoSZUC_GLQ_InputItem : UserControl
        {
                protected MD_GuideLineParameter paramDefine = null;
                protected Color _oldBackColor = Color.Transparent;
                protected bool InitFinished = false;
                public SinoSZUC_GLQ_InputItem()
                {
                        InitializeComponent();
                        InitFinished = true;
                }

                virtual public MD_GuideLineParameter ParamDefine
                {
                        get { return paramDefine; }
                }

                virtual public bool HaveInputData
                {
                        get
                        {
                                if (this.te_Value.EditValue == null || this.te_Value.EditValue.ToString() == "")
                                {
                                        return false;
                                }
                                return true;
                        }
                }
                public SinoSZUC_GLQ_InputItem(MD_GuideLineParameter _mdParameter)
                {
                        InitializeComponent();
                        paramDefine = _mdParameter;
                        InitControls();
                        InitFinished = true;
                }

                virtual protected void InitControls()
                {
                        this.teColName.Text = paramDefine.DisplayTitle;
                        this.te_Value.Properties.Buttons[0].Visible = false;
                }

                private void te_Value_Enter(object sender, EventArgs e)
                {
                        _oldBackColor = this.teColName.BackColor;
                        Color _newColor = Color.FromArgb(229, 255, 229);
                        this.te_Value.BackColor = _newColor;
                }

                private void te_Value_Leave(object sender, EventArgs e)
                {
                        this.te_Value.BackColor = _oldBackColor;
                }

                private void te_Value_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
                {
                        ButtonClicked();
                }

                virtual protected void ButtonClicked()
                {

                }

                private void te_Value_EditValueChanged(object sender, EventArgs e)
                {
                        RaiseInputChanged();
                }

                [Category("WinFormEx")]
                public event EventHandler InputChanged;
                protected void RaiseInputChanged()
                {
                        EventArgs e = new EventArgs();
                        if (InputChanged != null)
                                InputChanged(this, e);
                }

                virtual public MDQuery_GuideLineParameter GetParameter()
                {
                        MDQuery_GuideLineParameter _ret = new MDQuery_GuideLineParameter(paramDefine, this.te_Value.EditValue);
                        return _ret;
                }

                virtual public void SetValue(object _data)
                {
                        this.te_Value.EditValue = _data;
                }

                virtual public void SetValueByXml(string _xml)
                {
                        this.te_Value.EditValue = _xml;
                }

                virtual public string ExportValueByXml()
                {
                        StringBuilder _ret = new StringBuilder();
                        _ret.Append(string.Format("<{0}>", this.ParamDefine.ParameterName));
                        if (this.te_Value.EditValue != null) _ret.Append(this.te_Value.EditValue.ToString());
                        _ret.Append(string.Format("</{0}>", this.ParamDefine.ParameterName));
                        return _ret.ToString();
                }
        }
}
