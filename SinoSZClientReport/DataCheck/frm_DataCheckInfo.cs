using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZClientBase;
using SinoSZPluginFramework;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZMetaDataQuery.Common;

namespace SinoSZClientReport.DataCheck
{
    public partial class frm_DataCheckInfo : frmBase
    {
        private string MainKeyID = "";
        private DataSet ResultDs = null;
        private DataTable SHData = null;
        private MDQuery_Request QueryRequest = null;
        private MDModel_QueryModel QueryModel = null;
        private DataRow CurrentRow = null;
        private string CurrentWHXH = "";
        private string HisWHXH = "";
        private string UserLevel = "";
        private string SHID = "";

        public frm_DataCheckInfo()
        {
            InitializeComponent();
        }

        public void Init(string _title, string _menuName, string _mainid, MDQuery_Request _request, MDModel_QueryModel _queryModel, DataRow _dr)
        {
            QueryModel = _queryModel;
            QueryRequest = _request;
            MainKeyID = _mainid;
            CurrentRow = _dr;
            this.Text = _title;
            this._menuPageName = _menuName;
            InitForm();
            this._initFinished = true;
            RaiseMenuChanged();
        }

        private void InitForm()
        {
            this.panelAlert.Visible = false;
            //initTab("����˽��");
            //initTab("ֱ����˽��");
            //initTab("��˽�־�");
            ShowData();
            //ShowFs();

        }




        private void ShowData()
        {
            if (QueryModel != null && QueryRequest != null)
            {
                this.panelWait.Visible = true;
                this.backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                this.panelWait.Visible = false;
            }
        }



        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable _maindt;
            //ȡģ������
            ResultDs = new DataSet();
            using (SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient _rsc = new SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient())
            {
                _maindt = _rsc.GetMainTableDataByKey(this.QueryRequest.QueryModelName,
                                                     this.QueryModel.MainTable.TableName, this.MainKeyID);

                _maindt.TableName = this.QueryModel.MainTable.TableName;
                ResultDs.Tables.Add(_maindt);

                foreach (MDModel_Table _ct in this.QueryModel.ChildTableDict.Values)
                {
                    DataTable _dt = _rsc.GetChildTableDataByKey(this.QueryRequest.QueryModelName,
                                                     _ct.TableName, this.MainKeyID);
                    _dt.TableName = _ct.TableName;
                    ResultDs.Tables.Add(_dt);
                }
                //ȡ�û�����
                UserLevel = _rsc.GetUserLevel();
                //ȡ�������

                SHData = _rsc.GetDataCheckInfo(this.QueryRequest.QueryModelName, this.MainKeyID, ref SHID);

                CurrentWHXH = _rsc.GetDataCheckWHXH(QueryModel.MainTable.TableName, QueryModel.MainTable.TableDefine.Table.MainKey, this.MainKeyID);
            }

        }


        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string _sf = "";
            ShowData(this.QueryModel.MainTable, ResultDs.Tables[this.QueryModel.MainTable.TableName]);
            foreach (MDModel_Table _ct in this.QueryModel.ChildTableDict.Values)
            {
                ShowData(_ct, ResultDs.Tables[_ct.TableName]);
            }
            this.sinoUC_SHInput1.SetWHXH(SHID, CurrentWHXH, UserLevel);
            this.sinoUC_SHInput2.SetWHXH(SHID, CurrentWHXH, UserLevel);
            this.sinoUC_SHInput3.SetWHXH(SHID, CurrentWHXH, UserLevel);
            ShowShInfo();
            this.panelWait.Visible = false;
            RaiseMenuChanged();

