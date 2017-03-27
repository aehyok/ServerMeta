using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SinoSZJS.CS.BizUser;


namespace SinoSZJS.WCF.Lib
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“UserManagerService”。
    public class UserManagerService : IUserManagerService
    {
        public string GetTRDUserInfo(string _logonName, string dwid)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.GetTRDUserInfo(_logonName, dwid);
        }

        public List<Base.User.UserBaseInfo> GetUserListInOrg(decimal _orgid, decimal _levelNum)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.GetUserListInOrg(_orgid, _levelNum);
        }

        public List<Base.User.UserMappingInfo> GetUserListMapping(decimal _orgid, decimal _levelNum)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.GetUserListMapping(_orgid, _levelNum);
        }

        public List<Base.User.UserExtInfo> GetUserMobileList(decimal _orgid, decimal _LevelNum)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.GetUserMobileList(_orgid, _LevelNum);
        }

        public List<Base.User.PersonBaseInfo> GetPersionListInOrg(decimal _orgid, decimal _levelNum)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.GetPersionListInOrg(_orgid, _levelNum);
        }

        public bool RegisterUser(Base.User.PersonBaseInfo _personBaseInfo)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.RegisterUser(_personBaseInfo);
        }

        public List<Base.Authorize.SinoRole> GetRoleList()
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.GetRoleList();
        }

        public bool AddNewRole(Base.Authorize.SinoRole _newRole)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.AddNewRole(_newRole);
        }

        public List<Base.User.UserRightInfo> GetRightListByRoleID(string _roleID)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.GetRightListByRoleID(_roleID);
        }

        public List<Base.User.UserQueryModelInfo> GetModelRightListByRoleID(string _roleID)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.GetModelRightListByRoleID(_roleID);
        }

        public bool SaveRightsOfRole(Base.Authorize.SinoRole _role, List<Base.User.UserRightInfo> _functionRights, List<Base.User.UserQueryModelInfo> _modelRights)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.SaveRightsOfRole(_role, _functionRights, _modelRights);
        }

        public bool DeleteRole(Base.Authorize.SinoRole _role)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.DeleteRole(_role);
        }

        public List<Base.Authorize.SinoPost> GetPostListInOrg(Base.Authorize.SinoOrganize CurrentOrg)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.GetPostListInOrg(CurrentOrg);
        }

        public bool AddPostOfOrg(string _postName, string _postDescript, int _PostLevel, decimal _orgID)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.AddPostOfOrg(_postName, _postDescript, _PostLevel, _orgID);
        }

        public bool DelPostOfOrg(string _postID)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.DelPostOfOrg(_postID);
        }

        public bool ModifyPostOfOrg(string _postName, string _postDescript, int _PostLevel, string _postID)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.ModifyPostOfOrg(_postName, _postDescript, _PostLevel, _postID);
        }

        public List<Base.Authorize.SinoRole> GetRoleOfPost(string _postID)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.GetRoleOfPost(_postID);
        }

        public bool SaveRolesOfPost(List<Base.Authorize.SinoRole> _roleList, string _postID)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.SaveRolesOfPost(_roleList, _postID);
        }

        public bool PastePostToOrg(List<Base.Authorize.SinoPost> _clipPad, Base.Authorize.SinoOrganize _org)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.PastePostToOrg(_clipPad, _org);
        }

        public List<Base.User.UserRightInfo> GetRightListByPostID(string _postID)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.GetRightListByPostID(_postID);
        }

        public List<Base.User.UserQueryModelInfo> GetModelRightListByPostID(string _postID)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.GetModelRightListByPostID(_postID);
        }

        public List<Base.User.UserPostInfo> GetPostListByUserID(string _userID)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.GetPostListByUserID(_userID);
        }

        public bool IsExistUserPost(string _userID, string _postID)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.IsExistUserPost(_userID, _postID);
        }

        public bool AddUserPost(string _userID, string _postID)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.AddUserPost(_userID, _postID);
        }

        public bool UnRegisterUser(string _userID)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.UnRegisterUser(_userID);
        }

        public bool DeleteUserPost(string _userID, string _postID)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.DeleteUserPost(_userID, _postID);
        }

        public bool SetDefaultUserPost(string _userID, string _postID)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.SetDefaultUserPost(_userID, _postID);
        }

        public List<Base.User.UserBaseInfo> GetUsersOfPost(string _postID)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.GetUsersOfPost(_postID);
        }

        public bool DeleteUserOfPost(string _postID, string _userID)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.DeleteUserOfPost(_postID, _userID);
        }

        public bool IsExistYHM(string _yhm)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.IsExistYHM(_yhm);
        }

        public bool AddUserInfo(string YHM, string XM, string XB, string SFZH, decimal SSDW, string DWGUID, string HGGH, string JH, string ZWMC, string ZWJB, string EMAIL)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.AddUserInfo(YHM, XM, XB, SFZH, SSDW, DWGUID, HGGH, JH, ZWMC, ZWJB, EMAIL);
        }

        public string GetDWGUID(decimal DWID)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.GetDWGUID(DWID);
        }

        public bool AddNewOrg(string ShotName, string FullName, Base.Authorize.SinoOrganize FatherOrg)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.AddNewOrg(ShotName, FullName, FatherOrg);
        }

        public bool DelOrg(Base.Authorize.SinoOrganize sinoOrganize)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.DelOrg(sinoOrganize);
        }

        public bool IsExistChildOrg(decimal DWID)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.IsExistChildOrg(DWID);
        }

        public bool SaveUserExtInfo(string LogonName, string Mobile, string Email)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.SaveUserExtInfo(LogonName, Mobile, Email);
        }

        public bool SaveUserMapping(string TRD_YHID, string JSYW_YHID, string TRD_YHM, string TRD_XM, string JSYW_XM)
        {
            OraUserManagerFactroy _of = new OraUserManagerFactroy();
            return _of.SaveUserMapping(TRD_YHID, JSYW_YHID, TRD_YHM, TRD_XM, JSYW_XM);
        }

        public bool HeartBeat()
        {
            return true;
        }
    }
}
