using System;
using System.Collections.Generic;
using System.Text;
using SinoSZPluginFramework;
using SinoSZClientSysManager.UserLog;
using SinoSZClientSysManager.SystemLog;
using SinoSZClientSysManager.Notify;
using SinoSZPluginFramework.ClientPlugin;
using SinoSZClientSysManager.InterfaceManager;
using SinoSZClientSysManager.Organize;
using SinoSZJS.Base.Misc;
using SinoSZClientSysManager.FsAlertMailSet;
using SinoSZClientSysManager.TaskManager;
using SinoSZClientSysManager.QueryLog;
using SinoSZClientSysManager.WorkCalendar;
using SinoSZClientSysManager.ResetServer;
using SinoSZClientSysManager.GDSManager;

namespace SinoSZClientSysManager
{
    public class MenuController
    {
        static public bool DoCommand(string _menuID, string _commandName, string _commandTitle, string _param, IApplication _application)
        {
            string _title;
            switch (_commandName)
            {
                case "IISRecycle":
                    frmResetIISApp _frmIIS = MenuFunctions.AddPage<frmResetIISApp>("内存回收", _application);
                    if (_frmIIS != null)
                    {
                        _frmIIS.Init("内存回收", "内存回收", _param);
                    }
                    break;

                case "WinServiceWatch":
                    frmResetWindowsService _frmWinService = MenuFunctions.AddPage<frmResetWindowsService>("服务查看", _application);
                    if (_frmWinService != null)
                    {
                        _frmWinService.Init("服务查看", "服务查看", _param);
                    }
                    break;

                case "OrganizeExtInfo":
                    frmOrganizeExtInfo _frmOrgExt = MenuFunctions.AddPage<frmOrganizeExtInfo>("组织机构信息维护", _application);
                    if (_frmOrgExt != null)
                    {
                        _frmOrgExt.Init("组织机构信息维护", "机构信息维护", _param);
                    }
                    break;

                case "UserLog":
                    frmUserLog _rdf = new frmUserLog();
                    _application.AddForm("用户操作日志", _rdf);
                    break;

                case "QueryLog":
                    frmQueryLog _fql = new frmQueryLog();
                    _application.AddForm("数据查询日志", _fql);
                    break;

                case "SystemLog":
                    frmSystemLog _syslog = new frmSystemLog();
                    _application.AddForm("系统处理日志", _syslog);
                    break;
                case "Notify":
                    frmNotifyInfo _frm = MenuFunctions.AddPage<frmNotifyInfo>("通知通告", _application);
                    if (_frm != null)
                    {
                        _frm.Init("通知通告", "通知通告", "");
                    }
                    break;
                case "InterfaceManager_SJJH":
                    frmIM_SJJH _frmIM_SJJH = MenuFunctions.AddPage<frmIM_SJJH>("数据交换接口管理", _application);
                    if (_frmIM_SJJH != null)
                    {
                        _frmIM_SJJH.Init("数据交换接口管理", "数据交换接口管理", "");
                    }
                    break;

                case "FSDataLoadAlertMailSet":  //数据加载监控提示邮件设置
                    _title = StrUtils.GetMetaByName2("标题", _param);
                    frmFsAlertMainSet _frmFsAlert = MenuFunctions.AddPage<frmFsAlertMainSet>(_title, _application);
                    if (_frmFsAlert != null)
                    {
                        _frmFsAlert.Init(_title, "邮件设置", _param);
                    }
                    break;

                case "TaskManager": //后台任务管理器
                    _title = StrUtils.GetMetaByName2("标题", _param);
                    frmTaskManager _frmTaskManager = MenuFunctions.AddPage<frmTaskManager>(_title, _application);
                    if (_frmTaskManager != null)
                    {
                        _frmTaskManager.Init(_title, "任务管理", _param);
                    }
                    break;

                case "WorkCalendar"://工作日历
                    _title = "工作日历";
                    WorkCalenderForm _frmWorkCalenderForm = MenuFunctions.AddPage<WorkCalenderForm>(_title, _application);
                    if (_frmWorkCalenderForm != null)
                    {
                        _frmWorkCalenderForm.Init(_title, "工作日历", _param);
                    }
                    break;

                case "GDSManager":
                    _title = "通用接口管理";
                    frmGDSManager _frmGDSManager = MenuFunctions.AddPage<frmGDSManager>(_title, _application);
                    if (_frmGDSManager != null)
                    {
                        _frmGDSManager.Init(_title, _title, _param);
                    }
                    break;
            }
            return true;
        }
    }
}
