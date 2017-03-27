using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.Misc;
using System.Configuration;
using System.Reflection;
using SinoSZJS.Base.Authorize;
using SinoSZJS.Base.UserLog;
using SinoSZJS.Base.User;

namespace SinoSZJS.CS.BizUser
{
    public class BIZ_UserManager :  IUserManager
    {
        private static IUserManager _iUserManagerFactroy;
        public static IUserManager UserManagerFactroy
        {
            get
            {
                if (_iUserManagerFactroy == null)
                {
                    _iUserManagerFactroy = GetDataConfig();
                }
                return _iUserManagerFactroy;
            }

            set
            {
                _iUserManagerFactroy = value;
            }
        }

        private static IUserManager GetDataConfig()
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of as IUserManager;
        }

        #region IUserManager Members

        public List<UserBaseInfo> GetUserListInOrg(decimal _orgid, decimal _levelNum)
        {
            return UserManagerFactroy.GetUserListInOrg(_orgid, _levelNum);
        }



        public List<PersonBaseInfo> GetPersionListInOrg(decimal _orgid, decimal _levelNum)
        {
            return UserManagerFactroy.GetPersionListInOrg(_orgid, _levelNum);
        }

        public bool RegisterUser(PersonBaseInfo _personBaseInfo)
        {
            try
            {
                bool _ret = UserManagerFactroy.RegisterUser(_personBaseInfo);
                if (_ret)
                {
                    UserLogWriter.WriteLogByDefaultUser("注册用户", string.Format("注册用户{0}(姓名:{1})成功!", _personBaseInfo.LoginName, _personBaseInfo.Name), 1);
                }
                else
                {
                    UserLogWriter.WriteLogByDefaultUser("注册用户", string.Format("注册用户{0}失败!失败原因:未知", _personBaseInfo.LoginName), 2);
                }
                return _ret;
            }
            catch (Exception e)
            {
                UserLogWriter.WriteLogByDefaultUser("注册用户",
                    string.Format("注册用户{1}失败!失败原因:{0}", _personBaseInfo.LoginName, e.Message), 2);
                return false;
            }


        }


        public List<SinoRole> GetRoleList()
        {
            return UserManagerFactroy.GetRoleList();
        }


        public bool AddNewRole(SinoRole _newRole)
        {
            return UserManagerFactroy.AddNewRole(_newRole);
        }


        public List<UserRightInfo> GetRightListByRoleID(string _roleID)
        {
            return UserManagerFactroy.GetRightListByRoleID(_roleID);
        }


        public List<UserQueryModelInfo> GetModelRightListByRoleID(string _roleID)
        {
            return UserManagerFactroy.GetModelRightListByRoleID(_roleID);
        }

        public bool SaveRightsOfRole(SinoRole _role, List<UserRightInfo> _functionRights, List<UserQueryModelInfo> _modelRights)
        {
            return UserManagerFactroy.SaveRightsOfRole(_role, _functionRights, _modelRights);
        }


        public bool DeleteRole(SinoRole _role)
        {
            return UserManagerFactroy.DeleteRole(_role);
        }


        public List<SinoPost> GetPostListInOrg(SinoOrganize CurrentOrg)
        {
            return UserManagerFactroy.GetPostListInOrg(CurrentOrg);
        }



        public bool AddPostOfOrg(string _postName, string _postDescript, int _PostLevel, decimal _orgID)
        {
            return UserManagerFactroy.AddPostOfOrg(_postName, _postDescript, _PostLevel, _orgID);
        }



        public bool DelPostOfOrg(string _postID)
        {
            return UserManagerFactroy.DelPostOfOrg(_postID);
        }




        public bool ModifyPostOfOrg(string _postName, string _postDescript, int _PostLevel, string _postID)
        {
            return UserManagerFactroy.ModifyPostOfOrg(_postName, _postDescript, _PostLevel, _postID);
        }



        public List<SinoRole> GetRoleOfPost(string _postID)
        {
            return UserManagerFactroy.GetRoleOfPost(_postID);
        }



        public bool SaveRolesOfPost(List<SinoRole> _roleList, string _postID)
        {
            return UserManagerFactroy.SaveRolesOfPost(_roleList, _postID);
        }



        public bool PastePostToOrg(List<SinoPost> _clipPad, SinoOrganize _org)
        {
            return UserManagerFactroy.PastePostToOrg(_clipPad, _org);
        }



        public List<UserRightInfo> GetRightListByPostID(string _postID)
        {
            return UserManagerFactroy.GetRightListByPostID(_postID);
        }

        public List<UserQueryModelInfo> GetModelRightListByPostID(string _postID)
        {
            return UserManagerFactroy.GetModelRightListByPostID(_postID);
        }

        public List<UserPostInfo> GetPostListByUserID(string _userID)
        {
            return UserManagerFactroy.GetPostListByUserID(_userID);
        }



        public bool IsExistUserPost(string _userID, string _postID)
        {
            return UserManagerFactroy.IsExistUserPost(_userID, _postID);
        }

        public bool AddUserPost(string _userID, string _postID)
        {
            return UserManagerFactroy.AddUserPost(_userID, _postID);
        }


        public bool UnRegisterUser(string _userID)
        {
            return UserManagerFactroy.UnRegisterUser(_userID);
        }



        public bool DeleteUserPost(string _userID, string _postID)
        {
            return UserManagerFactroy.DeleteUserPost(_userID, _postID);
        }

        public bool SetDefaultUserPost(string _userID, string _postID)
        {
            return UserManagerFactroy.SetDefaultUserPost(_userID, _postID);
        }


        public List<UserBaseInfo> GetUsersOfPost(string _postID)
        {
            return UserManagerFactroy.GetUsersOfPost(_postID);
        }


        public bool DeleteUserOfPost(string _postID, string _userID)
        {
            return UserManagerFactroy.DeleteUserOfPost(_postID, _userID);
        }



        public bool IsExistYHM(string _yhm)
        {
            return UserManagerFactroy.IsExistYHM(_yhm);
        }



        public bool AddUserInfo(string YHM, string XM, string XB, string SFZH, decimal SSDW, string DWGUID, string HGGH, string JH, string ZWMC, string ZWJB, string EMAIL)
        {
            return UserManagerFactroy.AddUserInfo(YHM, XM, XB, SFZH, SSDW, DWGUID, HGGH, JH, ZWMC, ZWJB, EMAIL);
        }

        public string GetDWGUID(decimal DWID)
        {
            return UserManagerFactroy.GetDWGUID(DWID);
        }

        public bool AddNewOrg(string ShotName, string FullName, SinoOrganize FatherOrg)
        {
            return UserManagerFactroy.AddNewOrg(ShotName, FullName, FatherOrg);
        }


        public bool DelOrg(SinoOrganize sinoOrganize)
        {
            return UserManagerFactroy.DelOrg(sinoOrganize);
        }


        public bool IsExistChildOrg(decimal DWID)
        {
            return UserManagerFactroy.IsExistChildOrg(DWID);
        }



        public List<UserExtInfo> GetUserMobileList(decimal _orgid, decimal _LevelNum)
        {
            return UserManagerFactroy.GetUserMobileList(_orgid, _LevelNum);
        }




        public bool SaveUserExtInfo(string LogonName, string Mobile, string Email)
        {
            return UserManagerFactroy.SaveUserExtInfo(LogonName, Mobile, Email);
        }

        #endregion
    }
}
