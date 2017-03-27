using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSZJS.Base.WCF.Service;

namespace SinoSZJS.Base.Authorize
{
    public class WCFUserCTX : IUserInfoCTX
    {
        public SinoUser GetCurrentUser()
        {
            string ticket = ServiceInterpector.GetCurrentTicket();
            SinoSZTicketInfo _info = TicketLib.GetTicketInfo(ticket);
            if (_info == null) return null;
            string _yhid = _info.YHID;
            SinoUser _su = LogonUserLib.GetUserInfo(_yhid);
            string postid = ServiceInterpector.GetCurrentPost();
            if (postid != _su.CurrentPost.PostID)
            {
                var _ps = from _c in _su.Posts
                          where _c.PostID == postid
                          select _c;
                if (_ps.Count() > 0)
                {
                    _su.CurrentPost = _ps.First();

                }
            }
            return _su;
        }
    }
}
