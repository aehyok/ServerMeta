using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSZJS.Base.Document
{
    public class Attachment
    {
        public string ID { set; get; }
        public string FileName { set; get; }
        public string FileType { set; get; }
        public byte[] FileContent { set; get; }
        public decimal FileSize { set; get; }
    }
}
