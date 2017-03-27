using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.Authorize;
using SinoSZClientReport.DataCheck.Board;

namespace SinoSZClientReport.DataCheck
{
    public partial class SinoUC_SHInput : DevExpress.XtraEditors.XtraUserControl
    {
        private bool CanEditData = false;
        private DataRow CurrentRow = null;
        private string CurrentLevel = "";
        public string CurrentID = "";
        private string CurrentJLID = "";
        private string CurrentWHXH = "";
        public SinoUC_SHInput()
        {
            InitializeComponent();
        }

        internal bool CanEdit
        {
            get
            {
                return CanEditData;
            }
            set
            {
                CanEditData = value;
                this.te_JG.Properties.ReadOnly = !CanEditData;
                this.te_SHR.Properties.ReadOnly = !CanEditData;
                this.te_SHRQ.Properties.ReadOnly = false;
                this.te_XGYJ.Properties.ReadOnly = !CanEditData;
                //if (CanEditData)
                //{
                //    string _sr = "";
                //    if (this.te_SHR.EditValue != null) _sr = this.te_SHR.EditValue.ToString();
                //    this.te_SHR.Properties.Items.Clear();
                //    if (_sr != "") this.te_SHR.Properties.Items.Add(_sr);
                //    this.te_SHR.Properties.Items.Add(SessionClass.CurrentSinoUser.UserName);
                //    this.te_SHR.SelectedIndex = 0;
                //}
            }
        }

        public void SetCurrentSHR()
        {
            this.te_SHR.Properties.Items.Add(SessionClass.CurrentSinoUser.UserName);
            this.te_SHR.SelectedIndex = 0;
        }
        internal void InitData(DataRow _dr)
        {
            if (_dr == null) return;
            this.te_JG.EditValue = _dr.IsNull("SHJG") ? "" : _dr["SHJG"].ToString();
            this.te_SHR.EditValue = _dr.IsNull("RYXM") ? "" : _dr["RYXM"].ToString();
            this.te_XGYJ.EditValue = _dr.IsNull("SHYJ") ? "" : _dr["SHYJ"].ToString();
            this.te_SHRQ.EditValue = _dr["SHRQ"];
            this.CurrentLevel = _dr["DWJBFL"].ToString();
            this.CurrentID = _dr["ID"].ToString();
            this.CurrentJLID = _dr["SHJLID"].ToString();
            CurrentRow = _dr;
        }

        internal bool SaveData()
        {
            string _shjg, _shr, _xgyj;
            DateTime _shrq;

            if (this.te_JG.EditValue == null)
            {
                XtraMessageBox.Show("��¼����˽��!", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            _shjg = this.te_JG.EditValue.ToString();


            _shr = SessionClass.CurrentSinoUser.UserName;

            if (this.te_XGYJ.EditValue == null || this.te_XGYJ.EditValue.ToString() == "")
            {
                _xgyj = "";
            }
            else
            {
                _xgyj = this.te_XGYJ.EditValue.ToString();
            }

            bool _ret = DoSH(CurrentJLID, CurrentLevel, CurrentID, _shjg, _shr, _xgyj, CurrentWHXH);
            if (_ret)
            {
                XtraMessageBox.Show("����ɹ�!", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                XtraMessageBox.Show("����ʧ��!", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        private bool DoSH(string CurrentJLID, string CurrentLevel, string CurrentID, string _shjg, string _shr, string _xgyj, string CurrentWHXH)
        {
            using (SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient _rsc = new SinoSZClientBase.MetaDataQueryService.MetaDataQueryServiceClient())
            {
                string _ret = _rsc.SaveDataCheckResult(CurrentJLID, CurrentLevel, CurrentID, _shjg, _shr, _xgyj, CurrentWHXH);
                if (_ret == "-1")
                {
                    return false;
                }
                else
                {
                    this.CurrentJLID = _ret;
                    return true;
                }
            }
        }

        internal void SetWHXH(string SHID, string _whxh, string _userLevel)
        {
            CurrentID = SHID;
            CurrentWHXH = _whxh;
            CurrentLevel = _userLevel;
        }

        internal bool CheckInput(ref string _msg)
        {


            if (this.te_JG.EditValue == null)
            {
                _msg = "��¼����˽��!";
                return false;
            }


            //if (this.te_SHR.EditValue == null || this.te_SHR.EditValue.ToString() == "")
            //{
            //    _msg = "��¼�������!";
            //    return false;

            //}

            //if (this.te_XGYJ.EditValue == null || this.te_XGYJ.EditValue.ToString() == "")
            //{
            //    _msg = "��¼���޸����!";
            //    return false;

            //}
            return true;
        }

        public string SH_JG
        {
            get
            {
                return this.te_JG.EditValue.ToString();
            }
        }

        public string SH_SHR
        {
            get
            {
                return this.te_SHR.EditValue.ToString();
            }
        }
        public string SH_XGYJ
        {
            get
            {
                if (this.te_XGYJ.EditValue == null) return "";
                return this.te_XGYJ.EditValue.ToString();
            }
        }


        public bool ShData(DataRow _dr, string _whxh, string _currentLevel, string _currentid, string _currentJLID)
        {
            string _fieldName;
            string _shjg, _shr, _xgyj;
            _shjg = (this.te_JG.EditValue == null) ? "" : this.te_JG.EditValue.ToString();

            _shr = (this.te_SHR.EditValue == null) ? "" : this.te_SHR.EditValue.ToString();

            _xgyj = (this.te_XGYJ.EditValue == null) ? "" : this.te_XGYJ.EditValue.ToString();
            this.CurrentLevel = _currentLevel;
            this.CurrentID = _currentid;
            this.CurrentJLID = _currentJLID;
            CurrentRow = _dr;

            bool _ret = DoSH(CurrentJLID, CurrentLevel, CurrentID, _shjg, _shr, _xgyj, _whxh);
            if (_ret)
            {
                switch (CurrentLevel)
                {
                    case "����˽��":
                        _fieldName = "SH_ZONGSJ";
                        break;
                    case "�㶫����˽��":
                        _fieldName = "SH_ZONGSJ";
                        break;
                    case "ֱ����˽��":
                        _fieldName = "SH_ZHISJ";
                        break;
                    case "��˽�־�":
                        _fieldName = "SH_FJ";
                        break;
                    default:
                        _fieldName = "SH_FJ";
                        break;
                }
                if (_shjg == "ͨ��")
                {
                    this.CurrentRow[_fieldName] = "1";
                }
                else
                {
                    this.CurrentRow[_fieldName] = "2";
                }
                return true;
            }
            else
            {
                XtraMessageBox.Show("���������Ϣʧ��! CurrentJLID=" + CurrentJLID, "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        public void SendMsg(string _title, string _msg)
        {
            if (this.CurrentJLID == "")
            {
                XtraMessageBox.Show(string.Format("{0}�ּ����û�û����˼�¼���޷������棡", this.CurrentLevel), "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Dialog_SHMsgInfo _f = new Dialog_SHMsgInfo();
            _f.InitNew(this.CurrentJLID, _title, _msg);
            _f.ShowDialog();
        }

        public bool CanSendMsg()
        {
            if (this.CurrentJLID == "") return false;
            return CanEditData;
        }

        public string GetCurrentWHXH()
        {
            if (this.CurrentRow != null)
            {
                if (this.CurrentRow.IsNull("WHXH"))
                {
                    return "";
                }
                else
                {
                    return this.CurrentRow["WHXH"].ToString();
                }
            }
            return "";
        }
    }
}
