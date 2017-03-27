using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.Common;

namespace SinoSZJS.CS.BizMetaDataManager.DAL
{
    /// <summary>
    /// 查询语句生成器 (SqlServer语法)
    /// </summary>
    public class SQLQueryBuilder
    {
        internal static Dictionary<string, string> GetQueryStr(MDModel_QueryModel _qv, MDQuery_Request _queryRequest, ref string _mainQueryStr)
        {
            _mainQueryStr = "";

            string _filterStr = CreateDataFilterStr(_qv);
            bool canQueryOnce = IsOneResultTable(_qv, _queryRequest);
            string _conditionStr = CreateConditionString(_qv, _queryRequest);

            if (canQueryOnce)
            {
                //单查询语句
                List<string> _usedTableList = GetSingleQueryUsedTable(_qv, _queryRequest);
                string _displayStr = CreateSingleDisplayString(_qv, _queryRequest);
                string _tableStr = CreateTableString(_qv, _usedTableList);
                string _tableRelationStr = CreateTableRelationString(_qv, _usedTableList);
                _mainQueryStr = string.Format("select {0} from {1} where ", _displayStr, _tableStr);
                string _cstr = _conditionStr;
                if (_tableRelationStr.Trim().Length > 0)
                {
                    _cstr = string.Format(" {0} ({1}) ", _tableRelationStr, _cstr);
                }

                if (_filterStr.Trim().Length > 0)
                {
                    _cstr = string.Format(" {0} ({1}) ", _filterStr, _cstr);

                }

                _mainQueryStr += _cstr;
                return new Dictionary<string, string>();
            }
            else
            {
                //多查询语句暂时未实现         
                List<string> _QueryUsedTableList = GetQueryUsedTable(_qv, _queryRequest);
                string _tableStr = CreateTableString(_qv, _QueryUsedTableList);
                string _tableRelationStr = CreateTableRelationString(_qv, _QueryUsedTableList);
                string _condistr = _conditionStr;
                if (_tableRelationStr.Trim().Length > 0)
                {
                    _condistr = string.Format(" {0} ({1}) ", _tableRelationStr, _condistr);
                }

                if (_filterStr.Trim().Length > 0)
                {
                    _condistr = string.Format(" {0} ({1}) ", _filterStr, _condistr);

                }

                Dictionary<string, string> _ret = new Dictionary<string, string>();
                _ret.Add(_qv.MainTable.TableName, CreateMainTableResult(_qv, _queryRequest.MainResultTable, _condistr, _QueryUsedTableList));
                foreach (MDQuery_ResultTable _rt in _queryRequest.ChildResultTables)
                {
                    _ret.Add(_rt.TableName, CreateChildTableResult(_qv, _rt, _conditionStr, _filterStr, _QueryUsedTableList));
                }
                return _ret;
            }

        }



        private static string CreateChildTableResult(MDModel_QueryModel _qv, MDQuery_ResultTable _rt, string _conditionStr, string _filterStr, List<string> _QueryUsedTableList)
        {
            List<string> _usedTables = new List<string>();
            foreach (string _s in _QueryUsedTableList)
            {
                _usedTables.Add(_s);
            }
            if (!_usedTables.Contains(_rt.TableName)) _usedTables.Add(_rt.TableName);
            string _displayStr = CreateDisplayString(_qv, _rt);
            string _tableStr = CreateTableString(_qv, _usedTables);
            string _tableRelationStr = CreateTableRelationString(_qv, _usedTables);

            string _condistr = _conditionStr;
            if (_tableRelationStr.Trim().Length > 0)
            {
                _condistr = string.Format(" {0} ({1}) ", _tableRelationStr, _condistr);
            }

            if (_filterStr.Trim().Length > 0)
            {
                _condistr = string.Format(" {0} ({1}) ", _filterStr, _condistr);

            }

            return string.Format("select {0} from {1} where  {2} ",
                _displayStr, _tableStr, _condistr);
        }

        private static string CreateDisplayString(MDModel_QueryModel _qv, MDQuery_ResultTable _rt)
        {
            StringBuilder _sql = new StringBuilder();
            _sql.Append(string.Format("{0}.{1} MAINID", _qv.MainTable.TableName, _qv.MainTable.TableDefine.Table.MainKey));
            foreach (MDQuery_TableColumn _rc in _rt.Columns)
            {
                _sql.Append(SQLResultItemBuilder.BuildItem(_rc, _qv));
            }
            return _sql.ToString();
        }



