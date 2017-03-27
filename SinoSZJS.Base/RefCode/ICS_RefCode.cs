using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.RefCode
{
        public interface ICS_RefCode
        {
                RefCodeTablePropertie GetRefCodePropertie(string _refCodeName);
                List<RefCodeData> GetFullRefCodeData(string _refCodeName);
                List<RefCodeData> GetChildRefCodeData(string _refCodeName, string _fatherCode);
                /// <summary>
                /// 通过代码表代码项
                /// </summary>
                /// <param name="_value"></param>
                /// <returns></returns>
                RefCodeData GetRefCodeByCode(string _refCodeName,string _value);
        }
}
