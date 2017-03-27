
namespace SinoSZJS.Base.V2.Config
{
	/// <summary>
	/// added by lqm 2014.03.17 服务端配置文件实体类
	/// </summary>
	public class ServerConfig
	{
		/// <summary>
		/// 系统ID
		/// </summary>
		public static string SystemId { get; set; }
		/// <summary>
		/// 系统组织机构根ID
		/// </summary>
		public static string SystemOrganzationId { get; set; }
		/// <summary>
		/// 是否是windows服务
		/// </summary>
		public static bool IsWindowsService { set; get; }

        /// <summary>
        /// WCF服务版本号
        /// </summary>
        public static string ServerVersion { get; set; }
	}
}
