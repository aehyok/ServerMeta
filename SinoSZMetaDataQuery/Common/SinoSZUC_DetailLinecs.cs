using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Web;
using DevExpress.XtraEditors;
using System.IO;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZClientBase.MetaDataQueryService;

namespace SinoSZMetaDataQuery.Common
{
    public partial class SinoSZUC_DetailLinecs : UserControl
    {
        private int _blankLength = 2;

        //空余的位置数
        public int BlankLength
        {
            get { return _blankLength; }
        }


        public SinoSZUC_DetailLinecs()
        {
            InitializeComponent();
        }

        private void SinoSZUC_DetailLinecs_Resize(object sender, EventArgs e)
        {
            this.LeftPanel.Width = this.Width / 2;
        }

        public void AddItem(MDModel_Table_Column _tc, DataRow TableRecordData)
        {
            if (_tc.ColumnDefine.TableColumn.DisplayLength > _blankLength)
            {
                return;
            }

            if (_tc.ColumnDataType == "附件下载")
            {
                AddDownloadItem(_tc, TableRecordData);
                return;
            }

            if (_tc.ColumnDataType == "法律文书下载")
            {
                AddFLWSDownloadItem(_tc, TableRecordData);
                return;
            }

            if (_tc.ColumnDefine.TableColumn.DisplayLength >= 2)
            {
                this.RightPanel.Visible = false;
                this.LeftPanel.Visible = true;
                this.LeftPanel.Dock = DockStyle.Fill;
                this.LeftLabel.Text = _tc.ColumnTitle;
                if (_tc.ColumnDefine.TableColumn.DisplayHeight > 1)
                {
                    this.Height = 22 * _tc.ColumnDefine.TableColumn.DisplayHeight;
                    this.LeftText.Visible = false;
                    this.LeftMemo.Visible = true;
                    this.LeftMemo.EditValue = ShowData(_tc, TableRecordData);
                }
                else
                {
                    this.LeftMemo.Visible = false;
                    this.LeftText.Visible = true;
                    this.LeftText.EditValue = ShowData(_tc, TableRecordData);
                    this.LeftText.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                }
                this._blankLength = 0;
            }
            else
            {
                if (this.BlankLength == 2)
                {
                    this.LeftLabel.Text = _tc.ColumnTitle;
                    this.LeftMemo.Visible = false;
                    this.LeftText.Visible = true;
                    this.LeftText.EditValue = ShowData(_tc, TableRecordData);
                    this._blankLength = 1;
                }
                else
                {
                    this.RightLabel.Text = _tc.ColumnTitle;
                    this.RightText.Visible = true;
                    this.RightText.EditValue = ShowData(_tc, TableRecordData);
                    this._blankLength = 0;
                }
            }

        }

        private void AddFLWSDownloadItem(MDModel_Table_Column _tc, DataRow TableRecordData)
        {
            if (_tc.ColumnDefine.TableColumn.DisplayLength >= 2)
            {
                this.RightPanel.Visible = false;
                this.LeftPanel.Visible = true;
                this.LeftPanel.Dock = DockStyle.Fill;
                this.LeftLabel.Text = _tc.ColumnTitle;
                this.LeftMemo.Visible = false;
                this.LeftText.Visible = false;

                HyperLinkEdit _link = new HyperLinkEdit();
                _link.Properties.AutoHeight = false;
                _link.Dock = DockStyle.Fill;
                _link.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                _link.Properties.Appearance.Options.UseTextOptions = true;
                this.LeftPanel.Controls.Add(_link);
                _link.BringToFront();
                _link.Text = "下载法律文书";
                _link.Tag = TableRecordData[_tc.ColumnAlias] + "," + _tc.ColumnDefine.TableColumn.RefWordTableName;
                _link.Click += new EventHandler(FLWSAttachmentDownload_Click);
                this._blankLength = 0;
            }
            else
            {
                if (this.BlankLength == 2)
                {
                    this.LeftLabel.Text = _tc.ColumnTitle;
                    this.LeftMemo.Visible = false;
                    this.LeftText.Visible = false;
                    HyperLinkEdit _link = new HyperLinkEdit();
                    _link.Properties.AutoHeight = false;
                    _link.Dock = DockStyle.Fill;
                    _link.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    _link.Properties.Appearance.Options.UseTextOptions = true;
                    this.LeftPanel.Controls.Add(_link);
                    _link.BringToFront();
                    _link.Text = "下载法律文书";
                    _link.Tag = TableRecordData[_tc.ColumnAlias] + "," + _tc.ColumnDefine.TableColumn.RefWordTableName;
                    _link.Click += new EventHandler(FLWSAttachmentDownload_Click);
                    this._blankLength = 1;
                }
                else
                {
                    this.RightLabel.Text = _tc.ColumnTitle;
                    this.RightText.Visible = false;
                    HyperLinkEdit _link = new HyperLinkEdit();
                    _link.Properties.AutoHeight = false;
                    _link.Dock = DockStyle.Fill;
                    _link.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    _link.Properties.Appearance.Options.UseTextOptions = true;
                    this.RightPanel.Controls.Add(_link);
                    _link.BringToFront();
                    _link.Text = "下载法律文书";
                    _link.Tag = TableRecordData[_tc.ColumnAlias] + "," + _tc.ColumnDefine.TableColumn.RefWordTableName;
                    _link.Click += new EventHandler(FLWSAttachmentDownload_Click);
                    this._blankLength = 0;
                }
            }
        }

