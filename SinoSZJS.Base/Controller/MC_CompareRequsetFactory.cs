using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.DataCompare;

namespace SinoSZJS.Base.Controller
{
	public class MC_CompareRequsetFactory : MC_QueryRequsetFactory
	{
		private MDCompare_Request compareRequest = new MDCompare_Request();
		public MC_CompareRequsetFactory()
		{
			this.queryRequest = compareRequest as MDQuery_Request;
		}

		public MDCompare_Request GetCompareQueryRequest()
		{
			return compareRequest;
		}

		public void AddCompareExpression(string _expression)
		{
			compareRequest.CompareConditionExpression = _expression;
		}

		public void AddCompareConditonItem(MDCompare_ConditionItem _cItem)
		{
			this.compareRequest.CompareItems.Add(_cItem.ColumnIndex, _cItem);
		}


	}
}
