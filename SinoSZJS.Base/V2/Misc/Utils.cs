using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace SinoSZJS.Base.V2.Misc
{
    public class Utils
    {
        public static string ExeFullPath;				//	当前EXE的全路径名称
        public static string ExeDir;					//	当前EXE文件所在的目录
        public static string ExeFileName;				//	当前EXE文件的文件名称
        public static string AppConfigFileName;		//	.NET程序缺省配置文件文件名(WinForm版本)
        public static string AppConfigFullPath;			//	.NET程序缺省配置文件的全路径名称(WinForm版本)

        static Utils()
        {
            ExeFullPath = Assembly.GetEntryAssembly().Location;
            ExeDir = Path.GetDirectoryName(ExeFullPath);
            StrUtils.EnsureEndsWith(ref ExeDir, '\\');
            ExeFileName = Path.GetFileName(ExeFullPath);
            AppConfigFileName = ExeFileName + ".config";
            AppConfigFullPath = ExeFullPath + ".config";

        }

    }
}
