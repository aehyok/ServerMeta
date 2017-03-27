using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.Authorize
{
        public class LogonUserLib
        {
                public static Dictionary<string, SinoUser> _users = new Dictionary<string, SinoUser>();

                public static SinoUser GetUserInfo(string _yhid)
                {
                    return _users[_yhid];
                }

                public static bool AddUserInfo(string _yhid,SinoUser _su)
                {
                    if (_users.ContainsKey(_yhid))
                        {
                                //如果用户已经登录
                            _users[_yhid] = _su;
                        }
                        else
                        {
                            _users.Add(_yhid, _su);
                        }

                        return true;
                        
                }

                public static bool RemoveUserInfo(string _yhid)
                {
                    if (_users.ContainsKey(_yhid))
                        {
                            _users.Remove(_yhid);
                        }

                        return true;
                }

        }
}
