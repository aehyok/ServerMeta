using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSystemWatch.Base.Application
{
    public class ApplicationStatus
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string AppType { get; set; }
        public int AppStauts { get; set; }
        public string AppError { get; set; }
    }
}
