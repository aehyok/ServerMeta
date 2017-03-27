using System;
using System.Collections.Generic;
using System.Text;

using SinoSZPluginFramework;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraEditors;
using SinoSZClientBase;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.Define;
using SinoSZClientBase.MetaDataService;

namespace SinoSZMetaDataManager
{
    public class MenuDefine
    {
        static private IDictionary<String, FrmMenuGroup> _ObjectMenuGroups = new Dictionary<String, FrmMenuGroup>();

        /// <summary>
        /// 通过对象取功能菜单
        /// </summary>
        /// <param name="_value"></param>
        /// <returns></returns>
        internal static FrmMenuGroup GetMenuGroupByObject(object _value)
        {
            if (_value == null) return null;
            //if (!_ObjectMenuGroups.ContainsKey(_value.GetType().ToString()))
            //{
            //        FrmMenuGroup _mg = CreateMenuGroupByObject(_value);
            //        _ObjectMenuGroups.Add(_value.GetType().ToString(), _mg);
            //}
            //return _ObjectMenuGroups[_value.GetType().ToString()];
            return CreateMenuGroupByObject(_value);
        }

        private static FrmMenuGroup CreateMenuGroupByObject(object _value)
        {
            FrmMenuGroup _mg = null;
            FrmMenuItem _item;

            if (_value is MD_Nodes)
            {
                _mg = new FrmMenuGroup("节点管理");
                _mg.MenuItems = new List<FrmMenuItem>();

                _item = new FrmMenuItem("添加节点", "添加节点", global::SinoSZMetaDataManager.Properties.Resources.g3, 80);
                _mg.MenuItems.Add(_item);

                _item = new FrmMenuItem("删除节点", "删除节点", global::SinoSZMetaDataManager.Properties.Resources.g4, 80);
                _mg.MenuItems.Add(_item);

                _item = new FrmMenuItem("添加命名空间", "添加命名空间", global::SinoSZMetaDataManager.Properties.Resources.g5, 80);
                _mg.MenuItems.Add(_item);

                _item = new FrmMenuItem("导入命名空间", "导入命名空间", global::SinoSZMetaDataManager.Properties.Resources.g7, 80);
                _mg.MenuItems.Add(_item);


            }

            if (_value is MD_Namespace)
            {
                _mg = new FrmMenuGroup("命名空间管理");
                _mg.MenuItems = new List<FrmMenuItem>();

                _item = new FrmMenuItem("删除命名空间", "删除命名空间", global::SinoSZMetaDataManager.Properties.Resources.g6, 80);
                _mg.MenuItems.Add(_item);

                _item = new FrmMenuItem("添加表", "添加表", global::SinoSZMetaDataManager.Properties.Resources.g9, 80);
                _mg.MenuItems.Add(_item);

                _item = new FrmMenuItem("添加模型", "添加模型", global::SinoSZMetaDataManager.Properties.Resources.g12, 80);
                _mg.MenuItems.Add(_item);

                _item = new FrmMenuItem("添加代码表", "添加代码表", global::SinoSZMetaDataManager.Properties.Resources.g14, 80);
                _mg.MenuItems.Add(_item);

                _item = new FrmMenuItem("导出命名空间", "导出命名空间", global::SinoSZMetaDataManager.Properties.Resources.g8, 80);
                _mg.MenuItems.Add(_item);
            }

            if (_value is MD_Title)
            {
                MD_Title _mdtitle = _value as MD_Title;
                switch (_mdtitle.TitleType)
                {
                    case "MD_TABLE":
                        _mg = new FrmMenuGroup("数据表管理");
                        _mg.MenuItems = new List<FrmMenuItem>();

                        _item = new FrmMenuItem("添加表", "添加表", global::SinoSZMetaDataManager.Properties.Resources.g9, 80);
                        _mg.MenuItems.Add(_item);

                        _item = new FrmMenuItem("删除全部表", "删除全部表", global::SinoSZMetaDataManager.Properties.Resources.g10, 80);
                        _mg.MenuItems.Add(_item);
                        break;

                    case "MD_QUERYMODEL":
                        _mg = new FrmMenuGroup("查询模型管理");
                        _mg.MenuItems = new List<FrmMenuItem>();

                        _item = new FrmMenuItem("添加模型", "添加模型", global::SinoSZMetaDataManager.Properties.Resources.g12, 100);
                        _mg.MenuItems.Add(_item);
                        break;
                    case "MD_REFTABLE":
                        _mg = new FrmMenuGroup("代码表管理");
                        _mg.MenuItems = new List<FrmMenuItem>();

                        _item = new FrmMenuItem("添加代码表", "添加代码表", global::SinoSZMetaDataManager.Properties.Resources.g14, 80);
                        _mg.MenuItems.Add(_item);

                        _item = new FrmMenuItem("清空代码表", "清空代码表", global::SinoSZMetaDataManager.Properties.Resources.g10, 80);
                        _mg.MenuItems.Add(_item);
                        break;
                    case "MD_MENU":
                        _mg = new FrmMenuGroup("菜单管理");
                        _mg.MenuItems = new List<FrmMenuItem>();

                        _item = new FrmMenuItem("添加菜单", "添加菜单", global::SinoSZMetaDataManager.Properties.Resources.g16, 80);
                        _mg.MenuItems.Add(_item);
                        break;
                    case "MD_TJZB":
                        _mg = new FrmMenuGroup("统计指标");
                        _mg.MenuItems = new List<FrmMenuItem>();

                        _item = new FrmMenuItem("添加指标组", "添加指标组", global::SinoSZMetaDataManager.Properties.Resources.g26, 80);
                        _mg.MenuItems.Add(_item);
                        break;

                    case "MD_REPORTGUIDLINE":
                        _mg = new FrmMenuGroup("统计指标");
                        _mg.MenuItems = new List<FrmMenuItem>();

                        _item = new FrmMenuItem("添加指标组", "添加指标组", global::SinoSZMetaDataManager.Properties.Resources.g26, 80);
                        _mg.MenuItems.Add(_item);
                        break;

                    case "MD_CONCEPTGROUP":
                        _mg = new FrmMenuGroup("标签定义");
                        _mg.MenuItems = new List<FrmMenuItem>();

                        _item = new FrmMenuItem("添加标签组", "添加标签组", global::SinoSZMetaDataManager.Properties.Resources.g21, 80);
                        _mg.MenuItems.Add(_item);
                        break;
                    case "MD_VIEW_GUIDELINE":
                        _mg = new FrmMenuGroup("关联指标管理");
                        _mg.MenuItems = new List<FrmMenuItem>();

                        _item = new FrmMenuItem("添加关联", "添加关联", global::SinoSZMetaDataManager.Properties.Resources.g14, 80);
                        _mg.MenuItems.Add(_item);

                        _item = new FrmMenuItem("清空关联项", "清空关联项", global::SinoSZMetaDataManager.Properties.Resources.g10, 80);
                        _mg.MenuItems.Add(_item);
                        break;
                    case "MD_VIEW_APPLICATION":
                        _mg = new FrmMenuGroup("集成应用展示设置");
                        _mg.MenuItems = new List<FrmMenuItem>();

                        _item = new FrmMenuItem("添加应用", "添加应用", global::SinoSZMetaDataManager.Properties.Resources.g14, 80);
                        _mg.MenuItems.Add(_item);

                        _item = new FrmMenuItem("清空应用项", "清空应用项", global::SinoSZMetaDataManager.Properties.Resources.g10, 80);
                        _mg.MenuItems.Add(_item);
                        break;

                    case "MD_VIEW_EXRIGHT":
                        _mg = new FrmMenuGroup("查询模型扩展权限");
                        _mg.MenuItems = new List<FrmMenuItem>();

                        _item = new FrmMenuItem("添加权限", "添加权限", global::SinoSZMetaDataManager.Properties.Resources.g16, 80);
                        _mg.MenuItems.Add(_item);

                        break;


                }
            }

            if (_value is MD_QueryModel_ExRight)
            {
                _mg = new FrmMenuGroup("查询模型扩展权限");
                _mg.MenuItems = new List<FrmMenuItem>();

                _item = new FrmMenuItem("添加子权限", "添加子权限", global::SinoSZMetaDataManager.Properties.Resources.g16, 80);
                _mg.MenuItems.Add(_item);
                _item = new FrmMenuItem("删除权限", "删除权限", global::SinoSZMetaDataManager.Properties.Resources.g17, 80);
                _mg.MenuItems.Add(_item);
            }

            if (_value is MD_QueryModel)
            {
                _mg = new FrmMenuGroup("查询模型管理");
                _mg.MenuItems = new List<FrmMenuItem>();

                _item = new FrmMenuItem("删除模型", "删除模型", global::SinoSZMetaDataManager.Properties.Resources.g13, 80);
                _mg.MenuItems.Add(_item);

                _item = new FrmMenuItem("添加主表", "添加主表", global::SinoSZMetaDataManager.Properties.Resources.g9, 80);
                _mg.MenuItems.Add(_item);


                _item = new FrmMenuItem("添加关联组", "添加关联组", global::SinoSZMetaDataManager.Properties.Resources.g12, 80);
                _mg.MenuItems.Add(_item);
            }

            if (_value is MD_View2ViewGroup)
            {
                _mg = new FrmMenuGroup("关联模型管理");
                _mg.MenuItems = new List<FrmMenuItem>();

                _item = new FrmMenuItem("关联模型", "关联模型", global::SinoSZMetaDataManager.Properties.Resources.g12, 80);
                _mg.MenuItems.Add(_item);

                _item = new FrmMenuItem("删除关联组", "删除关联组", global::SinoSZMetaDataManager.Properties.Resources.g13, 80);
                _mg.MenuItems.Add(_item);
            }

            if (_value is MD_View2View)
            {

                _mg = new FrmMenuGroup("关联模型管理");
                _mg.MenuItems = new List<FrmMenuItem>();

                _item = new FrmMenuItem("删除关联", "删除关联", global::SinoSZMetaDataManager.Properties.Resources.g13, 80);
                _mg.MenuItems.Add(_item);
            }

            if (_value is MD_Table && !(_value is MD_ViewTable))
            {
                _mg = new FrmMenuGroup("数据表管理");
                _mg.MenuItems = new List<FrmMenuItem>();

                _item = new FrmMenuItem("删除表", "删除表", global::SinoSZMetaDataManager.Properties.Resources.g10, 80);
                _mg.MenuItems.Add(_item);

                _item = new FrmMenuItem("字段同步", "字段同步", global::SinoSZMetaDataManager.Properties.Resources.g11, 80);
                _mg.MenuItems.Add(_item);

                _item = new FrmMenuItem("关联模型", "关联模型", global::SinoSZMetaDataManager.Properties.Resources.g12, 80);
                _mg.MenuItems.Add(_item);
            }

            if (_value is MD_ViewTable)
            {
                _mg = new FrmMenuGroup("模型表管理");
                _mg.MenuItems = new List<FrmMenuItem>();

                _item = new FrmMenuItem("添加子表", "添加子表", global::SinoSZMetaDataManager.Properties.Resources.g9, 80);
                _mg.MenuItems.Add(_item);

                _item = new FrmMenuItem("删除表", "删除表", global::SinoSZMetaDataManager.Properties.Resources.g10, 80);
                _mg.MenuItems.Add(_item);


                _item = new FrmMenuItem("字段同步", "字段同步", global::SinoSZMetaDataManager.Properties.Resources.g11, 80);
                _mg.MenuItems.Add(_item);
            }

            if (_value is MD_Menu)
            {
                _mg = new FrmMenuGroup("菜单管理");
                _mg.MenuItems = new List<FrmMenuItem>();

                _item = new FrmMenuItem("添加子菜单", "添加子菜单", global::SinoSZMetaDataManager.Properties.Resources.g18, 80);
                _mg.MenuItems.Add(_item);

                _item = new FrmMenuItem("删除菜单", "删除菜单", global::SinoSZMetaDataManager.Properties.Resources.g17, 80);
                _mg.MenuItems.Add(_item);
            }

            if (_value is MD_GuideLineGroup)
            {
                _mg = new FrmMenuGroup("指标定义");
                _mg.MenuItems = new List<FrmMenuItem>();

                _item = new FrmMenuItem("删除指标组", "删除指标组", global::SinoSZMetaDataManager.Properties.Resources.g27, 80);
                _mg.MenuItems.Add(_item);

                _item = new FrmMenuItem("添加指标", "添加指标", global::SinoSZMetaDataManager.Properties.Resources.g28, 80);
                _mg.MenuItems.Add(_item);

                _item = new FrmMenuItem("查询指标", "查询指标", global::SinoSZMetaDataManager.Properties.Resources.g28, 80);
                _mg.MenuItems.Add(_item);

            }

            if (_value is MD_GuideLine)
            {
                _mg = new FrmMenuGroup("指标定义");
                _mg.MenuItems = new List<FrmMenuItem>();

                _item = new FrmMenuItem("删除指标", "删除指标", global::SinoSZMetaDataManager.Properties.Resources.g29, 80);
                _mg.MenuItems.Add(_item);

                _item = new FrmMenuItem("添加指标", "添加指标", global::SinoSZMetaDataManager.Properties.Resources.g28, 80);
                _mg.MenuItems.Add(_item);

                _item = new FrmMenuItem("导出指标", "导出指标", global::SinoSZMetaDataManager.Properties.Resources.g33, 80);
                _mg.MenuItems.Add(_item);

                _item = new FrmMenuItem("导入指标", "导入指标", global::SinoSZMetaDataManager.Properties.Resources.g32, 80);
                _mg.MenuItems.Add(_item);

            }

            if (_value is MD_ConceptGroup)
            {
                _mg = new FrmMenuGroup("概念标签定义");
                _mg.MenuItems = new List<FrmMenuItem>();

                _item = new FrmMenuItem("删除标签组", "删除标签组", global::SinoSZMetaDataManager.Properties.Resources.g22, 80);
                _mg.MenuItems.Add(_item);

                _item = new FrmMenuItem("添加标签", "添加标签", global::SinoSZMetaDataManager.Properties.Resources.g23, 80);
                _mg.MenuItems.Add(_item);
            }

            if (_value is MD_ConceptItem)
            {
                _mg = new FrmMenuGroup("概念标签定义");
                _mg.MenuItems = new List<FrmMenuItem>();

                _item = new FrmMenuItem("删除标签", "删除标签", global::SinoSZMetaDataManager.Properties.Resources.g24, 80);
                _mg.MenuItems.Add(_item);
            }

            if (_value is MD_RefTable)
            {
                _mg = new FrmMenuGroup("代码表");
                _mg.MenuItems = new List<FrmMenuItem>();

                _item = new FrmMenuItem("删除代码表", "删除代码表", global::SinoSZMetaDataManager.Properties.Resources.g24, 80);
                _mg.MenuItems.Add(_item);
            }

            if (_value is MD_View_GuideLine)
            {
                _mg = new FrmMenuGroup("模型关联指标扩展");
                _mg.MenuItems = new List<FrmMenuItem>();

                _item = new FrmMenuItem("删除指标", "删除指标", global::SinoSZMetaDataManager.Properties.Resources.g17, 80);
                _mg.MenuItems.Add(_item);
            }
            return _mg;
        }


