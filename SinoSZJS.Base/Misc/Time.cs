//	Time.cs
//
//	.NET Framework类库中没有Time类型，因此自行定义一个
//
//	作者:		黄晓东(2003.11.3)
//	
//	描述:
//
//	设计思路:
//		尽量与System.DateTime保持兼容(包括语法、表达方式、精确刻度、语义等)
//
//	版本特性:
//		1. 数据表达精确到100豪微秒(10E-7秒, 与DateTime相同)
//		2. 遵循DateTime的语义, Add/Substract系列方法只将修改后的时间返回，并不修改原对象中的时间.
//		   同时, Add/Substract系列方法采用溢出循环的方式(与DateTime不同)
//		3. 采用24小时制(与DateTime相同)                  ~~~~~~~~~~~~~~
//
//	遗留问题:
//		1. 目前对Parse/ToString仅支持"HH:MM:SS"和"HHMMSS"两种固定的格式
//		2. 目前对Parse没有实现易读的FormatException
//		3. 目前没有实现ParseExact方法

using System;
using System.Diagnostics;

namespace System
{
	/// <summary>
	/// Summary description for Time.
	/// </summary>
	public struct Time
	{
		private long _ticks;			//	自午夜0:00以来的经过时间以100毫微秒为间隔表示时的数字
		
		public const int	HoursPerDay				= 24;
		public const int	MinutesPerHour			= 60;
		public const int	MinutesPerDay			= 1440;
		public const int	SecondsPerMinute		= 60;
		public const int	SecondsPerHour			= 3600;
		public const int	SecondsPerDay			= 86400;
		public const int	MillisecondsPerSecond	= 1000;

		public static readonly Time	MinValue			= new Time(0L);
		public static readonly Time MaxValue			= new Time(TimeSpan.TicksPerDay - 1);
		
		public Time(long ticks)
		{
			if (ticks < 0 || ticks >= TimeSpan.TicksPerDay)
				{
				Debug.Assert(false);
				_ticks	= 0;
				throw new ArgumentOutOfRangeException("ticks", ticks, "ticks值无效");
				}
			_ticks = ticks;
		}
				
		public Time(int hour, int minute, int second) : this(hour, minute, second, 0)
		{
		}
		
		public Time(int hour, int minute, int second, int milliSecond)
		{
			if (hour < 0 || hour >= HoursPerDay)
				{
				Debug.Assert(false);
				_ticks	= 0;
				throw new ArgumentOutOfRangeException("hour", hour, "hour值无效");
				}
			if (minute < 0 || minute >= MinutesPerHour)
				{
				Debug.Assert(false);
				_ticks	= 0;
				throw new ArgumentOutOfRangeException("minute", minute, "minute值无效");
				}
			 if (second < 0 || second >= SecondsPerMinute)				
				{
				Debug.Assert(false);
				_ticks	= 0;
				throw new ArgumentOutOfRangeException("second", second, "second值无效");
				}
			 if (milliSecond < 0 || milliSecond >= MillisecondsPerSecond)
				{
				Debug.Assert(false);
				_ticks	= 0;
				throw new ArgumentOutOfRangeException("milliSecond", milliSecond, "milliSecond值无效");
				}

			_ticks = (long)hour * TimeSpan.TicksPerHour + (long)minute * TimeSpan.TicksPerMinute + 
							(long)second * TimeSpan.TicksPerSecond + (long)milliSecond * TimeSpan.TicksPerMillisecond;
		}
		
		public Time(DateTime dateTime)
		{
			DateTime beginOfDate = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
			_ticks = (dateTime - beginOfDate).Ticks;
		}
		
		public int	Hour			{ get { return (int)(_ticks / TimeSpan.TicksPerHour); } }
		public int	Minute			{ get { return (int)((_ticks % TimeSpan.TicksPerHour) / TimeSpan.TicksPerMinute); } }
		public int	Second			{ get { return (int)((_ticks % TimeSpan.TicksPerMinute) / TimeSpan.TicksPerSecond); } }
		public int	MilliSecond		{ get { return (int)((_ticks % TimeSpan.TicksPerSecond) / TimeSpan.TicksPerMillisecond); } }
		public long	Ticks			{ get { return _ticks; } }
		
		public static Time	Now			{ get { return new Time(DateTime.Now); } }
		public static Time	UtcNow		{ get { return new Time(DateTime.UtcNow); } }
		
		public Time Add(TimeSpan timeSpan)
		{
			return new Time((_ticks + timeSpan.Ticks) % TimeSpan.TicksPerDay);
		}
		
