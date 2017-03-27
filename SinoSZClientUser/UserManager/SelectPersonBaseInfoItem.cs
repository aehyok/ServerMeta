using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.User;


namespace SinoSZClientUser.UserManager
{
        public class SelectPersonBaseInfoItem
        {
                private PersonBaseInfo personInfo;
                private bool selected = false;
                public SelectPersonBaseInfoItem(PersonBaseInfo info)
                {
                        personInfo = info;
                }

                public bool Selected
                {
                        get { return selected; }
                        set { selected = value; }
                }

                public PersonBaseInfo PersonInfo
                {
                        get { return personInfo; }
                        set { personInfo = value; }
                }

                public string UserID
                {
                        get { return personInfo.UserID; }
                        set { personInfo.UserID = value; }
                }
                public string LoginName
                {
                        get { return personInfo.LoginName; }
                        set { personInfo.LoginName = value; }
                }
                public string Name
                {
                        get { return personInfo.Name; }
                        set { personInfo.Name = value; }
                }

                public string OrgShortName
                {
                        get { return personInfo.OrgShortName; }
                        set { personInfo.OrgShortName = value; }
                }

                public string HeadShip
                {
                        get { return personInfo.HeadShip; }
                        set { personInfo.HeadShip = value; }
                }

        }
}
