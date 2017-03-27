using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.WCF;
using System.Runtime.Serialization.Json;
using SinoSystemWatch.Base.Define;
using System.IO;
using System.Configuration;

namespace SinoSysMonitorCenter.SystemNode
{
    class SystemNodeAccessor
    {
        public static string AddSystem(byte[] ParameterData)
        {
            try
            {
                string _decodeItem = WcfDataCompressControl.UnCompress(ParameterData);
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(SystemStateItem));
                MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(_decodeItem.ToCharArray()));
                SystemStateItem _item = (SystemStateItem)serializer.ReadObject(ms);
                ms.Close();

                SystemConfigurationElement _el = new SystemConfigurationElement();
                _el.Name = _item.SystemName;
                _el.Description = _item.SystemDescription;
                _el.URL = _item.SystemURL;
                _el.DeployID = "";

                //插入配置
                Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                SystemConfigSection CurrentSysList = (SystemConfigSection)cfa.GetSection("SystemList");
                CurrentSysList.PluginCollection.Add(_el);
                cfa.Save();
                //插入缓存
                WatchSystemLib.AddSystem(_item);
                return "TRUE";
            }
            catch (Exception ex)
            {
                return "False!" + ex.Message;
            }
        }

        public static string ModifySystem(byte[] ParameterData)
        {
            try
            {
                string _decodeItem = WcfDataCompressControl.UnCompress(ParameterData);
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(SystemStateItem));
                MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(_decodeItem.ToCharArray()));
                SystemStateItem _item = (SystemStateItem)serializer.ReadObject(ms);
                ms.Close();

                //插入配置
                Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                SystemConfigSection CurrentSysList = (SystemConfigSection)cfa.GetSection("SystemList");
                SystemConfigurationElement _el = CurrentSysList.PluginCollection[_item.SystemName];
                _el.Description = _item.SystemDescription;
                _el.URL = _item.SystemURL;
                cfa.Save();
                //插入缓存
                SystemStateItem _c = WatchSystemLib.GetSystem(_item.SystemName);
                _c.SystemURL = _item.SystemURL;
                _c.SystemDescription = _item.SystemDescription;
                return "TRUE";
            }
            catch (Exception ex)
            {
                return "False!" + ex.Message;
            }
        }

        public static string DelSystem(byte[] ParameterData)
        {
            try
            {
                string _delName = WcfDataCompressControl.UnCompress(ParameterData);

                //删除配置
                Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                SystemConfigSection CurrentSysList = (SystemConfigSection)cfa.GetSection("SystemList");
                CurrentSysList.PluginCollection.Remove(_delName);
                cfa.Save();

                //删除缓存
                WatchSystemLib.RemoveSystem(_delName);
                return "TRUE";
            }
            catch (Exception ex)
            {
                return "False!" + ex.Message;
            }
        }


    }
}
