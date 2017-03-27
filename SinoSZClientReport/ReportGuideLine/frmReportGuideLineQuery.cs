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
using DevExpress.XtraTreeList.Nodes;
using SinoSZJS.Base.Report.ReportGuideLine;
using SinoSZJS.Base.Report;
using SinoSZJS.Base.Misc;
using SinoSZJS.Base.Authorize;
using System.Linq;

namespace SinoSZClientReport.ReportGuideLine
{
    public partial class frmReportGuideLineQuery : frmBase
    {
        private string reportType = "";
        private string Param = "";
        private List<MD_ReportName> reportItems = new List<MD_ReportName>();

        public frmReportGuideLineQuery()
        {
            InitializeComponent();
        }

        public override void Init(string _title, string _menuName, object _param)
        {
            this.Text = _title;
            Param = _param.ToString();
            string _reportNames = StrUtils.GetMetaByName("报表名称", Param);
            string _reportType = StrUtils.GetMetaByName("报表类型", Param).Split(',')[0];
            reportType = _reportType;
            using (SinoSZClientBase.ReportService.ReportServiceClient _rsc = new SinoSZClientBase.ReportService.ReportServiceClient())
            {
                reportItems = _rsc.GetReportNames(_reportNames, _reportType).ToList<MD_ReportName>();
            }
            this._menuPageName = _menuName;
            this.CB_Report.Properties.Items.Clear();
            foreach (MD_ReportName _rn in reportItems)
            {
                this.CB_Report.Properties.Items.Add(_rn);
            }
            this.sinoUC_OrgComboBox1.InitRootDWID(SessionClass.CurrentSinoUser.CurrentPost.PostDwID);
            this.sinoUC_OrgComboBox1.SelectedCode(decimal.Parse(SessionClass.CurrentSinoUser.CurrentPost.PostDwID));
            this._initFinished = true;


        }

        private void radioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            this.reportGuideLineUC_InputTJRQ1.ShowAsMode(this.radioGroup1.EditValue.ToString());
        }


        #region 重载基类的方法

        protected override IList<FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();

            FrmMenuGroup _thisGroup = new FrmMenuGroup("查询");
            _thisGroup.MenuItems = new List<FrmMenuItem>();
            FrmMenuItem _item = new FrmMenuItem("指标查询", "指标查询", global::SinoSZClientReport.Properties.Resources.x2, true);
            _thisGroup.MenuItems.Add(_item);
            _ret.Add(_thisGroup);

            _thisGroup = new FrmMenuGroup("指标概要信息处理");
            _thisGroup.MenuItems = new List<FrmMenuItem>();

            _item = new FrmMenuItem("图表展示", "图表展示", global::SinoSZClientReport.Properties.Resources.p6, true);
            _thisGroup.MenuItems.Add(_item);
            _item = new FrmMenuItem("导出", "导出", global::SinoSZClientReport.Properties.Resources.x3, true);
            _thisGroup.MenuItems.Add(_item);
            _ret.Add(_thisGroup);

            return _ret;
        }

        protected override bool ExcuteCommand(string _cmdName)
        {
            switch (_cmdName)
            {
                case "指标查询":
                    return QueryReport();

                case "图表展示":
                    ShowChart();
                    break;
                case "导出":
                    ExportData();
                    break;
            }
            return true;
        }



        private bool QueryReport()
        {
            string _msg = "";

            if (!this.reportGuideLineUC_InputTJRQ1.CheckInput(ref _msg))
            {
                XtraMessageBox.Show(_msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (this.sinoUC_OrgComboBox1.Code < 0)
            {
                XtraMessageBox.Show("请选择统计单位!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (this.CB_Report.EditValue == null)
            {
                XtraMessageBox.Show("请选择统计报表!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            this.reportGuideLineUC_Query1.Clear();
            this.reportGuideLineUC_Query1.StartDate = this.reportGuideLineUC_InputTJRQ1.StartDate;
            this.reportGuideLineUC_Query1.EndDate = this.reportGuideLineUC_InputTJRQ1.EndDate;
            this.reportGuideLineUC_Query1.DWDM = this.sinoUC_OrgComboBox1.OrgItem.DWDM;
            using (SinoSZClientBase.ReportService.ReportServiceClient _rsc = new SinoSZClientBase.ReportService.ReportServiceClient())
            {
                List<MD_ReportGuideLineItem> _guideLineData = _rsc.GetReportGuideLines(this.CB_Report.EditValue as MD_ReportName).ToList<MD_ReportGuideLineItem>();

                ShowGuideLineTree(_guideLineData);

                return true;
            }
        }

        private void ShowGuideLineTree(List<MD_ReportGuideLineItem> _guideLineData)
        {
            this.treeList1.BeginUpdate();
            this.treeList1.Nodes.Clear();
            foreach (MD_ReportGuideLineItem _item in _guideLineData)
            {
                TreeListNode _dwnode = treeList1.AppendNode(null, null);
                _dwnode.SetValue(this.treeListColumn1, _item.DisplayName);
                if (_item.Type == Enum_ReportGuideLineItemType.Report)
                {
                    _dwnode.ImageIndex = 1;
                }
                else
                {
                    _dwnode.ImageIndex = 2;
                }
                _dwnode.SelectImageIndex = 0;
                _dwnode.Tag = _item;
                LoadChildNode(_dwnode, _item);
                _dwnode.Expanded = true;
            }
            if (_guideLineData.Count > 0)
            {
                this.treeList1.FocusedNode = this.treeList1.Nodes[0];
            }
            this.treeList1.EndUpdate();
        }

        private void LoadChildNode(TreeListNode _fnode, MD_ReportGuideLineItem _fitem)
        {
            foreach (MD_ReportGuideLineItem _item in _fitem.Children)
            {
                TreeListNode _dwnode = treeList1.AppendNode(null, _fnode);
                _dwnode.SetValue(this.treeListColumn1, _item.DisplayName);
                if (_item.Type == Enum_ReportGuideLineItemType.Report)
                {
                    _dwnode.ImageIndex = 1;
                }
                else
                {
                    _dwnode.ImageIndex = 2;
                }
                _dwnode.SelectImageIndex = 0;
                _dwnode.Tag = _item;
                LoadChildNode(_dwnode, _item);
                _dwnode.Expanded = true;
            }
        }







        #endregion

        private void ExportData()
        {
            this.reportGuideLineUC_Query1.ExportData();
        }

        private void ShowChart()
        {
            this.reportGuideLineUC_Query1.ShowChart(this._application);
        }
        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            TreeListNode _cnode = this.treeList1.FocusedNode;
            if (_cnode != null)
            {
                MD_ReportGuideLineItem _item = _cnode.Tag as MD_ReportGuideLineItem;
                this.reportGuideLineUC_Query1.CurrentGuideLine = _item;
                this.reportGuideLineUC_Query1.ShowData();
            }
        }


    }
}