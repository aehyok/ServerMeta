using System;
using System.Collections;
using System.Xml;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Security.Cryptography;

namespace SinoSZJS.Base.Misc
{
    /// <summary>
    /// Summary description for StrUtils.
    /// </summary>
    public class StrUtils
    {
        public static int GetLengthChinese2(string _s)
        {
            int _ret = 0;
            foreach (char c in _s)
            {
                if (char.GetUnicodeCategory(c) == UnicodeCategory.OtherLetter)
                {
                    _ret += 2;
                }
                else if (c == '��' || c == '��')
                {
                    _ret += 2;
                }
                else
                {
                    _ret += 1;
                }
            }
            return _ret;
        }

        public static string GetLeftStringChinese2(string _s, int _length)
        {
            int _ret = 0;
            string _res = "";
            foreach (char c in _s)
            {
                if (char.GetUnicodeCategory(c) == UnicodeCategory.OtherLetter)
                {
                    _ret += 2;
                }
                else if (c == '��' || c == '��')
                {
                    _ret += 2;
                }
                else
                {
                    _ret += 1;
                }
                if (_ret > _length) return _res;
                _res += c;
                if (_ret == _length) return _res;
            }
            return _res;
        }

        public static string PaddingRightChinese2(string _s, int _length, char _blankChar)
        {
            int _srcLength = GetLengthChinese2(_s);
            if (_srcLength == _length) return _s;
            if (_srcLength > _length)
            {
                string _newString = GetLeftStringChinese2(_s, _length);
                if (GetLengthChinese2(_newString) < _length)
                {
                    return _newString + _blankChar;
                }
                else
                {
                    return _newString;
                }
            }
            if (_srcLength < _length)
            {
                int _needNum = _length - _srcLength;
                return _s + "".PadRight(_needNum, _blankChar);
            }
            return _s;
        }
        /// <summary>
        /// ȷ���ַ�����ָ�����ַ����ַ�����β(����������Զ����)
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

        public static string EnsureEndsWith(ref string str, string suffix)
        {
            if (!str.EndsWith(suffix))
                str += suffix;
            return str;
        }

        /// <summary>
        /// ׷���ַ����������ʵ�����Ӷ���
        /// </summary>
        /// <param name="dest">Ŀ���ַ���</param>
        /// <param name="src">Ҫ��ӵ��ַ���</param>
        /// <returns></returns>
        public static string AddByComma(ref string dest, string src)
        {
            return AddBySeperator(ref dest, src, ",", true);
        }

        public static string AddByComma(ref string dest, string src, bool addSpace)
        {
            return AddBySeperator(ref dest, src, ",", addSpace);
        }


        /// <summary>
        /// ׷���ַ����������ʵ�����ӷָ���
        /// </summary>
        /// <param name="dest">Ŀ���ַ���</param>
        /// <param name="src">Ҫ��ӵ��ַ���</param>
        /// <param name="seperator">�ָ���</param>
        /// <returns></returns>
        public static string AddBySeperator(ref string dest, string src, string seperator)
        {
            return AddBySeperator(ref dest, src, seperator, false);
        }

        /// <summary>
        /// ׷���ַ����������ʵ�����ӷָ����Ϳո�
        /// </summary>
        /// <param name="dest">Ŀ���ַ���</param>
        /// <param name="src">Ҫ��ӵ��ַ���</param>
        /// <param name="seperator">�ָ���</param>
        /// <param name="addSpace">�Ƿ���ӿո�</param>
        /// <returns></returns>
        public static string AddBySeperator(ref string dest, string src, string seperator, bool addSpace)
        {
            if (dest == string.Empty)
                dest = src;
            else
            {
                if (addSpace)
                    dest += seperator + " " + src;
                else
                    dest += seperator + src;
            }
            return dest;
        }


        /// <summary>
        /// �ж��ַ����Ƿ�������
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsDigit(string s)
        {
            Char[] chars = s.ToCharArray();
            foreach (char c in chars)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// ��XML�ַ�����ȡָ�������ƶε�����
        /// </summary>
        /// <param name="_name">����</param>
        /// <param name="_meta">XML�ַ���</param>
        /// <returns></returns>
        public static string GetMetaByName(string _name, string _meta)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(string.Format("<XmlText>{0}</XmlText>", _meta));

            XmlNodeList elemList = doc.GetElementsByTagName(_name);
            if (elemList.Count > 0)
            {
                return elemList[0].InnerXml;
            }
            else
            {
                return "";
            }
        }

