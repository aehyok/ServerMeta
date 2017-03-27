using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SinoSZClientReport.DataCheck
{
        public class Meta_TableFieldBuilder
        {
                public Meta_TableFieldBuilder()
                {
                        //
                        // TODO: 在此处添加构造函数逻辑
                        //
                }

                public static string CreateTableHisFields(DataRow[] _rows, string _tname, DataTable _HTMeta)
                {
                        string _res = "";
                        string _dmb = "";
                        string _fname = "";
                        foreach (DataRow _row in _rows)
                        {
                                _fname = _row["COLUMNNAME"].ToString();
                                DataRow[] _findrow = _HTMeta.Select(string.Format("COLUMN_NAME = '{0}'", _fname));
                                if (_findrow.Length > 0)
                                {
                                        if (_row.IsNull("REFDMB")) _dmb = "";
                                        else _dmb = _row["REFDMB"].ToString();

                                        if (_dmb != "")
                                        {
                                                _res = _res + string.Format(",ZHCX.GETCT(TO_CHAR({0}.{1}),'{2}') {1}", _tname, _fname, _dmb);
                                        }
                                        else
                                        {
                                                _res = _res + string.Format(",{0}.{1} {1}", _tname, _fname);

                                        }
                                }
                        }
                        if (_res.Length < 1) return "*";
                        else return _res.Substring(1);

                }

                public static string CreateTableFields(DataRow[] _rows, string _tname)
                {
                        string _res = "";
                        string _dmb = "";
                        string _fname = "";
                        foreach (DataRow _row in _rows)
                        {
                                _fname = _row["COLUMNNAME"].ToString();
                                if (_row.IsNull("REFDMB")) _dmb = "";
                                else _dmb = _row["REFDMB"].ToString();

                                if (_dmb != "")
                                {
                                        _res = _res + string.Format(",ZHCX.GETCT(TO_CHAR({0}.{1}),'{2}') {1}", _tname, _fname, _dmb);
                                }
                                else
                                {
                                        _res = _res + string.Format(",{0}.{1} {1}", _tname, _fname);

                                }
                        }
                        if (_res.Length < 1) return "*";
                        else return _res.Substring(1);

                }
        }
}
