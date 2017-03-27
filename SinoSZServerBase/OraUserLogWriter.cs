using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.UserLog;
using SinoSZJS.Base.SystemLog;
using System.Data;
using SinoSZJS.Base.SystemInterface;
using SinoSZJS.Base.OrganizeExt;
using SinoSZJS.DataAccess;

namespace SinoSZServerBase
{
        public class OraUserLogWriter : IUserLog
        {
                #region IUserLog Members

                public bool WriteUserLog(decimal _yhid, string _czlx, string _cxnr, decimal _resulttype, string _ipaddr, string _hostName, string _systemID)
                {
                        return OralceLogWriter.WriteUserLog(_yhid, _czlx, _cxnr, _resulttype, _ipaddr, _hostName, _systemID);
                }

          

                public List<UserLogRecord> GetUserLog(DateTime _startDate, DateTime _endDate, string _userName, string _context)
                {
                        return null;
                }


                public List<SystemLogRecord> GetSystemLog(DateTime _startDate, DateTime _endDate, string _logtype, string _context)
                {
                        return null;
                }



                public DataTable GetNotifyList(int _num)
                {
                        return null;
                }


                public SinoSZJS.Base.Notify.NotifyInfo GetNotifyInfo(string _msgid)
                {
                        return null;
                }

          

                public List<SystemICS_SJJH> GetSJJHInterfaceList()
                {
                        return null;
                }

           

                public List<SystemICS_SJJH_DataTable> GetSJJHTableList(string _yhm)
                {
                        return null;
                }

            
		public List<SystemICS_SJJH_DownloadLog> GetSJJHProcessList(string _yhm, DateTime _start, DateTime _end)
                {
                        return null;
                }


                public List<SystemICS_SJJH_Node> GetSJJHNodeList()
                {
                        return null;
                }

            

                public List<SinoSZJS.Base.OrganizeExt.OrgExtInfo> GetOrgExtRootData(List<SinoSZJS.Base.OrganizeExt.OrgExtFieldDefine> PropertieDefines)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

        
                public List<SinoSZJS.Base.OrganizeExt.OrgExtInfo> GetOrgExtChildData(string _fid, List<SinoSZJS.Base.OrganizeExt.OrgExtFieldDefine> PropertieDefines)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

            
                public bool SaveOrgExtList(List<SinoSZJS.Base.OrganizeExt.OrgExtInfo> BeSavedDataList,List<OrgExtFieldDefine> PropertieDefines)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

             
                public void SaveNotifyInfo(SinoSZJS.Base.Notify.NotifyInfo _info)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

                public bool DeleteNotifyInfo(SinoSZJS.Base.Notify.NotifyInfo CurrentInfo)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

          
                bool IUserLog.SaveNotifyInfo(SinoSZJS.Base.Notify.NotifyInfo _info)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

            
		public DataTable GetFsDataLoadAlertMailReceiver(string _selectedStr)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		

		public bool DelFsDataLoadAlertReceiver(string id)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public bool ModifyFsDataLoadAlertReceiver(string id, string EmailAddr)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public bool AddFsDataLoadAlertReceiver(string lx, string EmailAddr)
		{
			throw new Exception("The method or operation is not implemented.");
		}


		public Dictionary<string, SystemICS_SJJH_DownloadLog> GetSJJHState(string _yhm)
		{
			throw new Exception("The method or operation is not implemented.");
		}

	
                public SinoSZJS.Base.TaskInfo.SinoTaskInfo GetTaskInfo(string TaskID)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

           
                public DataTable GetTaskLog(string TaskID, DateTime LastTime, bool GetStartData, bool OnlyErrorData)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

           
                public string SetTaskState(string TaskID, int NewState, int LimitState)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

        

                public string ResetTaskParam(string TaskID, DateTime NextTime, string NewParam)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

         

                public List<QueryLogRecord> GetQueryLog(DateTime _startDate, DateTime _endDate, string _userName)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

                #endregion
        }
}
