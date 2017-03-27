//	Utils
//
//	ʵ��һЩ���õĻ�����
//
//	����:		������(2003.10.27 --- 2004.3.29)
//	
//	����:
//
//	���˼·:
//
//	�汾����:
//
//	��δ���������:

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
		public static string ExeFullPath;				//	��ǰEXE��ȫ·������
		public static string ExeDir;					//	��ǰEXE�ļ����ڵ�Ŀ¼
		public static string ExeFileName;				//	��ǰEXE�ļ����ļ�����
		public static string AppConfigFileName;		//	.NET����ȱʡ�����ļ��ļ���(WinForm�汾)
		public static string AppConfigFullPath;			//	.NET����ȱʡ�����ļ���ȫ·������(WinForm�汾)
		
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
