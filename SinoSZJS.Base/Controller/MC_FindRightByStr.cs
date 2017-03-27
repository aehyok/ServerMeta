using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.MetaData.Define;

namespace SinoSZJS.Base.Controller
{
        public class MC_FindRightByStr
        {
                string FindStr = "";
                public MC_FindRightByStr(string _findStr)
                {
                        this.FindStr = _findStr;
                }

                public bool FindByID(MD_RightDefine _right)
                {
                        return _right.RightID == FindStr;
                }

                public bool FindByFatherID(MD_RightDefine _right)
                {
                        return _right.FatherRightID == FindStr;
                }
        }
}
