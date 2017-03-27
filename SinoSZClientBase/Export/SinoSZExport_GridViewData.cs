using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraGrid.Views.Base;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.Authorize;

namespace SinoSZClientBase.Export
{
        public class SinoSZExport_GridViewData
        {
                public static bool Export(BaseView _view)
                {
                        SaveFileDialog _sf = new SaveFileDialog();
                        _sf.Filter = "Excle�ļ�|*.xls|HTML�ļ�|*.mht|�ı��ļ�|*.TXT";
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
                                                                _view.ExportToXls(_fname, true);
                                                                break;
                                                        case 2:
                                                                _view.ExportToMht(_fname, "UTF-8", "", true);
                                                                break;
                                                        case 3:
                                                                _view.ExportToText(_fname, "\t");
                                                                break;
                                                        case 4:
                                                                _view.ExportToPdf(_fname);
                                                                break;
                                                                
                                                }
                                                using (CommonService.CommonServiceClient _csc = new CommonService.CommonServiceClient())
                                                {
                                                    int _exportRowCount = _view.RowCount;
                                                    _csc.WriteExportLog(_exportRowCount, (_view.Tag != null) ? _view.Tag.ToString() : "");
                                                    //if (XtraMessageBox.Show("�����ļ��ѳɹ����Ƿ������򿪣�", "ϵͳ��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                                    //{
                                                    //    System.Diagnostics.Process.Start(_fname);
                                                    //}
                                                    return true;
                                                }
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
