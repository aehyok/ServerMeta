using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.Define;

namespace SinoSZMetaDataQuery.Common
{
        internal class ColumnListItem
        {

                MDModel_Table_Column column = null;

                public ColumnListItem() { }
                public ColumnListItem(MDModel_Table_Column _column)
                {
                        column = _column;
                }

                public MDModel_Table_Column Column
                {
                        get
                        {
                                return column;
                        }
                }

                public string FieldAliasName
                {
                        get
                        {
                                if (column == null) return "";
                                return column.ColumnAlias;
                        }
                }

                public string FieldName
                {
                        get
                        {
                                if (column == null) return "";
                                return column.ColumnName;
                        }
                }

                public string FieldDisplayName
                {
                        get
                        {
                                if (column == null) return "";
                                return column.ColumnTitle;
                        }
                }
                public override string ToString()
                {
                        if (column == null) return "";
                        return string.Format("${0}$  {1}", column.ColumnAlias, column.ColumnTitle);
                }
        }

        internal class FunListItem
        {
                MD_FUNCTION funDefine = null;
                public FunListItem() { }
                public FunListItem(MD_FUNCTION _function)
                {
                        funDefine = _function;
                }
                public MD_FUNCTION Function
                {
                        get
                        {
                                return funDefine;
                        }
                }
                public override string ToString()
                {
                        if (funDefine == null) return "";
                        return funDefine.Name;
                }
        }

        internal class TableListItem
        {
                MDModel_Table tableDefine = null;
                public TableListItem() { }
                public TableListItem(MDModel_Table _table)
                {
                        tableDefine = _table;
                }
                public MDModel_Table Table
                {
                        get
                        {
                                return tableDefine;
                        }
                }
                public override string ToString()
                {
                        if (tableDefine == null) return "";
                        return tableDefine.TableDefine.DisplayTitle;
                }
        }

}
