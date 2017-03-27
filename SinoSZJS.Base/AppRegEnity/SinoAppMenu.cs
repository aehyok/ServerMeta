using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.AppRegEnity
{
    [DataContract]
    public class SinoAppMenu
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public string ID { get; set; }
        /// <summary>
        /// 菜单图片
        /// </summary>
        [DataMember]
        public string Icon { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        [DataMember]
        public string Title { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [DataMember]
        public string Description { get; set; }
        /// <summary>
        /// 连接地址
        /// </summary>
        [DataMember]
        public string LinkUrl { get; set; }
        /// <summary>
        /// 打开方式
        /// </summary>
        [DataMember]
        public string OpenMode { get; set; }
        /// <summary>
        /// 显示顺序
        /// </summary>
        [DataMember]
        public int DisplayOrder { get; set; }
        /// <summary>
        /// 弹出框高度
        /// </summary>
        [DataMember]
        public int Height { set; get; }
        /// <summary>
        /// 弹出框宽度
        /// </summary>
        [DataMember]
        public int Width { set; get; }

        public SinoAppMenu() { }

        public SinoAppMenu(string _id, string _icon, string _title, string _description, string _linkUrl,
            string _openMode, int _displayOrder, int _height, int _width)
        {
            this.ID = _id;
            this.Icon = _icon;
            this.Title = _title;
            this.Description = _description;
            this.LinkUrl = _linkUrl;
            this.OpenMode = _openMode;
            this.DisplayOrder = _displayOrder;
            this.Height = _height;
            this.Width = _width;

        }


    }
}