        internal static List<FrmMenuGroup> GetMenuGroupByControls(System.Windows.Forms.Control _control)
        {
            if (_control is IControlMenu)
            {
                IControlMenu _cm = _control as IControlMenu;
                return _cm.GetControlMenu();
            }
            return null;
        }

        internal static bool RunObjectCommand(string _cmdName, object _value)
        {
            if (_value is MD_Nodes)
            {
                MD_Nodes _node = _value as MD_Nodes;
                switch (_cmdName)
                {
                    case "添加命名空间":
                        return CMD_AddNameSpace(_node);

                    case "添加节点":
                        return CMD_AddNode(_node);

                    case "删除节点":
                        return CMD_DelNode(_node);

                    case "导入命名空间":
                        return CMD_ImportNamespace(_node);

                    case "导出命名空间":
                        return false;
                }
            }

            if (_value is MD_Namespace)
            {
                MD_Namespace _ns = _value as MD_Namespace;
                switch (_cmdName)
                {
                    case "删除命名空间":
                        return CMD_DelNameSpace(_ns);

                    case "添加表":
                        return CMD_AddTable(_ns);

                    case "添加模型":
                        return CMD_AddQueryModel(_ns);

                    case "添加代码表":
                        return CMD_AddRefTable(_ns);

                    case "导出命名空间":
                        return CMD_ExportNameSpace(_ns);

                }
            }

            if (_value is MD_Title)
            {
                MD_Title _title = _value as MD_Title;
                object _ns = _title.FatherObj;
                switch (_title.TitleType)
                {
                    case "MD_TABLE":
                        switch (_cmdName)
                        {
                            case "添加表":
                                return CMD_AddTable(_ns as MD_Namespace);
                            case "删除全部表":
                                return CMD_DelAllTable(_ns as MD_Namespace);
                        }
                        break;

                    case "MD_QUERYMODEL":
                        switch (_cmdName)
                        {
                            case "添加模型":
                                return CMD_AddQueryModel(_ns as MD_Namespace);
                        }
                        break;

                    case "MD_REFTABLE":
                        switch (_cmdName)
                        {
                            case "添加代码表":
                                return CMD_AddRefTable(_ns as MD_Namespace);
                            case "清空代码表":
                                return CMD_DelAllRefTable(_ns as MD_Namespace);

                        }
                        break;
                    case "MD_MENU":
                        switch (_cmdName)
                        {
                            case "添加菜单":
                                return CMD_AddMenu(_ns as MD_Nodes);
                        }
                        break;

                    case "MD_TJZB":
                        switch (_cmdName)
                        {
                            case "添加指标组":
                                return CMD_AddGuideLineGroup(_ns as MD_Nodes, "TJZB");
                        }
                        break;
                    case "MD_REPORTGUIDLINE":
                        switch (_cmdName)
                        {
                            case "添加指标组":
                                return CMD_AddGuideLineGroup(_ns as MD_Nodes, "BBZB");
                        }
                        break;
                    case "MD_CONCEPTGROUP":
                        switch (_cmdName)
                        {
                            case "添加标签组":
                                return CMD_AddConceptGroup();

                        }
                        break;
                    case "MD_VIEW_GUIDELINE":
                        switch (_cmdName)
                        {
                            case "添加关联":
                                return CMD_AddView2GL(_ns as MD_QueryModel);
                            case "清空关联项":
                                return CMD_ClearView2GL(_ns as MD_QueryModel);

                        }
                        break;
                    case "MD_VIEW_APPLICATION":
                        switch (_cmdName)
                        {
                            case "添加应用":
                                return CMD_AddView2APP(_ns as MD_QueryModel);

                            case "清空应用项":
                                return CMD_ClearView2APP(_ns as MD_QueryModel);

                        }
                        break;
                    case "MD_VIEW_EXRIGHT":
                        switch (_cmdName)
                        {
                            case "添加权限":
                                MD_QueryModel _qv = _ns as MD_QueryModel;
                                return CMD_AddViewExRight(_qv.QueryModelID, null);

                        }


                        break;
                }
            }

            if (_value is MD_QueryModel_ExRight)
            {
                MD_QueryModel_ExRight _right = _value as MD_QueryModel_ExRight;
                switch (_cmdName)
                {
                    case "添加子权限":
                        return CMD_AddViewExRight(_right.ModelID, _right);
                    case "删除权限":
                        return CMD_DelViewExRight(_right);


                }
            }

            if (_value is MD_Table && !(_value is MD_ViewTable))
            {
                MD_Table _table = _value as MD_Table;
                switch (_cmdName)
                {
                    case "删除表":
                        return CMD_DelTable(_table);
                    case "关联模型":
                        return CMD_TableRelationView(_table);
                }

            }

            if (_value is MD_QueryModel)
            {
                MD_QueryModel _qm = _value as MD_QueryModel;
                switch (_cmdName)
                {
                    case "添加主表":
                        return CMD_AddMainTable(_qm);
                    case "删除模型":
                        return CMD_DelQueryModel(_qm);
                    case "添加关联组":
                        return CMD_AddView2ViewGroup(_qm);

                }
            }

            if (_value is MD_View2ViewGroup)
            {
                MD_View2ViewGroup _group = _value as MD_View2ViewGroup;
                switch (_cmdName)
                {
                    case "删除关联组":
                        return CMD_DelView2ViewGroup(_group);

                    case "关联模型":
                        return CMD_AddView2View(_group);
                }
            }


            if (_value is MD_View2View)
            {
                MD_View2View _v2v = _value as MD_View2View;
                switch (_cmdName)
                {
                    case "删除关联":
                        return CMD_DelView2View(_v2v.ID);

                }
            }

            if (_value is MD_ViewTable)
            {
                MD_ViewTable _vt = _value as MD_ViewTable;
                switch (_cmdName)
                {
                    case "添加子表":
                        return CMD_AddChildTable(_vt);

                    case "删除表":
                        return CMD_DelViewTable(_vt);

                }
            }

            if (_value is MD_View_GuideLine)
            {
                MD_View_GuideLine _vgl = _value as MD_View_GuideLine;
                switch (_cmdName)
                {
                    case "删除指标":
                        return CMD_Del_View2GL(_vgl);
                }
            }

            if (_value is MD_Menu)
            {
                MD_Menu _menu = _value as MD_Menu;
                switch (_cmdName)
                {
                    case "添加子菜单":
                        return CMD_AddChildMenu(_menu);

                    case "删除菜单":
                        if (CMD_DelMenu(_menu))
                        {
                            return true;
                        }
                        else
                        {
                            XtraMessageBox.Show("删除菜单失败!请先删除子菜单!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        };
                }
            }

            if (_value is MD_GuideLineGroup)
            {
                MD_GuideLineGroup _guideLineGroup = _value as MD_GuideLineGroup;
                switch (_cmdName)
                {
                    case "删除指标组":
                        return CMD_DelGuideLineGroup(_guideLineGroup);

                    case "添加指标":
                        return CMD_AddGuideLineOfGroup(_guideLineGroup);

                }
            }

            if (_value is MD_GuideLine)
            {
                switch (_cmdName)
                {
                    case "添加指标":
                        return CMD_AddChildGuideLine(_value as MD_GuideLine);

                    case "删除指标":
                        return CMD_DelGuideLine(_value as MD_GuideLine);

                    case "导出指标":
                        return CMD_ExportGuideLine(_value as MD_GuideLine);

                    case "导入指标":
                        return CMD_ImportGuideLine(_value as MD_GuideLine);
                }
            }

            if (_value is MD_ConceptGroup)
            {
                switch (_cmdName)
                {
                    case "删除标签组":
                        return CMD_DelConcpetGroup(_value as MD_ConceptGroup);

                    case "添加标签":
                        return CMD_AddConcept(_value as MD_ConceptGroup);

                }
            }

            if (_value is MD_ConceptItem)
            {
                switch (_cmdName)
                {
                    case "删除标签":
                        return CMD_DelConcpetItem(_value as MD_ConceptItem);
                }
            }

            if (_value is MD_RefTable)
            {
                switch (_cmdName)
                {
                    case "删除代码表":
                        return CMD_DelRefTable(_value as MD_RefTable);
                }
            }
            return false;
        }

        private static bool CMD_ClearView2APP(MD_QueryModel _qm)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                string _ret = _mdc.CMD_ClearView2App(_qm.QueryModelID);
                if (_ret.Length == 0)
                {
                    return true;
                }
                else
                {
                    XtraMessageBox.Show(string.Format("清空应用项失败！{0}", _ret), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
        }

        private static bool CMD_AddView2APP(MD_QueryModel _qm)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                MD_View2App _new = new MD_View2App();
                _new.ID = _mdc.GetNewID();
                _new.ViewID = _qm.QueryModelID;
                Dialog_AddView2App _f = new Dialog_AddView2App(_new);
                if (_f.ShowDialog() == DialogResult.OK)
                {
                    MD_View2App _v2app = _f.GetInputData();
                    bool _ret = _mdc.SaveView2App(_v2app.ID, _v2app);
                    if (_ret)
                    {
                        return true;
                    }
                    else
                    {
                        XtraMessageBox.Show("新增集成应用展示失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        private static bool CMD_Del_View2GL(MD_View_GuideLine _vgl)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                string _ret = _mdc.CMD_DelView2GL(_vgl);
                if (_ret.Length == 0)
                {
                    return true;
                }
                else
                {
                    XtraMessageBox.Show(string.Format("删除失败！{0}", _ret), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
        }



        private static bool CMD_DelViewExRight(MD_QueryModel_ExRight ExRight)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {

                string _ret = _mdc.CMD_DelViewExRight(ExRight);
                if (_ret.Length == 0)
                {
                    return true;
                }
                else
                {
                    XtraMessageBox.Show(string.Format("删除失败！{0}", _ret), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
        }


        private static bool CMD_DelView2View(string v2vid)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                string _ret = _mdc.CMD_DelView2View(v2vid);
                if (_ret.Length == 0)
                {
                    return true;
                }
                else
                {
                    XtraMessageBox.Show(_ret, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
        }

        private static bool CMD_AddView2View(MD_View2ViewGroup _group)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                string _ret = _mdc.AddView2View(_group.QueryModelID, _group.ID);
                if (_ret.Length == 0)
                {
                    return true;
                }
                else
                {
                    XtraMessageBox.Show(_ret, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
        }

        private static bool CMD_DelView2ViewGroup(MD_View2ViewGroup _group)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                string _ret = _mdc.DelView2ViewGroup(_group.ID);
                if (_ret.Length == 0)
                {
                    return true;
                }
                else
                {
                    XtraMessageBox.Show(_ret, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
        }

        private static bool CMD_AddView2ViewGroup(MD_QueryModel _qm)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                string _ret = _mdc.AddView2ViewGroup(_qm.QueryModelID);
                if (_ret.Length == 0)
                {
                    return true;
                }
                else
                {
                    XtraMessageBox.Show(_ret, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
        }






        private static bool CMD_ExportNameSpace(MD_Namespace _ns)
        {
            Dialog_ExportNamespace _f = new Dialog_ExportNamespace(_ns);
            _f.ShowDialog();
            return true;
        }

        /// <summary>
        /// 表数据关联到指定模型
        /// </summary>
        /// <param name="_table"></param>
        /// <returns></returns>
        private static bool CMD_TableRelationView(MD_Table _table)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                Dialog_AddTableRelationView _f = new Dialog_AddTableRelationView(_table.TID);
                if (_f.ShowDialog() == DialogResult.OK)
                {
                    string _ret = _mdc.AddTableRelationView(_table.TID, _f.SelectdModelName);
                    if (_ret.Length == 0)
                    {
                        return true;
                    }
                    else
                    {
                        XtraMessageBox.Show(_ret, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// 导入命令空间
        /// </summary>
        /// <param name="_node"></param>
        /// <returns></returns>
        private static bool CMD_ImportNamespace(MD_Nodes _node)
        {
            Dialog_ImportNamesapce _dialog = new Dialog_ImportNamesapce(_node);
            _dialog.ShowDialog();
            return true;
        }

        /// <summary>
        /// 导出指标
        /// </summary>
        /// <param name="mD_GuideLine"></param>
        /// <returns></returns>
        private static bool CMD_ExportGuideLine(MD_GuideLine _GuideLine)
        {
            Dialog_ExportGuideLine _dialog = new Dialog_ExportGuideLine(_GuideLine);
            _dialog.ShowDialog();
            return false;
        }

        /// <summary>
        /// 导入指标
        /// </summary>
        /// <param name="mD_GuideLine"></param>
        /// <returns></returns>
        private static bool CMD_ImportGuideLine(MD_GuideLine _guideLine)
        {
            Dialog_ImportGuideLine _dialog = new Dialog_ImportGuideLine(_guideLine);
            if (_dialog.ShowDialog() == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CMD_DelConcpetItem(MD_ConceptItem _ConceptItem)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                return _mdc.DelConceptTag(_ConceptItem.CTag);
            }
        }

        private static bool CMD_DelRefTable(MD_RefTable _RefTable)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                return _mdc.DelRefTable(_RefTable.RefTableID);
            }
        }

        private static bool CMD_DelAllRefTable(MD_Namespace _MDNamespace)
        {
            frmProgress _f = new frmProgress();
            _f.Show();
            Application.DoEvents();
            foreach (MD_RefTable _table in _MDNamespace.RefTableList)
            {
                _f.ShowMsg(string.Format("正在删除代码表 [ {0} ] ....", _table.RefTableName));
                Application.DoEvents();
                CMD_DelRefTable(_table);
            }
            _f.Hide();
            _f.Dispose();
            return true;
        }

        private static bool CMD_AddConcept(MD_ConceptGroup _ConceptGroup)
        {
            Dialog_AddConceptTag _f = new Dialog_AddConceptTag();
            if (_f.ShowDialog() == DialogResult.OK)
            {
                using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
                {
                    string _TagName = _f.TagName;
                    string _description = _f.Descript;

                    if (_mdc.IsExistConceptTag(_TagName))
                    {
                        XtraMessageBox.Show("此概念标签已经存在!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    return _mdc.AddNewConceptTag(_TagName, _description, _ConceptGroup.Name);
                }
            }
            return true;
        }

        private static bool CMD_DelConcpetGroup(MD_ConceptGroup _ConceptGroup)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                if (_mdc.IsExistChildOfConceptGroup(_ConceptGroup.Name))
                {
                    XtraMessageBox.Show("请先删除下级定义!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                return _mdc.DelConcpetGroup(_ConceptGroup.Name);
            }
        }

        private static bool CMD_AddConceptGroup()
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                Dialog_AddConceptGroup _f = new Dialog_AddConceptGroup();
                if (_f.ShowDialog() == DialogResult.OK)
                {
                    string _groupName = _f.GroupName;
                    if (_mdc.IsExistConceptGroup(_groupName))
                    {
                        XtraMessageBox.Show("此概念标签组已经存在!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    return _mdc.AddNewConceptGroup(_groupName);
                }
                return true;
            }
        }


        private static bool CMD_DelGuideLine(MD_GuideLine _guideLine)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                DialogResult _ask = XtraMessageBox.Show(string.Format(" 您确定要删除指标[{0}]吗?", _guideLine.GuideLineName), "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_ask == DialogResult.Yes)
                {

                    if (_mdc.IsExistChildOfGuideLine(_guideLine.ID))
                    {
                        DialogResult _ret = XtraMessageBox.Show("此指标下有下级子指标定义,删除操作会同时删除子指标! \n 您确定要删除吗?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (_ret == DialogResult.No)
                        {
                            return false;
                        }
                    }

                    return _mdc.DelGuideLine(_guideLine.ID);
                }
                return false;
            }
        }

        private static bool CMD_AddChildGuideLine(MD_GuideLine _guideLine)
        {
            Dialog_AddGuideLine _addGuideLine = new Dialog_AddGuideLine(_guideLine.GroupName, decimal.Parse(_guideLine.ID));
            if (_addGuideLine.ShowDialog() == DialogResult.OK)
            {
                return _addGuideLine.SaveData();
            }
            else
            {
                return false;
            }
        }

        private static bool CMD_AddGuideLineGroup(MD_Nodes _nodes, string _groupType)
        {

            Dialog_AddGuideLineGroup _addGuideLineGroup = new Dialog_AddGuideLineGroup(_nodes, _groupType);
            if (_addGuideLineGroup.ShowDialog() == DialogResult.OK)
            {
                return _addGuideLineGroup.SaveData();

            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 添加指标组下的指标
        /// </summary>
        /// <param name="_guideLineGroup"></param>
        /// <returns></returns>
        private static bool CMD_AddGuideLineOfGroup(MD_GuideLineGroup _guideLineGroup)
        {
            Dialog_AddGuideLine _addGuideLine = new Dialog_AddGuideLine(_guideLineGroup);
            if (_addGuideLine.ShowDialog() == DialogResult.OK)
            {
                return _addGuideLine.SaveData();
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除指标组
        /// </summary>
        /// <param name="_guideLineGroup"></param>
        /// <returns></returns>
        private static bool CMD_DelGuideLineGroup(MD_GuideLineGroup _guideLineGroup)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                if (_mdc.IsExistChildOfGuideLineGroup(_guideLineGroup.ZBZTMC))
                {
                    XtraMessageBox.Show("请先删除指标组中含有指标定义!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                return _mdc.DelGuideLineGroup(_guideLineGroup.ZBZTMC);
            }
        }

        /// <summary>
        /// 删除系统菜单
        /// </summary>
        /// <param name="_menu"></param>
        /// <returns></returns>
        private static bool CMD_DelMenu(MD_Menu _menu)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                return _mdc.DelSystemMenu(_menu.MenuID);
            }
        }

        /// <summary>
        /// 添加系统菜单
        /// </summary>
        /// <param name="mD_Nodes"></param>
        /// <returns></returns>
        private static bool CMD_AddMenu(MD_Nodes _nodes)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                return _mdc.AddSystemMenu(_nodes.DWDM);
            }
        }


        private static bool CMD_AddChildMenu(MD_Menu _menu)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                return _mdc.AddSystemSubMenu(_menu.MenuID, _menu.SystemID);
            }
        }

        /// <summary>
        /// 添加代码表
        /// </summary>
        /// <param name="_ns"></param>
        /// <returns></returns>
        private static bool CMD_AddRefTable(MD_Namespace _ns)
        {
            Dialog_AddRefTable _addNode = new Dialog_AddRefTable(_ns);
            if (_addNode.ShowDialog() == DialogResult.OK)
            {
                _addNode.SaveData();
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 删除数据表
        /// </summary>
        /// <param name="_table"></param>
        /// <returns></returns>
        private static bool CMD_DelTable(MD_Table _table)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                if (_mdc.IsExistViewUsedTable(_table.TID))
                {
                    XtraMessageBox.Show(string.Format("存在使用[{0}]表的查询模型，请先在查询模型中删除此表！", _table.TableName), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {

                    if (_mdc.DelTableMeta(_table.TID))
                    {
                        return true;
                    }
                    else
                    {
                        XtraMessageBox.Show(string.Format("删除[{0}]表的元数据失败！", _table.TableName), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                }
            }
        }


        private static bool CMD_DelAllTable(MD_Namespace _MDNamespace)
        {
            frmProgress _f = new frmProgress();
            _f.Show();
            Application.DoEvents();
            if (_MDNamespace.TableList != null)
            {
                foreach (MD_Table _table in _MDNamespace.TableList)
                {
                    _f.ShowMsg(string.Format("正在删除数据表 [ {0} ] ....", _table.TableName));
                    Application.DoEvents();
                    CMD_DelTable(_table);
                }
            }
            _f.Hide();
            _f.Dispose();
            return true;
        }


        /// <summary>
        /// 删除查询模型
        /// </summary>
        /// <param name="_qm"></param>
        /// <returns></returns>
        private static bool CMD_DelQueryModel(MD_QueryModel _qm)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                if (_mdc.IsExistChildOfView(_qm.QueryModelID))
                {

                    if (XtraMessageBox.Show("因为此查询模型中存在主表，请先删除主表后才可删除查询模型！您是否确认要强行删除此模型？", "系统提示", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if (_mdc.DelViewAndChildren(_qm.QueryModelID))
                        {
                            return true;
                        }
                        else
                        {
                            XtraMessageBox.Show("删除此查询模型失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                //if (SinoSZMetaConfig.MetaDataFactroy.IsExistGroupOfView(_qm.QueryModelID))
                //{
                //        XtraMessageBox.Show("请先在查询主题中删除此查询模型！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        return;
                //}
                else
                {
                    if (_mdc.DelViewMeta(_qm.QueryModelID))
                    {
                        return true;
                    }
                    else
                    {
                        XtraMessageBox.Show("删除此查询模型失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// 删除查询模型中的表
        /// </summary>
        /// <param name="_vt"></param>
        /// <returns></returns>
        private static bool CMD_DelViewTable(MD_ViewTable _vt)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                if (_mdc.IsExistChildTable(_vt.ViewTableID))
                {
                    XtraMessageBox.Show("请先删除子表！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    if (_mdc.DelViewTable(_vt.ViewTableID))
                    {
                        return true;
                    }
                    else
                    {
                        XtraMessageBox.Show("删除模型中的表失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                return true;
            }
        }



        /// <summary>
        /// 添加查询模型中的子表
        /// </summary>
        /// <param name="_vt"></param>
        /// <returns></returns>
        private static bool CMD_AddChildTable(MD_ViewTable _vt)
        {
            Dialog_AddMainTable _addMainTable = new Dialog_AddMainTable(_vt);
            if (_addMainTable.ShowDialog() == DialogResult.OK)
            {
                _addMainTable.SaveNewChildTable();
                return true;
            }
            else
            {
                return false;
            }

        }



        /// <summary>
        /// 添加主表
        /// </summary>
        /// <param name="_qm"></param>
        /// <returns></returns>
        private static bool CMD_AddMainTable(MD_QueryModel _qm)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                //验证是否已经存在主表
                if (_mdc.GetMainTableOfQueryModel(_qm.QueryModelID) != null)
                {
                    XtraMessageBox.Show("查询模型中已经存在主表!不能再次添加!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                };
                Dialog_AddMainTable _addMainTable = new Dialog_AddMainTable(_qm);
                if (_addMainTable.ShowDialog() == DialogResult.OK)
                {
                    _addMainTable.SaveNewData();
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        /// <summary>
        /// 添加查询模型
        /// </summary>
        /// <param name="_ns"></param>
        /// <returns></returns>
        private static bool CMD_AddQueryModel(MD_Namespace _ns)
        {
            Dialog_AddQueryModel _addModel = new Dialog_AddQueryModel(_ns);
            if (_addModel.ShowDialog() == DialogResult.OK)
            {
                _addModel.SaveData();
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="_node"></param>
        /// <returns></returns>
        private static bool CMD_DelNode(MD_Nodes _node)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                if (_node.NameSpaces.Count > 0)
                {
                    XtraMessageBox.Show("请先删除此节点下的命名空间!", "系统提示");
                    return false;
                }

                DialogResult _res = XtraMessageBox.Show(string.Format("是否删除节点[{0}]?", _node.DisplayTitle),
                                        "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_res == DialogResult.Yes)
                {
                    return _mdc.DelNodes(_node.ID);
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="_node"></param>
        /// <returns></returns>
        private static bool CMD_AddNode(MD_Nodes _node)
        {
            Dialog_AddNode _addNode = new Dialog_AddNode();
            if (_addNode.ShowDialog() == DialogResult.OK)
            {
                _addNode.SaveData();
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CMD_AddViewExRight(string ViewID, MD_QueryModel_ExRight fatherRight)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                Dialog_AddExtendRight _f = new Dialog_AddExtendRight();
                if (_f.ShowDialog() == DialogResult.OK)
                {
                    return _mdc.AddNewViewExRight(_f.RightValue, _f.RightTitle, ViewID, fatherRight);
                }
                else
                {
                    return false;
                }
            }
        }


        /// <summary>
        /// 添加命名空间
        /// </summary>
        /// <param name="_node"></param>
        /// <returns></returns>
        private static bool CMD_AddNameSpace(MD_Nodes _node)
        {
            Dialog_AddNameSpace _f = new Dialog_AddNameSpace(_node);
            if (_f.ShowDialog() == DialogResult.OK)
            {
                _f.SaveData(_node);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除命名空间
        /// </summary>
        /// <param name="_ns"></param>
        /// <returns></returns>
        private static bool CMD_DelNameSpace(MD_Namespace _ns)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                if (_ns.QueryModelList != null && _ns.QueryModelList.Count > 0)
                {
                    XtraMessageBox.Show("请先删除此命名空间下的查询模型!", "系统提示");
                    return false;
                }

                if (_ns.TableList != null && _ns.TableList.Count > 0)
                {
                    XtraMessageBox.Show("请先删除此命名空间下的表定义!", "系统提示");
                    return false;
                }

                DialogResult _res = XtraMessageBox.Show(string.Format("是否删除命名空[{0}]?", _ns.DisplayTitle),
                                        "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_res == DialogResult.Yes)
                {
                    if (_mdc.DelNamespace(_ns))
                    {
                        return true;
                    }
                    else
                    {
                        XtraMessageBox.Show("删除失败！请先删除此命名空间下的表和查询模型!", "系统提示");
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 添加表
        /// </summary>
        /// <param name="_ns"></param>
        /// <returns></returns>
        private static bool CMD_AddTable(MD_Namespace _ns)
        {
            Dialog_AddTable _addNode = new Dialog_AddTable(_ns);
            if (_addNode.ShowDialog() == DialogResult.OK)
            {
                _addNode.SaveData();
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CMD_ClearView2GL(MD_QueryModel _view)
        {
            return false;
        }

        private static bool CMD_AddView2GL(MD_QueryModel _view)
        {
            Dialog_AddView2GL _addNode = new Dialog_AddView2GL(_view);
            if (_addNode.ShowDialog() == DialogResult.OK)
            {
                _addNode.SaveData();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
