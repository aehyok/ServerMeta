using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SinoSZClientBase.ShowChart
{
        public interface ChartUC_ICS
        {
                void InitChart(DataTable _dt, string _Xfields, List<string> _Yfields, Dictionary<string, string> _Titles, bool _ShowLable, bool _ShowLegend, bool _ShowAxisYAsLog, bool _CanSelect,int _precision);
                void InitChart(DataTable _dt, string _Xfields, List<string> _Yfields, Dictionary<string, string> _Titles, bool _ShowLable, bool _ShowLegend, bool _ShowAxisYAsLog, bool _CanSelect,int _precision,string _title);
                void Refresh();

                bool ShowLabel { get; set; }
                bool ShowLegend { get;set;}
                bool ShowAxisYAsLog { get;set;}
                bool CanSelect { get;set;}
                int DataPrecision { get;set;}

                bool ExportChart();
        }
}
