﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SinoSystemWatch.Base.Application
{
   public class CheckWCFServiceConfigurationCollection : ConfigurationElementCollection
    {
       public CheckWCFServiceConfigurationCollection()
        {
        }

        protected override void
           BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        public void Remove(CheckWCFServiceConfigurationElement pluginElement)
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

        public void Add(CheckWCFServiceConfigurationElement pluginElement)
        {
            BaseAdd(pluginElement);
        }

        public int IndexOf(CheckWCFServiceConfigurationElement pluginElement)
        {
            return BaseIndexOf(pluginElement);
        }

        new public CheckWCFServiceConfigurationElement this[string Name]
        {
            get
            {
                return (CheckWCFServiceConfigurationElement)BaseGet(Name);
            }
        }

        public CheckWCFServiceConfigurationElement this[int index]
        {
            get
            {
                return (CheckWCFServiceConfigurationElement)BaseGet(index);
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
            return ((CheckWCFServiceConfigurationElement)element).Name;
        }

        protected override
            ConfigurationElement CreateNewElement()
        {
            return new CheckWCFServiceConfigurationElement();
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
