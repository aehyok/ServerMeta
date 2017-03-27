using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZMetaDataQuery.Common
{
      
        public partial class SinoUC_FunctionParam : DevExpress.XtraEditors.XtraUserControl
        {
                private string CurrentType = "";
                public SinoUC_FunctionParam()
                {
                        InitializeComponent();
                }



                public SinoUC_FunctionParam(string _paramName, string _type, MDModel_Table _table)
                {
                        InitializeComponent();
                        CurrentType = _type;
                        this.comboBoxEdit1.Properties.Items.Clear();
                        this.label1.Text = _paramName;
                        if (_table == null) return;
                        switch (_type.ToUpper())
                        {
                                case "VARCHAR":
                                case "CHAR":
                                case "VARCHAR2":
                                case "NVARCHAR":
                                case "NVARCHAR2":
                                        AddCharField(_table);
                                        break;
                                case "NUMBER":
                                        AddNumField(_table);
                                        break;
                                case "DATE":
                                        AddDateField(_table);
                                        break;
                        }

                }

                private void AddDateField(MDModel_Table _table)
                {
                        foreach (MDModel_Table_Column _tc in _table.Columns)
                        {
                                ColumnListItem _item = new ColumnListItem(_tc);
                                switch (_tc.ColumnDataType.ToUpper())
                                {
                                        case "DATE":
                                                this.comboBoxEdit1.Properties.Items.Add(_item);
                                                break;
                                }
                        }
                }

                private void AddNumField(MDModel_Table _table)
                {
                        foreach (MDModel_Table_Column _tc in _table.Columns)
                        {
                                ColumnListItem _item = new ColumnListItem(_tc);
                                switch (_tc.ColumnDataType.ToUpper())
                                {
                                        case "NUMBER":
                                                this.comboBoxEdit1.Properties.Items.Add(_item);
                                                break;
                                }
                        }
                }

                private void AddCharField(MDModel_Table _table)
                {
                        foreach (MDModel_Table_Column _tc in _table.Columns)
                        {
                                ColumnListItem _item = new ColumnListItem(_tc);
                                switch (_tc.ColumnDataType.ToUpper())
                                {
                                        case "VARCHAR":
                                        case "CHAR":
                                        case "VARCHAR2":
                                        case "NVARCHAR":
                                        case "NVARCHAR2":
                                                this.comboBoxEdit1.Properties.Items.Add(_item);
                                                break;
                                }
                        }
                }



                public string GetInput()
                {
                        if (this.comboBoxEdit1.SelectedIndex !=-1)
                        {
                                ColumnListItem _item = this.comboBoxEdit1.SelectedItem as ColumnListItem;
                                return _item.FieldAliasName;
                        }
                        else
                        {
                                string _inputStr = (this.comboBoxEdit1.EditValue == null) ? "" : this.comboBoxEdit1.EditValue.ToString();
                                if (_inputStr.Length > 1 && _inputStr.StartsWith("$") && _inputStr.EndsWith("$"))
                                {
                                        return _inputStr.Substring(1, _inputStr.Length - 2);
                                }
                                switch (CurrentType)
                                {
                                        case "VARCHAR":
                                        case "CHAR":
                                        case "VARCHAR2":
                                        case "NVARCHAR":
                                        case "NVARCHAR2":
                                                return string.Format("'{0}'", _inputStr);
                                        case "NUMBER":
                                                return _inputStr;
                                        case "DATE":
                                                return string.Format("to_date('{0}','yyyymmdd')", _inputStr);
                                }
                                return "";
                        }
                }
        }
}
