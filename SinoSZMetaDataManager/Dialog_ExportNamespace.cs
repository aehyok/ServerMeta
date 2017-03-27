using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using SinoSZJS.Base.MetaData.Define;
using SinoSZClientBase.MetaDataService;
using SinoSZJS.Base.MetaData.QueryModel;
using System.ServiceModel;

namespace SinoSZMetaDataManager
{
    public partial class Dialog_ExportNamespace : DevExpress.XtraEditors.XtraForm
    {
        private double _progressPosition = 0;
        private double _progressStep = 0;

        private MD_Namespace Namespace = null;
        public Dialog_ExportNamespace()
        {
            InitializeComponent();
        }

        public Dialog_ExportNamespace(MD_Namespace _ns)
        {
            InitializeComponent();
            Namespace = _ns;
            this.panelWait.Visible = false;
        }

        private void te_File_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SaveFileDialog _f = new SaveFileDialog();
            _f.Filter = "�����ļ� (*.bak) | *.bak";
            if (_f.ShowDialog() == DialogResult.OK)
            {
                this.te_File.EditValue = _f.FileName;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.te_File.EditValue == null || this.te_File.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("�����뵼���ļ�����", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ExportNameSpace())
            {
                XtraMessageBox.Show("�����ɹ���", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("����ʧ�ܣ�", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ExportNameSpace()
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                //ȡ����
                this.panelWait.Visible = true;
                SetProgress("���ڶ�ȡ���ݱ��Ԫ���ݶ���...", 0);

                IList<MD_Table> _tbList = _mdc.GetTablesAtNamespace(Namespace.NameSpace);
                SetProgressStep(10, 40, _tbList.Count);

                foreach (MD_Table _tb in _tbList)
                {
                    ShowProgressContinu(string.Format("���ڶ�ȡ{0}����ֶζ���...", _tb.TableName));
                    _tb.Columns = _mdc.GetColumnsOfTable(_tb.TID);
                }

                //ȡ��ѯģ�Ͷ���
                SetProgress("���ڶ�ȡ��ѯģ�͵�Ԫ���ݶ���...", 42);

                IList<MD_QueryModel> _qvList = _mdc.GetQueryModelAtNamespace(Namespace.NameSpace);
                SetProgressStep(45, 90, _qvList.Count);
                foreach (MD_QueryModel _qv in _qvList)
                {
                    ShowProgressContinu(string.Format("���ڶ�ȡ{0}��ģ�Ͷ���...", _qv.DisplayTitle));
                    _qv.MainTable = _mdc.GetMainTableOfQueryModel(_qv.QueryModelID);
                    _qv.ChildTables = _mdc.GetChildTableOfQueryModel(_qv.QueryModelID);
                    _qv.View2ViewGroup = _mdc.GetView2ViewGroupOfQueryModel(_qv.QueryModelID);

                    if (_qv.View2ViewGroup != null)
                    {
                        foreach (MD_View2ViewGroup _gr in _qv.View2ViewGroup)
                        {
                            _gr.View2Views = _mdc.GetView2ViewList(_gr.ID, _qv.QueryModelID);
                        }
                    }

                    try
                    {
                        _qv.View2GuideLines = _mdc.GetView2GuideLineList(_qv.QueryModelID);
                    }
                    catch (FaultException ex)
                    {
                        MessageBox.Show(ex.Message, "ϵͳ����");
                    }
                    _qv.View2Application = _mdc.GetView2ApplicationList(_qv.QueryModelID);

                }

                //ȡ�����
                SetProgress("���ڶ�ȡ������Ԫ���ݶ���...", 92);
                IList<MD_RefTable> _refList = _mdc.GetRefTableAtNamespace(Namespace.NameSpace);

                Namespace.RefTableList = _refList;
                Namespace.QueryModelList = _qvList;
                Namespace.TableList = _tbList;
                SetProgress("����д�뵼���ļ�...", 92);
                WriteExportFile(Namespace);
                SetProgress("������ɣ�", 100);
                return true;
            }
        }

        private void ShowProgressContinu(string _msg)
        {
            this.labelProgress.Text = _msg;
            _progressPosition += _progressStep;
            this.progressBarControl1.Position = Convert.ToInt32(_progressPosition);
            Application.DoEvents();
        }

        private void SetProgressStep(int _startPosition, int _endPosition, int _count)
        {
            _progressPosition = _startPosition;
            _progressStep = (_endPosition - _startPosition) / _count;

        }

        private void SetProgress(string _msg, int _point)
        {
            this.labelProgress.Text = _msg;
            this.progressBarControl1.Position = _point;
            Application.DoEvents();
        }

        public void WriteExportFile(MD_Namespace Namespace)
        {
            DataContractSerializer s = new DataContractSerializer(typeof(MD_Namespace));
            using (FileStream fs = File.Open(this.te_File.EditValue.ToString(), FileMode.Create))
            {
                s.WriteObject(fs, Namespace);
            }

        }
    }
}