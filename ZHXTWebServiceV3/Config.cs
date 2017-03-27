//	Config.cs
//
//	服务器端的配置信息
//
//	作者:		黄晓东(2004.2.7)
//	整理者:
//	
//	描述:
//		负责定义服务器端用到的所有配置信息, 供外部程序使用
//
//	设计思路:
//		1. 配置信息需要存放在2个地方： config文件和数据库中. 其中数据库连接部分必须放在config文件中，其他信息
//		   则适宜于存放在数据库中，这样可以方便统一部署和用户配置。 但为了方便测试，允许config文件中的信息覆盖
//		   数据库中存放的配置信息
//		2. 数据库中的配置信息需要定期重读
//
//	使用方法:
//
//	版本特性:
//		1. 不支持对config文件中的配置信息实现定期读取(仅支持数据库中的配置信息重读)
//
//	遗留问题:
//		1. Config读取失败应该有处理


using System;
using System.Collections;
using System.Reflection;
using SinoSZJS.DataAccess;

namespace DIReport.ZHXTWebService
{
    public class ConfigData
    {
        //	config文件存放部分(此信息只能放在config文件中, 后面的其他信息缺省放在数据库的Config表中, 但也可以用config文件中的信息来覆盖)
        public string DbConnStr;
        public string Version;
    }


    /// <summary>
    /// Server (AppServer & DataProcessService) 的所有配置信息
    /// </summary>
    public class Config
    {
        #region Properties
        public static ConfigData _CfgData { get { return _cfgData; } }

        //	数据库部分
        public static string DbConnStr { get { return _cfgData.DbConnStr; } }
        //	版本信息
        public static string Version { get { return _cfgData.Version; } }


        #endregion

        private static volatile ConfigData _cfgData;			//	存放配置信息的对象

        public static void LoadConfig()
        {
            ConfigData newCfg = new ConfigData();
            newCfg.DbConnStr = OracleHelper.ConnectionStringProfile;

            //  2. 获取版本号
            Assembly SysAssembly = Assembly.GetAssembly(typeof(Config));
            AssemblyName SysAssemblyName = SysAssembly.GetName();
            newCfg.Version = SysAssemblyName.Version.ToString();
            //	5. 将读好的Config复制到正式的_cfgData引用中
            _cfgData = newCfg;

        }

        #region Private Methods

        private static string _ReadCfgDb(Hashtable cfgDb, string itemStr)
        {
            string s = (string)cfgDb[itemStr];
            if (s == null)
                throw new Exception(string.Format("在表中找不到'{0}'配置项", itemStr));
            return s;
        }

        private static void _ReadCfgDb(Hashtable cfgDb, string itemStr, out string item)
        {
            item = _ReadCfgDb(cfgDb, itemStr);
        }

        private static void _ReadCfgDb(Hashtable cfgDb, string itemStr, out bool item)
        {
            string s = _ReadCfgDb(cfgDb, itemStr);
            if (s == "1" || s.ToUpper() == "TRUE" || s.ToUpper() == "ENABLE" || s.ToUpper() == "YES")
                item = true;
            else
                item = false;
        }

        private static void _ReadCfgDb(Hashtable cfgDb, string itemStr, out int item)
        {
            string s = _ReadCfgDb(cfgDb, itemStr);
            try
            {
                item = int.Parse(s);
            }
            catch (Exception)
            {
                throw new Exception(string.Format("在表中'{0}'配置项格式错误", itemStr));
            }
        }


        #endregion

        #region CfgItem Strings
        private class CfgItem
        {
            //	config文件存放部分
            public const string DbConnStr = "DbConnStr";

            //	其他
            public const string BeepOnSvcAction = "BeepOnSvcAction";
        }
        #endregion
    }


}