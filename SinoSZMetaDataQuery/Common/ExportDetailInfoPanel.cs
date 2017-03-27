using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.IO;

namespace SinoSZMetaDataQuery.Common
{
        public class ExportDetailInfoPanel
        {
                private XtraScrollableControl _panel;
                private string ExportFileName = "";
                public ExportDetailInfoPanel(XtraScrollableControl _p)
                {
                        //
                        // TODO: 在此处添加构造函数逻辑
                        //
                        _panel = _p;
                }

                public bool Export(string _fname)
                {
                        ExportFileName = _fname;
                        StringBuilder _sb = new StringBuilder();
                        _sb.Append("<table border=1>");

                        for (int i = _panel.Controls.Count; i > 0; i--)
                        {
                                SinoSZUC_RecordData _currentRecordData = null;
                                object _uc = _panel.Controls[i - 1];
                                if (_uc.GetType() == typeof(SinoSZUC_RecordData))
                                {
                                        //标题栏
                                        _currentRecordData = (SinoSZUC_RecordData)_uc;
                                        _sb.Append(_currentRecordData.ExportHtml());
                                }


                                if (_uc.GetType() == typeof(Panel))
                                {
                                        Panel _pc = (Panel)_uc;
                                        if (_pc.Visible)
                                        {
                                                _sb.Append(ExportChild(_pc));
                                        }
                                }
                        }
                        _sb.Append("</table>");

                        System.Text.Encoding _encode = System.Text.Encoding.Default;
                        StreamWriter sw = new StreamWriter(ExportFileName, false, _encode);
                        sw.Write(_sb.ToString());
                        sw.Close();
                        return true;
                }

                private string ExportChild(Panel _panel)
                {
                        StringBuilder _sb = new StringBuilder();

                        for (int i = _panel.Controls.Count; i > 0; i--)
                        {
                                object _uc = _panel.Controls[i - 1];
                                if (_uc.GetType() == typeof(SinoSZUC_RecordData))
                                {
                                        //标题栏
                                        SinoSZUC_RecordData _mc = (SinoSZUC_RecordData)_uc;
                                        _sb.Append(_mc.ExportHtml());
                                }
                        }

                        return _sb.ToString();
                }


        }
}
