using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.CS.BizMetaDataManager.DAL
{
	public class OraCommandSecretCheck
	{
		public static string CheckTableName(string TableName)
		{
			string _ret = TableName.Trim();
			_ret = _ret.Replace(" ", "");
			_ret = _ret.Replace(";", "");
			return _ret;
		}
	}
}
