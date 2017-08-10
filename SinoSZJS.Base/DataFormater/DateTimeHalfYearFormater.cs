using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.SystemLog;
using System.Diagnostics;

namespace SinoSZJS.Base.DataFormater
{
        public class DateTimeHalfYearFormater : IFormatProvider, ICustomFormatter
        {
                public object GetFormat(Type formatType)
                {
                        if (formatType == typeof(ICustomFormatter))
                                return this;
                        else
                                return null;
                }


                #region ICustomFormatter Members

                public string Format(string format, object arg, IFormatProvider formatProvider)
                {
                        string _result = "";
                        try
                        {
                                if (arg is DateTime)
                                {
                                        DateTime _dt = (DateTime)arg;
                                        int _year = _dt.Year;
                                        string _half = (_dt.Month > 6) ? "下半年" : "上半年";
                                        _result = string.Format("{0}年{1}", _year, _half);
                                }
                        }
                        catch (Exception ex)
                        {
                                string log = string.Format("转换{0}成半年格式时出错！{1}", arg, ex.Message);
                                //SystemLogWriter.WriteLog(log, EventLogEntryType.Warning);
                                return "";
                        }
                        return _result;
                }

                #endregion
        }
}