		public Time AddHours(double hours)
		{
			return new Time((_ticks + (long)(hours * TimeSpan.TicksPerHour)) % TimeSpan.TicksPerDay);
		}
		
		public Time AddMinutes(double minutes)
		{
			return new Time((_ticks + (long)(minutes * TimeSpan.TicksPerMinute)) % TimeSpan.TicksPerDay);
		}
		
		public Time AddSeconds(double seconds)
		{
			return new Time((_ticks + (long)(seconds * TimeSpan.TicksPerSecond)) % TimeSpan.TicksPerDay);
		}
		
		public Time AddMilliSeconds(double milliSeconds)
		{
			return new Time((_ticks + (long)(milliSeconds * TimeSpan.TicksPerMillisecond)) % TimeSpan.TicksPerDay);
		}
		
		public Time AddTicks(long ticks)
		{
			return new Time((_ticks + ticks) % TimeSpan.TicksPerDay);
		}
		
		public static int Compare(Time time1, Time time2)
		{
			if (time1 > time2)
				return 1;
			else if (time1 == time2)
				return 0;
			else
				return -1;
		}
		
		public int CompareTo(Time time2)
		{
			return Compare(this, time2);
		}
		
		public override bool Equals(object value)
		{
			if (value is Time)
				return this == (Time)value;
			else
				return false;
		}
		
		public static bool Equals(Time time1, Time time2)
		{
			return time1 == time2;
		}
		
		public override int GetHashCode()
		{
			return base.GetHashCode ();
		}

		//	目前没有实现易读的FormatException		
		public static Time Parse(string s)
		{
			if (s.Length == 8)
				{
				int hour	= int.Parse(s.Substring(0, 2));
				int	minute	= int.Parse(s.Substring(3, 2));
				int second	= int.Parse(s.Substring(6, 2));
				return new Time(hour, minute, second);
				}
			else if (s.Length == 6)
				{
				int hour	= int.Parse(s.Substring(0, 2));
				int	minute	= int.Parse(s.Substring(2, 2));
				int second	= int.Parse(s.Substring(4, 2));
				return new Time(hour, minute, second);
				}
			else
				{
				Debug.Assert(false);
				throw new FormatException("必须是HH:MM:SS或者HHMMSS格式");
				}
		}
		
		public TimeSpan Substract(Time time2)
		{
			return new TimeSpan(this.Ticks - time2.Ticks);
		}
		
		public Time Substract(TimeSpan timeSpan)
		{
			return new Time((this.Ticks - timeSpan.Ticks) % TimeSpan.TicksPerDay);
		}
		
		//	形成HH:MM:SS格式的字符串
		public override string ToString()
		{
//			return string.Format("{0:02}:{1:02}:{2:02}", Hour, Minute, Second);
			//2003-11-8杨睿改
			return string.Format("{0:d2}:{1:d2}:{2:d2}", Hour, Minute, Second);
		}
		
		//	形成HHMMSS格式的字符串
		public string ToShortString()
		{
//			return string.Format("{0:02}{1:02}{2:02}", Hour, Minute, Second);
			//2003-11-8杨睿改
			return string.Format("{0:d2}{1:d2}{2:d2}", Hour, Minute, Second);
		}
		
		// 形成HH:MM格式的字符串（杨睿2003-11-8加）
		public string ToShortTime()
		{
			return string.Format("{0:d2}:{1:d2}", Hour, Minute);
		}

		public Time ToUniveralTime()
		{
			return new Time((new DateTime(2000, 1, 1)).ToUniversalTime());
		}
		
		public static Time operator + (Time time, TimeSpan timeSpan)
		{
			return time.Add(timeSpan);
		}
		
		public static bool operator == (Time time1, Time time2)
		{
			return time1.Ticks == time2.Ticks;
		}
		
		public static bool operator != (Time time1, Time time2)
		{
			return time1.Ticks != time2.Ticks;
		}
		
		public static bool operator > (Time time1, Time time2)
		{
			return time1.Ticks > time2.Ticks;
		}
		
		public static bool operator >= (Time time1, Time time2)
		{
			return time1.Ticks >= time2.Ticks;
		}
		
		public static bool operator < (Time time1, Time time2)
		{
			return time1.Ticks < time2.Ticks;
		}
		
		public static bool operator <= (Time time1, Time time2)
		{
			return time1.Ticks <= time2.Ticks;
		}
		
		public static TimeSpan operator - (Time time1, Time time2)
		{
			return time1.Substract(time2);
		}
		
		public static Time operator - (Time time, TimeSpan timeSpan)
		{
			return time.Substract(timeSpan);
		}
	}
}