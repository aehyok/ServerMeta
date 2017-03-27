using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SinoSZClientReport.ReportGuideLine
{
        public partial class ReportGuideLineUC_InputTJRQ : DevExpress.XtraEditors.XtraUserControl
        {
                private string _queryType = "���¶Ȳ�ѯ";
                public ReportGuideLineUC_InputTJRQ()
                {
                        InitializeComponent();
                }

                public DateTime StartDate
                {
                        get
                        {
                                DateTime _dt;
                                switch (_queryType)
                                {
                                        case "���¶Ȳ�ѯ":
                                                _dt = (DateTime)this.dateEdit1.EditValue;
                                                return new DateTime(_dt.Year, _dt.Month, 1);
                                                break;
                                        case "���¶Ȳ�ѯ":
                                                _dt = (DateTime)this.te_StartDate.EditValue;
                                                return new DateTime(_dt.Year, _dt.Month, 1);
                                                break;
                                }
                                return DateTime.Now;
                        }
                }

                public DateTime EndDate
                {
                        get
                        {
                                DateTime _dt,_next;
                                switch (_queryType)
                                {
                                        case "���¶Ȳ�ѯ":
                                                _dt = (DateTime)this.dateEdit1.EditValue;
                                                _dt =new  DateTime(_dt.Year, _dt.Month, 1);
                                                 _next = _dt.AddMonths(1).AddSeconds(-1);
                                                return _next;
                                                break;
                                        case "���¶Ȳ�ѯ":
                                                _dt = (DateTime)this.te_EndDate.EditValue;
                                                _dt = new  DateTime(_dt.Year, _dt.Month, 1);
                                                 _next = _dt.AddMonths(1).AddSeconds(-1);
                                                return _next;
                                                break;
                                }
                                return DateTime.Now;
                        }
                }
                public bool CheckInput(ref string _msg)
                {
                        _msg = "";
                        switch (_queryType)
                        {
                                case "���¶Ȳ�ѯ":
                                        if (this.dateEdit1.EditValue == null)
                                        {
                                                _msg = "δ����ͳ���·ݣ�";
                                                return false;
                                        }
                                        else
                                        {
                                                return true;
                                        }
                                        break;
                                case "���¶Ȳ�ѯ":
                                        if (this.te_StartDate.EditValue == null && this.te_EndDate.EditValue == null)
                                        {
                                                _msg = "δ����ͳ���·ݷ�Χ��";
                                                return false;
                                        }
                                        else
                                        {
                                                return true;
                                        }
                                        break;
                        }
                        return true;
                }

                private void ReportGuideLineUC_InputTJRQ_Load(object sender, EventArgs e)
                {
                        DateTime _now = DateTime.Now;
                        this.dateEdit1.EditValue = new DateTime(_now.Year, _now.Month, 1);
                        this.te_StartDate.EditValue = new DateTime(_now.Year, 1, 1);
                        this.te_EndDate.EditValue = new DateTime(_now.Year, _now.Month, 1);
                }

                public void ShowAsMode(string _type)
                {
                        switch (_type)
                        {
                                case "���¶Ȳ�ѯ":
                                        this.tableLayoutPanel1.Visible = true;
                                        this.tableLayoutPanel2.Visible = false;
                                        _queryType = _type;
                                        break;
                                case "���¶Ȳ�ѯ":
                                        this.tableLayoutPanel1.Visible = false;
                                        this.tableLayoutPanel2.Visible = true;
                                        _queryType = _type;
                                        break;
                        }
                }
        }
}
