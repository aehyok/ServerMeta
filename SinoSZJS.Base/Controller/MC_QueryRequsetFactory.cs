using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.MetaData.QueryModel;
using System.Linq;
using SinoSZJS.Base.MetaData.EnumDefine;

namespace SinoSZJS.Base.Controller
{
    public class MC_QueryRequsetFactory
    {
        protected MDQuery_Request queryRequest = new MDQuery_Request();

        public MDQuery_Request GetQueryRequest()
        {
            return queryRequest;
        }

        public string QueryModelName
        {
            get { return queryRequest.QueryModelName; }
            set { queryRequest.QueryModelName = value; }
        }

        public void AddConditonItem(MDQuery_ConditionItem _conditionItem)
        {
            if (this.queryRequest.ConditionItems == null) this.queryRequest.ConditionItems = new List<MDQuery_ConditionItem>();

            this.queryRequest.ConditionItems.Add(_conditionItem);
        }

        public void AddResultTable(MDModel_Table _mtable)
        {
            string _tname = _mtable.TableName;
            if (this.queryRequest.MainResultTable != null && this.queryRequest.MainResultTable.TableName == _tname) return;
            if (this.queryRequest.ChildResultTables == null) this.queryRequest.ChildResultTables = new List<MDQuery_ResultTable>();
            var find = from _t in this.queryRequest.ChildResultTables
                       where _t.TableName == _tname
                       select _t;
            if (find != null && find.Count() > 0) return;
            MDQuery_ResultTable _table = new MDQuery_ResultTable();
            _table.TableName = _mtable.TableName;
            _table.DisplayTitle = _mtable.TableDefine.DisplayTitle;
            if (_mtable.TableDefine.ViewTableType == MDType_ViewTable.MainTable)
            {
                this.queryRequest.MainResultTable = _table;
            }
            else
            {
                _table.Columns = new List<MDQuery_TableColumn>();
                this.queryRequest.ChildResultTables.Add(_table);
            }
        }

        public void AddResultTableColumn(MDModel_Table _mtable, MDModel_Table_Column _mColumn)
        {
            MDQuery_ResultTable _rtable = null;
            string _tname = _mtable.TableName;
            if (this.queryRequest.MainResultTable != null && this.queryRequest.MainResultTable.TableName == _tname)
            {
                _rtable = this.queryRequest.MainResultTable;
            }
            else
            {
                var _rts = from _c in this.queryRequest.ChildResultTables
                           where _c.TableName == _tname
                           select _c;
                if (_rts != null && _rts.Count() > 0) _rtable = _rts.First();
            }
            if (_rtable.Columns == null) _rtable.Columns = new List<MDQuery_TableColumn>();

            string _cname = _mColumn.ColumnName;
            var _find = from _t in _rtable.Columns
                        where _t.ColumnName == _cname
                        select _t;
            if (_find == null || _find.Count() < 1)
            {
                MDQuery_TableColumn _column = new MDQuery_TableColumn(_mColumn);               
                _rtable.Columns.Add(_column);

            }


        }

        public void AddExpression(string _expression)
        {
            queryRequest.ConditionExpressions = _expression;
        }
    }
}
