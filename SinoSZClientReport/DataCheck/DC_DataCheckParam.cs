using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.DataCheck;


namespace SinoSZClientReport.DataCheck
{
        [Serializable]
        public class DC_DataCheckParam
        {
                public MDQuery_Request Request = null;
                public List<MD_CheckRule> Rules = null;                
                public string DWDM = "";
                public DC_FilterDefine FilterDefine = null;

                public DC_DataCheckParam() { }

                public DC_DataCheckParam(MDQuery_Request _request, List<MD_CheckRule> _rules, string _dwdm,DC_FilterDefine _filter)
                {
                        Request = _request;
                        Rules = _rules;
                        DWDM = _dwdm;
                        FilterDefine = _filter;
                }
        }
}
