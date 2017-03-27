using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.Common;
using SinoSZJS.Base.MetaData.DataCompare;
namespace SinoSZJS.CS.BizMetaDataManager.DAL
{
    public class OraConditionItemBuilder
    {
        /// <summary>
        /// 构建查询条件项的语句
        /// </summary>
        /// <param name="_cItem"></param>
        /// <param name="_qv"></param>
        /// <returns></returns>
        internal static string BuildConditionItemString(MDQuery_ConditionItem _cItem, MDModel_QueryModel _qv)
        {
            switch (_cItem.Column.ColumnType)
            {
                case QueryColumnType.TableColumn:
                    return BuildConditionItemByTableColumn(_cItem, _qv);

                case QueryColumnType.CalculationColumn:
                    return BuildConditionItemByCalculationColumn(_cItem, _qv);
                    break;

                case QueryColumnType.StatisticsColumn:
                    return BuildConditionItemByStatisticsColumn(_cItem, _qv);
                    break;

            }
            return "";
        }

        public static string BuildCompareConditionItemString(MDCompare_ConditionItem _cItem, MDModel_QueryModel _qv)
        {
            switch (_cItem.Column.ColumnType)
            {
                case QueryColumnType.TableColumn:
                    return BuildConditionItemByTableColumn(_cItem, _qv);

                //case QueryColumnType.CalculationColumn:
                //        return BuildConditionItemByCalculationColumn(_cItem, _qv);
                //        break;

                //case QueryColumnType.StatisticsColumn:
                //        return BuildConditionItemByStatisticsColumn(_cItem, _qv);
                //        break;

            }
            return "";
        }

        private static string BuildConditionItemByStatisticsColumn(MDQuery_ConditionItem _cItem, MDModel_QueryModel _qv)
        {
            switch (_cItem.Column.ColumnDataType.ToUpper())
            {
                case "DATE":     //日期型
                    return BuildDateFieldQueryCondition(_cItem);
                    break;
                case "NUMBER":　//数值型
                    return BuildNumberFieldCondition(_cItem, _qv);
                    break;
                case "CHAR":
                case "VACHAR":
                case "NVARCHAR":
                case "NVARCHAR2":
                case "VARCHAR2":
                    return BuildCharFieldCondition(_cItem, _qv);
                    break;
                default:
                    throw new Exception(string.Format("以{0}类型字段做条件的查询功能尚未实现.", _cItem.Column.ColumnDataType));
                    break;
            }
            return "";
        }

        private static string BuildConditionItemByCalculationColumn(MDQuery_ConditionItem _cItem, MDModel_QueryModel _qv)
        {
            switch (_cItem.Column.ColumnDataType.ToUpper())
            {
                case "DATE":     //日期型
                    return BuildDateFieldQueryCondition(_cItem);
                    break;
                case "NUMBER":　//数值型
                    return BuildNumberFieldCondition(_cItem, _qv);
                    break;
                case "CHAR":
                case "VACHAR":
                case "NVARCHAR":
                case "NVARCHAR2":
                case "VARCHAR2":
                    return BuildCharFieldCondition(_cItem, _qv);
                    break;
                default:
                    throw new Exception(string.Format("以{0}类型字段做条件的查询功能尚未实现.", _cItem.Column.ColumnDataType));
                    break;
            }
            return "";
        }

        /// <summary>
        /// 构建以表字段为条件的查询语句
        /// </summary>
        /// <param name="_cItem"></param>
        /// <param name="_qv"></param>
        /// <returns></returns>
        private static string BuildConditionItemByTableColumn(MDQuery_ConditionItem _cItem, MDModel_QueryModel _qv)
        {
            switch (_cItem.Column.ColumnDataType.ToUpper())
            {
                case "DATE":     //日期型
                    return BuildDateFieldQueryCondition(_cItem);
                    break;
                case "NUMBER":　//数值型
                    return BuildNumberFieldCondition(_cItem, _qv);
                    break;
                case "CHAR":
                case "VACHAR":
                case "NVARCHAR":
                case "NVARCHAR2":
                case "VARCHAR2":
                    return BuildCharFieldCondition(_cItem, _qv);
                    break;
                default:
                    throw new Exception(string.Format("以{0}类型字段做条件的查询功能尚未实现.", _cItem.Column.ColumnDataType));
                    break;
            }
            return "";
        }

