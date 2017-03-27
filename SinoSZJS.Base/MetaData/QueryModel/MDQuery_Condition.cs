using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MetaData.QueryModel
{
    [DataContract]   ///added by lqm 2012.10.17
    public class MDQuery_Condition
    {
        public int ColumnIndex { set; get; }

        public string ColumnName { set; get; }

        public string DisplayTitle { set; get; }

        public string ColumnDataType { set; get; }

        public string ColumnRefDMB { set; get; }

        public string TableName { set; get; }
    }
}
