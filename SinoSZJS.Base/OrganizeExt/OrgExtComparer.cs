using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.OrganizeExt
{
	public class OrgExtComparer : IComparer<OrgExtInfo>
	{
		#region IComparer<OrgExtInfo> Members

		public int Compare(OrgExtInfo x, OrgExtInfo y)
		{
			string _xorder = x.GetValue("DISPLAYORDER");
			if (_xorder == null) return 0;
			string _yorder = y.GetValue("DISPLAYORDER");
			if (_yorder == null) return 1;
			decimal _x = decimal.Parse(_xorder);
			decimal _y = decimal.Parse(_yorder);
			decimal _ret = _x - _y;
			if (_ret == 0) return 0;
			return (_ret > 0) ? 1 : -1;
		}

		#endregion
	}
}