        private static string BuildConditionItemByTableColumn(MDCompare_ConditionItem _cItem, MDModel_QueryModel _qv)
        {
            switch (_cItem.Column.ColumnDataType.ToUpper())
            {
                case "DATE":     //日期型
                    return BuildDateFieldConditon(_cItem);
                    break;
                case "NUMBER":　//数值型
                    return BuildNumberFieldCondition(_cItem, _qv);
                    break;
                case "CHAR":
                case "VACHAR":
                case "NVARCHAR":
                case "NVARCHAR2":
                case "VARCHAR2":
                    return BuildCharFieldCondition(_cItem, _qv);
                    break;
                default:
                    throw new Exception(string.Format("以{0}类型字段做条件的查询功能尚未实现.", _cItem.Column.ColumnDataType));
                    break;
            }
            return "";
        }

        /// <summary>
        /// 构建字符型字段表达式
        /// </summary>
        /// <param name="_cItem"></param>
        /// <returns></returns>
        private static string BuildCharFieldCondition(MDQuery_ConditionItem _cItem, MDModel_QueryModel _qv)
        {

            string _fieldStr;
            switch (_cItem.Column.ColumnType)
            {
                case QueryColumnType.TableColumn:
                    _fieldStr = string.Format("{0}.{1} ", _cItem.Column.TableName, _cItem.Column.ColumnName);
                    return BuildCharFieldCondition_Table(_cItem, _qv, _fieldStr);

                case QueryColumnType.CalculationColumn:
                case QueryColumnType.StatisticsColumn:
                    _fieldStr = string.Format("({0}) ", _cItem.Column.ColumnAlgorithm);
                    return BuildCharFieldCondition_Method(_cItem, _qv, _fieldStr);

            }
            return "";

        }

        private static string BuildCharFieldCondition(MDCompare_ConditionItem _cItem, MDModel_QueryModel _qv)
        {

            string _fieldStr;
            switch (_cItem.Column.ColumnType)
            {
                case QueryColumnType.TableColumn:
                    _fieldStr = string.Format("{0}.{1} ", _cItem.Column.TableName, _cItem.Column.ColumnName);
                    return BuildCharFieldCondition_Table(_cItem, _qv, _fieldStr);

            }
            return "";

        }

        private static string BuildCharFieldCondition_Method(MDQuery_ConditionItem _cItem, MDModel_QueryModel _qv, string _fieldStr)
        {
            MDModel_Table _table;
            string _tname = _cItem.Column.TableName;
            if (_qv.MainTable.TableName == _tname)
            {
                _table = _qv.MainTable;
            }
            else
            {
                _table = _qv.ChildTableDict[_tname];
            }


            //普通字符型
            switch (_cItem.Operator)
            {
                case "等于":
                    return string.Format("{0} ='{1}' ", _fieldStr, _cItem.Values[0]);
                case "不等于":
                    return string.Format("{0} <>'{1}' ", _fieldStr, _cItem.Values[0]);
                case "包含":
                    return string.Format("{0} like '%{1}%' ", _fieldStr, _cItem.Values[0]);

                case "匹配":
                    return string.Format("{0} like '{1}' ", _fieldStr, _cItem.Values[0]);

                case "集合":
                    #region 处理集合
                    string _collectionStr = string.Format(" {0} in (", _fieldStr);
                    string _fg = "";
                    foreach (string _dateStr in _cItem.Values)
                    {
                        _collectionStr += string.Format("{0}'{1}'", _fg, _dateStr);
                        _fg = ",";
                    }
                    _collectionStr += ") ";
                    return _collectionStr;
                    #endregion

                case "为空值":
                    return string.Format(" {0} is null ", _fieldStr);
                case "为非空值":
                    return string.Format(" {0} is not null ", _fieldStr);

            }
            return "";

        }

