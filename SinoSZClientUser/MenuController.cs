using System;
using System.Collections.Generic;
using System.Text;
using SinoSZPluginFramework;
using SinoSZClientUser.RoleManager;
using SinoSZClientUser.PostManager;
using SinoSZJS.Base.Misc;
using SinoSZClientUser.MobileNumber;
using SinoSZPluginFramework.ClientPlugin;
using SinoSZClientUser.UserMapping;

namespace SinoSZClientUser
{
	/// <summary>
	/// 菜单控制类
	/// </summary>
	public class MenuController
	{
		static public bool DoCommand(string _menuID, string _commandName, string _commandTitle, string _param, IApplication _application)
		{
			string _title;
			switch (_commandName)
			{
				case "RoleManager":  //角色管理
					frmRoleDefine _rdf = new frmRoleDefine(_param);
					_application.AddForm("角色管理", _rdf);
					break;

				case "PostManager": //岗位管理
					frmPostDefine _pdf = new frmPostDefine();
					_application.AddForm("岗位管理", _pdf);
					break;

				case "UserManager": //用户管理
					string _canAdd = StrUtils.GetMetaByName2("可添加", _param);
					frmUserDefine _f = new frmUserDefine(_commandTitle, _canAdd);
					_application.AddForm("用户管理", _f);
					break;
				case "UserMobileManager": //用户手机管理
					_title = StrUtils.GetMetaByName2("标题", _param);
					frmUserMobile _frmUserMobile = MenuFunctions.AddPage<frmUserMobile>(_title, _application);
					if (_frmUserMobile != null)
					{
						_frmUserMobile.Init(_title, "企业涉案", _param);
					}
					break;
                case "UserMappingCUPAA": //三统一用户映射
                    _title = StrUtils.GetMetaByName2("标题", _param);
                    frmUserMapping_CUPAA _f_UM_CUPAA = MenuFunctions.AddPage<frmUserMapping_CUPAA>(_title, _application);
                    if (_f_UM_CUPAA != null)
                    {
                        _f_UM_CUPAA.Init(_title, "三统一用户映射", _param);
                    }
                    break;
			}
			return true;
		}
	}
}
