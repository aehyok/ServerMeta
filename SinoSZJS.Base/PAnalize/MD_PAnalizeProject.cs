using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.PAnalize
{
        public class MD_PAnalizeProject
        {
                private string id;
                private string displayTitle;
                private string description;
                private string paType;
                private string userID;
                private string userName;
                private DateTime createDate;
                private int displayOrder;

                public string ID
                {
                        get { return id; }
                        set { id = value; }
                }

                public string DisplayTitle { get { return displayTitle; } set { displayTitle = value; } }
                public string Description { get { return description; } set { description = value; } }
                public string PAType { get { return paType; } set { paType = value; } }
                public string CreateUserID { get { return userID; } set { userID = value; } }
                public string CreateUserName { get { return userName; } set { userName = value; } }
                public DateTime CreateDate { get { return createDate; } set { createDate = value; } }
                public int DisplayOrder { get { return displayOrder; } set { displayOrder = value; } }

                public MD_PAnalizeProject(string _id, string _title, string _descript, string _type, string _userid, string _username, DateTime _createDate, int _order)
                {
                        ID = _id;
                        DisplayTitle = _title;
                        Description = _descript;
                        PAType = _type;
                        CreateUserID = _userid;
                        CreateUserName = _username;
                        CreateDate = _createDate;
                        DisplayOrder = _order;
                }

                public override string ToString()
                {
                        return DisplayTitle;
                }

        }
}
