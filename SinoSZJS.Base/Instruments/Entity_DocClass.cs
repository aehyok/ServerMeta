using System.Runtime.Serialization;

namespace SinoSZJS.Base.Instruments
{
    /// <summary>
    /// added by lqm 2014.01.08
    /// 文书分类（JSYW_WSDY_WSFL）
    /// </summary>
    [DataContract]
    public class Entity_DocClass
    {
        /// <summary>
        /// 文书分类ID
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// 文书分类名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [DataMember]
        public int Sort { get; set; }
    }


}
