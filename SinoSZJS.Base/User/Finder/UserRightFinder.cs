using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.User.Finder
{
        public class UserRightFinder
        {
                 string FindStr = "";
                public UserRightFinder(string _findStr)
                {
                        this.FindStr = _findStr;
                }

                public bool FindByID(UserRightInfo _right)
                {
                        return _right.RightID == FindStr;
                }

                public bool FindByFatherID(UserRightInfo _right)
                {
                        return _right.FatherRightID == FindStr;
                }
        }
}
