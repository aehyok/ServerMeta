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
                        _sf.Filter = "JPG�ļ�|*.jpg|Excle�ļ�|*.xls|HTML�ļ�|*.mht|BMP�ļ�|*.bmp|PNG�ļ�|*.png";
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
                                                XtraMessageBox.Show("�����뵼���ļ�����", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
