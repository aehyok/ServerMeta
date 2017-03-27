//	Config.cs
//
//	�������˵�������Ϣ
//
//	����:		������(2004.2.7)
//	������:
//	
//	����:
//		��������������õ�������������Ϣ, ���ⲿ����ʹ��
//
//	���˼·:
//		1. ������Ϣ��Ҫ�����2���ط��� config�ļ������ݿ���. �������ݿ����Ӳ��ֱ������config�ļ��У�������Ϣ
//		   �������ڴ�������ݿ��У��������Է���ͳһ������û����á� ��Ϊ�˷�����ԣ�����config�ļ��е���Ϣ����
//		   ���ݿ��д�ŵ�������Ϣ
//		2. ���ݿ��е�������Ϣ��Ҫ�����ض�
//
//	ʹ�÷���:
//
//	�汾����:
//		1. ��֧�ֶ�config�ļ��е�������Ϣʵ�ֶ��ڶ�ȡ(��֧�����ݿ��е�������Ϣ�ض�)
//
//	��������:
//		1. Config��ȡʧ��Ӧ���д���


using System;
using System.Collections;
using System.Reflection;
using SinoSZJS.DataAccess;

namespace DIReport.ZHXTWebService
{
    public class ConfigData
    {
        //	config�ļ���Ų���(����Ϣֻ�ܷ���config�ļ���, �����������Ϣȱʡ�������ݿ��Config����, ��Ҳ������config�ļ��е���Ϣ������)
        public string DbConnStr;
        public string Version;
    }


    /// <summary>
    /// Server (AppServer & DataProcessService) ������������Ϣ
    /// </summary>
    public class Config
    {
        #region Properties
        public static ConfigData _CfgData { get { return _cfgData; } }

        //	���ݿⲿ��
        public static string DbConnStr { get { return _cfgData.DbConnStr; } }
        //	�汾��Ϣ
        public static string Version { get { return _cfgData.Version; } }


        #endregion

        private static volatile ConfigData _cfgData;			//	���������Ϣ�Ķ���

        public static void LoadConfig()
        {
            ConfigData newCfg = new ConfigData();
            newCfg.DbConnStr = OracleHelper.ConnectionStringProfile;

            //  2. ��ȡ�汾��
            Assembly SysAssembly = Assembly.GetAssembly(typeof(Config));
            AssemblyName SysAssemblyName = SysAssembly.GetName();
            newCfg.Version = SysAssemblyName.Version.ToString();
            //	5. �����õ�Config���Ƶ���ʽ��_cfgData������
            _cfgData = newCfg;

        }

        #region Private Methods

        private static string _ReadCfgDb(Hashtable cfgDb, string itemStr)
        {
            string s = (string)cfgDb[itemStr];
            if (s == null)
                throw new Exception(string.Format("�ڱ����Ҳ���'{0}'������", itemStr));
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
                throw new Exception(string.Format("�ڱ���'{0}'�������ʽ����", itemStr));
            }
        }


        #endregion

        #region CfgItem Strings
        private class CfgItem
        {
            //	config�ļ���Ų���
            public const string DbConnStr = "DbConnStr";

            //	����
            public const string BeepOnSvcAction = "BeepOnSvcAction";
        }
        #endregion
    }


}