using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using SinoSystemWatch.Base.Application;
using System.Web.Script.Serialization;
using SinoSZJS.Base.Misc;

namespace SinoSystemWatch.Base.PluginFramework
{
    public class ServerPluginService : IServerPluginService
    {
        private IServerApplication application = null;
        private PluginConfigurationSection config = null;
        private Dictionary<String, IServerPlugin> plugins = new Dictionary<string, IServerPlugin>();
        private XmlDocument doc = new XmlDocument();
        public static List<AppPluginInfo> CurrentPluginInfos = new List<AppPluginInfo>();
        public static List<AppPluginInfo> PluginDescriptList = new List<AppPluginInfo>();
        public static IServerPluginService CurrentService = null;


        public ServerPluginService()
        {
            CurrentService = this;
        }

        public ServerPluginService(IServerApplication _app)
        {
            application = _app;
            CurrentService = this;
        }

        #region IServerPluginService Members

        public IServerApplication Application
        {
            get
            {
                return application;
            }
            set
            {
                application = value;
            }
        }

        public void AddPlugin(string pluginName, string pluginType, string Assembly, string pluginDescription, string version)
        {
            doc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            XmlNode pluginNode = doc.SelectSingleNode("/configuration/PluginSection");
            XmlElement ele = doc.CreateElement("add");
            XmlAttribute attr = doc.CreateAttribute("Name");
            attr.Value = pluginName;
            ele.SetAttributeNode(attr);
            XmlAttribute attrType = doc.CreateAttribute("Type");
            attrType.Value = pluginType;
            ele.SetAttributeNode(attrType);

            XmlAttribute attrVersion = doc.CreateAttribute("Version");
            attrVersion.Value = version;
            ele.SetAttributeNode(attrVersion);

            XmlAttribute attrAss = doc.CreateAttribute("Assembly");
            attrAss.Value = Assembly;
            ele.SetAttributeNode(attrAss);

            XmlAttribute attrDes = doc.CreateAttribute("Description");
            attrDes.Value = pluginDescription;
            ele.SetAttributeNode(attrDes);
            pluginNode.AppendChild(ele);
            doc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            ConfigurationManager.RefreshSection("PluginSection");
        }

        public void RemovePlugin(string pluginName)
        {
            doc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            XmlNode node = doc.SelectSingleNode("/configuration/PluginSection");
            foreach (XmlNode n in node.ChildNodes)
            {
                if (n.Attributes != null)
                {
                    if (n.Attributes[0].Value == pluginName)
                    {
                        node.RemoveChild(n);
                    }
                }
            }
            doc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            ConfigurationManager.RefreshSection("PluginSection");
            var _p = from _c in CurrentPluginInfos
                     where _c.Name == pluginName
                     select _c;
            AppPluginInfo _app = _p.FirstOrDefault();
            if (_app != null) CurrentPluginInfos.Remove(_app);
        }

        public string[] GetAllPluginNames()
        {
            config = (PluginConfigurationSection)ConfigurationManager.GetSection("PluginSection");
            PluginConfigurationElement pe = new PluginConfigurationElement();
            ArrayList ps = new ArrayList();
            for (Int32 i = 0; i < config.PluginCollection.Count; i++)
            {
                pe = config.PluginCollection[i];
                ps.Add(pe.Name);
            }
            return (String[])ps.ToArray(typeof(String));
        }

        public bool Contains(string pluginName)
        {
            config = (PluginConfigurationSection)ConfigurationManager.GetSection("PluginSection");
            PluginConfigurationElement pe = new PluginConfigurationElement();
            List<String> ps = new List<string>();
            for (Int32 i = 0; i < config.PluginCollection.Count; i++)
            {
                pe = config.PluginCollection[i];
                ps.Add(pe.Name);
            }
            return ps.Contains(pluginName);
        }

        public bool LoadPlugin(string pluginName)
        {
            string AssemblyFile;
            Boolean result = false;
            config = (PluginConfigurationSection)ConfigurationManager.GetSection("PluginSection");
            PluginConfigurationElement pe = new PluginConfigurationElement();

            String path = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "";
            try
            {
                for (Int32 i = 0; i < config.PluginCollection.Count; i++)
                {
                    pe = config.PluginCollection[i];
                    if (pe.Name == pluginName)
                    {
                        if (pe.Version == "")
                        {
                            AssemblyFile = path + "\\" + pe.Assembly;
                        }
                        else
                        {
                            AssemblyFile = path + "\\Plugin\\" + pe.Version + "\\" + pe.Assembly;
                            if (!File.Exists(AssemblyFile))
                            {
                                AssemblyFile = path + "\\" + pe.Assembly;
                            }
                        }

                        Assembly assembly = Assembly.LoadFile(AssemblyFile);
                        Type type = assembly.GetType(pe.Type);
                        IServerPlugin instance = (IServerPlugin)Activator.CreateInstance(type);
                        instance.ServerApplication = application;
                        instance.Load();
                        plugins[pluginName] = instance;
                        result = true;

                        AppPluginInfo _apinfo = new AppPluginInfo();
                        _apinfo.Descript = pe.Description;
                        _apinfo.PluginType = pe.Type;
                        _apinfo.Name = pe.Name;
                        _apinfo.FileName = pe.Assembly;
                        _apinfo.AssemblyVersion = assembly.GetName().Version.ToString();
                        CurrentPluginInfos.Add(_apinfo);
                        break;
                    }
                }
                if (!result)
                {
                    application.WriteMessage(string.Format("未找到插件{0}!", pluginName), EventLogEntryType.Error);
                }
            }
            catch (Exception e)
            {
                application.WriteMessage(string.Format("出现错误:{0}", e.Message), EventLogEntryType.Error);
                result = false;
            }
            return result;
        }

