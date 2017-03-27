using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.DataCheck;
using SinoSZJS.Base.Misc;
using SinoSZJS.Base.MetaData.Define;
using SinoSZJS.Base.MetaData.Common;

namespace SinoSZClientReport.DataCheck
{
    public class MC_CheckRule
    {

        public static MDQuery_Request RuleToQueryRequest(MD_CheckRule _rule, MDModel_QueryModel _queryModel, MDQuery_Request filter_Request)
        {
            MDQuery_Request _ret = new MDQuery_Request();
            _ret.ChildResultTables = new List<MDQuery_ResultTable>();
            _ret.QueryModelName = _rule.QueryModelName;
            _ret.ConditionExpressions = StrUtils.GetMetaByName("C_BDS", _rule.MethodDefine);
            MDQuery_ResultTable _restable = new MDQuery_ResultTable();
            _restable.TableName = _queryModel.MainTable.TableName;
            _restable.DisplayTitle = _queryModel.DisplayName;
            _restable.Columns = new List<MDQuery_TableColumn>();
            _ret.MainResultTable = _restable;
            if (_ret.ConditionItems == null) _ret.ConditionItems = new List<MDQuery_ConditionItem>();
            foreach (string _field in StrUtils.GetMetasByName("C_FIELD", _rule.MethodDefine))
            {
                string _index = StrUtils.GetMetaByName("MII_INDEX", _field);
                MDQuery_ConditionItem _citem = new MDQuery_ConditionItem();
                _citem.Operator = StrUtils.GetMetaByName("MII_OPER", _field).TrimStart().TrimEnd();
                MDModel_Table_Column _columnDefine = GetColumn(StrUtils.GetMetaByName("MII_FIELD", _field), _queryModel);
                _citem.Column = new MDQuery_TableColumn(_columnDefine);
                _ret.ConditionItems.Add(_citem);
                _citem.Values = GetValues(StrUtils.GetMetaByName("MII_VALUE", _field), (_columnDefine.ColumnRefDMB != ""));
                _citem.ColumnIndex = _index;

            }
            if (filter_Request != null && filter_Request.ConditionItems.Count > 0)
            {
                int _oldcount = _ret.ConditionItems.Count;
                _ret.ConditionExpressions = string.Format("({0})", _ret.ConditionExpressions);
                foreach (MDQuery_ConditionItem _fci in filter_Request.ConditionItems)
                {
                    MDQuery_ConditionItem _citem = new MDQuery_ConditionItem();
                    _citem.Operator = _fci.Operator;
                    _citem.Column = _fci.Column;
                    _citem.Values = _fci.Values;
                    _citem.CaseSensitive = _fci.CaseSensitive;
                    _citem.ColumnIndex = (int.Parse(_fci.ColumnIndex) + _oldcount).ToString();
                    _ret.ConditionItems.Add(_citem);
                    _ret.ConditionExpressions += string.Format("*{0}", _citem.ColumnIndex);
                }
            }
            return _ret;
        }

        private static MDModel_Table_Column GetColumn(string _fieldStr, MDModel_QueryModel _queryModel)
        {
            MDModel_Table_Column _ret;
            string _tableName = StrUtils.GetMetaByName("QCF_TABLE", _fieldStr);
            string _columnName = StrUtils.GetMetaByName("QCF_COL", _fieldStr);
            string _columType = StrUtils.GetMetaByName("QCF_TYPE", _fieldStr);
            string _columTitle = StrUtils.GetMetaByName("QCF_TITLE", _fieldStr);
            if (_columType.Substring(0, 1) == "#")
            {
                _ret = new MDModel_Table_Column();
                _ret.ColumnDefine = new MD_ViewTableColumn(Guid.NewGuid().ToString(), "", "", true, true, true, true, false, "", 0, 0);
                _ret.ColumnDataType = _columType.Substring(1);
                _ret.ColumnName = _columnName;
                _ret.ColumnAlgorithm = _columnName;
                _ret.ColumnType = QueryColumnType.CalculationColumn;
                _ret.TableName = _tableName;
                _ret.ColumnTitle = _columTitle;
                _ret.ColumnRefDMB = "";
            }
            else
            {
                _ret = MC_QueryModel.GetColumnDefineByName(_queryModel, _tableName, _columnName);
            }
#if DEBUG
            //if (_ret == null)
            //{
            //    Console.WriteLine(string.Format("未找到字段{0}.{1}", _tableName, _columnName));
            //}
#endif
            return _ret;

        }

