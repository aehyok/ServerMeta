using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSZJS.Base.Authorize
{
    public class ConOrgTreeModel
    {
        /// <summary>
        /// 下拉菜单Name
        /// </summary>
        public string DropDownEditName { set; get; }

        /// <summary>
        /// 下拉菜单的默认值Value
        /// </summary>
        public string DefaultValue { set; get; }
        /// <summary>
        /// 组织结构根ID
        /// </summary>
        public decimal RootID { set; get; }

        /// <summary>
        /// 下拉菜单下拉后树的Name
        /// </summary>
        public string TreeViewName { set; get; }

        /// <summary>
        /// 是否特殊处理
        /// </summary>
        public string Type { set; get; }
        /// <summary>
        /// 组织机构列表
        /// </summary>
        public List<SinoOrganize> OrgList { set; get; }

        public ConOrgTreeModel() { }

        public ConOrgTreeModel(string dropDownEditName,string defaultValue,decimal rootID, string treeViewName,string type, List<SinoOrganize> orgList)
        {
            this.DropDownEditName = dropDownEditName;
            this.DefaultValue = defaultValue;
            this.RootID = rootID;
            this.TreeViewName = treeViewName;
            this.Type = type;
            this.OrgList = orgList;
        }
    }
}