        private static string BuildCharFieldCondition_Table(MDQuery_ConditionItem _cItem, MDModel_QueryModel _qv, string _fieldStr)
        {
            MDModel_Table _table;
            string _tname = _cItem.Column.TableName;
            if (_qv.MainTable.TableName == _tname)
            {
                _table = _qv.MainTable;
            }
            else
            {
                _table = _qv.ChildTableDict[_tname];
            }

            MDModel_Table_Column _tc = _table.GetColumnByName(_cItem.Column.ColumnName);

            if (_tc.ColumnRefDMB != "")
            {
                //代码表型
                switch (_cItem.Operator)
                {
                    case "等于":
                        return string.Format("{0} = '{1}'", _fieldStr, _cItem.Values[0]);
                        break;
                    case "不等于":
                        return string.Format("{0} <> '{1}'", _fieldStr, _cItem.Values[0]);
                        break;
                    case "属于":
                        string[] _rtNames = _tc.ColumnRefDMB.Split('.');
                        string _tName = (_rtNames.Length > 1) ? _rtNames[1] : _rtNames[0];
                        return string.Format("{0} in (select dm from jsods.{2} start with dm='{1}' connect by prior DM=FATHERCODE) ", _fieldStr, _cItem.Values[0], _tName);
                        break;
                    case "集合":
                        #region 处理集合
                        string _collectionStr = string.Format(" {0} in (", _fieldStr);
                        string _fg = "";
                        foreach (string _dateStr in _cItem.Values)
                        {
                            _collectionStr += string.Format("{0}'{1}'", _fg, _dateStr);
                            _fg = ",";
                        }
                        _collectionStr += ") ";
                        return _collectionStr;
                        #endregion
                        break;

                    case "为空值":
                        return string.Format("{0} is null ", _fieldStr);
                        break;
                    case "为非空值":
                        return string.Format("{0} is not null ", _fieldStr);
                        break;
                }
                return "";

            }
            else
            {
                //普通字符型

                switch (_cItem.Operator)
                {
                    case "等于":
                        return string.Format("{0} ='{1}' ", _fieldStr, _cItem.Values[0]);
                    case "不等于":
                        return string.Format("{0} <> '{1}' ", _fieldStr, _cItem.Values[0]);
                    case "包含":
                        return string.Format("{0} like '%{1}%' ", _fieldStr, _cItem.Values[0]);

                    case "匹配":
                        return string.Format("{0} like '{1}' ", _fieldStr, _cItem.Values[0]);

                    case "集合":
                        #region 处理集合
                        string _collectionStr = string.Format(" {0} in (", _fieldStr);
                        string _fg = "";
                        foreach (string _dateStr in _cItem.Values)
                        {
                            _collectionStr += string.Format("{0}'{1}'", _fg, _dateStr);
                            _fg = ",";
                        }
                        _collectionStr += ") ";
                        return _collectionStr;
                        #endregion

                    case "为空值":
                        return string.Format(" {0} is null ", _fieldStr);
                    case "为非空值":
                        return string.Format(" {0} is not null ", _fieldStr);

                }
                return "";
            }
        }

        private static string BuildCharFieldCondition_Table(MDCompare_ConditionItem _cItem, MDModel_QueryModel _qv, string _fieldStr)
        {
            MDModel_Table _table;
            string _targetField = string.Format("TEMP_IMPDATA.{0}", _cItem.CompareTagetField);
            string _tname = _cItem.Column.TableName;
            if (_qv.MainTable.TableName == _tname)
            {
                _table = _qv.MainTable;
            }
            else
            {
                _table = _qv.ChildTableDict[_tname];
            }

            MDModel_Table_Column _tc = _table.GetColumnByName(_cItem.Column.ColumnName);
            //普通字符型

            switch (_cItem.Operator)
            {
                case "等于":
                    return string.Format("{0} ={1}", _fieldStr, _targetField);


                case "近似":
                    return string.Format("{0} = {1} ", _fieldStr, _targetField);

            }

            return "";

        }


