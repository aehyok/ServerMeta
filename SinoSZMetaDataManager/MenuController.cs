using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SinoSZPluginFramework;
using SinoSZPluginFramework.ClientPlugin;
using SinoSZJS.Base.Misc;
using SinoSZMetaDataManager.QueryModelEditor;

namespace SinoSZMetaDataManager
{
        public class MenuController
        {
                static public bool DoCommand(string _menuID,string _commandName, string _commandTitle, IApplication _application, object _commandParam)
                {
                        string _param = (_commandParam == null) ? "" : _commandParam.ToString();
                        switch (_commandName)
                        {
                                case "GlobalDefine":    //全局定义
                                        DoGlobalDefine(_application);
                                        break;
                                case "NodeDefine":      //节点定义
                                        DoNodeDefine(_application);
                                        break;
                                case "GuideLineDefine": //指标定义
                                        DoGuideLineDefine(_application);
                                        break;
                                case "QueryModelEditor":
                                        string _title = StrUtils.GetMetaByName2("标题", _param);
                                        frmQueryModelEditor _frm = MenuFunctions.AddPage<frmQueryModelEditor>(_title, _application);
                                        if (_frm != null)
                                        {
                                                _frm.Init(_title, "查询模型管理", _param);
                                        }
                                        break;
                        }
                        return true;
                }




                private static void DoGuideLineDefine(IApplication _application)
                {
                        string _frmName = Guid.NewGuid().ToString();
                        MenuFunctions.AddPage<frmGuideLineManager>(_frmName, _application);
                }

                private static void DoNodeDefine(IApplication _application)
                {
                        string _frmName = "NodeDefine";
                        MenuFunctions.AddPage<frmNodeManager>(_frmName, _application);
                }


                private static void DoGlobalDefine(IApplication _application)
                {
                        string _frmName = "GlobalDefine";
                        MenuFunctions.AddPage<frmGlobalManager>(_frmName, _application);
                }


        }
}
