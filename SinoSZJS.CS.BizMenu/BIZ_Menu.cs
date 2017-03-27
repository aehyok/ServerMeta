using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Messaging;
using System.Configuration;
using System.Reflection;
using SinoSZJS.Base.MenuType;
using SinoSZJS.CS.BizMenu.DAL;
using SinoSZJS.Base.Authorize;

namespace SinoSZJS.CS.BizMenu
{
    public class BIZ_Menu : MarshalByRefObject, ISinoMenu
    {

        private static ISinoMenu _iMenu = null;

        public static ISinoMenu MenuFactory
        {
            get
            {
                if (_iMenu == null)
                {
                    _iMenu = GetMenuConfig();
                }
                return _iMenu;
            }
        }


        private static ISinoMenu GetMenuConfig()
        {
            OraMenuFactory _of = new OraMenuFactory();
            return _of as ISinoMenu;
        }


        #region ISinoMenu Members

        public List<SinoMenuItem> GetAllMenus(string _postID)
        {

            SinoSZTicketInfo _currentUserInfo = CallContext.GetData("UserIdentity") as SinoSZTicketInfo;
            string _yhid = _currentUserInfo.YHID;
            SinoUser _userinfo = LogonUserLib.GetUserInfo(_yhid);
            bool _find = false;
            foreach (SinoPost _sp in _userinfo.Posts)
            {
                if (_sp.PostID == _postID)
                {
                    _find = true;
                    break;
                }
            }

            if (_find)
            {
                return MenuFactory.GetAllMenus(_postID);
            }
            else
            {
                throw new Exception("用户不具有此岗位授权!");
            }
            return null;
        }


        public List<firstPageItem> GetfirstPage()
        {
            return MenuFactory.GetfirstPage();
        }



        #endregion
    }
}