        public static string GetMetaByName2(string _name, string _meta)
        {
            RegexOptions options = RegexOptions.None;
            string _regStr = "<" + _name + @">[^<]{1,}</" + _name + ">";
            Regex regeMeta = new Regex(_regStr, options);
            int _TagLength = _name.Length;
            MatchCollection _mc = regeMeta.Matches(_meta);
            foreach (Match _m in _mc)
            {
                string _s2 = _m.Value.Substring(_TagLength + 2, _m.Length - (_TagLength + 2) * 2 - 1);
                return _s2;
            }
            return "";
        }

        /// <summary>
        /// ��XML�ַ�����ȡָ�������ƶε������б�
        /// </summary>
        /// <param name="_name">������</param>
        /// <param name="_meta">XML�ַ���</param>
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
        /// ȫ��ת���ɰ��
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
        /// ���ת��Ϊȫ��
        /// </summary>
        /// <param name="_s"></param>
        /// <returns></returns>
        static public string ConvertToWide(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }

                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }

        /// <summary> 
        /// ���Сд���д 
        /// </summary> 
        /// <param name="smallnum"></param> 
        /// <returns></returns> 
        public static string ConvertToChineseMoney(decimal smallnum)
        {
            string cmoney, cnumber, cnum, cnum_end, cmon, cno, snum, sno;
            int snum_len, sint_len, cbegin, zflag, i;
            if (smallnum > 1000000000000 || smallnum < -99999999999 || smallnum == 0)
                return "";
            cmoney = "Ǫ��ʰ��Ǫ��ʰ��Ǫ��ʰԪ�Ƿ�";// ��д����ҵ�λ�ַ��� 
            cnumber = "Ҽ��������½��ƾ�";// ��д�����ַ��� 
            cnum = "";// ת����Ĵ�д�����ַ��� 
            cnum_end = "";// ת����Ĵ�д�����ַ��������һλ 
            cmon = "";// ȡ��д����ҵ�λ�ַ����е�ĳһλ 
            cno = "";// ȡ��д�����ַ����е�ĳһλ 

            snum = System.Math.Round(smallnum, 2).ToString("############.00"); ;// Сд�����ַ��� 
            snum_len = snum.Length;// Сд�����ַ����ĳ��� 
            sint_len = snum_len - 2;// Сд�������������ַ����ĳ��� 
            sno = "";// Сд�����ַ����е�ĳ�������ַ� 
            cbegin = 15 - snum_len;// ��д����ҵ�λ�еĺ���λ�� 
            zflag = 1;// Сд�����ַ��Ƿ�Ϊ0(0=0)���жϱ�־ 
            i = 0;// Сд�����ַ����������ַ���λ�� 

            if (snum_len > 15)
                return "";
            for (i = 0; i < snum_len; i++)
            {
                if (i == sint_len - 1)
                    continue;

                cmon = cmoney.Substring(cbegin, 1);
                cbegin = cbegin + 1;
                sno = snum.Substring(i, 1);
                if (sno == "-")
                {
                    cnum = cnum + "��";
                    continue;
                }
                else if (sno == "0")
                {
                    cnum_end = cnum.Substring(cnum.Length - 2, 1);
                    if (cbegin == 4 || (cbegin == 8 || cnum_end.IndexOf("��") >= 0 || cbegin == 12))
                    {
                        cnum = cnum + cmon;
                        if (cnumber.IndexOf(cnum_end) >= 0)
                            zflag = 1;
                        else
                            zflag = 0;
                    }
                    else
                    {
                        zflag = 0;
                    }
                    continue;
                }
                else if (sno != "0" && zflag == 0)
                {
                    cnum = cnum + "��";
                    zflag = 1;
                }
                cno = cnumber.Substring(System.Convert.ToInt32(sno) - 1, 1);
                cnum = cnum + cno + cmon;
            }
            if (snum.Substring(snum.Length - 2, 1) == "0")
            {
                return cnum + "��";
            }
            else
                return cnum;
        }


        private static char[] strChinese = new char[] {
					'��','һ','��','��','��','��','��','��','��','��','ʮ'
					};

