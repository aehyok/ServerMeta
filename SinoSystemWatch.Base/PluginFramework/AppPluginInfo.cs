using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSystemWatch.Base.PluginFramework
{
    public class AppPluginInfo
    {
        public string Name { get; set; }
        public string AssemblyVersion { get; set; }
        public string FileName { get; set; }
        public string PluginType { get; set; }
        public string Descript { get; set; }
    }
}
