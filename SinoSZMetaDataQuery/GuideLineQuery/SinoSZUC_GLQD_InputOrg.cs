using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SinoSZClientBase.Organize;

using SinoSZJS.Base.Authorize;
using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZMetaDataQuery.GuideLineQuery
{
        public partial class SinoSZUC_GLQD_InputOrg : SinoSZUC_GLQD_InputItem
        {
                private string InputType = "";
                private SinoUC_OrgComboBox _uc;
                public SinoSZUC_GLQD_InputOrg()
                        : base()
                { }

                public SinoSZUC_GLQD_InputOrg(MD_GuideLineParameter _mdParameter)
                        : base(_mdParameter)
                { }

                public SinoSZUC_GLQD_InputOrg(MD_GuideLineParameter _mdParameter, string _type)
                {
                        InitializeComponent();
                        this.Width = _mdParameter.InputWidth;
                        paramDefine = _mdParameter;
                        InputType = _type;
                        InitControls();
                        InitFinished = true;
                }
                public override bool HaveInputData
                {
                        get
                        {
                                if (_uc == null) return false;
                                return _uc.Code >= 0;
                        }
                }
                protected override void InitControls()
                {
                        base.InitControls();
                        this.te_Value.Visible = false;
                        this.te_Value.Properties.Buttons[0].Image = global::SinoSZMetaDataQuery.Properties.Resources.y5;
                        this.te_Value.Properties.Buttons[0].ToolTip = "";
                        this.te_Value.Properties.Buttons[0].Visible = true;

                        _uc = new SinoUC_OrgComboBox();
                        _uc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        _uc.CodeChanged += new EventHandler(_uc_CodeChanged);
                        _uc.ForeColor = Color.Blue;
                        _uc.Properties.AutoHeight = false;
                        switch (InputType)
                        {
                                case "单位型(全部)":
                                        _uc.InitRootDWID(SessionClass.RootOrgID);
                                        break;
                                case "单位型(权限范围)":
                                        _uc.InitRootDWID(SessionClass.CurrentSinoUser.CurrentPost.PostDwID);
                                        break;
                                case "单位ID型(缉私局权限)":
                                        _uc.InitRootDWID(SessionClass.CurrentSinoUser.CurrentPost.PostDwID);
                                        break;
                                case "单位ID型(全部)":
                                        _uc.InitRootDWID(SessionClass.RootOrgID);
                                        break;
                                case "单位ID型(权限范围)":
                                        _uc.InitRootDWID(SessionClass.CurrentSinoUser.CurrentPost.PostDwID);
                                        break;
                                case "单位代码型(全部)":
                                        _uc.InitRootDWID(SessionClass.RootOrgID);
                                        break;
                                case "单位代码型(权限范围)":
                                        _uc.InitRootDWID(SessionClass.CurrentSinoUser.CurrentPost.PostDwID);
                                        break;
                        }
                        _uc.Dock = DockStyle.Fill;
                        this.Controls.Add(_uc);
                        _uc.BringToFront();
                }

                void _uc_CodeChanged(object sender, EventArgs e)
                {
                        this.RaiseInputChanged();
                }

                public override MDQuery_GuideLineParameter GetParameter()
                {
                        string _dwcode = "";
                        switch (InputType)
                        {
                                case "单位型(全部)":

                                case "单位型(权限范围)":

                                case "单位ID型(缉私局权限)":

                                case "单位ID型(全部)":

                                case "单位ID型(权限范围)":
                                        _dwcode = this._uc.Code.ToString();
                                        break;
                                case "单位代码型(全部)":

                                case "单位代码型(权限范围)":
                                        _dwcode = this._uc.DWDM;
                                        break;
                        }

                        MDQuery_GuideLineParameter _ret = new MDQuery_GuideLineParameter(paramDefine, _dwcode);
                        return _ret;
                }

                public override void SetValue(object _data)
                {
                        this._uc.SelectedCode(decimal.Parse(_data.ToString()));
                }

        }
}

