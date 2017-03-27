using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.User
{
    [DataContract]
    public class UserMappingInfo : UserBaseInfo
    {
        public UserMappingInfo(string _userid, string _loginName, string _personid, string _orgid, string _orgFullName, string _orgShortName, string _userName, string _sex, string _customsNo, string _policeNo, string _email, string _headShip, string _level, string _limit, string _secret, string _userType)
            :
            base(_userid, _loginName, _personid, _orgid, _orgFullName, _orgShortName, _userName, _sex, _customsNo, _policeNo, _email, _headShip, _level, _limit, _secret, _userType)
        {
        }

        [DataMember]
        public string TRD_YHID { get; set; }
        [DataMember]
        public string TRD_XM { get; set; }
        [DataMember]
        public string TRD_LoginName { get; set; }
    }
}
