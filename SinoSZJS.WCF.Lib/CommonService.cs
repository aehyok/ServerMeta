using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SinoSZJS.CS.BizAuthorize;
using SinoSZJS.CS.BizMenu.DAL;
using SinoSZJS.CS.BizUser;
using SinoSZJS.CS.BizMetaDataManager.DAL;
using SinoSZJS.Base.Config;
using SinoSZJS.Base.WorkCalendar;
using SinoSZJS.Base.SystemLog;
using System.ServiceProcess;
using System.DirectoryServices;
using SinoSZJS.Base.JSGDS;
using System.Data;
using System.Reflection;
using System.IO;
using SinoSZJS.Base.Misc;


namespace SinoSZJS.WCF.Lib
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“CommonService”。
    public class CommonService : ICommonService
    {
        private static ServerConfig _serverConfigData = null;
        public List<Base.Authorize.SinoOrganize> GetRootDwList(string RootDWID, decimal LevelNum)
        {
            try
            {
                OraAuthorizeFactroy _of = new OraAuthorizeFactroy();
                return _of.GetRootDwList(RootDWID, LevelNum);
            }
            catch (Exception ex)
            {
                string _error = string.Format("取RootDWList[RootDWID={1} LevelNum={2}]时发生错误！{0}", ex.Message, RootDWID, LevelNum);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return new List<Base.Authorize.SinoOrganize>();
            }
        }

        public List<Base.Authorize.SinoOrganize> GetRootDwListEx(string RootDWID, decimal LevelNum, string OrgType)
        {
            try
            {
                OraAuthorizeFactroy _of = new OraAuthorizeFactroy();
                return _of.GetRootDwListEx(RootDWID, LevelNum, OrgType);
            }
            catch (Exception ex)
            {
                string _error = string.Format("取GetRootDwListEx[RootDWID={1} LevelNum={2} OrgType={3}]时发生错误！{0}", ex.Message, RootDWID, LevelNum, OrgType);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return new List<Base.Authorize.SinoOrganize>();
            }
        }

        public Base.Config.ServerConfig GetServerConfig()
        {
            try
            {
                if (_serverConfigData == null)
                {
                    _serverConfigData = LocalConfigData.InitServerConfig();
                }

                return _serverConfigData;
            }
            catch (Exception ex)
            {
                string _error = string.Format("取GetServerConfig时发生错误！{0}", ex.Message);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                throw new FaultException(_error, new FaultCode("服务"));
            }

        }

        public decimal GetDWIDByDWDM(string _dwdm)
        {
            try
            {
                OraAuthorizeFactroy _of = new OraAuthorizeFactroy();
                return _of.GetDWIDByDWDM(_dwdm);
            }
            catch (Exception ex)
            {
                string _error = string.Format("取GetDWIDByDWDM[{1}]时发生错误！{0}", ex.Message, _dwdm);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                throw new FaultException(_error, new FaultCode("服务"));
            }
        }

        public void WriteExportLog(int ExportRowCount, string ExportDataMsg)
        {
            try
            {
                OraAuthorizeFactroy _of = new OraAuthorizeFactroy();
                _of.WriteExportLog(ExportRowCount, ExportDataMsg);
            }
            catch (Exception ex)
            {
                string _error = string.Format("写入导出日志时[ExportRowCount={1} ExportDataMsg={2}]时发生错误！{0}", ex.Message, ExportRowCount, ExportDataMsg);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                throw new FaultException(_error, new FaultCode("服务"));
            }
        }

        public void WriteClientUserLog(string Message, string LogType)
        {
            try
            {
                OraAuthorizeFactroy _of = new OraAuthorizeFactroy();
                _of.WriteClientUserLog(Message, LogType);
            }
            catch (Exception ex)
            {
                string _error = string.Format("写入客户端用户日志时[Message={1} LogType={2}]时发生错误！{0}", ex.Message, Message, LogType);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                throw new FaultException(_error, new FaultCode("服务"));
            }
        }


        public List<Base.MenuType.SinoMenuItem> GetAllMenus(string PostID)
        {
            try
            {
                OraMenuFactory _of = new OraMenuFactory();
                return _of.GetAllMenus(PostID);
            }
            catch (Exception ex)
            {
                string _error = string.Format("取所有菜单定义时[PostID={1}]时发生错误！{0}", ex.Message, PostID);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return new List<Base.MenuType.SinoMenuItem>();
            }
        }

        public List<Base.MenuType.firstPageItem> GetfirstPage()
        {
            try
            {
                OraMenuFactory _of = new OraMenuFactory();
                return _of.GetfirstPage();
            }
            catch (Exception ex)
            {
                string _error = string.Format("取首页定义数据时发生错误！{0}", ex.Message);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return new List<Base.MenuType.firstPageItem>();
            }
        }


        public bool WriteUserLog(decimal YHID, string CZLX, string CXNR, decimal ResultType, string IpAddr, string HostName, string SystemID)
        {
            try
            {
                OraSysManagerFactroy _of = new OraSysManagerFactroy();
                return _of.WriteUserLog(YHID, CZLX, CXNR, ResultType, IpAddr, HostName, SystemID);
            }
            catch (Exception ex)
            {
                string _error = string.Format("写入用户操作日志时时发生错误！{0}", ex.Message);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
        }

        public List<Base.UserLog.UserLogRecord> GetUserLog(DateTime StartDate, DateTime EndDate, string UserName, string Context)
        {
            try
            {
                OraSysManagerFactroy _of = new OraSysManagerFactroy();
                return _of.GetUserLog(StartDate, EndDate, UserName, Context);
            }
            catch (Exception ex)
            {
                string _error = string.Format("取用户操作日志时[UserName={1} Context={2}]时发生错误！{0}", ex.Message, UserName, Context);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return new List<Base.UserLog.UserLogRecord>();
            }
        }

        public List<Base.SystemLog.SystemLogRecord> GetSystemLog(DateTime StartDate, DateTime EndDate, string LogType, string Context)
        {
            try
            {
                OraSysManagerFactroy _of = new OraSysManagerFactroy();
                return _of.GetSystemLog(StartDate, EndDate, LogType, Context);
            }
            catch (Exception ex)
            {
                string _error = string.Format("取系统运行日志时时发生错误！{0}", ex.Message);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return new List<SystemLogRecord>();
            }
        }

        public System.Data.DataTable GetNotifyList(int _num)
        {
            try
            {
                OraSysManagerFactroy _of = new OraSysManagerFactroy();
                return _of.GetNotifyList(_num);
            }
            catch (Exception ex)
            {
                string _error = string.Format("取提示列表时发生错误！{0}", ex.Message);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return null;
            }
        }

        public Base.Notify.NotifyInfo GetNotifyInfo(string _msgid)
        {
            try
            {
                OraSysManagerFactroy _of = new OraSysManagerFactroy();
                return _of.GetNotifyInfo(_msgid);
            }
            catch (Exception ex)
            {
                string _error = string.Format("取提示信息[MsgID={1}]时发生错误！{0}", ex.Message, _msgid);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return null;
            }
        }

        public bool SaveNotifyInfo(Base.Notify.NotifyInfo _info)
        {
            try
            {
                OraSysManagerFactroy _of = new OraSysManagerFactroy();
                return _of.SaveNotifyInfo(_info);
            }
            catch (Exception ex)
            {
                string _error = string.Format("保存提示信息时发生错误！{0}", ex.Message);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
        }

        public bool DeleteNotifyInfo(Base.Notify.NotifyInfo CurrentInfo)
        {
            try
            {
                OraSysManagerFactroy _of = new OraSysManagerFactroy();
                return _of.DeleteNotifyInfo(CurrentInfo);
            }
            catch (Exception ex)
            {
                string _error = string.Format("删除提示信息[NotifyInfoID={1}]时发生错误！{0}", ex.Message, CurrentInfo.ID);
                ///SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
        }

        public List<Base.OrganizeExt.OrgExtInfo> GetOrgExtRootData(List<Base.OrganizeExt.OrgExtFieldDefine> PropertieDefines)
        {
            try
            {
                OraSysManagerFactroy _of = new OraSysManagerFactroy();
                return _of.GetOrgExtRootData(PropertieDefines);
            }
            catch (Exception ex)
            {
                string _error = string.Format("取扩展组织机构数据信息时发生错误！{0}", ex.Message);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return new List<Base.OrganizeExt.OrgExtInfo>();
            }
        }

        public List<Base.OrganizeExt.OrgExtInfo> GetOrgExtChildData(string _fid, List<Base.OrganizeExt.OrgExtFieldDefine> PropertieDefines)
        {
            try
            {
                OraSysManagerFactroy _of = new OraSysManagerFactroy();
                return _of.GetOrgExtChildData(_fid, PropertieDefines);
            }
            catch (Exception ex)
            {
                string _error = string.Format("取扩展组织机构子数据信息时发生错误！{0}", ex.Message);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return new List<Base.OrganizeExt.OrgExtInfo>();
            }
        }

        public bool SaveOrgExtList(List<Base.OrganizeExt.OrgExtInfo> BeSavedDataList, List<Base.OrganizeExt.OrgExtFieldDefine> PropertieDefines)
        {
            try
            {
                OraSysManagerFactroy _of = new OraSysManagerFactroy();
                return _of.SaveOrgExtList(BeSavedDataList, PropertieDefines);
            }
            catch (Exception ex)
            {
                string _error = string.Format("保存扩展组织机构信息时发生错误！{0}", ex.Message);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
        }

        public Base.TaskInfo.SinoTaskInfo GetTaskInfo(string TaskID)
        {
            try
            {
                OraSysManagerFactroy _of = new OraSysManagerFactroy();
                return _of.GetTaskInfo(TaskID);
            }
            catch (Exception ex)
            {
                string _error = string.Format("取任务信息[TaskID={1}]时发生错误！{0}", ex.Message, TaskID);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return null;
            }
        }

        public System.Data.DataTable GetTaskLog(string TaskID, DateTime LastTime, bool GetStartData, bool OnlyErrorData)
        {
            try
            {
                OraSysManagerFactroy _of = new OraSysManagerFactroy();
                return _of.GetTaskLog(TaskID, LastTime, GetStartData, OnlyErrorData);
            }
            catch (Exception ex)
            {
                string _error = string.Format("取任务处理日志[TaskID={1}]时发生错误！{0}", ex.Message, TaskID);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return null;
            }
        }

        public string SetTaskState(string TaskID, int NewState, int LimitState)
        {
            try
            {
                OraSysManagerFactroy _of = new OraSysManagerFactroy();
                return _of.SetTaskState(TaskID, NewState, LimitState);
            }
            catch (Exception ex)
            {
                string _error = string.Format("设置任务状态[TaskID={1}]时发生错误！{0}", ex.Message, TaskID);
                ///SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return "";
            }
        }

        public string ResetTaskParam(string TaskID, DateTime NextTime, string NewParam)
        {
            try
            {
                OraSysManagerFactroy _of = new OraSysManagerFactroy();
                return _of.ResetTaskParam(TaskID, NextTime, NewParam);
            }
            catch (Exception ex)
            {
                string _error = string.Format("重置任务参数[TaskID={1}]时发生错误！{0}", ex.Message, TaskID);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return null;
            }
        }

        public List<Base.SystemLog.QueryLogRecord> GetQueryLog(DateTime _startDate, DateTime _endDate, string _userName)
        {
            try
            {
                OraSysManagerFactroy _of = new OraSysManagerFactroy();
                return _of.GetQueryLog(_startDate, _endDate, _userName);
            }
            catch (Exception ex)
            {
                string _error = string.Format("取查询日志信息[UserName={1}]时发生错误！{0}", ex.Message, _userName);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return new List<QueryLogRecord>();
            }
        }


        public Base.RefCode.RefCodeTablePropertie GetRefCodePropertie(string _refCodeName)
        {
            try
            {
                OraRefTableFactory _of = new OraRefTableFactory();
                return _of.GetRefCodePropertie(_refCodeName);
            }
            catch (Exception ex)
            {
                string _error = string.Format("取代码表属性定义[RefCodeName={1}]时发生错误！{0}", ex.Message, _refCodeName);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return null;
            }
        }

        public List<Base.RefCode.RefCodeData> GetFullRefCodeData(string _refCodeName)
        {
            try
            {
                OraRefTableFactory _of = new OraRefTableFactory();
                return _of.GetFullRefCodeData(_refCodeName);
            }
            catch (Exception ex)
            {
                string _error = string.Format("取完整代码表数据[RefCodeName={1}]时发生错误！{0}", ex.Message, _refCodeName);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return new List<Base.RefCode.RefCodeData>();
            }
        }

        public List<Base.RefCode.RefCodeData> GetChildRefCodeData(string _refCodeName, string _fatherCode)
        {
            try
            {
                OraRefTableFactory _of = new OraRefTableFactory();
                return _of.GetChildRefCodeData(_refCodeName, _fatherCode);
            }
            catch (Exception ex)
            {
                string _error = string.Format("取代码表子级记录[RefCodeName={1}  FatherCode={2}]时发生错误！{0}", ex.Message, _refCodeName, _fatherCode);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return new List<Base.RefCode.RefCodeData>();
            }
        }

        public Base.RefCode.RefCodeData GetRefCodeByCode(string _refCodeName, string _value)
        {
            try
            {
                OraRefTableFactory _of = new OraRefTableFactory();
                return _of.GetRefCodeByCode(_refCodeName, _value);
            }
            catch (Exception ex)
            {
                string _error = string.Format("通过代码值取代码数据记录[RefCodeName={1}  Code={2}]时发生错误！{0}", ex.Message, _refCodeName, _value);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return null;
            }
        }

        public List<Base.WorkCalendar.WC_DataInfo> GetDataInfo(int Year)
        {
            try
            {
                OraSysManagerFactroy _of = new OraSysManagerFactroy();
                return _of.GetDataInfo(Year);
            }
            catch (Exception ex)
            {
                string _error = string.Format("取工作日历记录[YEAR={1}  ]时发生错误！{0}", ex.Message, Year);
                ///SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return new List<WC_DataInfo>();
            }
        }

        public WC_TJSB_Settings GetTJSBSettings()
        {
            try
            {
                OraSysManagerFactroy _of = new OraSysManagerFactroy();
                return _of.GetTJSBSettings();
            }
            catch (Exception ex)
            {
                string _error = string.Format("取统计上报日默认日期时发生错误！{0}", ex.Message);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return null;
            }
        }


        public bool SaveTJSBSettings(WC_TJSB_Settings Settings)
        {
            try
            {
                OraSysManagerFactroy _of = new OraSysManagerFactroy();
                return _of.SaveTJSBSettings(Settings);
            }
            catch (Exception ex)
            {
                string _error = string.Format("保存统计上报日默认日期时发生错误！{0}", ex.Message);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
        }


        public bool SaveDataInfo(WC_DataInfo DataInfo)
        {
            try
            {
                OraSysManagerFactroy _of = new OraSysManagerFactroy();
                return _of.SaveDataInfo(DataInfo);
            }
            catch (Exception ex)
            {
                string _error = string.Format("保存工作日历的日期设置时发生错误！{0}", ex.Message);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
        }


        public bool ResetService(string ServiceName, string state)
        {
            switch (state.ToUpper())
            {
                case "START":
                    return ReStartService(ServiceName);
                case "STOP":
                    return ReStopService(ServiceName);
                default:
                    return true;
            }

        }

        public bool ReStopService(string ServiceName)
        {
            try
            {
                ServiceController _sc = new ServiceController(ServiceName);

                if (_sc.Status != ServiceControllerStatus.Stopped)
                {
                    _sc.Stop();
                    //等待服务停止，3分钟后超时
                    _sc.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 3, 0));
                }
                return (_sc.Status == ServiceControllerStatus.Stopped);
            }
            catch (Exception ex)
            {
                string _error = string.Format("停止服务[{1}]时发生错误！{0} ", ex.Message, ServiceName);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
        }
        public bool ReStartService(string ServiceName)
        {

            try
            {
                ServiceController _sc = new ServiceController(ServiceName);


                if (_sc.Status == ServiceControllerStatus.Stopped)
                {
                    _sc.Start();
                    //等待服务停止，3分钟后超时
                    try
                    {
                        _sc.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 3, 0));
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("再次启动服务时出错：{0}", ex));
                    }
                }
                else
                {
                    return false;
                }

                return (_sc.Status == ServiceControllerStatus.Running);
            }
            catch (Exception ex)
            {
                string _error = string.Format("启动服务[{1}]时发生错误！{0} ", ex.Message, ServiceName);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
        }

        public string GetServiceState(string ServiceName)
        {
            try
            {
                ServiceController _sc = new ServiceController(ServiceName);
                return _sc.Status.ToString();
            }
            catch (Exception ex)
            {
                string _error = string.Format("取服务[{1}]的状态时发生错误！{0} ", ex.Message, ServiceName);
                ////SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return "ERROR";
            }
        }


        public string RecycleIISPool(string AppPoolName)
        {
            try
            {
                //如果应用程序池当前状态为停止,则会发生异常报错
                string method = "Recycle";
                DirectoryEntry appPool = new DirectoryEntry("IIS://localhost/W3SVC/AppPools");
                DirectoryEntry findPool = appPool.Children.Find(AppPoolName, "IIsApplicationPool");
                findPool.Invoke(method, null);
                appPool.CommitChanges();
                appPool.Close();
                return "回收成功";
            }
            catch (Exception ex)
            {
                string _error = string.Format("回收IIS应用程序池[{1}]时发生错误！{0} ", ex.Message, AppPoolName);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return "ERROR";
            }
        }


        public bool HeartBeat()
        {
            return true;
        }


        public List<GDSCommanderDefine> GetGDSList()
        {
            try
            {
                OraSysManagerFactroy _of = new OraSysManagerFactroy();
                return _of.GetGDSList();
            }
            catch (Exception ex)
            {
                string _error = string.Format("取通用接口定义列表信息时发生错误！{0}", ex.Message);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return null;
            }
        }

        public bool SaveGDSDefine(GDSCommanderDefine GDSDefine)
        {
            try
            {
                OraSysManagerFactroy _of = new OraSysManagerFactroy();
                return _of.SaveGDSDefine(GDSDefine);
            }
            catch (Exception ex)
            {
                string _error = string.Format("保存通用接口定义信息时发生错误！{0}", ex.Message);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
        }

        public bool DelGDSDefine(string GDSDefineID)
        {
            try
            {
                OraSysManagerFactroy _of = new OraSysManagerFactroy();
                return _of.DelGDSDefine(GDSDefineID);
            }
            catch (Exception ex)
            {
                string _error = string.Format("删除通用接口定义信息时发生错误！{0}", ex.Message);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
        }


        public List<GDSTokenRecord> GetTokenRecord(string GDSCommandName)
        {
            List<GDSTokenRecord> _ret = new List<GDSTokenRecord>();
            try
            {
                OraSysManagerFactroy _of = new OraSysManagerFactroy();
                _ret = _of.GetTokenRecord(GDSCommandName);
            }
            catch (Exception ex)
            {
                string _error = string.Format("取通用接口的令牌信息时发生错误！{0}", ex.Message);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
            }
            return _ret;
        }

        public bool InsertTokenRecord(GDSTokenRecord Record)
        {
            try
            {
                OraSysManagerFactroy _of = new OraSysManagerFactroy();
                return _of.InsertICSTokenRecord(Record);
            }
            catch (Exception ex)
            {
                string _error = string.Format("添加通用接口令牌信息时发生错误！{0}", ex.Message);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
        }

        public bool UpdateTokenRecord(GDSTokenRecord Record)
        {
            try
            {
                OraSysManagerFactroy _of = new OraSysManagerFactroy();
                return _of.UpdateICSTokenRecord(Record);
            }
            catch (Exception ex)
            {
                string _error = string.Format("修改通用接口令牌信息时发生错误！{0}", ex.Message);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
        }


        public bool DelICSTokenRecord(string RecordID)
        {
            try
            {
                OraSysManagerFactroy _of = new OraSysManagerFactroy();
                return _of.DelICSTokenRecord(RecordID);
            }
            catch (Exception ex)
            {
                string _error = string.Format("删除通用接口令牌信息时发生错误！{0}", ex.Message);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
        }


        public DataTable GetICSLogRecord(string CommandName, decimal RowCount)
        {
            try
            {
                OraSysManagerFactroy _of = new OraSysManagerFactroy();
                return _of.GetICSLogRecord(CommandName, RowCount);
            }
            catch (Exception ex)
            {
                string _error = string.Format("取通用接口日志信息时发生错误！{0}", ex.Message);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return null;
            }
        }


        public string GetServerVersionList()
        {
            try
            {
                StringBuilder _sb = new StringBuilder();
                AssemblyName myAssemblyName = null;
                DirectoryInfo dirInfo = new DirectoryInfo(Utils.ExeDir);
                foreach (FileSystemInfo _fs in dirInfo.GetFileSystemInfos())
                {
                    string FileName = "";
                    string FileExt = "";
                    //如果是文件
                    if (_fs is FileInfo)
                    {
                        FileInfo fi = (FileInfo)_fs;
                        FileName = fi.Name;
                        //取得文件的扩展名
                        FileExt = fi.Extension.ToUpper();

                        if (FileExt == ".DLL" || FileExt == ".EXE")
                        {
                            myAssemblyName = AssemblyName.GetAssemblyName(_fs.FullName);
                            _sb.AppendLine(string.Format("{0} : {1}", FileName, myAssemblyName.Version.ToString()));
                        }
                    }
                }
                return _sb.ToString();
            }
            catch (Exception ex)
            {
                string _error = string.Format("取服务器EXE和DLL文件的版本信息时发生错误！{0}", ex.Message);
                //SystemLogWriter.WriteLog(_error, System.Diagnostics.EventLogEntryType.Error);
                return _error;
            }
        }
    }
}
