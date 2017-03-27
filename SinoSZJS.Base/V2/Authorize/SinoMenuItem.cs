using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SinoSZJS.Base.V2.Authorize
{
	/// <summary>
	/// 菜单项定义
	/// </summary>
	[DataContract]
    [Serializable]
	public class SinoMenuItem:ICloneable
	{
		/// <summary>
		/// 菜单ID
		/// </summary>
		[DataMember]
		public string MenuId { get; set; }

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
		public string FatherId { get; set; }

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

		/// <summary>
		/// 子菜单列表
		/// </summary>
		[DataMember]
		public List<SinoMenuItem> Children { get; set; }//新添加

		public SinoMenuItem() { }

		public SinoMenuItem(string menuId, string menuTitle, string menuType, string menuParameter, int displayOrder, string fatherId, bool canUse, int level, string iconIndex, string iconName)
		{
			this.MenuId = menuId;
			this.MenuTitle = menuTitle;
			this.MenuType = menuType;
			this.MenuParameter = menuParameter;
			this.DisplayOrder = displayOrder;
			this.FatherId = fatherId;
			this.CanUse = canUse;
			this.Level = level;
			this.IconIndex = iconIndex;
			this.IconName = iconName;
			this.Children = new List<SinoMenuItem>();
		}

        /// <summary>
        /// 克隆  深复制
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            using (Stream objectstream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectstream, this);
                objectstream.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(objectstream) as SinoMenuItem;
            }
        }
    }
}
