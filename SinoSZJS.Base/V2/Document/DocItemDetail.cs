
namespace SinoSZJS.Base.V2.Document
{
    /// <summary>
    /// 文书事项明细
    /// </summary>
	public class DocItemDetail
	{
		/// <summary>
		/// 文书id
		/// </summary>
		public string DocId { set; get; }

        /// <summary>
        /// 文书类型Id
        /// </summary>
        public string DocTypeId { set; get; }

        /// <summary>
        /// 文书类型明细Id
        /// </summary>
        public string DocTypeDetailsId { set; get; }

		/// <summary>
		/// 文书名
		/// </summary>
		public string DocTitle { set; get; }
	}
}
