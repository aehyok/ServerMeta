using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;

namespace SinoSZJS.Base.Expression
{
        /// <summary>
        /// 验证查询表达式是否正确
        /// </summary>
        public class QueryExpression
        {
                static RegexOptions options = RegexOptions.None;
                static Regex regeFirst = new Regex(@"s", options);
                static Regex regeMax = new Regex(@"[0-9]{1,}", options);
                static Regex regeZero = new Regex(@"[0]*", options);
                static Regex regeChild = new Regex(@"\([0-9!s\+\*]*\)", options);
                static Regex regeExpress = new Regex(@"[!]{0,1}(([0-9]{1,})|[s])(([+*]{1,}[!]{0,1}[0-9]+)|([+*]{1,}[!]{0,1}s)){0,}", options);


                public QueryExpression()
                {
                        //
                        // TODO: 在此处添加构造函数逻辑
                        //

                }

                static public bool ExpressCheck(string _exp, int _maxnum)
                {
                        bool _ret = ExpressItemCheck(_exp, _maxnum);
                        if (_ret)
                        {
                                _ret = ExpressCheck(_exp);
                        }
                        return _ret;
                }

                static public bool ExpressItemCheck(string _exp, int _maxnum)
                {
                        int ls_1;
                        MatchCollection match = regeMax.Matches(_exp);
                        foreach (Match c in match)
                        {
                                ls_1 = Convert.ToInt16(c.Value);
                                if (ls_1 < 1) return false;
                                if (ls_1 > _maxnum) return false;
                        }
                        return true;
                }

                static public bool ExpressCheck(string _exp)
                {
                        bool _res = false;
                        string s = "";
                        string _newexp = _exp;
                        if (regeFirst.IsMatch(_newexp)) return false;
                        MatchCollection match = regeChild.Matches(_newexp);
                        while (match.Count > 0)
                        {
                                foreach (Match c in match)
                                {
                                        s = c.Value.Substring(1, c.Value.Length - 2);
                                        if (!ChirdrenExpressCheck(s))
                                        {
                                                return false;
                                        }
                                }
                                _newexp = regeChild.Replace(_newexp, "s");
                                match = regeChild.Matches(_newexp);
                        }
                        _res = ChirdrenExpressCheck(_newexp);

                        return _res;
                }

                static bool ChirdrenExpressCheck(string _exp)
                {
                        Match match = regeExpress.Match(_exp);
                        if (match.Value == _exp)
                                return true;
                        else
                                return false;
                }

                static public string GetLevelString(string _code, string LevelFormat)
                {

                        RegexOptions options = RegexOptions.None;
                        Regex regeZero = new Regex(@"[0]*", options);
                        string[] levels = LevelFormat.Split(',');
                        string _f = string.Empty, _current = _code, _rest = _code;
                        int _lsLen = 0;
                        if (LevelFormat == "") return _code;
                        for (int i = levels.Length; i > 0; i--)
                        {
                                _lsLen += Convert.ToInt16(levels[i - 1]);
                                string _ls1 = _code.Substring(_code.Length - _lsLen, _lsLen);
                                if (regeZero.Match(_ls1).Value == _ls1)
                                {
                                        _rest = _code.Substring(0, _code.Length - _lsLen);
                                }
                                else
                                {
                                        return _rest;
                                }
                        }
                        return _code.Substring(0, int.Parse(levels[0]));
                }
        }


}
