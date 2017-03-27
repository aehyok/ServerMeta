using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.User.Comparer
{
        public class UserRightInfoComparer : IComparer<UserRightInfo>
        {
                public int Compare(UserRightInfo x, UserRightInfo y)
                {
                        return x.DisplayOrder - y.DisplayOrder;

                }

        }
}
