using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Document
{
    /// <summary>
    /// 文书类型明细
    /// </summary>
    [DataContract]
    public class DocTypeDetails
    {
        /// <summary>
        ///文书类型明细Id 
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// 文书类型Id
        /// </summary>
        [DataMember]
        public string DocTypeId { get; set; }

        /// <summary>
        /// 文书名称
        /// </summary>
        [DataMember]
        public string DocName { get; set; }

        /// <summary>
        /// 文书所绑定录入模型的名称
        /// </summary>
        [DataMember]
        public string ModelName { get; set; }

        /// <summary>
        /// 文书所绑定的视图的名称
        /// </summary>
        [DataMember]
        public string ViewName { get; set; }

		/// <summary>
		/// 展示顺序
		/// </summary>
		[DataMember]
		public int DisplayOrder { get; set; }

        /// <summary>
        /// Form表单Id
        /// </summary>
        [DataMember]
        public string FormName { get; set; }
        
        /// <summary>
        /// 指标Id
        /// </summary>
        [DataMember]
        public string GuideLineId { get; set; }

        /// <summary>
        /// 工厂对应实体类名称（命名空间+实体类类名）
        /// </summary>
        [DataMember]
        public string FactoryClassName { get; set; }

         /// <summary>
        /// 是否能制作多份文书
        /// </summary>
        [DataMember]
        public string CanCreateMore { get; set; }

        /// <summary>
        /// 卷别（A卷、B卷）
        /// </summary>
        [DataMember]
        public string DocVolume { get; set; }

        /// <summary>
        /// 卷别中的展示顺序
        /// </summary>
        [DataMember]
        public decimal VolumeDislayOrder { get; set; }

        /// <summary>
        /// 签章关键字
        /// </summary>
        [DataMember]
        public string SignWord { get; set; }

        /// <summary>
        /// 案件系统文书编号
        /// </summary>
        [DataMember]
        public decimal CaseDocNo { get; set; }

        /// <summary>
        /// 目标文书
        /// </summary>
        [DataMember]
        public string TargetDoc { get; set; }
    }
}
