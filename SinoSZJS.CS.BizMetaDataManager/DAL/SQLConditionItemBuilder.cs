using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.MetaData.QueryModel;
using System.Linq;

namespace SinoSZJS.CS.BizMetaDataManager.DAL
{
    public class SQLConditionItemBuilder
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
                    throw new Exception("以计算项做条件的查询功能尚未实现.");
                    break;

                case QueryColumnType.StatisticsColumn:
                    throw new Exception("以统计项做条件的查询功能尚未实现.");
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
                    return BuildDateFieldConditon(_cItem);
                    break;
                case "NUMBER":　//数值型
                    return BuildNumberFieldCondition(_cItem);
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
            MDModel_Table _table;
            string _fieldStr = string.Format("{0}.{1} ", _cItem.Column.TableName, _cItem.Column.ColumnName);

            string _tname = _cItem.Column.TableName;
            if (_qv.MainTable.TableName == _tname)
            {
                _table = _qv.MainTable;
            }
            else
            {
                _table = _qv.ChildTableDict[_tname];
            }

            var _find = from _c in _table.Columns
                        where _c.ColumnName == _cItem.Column.ColumnName
                        select _c;
            MDModel_Table_Column _tc = _find.First();

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
                        throw new Exception("代码表型的属于操作未实现!");
                        break;
                    case "集合":
                        #region 处理集合
                        string _collectionStr = " (";
                        string _fg = "";
                        foreach (string _dateStr in _cItem.Values)
                        {
                            _collectionStr += string.Format(" {2} {0}='{1}' ", _fieldStr, _dateStr, _fg);
                            _fg = " or ";
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
                        return string.Format("{0} <>'{1}' ", _fieldStr, _cItem.Values[0]);


                    case "包含":
                        return string.Format("{0} like '%{1}%' ", _fieldStr, _cItem.Values[0]);

                    case "匹配":
                        return string.Format("{0} like '{1}' ", _fieldStr, _cItem.Values[0]);

                    case "集合":
                        #region 处理集合
                        string _collectionStr = " (";
                        string _fg = "";
                        foreach (string _dateStr in _cItem.Values)
                        {
                            _collectionStr += string.Format(" {2} {0}='{1}' ", _fieldStr, _dateStr, _fg);
                            _fg = " or ";
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

        /// <summary>
        /// 构建数值型字段条件的表达式
        /// </summary>
        /// <param name="_cItem"></param>
        /// <returns></returns>
        private static string BuildNumberFieldCondition(MDQuery_ConditionItem  _cItem)
        {
            string _fieldStr = string.Format("{0}.{1} ", _cItem.Column.TableName, _cItem.Column.ColumnName);

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
                    string _collectionStr = " (";
                    string _fg = "";
                    foreach (string _dateStr in _cItem.Values)
                    {
                        _collectionStr += string.Format(" {2} {0}={1} ", _fieldStr, _dateStr, _fg);
                        _fg = " or ";
                    }
                    _collectionStr += ") ";
                    return _collectionStr;
                    #endregion

                case "范围":
                    return string.Format("{0}>= {1} and {0}<={2} ", _fieldStr, _cItem.Values[0], _cItem.Values[1]);

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
        private static string BuildDateFieldConditon(MDQuery_ConditionItem  _cItem)
        {
            string _fieldStr = string.Format("{0}.{1} ", _cItem.Column.TableName, _cItem.Column.ColumnName);
            string _year = _cItem.Values[0].Substring(0, 4);
            string _month = _cItem.Values[0].Substring(4, 2);
            string _day = _cItem.Values[0].Substring(6, 2);
            string DateFirst = string.Format(" '{0}-{1}-{2}' ", _year, _month, _day);
            string DateEnd = string.Format(" '{0}-{1}-{2} 23:59:59' ", _year, _month, _day);

            switch (_cItem.Operator)
            {
                case "等于":
                    return string.Format("{0} >={1} and {0}<={2} ", _fieldStr, DateFirst, DateEnd);

                case "时间段":
                    #region 处理时间段
                    string enddate = string.Format(" '{0} 23:59:59'", _cItem.Values[1]);
                    return string.Format("{0} >={1} and {0}<={2} ", _fieldStr, DateFirst, enddate);
                    #endregion

                case "集合":
                    #region 处理时间集合
                    string _collectionStr = string.Format("  (", _fieldStr);
                    string _fg = "";
                    foreach (string _dateStr in _cItem.Values)
                    {
                        string _sDate = string.Format(" '{0}' ", _dateStr);
                        string _eDate = string.Format(" '{0} 23:59:59' ", _dateStr);
                        _collectionStr += string.Format(" {3} ({0} >={1} and {0} <={2}) ", _fieldStr, _sDate, _eDate, _fg);
                        _fg = " or ";
                    }
                    _collectionStr += ") ";
                    return _collectionStr;
                    #endregion

                case "不等于":
                    return string.Format("{0} <{1} or {0} >{2} ", _fieldStr, DateFirst, DateEnd);

                case "大于":
                    return string.Format("{0} > {1} ", _fieldStr, DateEnd);
                case "大于等于":
                    return string.Format("{0} > {1} ", _fieldStr, DateFirst);
                case "小于":
                    return string.Format("{0} < {1} ", _fieldStr, DateFirst);
                case "小于等于":
                    return string.Format("{0} < {1} ", _fieldStr, DateEnd);
                    break;
                case "为空值":
                    return string.Format(" {0} is null ", _fieldStr);
                case "为非空值":
                    return string.Format(" {0} is not null ", _fieldStr);

            }
            return "";
        }

    }
}
