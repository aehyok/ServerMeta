using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Messaging;

namespace SinoSZJS.Base.Authorize
{
        public class SinoSZTicketInfo: ILogicalThreadAffinative
        {
                string _ticket = "";
                string _yhid = "";
                string _addr = "";

                public string Ticket
                {
                        get { return _ticket; }
                        set { _ticket = value;}
                }

                public string YHID
                {
                    get { return _yhid; }
                    set { _yhid = value; }
                }

                public string Address
                {
                        get { return _addr; }
                        set { _addr = value; }
                }

                public SinoSZTicketInfo()
                {
                }

                public SinoSZTicketInfo(string _userid, string _uaddr, string _uticket)
                {
                        _yhid = _userid;
                        _addr = _uaddr;
                        _ticket = _uticket;
                }
        }
}