        private static string BuildNumberFieldCondition(MDQuery_ConditionItem _cItem, MDModel_QueryModel _qv)
        {
            string _fieldStr;
            switch (_cItem.Column.ColumnType)
            {
                case QueryColumnType.TableColumn:
                    _fieldStr = string.Format("{0}.{1} ", _cItem.Column.TableName, _cItem.Column.ColumnName);
                    return BuildNumberFieldCondition_Table(_cItem, _qv, _fieldStr);

                case QueryColumnType.CalculationColumn:
                case QueryColumnType.StatisticsColumn:
                    _fieldStr = string.Format("({0}) ", _cItem.Column.ColumnAlgorithm);
                    return BuildNumberFieldCondition_Method(_cItem, _qv, _fieldStr);

            }
            return "";
        }


        /// <summary>
        /// 构建数值型字段条件的表达式
        /// </summary>
        /// <param name="_cItem"></param>
        /// <returns></returns>
        private static string BuildNumberFieldCondition_Table(MDQuery_ConditionItem _cItem, MDModel_QueryModel _qv, string _fieldStr)
        {
            MDModel_Table _table;


            string _tname = _cItem.Column.TableName;
            if (_qv.MainTable.TableName == _tname)
            {
                _table = _qv.MainTable;
            }
            else
            {
                _table = _qv.ChildTableDict[_tname];
            }

            MDModel_Table_Column  _tc = _table.GetColumnByName(_cItem.Column.ColumnName);

            if (_tc.ColumnRefDMB != "")
            {
                #region 代码表型
                switch (_cItem.Operator)
                {
                    case "等于":
                        return string.Format("{0} = '{1}'", _fieldStr, _cItem.Values[0]);
                        break;
                    case "不等于":
                        return string.Format("{0} <> '{1}'", _fieldStr, _cItem.Values[0]);
                        break;
                    case "属于":
                        string[] _rtNames = _tc.ColumnRefDMB.Split('.');
                        string _tName = (_rtNames.Length > 1) ? _rtNames[1] : _rtNames[0];
                        return string.Format("{0} in (select dm from jsods.{2} start with dm='{1}' connect by prior DM=FATHERCODE) ", _fieldStr, _cItem.Values[0], _tName);
                        break;
                    case "集合":
                        #region 处理集合
                        string _collectionStr = string.Format(" {0} in (", _fieldStr);
                        string _fg = "";
                        foreach (string _dateStr in _cItem.Values)
                        {
                            _collectionStr += string.Format("{0}'{1}'", _fg, _dateStr);
                            _fg = ",";
                        }
                        _collectionStr += ") ";
                        return _collectionStr;
                        #endregion
                        break;

                    case "为空值":
                        return string.Format("{0} is null ", _fieldStr);
                        break;
                    case "为非空值":
                        return string.Format("{0} is not null ", _fieldStr);
                        break;
                }
                return "";
                #endregion

            }
            else
            {
                #region 普通数值型
                switch (_cItem.Operator)
                {
                    case "等于":
                        return string.Format("{0} =　{1} ", _fieldStr, _cItem.Values[0]);

                    case "不等于":
                        return string.Format("{0} <>　{1} ", _fieldStr, _cItem.Values[0]);

                    case "大于":
                        return string.Format("{0} > {1} ", _fieldStr, _cItem.Values[0]);

                    case "大于等于":
                        return string.Format("{0} >= {1} ", _fieldStr, _cItem.Values[0]);

                    case "小于":
                        return string.Format("{0} < {1} ", _fieldStr, _cItem.Values[0]);

                    case "小于等于":
                        return string.Format("{0} <= {1} ", _fieldStr, _cItem.Values[0]);
                        break;

                    case "集合":
                        #region 处理集合
                        string _collectionStr = string.Format(" {0} in (", _fieldStr);
                        string _fg = "";
                        foreach (string _dateStr in _cItem.Values)
                        {
                            _collectionStr += string.Format("{0}{1}", _fg, _dateStr);
                            _fg = ",";
                        }
                        _collectionStr += ") ";
                        return _collectionStr;
                        #endregion

                    case "范围":
                        return string.Format("{0} between {1} and {2} ", _fieldStr, _cItem.Values[0], _cItem.Values[1]);

                    case "为空值":
                        return string.Format(" {0} is null ", _fieldStr);
                    case "为非空值":
                        return string.Format(" {0} is not null ", _fieldStr);

                }


                #endregion
            }
            return "";
        }

