using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSZJS.Base.GuideLine
{
    /// <summary>
    /// 这是新的gridinfo,配合GuideLineEntity,GuideLineModel使用
    /// </summary>
    public class GridInfo
    {
        /// <summary>
        /// gridview的名字,默认为"ZBGridView"
        /// </summary>
        public string GridViewName { set; get; }
        /// <summary>
        /// gridview在performcallback时跳转的controller,默认为"XZZFJD"
        /// </summary>
        public string Controller { set; get; }
        /// <summary>
        /// gridview在performcallback时跳转的action,默认为"GridViewPartialView"
        /// </summary>
        public string Action { set; get; }
        /// <summary>
        /// gridview在删除记录时跳转的controller
        /// </summary>
        public string DeleteController { set; get; }
        /// <summary>
        ///  gridview在删除记录时跳转的action
        /// </summary>
        public string DeleteAction { set; get; }
        /// <summary>
        /// 是否显示序号列,默认为false
        /// </summary>
        public bool IsShowIndex { set; get; }
        ///// <summary>
        ///// 是否显示checkbox列,若显示，则同时需设置KeyField属性,默认为false
        ///// </summary>
        //public bool IsShowCheckBox { set; get; }

        /// <summary>
        /// GridView列表选择模式 1=CheckBox,2=RadioButton,0=无选择模式（added by lqm 2013.09.11）
        /// </summary>
        public int ShowSelectMode { get; set; }
        /// <summary>
        /// 是否显示删除按钮,若显示，则同时需设置KeyField、DeleteController和DeleteAction属性,默认为false
        /// </summary>
        public bool IsShowDeleteButton { set; get; }
        /// <summary>
        /// girdview的主键
        /// </summary>
        public string KeyField { set; get; }
        /// <summary>
        /// 过滤结果集的关键字
        /// </summary>
        public string FilterKeyWord { set; get; }
        /// <summary>
        /// 是否允许分页,默认为false
        /// </summary>
        public bool AllowPaging { set; get; }
        /// <summary>
        /// 页码,默认为1,当AllowPaging属性值为true是有效
        /// </summary>
        public decimal PageIndex { set; get; }
        /// <summary>
        /// 每页的记录数，默为15,当AllowPaging属性值为true是有效
        /// </summary>
        public decimal PageSize { set; get; }
        /// <summary>
        /// 记录总数,当AllowPaging属性值为true是有效
        /// </summary>
        public decimal RecordCount { set; get; }
        /// <summary>
        /// 排序字段,当AllowPaging属性值为true是有效
        /// </summary>
        public string SortBy { set; get; }
        /// <summary>
        /// 排序方向(ASC,DESC),当AllowPaging属性值为true是有效
        /// </summary>
        public string SortDirection { set; get; }
        /// <summary>
        /// gridview的高度,初值为0
        /// </summary>
        public int Height { set; get; }
        /// <summary>
        /// 是否显示垂直滚动条("auto,hidden,visible,none"),默认为none
        /// </summary>
        public string VerticalScrollBarMode { set; get; }

        public GridInfo()
        {
            GridViewName = "ZBGridView";
            Controller = "XZZFJD";
            Action = "GridView";
            IsShowIndex = false;
            //IsShowCheckBox = false;
            IsShowDeleteButton = false;
            VerticalScrollBarMode = "none";
            PageIndex = 1;
            PageSize = 15;
            Height = 0;
            ShowSelectMode = 0;
        }
    }
}
