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
using SinoSZJS.Base.OrganizeExt;
using SinoSZPluginFramework;
using DevExpress.XtraTreeList.Columns;
using SinoSZJS.Base.Authorize;
using System.Linq;

namespace SinoSZClientSysManager.Organize
{
    public partial class frmOrganizeExtInfo : frmBase
    {
        private string Param = "";
        private List<OrgExtFieldDefine> ExtendFields = new List<OrgExtFieldDefine>();
        private List<OrgExtFieldDefine> PropertieDefines = new List<OrgExtFieldDefine>();
        private OrgExtList CurrentOrgExtList = null;
        public frmOrganizeExtInfo()
        {
            InitializeComponent();
        }

        public override void Init(string _titleold, string _menuName, object _param)
        {
            this._menuPageName = _menuName;
            Param = _param as string;
            string _title = StrUtils.GetMetaByName2("标题", Param);
            this.Text = _title;
            string _extFieldStrs = StrUtils.GetMetaByName2("扩展字段", Param);
            ExtendFields.Clear();
            foreach (string _s in _extFieldStrs.Split(','))
            {
                if (_s.Trim().Length > 0)
                {
                    string[] _cs = _s.Split(':');
                    ExtendFields.Add(new OrgExtFieldDefine(_cs[0].Trim(), _cs[1].Trim(), _cs[2].Trim()));
                    PropertieDefines.Add(new OrgExtFieldDefine(_cs[0].Trim(), _cs[1].Trim(), _cs[2].Trim()));
                }
            }
            int _order = 10;
            if (this.ExtendFields.Count > 0)
            {
                foreach (OrgExtFieldDefine _item in this.ExtendFields)
                {
                    TreeListColumn _tc = this.treeList1.Columns.Add();
                    _tc.Caption = _item.DisplayTitle;
                    _tc.FieldName = _item.FieldName;
                    if (_item.FieldType == "BOOL")
                    {
                        _tc.ColumnEdit = this.repositoryItemCheckEdit1;
                    }
                    _tc.VisibleIndex = _order++;
                    _tc.BestFit();
                }
            }

            ExtendFields.Add(new OrgExtFieldDefine("ZZJGID", "组织机构ID", "VARCHAR2"));
            ExtendFields.Add(new OrgExtFieldDefine("SJDWID", "上级单位ID", "VARCHAR2"));
            ExtendFields.Add(new OrgExtFieldDefine("ZZJGQC", "组织机构全称", "VARCHAR2"));
            ExtendFields.Add(new OrgExtFieldDefine("JGXSMC", "显示名称", "VARCHAR2"));
            ExtendFields.Add(new OrgExtFieldDefine("ISDISPLAY", "是否显示", "BOOL"));
            ExtendFields.Add(new OrgExtFieldDefine("DISPLAYORDER", "显示顺序", "NUMBER"));


            ShowData();
            this._initFinished = true;
        }

        private void ShowData()
        {
            List<OrgExtInfo> _rootOrgExtData;
            CurrentOrgExtList = new OrgExtList();
            using (SinoSZClientBase.CommonService.CommonServiceClient _csc = new SinoSZClientBase.CommonService.CommonServiceClient())
            {
                _rootOrgExtData = _csc.GetOrgExtRootData(PropertieDefines.ToArray()).ToList<OrgExtInfo>();
            }
            OrgExtFinder _finder = new OrgExtFinder(SessionClass.CurrentSinoUser.CurrentPost.PostDwID);
            List<OrgExtInfo> olist = _rootOrgExtData.FindAll(new Predicate<OrgExtInfo>(_finder.FindByID));
            olist.Sort(new OrgExtComparer());
            foreach (OrgExtInfo _dw in olist)
            {
                OrgExtBusinessObject _bi = new OrgExtBusinessObject(_dw, ExtendFields);
                _bi.ChildOrgList.Add(new OrgExtBusinessObject(null, null));
                CurrentOrgExtList.Add(_bi);
            }
            this.treeList1.DataSource = CurrentOrgExtList;
        }


        #region 重载基类的方法

        protected override IList<FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            FrmMenuItem _item;
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();

            FrmMenuGroup _thisGroup = new FrmMenuGroup("组织机构信息维护");
            _thisGroup.MenuItems = new List<FrmMenuItem>();