        private static string CreateMainTableResult(MDModel_QueryModel _qv, MDQuery_ResultTable _ResultTable, string _condi, List<string> _QueryUsedTableList)
        {
            List<string> _usedTables = new List<string>();
            foreach (string _s in _QueryUsedTableList)
            {
                _usedTables.Add(_s);
            }
            if (!_usedTables.Contains(_ResultTable.TableName)) _usedTables.Add(_ResultTable.TableName);
            string _displayStr = CreateDisplayString(_qv, _ResultTable);
            string _tableStr = CreateTableString(_qv, _usedTables);
            return string.Format("select {0}  from {1} where {2} ",
                _displayStr, _tableStr, _condi);
        }

        private static List<string> GetQueryUsedTable(MDModel_QueryModel _qv, MDQuery_Request _queryRequest)
        {
            List<string> _usedTableList = new List<string>();
            _usedTableList.Add(_qv.MainTable.TableName);

            foreach (MDQuery_ConditionItem _cItem in _queryRequest.ConditionItems)
            {
                if (!_usedTableList.Contains(_cItem.Column.TableName))
                {
                    _usedTableList.Add(_cItem.Column.TableName);
                }
            }
            return _usedTableList;
        }

        /// <summary>
        /// 构建单查询语句的表间关系语句
        /// </summary>
        /// <param name="_qv"></param>
        /// <param name="_usedTables"></param>
        /// <returns></returns>
        private static string CreateTableRelationString(MDModel_QueryModel _qv, List<string> _usedTableList)
        {
            StringBuilder _ret = new StringBuilder();
            foreach (string _tname in _usedTableList)
            {
                if (_tname != _qv.MainTable.TableName)
                {
                    MDModel_Table _cTable = _qv.ChildTableDict[_tname];
                    if (_cTable != null)
                    {
                        if (_cTable.TableDefine.RelationString != string.Empty)
                        {
                            _ret.Append(string.Format("and {0} ", _cTable.TableDefine.RelationString));
                        }
                    }
                }

            }
            if (_ret.Length > 3)
            {
                return "(" + _ret.ToString().Substring(3) + ") and ";
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 构建单查询语句的表列表语句
        /// </summary>
        /// <param name="_qv"></param>
        /// <param name="_queryRequest"></param>
        /// <returns></returns>
        private static string CreateTableString(MDModel_QueryModel _qv, List<string> _usedTableList)
        {

            StringBuilder _sb = new StringBuilder();
            string _fg = "";
            foreach (string _tname in _usedTableList)
            {
                _sb.Append(_fg);
                _sb.Append(_tname);
                _fg = ",";
            }
            return _sb.ToString();
        }
        /// <summary>
        /// 建立单结果查询语句
        /// </summary>
        /// <param name="_qv"></param>
        /// <param name="_queryRequest"></param>
        /// <returns></returns>
        private static string CreateSingleDisplayString(MDModel_QueryModel _qv, MDQuery_Request _queryRequest)
        {
            StringBuilder _sql = new StringBuilder();
            _sql.Append(string.Format("{0}.{1} MAINID", _qv.MainTable.TableName, _qv.MainTable.TableDefine.Table.MainKey));
            foreach (MDQuery_TableColumn _rc in _queryRequest.MainResultTable.Columns)
            {
                _sql.Append(SQLResultItemBuilder.BuildItem(_rc, _qv));
            }

            foreach (MDQuery_ResultTable _rResultTable in _queryRequest.ChildResultTables)
            {
                foreach (MDQuery_TableColumn _rc in _rResultTable.Columns)
                {
                    _sql.Append(SQLResultItemBuilder.BuildItem(_rc, _qv));
                }
            }
            return _sql.ToString();
        }

        /// <summary>
        /// 取单查询中所有使用到的表
        /// </summary>
        /// <param name="_qv"></param>
        /// <param name="_queryRequest"></param>
        /// <returns></returns>
        private static List<string> GetSingleQueryUsedTable(MDModel_QueryModel _qv, MDQuery_Request _queryRequest)
        {
            List<string> _usedTableList = new List<string>();
            _usedTableList.Add(_qv.MainTable.TableName);
            foreach (MDQuery_ResultTable _table in _queryRequest.ChildResultTables)
            {
                if (!_usedTableList.Contains(_table.TableName))
                {
                    _usedTableList.Add(_table.TableName);
                }
            }

            foreach (MDQuery_ConditionItem _cItem in _queryRequest.ConditionItems)
            {
                if (!_usedTableList.Contains(_cItem.Column.TableName))
                {
                    _usedTableList.Add(_cItem.Column.TableName);
                }
            }
            return _usedTableList;
        }


        /// <summary>
        /// 构建查询条件
        /// </summary>
        /// <param name="_qv"></param>
        /// <param name="_queryRequest"></param>
        /// <returns></returns>
        private static string CreateConditionString(MDModel_QueryModel _qv, MDQuery_Request _queryRequest)
        {

            if (_queryRequest.ConditionExpressions == "") return "1=1";

            string conditionStr = _queryRequest.ConditionExpressions;
            StringBuilder res = new StringBuilder();
            string _itemIndex = "";

            for (int i = 0; i < conditionStr.Length; i++)
            {
                char c = conditionStr[i];

                switch (c)
                {
                    case '+':
                        res.Append(" or  ");
                        break;
                    case '*':
                        res.Append(" and ");
                        break;
                    case '!':
                        res.Append(" not ");
                        break;
                    case '(':
                        res.Append(" (");
                        break;
                    case ')':
                        res.Append(" ) ");
                        break;
                    default:
                        //数字
                        if (char.IsDigit(c))
                        {
                            _itemIndex = ProcDigit(conditionStr, ref i);
                        }
                        res.Append(GetConditionStr(_qv, _queryRequest, _itemIndex));
                        break;
                }
            }

            return RemoveOuter(res.ToString());
        }

        private static string RemoveOuter(string str)
        {
            string _ret = str.Trim();
            if (_ret.StartsWith("(") && _ret.EndsWith(")") && _ret.Length > 3)
            {
                if (BracketMatched(_ret.Substring(1, _ret.Length - 2)))
                {
                    return string.Format(" " + _ret.Substring(1, _ret.Length - 2) + " ");
                }
            }
            return string.Format(" " + _ret + " ");
        }

        private static bool BracketMatched(string str)
        {
            int flag = 0;
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];

                switch (c)
                {
                    case '(':
                        flag++;
                        break;
                    case ')':
                        flag--;
                        if (flag < 0) return false;
                        break;
                }

            }
            if (flag == 0) return true;
            return false;
        }

