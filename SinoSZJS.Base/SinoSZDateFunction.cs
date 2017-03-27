using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SinoSZJS.Base
{
        public class SinoSZDateFunction
        {
                static RegexOptions options = RegexOptions.None;
                static Regex regeDateType1 = new Regex(@"[12]{1}[0-9]{7}", options);
                static Regex regeDateType2 = new Regex(@"[12]{1}[0-9]{3}[-]{1}[01]{0,1}[0-9]{1}[-]{1}[0-3]{0,1}[0-9]{1}", options);
                static Regex regeDateType3 = new Regex(@"[12]{1}[0-9]{3}[/]{1}[01]{0,1}[0-9]{1}[/]{1}[0-3]{0,1}[0-9]{1}", options);

                /// <summary>
                /// 将日期字符串变为日期格式
                /// </summary>
                /// <param name="_dateStr"></param>
                /// <returns></returns>
                public static DateTime ConvertDateTimeType(string _dateStr)
                {
                        if (!CheckDateStringFormat(_dateStr))
                        {
                                return DateTime.MinValue;
                        }
                        string _ds = ConvertStandardDateString(_dateStr);
                        return DateTime.Parse(_ds);
                }

                /// <summary>
                /// 将日期格式变为标准格式
                /// </summary>
                /// <param name="_dateStr"></param>
                /// <returns></returns>
                public static string ConvertStandardDateString(string _dateStr)
                {
                        if (!CheckDateStringFormat(_dateStr)) return "";
                        return ConvertDateString(_dateStr);
                }

                public static string ConvertDateString(string _dateStr)
                {

                        string _year = "";
                        string _month = "";
                        string _day = "";

                        string _dstr = _dateStr.Replace("年", "-");
                        _dstr = _dstr.Replace("月", "-");
                        _dstr = _dstr.Replace("日", "");
                        if (isDateType(_dstr, regeDateType2))
                        {
                                return _dstr;
                        }
                        else if (isDateType(_dstr, regeDateType1))
                        {
                                _year = _dateStr.Substring(0, 4);
                                _month = _dateStr.Substring(4, 2);
                                _day = _dateStr.Substring(6, 2);
                                return string.Format("{0}-{1}-{2}", _year, _month, _day);
                        }
                        else if (isDateType(_dstr, regeDateType3))
                        {
                                string[] _ds = _dateStr.Split('/');
                                return string.Format("{0}-{1}-{2}", _ds[0],_ds[1],_ds[2]);
                        }
                        else
                        {
                                return "";
                        }
                }

                /// <summary>
                /// 将日期格式变为标准格式
                /// </summary>
                /// <param name="_dateStr"></param>
                /// <returns></returns>
                public static string ConvertStandardDateString(DateTime _dateStr)
                {
                        return _dateStr.ToString("yyyy-MM-dd");
                }

                /// <summary>
                /// 检查日期格式是否正确
                /// </summary>
                /// <param name="p"></param>
                /// <returns></returns>
                public static bool CheckDateStringFormat(string _dateStr)
                {
                        string _dstr = _dateStr.Replace("年", "-");
                        _dstr = _dstr.Replace("月", "-");
                        _dstr = _dstr.Replace("日", "");

                        if (isDateType(_dstr, regeDateType1) || isDateType(_dstr, regeDateType2) || isDateType(_dstr, regeDateType3))
                        {
                                try
                                {
                                        string _ds = ConvertDateString(_dateStr);
                                        DateTime _dt = DateTime.Parse(_ds);
                                        return true;
                                }
                                catch
                                {
                                        return false;
                                }
                        }
                        else
                        {
                                return false;
                        }
                }

                private static bool isDateType(string _s, Regex _type)
                {
                        if (_s.Length < 8) return false;
                        if (_type.Match(_s).Value == _s)
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }
        }
}
