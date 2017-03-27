using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.Define;
using SinoSZClientBase.MetaDataQueryService;
using SinoSZJS.Base.MetaData.Common;
using SinoSZJS.Base.MetaData.DataCheck;

namespace SinoSZClientBase.Cache
{
    public class MetaDataCache
    {
        private static Dictionary<string, MDModel_QueryModel> QueryModelLib = new Dictionary<string, MDModel_QueryModel>();
        private static Dictionary<string, List<MD_CheckRule>> CheckRuleLib = new Dictionary<string, List<MD_CheckRule>>();

        public static MDModel_QueryModel GetQueryModelDefine(string QueryModelName)
        {
            if (!QueryModelLib.ContainsKey(QueryModelName))
            {
                using (MetaDataQueryServiceClient _sc = new MetaDataQueryServiceClient())
                {
                    MD_QueryModel _qv = _sc.GetMDQueryModelDefine(QueryModelName);
                    QueryModelLib.Add(QueryModelName, MC_QueryModel.CreateQuery_ModelDefine(_qv));
                }
            }
            return QueryModelLib[QueryModelName];
        }

        public static List<MD_CheckRule> GetDataCheckRuleDefine(string QueryModelName, bool NeedRefresh)
        {
            using (MetaDataQueryServiceClient _sc = new MetaDataQueryServiceClient())
            {
                List<MD_CheckRule> _cr = _sc.GetDataCheckRuleDefine(QueryModelName).ToList<MD_CheckRule>();
                return _cr;
            }            
        }
    }
}
