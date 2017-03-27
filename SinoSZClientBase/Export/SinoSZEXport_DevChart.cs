using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraCharts;
using System.Drawing.Imaging;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SinoSZClientBase.Export
{
        public class SinoSZEXport_DevChart
        {
                public static bool Export(ChartControl _chart)
                {
                        SaveFileDialog _sf = new SaveFileDialog();
                        _sf.Filter = "JPG文件|*.jpg|Excle文件|*.xls|HTML文件|*.mht|BMP文件|*.bmp|PNG文件|*.png";
                        _sf.FilterIndex = 1;
                        string _fname = "";
                        while (_fname == "")
                        {
                                if (_sf.ShowDialog() == DialogResult.OK)
                                {
                                        _fname = _sf.FileName;
                                        if (_fname != "")
                                        {
                                                switch (_sf.FilterIndex)
                                                {
                                                        case 1:
                                                                _chart.ExportToImage(_fname, ImageFormat.Jpeg);
                                                                break;
                                                        case 2:
                                                                _chart.ExportToXls(_fname);                                                             
                                                                break;
                                                        case 3:
                                                                _chart.ExportToMht(_fname);
                                                                break;
                                                        case 4:
                                                                _chart.ExportToImage(_fname, ImageFormat.Bmp);
                                                                break;                                                        
                                                        case 5:
                                                                _chart.ExportToImage(_fname, ImageFormat.Png);
                                                                break;
                                                }

                                                return true;
                                        }
                                        else
                                        {
                                                XtraMessageBox.Show("请输入导出文件名！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                }
                                else
                                {
                                        return false;
                                }
                        }
                        return false;
                }
        }
}
