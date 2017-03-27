using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.Define;
using SinoSZClientBase.MetaDataService;
using SinoSZJS.Base.MetaData.Common;

namespace SinoSZMetaDataManager
{
    public partial class UC_View2GLInfo : DevExpress.XtraEditors.XtraUserControl
    {
        private bool _initFinished = false;
        Dialog_SelectGuideLine _ds = null;
        MD_View_GuideLine CurrentV2gl = null;
        private string v2gid = "";
        private string glid = "";
        public UC_View2GLInfo()
        {
            InitializeComponent();

        }
        public event EventHandler<EventArgs> DataChanged;
        public void RaiseDataChanged()
        {
            if (DataChanged != null)
            {
                DataChanged(this, new EventArgs());
            }

        }

        public void initData(MD_View_GuideLine _value)
        {
            CurrentV2gl = _value;
            this.v2gid = _value.ID;
            this.GuideLineID = _value.TargetGuideLineID;
            this.buttonEdit1.EditValue = this.GuideLineID;
            RefreshParams(_value.RelationParam);
            DisplayOrder = _value.DisplayOrder;
            DisplayTitle = _value.DisplayTitle;
            _initFinished = true;
        }

        public string V2GID
        {
            get { return v2gid; }
            set { v2gid = value; }
        }

        public string GuideLineID
        {
            get { return glid; }
            set { glid = value; }
        }

        public string Parameters
        {
            get
            {
                if (this.gridView1.RowCount < 1) return "";
                StringBuilder _ret = new StringBuilder();
                for (int i = 0; i < this.gridView1.RowCount; i++)
                {
                    object csName = this.gridView1.GetRowCellValue(i, "Name");
                    _ret.Append((csName == null) ? "" : csName.ToString());
                    _ret.Append("=");
                    object csValue = this.gridView1.GetRowCellValue(i, "DataValue");
                    _ret.Append((csValue == null) ? "" : csValue.ToString());
                    _ret.Append(";");
                }
                return _ret.ToString();
            }

        }

        public int DisplayOrder
        {
            get
            {
                try
                {
                    string _s = (this.textEdit2.EditValue == null) ? "0" : this.textEdit2.EditValue.ToString();
                    return int.Parse(_s);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                this.textEdit2.EditValue = value;
            }
        }

        public string DisplayTitle
        {
            get
            {
                return (this.textEdit1.EditValue == null) ? "" : this.textEdit1.EditValue.ToString();
            }
            set
            {
                this.textEdit1.EditValue = value;
            }
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (_ds == null) _ds = new Dialog_SelectGuideLine();
            if (_ds.ShowDialog() == DialogResult.OK)
            {
                this.buttonEdit1.EditValue = _ds.GuideLineID;
                RefreshParams();
            }
        }

        private void RefreshParams()
        {
            string id = this.buttonEdit1.EditValue.ToString();
            if (id != null && id != string.Empty)
            {
                glid = id;
                List<MD_GuideLineDetailParameter> _ret = new List<MD_GuideLineDetailParameter>();
                using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
                {

                    MD_GuideLine _gl = _mdc.GetGuideLineDefine(id);
                    List<MD_GuideLineParameter> _gParam = MC_GuideLine.GetParametersFromMeta(_gl.GuideLineMeta);
                    foreach (MD_GuideLineParameter _p in _gParam)
                    {
                        _ret.Add(new MD_GuideLineDetailParameter(_p.ParameterName, _p.DisplayTitle, _p.ParameterType, ""));
                    }
                    this.sinoCommonGrid1.DataSource = _ret;
                }
            }
        }


        private void RefreshParams(string strParams)
        {
            string id = this.buttonEdit1.EditValue.ToString();
            if (id != null && id != string.Empty)
            {
                Dictionary<string, string> _psdict = new Dictionary<string, string>();
                foreach (string _s in strParams.Split(';'))
                {
                    if (_s != null && _s.Trim() != "")
                    {
                        string[] _vs = _s.Split('=');
                        _psdict.Add(_vs[0], _vs[1]);
                    }
                }
                glid = id;
                List<MD_GuideLineDetailParameter> _ret = new List<MD_GuideLineDetailParameter>();
                MetaDataServiceClient _mdc = new MetaDataServiceClient();
                MD_GuideLine _gl = _mdc.GetGuideLineDefine(id);
                List<MD_GuideLineParameter> _gParam = MC_GuideLine.GetParametersFromMeta(_gl.GuideLineMeta);
                foreach (MD_GuideLineParameter _p in _gParam)
                {
                    if (_psdict.ContainsKey(_p.ParameterName))
                    {
                        _ret.Add(new MD_GuideLineDetailParameter(_p.ParameterName, _p.DisplayTitle, _p.ParameterType, _psdict[_p.ParameterName]));
                    }
                    else
                    {
                        _ret.Add(new MD_GuideLineDetailParameter(_p.ParameterName, _p.DisplayTitle, _p.ParameterType, ""));
                    }
                }
                this.sinoCommonGrid1.DataSource = _ret;
            }
        }


        public bool CheckInput(ref string _msg)
        {
            _msg = "";
            string _glid = (this.buttonEdit1.EditValue == null) ? "" : this.buttonEdit1.EditValue.ToString().Trim();
            if (_glid == string.Empty)
            {
                _msg = "请选择指标ID";
                return false;
            }
            if (this.textEdit1.EditValue == null || this.textEdit1.EditValue.ToString().Trim() == string.Empty)
            {
                _msg = "请输入显示标题";
                return false;
            }
            return true;
        }

        private void buttonEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (_initFinished) RaiseDataChanged();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (_initFinished) RaiseDataChanged();
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            if (_initFinished) RaiseDataChanged();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (_initFinished) RaiseDataChanged();
        }

    }
}