        private void AddDownloadItem(MDModel_Table_Column _tc, DataRow TableRecordData)
        {
            if (_tc.ColumnDefine.TableColumn.DisplayLength >= 2)
            {
                this.RightPanel.Visible = false;
                this.LeftPanel.Visible = true;
                this.LeftPanel.Dock = DockStyle.Fill;
                this.LeftLabel.Text = _tc.ColumnTitle;
                this.LeftMemo.Visible = false;
                this.LeftText.Visible = false;

                HyperLinkEdit _link = new HyperLinkEdit();
                _link.Properties.AutoHeight = false;
                _link.Dock = DockStyle.Fill;
                _link.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                _link.Properties.Appearance.Options.UseTextOptions = true;
                this.LeftPanel.Controls.Add(_link);
                _link.BringToFront();
                _link.Text = "下载附件";
                _link.Tag = TableRecordData[_tc.ColumnAlias] + "," + _tc.ColumnDefine.TableColumn.RefWordTableName + "," + _tc.ColumnDefine.TableColumn.DisplayFormat;
                _link.Click += new EventHandler(AttachmentDownload_Click);
                this._blankLength = 0;
            }
            else
            {
                if (this.BlankLength == 2)
                {
                    this.LeftLabel.Text = _tc.ColumnTitle;
                    this.LeftMemo.Visible = false;
                    this.LeftText.Visible = false;
                    HyperLinkEdit _link = new HyperLinkEdit();
                    _link.Properties.AutoHeight = false;
                    _link.Dock = DockStyle.Fill;
                    _link.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    _link.Properties.Appearance.Options.UseTextOptions = true;
                    this.LeftPanel.Controls.Add(_link);
                    _link.BringToFront();
                    _link.Text = "下载附件";
                    _link.Tag = TableRecordData[_tc.ColumnAlias] + "," + _tc.ColumnDefine.TableColumn.RefWordTableName + "," + _tc.ColumnDefine.TableColumn.DisplayFormat;
                    _link.Click += new EventHandler(AttachmentDownload_Click);
                    this._blankLength = 1;
                }
                else
                {
                    this.RightLabel.Text = _tc.ColumnTitle;
                    this.RightText.Visible = false;
                    HyperLinkEdit _link = new HyperLinkEdit();
                    _link.Properties.AutoHeight = false;
                    _link.Dock = DockStyle.Fill;
                    _link.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    _link.Properties.Appearance.Options.UseTextOptions = true;
                    this.RightPanel.Controls.Add(_link);
                    _link.BringToFront();
                    _link.Text = "下载附件";
                    _link.Tag = TableRecordData[_tc.ColumnAlias] + "," + _tc.ColumnDefine.TableColumn.RefWordTableName + "," + _tc.ColumnDefine.TableColumn.DisplayFormat;
                    _link.Click += new EventHandler(AttachmentDownload_Click);
                    this._blankLength = 0;
                }
            }
        }


