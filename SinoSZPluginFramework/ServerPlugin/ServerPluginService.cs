using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Reflection;
using System.ServiceModel;

namespace SinoSZPluginFramework.ServerPlugin
{
    public class ServerPluginService : IServerPluginService
    {
        private IServerApplication application = null;
        private PluginConfigurationSection config = null;
        private Dictionary<String, IServerPlugin> plugins = new Dictionary<string, IServerPlugin>();
        private XmlDocument doc = new XmlDocument();

        public ServerPluginService()
        {
        }

        public ServerPluginService(IServerApplication _app)
        {
            application = _app;
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

        public void AddPlugin(string pluginName, string pluginType, string Assembly, string pluginDescription)
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
                        Assembly assembly = Assembly.LoadFile(path + "\\" + pe.Assembly);
                        Type type = assembly.GetType(pe.Type);
                        IServerPlugin instance = (IServerPlugin)Activator.CreateInstance(type);
                        instance.ServerApplication = application;
                        instance.Load();
                        plugins[pluginName] = instance;
                        result = true;
                        break;
                    }
                }
                if (!result)
                {
                    application.WriteMessage(string.Format("未找到插件{0}!", pluginName));
                }
            }
            catch (Exception e)
            {
                application.WriteMessage(string.Format("出现错误:{0}", e.Message));
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
                application.WriteMessage(string.Format("出现错误:{0}", e.Message));
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

        public void LoadAllWCFService(Dictionary<string, ServiceHost> hostlib)
        {
            foreach (string _key in hostlib.Keys)
            {
                ServiceHost host = hostlib[_key];
                if (host != null && host.State != CommunicationState.Opened)
                {
                    try
                    {
                        host.Open();
                        application.WriteMessage(string.Format("启动WCF服务[{0}]成功!", _key));
                    }
                    catch (Exception ex)
                    {
                        application.WriteMessage(string.Format("启动WCF服务[{0}]失败!错误信息：{1}", _key, ex.Message));
                    }
                }
                else
                {
                    application.WriteMessage(string.Format("启动WCF服务[{0}]失败!当前的状态不正确", host.State));
                }

            }
        }
        public void LoadAllPlugin()
        {
            PluginConfigurationElement pe = new PluginConfigurationElement();
            config = (PluginConfigurationSection)ConfigurationManager.GetSection("PluginSection");
            if (config == null)
            {
                application.WriteMessage("未配置插件文件!");
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
                    }
                    else
                    {
                        application.WriteMessage(string.Format("服务器端插件文件{0}不存在!", pe.Assembly));
                    }
                }
            }
            catch (Exception e)
            {
                application.WriteMessage(string.Format("出现错误:{0}", e.Message));
            }
        }

        #endregion


    }
}
