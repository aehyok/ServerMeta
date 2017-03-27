//	Date.cs
//
//	.NET Framework类库中没有Date类型，因此自行定义一个
//
//	作者:		黄晓东(2003.11.3)
//	
//	描述:
//
//	设计思路:
//
//	版本特性:
//
//	遗留问题:
//		尚未完成，因此保留为internal

using System;
using System.Diagnostics;

namespace System
{
	/// <summary>
	/// Summary description for Date.
	/// </summary>
	internal class Date
	{
		private	int	_year;
		private int	_month;
		private int _day;
		
		public Date(int year, int month, int day)
		{
			_year	= year;
			_month	= month;
			_day	= day;
		}
		
	}
}