        /// <summary>
        /// ������ת�������Ĵ�дд��
        /// </summary>
        /// <param name="strDate"></param>
        /// <returns></returns>
        public static string ConvertToChineseDate(string DateParam)
        {
            StringBuilder result = new StringBuilder();
            string strDate = DateParam.Replace("��", "/");
            strDate = strDate.Replace("��", "/");
            strDate = strDate.Replace("��", "");

            if (strDate.Length > 0)
            {
                // ���������ڵ������մ浽�ַ�����str��
                string[] str = null;
                if (strDate.Contains("-"))
                {
                    str = strDate.Split('-');
                }
                else if (strDate.Contains("/"))
                {
                    str = strDate.Split('/');
                }

                // str[0]��Ϊ�꣬��������ַ�ת��Ϊ��Ӧ�ĺ���
                for (int i = 0; i < str[0].Length; i++)
                {
                    result.Append(strChinese[int.Parse(str[0][i].ToString())]);
                }
                result.Append("��");

                // ת����
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
                result.Append("��");

                // ת����
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
                result.Append("��");
                return result.ToString();
            }
            else
            {
                return "";
            }

        }

        /// <summary>
        /// XMLתΪDictionary<string,object>
        /// </summary>
        /// <param name="pstr"></param>
        /// <returns></returns>
        public static Dictionary<string, object> ChangeXMLToDictionary(string pstr)
        {
            int _index, _start, _end, em_start;
            string _mark, _endmark;
            Dictionary<string, object> _ret = new Dictionary<string, object>();
            _index = 0;
            if (pstr != null)
            {
                while (_index < pstr.Length)
                {
                    _start = pstr.IndexOf('<', _index);
                    if (_start >= 0)
                    {
                        _end = pstr.IndexOf('>', _start);
                        if (_end >= 0)
                        {
                            _mark = pstr.Substring(_start + 1, _end - _start - 1);
                            _endmark = string.Format("</{0}>", _mark);
                            em_start = pstr.IndexOf(_endmark, _end + 1);
                            if (em_start >= 0)
                            {
                                string value = pstr.Substring(_end + 1, em_start - _end - 1);
                                _ret.Add(_mark, value);
                                _index = _end + _endmark.Length + 1;
                            }
                            else
                            {
                                _index = _end + 1;
                            }
                        }
                        else
                        {
                            _index = _start + 1;
                        }
                    }
                    else
                    {
                        _index = pstr.Length + 1;
                    }
                }
            }
            return _ret;
        }

