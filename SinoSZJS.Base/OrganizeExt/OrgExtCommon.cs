using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSZJS.Base.OrganizeExt
{
    public static class OrgExtCommon
    {
        public static void SetValue(this OrgExtInfo OrgExt, string FieldName, object _data)
        {
            if (OrgExt.ExtProperties.ContainsKey(FieldName))
            {
                OrgExt.ExtProperties[FieldName] = _data.ToString();
            }
            else
            {
                OrgExt.ExtProperties.Add(FieldName, _data.ToString());
            }
        }

        public static string GetValue(this OrgExtInfo OrgExt, string FieldName)
        {
            if (OrgExt.ExtProperties.ContainsKey(FieldName))
            {
                return OrgExt.ExtProperties[FieldName];
            }
            else
            {
                return null;
            }
        }
    }
}
