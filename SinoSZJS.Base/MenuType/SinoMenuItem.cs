using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MenuType
{
    /// <summary>
    /// 菜单项定义
    /// </summary>
    [DataContract]
    public class SinoMenuItem
    {

        /// <summary>
        /// 菜单ID
        /// </summary>
        [DataMember]
        public string MenuID { get; set; }
        /// <summary>
        /// 菜单显示标题
        /// </summary>
        [DataMember]
        public string MenuTitle { get; set; }

        /// <summary>
        /// 菜单显示顺序
        /// </summary>
        [DataMember]
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 父菜单ID
        /// </summary>
        [DataMember]
        public string FatherID { get; set; }


        /// <summary>
        /// 菜单图标
        /// </summary>
        [DataMember]
        public string IconName { get; set; }

        /// <summary>
        /// 菜单类型
        /// </summary>
        [DataMember]
        public string MenuType { get; set; }

        /// <summary>
        /// 菜单参数名称
        /// </summary>
        [DataMember]
        public string MenuParameter { get; set; }

        /// <summary>
        /// 本菜单是否可用
        /// </summary>
        [DataMember]
        public bool CanUse { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        [DataMember]
        public int Level { get; set; }

        /// <summary>
        /// 图标号
        /// </summary>
        [DataMember]
        public string IconIndex { get; set; }
        [DataMember]
        public List<SinoMenuItem> Children { get; set; }//新添加

        /// <summary>
        /// added by lqm 2012.11.3
        /// </summary>
        public SinoMenuItem()
        { }
        
        public SinoMenuItem(string _mid, string _mname, string _mtype, string _mparam, int _order, string _fid, bool _canuse, int _level, string _iconIndex, string _iconName)
        {
            this.MenuID = _mid;
            MenuTitle = _mname;
            MenuType = _mtype;
            MenuParameter = _mparam;
            DisplayOrder = _order;
            FatherID = _fid;
            CanUse = _canuse;
            Level = _level;
            IconIndex = _iconIndex;
            IconName = _iconName;
            this.Children = new List<SinoMenuItem>();
        }

    }
}
