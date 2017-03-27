using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.MenuType;
using System.Linq;

namespace SinoSZJS.CS.BizMenu.DAL
{
    [Serializable]
    public class SinoSZMenuLib
    {
        private static Dictionary<string, SinoMenuItem> menuDict = null;
        private static List<SinoMenuItem> rootCsMenuList = null;
        private static List<SinoMenuItem> rootBsMenuList = null;
        private static List<SinoMenuItem> rootSLMenuList = null;
        private static Dictionary<string, List<SinoMenuItem>> childMenuDict = null;

        #region 公开属性
        /// <summary>
        /// 菜单字典
        /// </summary>
        public static Dictionary<string, SinoMenuItem> MenuDict
        {
            get
            {
                if (menuDict == null)
                {
                    InitMenuDict();
                }
                return menuDict;
            }
        }

        /// <summary>
        /// CS根菜单列表
        /// </summary>
        public static List<SinoMenuItem> RootCsMenuList
        {
            get
            {
                if (rootCsMenuList == null) InitMenuDict();
                return rootCsMenuList;
            }
        }

        /// <summary>
        /// BS根菜单列表
        /// </summary>
        public static List<SinoMenuItem> RootBsMenuList
        {
            get
            {
                if (rootBsMenuList == null) InitMenuDict();
                return rootBsMenuList;
            }
        }

        /// <summary>
        /// SilverLight根菜单列表
        /// </summary>
        public static List<SinoMenuItem> RootSLMenuList
        {
            get
            {
                if (rootSLMenuList == null) InitMenuDict();
                return rootSLMenuList;
            }
        }

        /// <summary>
        /// 子菜单对照表
        /// </summary>
        public static Dictionary<string, List<SinoMenuItem>> ChildMenuDict
        {
            get
            {
                if (childMenuDict == null) InitMenuDict();
                return childMenuDict;
            }
        }
        #endregion

        /// <summary>
        /// 菜单定义初始化
        /// </summary>
        public static void InitMenuDict()
        {
            menuDict = new Dictionary<string, SinoMenuItem>();
            rootCsMenuList = new List<SinoMenuItem>();
            rootSLMenuList = new List<SinoMenuItem>();
            rootBsMenuList = new List<SinoMenuItem>();
            childMenuDict = new Dictionary<string, List<SinoMenuItem>>();

            OraMenuFactory _of = new OraMenuFactory();
            List<SinoMenuItem> _menuList = _of.GetAllMenus("0");
            foreach (SinoMenuItem _mitem in _menuList)
            {
                string _mid = _mitem.MenuID;
                menuDict.Add(_mid, _mitem);
            }

            if (_menuList != null)
            {
                var _TopLevelMenuList = from _c in _menuList
                                        where _c.FatherID == "0"
                                        orderby _c.DisplayOrder
                                        select _c;

                foreach (SinoMenuItem _smi in _TopLevelMenuList)
                {
                    if (_smi.MenuType.Length > 3 && _smi.MenuType.Substring(0, 3) == "WEB")
                    {
                        rootBsMenuList.Add(_smi);
                    }
                    else if (_smi.MenuType.Length > 3 && _smi.MenuType.Substring(0, 3) == "SL_")
                    {
                        rootSLMenuList.Add(_smi);
                    }
                    else
                    {
                        rootCsMenuList.Add(_smi);
                    }

                    GetChildMenu(_menuList, _smi);
                }
            }
        }

        /// <summary>
        /// 取子菜单
        /// </summary>
        /// <param name="_menuList"></param>
        /// <param name="_fatherItem"></param>
        private static void GetChildMenu(List<SinoMenuItem> _menuList, SinoMenuItem _fatherItem)
        {
            var _subMenuList = from _c in _menuList
                               where _c.FatherID == _fatherItem.MenuID
                               orderby _c.DisplayOrder
                               select _c;

            if (childMenuDict.ContainsKey(_fatherItem.MenuID))
            {
                childMenuDict[_fatherItem.MenuID] = _subMenuList.ToList<SinoMenuItem>();
            }
            else
            {
                childMenuDict.Add(_fatherItem.MenuID, _subMenuList.ToList<SinoMenuItem>());
            }

            foreach (SinoMenuItem _smi in _subMenuList)
            {
                GetChildMenu(_menuList, _smi);
            }

        }
    }
}
