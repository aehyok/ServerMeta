using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Drawing;

namespace SinoSZMetaDataQuery.Common
{
    public class PrintDetailInfoPanel
    {
        public enum FontType
        {
            Small,					//	小型， 宋体 9号字
            Large,					//	大型， 宋体 16号字
            Default					//	正常， 宋体 12号字
        }

        private XtraScrollableControl _panel;
        private int _lineHeight = 15;  //行高
        private Font _lineFont = null;	//行字体
        private int _finishNum = 0;
        private int _currentNum = 0;

        public PrintDetailInfoPanel(XtraScrollableControl _p)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            _panel = _p;
        }

        public PrintDetailInfoPanel(XtraScrollableControl _p, int _lineheight, Font _font)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            _panel = _p;
            _lineHeight = _lineheight;
            _lineFont = _font;
        }

        public PrintDetailInfoPanel(XtraScrollableControl _p, FontType _ftype)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            _panel = _p;
            Font UseFont = null;

            switch (_ftype)
            {
                case FontType.Default:
                    _lineHeight = 15;  //行高
                    UseFont = new Font("宋体", 12, FontStyle.Regular);	//行字体
                    _lineFont = UseFont;
                    break;
                case FontType.Large:
                    _lineHeight = 20;  //行高
                    UseFont = new Font("宋体", 16, FontStyle.Regular);	//行字体
                    _lineFont = UseFont;
                    break;
                case FontType.Small:
                    _lineHeight = 12;  //行高
                    UseFont = new Font("宋体", 9, FontStyle.Regular);	//行字体
                    _lineFont = UseFont;
                    break;

            }

        }
        private void PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float _ret;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;

            int fullWidth = e.MarginBounds.Width;

            float intX = leftMargin;
            float intY = topMargin;
            _currentNum = 0;

            for (int i = _panel.Controls.Count; i > 0; i--)
            {
                SinoSZUC_RecordData _currentRecordData = null;
                _ret = _lineHeight;
                object _uc = _panel.Controls[i - 1];
                if (_uc.GetType() == typeof(SinoSZUC_RecordData))
                {
                    //标题栏
                    _currentRecordData = (SinoSZUC_RecordData)_uc;

                    if (++_currentNum > _finishNum)
                    {
                        _ret = _currentRecordData.Print(intX, intY, e, _lineHeight, fullWidth, _lineFont);
                        intY += _ret;
                    }
                }


                if (_uc.GetType() == typeof(Panel))
                {
                    Panel _pc = (Panel)_uc;
                    if (_pc.Visible)
                    {
                        _ret = PrintChild(_pc, intX, intY, fullWidth, e);
                        intY += _ret;
                    }
                }

                if (intY > (e.MarginBounds.Top + e.MarginBounds.Height))
                {
                    e.HasMorePages = true;
                    _finishNum = _currentNum;
                    intY = topMargin;
                    return;
                }

            }
            _finishNum = 0;
        }

        private float PrintChild(Panel _panel, float _intX, float _intY, int _fullwidth, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float _ret, _result = 0;
            float intX = _intX;
            float intY = _intY;
            for (int i = _panel.Controls.Count; i > 0; i--)
            {
                _ret = _lineHeight;
                object _uc = _panel.Controls[i - 1];
                if (_uc.GetType() == typeof(SinoSZUC_RecordData))
                {
                    //标题栏
                    SinoSZUC_RecordData _mc = (SinoSZUC_RecordData)_uc;
                    if (++_currentNum > _finishNum)
                    {
                        _ret = _mc.Print(intX, intY, e, _lineHeight, _fullwidth, _lineFont);
                        intY += _ret;
                        _result += _ret;
                    }
                }


                if (intY > (e.MarginBounds.Top + e.MarginBounds.Height))
                {
                    e.HasMorePages = true;
                    _finishNum = _currentNum;
                    return _result;

                }

            }
            return _result;
        }

        public void Print()
        {
            using (PrintDocument docToPrint = new System.Drawing.Printing.PrintDocument())
            {
                docToPrint.DocumentName = "详细信息";
                docToPrint.PrintPage += new PrintPageEventHandler(PrintPage);

                PrintDialog PrintDialog1 = new PrintDialog();

                PrintDialog1.AllowSomePages = true;
                PrintDialog1.ShowHelp = true;
                PrintDialog1.Document = docToPrint;


                PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
                printPreviewDialog1.Document = docToPrint;

                DialogResult result = printPreviewDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    docToPrint.Print();
                }
            }
        }


    }
}
