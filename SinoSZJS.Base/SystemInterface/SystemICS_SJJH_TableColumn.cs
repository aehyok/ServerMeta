using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.SystemInterface
{
        public class SystemICS_SJJH_TableColumn
        {
                private string tableName = "";
                private string columnName = "";
                private string columnType = "";
                private int columnLength = 0;
                private string refTableName = "";

                public SystemICS_SJJH_TableColumn(string _tableName, string _columnName, string _columnType, int _length, string _refTable)
                {
                        tableName = _tableName;
                        columnName = _columnName;
                        columnType = _columnType;
                        columnLength = _length;
                        refTableName = _refTable;
                }
                public string TableName
                {
                        get { return tableName; }
                        set { tableName = value; }
                }

                public string RefTableName
                {
                        get { return refTableName; }
                        set { refTableName = value; }
                }


                public string ColumnName
                {
                        get { return columnName; }
                        set { columnName = value; }
                }

                public string ColumnType
                {
                        get { return columnType; }
                        set { columnType = value; }
                }

                public int ColumnLength
                {
                        get { return columnLength; }
                        set { columnLength = value; }
                }

        }
}
