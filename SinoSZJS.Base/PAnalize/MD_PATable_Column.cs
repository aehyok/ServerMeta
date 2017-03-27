using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.PAnalize
{
        public class MD_PATable_Column
        {
                private string tid = "";
                private string tableName = "";
                private string columnid = "";
                private string columnName = "";
                private string displayTitle = "";
                private string columnType = "";
                private int columnLength = 1;
                private string refDMB = "";
                private string displayFormat = "";
                private string refWord = "";
                private int displayOrder = 0;
                private bool isChanged = false;

                public bool IsChanged
                {
                        get
                        {
                                return isChanged;
                        }
                }

                public int DisplayOrder
                {
                        get { return displayOrder; }
                        set { displayOrder = value; }
                }

                public string ColumnType
                {
                        get { return columnType; }
                        set
                        {
                                if (ColumnType != value)
                                {
                                        columnType = value;
                                        isChanged = true;
                                }
                        }
                }

                public int ColumnLength
                {
                        get { return columnLength; }
                        set { columnLength = value; }
                }

                public string RefDMB
                {
                        get { return refDMB; }
                        set { refDMB = value; }
                }

                public string DisplayFormat
                {
                        get { return displayFormat; }
                        set { displayFormat = value; }
                }

                public string RefWord
                {
                        get { return refWord; }
                        set { refWord = value; }
                }

                public string TID
                {
                        get { return tid; }
                        set { tid = value; }
                }

                public string TableName
                {
                        get { return tableName; }
                        set { tableName = value; }
                }

                public string ColumnID
                {
                        get { return columnid; }
                        set { columnid = value; }
                }

                public string ColumnName
                {
                        get { return columnName; }
                        set { columnName = value; }
                }

                public string DisplayTitle
                {
                        get { return displayTitle; }
                        set { displayTitle = value; }
                }
                public MD_PATable_Column() { }

                public MD_PATable_Column(string _tid, string _tname, string _cid, string _cname, string _title, string _colType, int _colLength, int _order)
                {
                        tid = _tid;
                        tableName = _tname;
                        columnid = _cid;
                        columnName = _cname;
                        displayTitle = _title;
                        columnType = _colType;
                        columnLength = _colLength;
                        displayOrder = _order;

                }

                public MD_PATable_Column(string _tid, string _tname, string _cid, string _cname, string _title, string _colType,
                                                        int _colLength, int _order, string _refDMB, string _displayFormat, string _refWord)
                {
                        tid = _tid;
                        tableName = _tname;
                        columnid = _cid;
                        columnName = _cname;
                        displayTitle = _title;
                        columnType = _colType;
                        columnLength = _colLength;
                        refDMB = _refDMB;
                        displayFormat = _displayFormat;
                        refWord = _refWord;
                        displayOrder = _order;
                }
        }
}
