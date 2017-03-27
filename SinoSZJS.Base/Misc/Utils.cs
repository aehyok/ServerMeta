//	Utils
//
//	实现一些公用的基础类
//
//	作者:		黄晓东(2003.10.27 --- 2004.3.29)
//	
//	描述:
//
//	设计思路:
//
//	版本特性:
//
//	尚未解决的问题:

using System;
using System.Text;
using System.IO;
using System.Reflection;


namespace SinoSZJS.Base.Misc
{
	/// <summary>
	/// Summary description for Utils.
	/// </summary>
	public class Utils
	{
		public static string ExeFullPath;				//	当前EXE的全路径名称
		public static string ExeDir;					//	当前EXE文件所在的目录
		public static string ExeFileName;				//	当前EXE文件的文件名称
		public static string AppConfigFileName;		//	.NET程序缺省配置文件文件名(WinForm版本)
		public static string AppConfigFullPath;			//	.NET程序缺省配置文件的全路径名称(WinForm版本)
		
		static Utils()
		{
			ExeFullPath			= Assembly.GetEntryAssembly().Location;
			ExeDir				= Path.GetDirectoryName(ExeFullPath);
			StrUtils.EnsureEndsWith(ref ExeDir, '\\');
			ExeFileName			= Path.GetFileName(ExeFullPath);
			AppConfigFileName	= ExeFileName + ".config";
			AppConfigFullPath	= ExeFullPath + ".config";
			
		}		
		
	}
}
