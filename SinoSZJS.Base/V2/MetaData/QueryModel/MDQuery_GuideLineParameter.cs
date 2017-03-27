using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.MetaData.QueryModel
{
	[DataContract]
	public class MDQuery_GuideLineParameter
	{
		/// <summary>
		/// 参数名称
		/// </summary>
		[DataMember]
		public string ParameterName { get; set; }
		/// <summary>
		/// 参数显示名称
		/// </summary>
		[DataMember]
		public string DisplayTitle { get; set; }
		/// <summary>
		/// 参数类型
		/// </summary>
		[DataMember]
		public string ParameterType { get; set; }
		/// <summary>
		/// 参数值
		/// </summary>
		[DataMember]
		public object ParameterValue { get; set; }

		[DataMember]
		public string RefTableName { get; set; }

		[DataMember]
		public bool IncludeChildren { get; set; }

		[DataMember]
		public string SelectAllCode { get; set; }
		[DataMember]
		public MD_GuideLineParameter Paramter { get; set; }

		[DataMember]
		public object Data { set; get; }
		public MDQuery_GuideLineParameter() { }

		public MDQuery_GuideLineParameter(MD_GuideLineParameter pDefine, object data)
		{
			Paramter = pDefine;
			Data = data;
			this.ParameterName = pDefine.ParameterName;
			this.DisplayTitle = pDefine.DisplayTitle;
			this.ParameterType = pDefine.ParameterType;
			this.ParameterValue = data;
			this.RefTableName = pDefine.RefTableName;
			this.IncludeChildren = pDefine.IncludeChildren;
			this.SelectAllCode = pDefine.SelectAllCode;
		}
		public MDQuery_GuideLineParameter(string paramName, string paramType, object value)
		{
			ParameterName = paramName;
			ParameterType = paramType;
			ParameterValue = value;
		}
	}
}
