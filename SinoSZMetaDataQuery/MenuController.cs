using System;
using System.Collections.Generic;
using System.Text;
using SinoSZPluginFramework;
using SinoSZMetaDataQuery.DataQuery;
using SinoSZJS.Base.Misc;
using SinoSZMetaDataQuery.DataCompare;
using SinoSZMetaDataQuery.DataSearch;
using SinoSZMetaDataQuery.GuideLineQuery;
using SinoSZMetaDataQuery.Portal;
using SinoSZPluginFramework.ClientPlugin;
using SinoSZMetaDataQuery.AlertMonitor;
using SinoSZMetaDataQuery.FixQuery;
using SinoSZMetaDataQuery.GuideLineSetting;

namespace SinoSZMetaDataQuery
{
        public class MenuController
        {
                static public bool DoCommand(string _menuID,string _commandName, string _commandTitle, string _param, IApplication _application)
                {
                        string _modelName;
                        string _guidLines;
                        string _glqTitle;
                        string _title;
                        switch (_commandName)
                        {

                                case "RelationQuery":
                                        _modelName = StrUtils.GetMetaByName("查询模型", _param);
                                        frmSinoSZ_RelationQuery _f = new frmSinoSZ_RelationQuery(_modelName,_param);
					_f.Tag = _menuID;
                                        _application.AddForm(Guid.NewGuid().ToString(), _f);
                                        break;
                                case "FixQuery":
                                        _title = StrUtils.GetMetaByName2("标题", _param);
                                        frmFixQuery _frmFixQuery = MenuFunctions.AddPage<frmFixQuery>(_title, _application);
                                        if (_frmFixQuery != null)
                                        {
                                                _frmFixQuery.Init(_title, _title, _param);
                                        }
                                        break;
                                case "SingleGuideLineQuery":
                                        _title = StrUtils.GetMetaByName2("标题", _param);
                                        frmGuideLineQuery_Single _frmSingleGuideLine = MenuFunctions.AddPage<frmGuideLineQuery_Single>(_title, _application);
                                        if (_frmSingleGuideLine != null)
                                        {
                                                _frmSingleGuideLine.Init(_title, _title, _param);
                                        }
                                        break;
                                case "DataCompare":
                                      
					frmDataCompare _f2 = new frmDataCompare( _param);
                                        _application.AddForm(Guid.NewGuid().ToString(), _f2);
                                        break;
                                case "DataSearch":
                                        _modelName = StrUtils.GetMetaByName("查询模型", _param);
                                        frmDataSearch _f3 = new frmDataSearch(_modelName);
                                        _application.AddForm(Guid.NewGuid().ToString(), _f3);
                                        break;
                                case "GuideLineQuery":
                                        _guidLines = StrUtils.GetMetaByName("指标ID", _param);
                                        _glqTitle = StrUtils.GetMetaByName("标题", _param);
                                        frmGuideLineQuery _f4 = new frmGuideLineQuery((_glqTitle == "") ? _commandTitle : _glqTitle, _guidLines);
                                        _application.AddForm(Guid.NewGuid().ToString(), _f4);
                                        break;
                                case "GuideLineQueryEx":
                                        _guidLines = StrUtils.GetMetaByName("指标ID", _param);
                                        _glqTitle = StrUtils.GetMetaByName("标题", _param);
                                        frmGuideLineQueryEx _f4ex = new frmGuideLineQueryEx((_glqTitle == "") ? _commandTitle : _glqTitle, _guidLines);
                                        _application.AddForm(Guid.NewGuid().ToString(), _f4ex);
                                        break;
                                case "GuideLineShow":
                                        string _guidLineID = StrUtils.GetMetaByName2("指标ID", _param);
                                        string _params = StrUtils.GetMetaByName2("参数", _param);
                                        bool _canGroup = (StrUtils.GetMetaByName2("可分组", _param).ToUpper() == "TRUE");
                                        _title = StrUtils.GetMetaByName2("标题", _param);
                                        frmGuideLineQueryWithoutInput _f5 = new frmGuideLineQueryWithoutInput(_title, _guidLineID, _params, _canGroup);
                                        _application.AddForm(_title, _f5);
                                        break;
                                case "GuideLineGroupShow":
                                        frmGuideLineGroupShow _f6 = new frmGuideLineGroupShow(_param);
                                        _application.AddForm(_commandTitle, _f6);
                                        break;
                                case "GuideLineGroupShow2":
                                        _title = StrUtils.GetMetaByName2("标题", _param);
                                        frmGuideLineGroupShow2 _f7 = new frmGuideLineGroupShow2(_param);
                                        _application.AddForm(_title, _f7);
                                        break;
                                case "PortalShow":
                                        frmPortal _fPortal = new frmPortal(_param, _application);
                                        _application.AddForm(_commandTitle, _fPortal);
                                        break;

                                case "RelationQueryTask":
                                        _modelName = StrUtils.GetMetaByName("查询模型", _param);
                                        frmSinoSZ_RelationQuery_Task _f8 = new frmSinoSZ_RelationQuery_Task(_modelName,_param);
                                        _application.AddForm(Guid.NewGuid().ToString(), _f8);
                                        break;
                                case "QueryTaskList":
                                        frmSinoSZ_TaskList _f9 = new frmSinoSZ_TaskList();
                                        _application.AddForm(_commandTitle, _f9);
                                        break;
                                case "TreeComboPortalShow":
                                        _title = StrUtils.GetMetaByName2("标题", _param);
                                        frmTreeComboPortal _frm = MenuFunctions.AddPage<frmTreeComboPortal>(_title, _application);
                                        if (_frm != null)
                                        {
                                                _frm.Init(_title, _title, _param);
                                        }
                                        break;
                                case "AlertMonitor":
                                        _title = StrUtils.GetMetaByName2("标题", _param);
                                        frmAlertMonitor _frmAert = MenuFunctions.AddPage<frmAlertMonitor>(_title, _application);
                                        if (_frmAert != null)
                                        {
                                                _frmAert.Init(_title, _title, _param);
                                        }
                                        break;
                                case "ParameterSetting":
                                        _title = StrUtils.GetMetaByName2("标题", _param);
                                        frmGuideLineSetting _frmSetting = MenuFunctions.AddPage<frmGuideLineSetting>(_title, _application);
                                        if (_frmSetting != null)
                                        {
                                                _frmSetting.Init(_title, _title, _param);
                                        }
                                        break;
                        }
                        return true;
                }
        }
}
