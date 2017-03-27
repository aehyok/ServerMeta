using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZPluginFramework.ClientPlugin
{
        [Serializable]
        public class MenuRightItem
        {
                public int Index = 1;
                public string Title = "";

                public MenuRightItem(int _index, string _title)
                {
                        Index = _index;
                        Title = _title;
                }
        }
}
