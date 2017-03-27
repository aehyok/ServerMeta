using System;
using System.Data;
using SinoSZJS.Base.Misc;

namespace SinoSZJS.Base.Authorize
{
    /// <summary>
    /// RightFunctions 的摘要说明。
    /// 本类用于处理所有的关于权限相关的内容
    /// </summary>
    public class RightFunctions
    {
        public RightFunctions()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 用一条数据库的记录来建立用户权限项
        /// </summary>
        /// <param name="_dr"></param>
        /// <returns></returns>
        public static UserRightItem CreateUserRightItem(DataRow _dr)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //	
            UserRightItem _ur = new UserRightItem();
            _ur.Right = RightFunctions.CreateSinoRightItem(_dr);
            _ur.Level = _dr.IsNull("QXJB") ? 0 : (decimal)_dr["QXJB"];
            return _ur;
        }

        /// <summary>
        /// 用一条数据库的记录来建立角色
        /// </summary>
        /// <param name="_dr"></param>
        /// <returns></returns>
        public static SinoRole CreateRoleItem(DataRow _dr)
        {
            SinoRole _sr = new SinoRole();
            _sr.RoleID = _dr["JSID"].ToString();
            _sr.RoleName = _dr["JSMC"].ToString();
            _sr.Descript = _dr["JSSM"].ToString();
            _sr.RoleDwid = _dr.IsNull("SSDWID") ? "" : _dr["SSDWID"].ToString();
            return _sr;
        }

        public static SinoRole CreateRoleItem(string _jsid, string _jsmc, string _jssm, string _ssdwid)
        {
            SinoRole _sr = new SinoRole();
            _sr.RoleID = _jsid;
            _sr.RoleName = _jsmc;
            _sr.Descript = _jssm;
            _sr.RoleDwid = _ssdwid;
            return _sr;

        }
        /// <summary>
        /// 通过一条记录来建立CS界面用的角色
        /// </summary>
        /// <param name="_dr"></param>
        /// <returns></returns>
        public static CSSinoRole CreateCsRoleItem(DataRow _dr)
        {
            CSSinoRole _sr = new CSSinoRole();
            _sr.RoleID = _dr["JSID"].ToString();
            _sr.RoleName = _dr["JSMC"].ToString();
            _sr.Descript = _dr["JSSM"].ToString();
            _sr.RoleDwid = _dr.IsNull("SSDWID") ? "" : _dr["SSDWID"].ToString();
            return _sr;
        }

        /// <summary>
        /// 将角色项转换为界面角色类
        /// </summary>
        /// <param name="_role"></param>
        /// <returns></returns>
        public static CSSinoRole SinoRole2CsRole(SinoRole _role)
        {
            CSSinoRole _sr = new CSSinoRole();
            _sr.RoleID = _role.RoleID;
            _sr.RoleName = _role.RoleName;
            _sr.Descript = _role.Descript;
            _sr.RoleDwid = _role.RoleDwid;
            return _sr;
        }

        /// <summary>
        /// 通过记录建立用户权限定义项
        /// </summary>
        /// <param name="_dr"></param>
        /// <returns></returns>
        public static SinoRightItem CreateSinoRightItem(DataRow _dr)
        {
            SinoRightItem _sri = new SinoRightItem();
            try
            {
                _sri.RightID = _dr["QXID"].ToString();
                _sri.FatherRightID = _dr["SJQXID"].ToString();
                _sri.RightName = _dr["QXMC"].ToString();
                _sri.RightDescript = _dr["QXMS"].ToString();
                _sri.RightType = _dr["QXLX"].ToString();
                ParseRightLevels(ref _sri, _dr["QXMETA"].ToString());
            }
            catch (Exception e)
            {
                throw e;
            }
            return _sri;
        }

        /// <summary>
        /// 拆解权限的分级元数据
        /// </summary>
        /// <param name="_sri"></param>
        /// <param name="_meta"></param>
        private static void ParseRightLevels(ref SinoRightItem _sri, string _meta)
        {
            if (_sri.RightLevels == null) _sri.RightLevels = new System.Collections.ArrayList();
            else _sri.RightLevels.Clear();
            string _values = StrUtils.GetMetaByName("VALUE", _meta);
            if (_values == "") return;
            string[] _Levels = _values.Split(',');

            foreach (string _le in _Levels)
            {
                string[] _items = _le.Split(':');
                RightLevelName _rln = new RightLevelName();
                _rln.Index = decimal.Parse(_items[0]);
                _rln.DisplayText = _items[1];
                _sri.RightLevels.Add(_rln);
            }
        }
    }
}
