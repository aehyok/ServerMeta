using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using System.Web;
using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZMetaDataQuery.Common
{
    public partial class SinoSZUC_RecordData : DevExpress.XtraEditors.XtraUserControl
    {
        private MDModel_Table TableDefine = null;
        private DataRow TableRecordData = null;
        private int _lineCount = 0;
        public SinoSZUC_RecordData()
        {
            InitializeComponent();
        }

        public SinoSZUC_RecordData(MDModel_Table _tableDefine, DataRow _dr)
        {
            InitializeComponent();
            TableDefine = _tableDefine;
            TableRecordData = _dr;
            this.groupControl1.Text = TableDefine.TableDefine.DisplayTitle;
            AddColumns();
        }
        public SinoSZUC_RecordData(MDModel_Table _tableDefine, DataRow _dr, int _num)
        {
            InitializeComponent();
            TableDefine = _tableDefine;
            TableRecordData = _dr;
            this.groupControl1.Text = TableDefine.TableDefine.DisplayTitle + string.Format(" [{0}]", _num);
            AddColumns();
        }

        private void AddColumns()
        {
            this.Height = 40;
            this.groupControl1.Controls.Clear();

            List<MDModel_Table_Column> _columnList = new List<MDModel_Table_Column>();
            foreach (MDModel_Table_Column _tc in TableDefine.Columns)
            {
                if (_tc.ColumnDefine.TableColumn.CanDisplay && _tc.ColumnDefine.CanShowAsResult)
                {
                    _columnList.Add(_tc);
                }
            }
            //排序
            _columnList.Sort(new MDModel_ColumnComparer());

            //显示
            SinoSZUC_DetailLinecs _line = new SinoSZUC_DetailLinecs();
            foreach (MDModel_Table_Column _tc in _columnList)
            {
                if (_tc.ColumnDefine.TableColumn.DisplayLength <= _line.BlankLength)
                {
                    _line.AddItem(_tc, TableRecordData);
                }
                else
                {
                    _line.Dock = DockStyle.Top;
                    this.groupControl1.Controls.Add(_line);
                    this.Height += _line.Height;
                    _lineCount++;
                    _line.BringToFront();
                    _line = new SinoSZUC_DetailLinecs();
                    _line.AddItem(_tc, TableRecordData);
                }
            }

            if (_line.BlankLength < 2)
            {
                _line.Dock = DockStyle.Top;
                this.groupControl1.Controls.Add(_line);
                this.Height += _line.Height;
                _lineCount++;
                _line.BringToFront();
            }


        }


        public float Print(float intX, float intY, System.Drawing.Printing.PrintPageEventArgs e, int _lineHeight, int fullWidth, Font _lineFont)
        {
            float _ret = PrintTitle(intX, intY, e, _lineHeight, fullWidth, _lineFont);
            int _count = this.groupControl1.Controls.Count;
            for (int i = _count; i > 0; i--)
            {
                SinoSZUC_DetailLinecs _cs = this.groupControl1.Controls[i - 1] as SinoSZUC_DetailLinecs;
                _ret += _cs.Print(intX, intY + _ret, e, _lineHeight, fullWidth, _lineFont);
            }
            return _ret;
        }

        private float PrintTitle(float intX, float intY, System.Drawing.Printing.PrintPageEventArgs e, int _lineHeight, int fullWidth, Font _lineFont)
        {
            float _retHeight = _lineHeight;
            Font _drawFont = null;
            Pen _pen = new Pen(Color.Black, 1);
            try
            {
                string _titleStr = this.groupControl1.Text.Trim();
                SizeF stringSize = e.Graphics.MeasureString(_titleStr, _lineFont, fullWidth);
                while (_retHeight < stringSize.Height)
                {
                    _retHeight += _lineHeight;
                }
                float _drawX = intX + 1;
                float _drawY = intY + (_retHeight - stringSize.Height) / 2 + 1;
                e.Graphics.DrawRectangle(_pen, intX, intY, fullWidth, _retHeight);
                _drawFont = new Font(_lineFont.FontFamily, _lineFont.Size, FontStyle.Bold);
                e.Graphics.DrawString(_titleStr, _drawFont, Brushes.Black, _drawX, _drawY);
                _pen = null;
                _drawFont = null;
                return _retHeight;
            }
            finally
            {
                if (_pen != null)
                {
                    _pen.Dispose();
                }
                if (_drawFont != null)
                {
                    _drawFont.Dispose();
                }
            }

        }

        public string ExportHtml()
        {
            StringBuilder _sb = new StringBuilder();
            //导出标题
            string _titleStr = this.groupControl1.Text.Trim();
            _sb.Append("<tr>\n");
            _sb.Append("<td colspan=4 style='background:#99CCFF;'>");
            _sb.Append(HttpUtility.HtmlEncode(_titleStr));
            _sb.Append("</td>");
            _sb.Append("</tr>");

            //导出记录
            int _count = this.groupControl1.Controls.Count;
            for (int i = _count; i > 0; i--)
            {
                SinoSZUC_DetailLinecs _cs = this.groupControl1.Controls[i - 1] as SinoSZUC_DetailLinecs;
                _sb.Append(_cs.ExportHtml());
            }

            return _sb.ToString();
        }


    }
}
