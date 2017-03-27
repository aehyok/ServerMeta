using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.Authorize;

namespace SinoSZJS.Base.Authorize
{
        public class FindOrgByStr
        {
                string FindStr = "";
                public FindOrgByStr(string _findStr)
                {
                        this.FindStr = _findStr;
                }

                public bool FindByID(SinoOrganize _org)
                {
                        return _org.Code.ToString() == FindStr;
                }

                public bool FindByDWDM(SinoOrganize _org)
                {
                        return _org.DWDM == FindStr;
                }

                public bool FindByFatherID(SinoOrganize _org)
                {
                        return _org.FatherCode.ToString() == FindStr;
                }

        }
}
