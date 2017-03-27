using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZPluginFramework;

using DevExpress.XtraTreeList.Nodes;
using SinoSZMetaDataQuery.GuideLineQuery;
using System.Linq;
using SinoSZClientBase;
using SinoSZJS.Base.Misc;
using DevExpress.XtraTreeList;
using SinoSZClientBase.Export;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZClientBase.MetaDataQueryService;

namespace SinoSZMetaDataQuery.AlertMonitor
{
    public partial class frmAlertMonitor : frmBase
    {
        protected string Param = "";
        private string rootGuideLines = "";
        private string ParamStrings = "";
        private string DefalutValueStrings = "";
        private MD_GuideLine FirstGuideLine = null;
        private Dictionary<string, MD_GuideLine> GuideLineDict = new Dictionary<string, MD_GuideLine>();
        private Dictionary<string, int> GuideLineQueryData = new Dictionary<string, int>();
        private TreeListNode OldNode = null;
        public frmAlertMonitor()
        {
            InitializeComponent();
        }

        public override void Init(string _title, string _menuName, object _param)
        {
            Param = (string)_param;
            this.Text = StrUtils.GetMetaByName2("标题", Param);
            rootGuideLines = StrUtils.GetMetaByName2("指标ID", Param);
            ParamStrings = StrUtils.GetMetaByName2("参数", Param);
            DefalutValueStrings = StrUtils.GetMetaByName2("默认值", Param);
            InitGuideLineTree();
            _initFinished = true;
            RaiseMenuChanged();
        }


        #region 重载基类的方法



        protected override IList<FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();
            FrmMenuGroup _thisGroup = new FrmMenuGroup("预警监督功能");

            _thisGroup.MenuItems = new List<FrmMenuItem>();

            bool _inputFinished = false;
            if (this.sinoSZUC_GuideLineDynamicInput21.InputFinised && !this.sinoSZUC_AlertResult1.IsQuerying)
            {
                _inputFinished = true;
            }

            FrmMenuItem _item = new FrmMenuItem("查询", "查询", global::SinoSZMetaDataQuery.Properties.Resources.b28, _inputFinished);
            _thisGroup.MenuItems.Add(_item);

            bool _cancelQuery = false;
            if (this.sinoSZUC_AlertResult1.IsQuerying)
            {
                _cancelQuery = true;
            }

            _item = new FrmMenuItem("取消", "取消", global::SinoSZMetaDataQuery.Properties.Resources.x1, _cancelQuery);
            _thisGroup.MenuItems.Add(_item);
            _ret.Add(_thisGroup);

            _thisGroup = new FrmMenuGroup("结果处理");
            _thisGroup.MenuItems = new List<FrmMenuItem>();
            bool _haveResult = this.sinoSZUC_AlertResult1.HaveResult;

            _item = new FrmMenuItem("显示", "显示", global::SinoSZMetaDataQuery.Properties.Resources.b11, _haveResult);
            _thisGroup.MenuItems.Add(_item);

            FrmMenuItem _citem = new FrmMenuItem("未解除", "未解除", global::SinoSZMetaDataQuery.Properties.Resources.b12, _haveResult);
            _item.ChildMenus.Add(_citem);

            _citem = new FrmMenuItem("已解除", "已解除", global::SinoSZMetaDataQuery.Properties.Resources.b12, _haveResult);
            _item.ChildMenus.Add(_citem);


            _item = new FrmMenuItem("解除", "解除", global::SinoSZMetaDataQuery.Properties.Resources.b18, _haveResult);
            _thisGroup.MenuItems.Add(_item);


            _item = new FrmMenuItem("图表展示", "图表展示", global::SinoSZMetaDataQuery.Properties.Resources.b18, _haveResult);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("导出", "导出", global::SinoSZMetaDataQuery.Properties.Resources.x3, _haveResult);
            _thisGroup.MenuItems.Add(_item);
            _ret.Add(_thisGroup);
            return _ret;
        }

        protected override bool ExcuteCommand(string _cmdName)
        {
            switch (_cmdName)
            {
                case "查询":
                    QueryAlert();
                    break;
                case "取消":
                    this.sinoSZUC_AlertResult1.CancelQuery();
                    break;
                case "图表展示":
                    ShowAsChart();
                    break;
                case "导出":
                    SinoSZExport_GridViewData.Export(this.sinoSZUC_AlertResult1.CurrentView);
                    break;
                case "解除":
                    DisAlert();
                    break;
            }
            this.RaiseMenuChanged();
            return true;
        }

        #endregion


        private void DisAlert()
        {
            Dialog_DisAlert _f = new Dialog_DisAlert();
            _f.ShowDialog();
        }


