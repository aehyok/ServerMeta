using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZClientBase.PortalItem
{
        [Serializable]
        public class PortalItemDefine
        {
                private string name = "";
                private string plugInName = "";
                private string title = "";
                private string param = "";

                public PortalItemDefine() { }
                public PortalItemDefine(string _cs)
                {
                        string[] _strs = _cs.Split(':');
                        this.title = _strs[0];

                        string[] _pl = _strs[1].Split('.');
                        this.name = (_pl.Length > 1) ? _pl[1] : "";
                        this.plugInName = _pl[0];

                        this.param = _cs;
                }
                public string Name
                {
                        get { return name; }
                        set { name = value; }
                }

                public string PluginName
                {
                        get { return plugInName; }
                        set { plugInName = value; }
                }

                public string Title
                {
                        get { return title; }
                        set { title = value; }
                }

                public string Param
                {
                        get { return param; }
                        set { param = value; }
                }

        }
}
