using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.PluginFramework;

namespace SinoSystemWatch.Base.Common
{
    public class UpLoadFileInfo
    {
        public string FileName { get; set; }
        public string SavePath { get; set; }
        public byte[] FileData { get; set; }
        public AppPluginInfo PluginInfo { get; set; }
    }
}
