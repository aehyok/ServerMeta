//	Date.cs
//
//	.NET Framework�����û��Date���ͣ�������ж���һ��
//
//	����:		������(2003.11.3)
//	
//	����:
//
//	���˼·:
//
//	�汾����:
//
//	��������:
//		��δ��ɣ���˱���Ϊinternal

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