            if (CurrentRow != null)
            {
                switch (UserLevel)
                {
                    case "����˽��":
                        _sf = "SH_ZONGSJ";
                        break;
                    case "�㶫����˽��":
                        _sf = "SH_ZONGSJ";
                        break;
                    case "ֱ����˽��":
                        _sf = "SH_ZHISJ";
                        break;
                    case "��˽�־�":
                        _sf = "SH_FJ";
                        break;
                    default:
                        _sf = "SH_FJ";
                        break;
                }

                if ((decimal)CurrentRow["GX_STATE"] == 1 && CurrentRow != null && (CurrentRow[_sf].ToString() == "1"))
                {
                    this.panelAlert.Visible = true;
                }
                else
                {
                    this.panelAlert.Visible = false;
                }
            }
        }

        private void ShowShInfo()
        {
            if (SHData == null) return;

            foreach (DataRow _dr in SHData.Rows)
            {
                ShowSHXX(_dr);
            }

            this.sinoUC_SHInput1.CanEdit = (UserLevel == "����˽��" || UserLevel == "�㶫����˽��");
            this.sinoUC_SHInput2.CanEdit = (UserLevel == "ֱ����˽��");
            this.sinoUC_SHInput3.CanEdit = (UserLevel == "��˽�־�");

        }

        private void ShowSHXX(DataRow _dr)
        {
            SinoUC_SHInput _control = null;
            string _jb = _dr["DWJBFL"].ToString();
            HisWHXH = _dr["WHXH"].ToString();
            switch (_jb)
            {
                case "����˽��":
                    _control = this.sinoUC_SHInput1;
                    break;
                case "�㶫����˽��":
                    _control = this.sinoUC_SHInput1;
                    break;
                case "ֱ����˽��":
                    _control = this.sinoUC_SHInput2;
                    break;
                case "��˽�־�":
                    _control = this.sinoUC_SHInput3;
                    break;
            }

            if (_control != null)
            {
                _control.InitData(_dr);
            }
        }

        private void ShowData(MDModel_Table MainTableDefine, DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                SinoSZUC_RecordData _rd = new SinoSZUC_RecordData(MainTableDefine, null);
                _rd.Dock = DockStyle.Top;
                this.PanelDetail.Controls.Add(_rd);
                _rd.BringToFront();
            }
            else
            {
                foreach (DataRow _dr in dataTable.Rows)
                {
                    SinoSZUC_RecordData _rd = new SinoSZUC_RecordData(MainTableDefine, _dr);
                    _rd.Dock = DockStyle.Top;
                    this.PanelDetail.Controls.Add(_rd);
                    _rd.BringToFront();
                }
            }
        }



        private void frm_DataCheckInfo_Load(object sender, EventArgs e)
        {

        }


        #region ���ػ���ķ���

        protected override IList<FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            FrmMenuItem _item;
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();

            FrmMenuGroup _thisGroup = new FrmMenuGroup("�������");
            _thisGroup.MenuItems = new List<FrmMenuItem>();

            //_item = new FrmMenuItem("��ӡ", "��ӡ", global::SinoSZClient.DataCheck.Properties.Resources.g36, true);
            //_thisGroup.MenuItems.Add(_item);
            if (this.CurrentSHInput != null && this.CurrentSHInput.CanSendMsg())
            {
                _item = new FrmMenuItem("������", "������", global::SinoSZClientReport.Properties.Resources.b22, true);
                _thisGroup.MenuItems.Add(_item);
            }

            _item = new FrmMenuItem("�鿴��ʷ", "�鿴��ʷ", global::SinoSZClientReport.Properties.Resources.x2, true);
            _thisGroup.MenuItems.Add(_item);
            if (this.CurrentSHInput != null && this.CurrentSHInput.CanEdit)
            {
                _item = new FrmMenuItem("�������", "�������", global::SinoSZClientReport.Properties.Resources.xx, true);
                _thisGroup.MenuItems.Add(_item);
            }

            _ret.Add(_thisGroup);


            return _ret;
        }



        protected override bool ExcuteCommand(string _cmdName)
        {
            switch (_cmdName)
            {
                case "������":
                    SendSHMsg();
                    break;
                case "�鿴��ʷ":
                    ShowHisData();
                    break;
                case "�������":
                    SaveSHData();
                    break;
            }
            return true;
        }

        private SinoUC_SHInput CurrentSHInput
        {
            get
            {
                switch (this.xtraTabControl1.SelectedTabPageIndex)
                {
                    case 0:
                        return this.sinoUC_SHInput1;

                    case 1:
                        return this.sinoUC_SHInput2;

                    case 2:
                        return this.sinoUC_SHInput3;

                }
                return null;
            }
        }


        /// <summary>
        /// ����˹���
        /// </summary>
        private void SendSHMsg()
        {

            DataTable _dt;
            string JY_Info = "";
            foreach (MDQuery_TableColumn _tc in this.QueryRequest.MainResultTable.Columns)
            {
                string _str = this.CurrentRow[_tc.ColumnAlias].ToString();
                JY_Info += string.Format("{0}: {1}", _tc.ColumnTitle, _str);
                JY_Info += "\r\n";
            }

            string _shyj = GetSHYJ();
            SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient _rsc = new SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient();
            string _dw = _rsc.GetSjshInfo_HGJS(this.QueryRequest, MainKeyID);
            string _title = _dw + "������������";
            string _msg = string.Format("{0}����������������,�޸Ľ�������:\r\n{2} \r\n\r\n���ݸ�Ҫ��Ϣ��\r\n{1}", _dw, JY_Info, _shyj);

            switch (this.xtraTabControl1.SelectedTabPageIndex)
            {
                case 0:
                    CreateSHMsg(this.sinoUC_SHInput1, _title, _msg);
                    break;
                case 1:
                    CreateSHMsg(this.sinoUC_SHInput2, _title, _msg);
                    break;
                case 2:
                    CreateSHMsg(this.sinoUC_SHInput3, _title, _msg);
                    break;
            }

        }

        private string GetSHYJ()
        {
            if (this.sinoUC_SHInput1.CanEdit) return this.sinoUC_SHInput1.SH_XGYJ;
            if (this.sinoUC_SHInput2.CanEdit) return this.sinoUC_SHInput2.SH_XGYJ;
            if (this.sinoUC_SHInput3.CanEdit) return this.sinoUC_SHInput3.SH_XGYJ;
            return "";
        }

        private void CreateSHMsg(SinoUC_SHInput _shInput, string _title, string _msg)
        {
            _shInput.SendMsg(_title, _msg);
        }

        private void ShowHisData()
        {
            string _showhisWHXH = GetCurrentUserHis();
            Dialog_ShowHisData _f = new Dialog_ShowHisData();
            _f.InitData(CurrentRow, _showhisWHXH, this.QueryModel, this.MainKeyID);
            _f.ShowDialog();

        }

        private string GetCurrentUserHis()
        {
            SinoUC_SHInput _control = null;
            switch (UserLevel)
            {
                case "����˽��":
                    _control = this.sinoUC_SHInput1;
                    break;
                case "�㶫����˽��":
                    _control = this.sinoUC_SHInput1;
                    break;
                case "ֱ����˽��":
                    _control = this.sinoUC_SHInput2;
                    break;
                case "��˽�־�":
                    _control = this.sinoUC_SHInput3;
                    break;
            }

            if (_control != null)
            {
                return _control.GetCurrentWHXH();
            }
            return "";
        }

        private void SaveSHData()
        {
            SinoUC_SHInput _control = null;
            string _fieldName = "SH_ZONGSJ";
            switch (UserLevel)
            {
                case "����˽��":
                    _control = this.sinoUC_SHInput1;
                    _fieldName = "SH_ZONGSJ";
                    break;
                case "�㶫����˽��":
                    _control = this.sinoUC_SHInput1;
                    _fieldName = "SH_ZONGSJ";
                    break;
                case "ֱ����˽��":
                    _control = this.sinoUC_SHInput2;
                    _fieldName = "SH_ZHISJ";
                    break;
                case "��˽�־�":
                    _control = this.sinoUC_SHInput3;
                    _fieldName = "SH_FJ";
                    break;
            }

            if (_control != null)
            {
                if (_control.SaveData())
                {
                    if (_control.SH_JG == "ͨ��")
                    {
                        this.CurrentRow[_fieldName] = "1";
                    }
                    else
                    {
                        this.CurrentRow[_fieldName] = "2";
                    }
                    this.CurrentRow["GX_STATE"] = 0;
                    this.panelAlert.Visible = false;
                    ShowData();
                    RaiseMenuChanged();
                }
            }
        }


        #endregion

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            RaiseMenuChanged();
        }
    }
}