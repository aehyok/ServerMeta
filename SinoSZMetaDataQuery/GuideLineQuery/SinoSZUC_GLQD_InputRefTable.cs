using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SinoSZClientBase.RefCode;


using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZMetaDataQuery.GuideLineQuery
{
    public partial class SinoSZUC_GLQD_InputRefTable : SinoSZMetaDataQuery.GuideLineQuery.SinoSZUC_GLQD_InputItem
    {
        private RefCodeBox _uc;
        public SinoSZUC_GLQD_InputRefTable()
        {
            InitializeComponent();
        }

        public SinoSZUC_GLQD_InputRefTable(MD_GuideLineParameter _mdParameter)
            : base(_mdParameter)
        { }


        public override bool HaveInputData
        {
            get
            {
                if (_uc == null) return false;
                return _uc.Code.Length > 0;
            }
        }

        protected override void InitControls()
        {
            Font UseFont = null;
            try
            {

                base.InitControls();
                this.te_Value.Visible = false;

                _uc = new RefCodeBox();
                _uc.ForeColor = Color.Blue;
                _uc.CanEdit = true;
                _uc.CanMultiSelect = false;
                _uc.Dock = System.Windows.Forms.DockStyle.Fill;
                _uc.Location = new System.Drawing.Point(0, 1);
                _uc.Name = "refCodeBox1";
                _uc.Properties.AutoHeight = false;
                _uc.Properties.AllowFocused = false;
                UseFont = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                _uc.Properties.Appearance.Font = UseFont;
                _uc.Properties.Appearance.Options.UseFont = true;
                _uc.Properties.Appearance.Options.UseTextOptions = true;
                _uc.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
                _uc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                //refCodeBox1.Properties.Name = "_properties";
                _uc.ReadOnly = false;
                if (paramDefine.CanSelectAll)
                {
                    _uc.AddAllCode(paramDefine.SelectAllCode);
                }

                _uc.RefTableName = paramDefine.RefTableName;
                _uc.Size = new System.Drawing.Size(450, 20);
                _uc.TabIndex = 13;
                _uc.Properties.LookAndFeel.UseDefaultLookAndFeel = false;

                _uc.CodeChanged += new EventHandler(_uc_CodeChanged);

                _uc.Dock = DockStyle.Fill;
                this.Controls.Add(_uc);
                _uc.BringToFront();
            }
            finally
            {
                if (UseFont != null)
                {
                    UseFont.Dispose();
                }
            }

        }

        void _uc_CodeChanged(object sender, EventArgs e)
        {
            this.RaiseInputChanged();
        }

        public override void SetValue(object _data)
        {
            this._uc.Code = _data.ToString();
        }

        public override MDQuery_GuideLineParameter GetParameter()
        {
            MDQuery_GuideLineParameter _ret = new MDQuery_GuideLineParameter(paramDefine, this._uc.Code);
            return _ret;
        }

    }
}

