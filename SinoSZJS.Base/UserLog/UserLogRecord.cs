using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.UserLog
{
        public class UserLogRecord
        {
                private string id = "";
                private string userid = "";               
                private string userName = "";
                private string czlx = "";
                private string cznr = "";
                private string ipAddr = "";
                private string userHost = "";
                private DateTime czsj = DateTime.Now;
                private int resultType = 0;
                private string resultTypeName = "";
                private string loginName = "";

                public UserLogRecord() { }
                public UserLogRecord(string _id, string _userid, string _userName, string _czlx, string _cznr, string _ip, string _host, DateTime _czsj,int _resultType,string _loginName)
                {
                        id = _id;
                        userid = _userid;
                        userName = _userName;
                        czlx = _czlx;
                        cznr = _cznr;
                        ipAddr = _ip;
                        userHost = _host;
                        czsj = _czsj;
                        resultType = _resultType;
                        loginName = _loginName;
                        switch (resultType)
                        {                             
                                case 1:
                                        resultTypeName = "成功";
                                        break;
                                case 2:
                                        resultTypeName = "失败";
                                        break;
                                default:
                                        resultTypeName = "未知";
                                        break;
                        }

                }

                public string LoginName
                {
                        get { return loginName; }
                        set { loginName = value; }
                }

                public string ResultTypeName
                {
                        get { return resultTypeName; }
                        set { resultTypeName = value; }
                }

                public int ResultType
                {
                        get { return resultType; }
                        set { resultType = value; }
                }

                public DateTime CZSJ
                {
                        get { return czsj; }
                        set { czsj = value; }
                }

                public string UserHost
                {
                        get { return userHost; }
                        set { userHost = value; }
                }
                public string IpAddress
                {
                        get { return ipAddr; }
                        set { ipAddr = value; }
                }

                public string CZNR
                {
                        get { return cznr; }
                        set { cznr = value; }
                }

                public string CZLX
                {
                        get { return czlx; }
                        set { czlx = value; }
                }


                public string ID
                {
                        get { return id; }
                        set { id = value; }
                }

                public string UserID
                {
                        get { return userid; }
                        set { userid = value; }
                }
                public string UserName
                {
                        get { return userName; }
                        set { userName = value; }
                }


        }
}
