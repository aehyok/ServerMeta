using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.InputModel
{
    /// <summary>
    /// added by lqm 2014.03.25 录入模型保存表
    /// </summary>
    [DataContract(IsReference = true)]
    public class MD_InputModel_SaveTable
    {
        /// <summary>
        /// 录入模型保存表Id
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// 录入模型表名称
        /// </summary>
        [DataMember]
        public string TableName { get; set; }
        
        /// <summary>
        /// 录入模型表显示名称
        /// </summary>
        [DataMember]
        public string TableTitle { get; set; }

        /// <summary>
        /// 是否锁定
        /// </summary>
        [DataMember]
        public bool IsLock { get; set; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        [DataMember]
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 录入模型Id
        /// </summary>
        [DataMember]
        public string InputModelId { get; set; }
        [DataMember]
        public List<MD_InputModel_SaveTableColumn> Columns { get; set; }

        /// <summary>
        /// 保存模式
        /// </summary>
        [DataMember]
        public string SaveMode { get; set; }

        public override string ToString()
        {
            return string.Format("{0} [{1}]", TableTitle, TableName);
        }

        public MD_InputModel_SaveTable() { }
        public MD_InputModel_SaveTable(string id, string tableName, string tableTitle, bool isLock, string inputModelId, int displayOrder)
        {
            Id = id;
            TableName = tableName;
            TableTitle = tableTitle;
            IsLock = isLock;
            DisplayOrder = displayOrder;
            InputModelId = inputModelId;
        }
        public MD_InputModel_SaveTable(string id, string tableName, string tableTitle, bool isLock, string inputModelId, int displayOrder, string saveMode)
        {
            Id = id;
            TableName = tableName;
            TableTitle = tableTitle;
            IsLock = isLock;
            DisplayOrder = displayOrder;
            InputModelId = inputModelId;
            this.SaveMode = (saveMode == null || saveMode.Length == 0) ? "DEFAULT" : saveMode.ToUpper();
        }
    }
}
