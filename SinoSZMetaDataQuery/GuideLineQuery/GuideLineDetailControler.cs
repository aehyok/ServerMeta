using System;
using System.Collections.Generic;
using System.Text;
using SinoSZPluginFramework;
using SinoSZMetaDataQuery.DataQuery;

using SinoSZJS.Base.MetaData.QueryModel;

using SinoSZClientBase.Cache;
using SinoSZClientBase.MetaDataQueryService;

namespace SinoSZMetaDataQuery.GuideLineQuery
{
    public class GuideLineDetailControler
    {
        public static void ShowDetail(ShowDetailDataArgs _showArgs, IApplication _application)
        {
            if (_showArgs.Type == "GuideLine")
            {
                frmGuideLineQueryWithoutInput _f = new frmGuideLineQueryWithoutInput(_showArgs.GuideLine, _showArgs.QueryParams);
                _application.AddForm(Guid.NewGuid().ToString(), _f);
            }

            if (_showArgs.Type == "QueryModel")
            {
                using (MetaDataQueryServiceClient _msc = new MetaDataQueryServiceClient())
                {
                    string _mainKey = _msc.GetMainTableKeyByColumnCondition(_showArgs.QueryModelName,
                            _showArgs.QueryColumnName,
                            _showArgs.QueryDataValue);
                    MDModel_QueryModel _model = MetaDataCache.GetQueryModelDefine(_showArgs.QueryModelName);
                    frmSinoSZ_DataDetail _f = new frmSinoSZ_DataDetail(_model, _mainKey);
                    _application.AddForm(Guid.NewGuid().ToString(), _f);
                }
            }
        }
    }
}
