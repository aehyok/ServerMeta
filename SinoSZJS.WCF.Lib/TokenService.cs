using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SinoSZJS.WCF.Lib
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“TokenService”。
    public class TokenService : ITokenService
    {
        public byte[] GetCurrentUser(string TokenTicket)
        {
            return null;
        }


        public bool CheckTicket(string TokenTicket)
        {
            return true;
        }


        public bool InsertToken(string TokenTicket, byte[] AddUser)
        {
            return true;
        }

        public bool HeartBeat()
        {
            return true;
        }
    }
}
