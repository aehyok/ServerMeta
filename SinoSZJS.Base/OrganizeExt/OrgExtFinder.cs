using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.OrganizeExt
{
        public class OrgExtFinder
        {
                 string FindStr = "";
                public OrgExtFinder(string _findStr)
                {
                        this.FindStr = _findStr;
                }

                public bool FindByID(OrgExtInfo _org)
                {
                        return ((string)_org.GetValue("ZZJGID")) == FindStr;
                }



                public bool FindByFatherID(OrgExtInfo _org)
                {
                        return ((string)_org.GetValue("SJDWID")) == FindStr;
                }
        }
}
