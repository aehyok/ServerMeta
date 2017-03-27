
namespace SinoSZJS.Base.Config
{
	public static class MVCConfig
	{
		public static string RootDWID { get; set; }
		public static string SystemID { get; set; }
		public static string LogoImage { get; set; }
		public static string LoginImage { get; set; }
		public static string LoginType { get; set; }
		public static string WebInterface { get; set; }
		public static string RootUrl { set; get; }
		public static string CompanyInterface { get; set; }
		public static string ISTestData { get; set; }
		/// <summary>
		/// 服务的版本信息
		/// </summary>
		public static string Version { set; get; }

        /// <summary>
        /// 系统角色——超级管理员角色Id
        /// </summary>
        public static string SystemRoleId { get; set; }
	}
}
