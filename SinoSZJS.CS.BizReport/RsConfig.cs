using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace SinoSZJS.CS.BizReport
{
    public class RsConfig
    {
        static private string name = "";
        static private string pass = "";
        static private string rsUrl = "";
        static private string interfaceType = "OLD";
        static private bool initFinished = false;
        /// <summary>
        /// ReportingService用户名
        /// </summary>
        static public string Name
        {
            get
            {
                if (!initFinished)
                {
                    InitConifg();
                }
                return name;
            }
        }

        /// <summary>
        /// ReportingService密码
        /// </summary>
        static public string Pass
        {
            get
            {
                if (!initFinished) InitConifg();
                return pass;
            }
        }
        /// <summary>
        /// ReportingService地址
        /// </summary>
        static public string RsURL
        {
            get
            {
                if (!initFinished) InitConifg();
                return rsUrl;
            }

        }

        static public string InterfaceType
        {
            get
            {
                if (!initFinished) InitConifg();
                if (interfaceType == null || interfaceType == "") interfaceType = "OLD";
                return interfaceType;
            }
        }
        private static void InitConifg()
        {
            rsUrl = ConfigurationManager.AppSettings["Rs_Url"];
            name = ConfigurationManager.AppSettings["Rs_UserName"];
            pass = ConfigurationManager.AppSettings["Rs_UserPass"];
            try
            {
                interfaceType = ConfigurationManager.AppSettings["Rs_Type"].ToUpper();
            }
            catch
            {
                interfaceType = "OLD";
            }

        }
    }
}
