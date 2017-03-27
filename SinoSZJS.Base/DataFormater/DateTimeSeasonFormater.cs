using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.SystemLog;
using System.Diagnostics;

namespace SinoSZJS.Base.DataFormater
{
        public class DateTimeSeasonFormater : IFormatProvider, ICustomFormatter
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
                                        int _season = (_dt.Month - 1) / 3 + 1;
                                        _result = string.Format("{0}年{1}季度", _year, _season);
                                }
                        }
                        catch (Exception ex)
                        {
                                string log = string.Format("转换{0}成季度格式时出错！{1}", arg, ex.Message);
                                SystemLogWriter.WriteLog(log, EventLogEntryType.Warning);
                                return "";
                        }
                        return _result;
                }

                #endregion
        }
}
