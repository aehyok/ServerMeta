using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.DateTimeDefine
{
        public struct SinoSZ_Season
        {
                public DateTime StartDate ;
                public DateTime EndDate ;
                public int SeasonIndex ;
                public SinoSZ_Season(int _year, int _index)
                {
                        if (_index < 0 || _index > 4) throw new Exception("季序号必须在1到4之间!");
                        StartDate = new DateTime(_year, (_index - 1) * 3 + 1, 1);
                        EndDate = StartDate.AddMonths(3).AddSeconds(-1);
                        SeasonIndex = _index;
                }

                public static SinoSZ_Season SeasonOfDate(DateTime _date)
                {
                        int _index = (_date.Month / 3);
                        _index++;
                        return new SinoSZ_Season(_date.Year, _index);
                }

                public SinoSZ_Season AddSeason(int _num)
                {
                        if (_num == 0)
                        {
                                SinoSZ_Season _ret = this;
                                return _ret;
                        }
                        else
                        {
                                DateTime _retStart = StartDate.AddMonths(3 * _num);
                                return SinoSZ_Season.SeasonOfDate(_retStart);
                        }
                }

                public override string ToString()
                {
                        return string.Format("{0}年{1}季度", StartDate.Year, SeasonIndex);
                }
        }
}
