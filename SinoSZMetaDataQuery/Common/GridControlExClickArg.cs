using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SinoSZMetaDataQuery.Common
{
        public class GridControlExClickArg : EventArgs
        {
                public string TableName = "";
                public string Column = "";
                public string MainID = "";
                public object Value = null;
                public DataRow RowData = null;
                public GridControlExClickArg()
                {
                        //
                        // TODO: 在此处添加构造函数逻辑
                        //
                }
        }
}
