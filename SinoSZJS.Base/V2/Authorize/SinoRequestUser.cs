using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Authorize
{
	[DataContract]
	public class SinoRequestUser
	{
		/// <summary>
		/// 用户基本信息
		/// </summary>
		[DataMember]
		public SinoUserBaseInfo BaseInfo { get; set; }

		/// <summary>
		/// 岗位基本信息
		/// </summary>
		[DataMember]
		public SinoPost SinoPost { get; set; }
	}
}
