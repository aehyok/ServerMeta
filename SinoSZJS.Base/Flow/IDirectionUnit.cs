using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSZJS.Base.Authorize;

namespace SinoSZJS.Base.Flow
{
    public interface IDirectionUnit
    {
        Dictionary<string, string> GetDirectionUnit(string actionID, string bzid,SinoRequestUser user);
    }
}
