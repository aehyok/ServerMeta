using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SinoSZClientBase.RefCode;


using System.Xml;
using SinoSZJS.Base.Misc;
using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZMetaDataQuery.GuideLineQuery
{
    public partial class SinoSZUC_GLQ_InputRefTable : SinoSZMetaDataQuery.GuideLineQuery.SinoSZUC_GLQ_InputItem
    {
        private RefCodeBox _uc;
        public SinoSZUC_GLQ_InputRefTable()
        {
            InitializeComponent();
        }

        public SinoSZUC_GLQ_InputRefTable(MD_GuideLineParameter _mdParameter)
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

            base.InitControls();
            this.te_Value.Visible = false;
            Font UseFont = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            try
            {
                _uc = new RefCodeBox();
                _uc.ForeColor = Color.Blue;
                _uc.CanEdit = true;
                _uc.CanMultiSelect = false;
                _uc.Dock = System.Windows.Forms.DockStyle.Fill;
                _uc.Location = new System.Drawing.Point(0, 1);
                _uc.Name = "refCodeBox1";
                _uc.Properties.AutoHeight = false;
                _uc.Properties.AllowFocused = false;

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
                UseFont = null;
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
        public override string ExportValueByXml()
        {
            string _lx = "";
            _lx += string.Format("<{0}>", this.ParamDefine.ParameterName);
            string _data = "";
            if (this._uc.CanMultiSelect)
            {
                _lx += "<REF_MUTI>TRUE</REF_MUTI>";
                foreach (string key in this._uc.GetValues())
                {
                    _data += string.Format("<REF_DATA><REF_CODE>{0}</REF_CODE><REF_TEXT></REF_TEXT></REF_DATA>", key);
                }
            }
            else
            {
                _lx += "<REF_MUTI>FALSE</REF_MUTI>";
                _data = string.Format("<REF_DATA><REF_CODE>{0}</REF_CODE><REF_TEXT></REF_TEXT></REF_DATA>", this._uc.Code, "");
            }
            return _lx + _data + string.Format("</{0}>", this.ParamDefine.ParameterName); ;
        }
        public override void SetValueByXml(string _xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(string.Format("<XmlText>{0}</XmlText>", _xml));

            XmlNodeList elemList = doc.GetElementsByTagName("REF_MUTI");
            if (elemList.Count < 1)
            {
                this._uc.CanMultiSelect = false;
            }
            else
            {
                this._uc.CanMultiSelect = (elemList[0].InnerText == "TRUE") ? true : false;
            }

            XmlNodeList dataList = doc.GetElementsByTagName("REF_DATA");
            List<string> _selectedValues = new List<string>();
            for (int i = 0; i < dataList.Count; i++)
            {
                string _s2 = StrUtils.GetMetaByName("REF_CODE", dataList[i].InnerXml);
                _selectedValues.Add(_s2);
            }
            this._uc.SetValues(_selectedValues);
        }

        public override MDQuery_GuideLineParameter GetParameter()
        {
            MDQuery_GuideLineParameter _ret = new MDQuery_GuideLineParameter(paramDefine, this._uc.Code);
            return _ret;
        }

    }
}

