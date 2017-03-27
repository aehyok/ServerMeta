using System;
using System.Collections.Generic;
using System.Text;


using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZMetaDataQuery.GuideLineQuery
{
        public class ShowDetailDataArgs:EventArgs
        {
                public MD_GuideLine GuideLine = null;
                public List<MDQuery_GuideLineParameter> QueryParams = null;
                public string Type = "GuideLine";

                public string QueryModelName = "";
                public string QueryColumnName = "";
                public string QueryDataValue = "";
                public ShowDetailDataArgs(MD_GuideLine _guideLine, List<MDQuery_GuideLineParameter> _params)
                {
                        Type = "GuideLine";
                        GuideLine = _guideLine;
                        QueryParams = _params;
                }

                public ShowDetailDataArgs(string _modelName, string _columnName, string _dataValue)
                {
                        Type = "QueryModel";
                        QueryModelName = _modelName;
                        QueryColumnName = _columnName;
                        QueryDataValue = _dataValue;
                }
        }
}
