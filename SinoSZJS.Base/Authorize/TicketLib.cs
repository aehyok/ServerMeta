using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.Authorize;

namespace SinoSZJS.Base.Authorize
{
    public class TicketLib
    {
        public static Dictionary<string, SinoSZTicketInfo> _tickets = new Dictionary<string, SinoSZTicketInfo>();
        public static SinoSZTicketInfo GetTicketInfo(string ticket)
        {
            if (_tickets.ContainsKey(ticket))
            {
                SinoSZTicketInfo _cacheinfo = _tickets[ticket];
                return _cacheinfo;
            }
            else
            {
                return null;
            }
        }
        public static bool CheckUserTicket(SinoSZTicketInfo _tinfo)
        {
            string _uTicket = _tinfo.Ticket;
            if (_tickets.ContainsKey(_uTicket))
            {
                SinoSZTicketInfo _cacheinfo = _tickets[_uTicket];
                if (_cacheinfo.YHID == _tinfo.YHID && _cacheinfo.Address == _tinfo.Address)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static string AddTicket(string _yhid, string _uaddr)
        {
            string _ticket = Guid.NewGuid().ToString();
            AddTicket(_yhid, _uaddr, _ticket);
            return _ticket;
        }

        public static void AddTicket(string _yhid, string _uaddr, string _ticket)
        {
            SinoSZTicketInfo _uinfo = new SinoSZTicketInfo(_yhid, _uaddr, _ticket);
            if (_tickets.ContainsKey(_ticket))
            {
                _tickets[_ticket] = _uinfo;
            }
            else
            {
                _tickets.Add(_ticket, _uinfo);
            }
        }

        public static void Clear()
        {
            _tickets.Clear();
        }

        public static bool Check(string ticket)
        {
            bool _ret = _tickets.ContainsKey(ticket);
            return _ret;
        }
    }
}
