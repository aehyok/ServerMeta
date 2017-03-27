using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.User
{
	/// <summary>
	/// 岗位用户列表
	/// </summary>
	[DataContract]
	public class PostUserList
	{
		public PostUserList() { }

		public PostUserList(string userID, string userName, string personID, string dwid, string djsfzh, string loginName,
							 string sex, string customsNO, string policeNO, string yjdz, string zwmc, string zwjb,
							 string gwmc, string gwms, string ssdwid)
		{
			UserID = userID;
			UserName = userName;
			PersonID = personID;
			DWID = dwid;
			DJSFZH = djsfzh;
			LoginName = loginName;
			Sex = sex;
			CustomsNO = customsNO;
			PoliceNO = policeNO;
			YJDZ = yjdz;
			ZWMC = zwmc;
			ZWJB = zwjb;
			GWMC = gwmc;
			GWMS = gwms;
			SSDWID = ssdwid;
		}


		/// <summary>
		/// 用户ID
		/// </summary>
		[DataMember]
		public string UserID { get; set; }
		/// <summary>
		/// 用户姓名
		/// </summary>
		[DataMember]
		public string UserName { get; set; }
		/// <summary>
		/// 人员ID
		/// </summary>
		[DataMember]
		public string PersonID { get; set; }
		/// <summary>
		/// 单位ID
		/// </summary>
		[DataMember]
		public string DWID { get; set; }
		/// <summary>
		/// 登记身份证号
		/// </summary>
		[DataMember]
		public string DJSFZH { get; set; }
		/// <summary>
		/// 用户登录名
		/// </summary>
		[DataMember]
		public string LoginName { get; set; }
		/// <summary>
		/// 用户性别
		/// </summary>
		[DataMember]
		public string Sex { get; set; }
		/// <summary>
		/// 海关编号
		/// </summary>
		[DataMember]
		public string CustomsNO { get; set; }
		/// <summary>
		/// 警号
		/// </summary>
		[DataMember]
		public string PoliceNO { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string YJDZ { get; set; }
		/// <summary>
		/// 职务名称
		/// </summary>
		[DataMember]
		public string ZWMC { get; set; }
		/// <summary>
		/// 职务级别
		/// </summary>
		[DataMember]
		public string ZWJB { get; set; }
		/// <summary>
		/// 岗位名称
		/// </summary>
		[DataMember]
		public string GWMC { get; set; }
		/// <summary>
		/// 岗位说明
		/// </summary>
		[DataMember]
		public string GWMS { get; set; }
		/// <summary>
		/// 所属单位ID
		/// </summary>
		[DataMember]
		public string SSDWID { get; set; }

	}
}
