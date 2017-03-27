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
using System.Collections;
using SinoSZJS.Base.Misc;
using DevExpress.XtraNavBar;

namespace SinoSZClientReport.DataCheck
{
    public partial class frmCheckSearch : frmBase
    {
        private NavBarItem _oldItem = null;
        private Color _oldColor = Color.White;
        private Dictionary<string, NavBarGroup> GroupDict = null;
        public frmCheckSearch()
        {
            InitializeComponent();
        }



        public override void Init(string _title, string _menuName, object _param)
        {
            this.Text = _title;
            this._menuPageName = _menuName;
            string _pstr = _param.ToString();
            ShowGroups(StrUtils.GetMetasByName2("审核分组", _pstr));
            ShowLinks(StrUtils.GetMetasByName2("审核模型", _pstr));

            this._initFinished = true;
            this.navBarControl1.SelectedLink = null;
            RaiseMenuChanged();
        }



        #region 重载基类的方法

        protected override IList<SinoSZPluginFramework.FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            FrmMenuItem _item;
            bool _inputReady = this.sinoUC_CheckDataSearch1.InputReady;
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();

            FrmMenuGroup _thisGroup = new FrmMenuGroup("异常数据检查规则");
            _thisGroup.MenuItems = new List<FrmMenuItem>();

            _item = new FrmMenuItem("添加规则", "添加规则", global::SinoSZClientReport.Properties.Resources.g16, _inputReady);
            _thisGroup.MenuItems.Add(_item);
            bool _ruleSelect = this.sinoUC_CheckDataSearch1.RuleSelected;
            _item = new FrmMenuItem("修改规则", "修改规则", global::SinoSZClientReport.Properties.Resources.b5, _ruleSelect);
            _thisGroup.MenuItems.Add(_item);
            _item = new FrmMenuItem("删除规则", "删除规则", global::SinoSZClientReport.Properties.Resources.g17, _ruleSelect);
            _thisGroup.MenuItems.Add(_item);
            _item = new FrmMenuItem("导入规则", "导入规则", global::SinoSZClientReport.Properties.Resources.s2, _inputReady);
            _thisGroup.MenuItems.Add(_item);

            _ret.Add(_thisGroup);

            _thisGroup = new FrmMenuGroup("审核功能");
            _thisGroup.MenuItems = new List<FrmMenuItem>();
            _item = new FrmMenuItem("数据检查", "数据检查", global::SinoSZClientReport.Properties.Resources.b15, _inputReady);
            _thisGroup.MenuItems.Add(_item);
            _ret.Add(_thisGroup);

            return _ret;
        }

        protected override bool ExcuteCommand(string _cmdName)
        {
            switch (_cmdName)
            {
                case "数据检查":
                    CheckData();
                    break;
                case "添加规则":
                    AddRule();
                    break;
                case "删除规则":
                    DelRule();
                    break;
                case "修改规则":
                    ModifyRule();
                    break;
                case "导入规则":
                    ImportRule();
                    break;
            }
            return true;
        }






        #endregion


        #region 私有方法


        private void ShowGroups(ArrayList fzlist)
        {
            this.navBarControl1.Groups.Clear();
            GroupDict = new Dictionary<string, NavBarGroup>();
            foreach (string _item in fzlist)
            {
                string[] _strs = _item.Split(',');
                foreach (string _s in _strs)
                {
                    string[] _v = _s.Split(':');
                    NavBarGroup _group = new NavBarGroup();
                    _group.Caption = _v[1];
                    _group.Name = _v[0];
                    _group.Expanded = true;
                    this.navBarControl1.Groups.Add(_group);
                    GroupDict.Add(_group.Name, _group);
                }
            }
        }

        private void ShowLinks(ArrayList _gList)
        {
            foreach (string _gItem in _gList)
            {
                AddLink(_gItem);
            }
        }

        private void AddLink(string _glink)
        {
            string[] _names = _glink.Split(',');
            NavBarItem _nb = new DevExpress.XtraNavBar.NavBarItem();
            _nb.Caption = _names[1];
            _nb.Name = _names[0];
            _nb.Tag = _names[0];

            NavBarGroup _group = GroupDict.ContainsKey(_names[2]) ? GroupDict[_names[2]] : null;
            if (_group != null)
            {
                NavBarItemLink _link = _group.ItemLinks.Add(_nb);
            }

        }

        /// <summary>
        /// 数据审核
        /// </summary>
        private void CheckData()
        {
            this.sinoUC_CheckDataSearch1.CheckData(_application);
        }

        /// <summary>
        /// 导入规则
        /// </summary>
        private void ImportRule()
        {
            this.sinoUC_CheckDataSearch1.ImportRule(_application);
        }


        /// <summary>
        /// 添加规则
        /// </summary>
        private void AddRule()
        {
            this.sinoUC_CheckDataSearch1.AddRule(_application);
        }

        /// <summary>
        /// 删除规则
        /// </summary>
        private void DelRule()
        {
            this.sinoUC_CheckDataSearch1.DelRule(_application);
        }

        private void ModifyRule()
        {
            this.sinoUC_CheckDataSearch1.ModifyRule(_application);
        }

        #endregion

        #region 事件处理
        private void navBarControl1_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            NavBarItem _item = e.Link.Item;
            this.label1.Text = string.Format("[{0}] 数据审核", _item.Caption);
            this.navBarControl1.Enabled = false;
            this.sinoUC_CheckDataSearch1.InitModel(_item.Caption, _item.Tag.ToString());
            _oldItem = _item;
            RaiseMenuChanged();
        }



        #endregion

        private void sinoUC_CheckDataSearch1_InitFinished(object sender, EventArgs e)
        {
            this.navBarControl1.Enabled = true;
            this.RaiseMenuChanged();
        }

    }
}