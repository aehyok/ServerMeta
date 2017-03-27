using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SinoSZJS.Base.Authorize;
using SinoSZJS.Base.User;

namespace SinoSZJS.WCF.Lib
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IUserManagerService”。
    [ServiceContract]
    public interface IUserManagerService
    {
        [OperationContract]
        bool HeartBeat();

        [OperationContract]
        bool SaveUserMapping(string TRD_YHID, string JSYW_YHID, string TRD_YHM, string TRD_XM, string JSYW_XM);

        [OperationContract]
        string GetTRDUserInfo(string _logonName, string dwid);

        [OperationContract]
        List<UserMappingInfo> GetUserListMapping(decimal _orgid, decimal _levelNum);

        [OperationContract]
        List<UserBaseInfo> GetUserListInOrg(decimal _orgid, decimal _levelNum);
        /// <summary>
        /// 取指定组织机构下的用户的手机号码
        /// </summary>
        /// <param name="_orgid"></param>
        /// <param name="_LevelNum"></param>
        /// <returns></returns>
        [OperationContract]
        List<UserExtInfo> GetUserMobileList(decimal _orgid, decimal _LevelNum);

        /// <summary>
        /// 取指定组织机构下的人员列表
        /// </summary>
        /// <param name="_orgid"></param>
        /// <param name="ShowChildren"></param>
        /// <returns></returns>
        [OperationContract]
        List<PersonBaseInfo> GetPersionListInOrg(decimal _orgid, decimal _levelNum);
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="PersonBaseInfo"></param>
        /// <returns></returns>
        [OperationContract]
        bool RegisterUser(PersonBaseInfo _personBaseInfo);
        /// <summary>
        /// 取角色列表
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<SinoRole> GetRoleList();

        /// <summary>
        /// 添加新角色
        /// </summary>
        /// <param name="_newRole"></param>
        /// <returns></returns>
        [OperationContract]
        bool AddNewRole(SinoRole _newRole);

        /// <summary>
        /// 取角色的功能授权情况
        /// </summary>
        /// <param name="_roleID"></param>
        /// <returns></returns>
        [OperationContract]
        List<UserRightInfo> GetRightListByRoleID(string _roleID);
        /// <summary>
        /// 取查询模型的授权情况
        /// </summary>
        /// <param name="_roleID"></param>
        /// <returns></returns>
        [OperationContract]
        List<UserQueryModelInfo> GetModelRightListByRoleID(string _roleID);
        /// <summary>
        /// 保存角色的授权信息
        /// </summary>
        /// <param name="_role"></param>
        /// <param name="_functionRights"></param>
        /// <param name="_modelRights"></param>
        /// <returns></returns>
        [OperationContract]
        bool SaveRightsOfRole(SinoRole _role, List<UserRightInfo> _functionRights, List<UserQueryModelInfo> _modelRights);

        /// <summary>
        /// 删除角色定义
        /// </summary>
        /// <param name="_role"></param>
        /// <returns></returns>
        [OperationContract]
        bool DeleteRole(SinoRole _role);

        /// <summary>
        /// 取指定组织机构下的所有岗位
        /// </summary>
        /// <param name="CurrentOrg"></param>
        /// <returns></returns>
        [OperationContract]
        List<SinoPost> GetPostListInOrg(SinoOrganize CurrentOrg);
        /// <summary>
        /// 在指定的组织机构下建立岗位
        /// </summary>
        /// <param name="_postName"></param>
        /// <param name="_postDescript"></param>
        /// <param name="_PostLevel"></param>
        /// <param name="_orgID"></param>
        [OperationContract]
        bool AddPostOfOrg(string _postName, string _postDescript, int _PostLevel, decimal _orgID);

        /// <summary>
        /// 删除指定的岗位
        /// </summary>
        /// <param name="_postID"></param>
        /// <returns></returns>
        [OperationContract]
        bool DelPostOfOrg(string _postID);
        /// <summary>
        /// 修改岗位信息
        /// </summary>
        /// <param name="_postName"></param>
        /// <param name="_postDescript"></param>
        /// <param name="_PostLevel"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        [OperationContract]
        bool ModifyPostOfOrg(string _postName, string _postDescript, int _PostLevel, string _postID);
        /// <summary>
        /// 取岗位的角色
        /// </summary>
        /// <param name="_postID"></param>
        /// <returns></returns>
        [OperationContract]
        List<SinoRole> GetRoleOfPost(string _postID);
        /// <summary>
        /// 保存岗位的角色定义
        /// </summary>
        /// <param name="_roleList"></param>
        /// <param name="_postID"></param>
        /// <returns></returns>
        [OperationContract]
        bool SaveRolesOfPost(List<SinoRole> _roleList, string _postID);
        /// <summary>
        /// 粘贴岗位定义
        /// </summary>
        /// <param name="ClipPad"></param>
        /// <param name="sinoOrganize"></param>
        /// <returns></returns>
        [OperationContract]
        bool PastePostToOrg(List<SinoPost> _clipPad, SinoOrganize _org);
        /// <summary>
        /// 岗位授权的情况列表
        /// </summary>
        /// <param name="_postID"></param>
        /// <returns></returns>
        [OperationContract]
        List<UserRightInfo> GetRightListByPostID(string _postID);
        /// <summary>
        /// 取岗位的查询模型授权情况
        /// </summary>
        /// <param name="_postID"></param>
        /// <returns></returns>
        [OperationContract]
        List<UserQueryModelInfo> GetModelRightListByPostID(string _postID);
        /// <summary>
        /// 通过用户ID取用户的岗位列表
        /// </summary>
        /// <param name="_userID"></param>
        /// <returns></returns>
        [OperationContract]
        List<UserPostInfo> GetPostListByUserID(string _userID);
        /// <summary>
        /// 判断用户是否具有岗位
        /// </summary>
        /// <param name="_userID"></param>
        /// <param name="_postID"></param>
        /// <returns></returns>
        [OperationContract]
        bool IsExistUserPost(string _userID, string _postID);
        /// <summary>
        /// 添加用户岗位
        /// </summary>
        /// <param name="_userID"></param>
        /// <param name="_postID"></param>
        /// <returns></returns>
        [OperationContract]
        bool AddUserPost(string _userID, string _postID);

        /// <summary>
        /// 删除注册用户
        /// </summary>
        /// <param name="_userID"></param>
        /// <returns></returns>
        [OperationContract]
        bool UnRegisterUser(string _userID);

        /// <summary>
        /// 删除用户岗位
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        /// <returns></returns>
        [OperationContract]
        bool DeleteUserPost(string _userID, string _postID);
        /// <summary>
        /// 设置为用户的默认岗位
        /// </summary>
        /// <param name="_userID"></param>
        /// <param name="_postID"></param>
        /// <returns></returns>
        [OperationContract]
        bool SetDefaultUserPost(string _userID, string _postID);

        /// <summary>
        /// 取指定岗位下的用户列表
        /// </summary>
        /// <param name="_postID"></param>
        /// <returns></returns>
        [OperationContract]
        List<UserBaseInfo> GetUsersOfPost(string _postID);

        /// <summary>
        /// 删除岗位下的用户
        /// </summary>
        /// <param name="_postID"></param>
        /// <param name="_userID"></param>
        /// <returns></returns>
        [OperationContract]
        bool DeleteUserOfPost(string _postID, string _userID);

        /// <summary>
        /// 判断是否存在此用户名
        /// </summary>
        /// <param name="_yhm"></param>
        /// <returns></returns>
        [OperationContract]
        bool IsExistYHM(string _yhm);
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="YHM"></param>
        /// <param name="XM"></param>
        /// <param name="XB"></param>
        /// <param name="SFZH"></param>
        /// <param name="SSDW"></param>
        /// <param name="DWGUID"></param>
        /// <param name="HGGH"></param>
        /// <param name="JH"></param>
        /// <param name="ZWMC"></param>
        /// <param name="ZWJB"></param>
        /// <param name="EMAIL"></param>
        /// <returns></returns>
        [OperationContract]
        bool AddUserInfo(string YHM, string XM, string XB, string SFZH, decimal SSDW, string DWGUID, string HGGH, string JH, string ZWMC, string ZWJB, string EMAIL);
        /// <summary>
        /// 取单位GUID
        /// </summary>
        /// <param name="DWID"></param>
        /// <returns></returns>
        [OperationContract]
        string GetDWGUID(decimal DWID);
        /// <summary>
        /// 添加新组织机构
        /// </summary>
        /// <param name="ShotName"></param>
        /// <param name="FullName"></param>
        /// <param name="FatherOrg"></param>
        /// <returns></returns>
        [OperationContract]
        bool AddNewOrg(string ShotName, string FullName, SinoOrganize FatherOrg);
        /// <summary>
        /// 删除组织机构
        /// </summary>
        /// <param name="sinoOrganize"></param>
        /// <returns></returns>
        [OperationContract]
        bool DelOrg(SinoOrganize sinoOrganize);
        /// <summary>
        /// 判断是否存在子机构
        /// </summary>
        /// <param name="DWID"></param>
        /// <returns></returns>
        [OperationContract]
        bool IsExistChildOrg(decimal DWID);
        /// <summary>
        /// 保存用户扩展信息
        /// </summary>
        /// <param name="LogonName"></param>
        /// <param name="Mobile"></param>
        /// <param name="Email"></param>
        /// <returns></returns>
        [OperationContract]
        bool SaveUserExtInfo(string LogonName, string Mobile, string Email);
    }
}
