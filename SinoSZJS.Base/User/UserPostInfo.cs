using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.Authorize;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.User
{
    /// <summary>
    /// 用户岗位信息
    /// </summary>
    /// 
    [DataContract(IsReference = true)]
    public class UserPostInfo
    {
        [DataMember]
        public SinoPost UserPost { get; set; }

        public UserPostInfo(SinoPost _post)
        {
            UserPost = _post;
        }

        public string PostID
        {
            get { return UserPost.PostID; }
            set { UserPost.PostID = value; }
        }

        public string PostName
        {
            get { return UserPost.PostName; }
            set { UserPost.PostName = value; }
        }

        public string OrgName
        {
            get { return UserPost.PostDWMC; }
            set { UserPost.PostDWMC = value; }
        }

        public bool IsDefault
        {
            get { return UserPost.IsDefaultPost; }
            set { UserPost.IsDefaultPost = value; }
        }

        public SinoPost Post
        {
            get { return UserPost; }
            set { UserPost = value; }
        }


    }
}
