using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.DataCompare;

namespace SinoSZJS.CS.BizMetaDataManager.DAL
{
    public class CompareBuilder
    {
        public static string CreateCompareSQL(MDModel_QueryModel _qv, MDCompare_Request compareRequest)
        {

            //1.生成以筛选条件对查询模型数据集进行筛选的语句
            string _filterSQL = CreateFilterStr(_qv, compareRequest);

            //2.生成比对语句
            string _compareSQL = CreateCompareStr(_qv, compareRequest);
            string _mainSql = string.Format("{0} and ({1}.{2} in ({3}))", _compareSQL, _qv.MainTable.TableName, _qv.MainTable.TableDefine.Table.MainKey, _filterSQL);
            string _mainResult = string.Format("insert into COMP_TEMP (PK_C,PK_C2) {0}", _mainSql);
            return _mainResult;
        }

        private static string CreateCompareStr(MDModel_QueryModel _qv, MDCompare_Request compareRequest)
        {
            string _res = "";
            MDQuery_Request _queryRequest = compareRequest as MDQuery_Request;
            List<string> CompareUsedTableList = GetAllCompareUsedTables(_qv, compareRequest);

            string _whereStr = CreateCompareWhereStr(_qv, compareRequest);
            string _displayStr = CreateCompareMainKeyString(_qv, compareRequest);
            string _tableStr = CreateCompareTableString(_qv, CompareUsedTableList);
            string _tableRelationStr = OraQueryBuilder.CreateTableRelationString(_qv, CompareUsedTableList);

            _res = string.Format("select DISTINCT {0} from {1} where  {2} ({3}) ", _displayStr, _tableStr, _tableRelationStr, _whereStr);


            return _res;
        }

        private static string CreateCompareTableString(MDModel_QueryModel _qv, List<string> CompareUsedTableList)
        {
            string _a1 = OraQueryBuilder.CreateTableString(_qv, CompareUsedTableList);
            return string.Format("{0},TEMP_IMPDATA", _a1);
        }

        private static string CreateCompareMainKeyString(MDModel_QueryModel _qv, MDCompare_Request compareRequest)
        {
            string _res = "";
            _res = string.Format(" TEMP_IMPDATA.XH,{0}.{1} MAINID ", _qv.MainTable.TableName, _qv.MainTable.TableDefine.Table.MainKey);
            return _res;
        }



