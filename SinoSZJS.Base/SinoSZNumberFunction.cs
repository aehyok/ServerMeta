using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SinoSZJS.Base
{
        public class SinoSZNumberFunction
        {
                public static bool CheckNumberStringFormat(string _str)
                {
                        if (_str.IndexOf(',') > 0) return false;
                        

                        try
                        {
                                decimal _i = decimal.Parse(_str);
                                return true;
                        }
                        catch
                        {
                                return false;
                        }

                }
        }
}