        private static List<string> GetValues(string _valueStr, bool isRefTable)
        {
            List<string> _ret = new List<string>();
            if (isRefTable)
            {
                foreach (string _s in StrUtils.GetMetasByName("REF_CODE", _valueStr))
                {
                    _ret.Add(_s);
                }
            }
            else
            {
                foreach (string _s in _valueStr.Split(','))
                {
                    _ret.Add(_s);
                }
            }

            return _ret;

        }

        public static string QueryRequestToRule(MDQuery_Request _Request, MDModel_QueryModel _queryModel)
        {
            MDModel_Table_Column _columnDefine;
            StringBuilder _ret = new StringBuilder();
            _ret.Append(string.Format("<C_BDS>{0}</C_BDS>", _Request.ConditionExpressions));
            foreach (MDQuery_ConditionItem _citem in _Request.ConditionItems)
            {

                _ret.Append("<C_FIELD>");
                #region 加条件序号
                _ret.Append(string.Format("<MII_INDEX>{0}</MII_INDEX>", _citem.ColumnIndex));
                _ret.Append(string.Format("<MII_OPER>{0}</MII_OPER>", _citem.Operator));
                #endregion

                #region  加字段定义
                _ret.Append("<MII_FIELD>");
                _ret.Append(string.Format("<QCF_TABLE>{0}</QCF_TABLE>", _citem.Column.TableName));
                _ret.Append(string.Format("<QCF_TITLE>{0}</QCF_TITLE>", _citem.Column.ColumnTitle));
                switch (_citem.Column.ColumnType)
                {
                    case QueryColumnType.TableColumn:
                        _ret.Append(string.Format("<QCF_COL>{0}</QCF_COL>", _citem.Column.ColumnName));
                        _ret.Append(string.Format("<QCF_TYPE>{0}</QCF_TYPE>", _citem.Column.ColumnDataType));

                        break;
                    case QueryColumnType.CalculationColumn:
                    case QueryColumnType.StatisticsColumn:
                        _ret.Append(string.Format("<QCF_COL>{0}</QCF_COL>", _citem.Column.ColumnAlgorithm));
                        _ret.Append(string.Format("<QCF_TYPE>#{0}</QCF_TYPE>", _citem.Column.ColumnDataType));
                        break;
                }
                _ret.Append(string.Format("<QCF_REF></QCF_REF>"));
                _ret.Append(string.Format("<QCF_VALUE></QCF_VALUE>"));
                _ret.Append(string.Format("<QCF_OPER></QCF_OPER>"));
                _ret.Append(string.Format("<QCF_SEC>0</QCF_SEC>"));
                _ret.Append(string.Format("<QCF_INDEX>0</QCF_INDEX>"));
                _ret.Append(string.Format("<QCF_CON></QCF_CON>"));
                _ret.Append("</MII_FIELD>");
                #endregion

                #region 加条件值
                _ret.Append("<MII_VALUE>");
                if (_citem.Column.ColumnType == QueryColumnType.TableColumn)
                {
                    _columnDefine = MC_QueryModel.GetColumnDefineByName(_queryModel, _citem.Column.TableName, _citem.Column.ColumnName);
                }
                else
                {
                    _columnDefine = new MDModel_Table_Column("", "", "", true, _citem.Column.ColumnDataType, 0, 0, 0, "", "", 0, _citem.Column.ColumnTitle, "", 0, 0, 0, true,
                        80, "", "", "", "", true, true, true, true, true, 0, _citem.Column.ColumnDataType);
                    _columnDefine.ColumnType = _citem.Column.ColumnType;
                }
                if (_columnDefine.ColumnRefDMB != "")
                {
                    //代码表式
                    if (_citem.Values.Count > 1)
                    {
                        _ret.Append("<REF_MUTI>TRUE</REF_MUTI>");
                    }
                    else
                    {
                        _ret.Append("<REF_MUTI>FALSE</REF_MUTI>");
                    }

                    foreach (string _s in _citem.Values)
                    {
                        _ret.Append("<REF_DATA>");
                        _ret.Append(string.Format("<REF_CODE>{0}</REF_CODE>", _s));
                        _ret.Append("</REF_DATA>");
                    }
                }
                else
                {
                    //普通
                    string _fg = "";
                    foreach (string _s in _citem.Values)
                    {
                        _ret.Append(_fg);
                        _ret.Append(_s);
                        _fg = ",";
                    }

                }
                _ret.Append("</MII_VALUE>");
                #endregion

                //加条件类型
                _ret.Append(string.Format("<MII_TYPE>{0}</MII_TYPE>", _citem.Column.ColumnDataType));

                _ret.Append("</C_FIELD>");
            }

            return _ret.ToString();
        }


    }
}
