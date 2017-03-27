using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSystemWatch.Base.SystemCheck
{
    public class HardDiskPartition
    {
        public string PartitionName { get; set; }
        public double FreeSpace { get; set; }
        public double SumSpace { get; set; }
        public bool IsPrimary { get; set; }
    }
}
