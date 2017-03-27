using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.Authorize;
using System.Data;

namespace SinoSZJS.Base.User
{
	/// <summary>
	/// 用户及授权管理接口定义
	/// </summary>
	public interface IUserManager
	{
		/// <summary>
		/// 取指定组织机构下的用户列表
		/// </summary>
		/// <param name="_orgid">组织机构ID</param>
		/// <param name="_levelNum">包含下级单位的层级数</param>
		/// <returns></returns>
		List<UserBaseInfo> GetUserListInOrg(decimal _orgid, decimal _levelNum);

		/// <summary>
		/// 取指定组织机构下的用户的手机号码
		/// </summary>
		/// <param name="_orgid"></param>
		/// <param name="_LevelNum"></param>
		/// <returns></returns>
		List<UserExtInfo> GetUserMobileList(decimal _orgid, decimal _LevelNum);

		/// <summary>
		/// 取指定组织机构下的人员列表
		/// </summary>
		/// <param name="_orgid"></param>
		/// <param name="ShowChildren"></param>
		/// <returns></returns>
		List<PersonBaseInfo> GetPersionListInOrg(decimal _orgid, decimal _levelNum);
		/// <summary>
		/// 注册用户
		/// </summary>
		/// <param name="PersonBaseInfo"></param>
		/// <returns></returns>
		bool RegisterUser(PersonBaseInfo _personBaseInfo);
		/// <summary>
		/// 取角色列表
		/// </summary>
		/// <returns></returns>
		List<SinoRole> GetRoleList();

		/// <summary>
		/// 添加新角色
		/// </summary>
		/// <param name="_newRole"></param>
		/// <returns></returns>
		bool AddNewRole(SinoRole _newRole);

		/// <summary>
		/// 取角色的功能授权情况
		/// </summary>
		/// <param name="_roleID"></param>
		/// <returns></returns>
		List<UserRightInfo> GetRightListByRoleID(string _roleID);
		/// <summary>
		/// 取查询模型的授权情况
		/// </summary>
		/// <param name="_roleID"></param>
		/// <returns></returns>
		List<UserQueryModelInfo> GetModelRightListByRoleID(string _roleID);
		/// <summary>
		/// 保存角色的授权信息
		/// </summary>
		/// <param name="_role"></param>
		/// <param name="_functionRights"></param>
		/// <param name="_modelRights"></param>
		/// <returns></returns>
		bool SaveRightsOfRole(SinoRole _role, List<UserRightInfo> _functionRights, List<UserQueryModelInfo> _modelRights);

		/// <summary>
		/// 删除角色定义
		/// </summary>
		/// <param name="_role"></param>
		/// <returns></returns>
		bool DeleteRole(SinoRole _role);

		/// <summary>
		/// 取指定组织机构下的所有岗位
		/// </summary>
		/// <param name="CurrentOrg"></param>
		/// <returns></returns>
		List<SinoPost> GetPostListInOrg(SinoOrganize CurrentOrg);
		/// <summary>
		/// 在指定的组织机构下建立岗位
		/// </summary>
		/// <param name="_postName"></param>
		/// <param name="_postDescript"></param>
		/// <param name="_PostLevel"></param>
		/// <param name="_orgID"></param>
		bool AddPostOfOrg(string _postName, string _postDescript, int _PostLevel, decimal _orgID);

		/// <summary>
		/// 删除指定的岗位
		/// </summary>
		/// <param name="_postID"></param>
		/// <returns></returns>
		bool DelPostOfOrg(string _postID);
		/// <summary>
		/// 修改岗位信息
		/// </summary>
		/// <param name="_postName"></param>
		/// <param name="_postDescript"></param>
		/// <param name="_PostLevel"></param>
		/// <param name="p"></param>
		/// <returns></returns>
		bool ModifyPostOfOrg(string _postName, string _postDescript, int _PostLevel, string _postID);
		/// <summary>
		/// 取岗位的角色
		/// </summary>
		/// <param name="_postID"></param>
		/// <returns></returns>
		List<SinoRole> GetRoleOfPost(string _postID);
		/// <summary>
		/// 保存岗位的角色定义
		/// </summary>
		/// <param name="_roleList"></param>
		/// <param name="_postID"></param>
		/// <returns></returns>
		bool SaveRolesOfPost(List<SinoRole> _roleList, string _postID);
		/// <summary>
		/// 粘贴岗位定义
		/// </summary>
		/// <param name="ClipPad"></param>
		/// <param name="sinoOrganize"></param>
		/// <returns></returns>
		bool PastePostToOrg(List<SinoPost> _clipPad, SinoOrganize _org);
		/// <summary>
		/// 岗位授权的情况列表
		/// </summary>
		/// <param name="_postID"></param>
		/// <returns></returns>
		List<UserRightInfo> GetRightListByPostID(string _postID);
		/// <summary>
		/// 取岗位的查询模型授权情况
		/// </summary>
		/// <param name="_postID"></param>
		/// <returns></returns>
		List<UserQueryModelInfo> GetModelRightListByPostID(string _postID);
		/// <summary>
		/// 通过用户ID取用户的岗位列表
		/// </summary>
		/// <param name="_userID"></param>
		/// <returns></returns>
		List<UserPostInfo> GetPostListByUserID(string _userID);
		/// <summary>
		/// 判断用户是否具有岗位
		/// </summary>
		/// <param name="_userID"></param>
		/// <param name="_postID"></param>
		/// <returns></returns>
		bool IsExistUserPost(string _userID, string _postID);
		/// <summary>
		/// 添加用户岗位
		/// </summary>
		/// <param name="_userID"></param>
		/// <param name="_postID"></param>
		/// <returns></returns>
		bool AddUserPost(string _userID, string _postID);

		/// <summary>
		/// 删除注册用户
		/// </summary>
		/// <param name="_userID"></param>
		/// <returns></returns>
		bool UnRegisterUser(string _userID);

		/// <summary>
		/// 删除用户岗位
		/// </summary>
		/// <param name="p"></param>
		/// <param name="p_2"></param>
		/// <returns></returns>
		bool DeleteUserPost(string _userID, string _postID);
		/// <summary>
		/// 设置为用户的默认岗位
		/// </summary>
		/// <param name="_userID"></param>
		/// <param name="_postID"></param>
		/// <returns></returns>
		bool SetDefaultUserPost(string _userID, string _postID);

		/// <summary>
		/// 取指定岗位下的用户列表
		/// </summary>
		/// <param name="_postID"></param>
		/// <returns></returns>
		List<UserBaseInfo> GetUsersOfPost(string _postID);

		/// <summary>
		/// 删除岗位下的用户
		/// </summary>
		/// <param name="_postID"></param>
		/// <param name="_userID"></param>
		/// <returns></returns>
		bool DeleteUserOfPost(string _postID, string _userID);



		bool IsExistYHM(string _yhm);

		bool AddUserInfo(string YHM, string XM, string XB, string SFZH, decimal SSDW, string DWGUID, string HGGH, string JH, string ZWMC, string ZWJB, string EMAIL);

		string GetDWGUID(decimal DWID);

		bool AddNewOrg(string ShotName, string FullName, SinoOrganize FatherOrg);

		bool DelOrg(SinoOrganize sinoOrganize);

		bool IsExistChildOrg(decimal DWID);

		bool SaveUserExtInfo(string LogonName, string Mobile, string Email);
	}
}
