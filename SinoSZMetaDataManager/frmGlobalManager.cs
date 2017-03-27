using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZPluginFramework;
using SinoSZJS.Base.MetaData.Define;


namespace SinoSZMetaDataManager
{
    public partial class frmGlobalManager : DevExpress.XtraEditors.XtraForm, IChildForm
    {
        private IApplication _application = null;
        private bool _initFinished = false;

        public frmGlobalManager()
        {
            InitializeComponent();
        }

        #region IChildForm Members

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

        public IList<FrmMenuPage> GetMenuPages()
        {
            IList<FrmMenuPage> _ret = new List<FrmMenuPage>();
            FrmMenuPage _page = new FrmMenuPage("全局定义");
            _page.MenuGroups = GetMenuGroups(_page.PageTitle);
            _ret.Add(_page);
            return _ret;
        }

        private IList<FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();

            FrmMenuGroup _thisGroup = new FrmMenuGroup("修改保存");
            _thisGroup.MenuItems = new List<FrmMenuItem>();
            FrmMenuItem _item = new FrmMenuItem("保存", "保存", global::SinoSZMetaDataManager.Properties.Resources.xx, true);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("取消", "取消", global::SinoSZMetaDataManager.Properties.Resources.x1, true);
            _thisGroup.MenuItems.Add(_item);
            _ret.Add(_thisGroup);
            return _ret;
        }

        public bool DoCommand(string _cmdName)
        {

            return true;
        }

        #endregion

        private void imageListBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MD_NsShareState _st = null;
            int _index = imageListBoxControl1.SelectedIndex;
            if (_index >= 0)
            {
                List<MD_NsShareState> NsStateList = new List<MD_NsShareState>();
                switch (_index)
                {
                    case 0:
                        _st = new MD_NsShareState("JS2008", "缉私案件数据", "开放");
                        NsStateList.Add(_st);
                        _st = new MD_NsShareState("JSQB", "缉私情报数据", "保密");
                        NsStateList.Add(_st);
                        _st = new MD_NsShareState("JSTJ", "缉私统计数据", "开放");
                        NsStateList.Add(_st);

                        break;
                    case 1:
                        _st = new MD_NsShareState("LDPSJK", "两地车牌数据", "开放");
                        NsStateList.Add(_st);
                        _st = new MD_NsShareState("ZDSP", "重点商品", "开放");
                        NsStateList.Add(_st);
                        _st = new MD_NsShareState("ZDSP", "重点人员", "开放");
                        NsStateList.Add(_st);
                        _st = new MD_NsShareState("HKQB", "香港情报交换数据", "保密");
                        NsStateList.Add(_st);
                        _st = new MD_NsShareState("CPA", "CEPA企业资料", "开放");
                        NsStateList.Add(_st);
                        break;
                    case 2:
                        _st = new MD_NsShareState("ZHQD", "载货清单数据", "开放");
                        NsStateList.Add(_st);
                        _st = new MD_NsShareState("SZBGD", "深圳海关报关单数据", "开放");
                        NsStateList.Add(_st);
                        _st = new MD_NsShareState("SZQYBA", "深圳海关企业备案数据库", "开放");
                        NsStateList.Add(_st);
                        _st = new MD_NsShareState("SZCLBA", "深圳海关线索移交反馈数据", "保密");
                        NsStateList.Add(_st);
                        break;
                    case 3:
                        _st = new MD_NsShareState("SZQYBA", "青岛海关企业备案数据", "开放");
                        NsStateList.Add(_st);
                        _st = new MD_NsShareState("SZQYBA", "青岛海关诚信企业数据", "开放");
                        NsStateList.Add(_st);
                        _st = new MD_NsShareState("SZCLBA", "青岛海关线索移交反馈数据", "保密");
                        NsStateList.Add(_st);
                        break;
                }
                this.sinoCommonGrid1.DataSource = NsStateList;
            }
        }
    }
}