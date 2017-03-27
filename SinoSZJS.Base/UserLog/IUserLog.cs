using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.SystemLog;
using System.Data;
using SinoSZJS.Base.Notify;
using SinoSZJS.Base.SystemInterface;
using SinoSZJS.Base.OrganizeExt;
using SinoSZJS.Base.TaskInfo;

namespace SinoSZJS.Base.UserLog
{
        /// <summary>
        /// 用户日志接口
        /// </summary>
        public interface IUserLog
        {
                /// <summary>
                /// 写用户操作日志
                /// </summary>
                /// <param name="_yhid">用户ID</param>
                /// <param name="_czlx">操作类型</param>
                /// <param name="_cxnr">日志内容</param>
                /// <param name="_resulttype">操作结果类型　0.未知　1.成功　　2.失败　</param>
                /// <param name="_ipaddr">客户端IP地址</param>
                /// <param name="_hostName">客户端主机名称</param>
                /// <param name="_systemID">记录日志的系统ID</param>
                /// <returns></returns>             
                bool WriteUserLog(decimal _yhid, string _czlx, string _cxnr, decimal _resulttype, string _ipaddr, string _hostName, string _systemID);

                /// <summary>
                /// 取用户操作日志
                /// </summary>
                /// <param name="_startDate">开始日期</param>
                /// <param name="_endDate">结束日期</param>
                /// <param name="_userName">用户名</param>
                /// <param name="_context">包含的内容关键字</param>
                /// <returns></returns>
                List<UserLogRecord> GetUserLog(DateTime _startDate, DateTime _endDate, string _userName, string _context);

                /// <summary>
                /// 取系统操作日志
                /// </summary>
                /// <param name="_startDate">开始日期</param>
                /// <param name="_endDate">结束日期</param>
                /// <param name="_logtype">日志类型</param>
                /// <param name="_context">包含的内容关键字</param>
                /// <returns></returns>
                List<SystemLogRecord> GetSystemLog(DateTime _startDate, DateTime _endDate, string _logtype, string _context);


                /// <summary>
                /// 取通知通告信息列表
                /// </summary>
                /// <param name="_num"></param>
                /// <returns></returns>
                DataTable GetNotifyList(int _num);

                /// <summary>
                /// 取通知通告信息内容
                /// </summary>
                /// <param name="_msgid"></param>
                /// <returns></returns>
                NotifyInfo GetNotifyInfo(string _msgid);

                /// <summary>
                /// 保存通知通告信息
                /// </summary>
                /// <param name="_info"></param>
                bool SaveNotifyInfo(NotifyInfo _info);

                /// <summary>
                /// 删除通知通告信息
                /// </summary>
                /// <param name="CurrentInfo"></param>
                /// <returns></returns>
                bool DeleteNotifyInfo(NotifyInfo CurrentInfo);

                List<SystemICS_SJJH> GetSJJHInterfaceList();

                List<SystemICS_SJJH_DataTable> GetSJJHTableList(string _yhm);

                List<SystemICS_SJJH_DownloadLog> GetSJJHProcessList(string _yhm, DateTime _start, DateTime _end);

                List<SystemICS_SJJH_Node> GetSJJHNodeList();

                /// <summary>
                /// 取根的组织机构扩展数据
                /// </summary>
                /// <param name="PropertieDefines"></param>
                /// <returns></returns>
                List<OrgExtInfo> GetOrgExtRootData(List<OrgExtFieldDefine> PropertieDefines);
                /// <summary>
                /// 取指定的组织机构了子机构扩展数据
                /// </summary>
                /// <param name="_fid"></param>
                /// <param name="PropertieDefines"></param>
                /// <returns></returns>
                List<OrgExtInfo> GetOrgExtChildData(string _fid, List<OrgExtFieldDefine> PropertieDefines);

                /// <summary>
                /// 保存变更的组织机构扩展信息列表
                /// </summary>
                /// <param name="BeSavedDataList"></param>
                /// <param name="PropertieDefines"></param>
                /// <returns></returns>
                bool SaveOrgExtList(List<OrgExtInfo> BeSavedDataList, List<OrgExtFieldDefine> PropertieDefines);


                DataTable GetFsDataLoadAlertMailReceiver(string _selectedStr);

                bool DelFsDataLoadAlertReceiver(string id);

                bool ModifyFsDataLoadAlertReceiver(string id, string EmailAddr);

                bool AddFsDataLoadAlertReceiver(string lx, string EmailAddr);

                Dictionary<string, SystemICS_SJJH_DownloadLog> GetSJJHState(string _yhm);

                SinoTaskInfo GetTaskInfo(string TaskID);

                DataTable GetTaskLog(string TaskID, DateTime LastTime, bool GetStartData, bool OnlyErrorData);

                string SetTaskState(string TaskID, int NewState, int LimitState);

                string ResetTaskParam(string TaskID, DateTime NextTime, string NewParam);

                List<QueryLogRecord> GetQueryLog(DateTime _startDate, DateTime _endDate, string _userName);
             
        }
}
