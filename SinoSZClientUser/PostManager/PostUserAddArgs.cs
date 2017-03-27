using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.User;

namespace SinoSZClientUser.PostManager
{
        public class PostUserAddArgs : EventArgs
        {
                private UserBaseInfo userInfo = null;

                public UserBaseInfo User
                {
                        get { return userInfo; }
                        set { userInfo = value; }
                }

                public PostUserAddArgs(UserBaseInfo _user)
                {
                        userInfo = _user;
                }
        }
}
