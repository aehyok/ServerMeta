using System.Runtime.Serialization;

namespace SinoSZJS.Base.Instruments
{
    /// <summary>
    /// added by mhq 2014.01.09
    /// 文书类型明细
    /// </summary>
    [DataContract]
    public class Entity_DocTypeDetails
    {
        /// <summary>
        /// 文书类型明细ID
        /// </summary>
        [DataMember]
        public int Id { get; set; }
        
        /// <summary>
        /// 文书名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 文书类型ID（关联JSYW_WSDY_WSLX）
        /// </summary>
        [DataMember]
        public int DocTypeId { get; set; }

        /// <summary>
        /// 文书录入模型名称
        /// </summary>
        [DataMember]
        public string InputModelName { get; set; }

        /// <summary>
        /// 文书部分视图名称
        /// </summary>
        [DataMember]
        public string PartOfViewName { get; set; }

        /// <summary>
        /// 文书对应视图中Form名称
        /// </summary>
        [DataMember]
        public string FormOnViewName { get; set; }

        /// <summary>
        /// 文书取物品指标
        /// </summary>
        [DataMember]
        public string GetItemsIndex { get; set; }
        
        /// <summary>
        /// 工厂对应文书类名称
        /// </summary>
        [DataMember]
        public string FactoryClassName { get; set; }
        
        /// <summary>
        /// 用于文书排序ID
        /// </summary>
        [DataMember]
        public int SortId { get; set; }
        
        /// <summary>
        /// 1，1份；2，多份
        /// </summary>
        [DataMember]
        public string DocCounts { get; set; }

        /// <summary>
        /// 文书分类（A卷、B卷）
        /// </summary>
        [DataMember]
        public string DocKinds { get;set;}
        
        /// <summary>
        /// 卷内目录顺序
        /// </summary>
        [DataMember]
        public int CatalogueOrder { get; set; }
        
        /// <summary>
        /// 文书审批时转换成的目标文书
        /// </summary>
        [DataMember]
        public string ConvertToAimDoc { get; set; }

        /// <summary>
        /// 签章关键字
        /// </summary>
        [DataMember]
        public string SignWord { get; set; }


    }
}
