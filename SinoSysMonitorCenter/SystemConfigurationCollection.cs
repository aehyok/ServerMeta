using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace SinoSysMonitorCenter
{
    public class SystemConfigurationCollection : ConfigurationElementCollection
    {
        public SystemConfigurationCollection()
        {
        }

        protected override void
           BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        public void Remove(SystemConfigurationElement pluginElement)
        {
            if (BaseIndexOf(pluginElement) >= 0)
                BaseRemove(pluginElement.Name);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void Clear()
        {
            BaseClear();
        }

        public void Add(SystemConfigurationElement pluginElement)
        {
            BaseAdd(pluginElement);
        }

        public int IndexOf(SystemConfigurationElement pluginElement)
        {
            return BaseIndexOf(pluginElement);
        }

        new public SystemConfigurationElement this[string Name]
        {
            get
            {
                return (SystemConfigurationElement)BaseGet(Name);
            }
        }

        public SystemConfigurationElement this[int index]
        {
            get
            {
                return (SystemConfigurationElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public new int Count
        {

            get
            {
                return base.Count;
            }

        }

        public new string RemoveElementName
        {
            get
            {
                return base.RemoveElementName;
            }

        }

        public new string ClearElementName
        {
            get
            {
                return base.ClearElementName;
            }

            set
            {
                base.AddElementName = value;
            }

        }

        public new string AddElementName
        {
            get
            {
                return base.AddElementName;
            }

            set
            {
                base.AddElementName = value;
            }

        }

        protected override Object
            GetElementKey(ConfigurationElement element)
        {
            return ((SystemConfigurationElement)element).Name;
        }

        protected override
            ConfigurationElement CreateNewElement()
        {
            return new SystemConfigurationElement();
        }

        public override
            ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return
                    ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }
    }

}
