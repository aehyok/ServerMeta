using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZClientBase;
using SinoSZJS.Base.Misc;
using SinoSZPluginFramework;
using DevExpress.XtraTreeList.Nodes;

using System.Linq;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZClientBase.MetaDataQueryService;

namespace SinoSZMetaDataQuery.GuideLineSetting
{
    public partial class frmGuideLineSetting : frmBase
    {
        protected string Param = "";
        private string rootGuideLines = "";
        protected MD_GuideLine_ParamSetting CurrentParamSetting = null;
        public frmGuideLineSetting()
        {
            InitializeComponent();
        }

        public override void Init(string _title, string _menuName, object _param)
        {
            Param = (string)_param;

            this.Text = StrUtils.GetMetaByName2("����", Param);
            rootGuideLines = StrUtils.GetMetaByName2("ָ��ID", Param);
            InitGuideLineTree();
            _initFinished = true;

            ShowFocusNodeParamSetting();

            RaiseMenuChanged();
        }


        private void InitGuideLineTree()
        {
            if (rootGuideLines != "")
            {
                using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                {
                    List<MD_GuideLine> _rootGuideLineList = _msc.GetRootGuideLineList(rootGuideLines).ToList<MD_GuideLine>();

                    foreach (MD_GuideLine _gl in _rootGuideLineList)
                    {
                        TreeListNode _newnode = treeList1.AppendNode(null, null);
                        _newnode.SetValue(this.treeListColumn1, _gl);
                        LoadChildGuideLine(_gl, _newnode);
                        _newnode.Expanded = true;
                    }
                }
            }
        }

        private void LoadChildGuideLine(MD_GuideLine _fgl, TreeListNode _fnode)
        {
            using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
            {
                List<MD_GuideLine> _rootGuideLineList = _msc.GetGuideLineListByFatherID(_fgl.ID).ToList<MD_GuideLine>();
                foreach (MD_GuideLine _gl in _rootGuideLineList)
                {
                    TreeListNode _newnode = treeList1.AppendNode(null, _fnode);
                    _newnode.SetValue(this.treeListColumn1, _gl);
                    LoadChildGuideLine(_gl, _newnode);
                    _newnode.HasChildren = true;
                }
            }
        }




        #region ���ػ���ķ���
        protected override IList<FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            FrmMenuItem _item;
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();
            FrmMenuGroup _thisGroup = new FrmMenuGroup("��������");

            _thisGroup.MenuItems = new List<FrmMenuItem>();
            _item = new FrmMenuItem("����", "����", global::SinoSZMetaDataQuery.Properties.Resources.x5, true);
            _thisGroup.MenuItems.Add(_item);
            _item = new FrmMenuItem("ȡ��", "ȡ��", global::SinoSZMetaDataQuery.Properties.Resources.x1, true);
            _thisGroup.MenuItems.Add(_item);
            _item = new FrmMenuItem("�����㷨", "�����㷨", global::SinoSZMetaDataQuery.Properties.Resources.b27, true);
            _thisGroup.MenuItems.Add(_item);
            _ret.Add(_thisGroup);

            return _ret;
        }

        protected override bool ExcuteCommand(string _cmdName)
        {
            switch (_cmdName)
            {
                case "����":
                    SaveData();
                    break;
                case "ȡ��":
                    ShowFocusNodeParamSetting();
                    break;
                case "�����㷨":
                    ReBuilderMethod();
                    break;
            }
            this.RaiseMenuChanged();
            return true;
        }




        #endregion

        private void ReBuilderMethod()
        {
            this.CurrentParamSetting.ParamMeta = this.sinoSZUC_GuideLineQueryInput1.ExportValueByXml();
            using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
            {
                if (_msc.RebuildGuideLineParamSetting(this.CurrentParamSetting.GuideLineID))
                {
                    XtraMessageBox.Show("�����㷨�ɹ�!", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    XtraMessageBox.Show("�����㷨ʧ��!", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }


        private void SaveData()
        {
            this.CurrentParamSetting.ParamMeta = this.sinoSZUC_GuideLineQueryInput1.ExportValueByXml();
            List<MDQuery_GuideLineParameter> _paramters = this.sinoSZUC_GuideLineQueryInput1.GetParamters();
            using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
            {
                if (_msc.SaveGuideLineParamSetting(this.CurrentParamSetting, _paramters.ToArray()))
                {
                    XtraMessageBox.Show("����ɹ�!", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    XtraMessageBox.Show("����ʧ��!", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (this._initFinished) ShowFocusNodeParamSetting();
        }


        private void ShowFocusNodeParamSetting()
        {

            TreeListNode _cNode = this.treeList1.FocusedNode;
            if (_cNode != null)
            {
                MD_GuideLine _cGuideLine = _cNode.GetValue(this.treeListColumn1) as MD_GuideLine;
                using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                {
                    CurrentParamSetting = _msc.GetGuideLineParamSetting(_cGuideLine.ID);
                }
                if (CurrentParamSetting != null)
                {
                    ShowParams(_cGuideLine);
                }
            }
        }

        private void ShowParams(MD_GuideLine _guideLine)
        {
            if (_guideLine != null)
            {
                this.sinoSZUC_GuideLineQueryInput1.InitForm(_guideLine, CurrentParamSetting.ParamMeta);
            }
        }


    }
}