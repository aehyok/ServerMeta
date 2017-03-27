using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZClientSysManager.TaskManager
{
        public class TaskParameter
        {
                protected string paramName = "";
                protected string paramValue = "";
                protected string displayTitle = "";
                public string ParamName { get { return paramName; } set { paramName = value; } }
                public string ParamValue { get { return paramValue; } set { paramValue = value; } }
                public string DisplayTitle { get { return displayTitle; } set { displayTitle = value; } }

                public TaskParameter() { }
                public TaskParameter(string name, string value, string title)
                {
                        ParamName = name;
                        ParamValue = value;
                        DisplayTitle = title;
                }

                public static List<TaskParameter> GetParamList(string pstr)
                {
                        int _index, _start, _end, em_start, em_end;
                        string _mark, _endmark;
                        List<TaskParameter> _ret = new List<TaskParameter>();
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
                                                        _ret.Add(new TaskParameter(_mark, value, _mark));
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
        }
}
