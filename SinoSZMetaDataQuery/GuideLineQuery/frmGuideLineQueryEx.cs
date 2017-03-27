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
using SinoSZJS.Base.MetaData.QueryModel;
using System.Linq;
using SinoSZClientBase.MetaDataQueryService;
namespace SinoSZMetaDataQuery.GuideLineQuery
{
    public partial class frmGuideLineQueryEx : DevExpress.XtraEditors.XtraForm, IChildForm
    {
        private IApplication _application = null;
        private bool _initFinished = false;
        private string rootGuideLines = "";
        private SinoSZUC_GuideLineQueryEx CurrentInputControl = null;
        public frmGuideLineQueryEx()
        {
            InitializeComponent();
        }
        public frmGuideLineQueryEx(string _title, string _guideLines)
        {
            InitializeComponent();
            rootGuideLines = _guideLines;
            this.Text = _title;
            InitGuideLineTree();
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




        #region ʵ��IChildFrom�ӿ�

        public IApplication Application
        {
            get { return _application; }
            set { _application = value; }
        }

        public event EventHandler<EventArgs> MenuChanged;
        virtual public void RaiseMenuChanged()
        {
            if (this._initFinished && MenuChanged != null)
            {
                MenuChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// ȡ�����˵�ҳ
        /// </summary>
        /// <returns></returns>
        public IList<FrmMenuPage> GetMenuPages()
        {
            IList<FrmMenuPage> _ret = new List<FrmMenuPage>();
            FrmMenuPage _page = new FrmMenuPage("ָ���ѯ");
            _page.MenuGroups = GetMenuGroups(_page.PageTitle);
            _ret.Add(_page);
            return _ret;
        }

        /// <summary>
        /// ȡ�˵���
        /// </summary>
        /// <param name="_pagename"></param>
        /// <returns></returns>
        private IList<FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();
            FrmMenuGroup _thisGroup = new FrmMenuGroup("ָ���ѯ����");

            _thisGroup.MenuItems = new List<FrmMenuItem>();

            bool _inputFinished = false;
            if (CurrentInputControl != null && CurrentInputControl.InputFinised && !CurrentInputControl.IsQuerying)
            {
                _inputFinished = true;
            }

            FrmMenuItem _item = new FrmMenuItem("ָ���ѯ", "ָ���ѯ", global::SinoSZMetaDataQuery.Properties.Resources.b28, _inputFinished);
            _thisGroup.MenuItems.Add(_item);

            bool _cancelQuery = false;
            if (CurrentInputControl != null && CurrentInputControl.IsQuerying)
            {
                _cancelQuery = true;
            }

            _item = new FrmMenuItem("ȡ��", "ȡ��", global::SinoSZMetaDataQuery.Properties.Resources.x1, _cancelQuery);
            _thisGroup.MenuItems.Add(_item);


            _ret.Add(_thisGroup);

            _thisGroup = new FrmMenuGroup("ָ���ѯ�������");
            _thisGroup.MenuItems = new List<FrmMenuItem>();

            bool _haveResult = (this.CurrentInputControl == null) ? false : this.CurrentInputControl.HaveResult;
            _item = new FrmMenuItem("ͼ��չʾ", "ͼ��չʾ", global::SinoSZMetaDataQuery.Properties.Resources.b18, _haveResult);
            _thisGroup.MenuItems.Add(_item);


            _item = new FrmMenuItem("����", "����", global::SinoSZMetaDataQuery.Properties.Resources.x3, _haveResult);

            _thisGroup.MenuItems.Add(_item);
            _ret.Add(_thisGroup);
            return _ret;
        }


        /// <summary>
        /// ִ�в˵�����
        /// </summary>
        /// <param name="_cmdName"></param>
        /// <returns></returns>
        public bool DoCommand(string _cmdName)
        {
            switch (_cmdName)
            {
                case "ָ���ѯ":
                    if (this.CurrentInputControl != null)
                    {
                        this.treeList1.Enabled = false;
                        this.CurrentInputControl.QueryData();
                    }
                    break;
                case "ȡ��":

                    break;
                case "ͼ��չʾ":
                    ShowAsChart();
                    break;
                case "����":
                    ExportData();
                    break;
            }
            this.RaiseMenuChanged();
            return true;
        }

        private void ExportData()
        {
            if (this.CurrentInputControl != null)
            {
                this.CurrentInputControl.ExportData();
            }
        }

        private void ShowAsChart()
        {
            if (this.CurrentInputControl != null)
            {
                this.CurrentInputControl.ShowAsChart(_application);
            }

        }


        #endregion

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            ShowCurrentNode();
        }

        private void ShowCurrentNode()
        {
            if (_initFinished)
            {
                this.splitContainerControl1.Panel2.Controls.Clear();
                CurrentInputControl = null;
                TreeListNode _cNode = this.treeList1.FocusedNode;
                if (_cNode != null)
                {
                    MD_GuideLine _cGuideLine = _cNode.GetValue(this.treeListColumn1) as MD_GuideLine;
                    if (_cGuideLine == null || _cGuideLine.GuideLineMethod == null || _cGuideLine.GuideLineMethod.Trim() == "")
                    {
                    }
                    else
                    {
                        SinoSZUC_GuideLineQueryEx _uc = new SinoSZUC_GuideLineQueryEx(_cGuideLine);
                        _uc.InputChanged += new EventHandler(_uc_InputChanged);
                        _uc.QueryFinished += new EventHandler(_uc_QueryFinished);
                        _uc.ShowDetailData += new EventHandler(_uc_ShowDetailData);
                        CurrentInputControl = _uc;
                        _uc.Dock = DockStyle.Fill;
                        this.splitContainerControl1.Panel2.Controls.Add(_uc);
                        _uc.BringToFront();
                    }
                }
                RaiseMenuChanged();
            }
        }

        void _uc_ShowDetailData(object sender, EventArgs e)
        {
            ShowDetailDataArgs _showArgs = e as ShowDetailDataArgs;
            GuideLineDetailControler.ShowDetail(_showArgs, _application);

        }

        void _uc_QueryFinished(object sender, EventArgs e)
        {
            this.treeList1.Enabled = true;
            RaiseMenuChanged();
        }

        void _uc_InputChanged(object sender, EventArgs e)
        {
            RaiseMenuChanged();
        }

        private void frmGuideLineQueryEx_Load(object sender, EventArgs e)
        {
            this._initFinished = true;
            ShowCurrentNode();
        }

        private void treeList1_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {
            MD_GuideLine _gline = e.Node.GetValue(this.treeListColumn1) as MD_GuideLine;
            if (_gline.GuideLineMethod == "")
            {
                e.NodeImageIndex = 1;
            }
            else
            {
                e.NodeImageIndex = 2;
            }
        }


    }
}