            _item = new FrmMenuItem("保存修改", "保存修改", global::SinoSZClientSysManager.Properties.Resources.xx, true);
            _thisGroup.MenuItems.Add(_item);
            _item = new FrmMenuItem("取消修改", "取消修改", global::SinoSZClientSysManager.Properties.Resources.x1, true);
            _thisGroup.MenuItems.Add(_item);

            _ret.Add(_thisGroup);

            return _ret;
        }

        protected override bool ExcuteCommand(string _cmdName)
        {
            switch (_cmdName)
            {

                case "保存修改":
                    SaveData();
                    break;
                case "取消修改":
                    CanelChange();
                    break;
            }
            return true;
        }

        private void SaveData()
        {
            using (SinoSZClientBase.CommonService.CommonServiceClient _csc = new SinoSZClientBase.CommonService.CommonServiceClient())
            {
                List<OrgExtBusinessObject> ChangedList = GetChangedOrgExtObj();
                List<OrgExtInfo> BeSavedDataList = new List<OrgExtInfo>();
                foreach (OrgExtBusinessObject _obj in ChangedList)
                {
                    BeSavedDataList.Add(_obj.GetInfoData());
                }
                if (_csc.SaveOrgExtList(BeSavedDataList.ToArray(), PropertieDefines.ToArray()))
                {
                    foreach (OrgExtBusinessObject _obj in ChangedList)
                    {
                        _obj.AcceptChanged();
                    }
                    XtraMessageBox.Show("保存成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("保存失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private List<OrgExtBusinessObject> GetChangedOrgExtObj()
        {
            List<OrgExtBusinessObject> _ret = new List<OrgExtBusinessObject>();
            this.treeList1.PostEditor();
            if (CurrentOrgExtList != null)
            {
                foreach (OrgExtBusinessObject _obj in CurrentOrgExtList)
                {
                    if (_obj.IsChanged)
                    {
                        _ret.Add(_obj);
                    }
                    AddChild(_obj.ChildOrgList, _ret);
                }
            }
            return _ret;
        }

        private void AddChild(OrgExtList orgExtList, List<OrgExtBusinessObject> _ret)
        {
            if (orgExtList == null) return;
            foreach (OrgExtBusinessObject _obj in orgExtList)
            {
                if (_obj.IsChanged)
                {
                    _ret.Add(_obj);
                }
                AddChild(_obj.ChildOrgList, _ret);
            }
        }

        private void CanelChange()
        {
            this._initFinished = false;
            ShowData();
            this._initFinished = true;
        }

        #endregion

        private void treeList1_BeforeExpand(object sender, DevExpress.XtraTreeList.BeforeExpandEventArgs e)
        {
            OrgExtBusinessObject _orgExtData = (OrgExtBusinessObject)treeList1.GetDataRecordByNode(e.Node);
            if (_orgExtData == null) return;
            if (_orgExtData.ChildOrgList.Count == 1)
            {
                OrgExtBusinessObject _firstData = _orgExtData.ChildOrgList[0];
                if (_firstData.IsBlank)
                {
                    this.treeList1.BeginUpdate();
                    _orgExtData.ChildOrgList.Clear();
                    foreach (OrgExtInfo _dw in GetChildOrgList((string)_orgExtData.GetData("ZZJGID")))
                    {
                        OrgExtBusinessObject _bi = new OrgExtBusinessObject(_dw, ExtendFields);
                        _bi.ChildOrgList.Add(new OrgExtBusinessObject(null, null));
                        _orgExtData.ChildOrgList.Add(_bi);
                    }

                    this.treeList1.EndUpdate();
                }
            }
        }

        private List<OrgExtInfo> GetChildOrgList(string _fid)
        {
            List<OrgExtInfo> _lsExtData;
            using (SinoSZClientBase.CommonService.CommonServiceClient _csc = new SinoSZClientBase.CommonService.CommonServiceClient())
            {
                _lsExtData = _csc.GetOrgExtChildData(_fid, PropertieDefines.ToArray()).ToList<OrgExtInfo>();
            }
            OrgExtFinder _finder = new OrgExtFinder(_fid);
            List<OrgExtInfo> olist = _lsExtData.FindAll(new Predicate<OrgExtInfo>(_finder.FindByFatherID));
            olist.Sort(new OrgExtComparer());
            return olist;
        }

    }
}