        void FLWSAttachmentDownload_Click(object sender, EventArgs e)
        {
            Control _te = sender as Control;
            string _tagString = (_te.Tag == null) ? "" : _te.Tag.ToString();
            string[] _strs = _tagString.Split(',');
            if (_strs.Length < 4)
            {
                XtraMessageBox.Show(string.Format("下载法律文书失败！错误的参数信息：{0}", _tagString), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
            {
                string _indexString = _strs[0];
                SaveFileDialog _f = new SaveFileDialog();
                _f.FileName = _msc.GetFLWSFileName(_indexString, _strs[1] + "," + _strs[2]);
                if (_f.ShowDialog() == DialogResult.OK)
                {
                    byte[] _fileBytes = _msc.GetFLWSFileBytes(_indexString, _strs[3]);
                    if (_fileBytes == null)
                    {
                        XtraMessageBox.Show("下载法律文书失败！取得的附件数据为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    FileStream stream = File.OpenWrite(_f.FileName);
                    int _count = _fileBytes.Length;
                    stream.Write(_fileBytes, 0, _count);
                    stream.Close();
                    XtraMessageBox.Show("下载法律文书成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }
        void AttachmentDownload_Click(object sender, EventArgs e)
        {
            Control _te = sender as Control;
            string _tagString = (_te.Tag == null) ? "" : _te.Tag.ToString();
            string[] _strs = _tagString.Split(',');
            if (_strs.Length < 3)
            {
                XtraMessageBox.Show(string.Format("下载失败！错误的参数信息：{0}", _tagString), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string _indexString = _strs[0];
            SaveFileDialog _f = new SaveFileDialog();
            using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
            {
                _f.FileName = _msc.GetAttachFileName(_indexString, _strs[2]);
                if (_f.ShowDialog() == DialogResult.OK)
                {
                    byte[] _fileBytes = _msc.GetAttachFileBytes(_indexString, _strs[1]);
                    if (_fileBytes == null)
                    {
                        XtraMessageBox.Show("下载失败！取得的附件数据为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    FileStream stream = File.OpenWrite(_f.FileName);
                    int _count = _fileBytes.Length;
                    stream.Write(_fileBytes, 0, _count);
                    stream.Close();
                    XtraMessageBox.Show("下载成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private object ShowData(MDModel_Table_Column _tc, DataRow TableRecordData)
        {
            if (TableRecordData == null) return "";

            switch (_tc.ColumnDataType)
            {
                case "DATE":
                    if (!TableRecordData.IsNull(_tc.ColumnAlias))
                    {
                        DateTime _dt = (DateTime)TableRecordData[_tc.ColumnAlias];
                        if (_dt.Hour == 0 && _dt.Minute == 0 && _dt.Second == 0)
                        {
                            return _dt.ToString("yyyy年MM月dd日");
                        }
                        else
                        {
                            return _dt.ToString("yyyy年MM月dd日 HH:mm:ss");
                        }
                    }
                    else
                    {
                        return TableRecordData[_tc.ColumnAlias];
                    }
                    break;

                case "附件下载":
                    return "下载";
                    break;
                default:
                    return TableRecordData[_tc.ColumnAlias];

            }
            return TableRecordData[_tc.ColumnAlias];
        }

        public bool SingleItem
        {
            get
            {
                return !this.RightPanel.Visible;
            }
        }
        public float Print(float x, float y, System.Drawing.Printing.PrintPageEventArgs e, int _lineheight, int fullwidth, Font _font)
        {
            SizeF t1, t2, s1, s2;
            float _retHeight = _lineheight;
            SolidBrush UseBrush = null;
            Pen _pen = null;
            try
            {
                UseBrush = new SolidBrush(Color.LightGray);
                SolidBrush _Brush = UseBrush;
                float Maxheight;
                int _datawidth, _datawidth2;
                float _drawX = x + 1;
                float _drawY;
                int _titlewidth = 100;

                if (SingleItem)
                {
                    _datawidth2 = _datawidth = (fullwidth - _titlewidth);
                }
                else
                {
                    _datawidth = (fullwidth - _titlewidth * 2) / 2;
                    _datawidth2 = fullwidth - _titlewidth * 2 - _datawidth;
                }

                _pen = new Pen(Color.Black, 1);

                object _leftobj = (this.LeftText.Visible) ? this.LeftText.EditValue : this.LeftMemo.EditValue;
                string _leftData = (_leftobj == null) ? "" : _leftobj.ToString().Trim();
                string _rightData = (this.RightText.EditValue == null) ? "" : this.RightText.EditValue.ToString().Trim();
                string _leftLable = this.LeftLabel.Text.Trim();
                string _rightLable = this.RightLabel.Text.Trim();

                //取最大行
                t1 = e.Graphics.MeasureString(_leftLable, _font, _titlewidth);
                t2 = e.Graphics.MeasureString(_rightLable, _font, _titlewidth);
                s1 = e.Graphics.MeasureString(_leftData, _font, _datawidth);
                s2 = e.Graphics.MeasureString(_rightData, _font, _datawidth);
                float MaxLabelHeight = Math.Max(t1.Height, t2.Height);
                float MaxDataHeight = Math.Max(s1.Height, s2.Height);
                Maxheight = Math.Max(MaxLabelHeight, MaxDataHeight);

                while (_retHeight < Maxheight)
                {
                    _retHeight += _lineheight;
                }

                if (SingleItem)
                {	//单列
                    //画标题格                               
                    e.Graphics.DrawRectangle(_pen, x, y, _titlewidth, _retHeight);
                    e.Graphics.FillRectangle(_Brush, x + 1, y + 1, _titlewidth - 1, _retHeight - 1);
                    //画数据格
                    e.Graphics.DrawRectangle(_pen, x + _titlewidth, y, _datawidth, _retHeight);

                    //写标题
                    _drawX = x + (_titlewidth - t1.Width) / 2;
                    _drawY = y + (_retHeight - t1.Height) / 2 + 1;
                    e.Graphics.DrawString(_leftLable, _font, Brushes.Black, new RectangleF(new PointF(_drawX, _drawY), t1));
                    //写数据
                    _drawY = y + (_retHeight - s1.Height) / 2 + 1;
                    _drawX = x + _titlewidth + (_datawidth - s1.Width) / 2;
                    e.Graphics.DrawString(_leftData, _font, Brushes.Black, new RectangleF(new PointF(_drawX, _drawY), s1));
                }
                else
                {	//双列
                    //画格

                    e.Graphics.DrawRectangle(_pen, x, y, _titlewidth, _retHeight);
                    e.Graphics.FillRectangle(_Brush, x + 1, y + 1, _titlewidth - 1, _retHeight - 1);
                    e.Graphics.DrawRectangle(_pen, x + _titlewidth, y, _datawidth, _retHeight);
                    e.Graphics.DrawRectangle(_pen, x + _titlewidth + _datawidth, y, _titlewidth, _retHeight);
                    e.Graphics.FillRectangle(_Brush, x + _titlewidth + _datawidth + 1, y + 1, _titlewidth - 1, _retHeight - 1);
                    e.Graphics.DrawRectangle(_pen, x + _titlewidth * 2 + _datawidth, y, _datawidth2, _retHeight);

                    //写左标题
                    _drawY = y + (_retHeight - t1.Height) / 2 + 1;
                    _drawX = x + (_titlewidth - t1.Width) / 2;
                    e.Graphics.DrawString(_leftLable, _font, Brushes.Black, new RectangleF(new PointF(_drawX, _drawY), t1));
                    //写右标题
                    _drawY = y + (_retHeight - t2.Height) / 2 + 1;
                    _drawX = x + _titlewidth + _datawidth + (_titlewidth - t2.Width) / 2; ;
                    e.Graphics.DrawString(_rightLable, _font, Brushes.Black, new RectangleF(new PointF(_drawX, _drawY), t2));
                    //写左数据
                    _drawY = y + (_retHeight - s1.Height) / 2 + 1;
                    _drawX = x + _titlewidth + (_datawidth - s1.Width) / 2;
                    e.Graphics.DrawString(_leftData, _font, Brushes.Black, new RectangleF(new PointF(_drawX, _drawY), s1));
                    //写右数据
                    _drawY = y + (_retHeight - s2.Height) / 2 + 1;
                    _drawX = x + _titlewidth * 2 + _datawidth + (_datawidth2 - s2.Width) / 2; ;
                    e.Graphics.DrawString(_rightData, _font, Brushes.Black, new RectangleF(new PointF(_drawX, _drawY), s2));

                }
            }
            finally
            {
                if (UseBrush != null)
                {
                    UseBrush.Dispose();
                }
                if (_pen != null)
                {
                    _pen.Dispose();
                }
            }
            return _retHeight;
        }

        public string ExportHtml()
        {
            StringBuilder _sb = new StringBuilder();
            object _leftobj = (this.LeftText.Visible) ? this.LeftText.EditValue : this.LeftMemo.EditValue;
            string _leftData = (_leftobj == null) ? "" : _leftobj.ToString().Trim();
            string _rightData = (this.RightText.EditValue == null) ? "" : this.RightText.EditValue.ToString().Trim();
            string _leftLable = this.LeftLabel.Text.Trim();
            string _rightLable = this.RightLabel.Text.Trim();
            if (SingleItem)
            {	//单列
                //画标题格                               
                _sb.Append("<tr>");
                _sb.Append("<td style='vnd.ms-excel.numberformat:@'>");
                _sb.Append(HttpUtility.HtmlEncode(_leftLable));
                _sb.Append("</td>");
                //画数据格
                _sb.Append("<td colspan=3 style='vnd.ms-excel.numberformat:@'>");
                _sb.Append(HttpUtility.HtmlEncode(_leftData));
                _sb.Append("</td>");
                _sb.Append("</tr>");
            }
            else
            {	//双列  
                //写左标题
                _sb.Append("<tr>");
                _sb.Append("<td style='vnd.ms-excel.numberformat:@'>");
                _sb.Append(HttpUtility.HtmlEncode(_leftLable));
                _sb.Append("</td>");
                //画左数据
                _sb.Append("<td style='vnd.ms-excel.numberformat:@'>");
                _sb.Append(HttpUtility.HtmlEncode(_leftData));
                _sb.Append("</td>");
                //写右标题                               
                _sb.Append("<td style='vnd.ms-excel.numberformat:@'>");
                _sb.Append(HttpUtility.HtmlEncode(_rightLable));
                _sb.Append("</td>");

                //写右数据
                _sb.Append("<td>");
                _sb.Append(HttpUtility.HtmlEncode(_rightData));
                _sb.Append("</td>");
                _sb.Append("</tr>");

            }
            return _sb.ToString();
        }
    }
}