        private static string BuildNumberFieldCondition_Method(MDQuery_ConditionItem  _cItem, MDModel_QueryModel _qv, string _fieldStr)
        {
            MDModel_Table  _table;
            string _tname = _cItem.Column.TableName;
            if (_qv.MainTable.TableName == _tname)
            {
                _table = _qv.MainTable;
            }
            else
            {
                _table = _qv.ChildTableDict[_tname];
            }



            #region 普通数值型
            switch (_cItem.Operator)
            {
                case "等于":
                    return string.Format("{0} =　{1} ", _fieldStr, _cItem.Values[0]);

                case "不等于":
                    return string.Format("{0} <>　{1} ", _fieldStr, _cItem.Values[0]);

                case "大于":
                    return string.Format("{0} > {1} ", _fieldStr, _cItem.Values[0]);

                case "大于等于":
                    return string.Format("{0} >= {1} ", _fieldStr, _cItem.Values[0]);

                case "小于":
                    return string.Format("{0} < {1} ", _fieldStr, _cItem.Values[0]);

                case "小于等于":
                    return string.Format("{0} <= {1} ", _fieldStr, _cItem.Values[0]);
                    break;

                case "集合":
                    #region 处理集合
                    string _collectionStr = string.Format(" {0} in (", _fieldStr);
                    string _fg = "";
                    foreach (string _dateStr in _cItem.Values)
                    {
                        _collectionStr += string.Format("{0}{1}", _fg, _dateStr);
                        _fg = ",";
                    }
                    _collectionStr += ") ";
                    return _collectionStr;
                    #endregion

                case "范围":
                    return string.Format("{0} between {1} and {2} ", _fieldStr, _cItem.Values[0], _cItem.Values[1]);

                case "为空值":
                    return string.Format(" {0} is null ", _fieldStr);
                case "为非空值":
                    return string.Format(" {0} is not null ", _fieldStr);

            }
            return "";
            #endregion
        }

        /// <summary>
        /// 构建数值型字段条件的表达式
        /// </summary>
        /// <param name="_cItem"></param>
        /// <returns></returns>
        private static string BuildNumberFieldCondition(MDCompare_ConditionItem _cItem, MDModel_QueryModel _qv)
        {
            MDModel_Table _table;
            string _targetField = string.Format("TEMP_IMPDATA.{0}", _cItem.CompareTagetField);
            string _fieldStr = "";
            switch (_cItem.Column.ColumnType)
            {
                case QueryColumnType.TableColumn:
                    _fieldStr = string.Format("{0}.{1} ", _cItem.Column.TableName, _cItem.Column.ColumnName);
                    break;
            }

            string _tname = _cItem.Column.TableName;
            if (_qv.MainTable.TableName == _tname)
            {
                _table = _qv.MainTable;
            }
            else
            {
                _table = _qv.ChildTableDict[_tname];
            }

            MDModel_Table_Column _tc = _table.GetColumnByName(_cItem.Column.ColumnName);

            #region 普通数值型
            switch (_cItem.Operator)
            {
                case "等于":
                    return string.Format("to_char({0}) =　{1} ", _fieldStr, _targetField);

            }


            #endregion

            return "";
        }

