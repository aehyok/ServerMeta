using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.InputModel;

namespace SinoSZMetaDataQuery.InputModel
{
    public partial class InputModelPanel : DevExpress.XtraEditors.XtraUserControl
    {
        private const int RowHeight = 30;
        private MD_InputModel InputModelDefine = null;
        private MD_InputEntity CurrentEntity = null;
        Dictionary<string, SinoUC_IM_Text> InputDict = new Dictionary<string, SinoUC_IM_Text>();
        public InputModelPanel()
        {
            InitializeComponent();
        }

        public void InitForm(MD_InputModel inputModelDefine, MD_InputEntity entity)
        {
            InputModelDefine = inputModelDefine;
            CurrentEntity = entity;
            if (InputModelDefine.Groups.Count > 0)
            {
                CreateGroupsForm();
            }
            else
            {
                CreateSingleForm();
            }
        }

        private void CreateSingleForm()
        {
            SinoUC_IM_Text _valText;
            this.LayoutPanel.RowStyles.Clear();
            InputDict.Clear();
            this.LayoutPanel.Height = 0;
            int colIndex = 4;
            int rowIndex = -1;
            foreach (MD_InputModel_Column _col in this.InputModelDefine.Columns)
            {
                int _itemWidth = (_col.Width > 2) ? 2 : _col.Width;
                if (colIndex + _itemWidth > 2)
                {
                    this.LayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, RowHeight));
                    rowIndex++;
                    colIndex = 0;
                    this.LayoutPanel.Height += RowHeight;
                }

                TextEdit _lbText = new TextEdit();
                _lbText.Margin = new Padding(0, 0, 0, 0);
                _lbText.Properties.AutoHeight = false;
                _lbText.EditValue = _col.DisplayName;
                _lbText.Properties.ReadOnly = true;
                _lbText.Anchor = (AnchorStyles)(AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
                this.LayoutPanel.Controls.Add(_lbText, colIndex * 2, rowIndex);

                switch (_col.ColumnType)
                {
                    case "VARCHAR":
                    case "字符型":
                        _valText = CreateTextInput(_col) as SinoUC_IM_Text;
                        break;
                    case "代码表":
                        _valText = CreateRefTableInput(_col) as SinoUC_IM_Text;
                        break;
                    case "NUMBER":
                    case "数值型":
                        _valText = CreateNumberInput(_col) as SinoUC_IM_Text;
                        break;
                    case "DATE":
                    case "日期型":
                        _valText = CreateDateInput(_col) as SinoUC_IM_Text;
                        break;
                    case "组织机构":
                        _valText = CreateOrgInput(_col) as SinoUC_IM_Text;
                        break;
                    default:
                        _valText = CreateTextInput(_col) as SinoUC_IM_Text;
                        break;
                }

                this.LayoutPanel.Controls.Add(_valText, colIndex * 2 + 1, rowIndex);
                InputDict.Add(_col.ColumnName, _valText);
                colIndex += _itemWidth;
            }
        }

        private SinoUC_IM_Text CreateRefTableInput(MD_InputModel_Column _col)
        {
            SinoUC_IM_RefTable _ref = new SinoUC_IM_RefTable(_col.EditFormat);
            _ref.Margin = new Padding(0, 0, 0, 0);
            _ref.EditValue = GetEntityValue(_col);
            _ref.Anchor = (AnchorStyles)(AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            return _ref;
        }

        private SinoUC_IM_Text CreateOrgInput(MD_InputModel_Column _col)
        {
            SinoUC_IM_Org _orgText = new SinoUC_IM_Org();
            _orgText.InitOrgs();
            _orgText.Margin = new Padding(0, 0, 0, 0);
            _orgText.EditValue = GetEntityValue(_col);
            _orgText.Anchor = (AnchorStyles)(AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);

            return _orgText;
        }

        private SinoUC_IM_Number CreateNumberInput(MD_InputModel_Column _col)
        {
            SinoUC_IM_Number _valText = new SinoUC_IM_Number();
            _valText.Margin = new Padding(0, 0, 0, 0);
            _valText.EditValue = GetEntityValue(_col);
            _valText.Anchor = (AnchorStyles)(AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);

            return _valText;
        }

        private SinoUC_IM_Date CreateDateInput(MD_InputModel_Column _col)
        {
            SinoUC_IM_Date _dateText = new SinoUC_IM_Date();
            _dateText.Margin = new Padding(0, 0, 0, 0);
            _dateText.EditValue = GetEntityValue(_col);
            _dateText.Anchor = (AnchorStyles)(AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            return _dateText;
        }

        private SinoUC_IM_Text CreateTextInput(MD_InputModel_Column _col)
        {
            SinoUC_IM_Text _valText = new SinoUC_IM_Text();
            _valText.Margin = new Padding(0, 0, 0, 0);
            _valText.EditValue = GetEntityValue(_col);
            _valText.Anchor = (AnchorStyles)(AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);

            return _valText;
        }
        private object GetEntityValue(MD_InputModel_Column _col)
        {
            if (this.CurrentEntity.InputData.ContainsKey(_col.ColumnName))
            {
                return this.CurrentEntity.InputData[_col.ColumnName];
            }
            else
            {
                return null;
            }
        }

        private void CreateGroupsForm()
        {
            foreach (MD_InputModel_ColumnGroup _g in InputModelDefine.Groups)
            {
            }
        }

        public void ChangeEntityData(MD_InputEntity DataEntity)
        {
            DataEntity.IsNewData = false;
            foreach (string _key in this.InputDict.Keys)
            {
                SinoUC_IM_Text _input = this.InputDict[_key];
                string _val = (_input.EditValue == null) ? null : _input.EditValue.ToString();
                if (DataEntity.InputData.ContainsKey(_key))
                {
                    DataEntity.InputData[_key] = _val;
                }
                else
                {
                    DataEntity.InputData.Add(_key, _val);
                }
            }
        }
    }
}
