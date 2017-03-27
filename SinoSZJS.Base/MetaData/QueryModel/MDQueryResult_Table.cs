using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace SinoSZJS.Base.MetaData.QueryModel
{
    [DataContract]
    public class MDQueryResult_Table
    {
        /// <summary>
        /// 表名称
        /// </summary>
        [DataMember]
        public string TableName { get; set; }

        /// <summary>
        /// 字段列表
        /// </summary>
        [DataMember]
        public List<MDQueryResult_TableColumn> Columns { get; set; }

        /// <summary>
        /// 记录行集
        /// </summary>
        [DataMember]
        public List<MDQueryResult_TableRow> Rows { get; set; }


        public MDQueryResult_Table(string _tableName)
        {
            // TODO: Complete member initialization
            this.TableName = _tableName;
        }

    }

    [DataContract]
    public class MDQueryResult_TableColumn
    {
        [DataMember]
        public string ColumnName { get; set; }
        [DataMember]
        public string ColumnType { get; set; }
        public MDQueryResult_TableColumn() { }
        public MDQueryResult_TableColumn(string name, string type)
        {
            ColumnName = name;
            ColumnType = type;
        }
    }
}
