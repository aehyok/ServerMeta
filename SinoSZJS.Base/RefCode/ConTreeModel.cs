using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSZJS.Base.RefCode;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.RefCode
{
    /// <summary>
    /// add by  lqm
    /// </summary>
    public class ConTreeModel
    {
        /// <summary>
        /// 下拉菜单Name
        /// </summary>
        [DataMember]
        public string DropDownEditName { set; get;}

        /// <summary>
        /// 下拉菜单的默认值Value
        /// </summary>
        [DataMember]
        public string DefaultValue { set; get; }

        /// <summary>
        /// 下拉菜单下拉后树的Name
        /// </summary>
        [DataMember]
        public string TreeViewName { set; get; }

        /// <summary>
        /// 代码表的表名Name
        /// </summary>
        [DataMember]
        public string RefCodeName { set; get; }

        /// <summary>
        /// 下载模式 true为一次性全部下载  false为分级下载
        /// </summary>
        [DataMember]
        public bool DownloadMode { set; get; }
        /// <summary>
        /// 是否允许多选
        /// </summary>
        [DataMember]
        public RefCodeMulti RefMulti { set; get; }

        /// <summary>
        /// 弹窗的Name
        /// </summary>
        [DataMember]
        public string PopWinName { set; get; }

        /// <summary>
        /// TreeView列表
        /// </summary>
        [DataMember]
        public List<RefCodeData> RefCodeList{set;get;}


        /// <summary>
        /// 设置代码表下拉是否为空
        /// </summary>
        [DataMember]
        public bool DropDownReadOnly { get; set; }

        public ConTreeModel(){}

        public ConTreeModel(string dropDownEditName,string defaultValue,string treeViewName, string refCodeName, RefCodeMulti refMulti,string popWinName, List<RefCodeData> refCodeList)
        {
            this.DropDownEditName = dropDownEditName;
            this.DefaultValue = defaultValue;
            this.TreeViewName = treeViewName;
            this.RefCodeName = refCodeName;
            this.RefMulti = refMulti;
            this.PopWinName = popWinName;
            this.RefCodeList = refCodeList;
        }
    }
}
