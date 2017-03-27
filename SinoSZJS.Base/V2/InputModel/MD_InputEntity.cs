using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.InputModel
{
	/// <summary>
	/// added by lqm 2014.03.26 录入模型实体数据
	/// </summary>
	[DataContract]
	public class MD_InputEntity
	{
		/// <summary>
		/// 录入模型名称
		/// </summary>
		[DataMember]
		public string InputModelName { get; set; }

		/// <summary>
		/// 录入模型实体数据字典
		/// </summary>
		[DataMember]
		public Dictionary<string, string> InputData { get; set; }

		/// <summary>
		/// 是否为新数据
		/// </summary>
		[DataMember]
		public bool IsNewData { get; set; }

		/// <summary>
		/// 是否为新流程
		/// </summary>
		[DataMember]
		public bool IsNewFlow { get; set; }

		/// <summary>
		/// 子模型实体数据列表
		/// </summary>
		[DataMember]
		public Dictionary<string, string> ChildInputData { get; set; }

		public MD_InputEntity() { }
		public MD_InputEntity(string inputModelName)
		{
			InputModelName = inputModelName;
		}

		/// <summary>
		/// 深复制该对象
		/// </summary>
		/// <returns></returns>
		public MD_InputEntity DeepClone()
		{
			MD_InputEntity ret = new MD_InputEntity();
			ret.InputModelName = this.InputModelName;
			ret.IsNewData = this.IsNewData;
			ret.IsNewFlow = this.IsNewFlow;
			if (this.ChildInputData != null)
			{
				Dictionary<string, string> cInputData = new Dictionary<string, string>();
				foreach (var input in this.ChildInputData)
				{
					cInputData.Add(input.Key, input.Value);
				}
				ret.ChildInputData = cInputData;
			}

			if (this.InputData != null)
			{
				Dictionary<string, string> inputData = new Dictionary<string, string>();
				foreach (var input in this.InputData)
				{
					inputData.Add(input.Key, input.Value);
				}
				ret.InputData = inputData;
			}

			return ret;
		}
	}
}