        /// <summary>
        /// ��DataTable����ת����XML�ַ���
        /// </summary>
        /// <param name="dt">DataTable����</param>
        /// <returns>XML�ַ���</returns>
        public static string CDataToXml(DataTable dt)
        {
            if (dt != null)
            {
                MemoryStream ms = null;
                XmlTextWriter XmlWt = null;
                try
                {
                    ms = new MemoryStream();
                    //����msʵ����XmlWt
                    XmlWt = new XmlTextWriter(ms, Encoding.Unicode);
                    //��ȡds�е�����
                    dt.WriteXml(XmlWt);
                    int count = (int)ms.Length;
                    byte[] temp = new byte[count];
                    ms.Seek(0, SeekOrigin.Begin);
                    ms.Read(temp, 0, count);
                    //����Unicode������ı�
                    UnicodeEncoding ucode = new UnicodeEncoding();
                    string returnValue = ucode.GetString(temp).Trim();
                    return returnValue;
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    //�ͷ���Դ
                    if (XmlWt != null)
                    {
                        XmlWt.Close();
                        ms.Close();
                        ms.Dispose();
                    }
                }
            }
            else
            {
                return "";
            }
        }
        //// <summary>
        /// ��Xml�����ַ���ת����DataSet����
        /// </summary>
        /// <param name="xmlStr">Xml�����ַ���</param>
        /// <returns>DataSet����</returns>
        public static DataSet CXmlToDataSet(string xmlStr)
        {
            if (!string.IsNullOrEmpty(xmlStr))
            {
                StringReader StrStream = null;
                XmlTextReader Xmlrdr = null;
                try
                {
                    DataSet ds = new DataSet();
                    //��ȡ�ַ����е���Ϣ
                    StrStream = new StringReader(xmlStr);
                    //��ȡStrStream�е�����
                    Xmlrdr = new XmlTextReader(StrStream);

                    //ds��ȡXmlrdr�е�����                
                    ds.ReadXml(Xmlrdr);
                    return ds;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    //�ͷ���Դ
                    if (Xmlrdr != null)
                    {
                        Xmlrdr.Close();
                        StrStream.Close();
                        StrStream.Dispose();
                    }
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// XMLתΪDictionary<string,string>
        /// </summary>
        /// <param name="pstr"></param>
        /// <returns></returns>
        public static Dictionary<string, string> XMLToDictionary(string pstr)
        {
            int _index, _start, _end, em_start;
            string _mark, _endmark;
            Dictionary<string, string> _ret = new Dictionary<string, string>();
            _index = 0;
            while (_index < pstr.Length)
            {
                _start = pstr.IndexOf('<', _index);
                if (_start >= 0)
                {
                    _end = pstr.IndexOf('>', _start);
                    if (_end >= 0)
                    {
                        _mark = pstr.Substring(_start + 1, _end - _start - 1);
                        _endmark = string.Format("</{0}>", _mark);
                        em_start = pstr.IndexOf(_endmark, _end + 1);
                        if (em_start >= 0)
                        {
                            string value = pstr.Substring(_end + 1, em_start - _end - 1);
                            _ret.Add(_mark, value);
                            _index = _end + _endmark.Length + 1;
                        }
                        else
                        {
                            _index = _end + 1;
                        }
                    }
                    else
                    {
                        _index = _start + 1;
                    }
                }
                else
                {
                    _index = pstr.Length + 1;
                }
            }

            return _ret;
        }

        /// <summary>
        /// ��ָ���ֵ����Ͳ������л�ΪXML�ַ���,����<name>value</name>
        /// </summary>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static string DicToXMLString(Dictionary<string, object> paras)
        {
            string str = "";
            if (paras != null)
            {
                foreach (var p in paras)
                {
                    object _value = "";
                    if (p.Value != null && p.Value.GetType() == typeof(DateTime))
                    {
                        DateTime _dt = DateTime.MinValue;
                        DateTime.TryParse(p.Value.ToString(), out _dt);
                        _value = _dt.ToString("yyyyMMddHHmmss");
                    }
                    else
                        _value = p.Value;
                    str += "<" + p.Key + ">" + _value + "</" + p.Key + ">";
                }
            }
            return str;
        }

        /// <summary>
        /// ��ָ���ֵ����Ͳ������л�ΪXML�ַ���,����<name>value</name>
        /// </summary>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static string DicToXMLString(Dictionary<string, string> paras)
        {
            string str = "";
            if (paras != null)
            {
                foreach (var p in paras)
                {
                    str += "<" + p.Key + ">" + p.Value + "</" + p.Key + ">";
                }
            }
            return str;
        }
        /// <summary>
        /// �ж��ַ����Ƿ��пո�
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        static public bool IsSpace(string TableName)//�����
        {
            TableName = StrUtils.ConvertToNarrow(TableName);
            if (TableName.IndexOf(' ') > -1)
            {
                return true;
            }
            return false;
        }
        public static List<string> GetGroupItemsByFlag(string str, char flag)//�����
        {
            List<string> _ret = new List<string>();
            int _index = 0;
            while (_index < str.Length)
            {
                int _start = str.IndexOf(flag, _index);
                if (_start >= 0 && _start < str.Length)
                {
                    int _end = str.IndexOf(flag, _start + 1);
                    if (_end >= 0)
                    {
                        _ret.Add(str.Substring(_start, _end - _start + 1));
                        _index = _end + 1;
                    }
                    else
                    {
                        _index = str.Length + 1;
                    }
                }
                else
                {
                    _index = str.Length + 1;
                }
            }
            return _ret;
        }

        /// <summary>
        /// ��stringתDateTime
        /// </summary>
        /// <param name="_date"></param>
        /// <returns></returns>
        public static DateTime String2Date(string _date)
        {
            if (string.IsNullOrEmpty(_date)) return DateTime.MinValue;
            string _lsdate = _date.Replace("��", "");
            _lsdate = _lsdate.Replace("��", "");
            _lsdate = _lsdate.Replace("��", "");
            _lsdate = _lsdate.Replace("/", "");
            _lsdate = _lsdate.Replace("-", "");
            _lsdate = _lsdate.Replace(" ", "");//�滻�ո�
            _lsdate = _lsdate.Replace(":", "");
            switch (_lsdate.Length)
            {
                case 4:
                    int _year4 = int.Parse(_lsdate.Substring(0, 4));
                    return new DateTime(_year4, 1, 1);
                case 6:
                    int _year6 = int.Parse(_lsdate.Substring(0, 4));
                    int _month6 = int.Parse(_lsdate.Substring(4, 2));
                    return new DateTime(_year6, _month6, 1);
                case 8:
                    int _year8 = int.Parse(_lsdate.Substring(0, 4));
                    int _month8 = int.Parse(_lsdate.Substring(4, 2));
                    int _day8 = int.Parse(_lsdate.Substring(6, 2));
                    return new DateTime(_year8, _month8, _day8);
                case 14:
                    int _year14 = int.Parse(_lsdate.Substring(0, 4));
                    int _month14 = int.Parse(_lsdate.Substring(4, 2));
                    int _day14 = int.Parse(_lsdate.Substring(6, 2));
                    int _hour = int.Parse(_lsdate.Substring(8, 2));
                    int _min = int.Parse(_lsdate.Substring(10, 2));
                    int _sec = int.Parse(_lsdate.Substring(12, 2));
                    return new DateTime(_year14, _month14, _day14, _hour, _min, _sec);
                default:
                    return DateTime.MinValue;
            }
        }

        /// <summary>
        /// ������ҳ��sql���
        /// </summary>
        /// <param name="sql">Դsql���</param>
        /// <param name="pageIndex">ҳ��</param>
        /// <param name="pageSize">ÿҳ�ļ�¼��</param>
        /// <param name="sortBy">�����ֶ�</param>
        /// <param name="sortDirection">������(ASC,DESC)</param>
        /// <returns></returns>
        public static string BuildPagingSQL(string sql, decimal pageIndex, decimal pageSize, string sortBy, string sortDirection)
        {
            StringBuilder _str = new StringBuilder();
            if (!string.IsNullOrEmpty(sortBy))
            {
                sql = " select * from (\n " + sql + " \n) order by " + sortBy + " " + sortDirection;
            }
            _str.Append(" select t_1.* from ");
            _str.Append(" ( select rownum r_0,t_0.* from ");
            _str.Append(" (\n " + sql + " \n) t_0 ");
            _str.Append(" where rownum <= " + (pageIndex * pageSize) + " ) t_1 ");
            _str.Append(" where r_0 > " + (pageIndex - 1) * pageSize);
            return _str.ToString();
        }

        public static int IndexOfComma(string Data)
        {
            string s = @".";
            string s2 = @"" + Data;

            Regex re = new Regex(Regex.Escape(s), RegexOptions.IgnoreCase | RegexOptions.Singleline);
            MatchCollection mc = re.Matches(s2);
            return mc.Count;
        }

        public static string GetXMLContent2(XmlDocument doc, string FNode, string CNodeName)
        {
            XmlNodeList elemList = doc.GetElementsByTagName(FNode);
            if (elemList.Count > 0)
            {
                XmlNode cnode = elemList[0];
                foreach (XmlNode _n in cnode.ChildNodes)
                {
                    if (_n.Name == CNodeName)
                    {
                        return _n.InnerXml;
                    }
                }
                return "";
            }
            else
            {
                return "";
            }
        }

        public static string GetXMLContent(XmlDocument doc, string NodeName)
        {
            XmlNodeList elemList = doc.GetElementsByTagName(NodeName);
            if (elemList.Count > 0)
            {
                return elemList[0].InnerXml;
            }
            else
            {
                return "";
            }
        }


        public static string EncodeByDESC(string Data, string EncryptKey)
        {
            byte[] rgbKey, rgbIV, inputByteArray;
            byte[] Keys = { 0x13, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            try
            {
                rgbKey = Encoding.ASCII.GetBytes(EncryptKey.Length > 8 ? EncryptKey.Substring(0, 8) : EncryptKey);
                rgbIV = Keys;
                inputByteArray = System.Text.Encoding.Unicode.GetBytes(Data);
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    //�趨����Կ 
                    des.Key = rgbKey;
                    //�趨��ʼ������ 
                    des.IV = rgbIV;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(inputByteArray, 0, inputByteArray.Length);
                            cs.FlushFinalBlock();
                        }
                        //��������ֽ�
                        string _ret = Convert.ToBase64String(ms.ToArray());
                        return _ret;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("�����ַ�������{0}", ex.Message));
            }
        }

        public static string DecodeByDESC(string Data, string EncryptKey)
        {
            byte[] rgbKey, rgbIV, inputByteArray;
            byte[] Keys = { 0x13, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

            try
            {
                rgbKey = Encoding.ASCII.GetBytes(EncryptKey.Length > 8 ? EncryptKey.Substring(0, 8) : EncryptKey);
                rgbIV = Keys;
                inputByteArray = Convert.FromBase64String(Data);
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    //�趨����Կ 
                    des.Key = rgbKey;
                    //�趨��ʼ������ 
                    des.IV = rgbIV;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            try
                            {
                                cs.Write(inputByteArray, 0, inputByteArray.Length);
                                cs.FlushFinalBlock();
                                //ݔ���Y�� 
                                string _ret = System.Text.Encoding.Unicode.GetString(ms.ToArray());
                                return _ret;
                            }
                            catch
                            {
                                throw;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("�����ַ�������{0}", ex.Message));
            }
        }


    }
}
