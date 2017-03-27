using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SinoSZJS.Base.Authorize;
using SinoSZJS.Base.Config;
using SinoSZJS.Base.MenuType;
using SinoSZJS.Base.UserLog;
using SinoSZJS.Base.SystemLog;
using System.Data;
using SinoSZJS.Base.Notify;
using SinoSZJS.Base.OrganizeExt;
using SinoSZJS.Base.TaskInfo;
using SinoSZJS.Base.RefCode;
using SinoSZJS.Base.WorkCalendar;
using SinoSZJS.Base.JSGDS;

namespace SinoSZJS.WCF.Lib
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ICommonService”。
    /// <summary>
    /// 通用服务
    /// </summary>
    [ServiceContract]
    public interface ICommonService
    {
        /// <summary>
        /// 取组织机构树型列表
        /// </summary>
        /// <param name="RootDWID">根单位ID</param>
        /// <param name="LevelNum">层级</param>
        /// <returns></returns>
        [OperationContract]
        List<SinoOrganize> GetRootDwList(string RootDWID, decimal LevelNum);
        /// <summary>
        /// 取扩展组织机构树型列表
        /// </summary>
        /// <param name="RootDWID">根单位ID</param>
        /// <param name="LevelNum">层级</param>
        /// <param name="OrgType">类型</param>
        /// <returns></returns>
        [OperationContract]
        List<SinoOrganize> GetRootDwListEx(string RootDWID, decimal LevelNum, string OrgType);
        /// <summary>
        /// 取服务器配置
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        ServerConfig GetServerConfig();

        /// <summary>
        /// 取服务器端所有执行文件的版本号
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        string GetServerVersionList();

        /// <summary>
        /// 通过DWDM取单位ID
        /// </summary>
        /// <param name="_dwdm"></param>
        /// <returns></returns>
        [OperationContract]
        decimal GetDWIDByDWDM(string _dwdm);
        /// <summary>
        /// 记录导出日志
        /// </summary>
        /// <param name="_exportRowCount"></param>
        /// <param name="ExportDataMsg"></param>
        [OperationContract]
        void WriteExportLog(int ExportRowCount, string ExportDataMsg);
        /// <summary>
        /// 写客户端用户操作日志到服务器
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="LogType"></param>
        [OperationContract]
        void WriteClientUserLog(string Message, string LogType);
        /// <summary>
        /// 根据用户的岗位取所有的菜单
        /// </summary>
        /// <param name="_postID"></param>
        /// <returns></returns>
        [OperationContract]
        List<SinoMenuItem> GetAllMenus(string PostID);
        /// <summary>
        /// 取用户的首页面
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<firstPageItem> GetfirstPage();

        /// <summary>
        /// 写用户操作日志
        /// </summary>
        /// <param name="YHID"></param>
        /// <param name="CZLX"></param>
        /// <param name="CXNR"></param>
        /// <param name="ResultType"></param>
        /// <param name="IpAddr"></param>
        /// <param name="HostName"></param>
        /// <param name="SystemID"></param>
        /// <returns></returns>
        [OperationContract]
        bool WriteUserLog(decimal YHID, string CZLX, string CXNR, decimal ResultType, string IpAddr, string HostName, string SystemID);

        /// <summary>
        /// 取用户操作日志
        /// </summary>
        /// <param name="StartDate">开始日期</param>
        /// <param name="EndDate">结束日期</param>
        /// <param name="UserName">用户名</param>
        /// <param name="Context">包含的内容关键字</param>
        /// <returns></returns>
        [OperationContract]
        List<UserLogRecord> GetUserLog(DateTime StartDate, DateTime EndDate, string UserName, string Context);

        /// <summary>
        /// 取系统操作日志
        /// </summary>
        /// <param name="StartDate">开始日期</param>
        /// <param name="EndDate">结束日期</param>
        /// <param name="Logtype">日志类型</param>
        /// <param name="Context">包含的内容关键字</param>
        /// <returns></returns>
        [OperationContract]
        List<SystemLogRecord> GetSystemLog(DateTime StartDate, DateTime EndDate, string LogType, string Context);

        /// <summary>
        /// 取通知通告信息列表
        /// </summary>
        /// <param name="_num"></param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetNotifyList(int _num);

        /// <summary>
        /// 取通知通告信息内容
        /// </summary>
        /// <param name="_msgid"></param>
        /// <returns></returns>
        [OperationContract]
        NotifyInfo GetNotifyInfo(string _msgid);

        /// <summary>
        /// 保存通知通告信息
        /// </summary>
        /// <param name="_info"></param>
        [OperationContract]
        bool SaveNotifyInfo(NotifyInfo _info);

        /// <summary>
        /// 删除通知通告信息
        /// </summary>
        /// <param name="CurrentInfo"></param>
        /// <returns></returns>
        [OperationContract]
        bool DeleteNotifyInfo(NotifyInfo CurrentInfo);

        /// <summary>
        /// 取根的组织机构扩展数据
        /// </summary>
        /// <param name="PropertieDefines"></param>
        /// <returns></returns>
        [OperationContract]
        List<OrgExtInfo> GetOrgExtRootData(List<OrgExtFieldDefine> PropertieDefines);
        /// <summary>
        /// 取指定的组织机构了子机构扩展数据
        /// </summary>
        /// <param name="_fid"></param>
        /// <param name="PropertieDefines"></param>
        /// <returns></returns>
        [OperationContract]
        List<OrgExtInfo> GetOrgExtChildData(string _fid, List<OrgExtFieldDefine> PropertieDefines);

        /// <summary>
        /// 保存变更的组织机构扩展信息列表
        /// </summary>
        /// <param name="BeSavedDataList"></param>
        /// <param name="PropertieDefines"></param>
        /// <returns></returns>
        [OperationContract]
        bool SaveOrgExtList(List<OrgExtInfo> BeSavedDataList, List<OrgExtFieldDefine> PropertieDefines);

        /// <summary>
        /// 取任务信息
        /// </summary>
        /// <param name="TaskID"></param>
        /// <returns></returns>
        [OperationContract]
        SinoTaskInfo GetTaskInfo(string TaskID);

        /// <summary>
        /// 取任务日志
        /// </summary>
        /// <param name="TaskID"></param>
        /// <param name="LastTime"></param>
        /// <param name="GetStartData"></param>
        /// <param name="OnlyErrorData"></param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetTaskLog(string TaskID, DateTime LastTime, bool GetStartData, bool OnlyErrorData);

        /// <summary>
        /// 设置任务状态
        /// </summary>
        /// <param name="TaskID"></param>
        /// <param name="NewState"></param>
        /// <param name="LimitState"></param>
        /// <returns></returns>
        [OperationContract]
        string SetTaskState(string TaskID, int NewState, int LimitState);

        /// <summary>
        /// 重置任务参数
        /// </summary>
        /// <param name="TaskID"></param>
        /// <param name="NextTime"></param>
        /// <param name="NewParam"></param>
        /// <returns></returns>
        [OperationContract]
        string ResetTaskParam(string TaskID, DateTime NextTime, string NewParam);

        /// <summary>
        /// 取查询日志
        /// </summary>
        /// <param name="_startDate"></param>
        /// <param name="_endDate"></param>
        /// <param name="_userName"></param>
        /// <returns></returns>
        [OperationContract]
        List<QueryLogRecord> GetQueryLog(DateTime _startDate, DateTime _endDate, string _userName);
        /// <summary>
        /// 取代码表属性
        /// </summary>
        /// <param name="_refCodeName"></param>
        /// <returns></returns>
        [OperationContract]
        RefCodeTablePropertie GetRefCodePropertie(string _refCodeName);
        /// <summary>
        /// 取完整代码表数据
        /// </summary>
        /// <param name="_refCodeName"></param>
        /// <returns></returns>
        [OperationContract]
        List<RefCodeData> GetFullRefCodeData(string _refCodeName);
        /// <summary>
        /// 取子代码数据
        /// </summary>
        /// <param name="_refCodeName"></param>
        /// <param name="_fatherCode"></param>
        /// <returns></returns>
        [OperationContract]
        List<RefCodeData> GetChildRefCodeData(string _refCodeName, string _fatherCode);
        /// <summary>
        /// 通过代码表代码项
        /// </summary>
        /// <param name="_value"></param>
        /// <returns></returns>
        [OperationContract]
        RefCodeData GetRefCodeByCode(string _refCodeName, string _value);

        [OperationContract]
        List<WC_DataInfo> GetDataInfo(int Year);
        [OperationContract]
        bool SaveDataInfo(WC_DataInfo DataInfo);

        [OperationContract]
        WC_TJSB_Settings GetTJSBSettings();

        [OperationContract]
        bool SaveTJSBSettings(WC_TJSB_Settings Settings);

        [OperationContract]
        bool ResetService(string ServiceName, string state);

        [OperationContract]
        string GetServiceState(string ServiceName);

        [OperationContract]
        string RecycleIISPool(string AppPoolName);

        [OperationContract]
        List<GDSCommanderDefine> GetGDSList();

        [OperationContract]
        bool SaveGDSDefine(GDSCommanderDefine GDSDefine);

        [OperationContract]
        bool DelGDSDefine(string GDSDefineID);

        [OperationContract]
        bool HeartBeat();

        [OperationContract]
        List<GDSTokenRecord> GetTokenRecord(string GDSCommandName);

        [OperationContract]
        bool InsertTokenRecord(GDSTokenRecord Record);

        [OperationContract]
        bool UpdateTokenRecord(GDSTokenRecord Record);

        [OperationContract]
        bool DelICSTokenRecord(string RecordID);

        [OperationContract]
        DataTable GetICSLogRecord(string CommandName, decimal RowCount);
    }
}
