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
        public partial class SinoSZUC_GLQD_InputItem : UserControl
        {
                protected MD_GuideLineParameter paramDefine = null;
                protected Color _oldBackColor = Color.Transparent;
                protected bool InitFinished = false;
                public SinoSZUC_GLQD_InputItem()
                {
                        InitializeComponent();
                        InitFinished = true;
                }

                public SinoSZUC_GLQD_InputItem(MD_GuideLineParameter _mdParameter)
                {
                        InitializeComponent();
                        this.Width = _mdParameter.InputWidth;
                        paramDefine = _mdParameter;
                        InitControls();
                        InitFinished = true;
                }

                #region 自定义事件
                [Category("WinFormEx")]
                public event EventHandler InputChanged;
                protected void RaiseInputChanged()
                {
                        EventArgs e = new EventArgs();
                        if (InputChanged != null)
                                InputChanged(this, e);
                }
                #endregion


                #region 可重载的方法
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

                virtual public Color LabelColor
                {
                        get { return this.te_ColName.ForeColor; }
                        set { this.te_ColName.ForeColor = value; }
                }

                virtual protected void InitControls()
                {
                        this.te_ColName.Text = paramDefine.DisplayTitle;
                        int _width = this.te_ColName.Width;
                        this.te_ColName.AutoSize = false;
                        this.te_ColName.Width = _width+6;
                        this.te_Value.Properties.Buttons[0].Visible = false;
                }

                virtual protected void EnterValueBox()
                {
                        _oldBackColor = this.te_ColName.BackColor;
                        Color _newColor = Color.FromArgb(229, 255, 229);
                        this.te_Value.BackColor = _newColor;
                }

                virtual protected void LeaveValueBox()
                {
                        this.te_Value.BackColor = _oldBackColor;
                }
                
                virtual protected void ButtonClicked()
                {

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

                #endregion

                private void te_Value_Enter(object sender, EventArgs e)
                {
                        EnterValueBox();
                }

                private void te_Value_Leave(object sender, EventArgs e)
                {
                        LeaveValueBox();
                }

                private void te_Value_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
                {
                        ButtonClicked();
                }

                private void te_Value_EditValueChanged(object sender, EventArgs e)
                {
                        RaiseInputChanged();
                }


        }
}