        public bool UnLoadPlugin(string pluginName)
        {
            Boolean result = false;
            try
            {
                IServerPlugin plugin = GetPluginInstance(pluginName);
                plugin.UnLoad();
                result = true;
            }
            catch (Exception e)
            {
                application.WriteMessage(string.Format("出现错误:{0}", e.Message), EventLogEntryType.Error);
            }
            return result;
        }

        public IServerPlugin GetPluginInstance(string pluginName)
        {
            IServerPlugin plugin = null;
            if (plugins.ContainsKey(pluginName))
            {
                plugin = plugins[pluginName];
            }
            return plugin;
        }

        public void LoadAllPlugin()
        {
            application.WriteMessage("开始加载插件!", EventLogEntryType.Information);
            CurrentPluginInfos = new List<AppPluginInfo>();
            PluginConfigurationElement pe = new PluginConfigurationElement();
            config = (PluginConfigurationSection)ConfigurationManager.GetSection("PluginSection");
            if (config == null)
            {
                application.WriteMessage("未配置插件文件!", EventLogEntryType.Error);
                return;
            }
            String path = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "";
            try
            {
                for (Int32 i = 0; i < config.PluginCollection.Count; i++)
                {
                    pe = config.PluginCollection[i];
                    if (File.Exists(path + "\\" + pe.Assembly))
                    {
                        Assembly assembly = Assembly.LoadFile(path + "\\" + pe.Assembly);

                        Type type = assembly.GetType(pe.Type);
                        IServerPlugin instance = (IServerPlugin)Activator.CreateInstance(type);
                        instance.ServerApplication = application;
                        instance.Load();
                        plugins[pe.Name] = instance;

                        AppPluginInfo _apinfo = new AppPluginInfo();
                        _apinfo.Descript = pe.Description;
                        _apinfo.PluginType = pe.Type;
                        _apinfo.Name = pe.Name;
                        _apinfo.FileName = pe.Assembly;
                        _apinfo.AssemblyVersion = assembly.GetName().Version.ToString();
                        CurrentPluginInfos.Add(_apinfo);
                    }
                    else
                    {
                        application.WriteMessage(string.Format("服务器端插件文件{0}不存在!", pe.Assembly), EventLogEntryType.Error);
                    }
                }
            }
            catch (Exception e)
            {
                application.WriteMessage(string.Format("出现错误:{0}", e.Message), EventLogEntryType.Error);
            }
            application.WriteMessage("加载插件结束...", EventLogEntryType.Information);
        }



        public static AppPluginInfo GetDescrip(string _fileName)
        {
            var _a = from _c in PluginDescriptList
                     where _c.FileName == _fileName
                     select _c;
            return _a.FirstOrDefault();

        }
        #endregion

        public static string RemovePlugin(AppPluginInfo _api)
        {
            try
            {
                CurrentService.UnLoadPlugin(_api.Name);
                CurrentService.RemovePlugin(_api.Name);
                return "TRUE";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string LoadAppPlugin(AppPluginInfo _api)
        {
            try
            {
                CurrentService.AddPlugin(_api.Name, _api.PluginType, _api.FileName, _api.Descript, _api.AssemblyVersion);
                CurrentService.LoadPlugin(_api.Name);
                return "TRUE";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string GetPluginInfoString()
        {
            var jser = new JavaScriptSerializer();
            //序列化
            string _retstr = jser.Serialize(CurrentPluginInfos);
            return _retstr;
        }





        public void LoadPluginDescript()
        {
            string FileName = Utils.ExeDir + "PluginInfo.txt";
            if (!File.Exists(FileName))
            {
                string _js = SerializeHelper.JsonSerialize<List<AppPluginInfo>>(ServerPluginService.CurrentPluginInfos);
                File.WriteAllText(FileName, _js);
            }

            string _data = File.ReadAllText(FileName);
            PluginDescriptList = SerializeHelper.JsonDeserialize<List<AppPluginInfo>>(_data);
        }


        public static void AddPluginDescript(AppPluginInfo PluginInfo)
        {
            var _a = from _c in PluginDescriptList
                     where _c.FileName == PluginInfo.FileName
                     select _c;
            if (_a.Count() > 0) return;
            PluginDescriptList.Add(PluginInfo);
            string FileName = Utils.ExeDir + "PluginInfo.txt";
            string _js = SerializeHelper.JsonSerialize<List<AppPluginInfo>>(ServerPluginService.CurrentPluginInfos);
            File.WriteAllText(FileName, _js);
        }
    }

}