        private static string BuildDateFieldQueryCondition(MDQuery_ConditionItem _cItem)
        {
            string _fieldStr;
            switch (_cItem.Column.ColumnType)
            {
                case QueryColumnType.TableColumn:
                    _fieldStr = string.Format("{0}.{1} ", _cItem.Column.TableName, _cItem.Column.ColumnName);
                    return BuildDateFieldConditon_Table(_cItem, _fieldStr);

                case QueryColumnType.CalculationColumn:
                case QueryColumnType.StatisticsColumn:
                    _fieldStr = string.Format("({0}) ", _cItem.Column.ColumnAlgorithm);
                    return BuildDateFieldConditon_Table(_cItem, _fieldStr);

            }
            return "";
        }



        /// <summary>
        /// 构建日期型字段条件的表达式
        /// </summary>
        /// <param name="_cItem"></param>
        /// <returns></returns>
        private static string BuildDateFieldConditon_Table(MDQuery_ConditionItem _cItem, string _fieldStr)
        {

            string DateFirst = string.Format("to_date('{0}','YYYY-MM-DD')", _cItem.Values[0]);
            string DateEnd = string.Format("to_date('{0}235959','YYYY-MM-DDhh24miss')", _cItem.Values[0]);

            switch (_cItem.Operator)
            {
                case "等于":
                    return string.Format("{0} between {1} and {2} ", _fieldStr, DateFirst, DateEnd);

                case "时间段":
                    #region 处理时间段
                    string enddate = string.Format("to_date('{0}235959','YYYY-MM-DDhh24miss')", _cItem.Values[1]);
                    return string.Format(" {0} between {1} and {2} ", _fieldStr, DateFirst, enddate);
                    #endregion

                case "集合":
                    #region 处理时间集合
                    string _collectionStr = string.Format(" {0} in (", _fieldStr);
                    string _fg = "";
                    foreach (string _dateStr in _cItem.Values)
                    {
                        _collectionStr += string.Format("{0}to_date('{1}','YYYY-MM-DD')", _fg, _dateStr);
                        _fg = ",";
                    }
                    _collectionStr += ") ";
                    return _collectionStr;
                    #endregion

                case "不等于":
                    return string.Format("{0} not between {1} and {2} ", _fieldStr, DateFirst, DateEnd);
                case "大于":
                    return string.Format("{0} > {1} ", _fieldStr, DateEnd);
                case "大于等于":
                    return string.Format("{0} >= {1} ", _fieldStr, DateFirst);
                case "小于":
                    return string.Format("{0} < {1} ", _fieldStr, DateFirst);
                case "小于等于":
                    return string.Format("{0} <= {1} ", _fieldStr, DateEnd);
                    break;
                case "为空值":
                    return string.Format(" {0} is null ", _fieldStr);
                case "为非空值":
                    return string.Format(" {0} is not null ", _fieldStr);

            }
            return "";
        }


        /// <summary>
        /// 构建日期型字段条件的表达式
        /// </summary>
        /// <param name="_cItem"></param>
        /// <returns></returns>
        private static string BuildDateFieldConditon(MDCompare_ConditionItem _cItem)
        {
            string _fieldStr = "";
            switch (_cItem.Column.ColumnType)
            {
                case QueryColumnType.TableColumn:
                    _fieldStr = string.Format("{0}.{1} ", _cItem.Column.TableName, _cItem.Column.ColumnName);
                    break;
                //case QueryColumnType.CalculationColumn:
                //case QueryColumnType.StatisticsColumn:
                //        _fieldStr = string.Format("({0}) ", _cItem.Column.ColumnAlgorithm);
                //        break;
            }
            string _targetField = string.Format("TEMP_IMPDATA.{0}", _cItem.CompareTagetField);

            string DateFirst = string.Format("to_date('{0}','YYYY-MM-DD')", _targetField);
            string DateEnd = string.Format("to_date('{0}235959','YYYY-MM-DDhh24miss')", _targetField);

            switch (_cItem.Operator)
            {
                case "等于":
                    return string.Format("{0} between {1} and {2} ", _fieldStr, DateFirst, DateEnd);
            }
            return "";
        }




    }
}
