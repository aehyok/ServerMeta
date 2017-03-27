using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Xml;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.V2.Misc
{
	/// <summary>
	/// added by  lqm 2014.03.07
	/// </summary>
	public static class StrUtils
	{
		/// <summary>
		/// 从XML字符串中取指定的名称段的内容
		/// </summary>
		/// <param name="_name">段名</param>
		/// <param name="_meta">XML字符串</param>
		/// <returns></returns>
		public static string GetMetaByName(this string meta, string name)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(string.Format("<XmlText>{0}</XmlText>", meta));

			XmlNodeList xmlNodeList = xmlDocument.GetElementsByTagName(name);
			if (xmlNodeList.Count > 0)
			{
				return xmlNodeList[0].InnerXml;
			}
			else
			{
				return "";
			}
		}

		public static string GetMetaByName2(this string meta, string name)
		{
			RegexOptions regexOptions = RegexOptions.None;
			string regString = "<" + name + @">[^<]{1,}</" + name + ">";
			Regex regeMeta = new Regex(regString, regexOptions);
			int TagLength = name.Length;
			MatchCollection matchCollection = regeMeta.Matches(meta);
			foreach (Match match in matchCollection)
			{
				return match.Value.Substring(TagLength + 2, match.Length - (TagLength + 2) * 2 - 1);
			}
			return "";
		}

		/// <summary>
		/// 从XML字符串中取指定的名称段的内容列表
		/// </summary>
		/// <param name="_name">段名称</param>
		/// <param name="_meta">XML字符串</param>
		/// <returns></returns>
		public static ArrayList GetMetasByName(string _name, string _meta)
		{
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(string.Format("<XmlText>{0}</XmlText>", _meta));
			ArrayList _res = new ArrayList();
			XmlNodeList elemList = doc.GetElementsByTagName(_name);
			for (int i = 0; i < elemList.Count; i++)
			{
				string _s2 = elemList[i].InnerXml;
				_res.Add(_s2);
			}

			return _res;
		}

		public static ArrayList GetMetasByName2(string _name, string _meta)
		{
			ArrayList _res = new ArrayList();

			RegexOptions options = RegexOptions.None;
			string _regStr = "<" + _name + @">[^<]{1,}</" + _name + ">";
			Regex regeMeta = new Regex(_regStr, options);
			int _TagLength = _name.Length;
			MatchCollection _mc = regeMeta.Matches(_meta);
			foreach (Match _m in _mc)
			{
				string _s2 = _m.Value.Substring(_TagLength + 2, _m.Length - (_TagLength + 2) * 2 - 1);
				_res.Add(_s2);
			}

			return _res;
		}

		/// <summary>
		/// 把string转DateTime
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public static DateTime String2Date(string date)
		{
			if (string.IsNullOrEmpty(date)) return DateTime.MinValue;
			string lsdate = date.Replace("年", "");
			lsdate = lsdate.Replace("月", "");
			lsdate = lsdate.Replace("日", "");
			lsdate = lsdate.Replace("/", "");
			lsdate = lsdate.Replace("-", "");
			lsdate = lsdate.Replace(" ", "");//替换空格
			lsdate = lsdate.Replace(":", "");
			switch (lsdate.Length)
			{
				case 4:
					int year4 = int.Parse(lsdate.Substring(0, 4));
					return new DateTime(year4, 1, 1);
				case 6:
					int year6 = int.Parse(lsdate.Substring(0, 4));
					int month6 = int.Parse(lsdate.Substring(4, 2));
					return new DateTime(year6, month6, 1);
				case 8:
					int year8 = int.Parse(lsdate.Substring(0, 4));
					int month8 = int.Parse(lsdate.Substring(4, 2));
					int day8 = int.Parse(lsdate.Substring(6, 2));
					return new DateTime(year8, month8, day8);
				case 14:
					int year14 = int.Parse(lsdate.Substring(0, 4));
					int month14 = int.Parse(lsdate.Substring(4, 2));
					int day14 = int.Parse(lsdate.Substring(6, 2));
					int hour = int.Parse(lsdate.Substring(8, 2));
					int min = int.Parse(lsdate.Substring(10, 2));
					int sec = int.Parse(lsdate.Substring(12, 2));
					return new DateTime(year14, month14, day14, hour, min, sec);
				default:
					return DateTime.MinValue;
			}
		}

		/// <summary>
		/// 全角转换成半角
		/// </summary>
		/// <param name="_s"></param>
		/// <returns></returns>
		static public string ConvertToNarrow(string input)
		{
			char[] c = input.ToCharArray();
			for (int i = 0; i < c.Length; i++)
			{
				if (c[i] == 12288)
				{
					c[i] = (char)32;
					continue;
				}

				if (c[i] > 65280 && c[i] < 65375)
					c[i] = (char)(c[i] - 65248);
			}
			return new string(c);
		}


		/// <summary>
		/// XML转为Dictionary<string,object>
		/// </summary>
		/// <param name="pstr"></param>
		/// <returns></returns>
		public static Dictionary<string, object> ChangeXMLToDictionary(this string pstr)
		{
			int index, start, end, em_start;
			string mark, endmark;
			Dictionary<string, object> _ret = new Dictionary<string, object>();
			index = 0;
			if (pstr != null)
			{
				while (index < pstr.Length)
				{
					start = pstr.IndexOf('<', index);
					if (start >= 0)
					{
						end = pstr.IndexOf('>', start);
						if (end >= 0)
						{
							mark = pstr.Substring(start + 1, end - start - 1);
							endmark = string.Format("</{0}>", mark);
							em_start = pstr.IndexOf(endmark, end + 1);
							if (em_start >= 0)
							{
								string value = pstr.Substring(end + 1, em_start - end - 1);
								_ret.Add(mark, value);
								index = end + endmark.Length + 1;
							}
							else
							{
								index = end + 1;
							}
						}
						else
						{
							index = start + 1;
						}
					}
					else
					{
						index = pstr.Length + 1;
					}
				}
			}
			return _ret;
		}

        /// <summary>
        /// 判断字符串是否有空格
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        static public bool IsSpace(this string tableName)//新添加
        {
            tableName = StrUtils.ConvertToNarrow(tableName);
            if (tableName.IndexOf(' ') > -1)
            {
                return true;
            }
            return false;
        }

        public static int IndexOfComma(this string data)
        {
            string s = @".";
            string s2 = @"" + data;
            Regex re = new Regex(Regex.Escape(s), RegexOptions.IgnoreCase | RegexOptions.Singleline);
            MatchCollection mc = re.Matches(s2);
            return mc.Count;
        }

        /// <summary>
        /// 判断字符串是否是数字
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsDigit(this string data)
        {
            Char[] chars = data.ToCharArray();
            foreach (char c in chars)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 确保字符串以指定的字符或字符串结尾(如果不是则自动添加)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public static string EnsureEndsWith(ref string str, char suffix)
        {
            string suffixStr = new string(suffix, 1);
            if (!str.EndsWith(suffixStr))
                str += suffixStr;
            return str;
        }

        private static char[] strChinese = new char[] {
					'〇','一','二','三','四','五','六','七','八','九','十'
					};

        /// <summary>
        /// 将日期转化成中文大写写法
        /// </summary>
        /// <param name="strDate"></param>
        /// <returns></returns>
        public static string ConvertToChineseDate(this string DateParam)
        {
            StringBuilder result = new StringBuilder();
            string strDate = DateParam.Replace("年", "/");
            strDate = strDate.Replace("月", "/");
            strDate = strDate.Replace("日", "");

            if (strDate.Length > 0)
            {
                // 将数字日期的年月日存到字符数组str中
                string[] str = null;
                if (strDate.Contains("-"))
                {
                    str = strDate.Split('-');
                }
                else if (strDate.Contains("/"))
                {
                    str = strDate.Split('/');
                }

                // str[0]中为年，将其各个字符转换为相应的汉字
                for (int i = 0; i < str[0].Length; i++)
                {
                    result.Append(strChinese[int.Parse(str[0][i].ToString())]);
                }
                result.Append("年");

                // 转换月
                int month = int.Parse(str[1]);
                int MN1 = month / 10;
                int MN2 = month % 10;

                if (MN1 > 1)
                {
                    result.Append(strChinese[MN1]);
                }
                if (MN1 > 0)
                {
                    result.Append(strChinese[10]);
                }
                if (MN2 != 0)
                {
                    result.Append(strChinese[MN2]);
                }
                result.Append("月");

                // 转换日
                int day = int.Parse(str[2]);
                int DN1 = day / 10;
                int DN2 = day % 10;

                if (DN1 > 1)
                {
                    result.Append(strChinese[DN1]);
                }
                if (DN1 > 0)
                {
                    result.Append(strChinese[10]);
                }
                if (DN2 != 0)
                {
                    result.Append(strChinese[DN2]);
                }
                result.Append("日");
                return result.ToString();
            }
            else
            {
                return "";
            }

        }
	}
}
