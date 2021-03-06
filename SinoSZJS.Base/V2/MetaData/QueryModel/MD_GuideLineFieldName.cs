﻿using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.MetaData.QueryModel
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

		public MD_GuideLineFieldName(string fname, string title, int order, int width, string align, string format, bool hide, string groupName)
		{
			FieldName = fname;
			DisplayTitle = title;
			DisplayOrder = order;
			DisplayWidth = width;
			TextAlign = align;
			DisplayFormat = format;
			CanHide = hide;
			GroupName = groupName;
		}
		public MD_GuideLineFieldName(string fname, string title, int order, int width, string align, string format, bool hide)
		{
			FieldName = fname;
			DisplayTitle = title;
			DisplayOrder = order;
			DisplayWidth = width;
			TextAlign = align;
			DisplayFormat = format;
			CanHide = hide;
		}
	}
}
