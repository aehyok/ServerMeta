using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSZJS.Base.Authorize;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SinoSZJS.Base.Token
{
    public class TokenController
    {
        static public bool CheckTicket(string _ticket)
        {
            using (TokenService.TokenServiceClient _tsc = new TokenService.TokenServiceClient())
            {
                bool _ret = _tsc.CheckTicket(_ticket);
                return _ret;
            }

        }

        static public bool InsertTicket(string _ticket, SinoUser _su)
        {
            using (TokenService.TokenServiceClient _tsc = new TokenService.TokenServiceClient())
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new MemoryStream();
                formatter.Serialize(stream, _su);
                stream.Seek(0, SeekOrigin.Begin);
                byte[] blob = new byte[stream.Length];
                stream.Read(blob, 0, blob.Length);
                stream.Close();

                bool _ret = _tsc.InsertToken(_ticket, blob);
                return _ret;
            }

        }

        static public SinoUser GetCurrentUser(string _ticket)
        {
            using (TokenService.TokenServiceClient _tsc = new TokenService.TokenServiceClient())
            {
                byte[] _subytes = _tsc.GetCurrentUser(_ticket);
                Stream _str = new MemoryStream(_subytes);
                IFormatter formatter = new BinaryFormatter();
                SinoUser _ret = (SinoUser)formatter.Deserialize(_str);
                return _ret;
            }
        }


    }
}