        private static string CreateCompareWhereStr(MDModel_QueryModel _qv, MDCompare_Request compareRequest)
        {
            if (compareRequest.CompareConditionExpression == "") return "1=1";
            string conditionStr = compareRequest.CompareConditionExpression;
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
                            _itemIndex = OraQueryBuilder.ProcDigit(conditionStr, ref i);
                        }
                        res.Append(GetCompareConditionStr(_qv, compareRequest, _itemIndex));
                        break;
                }
            }

            return res.ToString();
        }

        private static string GetCompareConditionStr(MDModel_QueryModel _qv, MDCompare_Request compareRequest, string _itemIndex)
        {
            if (!compareRequest.CompareItems.ContainsKey(_itemIndex))
            {
                throw new Exception(string.Format("缺少编号为{0}的条件项!", _itemIndex));
            }
            else
            {
                MDCompare_ConditionItem _cItem = compareRequest.CompareItems[_itemIndex];
                return OraConditionItemBuilder.BuildCompareConditionItemString(_cItem, _qv);
            }
        }

        private static List<string> GetAllCompareUsedTables(MDModel_QueryModel _qv, MDCompare_Request compareRequest)
        {
            List<string> _ret = new List<string>();
            _ret.Add(_qv.MainTable.TableName);
            foreach (MDCompare_ConditionItem _conItem in compareRequest.CompareItems.Values)
            {
                string _table = _conItem.Column.TableName;
                if (!_ret.Contains(_table)) _ret.Add(_table);
            }
            return _ret;
        }

        private static string CreateFilterStr(MDModel_QueryModel _qv, MDCompare_Request compareRequest)
        {

            string _res = "";

            MDQuery_Request _queryRequest = compareRequest as MDQuery_Request;
            List<string> _QueryUsedTableList = OraQueryBuilder.GetQueryUsedTable(_qv, _queryRequest);
            string _filterStr = OraQueryBuilder.CreateDataFilterStr(_qv);
            string _conditionStr = OraQueryBuilder.CreateConditionString(_qv, _queryRequest);
            string _tableStr = OraQueryBuilder.CreateTableString(_qv, _QueryUsedTableList);
            string _tableRelationStr = OraQueryBuilder.CreateTableRelationString(_qv, _QueryUsedTableList);
            string _displayStr = string.Format("{0}.{1} MAINID", _qv.MainTable.TableName, _qv.MainTable.TableDefine.Table.MainKey);

            _res = string.Format("select DISTINCT {0} from {1} where {4} ( {2} ({3})) ", _displayStr, _tableStr, _tableRelationStr, _conditionStr, _filterStr);

            return _res;
        }


        public static Dictionary<string, string> GetAllResultSQL(MDModel_QueryModel _qv, MDCompare_Request compareRequest)
        {
            Dictionary<string, string> _SqlCollection = new Dictionary<string, string>();
            _SqlCollection.Add(_qv.MainTable.TableName, GetMainTableQueryStr(_qv, compareRequest));
            foreach (MDQuery_ResultTable _qrc in compareRequest.ChildResultTables)
            {
                _SqlCollection.Add(_qrc.TableName, GetQueryStrByMainID(_qv, _qrc));
            }
            _SqlCollection.Add("EXCELRESULTDATA", GetExecelResultStr(_qv, compareRequest));
            _SqlCollection.Add("RESIDUAL", GetExcelResidual(_qv, compareRequest));
            return _SqlCollection;
        }

        private static string GetExcelResidual(MDModel_QueryModel _qv, MDCompare_Request compareRequest)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append(string.Format(" select TEMP_IMPDATA.XH 行号 ", _qv.MainTable.TableName, _qv.MainTable.TableDefine.Table.MainKey));
            foreach (string _key in compareRequest.ColumnDictionary.Keys)
            {
                _sb.Append(string.Format(",TEMP_IMPDATA.{0} \"{1}\"", _key, compareRequest.ColumnDictionary[_key]));
            }
            _sb.Append(" from TEMP_IMPDATA where xh not in (select pk_c from COMP_TEMP) ");
            return _sb.ToString();
        }

        private static string GetExecelResultStr(MDModel_QueryModel _qv, MDCompare_Request compareRequest)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append(string.Format(" select COMP_TEMP.PK_C 行号, {0}.{1} MAINID ", _qv.MainTable.TableName, _qv.MainTable.TableDefine.Table.MainKey));
            foreach (string _key in compareRequest.ColumnDictionary.Keys)
            {
                _sb.Append(string.Format(",TEMP_IMPDATA.{0} \"{1}\"", _key, compareRequest.ColumnDictionary[_key]));
            }
            _sb.Append(string.Format(" from COMP_TEMP,TEMP_IMPDATA,{0} where TEMP_IMPDATA.XH = COMP_TEMP.pk_c and ", _qv.MainTable.TableName));
            _sb.Append(string.Format("{0}.{1}= COMP_TEMP.pk_c2", _qv.MainTable.TableName, _qv.MainTable.TableDefine.Table.MainKey));
            return _sb.ToString();
        }

        private static string GetQueryStrByMainID(MDModel_QueryModel _qv, MDQuery_ResultTable _qrc)
        {
            List<string> _usedTables = new List<string>();
            _usedTables.Add(_qv.MainTable.TableName);
            _usedTables.Add(_qrc.TableName);
            string _displayStr = OraQueryBuilder.CreateDisplayString(_qv, _qrc);
            string _conditionRes = CreateConditionStringByMainID(_qv);
            string _tableStr = OraQueryBuilder.CreateTableString(_qv, _usedTables);
            string _tableRelationStr = OraQueryBuilder.CreateTableRelationString(_qv, _usedTables);
            return string.Format("select {0} from {1} where ( {2} ({3})) ",
                _displayStr, _tableStr, _tableRelationStr, _conditionRes);

        }

        private static string GetMainTableQueryStr(MDModel_QueryModel _qv, MDCompare_Request compareRequest)
        {
            MDQuery_Request _queryRequest = compareRequest as MDQuery_Request;
            List<string> _QueryUsedTableList = OraQueryBuilder.GetQueryUsedTable(_qv, _queryRequest);
            string _conditionRes = CreateConditionStringByMainID(_qv);
            string _tableStr = OraQueryBuilder.CreateTableString(_qv, _QueryUsedTableList);
            string _tableRelationStr = OraQueryBuilder.CreateTableRelationString(_qv, _QueryUsedTableList);
            string _displayStr = OraQueryBuilder.CreateDisplayString(_qv, compareRequest.MainResultTable);
            return string.Format("select distinct {0} from {1},COMP_TEMP where ( {2} ({3})) ", _displayStr, _tableStr, _tableRelationStr, _conditionRes);
        }

        private static string CreateConditionStringByMainID(MDModel_QueryModel _qv)
        {
            string _str = string.Format("{0}.{1} in (select  PK_C2 from COMP_TEMP) ", _qv.MainTable.TableName, _qv.MainTable.TableDefine.Table.MainKey);
            return _str;
        }


    }
}