        /// <summary>
        /// 处理数值
        /// </summary>
        /// <param name="i"></param>
        /// <param name="_itemIndex"></param>
        private static string ProcDigit(string conditionStr, ref int index)
        {
            StringBuilder str = new StringBuilder();
            for (int i = index; i < conditionStr.Length; i++)
            {
                char c = conditionStr[i];
                if (char.IsDigit(c))
                    str.Append(c);
                else
                {
                    break;
                }
                index = i;
            }
            return str.ToString();
        }

        /// <summary>
        /// 取条件项字符串
        /// </summary>
        /// <param name="_qv"></param>
        /// <param name="_queryRequest"></param>
        /// <param name="_itemIndex"></param>
        /// <returns></returns>
        private static string GetConditionStr(MDModel_QueryModel _qv, MDQuery_Request _queryRequest, string _itemIndex)
        {
            MDQuery_ConditionItem _cItem = _queryRequest.GetConditionItemByIndex(_itemIndex);
            if (_cItem == null)
            {
                throw new Exception(string.Format("缺少编号为{0}的条件项!", _itemIndex));
            }
            else
            {
                return SQLConditionItemBuilder.BuildConditionItemString(_cItem, _qv);
            }
        }


        private static bool IsOneResultTable(MDModel_QueryModel _qv, MDQuery_Request _queryRequest)
        {
            //暂时未实现
            if (_queryRequest.ChildResultTables.Count < 1) return true;

            foreach (MDQuery_ResultTable _table in _queryRequest.ChildResultTables)
            {
                if (!_qv.ChildTableDict.ContainsKey(_table.TableName))
                {
                    throw new Exception(string.Format("构建查询字符串时发出错误，不存在子表{0}", _table.TableName));
                }
            }
            return false;
        }

        /// <summary>
        /// 构建通过用户岗位权限筛选数据的语句
        /// </summary>
        /// <param name="_qv"></param>
        /// <returns></returns>
        private static string CreateDataFilterStr(MDModel_QueryModel _qv)
        {
            string _res = "";
            if (_qv.MainTable.TableDefine.Table.SecretFun != "")
            {
                //暂时未实现
            }
            else
            {
                _res = "";
            }

            if (_qv.MainTable.TableDefine.Table.ExtSecret != "")
            {
                //暂时未实现
            }
            return _res;
        }
    }
}
