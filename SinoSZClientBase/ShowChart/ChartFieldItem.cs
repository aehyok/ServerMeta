using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZClientBase.ShowChart
{
        /// <summary>
        /// 图表展示用的字段定义
        /// </summary>
        public class ChartFieldItem
        {
                private string fieldName = "";
                private string displayName = "";
                public string FieldName
                {
                        get { return fieldName; }
                        set { fieldName = value; }
                }

                public string DisplayName
                {
                        get { return displayName; }
                        set { displayName = value; }
                }

                public ChartFieldItem() { }
                public ChartFieldItem(string _fname, string _display)
                {
                        fieldName = _fname;
                        displayName = _display;
                }

                public override string ToString()
                {
                        return displayName;
                }
        }
}