        private void InitGuideLineTree()
        {
            GuideLineDict.Clear();
            using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
            {
                List<MD_GuideLine> _rootGuideLineList = _msc.GetRootGuideLineList(rootGuideLines).ToList<MD_GuideLine>();
                foreach (MD_GuideLine _gl in _rootGuideLineList)
                {
                    GuideLineDict.Add(_gl.ID, _gl);
                    if (_gl.GuideLineMethod != "" && FirstGuideLine == null)
                    {
                        FirstGuideLine = _gl;
                    }
                    TreeListNode _newnode = treeList1.AppendNode(null, null);
                    _newnode.SetValue(this.treeListColumn1, _gl);
                    LoadChildGuideLine(_gl, _newnode);
                    _newnode.Expanded = true;
                }

                string _pstr = ParamStrings.Replace("\r\n", "");
                string _ps = "";
                foreach (string _s in _pstr.Split(','))
                {
                    _ps += string.Format("<CS>{0}</CS>", _s);
                }


                this.sinoSZUC_GuideLineDynamicInput21.InitForm(_ps);
                foreach (string _val in DefalutValueStrings.Split(','))
                {
                    string[] _valueItems = _val.Split(':');
                    if (_valueItems.Length > 1)
                    {
                        this.sinoSZUC_GuideLineDynamicInput21.WriteParamValue(_valueItems[0], _valueItems[1]);
                    }
                }

                if (this.sinoSZUC_GuideLineDynamicInput21.InputFinised)
                {
                    QueryAlert();
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
                    GuideLineDict.Add(_gl.ID, _gl);
                    if (_gl.GuideLineMethod != "" && FirstGuideLine == null)
                    {
                        FirstGuideLine = _gl;
                    }
                    TreeListNode _newnode = treeList1.AppendNode(null, _fnode);
                    _newnode.SetValue(this.treeListColumn1, _gl);
                    LoadChildGuideLine(_gl, _newnode);
                    _newnode.HasChildren = true;
                }
            }
        }

        private void treeList1_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {
            MD_GuideLine _gline = e.Node.GetValue(this.treeListColumn1) as MD_GuideLine;
            if (_gline == null) return;
            if (_gline.GuideLineMethod == "")
            {
                e.NodeImageIndex = 1;
            }
            else
            {
                e.NodeImageIndex = 2;
            }
        }





        private void QueryAlert()
        {
            this.panelControl1.Visible = true;
            this.backgroundWorker1.RunWorkerAsync();
        }

        private void ShowAsChart()
        {
            if (this.sinoSZUC_AlertResult1.HaveResult)
            {
                this.sinoSZUC_AlertResult1.ShowAsChart(_application);
            }

        }




        private void sinoSZUC_GuideLineDynamicInput21_InputChanged(object sender, EventArgs e)
        {
            RaiseMenuChanged();
        }

        private void frmAlertMonitor_Load(object sender, EventArgs e)
        {
            this._initFinished = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            List<MDQuery_GuideLineParameter> _params = this.sinoSZUC_GuideLineDynamicInput21.GetParamters();
            GuideLineQueryData.Clear();
            foreach (MD_GuideLine _gl in GuideLineDict.Values)
            {
                if (_gl.GuideLineMethod == "")
                {
                    GuideLineQueryData.Add(_gl.ID, -1);
                }
                else
                {
                    using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                    {
                        int _resCount = _msc.QueryGuideLineResultCount(_gl.ID, _params.ToArray());
                        GuideLineQueryData.Add(_gl.ID, _resCount);
                    }
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (TreeListNode _tn in this.treeList1.Nodes)
            {
                MD_GuideLine _gl = _tn.GetValue(this.treeListColumn1) as MD_GuideLine;
                int _ret = GuideLineQueryData[_gl.ID];
                if (_ret != -1)
                {
                    _tn.SetValue(this.treeListColumn2, _ret);
                }

                ShowChildNodes(_tn);

            }
            this.panelControl1.Visible = false;
        }

        private void ShowChildNodes(TreeListNode _ftn)
        {
            foreach (TreeListNode _tn in _ftn.Nodes)
            {
                MD_GuideLine _gl = _tn.GetValue(this.treeListColumn1) as MD_GuideLine;
                int _ret = GuideLineQueryData[_gl.ID];
                if (_ret != -1)
                {
                    _tn.SetValue(this.treeListColumn2, _ret);
                }

                ShowChildNodes(_tn);
            }
        }


        private void treeList1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeListHitInfo _info = this.treeList1.CalcHitInfo(e.Location);
            if ((_info.Column == this.treeListColumn2 || _info.Column == this.treeListColumn1) && _info.Node != null)
            {
                if (OldNode != null)
                {
                    if (OldNode.Equals(_info.Node))
                    {
                        return;
                    }
                    OldNode.SetValue(this.treeListColumn3, "0");
                }


                TreeListNode _tn = _info.Node;
                _tn.SetValue(this.treeListColumn3, "1");
                MD_GuideLine _gl = _tn.GetValue(this.treeListColumn1) as MD_GuideLine;
                this.sinoSZUC_AlertResult1.ShowGuideLineResult(_gl, this.sinoSZUC_GuideLineDynamicInput21.GetParamters());
                OldNode = _tn;
            }
        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {

        }

        private void sinoSZUC_AlertResult1_QueryFinished(object sender, EventArgs e)
        {
            RaiseMenuChanged();
        }

        private void sinoSZUC_AlertResult1_DataChanged(object sender, EventArgs e)
        {
            RaiseMenuChanged();
        }


    }
}