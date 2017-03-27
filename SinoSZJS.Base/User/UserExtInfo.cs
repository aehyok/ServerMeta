using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.User
{
    [DataContract]
    public class UserExtInfo
    {

        public UserExtInfo() { }
        public UserExtInfo(string _id, string _logonname, string _username, string _mobile, string _email)
        {
            UserID = _id;
            LogonName = _logonname;
            UserName = _username;
            Mobile = _mobile;
            EMAIL = _email;
        }
        [DataMember]
        public string UserID { get; set; }
        [DataMember]
        public string LogonName { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string EMAIL { get; set; }


    }
}
