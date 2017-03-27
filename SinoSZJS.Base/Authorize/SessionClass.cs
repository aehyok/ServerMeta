using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using SinoSZJS.Base.Config;

namespace SinoSZJS.Base.Authorize
{
    public class SessionClass
    {
        public static string CurrentLogonName = "";
        public static string CurrentLogonPass = "";
        public static string CurrentCheckType = "";
        public static ServerConfig ServerConfigData = null;
        private static SinoSZTicketInfo _currentTicket = null;
        public static SinoSZTicketInfo CurrentTicket
        {
            get { return _currentTicket; }
            set { _currentTicket = value; }
        }

        public static AssemblyName SysAssemblyName = null;

        public static Assembly sysResourcesAssembly = null;
        public static Assembly SysResourcesAssembly
        {
            get
            {
                if (sysResourcesAssembly == null)
                {
                    return Assembly.GetEntryAssembly();
                }
                else
                { return sysResourcesAssembly; }
            }

            set { sysResourcesAssembly = value; }
        }


        public static SinoUser CurrentSinoUser = null;

        public static int RemoteRenewValue
        {
            get
            {
                if (ServerConfigData == null)
                {
                    return 20;
                }
                else
                {
                    return ServerConfigData.RemoteRenewValue;
                }
            }
        }

        public static string RootOrgID
        {
            get
            {
                if (ServerConfigData == null)
                {
                    return "";
                }
                else
                {
                    return ServerConfigData.RootOrgID;
                }
            }
        }
    }
}
