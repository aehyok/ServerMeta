using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SinoSZJS.Base.Report
{
        public class ChangeReportDataAsXML
        {
                static public string Change(DataTable _dt)
                {
                        StringBuilder _ret = new StringBuilder();
                        _ret.AppendLine("<?xml ...?>");
                        _ret.AppendLine("<ReportData>");
                        int _rowIndex = 0;

                        foreach (DataRow _dr in _dt.Rows)
                        {
                                string _lineName = string.Format("LINE{0}", _rowIndex++);
                                _ret.AppendLine(string.Format("<{0}>", _lineName));
                                foreach (DataColumn _dc in _dt.Columns)
                                {
                                        _ret.AppendLine(string.Format("<{0}>", _dc.ColumnName));
                                        string _value = _dr.IsNull(_dc.ColumnName) ? "" : _dr[_dc.ColumnName].ToString();
                                        _ret.AppendLine(_value);
                                        _ret.AppendLine(string.Format("</{0}>", _dc.ColumnName));
                                }
                                _ret.AppendLine(string.Format("</{0}>", _lineName));
                        }
                        _ret.AppendLine("</ReportData>");
                        return _ret.ToString();                         
                }
        }
}
