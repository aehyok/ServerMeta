using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SinoSystemWatch.Base.WinServiceCheck
{
    public class CheckWinServiceConfigurationCollection : ConfigurationElementCollection
    {
         public CheckWinServiceConfigurationCollection()
        {
        }

        protected override void
           BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        public void Remove(CheckWinServiceConfigurationElement pluginElement)
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

        public void Add(CheckWinServiceConfigurationElement pluginElement)
        {
            BaseAdd(pluginElement);
        }

        public int IndexOf(CheckWinServiceConfigurationElement pluginElement)
        {
            return BaseIndexOf(pluginElement);
        }

        new public CheckWinServiceConfigurationElement this[string Name]
        {
            get
            {
                return (CheckWinServiceConfigurationElement)BaseGet(Name);
            }
        }

        public CheckWinServiceConfigurationElement this[int index]
        {
            get
            {
                return (CheckWinServiceConfigurationElement)BaseGet(index);
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
            return ((CheckWinServiceConfigurationElement)element).Name;
        }

        protected override
            ConfigurationElement CreateNewElement()
        {
            return new CheckWinServiceConfigurationElement();
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
