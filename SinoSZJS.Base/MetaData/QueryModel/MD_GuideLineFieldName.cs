using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MetaData.QueryModel
{
    [DataContract]
    public class MD_GuideLineFieldName
    {
        [DataMember]
        /// <summary>
        /// 本字段是否可隐藏
        /// </summary>
        public bool CanHide { get; set; }

        [DataMember]
        /// <summary>
        /// 显示格式
        /// </summary>
        public string DisplayFormat { get; set; }

        [DataMember]
        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName { get; set; }


        /// <summary>
        /// 显示名称
        /// </summary>
        /// 
        [DataMember]
        public string DisplayTitle { get; set; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        /// 
        [DataMember]
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 显示宽度
        /// </summary>
        /// 
        [DataMember]
        public int DisplayWidth { get; set; }

        /// <summary>
        /// 是否居中
        /// </summary>
        /// 
        [DataMember]
        public string TextAlign { get; set; }

        /// <summary>
        /// 分组名称
        /// </summary>
        [DataMember]
        public string GroupName { get; set; }
        public MD_GuideLineFieldName()
        {
        }

        public MD_GuideLineFieldName(string _fname, string _title, int _order, int _width, string _align, string _format, bool _hide, string _groupName)
        {
            FieldName = _fname;
            DisplayTitle = _title;
            DisplayOrder = _order;
            DisplayWidth = _width;
            TextAlign = _align;
            DisplayFormat =_format;
            CanHide = _hide;
            GroupName = _groupName;
        }
        public MD_GuideLineFieldName(string _fname, string _title, int _order, int _width, string _align, string _format, bool _hide)
        {
            FieldName = _fname;
            DisplayTitle = _title;
            DisplayOrder = _order;
            DisplayWidth = _width;
            TextAlign = _align;
            DisplayFormat = _format;
            CanHide = _hide;
        }
    }
}
