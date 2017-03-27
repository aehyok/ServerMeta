using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace SinoSZClientBase.ShowChart
{
        public class DevChartClass
        {

                public static Control CreateBarChart(DataTable _dt, string _Xfields, List<string> _Yfields, Dictionary<string, string> _Titles, bool _canSelect, int _precision)
                {
                        return CreateBarChart(_dt, _Xfields, _Yfields, _Titles, _canSelect,  _precision,true);
                }

                public static Control CreateBarChart(DataTable _dt, string _Xfields, List<string> _Yfields, Dictionary<string, string> _Titles, bool _canSelect,int _precision,bool _ShowLable)
                {
                        ChartUC_Bar _ret = new ChartUC_Bar();
                        _ret.InitChart(_dt, _Xfields, _Yfields, _Titles, _ShowLable, true, false, _canSelect, _precision);
                        _ret.Dock = DockStyle.Fill;
                        return _ret;
                }

                public static Control CreateLineChart(DataTable _dt, string _Xfields, List<string> _Yfields, Dictionary<string, string> _Titles, bool _canSelect,int _precision)
                {
                        return CreateLineChart(_dt, _Xfields, _Yfields, _Titles, _canSelect,  _precision,true);
                }

                public static Control CreateLineChart(DataTable _dt, string _Xfields, List<string> _Yfields, Dictionary<string, string> _Titles, bool _canSelect, int _precision,bool _ShowLable)
                {
                        ChartUC_Line _ret = new ChartUC_Line();
                        _ret.InitChart(_dt, _Xfields, _Yfields, _Titles, _ShowLable, true, false, _canSelect, _precision);
                        _ret.Dock = DockStyle.Fill;
                        return _ret;
                }


                public static Control CreatePieChart(DataTable _dt, string _Xfields, List<string> _Yfields, Dictionary<string, string> _Titles, bool _canSelect,int _precision)
                {
                        return CreatePieChart(_dt, _Xfields, _Yfields, _Titles, _canSelect, _precision, true);
                }

                public static Control CreatePieChart(DataTable _dt, string _Xfields, List<string> _Yfields, Dictionary<string, string> _Titles, bool _canSelect, int _precision,bool _ShowLable)
                {
                        ChartUC_Pie _ret = new ChartUC_Pie();
                        _ret.InitChart(_dt, _Xfields, _Yfields, _Titles, _ShowLable, true, false, _canSelect, _precision);
                        _ret.Dock = DockStyle.Fill;
                        return _ret;
                }

              

        }
}
