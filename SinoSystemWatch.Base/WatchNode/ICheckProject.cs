using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSystemWatch.Base.WatchNode
{
    public interface ICheckProject
    {
        int Check(ref string result);
    }
}
