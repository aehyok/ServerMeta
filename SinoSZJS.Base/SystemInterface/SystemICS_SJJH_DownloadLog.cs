using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.SystemInterface
{
	public class SystemICS_SJJH_DownloadLog
	{
		private string logonName = "";
		private string tableName = "";
		private DateTime dowloadTime = DateTime.Now;
		private int ods_id = 0;
		private string actionType = "";


		public SystemICS_SJJH_DownloadLog(string _logonName, string _tableName, DateTime _date, int _ods_id, string _action)
		{
			logonName = _logonName;
			tableName = _tableName;
			dowloadTime = _date;
			ods_id = _ods_id;
			actionType = _action;
		}
		public string ActionType
		{
			get { return actionType; }
			set { actionType = value; }
		}

		public string LogonName
		{
			get { return logonName; }
			set { logonName = value; }
		}

		public string TableName
		{
			get { return tableName; }
			set { tableName = value; }
		}

		public DateTime DownloadTime
		{
			get
			{
				return dowloadTime;
			}
			set { dowloadTime = value; }
		}

		public int ODS_ID
		{
			get { return ods_id; }
			set { ods_id = value; }
		}


	}
}
